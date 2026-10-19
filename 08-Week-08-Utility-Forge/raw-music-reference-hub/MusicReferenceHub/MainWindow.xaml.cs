using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using Microsoft.Win32;

namespace MusicReferenceHub;

public partial class MainWindow : Window
{
    private readonly System.Collections.ObjectModel.ObservableCollection<string> links = new();
    private bool mediaReady = false;
    private bool isPlaying = false;

    // Fields for playback tracking
    private DispatcherTimer timer;
    private bool isDraggingSlider = false;
    private List<string> playlist = new();
    private int currentTrackIndex = -1;

    public MainWindow()
    {
        InitializeComponent();
        lstLinks.ItemsSource = links;

        // Setup timer for progress slider
        timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(500) };
        timer.Tick += Timer_Tick;
    }

    private void Timer_Tick(object sender, EventArgs e)
    {
        if (!isDraggingSlider && mediaPlayer.NaturalDuration.HasTimeSpan)
        {
            progressSlider.Maximum = mediaPlayer.NaturalDuration.TimeSpan.TotalSeconds;
            progressSlider.Value = mediaPlayer.Position.TotalSeconds;
        }
    }

    private void LoadLocalMedia()
    {
        var dialog = new OpenFileDialog
        {
            Filter = "Audio|*.mp3;*.wav;*.wma|All files|*.*"
        };

        if (dialog.ShowDialog() != true)
        {
            txtStatus.Text = "Load canceled. Choose a file when ready.";
            return;
        }

        mediaPlayer.Stop();
        isPlaying = false;
        mediaReady = false;
        mediaPlayer.Source = new Uri(dialog.FileName);
        txtNowPlaying.Text = Path.GetFileName(dialog.FileName);
        txtStatus.Text = "Opening media. Wait for Ready before Play.";
    }


    private void PlayTrack(int index)
    {
        if (index < 0 || index >= playlist.Count) return;

        string filePath = playlist[index];
        mediaPlayer.Stop();
        isPlaying = false;
        mediaReady = false;
        mediaPlayer.Source = new Uri(filePath);
        txtNowPlaying.Text = Path.GetFileName(filePath);
        txtStatus.Text = "Opening media. Wait for Ready before Play.";

        ExtractMetadataArtwork(filePath);
    }

    private void ExtractMetadataArtwork(string filePath)
    {
        try
        {
            // Requires TagLibSharp NuGet Package
            var file = TagLib.File.Create(filePath);
            if (file.Tag.Pictures.Length > 0)
            {
                var bin = (byte[])(file.Tag.Pictures[0].Data.Data);
                using (var stream = new MemoryStream(bin))
                {
                    var bitmap = new System.Windows.Media.Imaging.BitmapImage();
                    bitmap.BeginInit();
                    bitmap.CacheOption = System.Windows.Media.Imaging.BitmapCacheOption.OnLoad;
                    bitmap.StreamSource = stream;
                    bitmap.EndInit();
                    imgArtwork.Source = bitmap;
                    imgButton.Source = bitmap;
                }
            }
            else
            {
                // Clear artwork if track has none
                imgArtwork.Source = null;
                imgButton.Source = null;
            }
        }
        catch (Exception)
        {
            txtStatus.Text = "Could not extract track artwork.";
        }
    }

    private void Media_Opened(object sender, RoutedEventArgs e)
    {
        mediaReady = true;
        txtStatus.Text = "Ready. Press Play.";
    }

    private void Media_Failed(object sender, ExceptionRoutedEventArgs e)
    {
        mediaReady = false;
        isPlaying = false;
        timer.Stop();
        txtStatus.Text = "Media could not open. Try another local file or format.";
    }

    private void Media_Ended(object sender, RoutedEventArgs e)
    {
        mediaPlayer.Stop();
        isPlaying = false;

        if (playlist.Count > 0)
        {
            currentTrackIndex++;

            if (currentTrackIndex >= playlist.Count)
            {
                txtStatus.Text = "Playlist finished.";
                timer.Stop();
                return;
            }
            PlayTrack(currentTrackIndex);
        }
    }

    private void Play_Click(object sender, RoutedEventArgs e)
    {
        if (!mediaReady) { txtStatus.Text = "Load a supported local file first."; return; }
        mediaPlayer.Play();
        timer.Start();
        isPlaying = true;
        txtStatus.Text = "Playing.";
    }

    private void Pause_Click(object sender, RoutedEventArgs e)
    {
        if (!mediaReady) { txtStatus.Text = "Load a file first."; return; }
        if (!isPlaying) { txtStatus.Text = "Playback is already paused or stopped."; return; }
        mediaPlayer.Pause();
        timer.Stop();
        isPlaying = false;
        txtStatus.Text = "Paused. Play continues from this point.";
    }

    private void Stop_Click(object sender, RoutedEventArgs e)
    {
        if (!mediaReady) { txtStatus.Text = "Load a file first."; return; }
        mediaPlayer.Stop();
        timer.Stop();
        progressSlider.Value = 0;
        isPlaying = false;
        txtStatus.Text = "Stopped. Play starts from the beginning.";
    }

    private void Load_Click(object sender, RoutedEventArgs e) => LoadLocalMedia();

    // --- Slider Events ---
    private void ProgressSlider_DragStarted(object sender, MouseButtonEventArgs e) => isDraggingSlider = true;

    private void ProgressSlider_DragCompleted(object sender, MouseButtonEventArgs e)
    {
        isDraggingSlider = false;
        mediaPlayer.Position = TimeSpan.FromSeconds(progressSlider.Value);
    }

    private void ProgressSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        if (isDraggingSlider)
        {
            mediaPlayer.Position = TimeSpan.FromSeconds(progressSlider.Value);
        }
    }

    // --- Note & Link functions remain identical ---
    private void AddLink()
    {
        string address = txtLink.Text.Trim();
        if (!Uri.TryCreate(address, UriKind.Absolute, out Uri? uri) || (uri.Scheme != "https" && uri.Scheme != "http"))
        {
            txtStatus.Text = "Enter a complete https:// or http:// link.";
            return;
        }
        links.Add(uri.AbsoluteUri);
        txtLink.Clear();
        txtStatus.Text = "Reference added. Select it, then Open link.";
    }

    private void OpenSelectedLink()
    {
        if (lstLinks.SelectedItem is not string address) 
        { 
            txtStatus.Text = "Select a reference link first."; 
            return; 
        }
        try
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(address) 
            { UseShellExecute = true });
            txtStatus.Text = "Reference opened in your browser.";
        }
        catch (Exception ex) 
        { 
            txtStatus.Text = "Could not open the browser: " + ex.Message; 
        }
    }

    private void AddLink_Click(object sender, RoutedEventArgs e) => AddLink();
    private void OpenLink_Click(object sender, RoutedEventArgs e) => OpenSelectedLink();

    private void SaveText(string text)
    {
        var dialog = new SaveFileDialog { Filter = "Text files|*.txt", FileName = "music-record.txt" };
        if (dialog.ShowDialog() != true)
        {
            txtStatus.Text = "Save canceled. Your text stays here.";
            return;
        }
        try
        {
            File.WriteAllText(dialog.FileName, text);
            txtStatus.Text = "Saved: " + Path.GetFileName(dialog.FileName);
        }
        catch (Exception ex)
        {
            txtStatus.Text = "Could not save. Choose a writable folder: " + ex.Message;
        }
    }

    private void Open_Click(object sender, RoutedEventArgs e)
    {
        var dialog = new OpenFileDialog { Filter = "Text files|*.txt" };
        if (dialog.ShowDialog() != true)
        {
            txtStatus.Text = "Open canceled. Your current text stays here.";
            return;
        }
        try
        {
            txtNotes.Text = File.ReadAllText(dialog.FileName);
            txtStatus.Text = "Text reopened. Review it before editing.";
        }
        catch (Exception ex)
        {
            txtStatus.Text = "Could not read the file: " + ex.Message;
        }
    }

    private void Save_Click(object sender, RoutedEventArgs e) => SaveText(txtNotes.Text);

    private void Image_Click(object sender, RoutedEventArgs e)
    {
        var dialog = new OpenFileDialog { Filter = "Images|*.png;*.jpg;*.jpeg" };
        if (dialog.ShowDialog() != true) return;

        try
        {
            // Custom user image overwrites the UI display only, not the underlying metadata
            var bitmap = new System.Windows.Media.Imaging.BitmapImage();
            bitmap.BeginInit();
            bitmap.CacheOption = System.Windows.Media.Imaging.BitmapCacheOption.OnLoad;
            bitmap.UriSource = new Uri(dialog.FileName);
            bitmap.EndInit();
            imgArtwork.Source = bitmap;
            imgButton.Source = bitmap;
            txtStatus.Text = "Custom artwork loaded for current session.";
        }
        catch (Exception ex)
        {
            txtStatus.Text = "Choose a valid PNG or JPG: " + ex.Message;
        }
    }
}