using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using Microsoft.Win32;

namespace MusicReferenceHub;

public partial class MainWindow : Window
{
    private readonly System.Collections.ObjectModel.ObservableCollection<string> links = new();
    private readonly System.Collections.ObjectModel.ObservableCollection<string> favoriteDisplayNames = new();

    private bool mediaReady = false;
    private bool isPlaying = false;

    private readonly DispatcherTimer timer;
    private bool isDraggingSlider = false;
    private readonly List<string> playlist = new();
    private int currentTrackIndex = -1;

    private BitmapImage? defaultKittyImage;

    public MainWindow()
    {
        InitializeComponent();
        lstPlaylist.ItemsSource = favoriteDisplayNames;
        lstLinks.ItemsSource = links;

        timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(500) };
        timer.Tick += Timer_Tick;

        LoadDefaultArtwork();
    }

    private void LoadDefaultArtwork()
    {
        try
        {
            defaultKittyImage = new BitmapImage(new Uri("pack://application:,,,/Assets/Images/Hellokitty.jpg"));
            imgArtwork.Source = defaultKittyImage;
            imgButton.Source = defaultKittyImage;
        }
        catch (Exception)
        {
            // Fallback if local asset is missing
        }
    }

    private void Window_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (!lstPlaylist.IsMouseOver && !lstLinks.IsMouseOver)
        {
            lstPlaylist.SelectedItem = null;
            lstLinks.SelectedItem = null;
        }
    }

    private void Timer_Tick(object? sender, EventArgs e)
    {
        if (!isDraggingSlider && mediaPlayer.NaturalDuration.HasTimeSpan)
        {
            progressSlider.Maximum = mediaPlayer.NaturalDuration.TimeSpan.TotalSeconds;
            progressSlider.Value = mediaPlayer.Position.TotalSeconds;

            lblCurrentTime.Text = mediaPlayer.Position.ToString(@"mm\:ss");
            lblTotalTime.Text = mediaPlayer.NaturalDuration.TimeSpan.ToString(@"mm\:ss");
        }
    }

    private void LoadLocalMedia()
    {
        var dialog = new OpenFileDialog
        {
            Filter = "Audio Files|*.mp3;*.wav;*.wma;*.m4a;*.aac|All files|*.*",
            Multiselect = true
        };

        if (dialog.ShowDialog() != true || dialog.FileNames.Length == 0)
        {
            txtStatus.Text = "No songs added.";
            return;
        }

        foreach (string file in dialog.FileNames)
        {
            if (!playlist.Contains(file))
            {
                playlist.Add(file);
                favoriteDisplayNames.Add(Path.GetFileName(file));
            }
        }

        if (currentTrackIndex == -1 && playlist.Count > 0)
        {
            PlayTrack(0);
        }

        txtStatus.Text = $"Added {dialog.FileNames.Length} track(s) ♡";
    }

    private void PlayTrack(int index)
    {
        if (index < 0 || index >= playlist.Count) return;

        currentTrackIndex = index;
        string filePath = playlist[index];

        mediaPlayer.Stop();
        isPlaying = false;

        // Directly mark media ready when initiating playback
        mediaReady = true;
        mediaPlayer.Source = new Uri(filePath);
        txtNowPlaying.Text = Path.GetFileName(filePath);
        txtStatus.Text = "Opening track...";

        ExtractMetadataArtwork(filePath);

        mediaPlayer.Play();
        timer.Start();
        isPlaying = true;
    }

    private void LstPlaylist_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (lstPlaylist.SelectedIndex >= 0 && lstPlaylist.SelectedIndex < playlist.Count)
        {
            PlayTrack(lstPlaylist.SelectedIndex);
        }
    }

    private void ClearPlaylist_Click(object sender, RoutedEventArgs e)
    {
        mediaPlayer.Stop();
        timer.Stop();
        isPlaying = false;
        mediaReady = false;
        playlist.Clear();
        favoriteDisplayNames.Clear();
        currentTrackIndex = -1;
        txtNowPlaying.Text = "No track playing ♡";
        lblCurrentTime.Text = "00:00";
        lblTotalTime.Text = "00:00";
        progressSlider.Value = 0;

        if (defaultKittyImage != null)
        {
            imgArtwork.Source = defaultKittyImage;
        }

        txtStatus.Text = "Playlist cleared.";
    }

    private void ExtractMetadataArtwork(string filePath)
    {
        try
        {
            var file = TagLib.File.Create(filePath);
            if (file.Tag.Pictures.Length > 0)
            {
                var bin = (byte[])(file.Tag.Pictures[0].Data.Data);
                using var stream = new MemoryStream(bin);
                var bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.StreamSource = stream;
                bitmap.EndInit();

                imgArtwork.Source = bitmap;
                return;
            }
        }
        catch (Exception)
        {
            // Fall back to default artwork if extraction fails
        }

        if (defaultKittyImage != null)
        {
            imgArtwork.Source = defaultKittyImage;
        }
    }

    private void Media_Opened(object sender, RoutedEventArgs e)
    {
        mediaReady = true;
        txtStatus.Text = "Playing favorite track ♡";
        if (mediaPlayer.NaturalDuration.HasTimeSpan)
        {
            lblTotalTime.Text = mediaPlayer.NaturalDuration.TimeSpan.ToString(@"mm\:ss");
        }
    }

    private void Media_Failed(object sender, ExceptionRoutedEventArgs e)
    {
        mediaReady = false;
        isPlaying = false;
        timer.Stop();
        txtStatus.Text = "Unable to open audio file.";
    }

    private void Media_Ended(object sender, RoutedEventArgs e)
    {
        mediaPlayer.Stop();
        isPlaying = false;

        if (playlist.Count > 0 && currentTrackIndex + 1 < playlist.Count)
        {
            PlayTrack(currentTrackIndex + 1);
        }
        else
        {
            txtStatus.Text = "End of playlist reached ♡";
            timer.Stop();
        }
    }

    private void Play_Click(object sender, RoutedEventArgs e)
    {
        if (!mediaReady && playlist.Count > 0)
        {
            PlayTrack(0);
            return;
        }

        if (!mediaReady && mediaPlayer.Source == null)
        {
            txtStatus.Text = "Add favorite tracks first.";
            return;
        }

        mediaPlayer.Play();
        timer.Start();
        isPlaying = true;
        txtStatus.Text = "Playing ♡";
    }

    private void Pause_Click(object sender, RoutedEventArgs e)
    {
        if (!mediaReady && mediaPlayer.Source == null)
        {
            txtStatus.Text = "No track loaded.";
            return;
        }

        if (isPlaying)
        {
            mediaPlayer.Pause();
            timer.Stop();
            isPlaying = false;
            txtStatus.Text = "Paused ♡";
        }
        else
        {
            mediaPlayer.Play();
            timer.Start();
            isPlaying = true;
            txtStatus.Text = "Playing ♡";
        }
    }

    private void Stop_Click(object sender, RoutedEventArgs e)
    {
        if (!mediaReady && mediaPlayer.Source == null)
        {
            txtStatus.Text = "No track loaded.";
            return;
        }

        mediaPlayer.Stop();
        timer.Stop();
        progressSlider.Value = 0;
        lblCurrentTime.Text = "00:00";
        isPlaying = false;
        txtStatus.Text = "Stopped ♡";
    }

    private void Load_Click(object sender, RoutedEventArgs e) => LoadLocalMedia();

    private void VolumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        if (mediaPlayer != null)
        {
            mediaPlayer.Volume = volumeSlider.Value;
        }
    }

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
            lblCurrentTime.Text = TimeSpan.FromSeconds(progressSlider.Value).ToString(@"mm\:ss");
        }
    }

    private async Task ProcessYoutubeUrlAsync(string url)
    {
        txtStatus.Text = "Downloading audio from YouTube... Please wait ♡";

        string outputDirectory = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Downloads");
        Directory.CreateDirectory(outputDirectory);

        string ytDlpPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "yt-dlp.exe");

        if (!File.Exists(ytDlpPath))
        {
            txtStatus.Text = "Error: yt-dlp.exe missing in output folder!";
            MessageBox.Show("Please make sure yt-dlp.exe, ffmpeg.exe, and ffprobe.exe are placed in your app folder.",
                            "Missing Executable", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        try
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = ytDlpPath,
                Arguments = $"--no-playlist -x --audio-format mp3 --embed-thumbnail --embed-metadata -o \"{outputDirectory}/%(title)s.%(ext)s\" \"{url}\"",
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };

            using var process = Process.Start(startInfo);
            if (process != null)
            {
                await process.WaitForExitAsync();

                var dir = new DirectoryInfo(outputDirectory);
                var latestFile = dir.GetFiles("*.mp3")
                                    .OrderByDescending(f => f.LastWriteTime)
                                    .FirstOrDefault();

                if (latestFile != null && !playlist.Contains(latestFile.FullName))
                {
                    playlist.Add(latestFile.FullName);
                    favoriteDisplayNames.Add(latestFile.Name);

                    txtStatus.Text = "YouTube track added to playlist ♡";

                    if (currentTrackIndex == -1)
                    {
                        PlayTrack(playlist.Count - 1);
                    }
                }
                else
                {
                    txtStatus.Text = "Download completed, but MP3 was not found.";
                }
            }
        }
        catch (Exception ex)
        {
            txtStatus.Text = "YouTube download failed: " + ex.Message;
        }
    }

    private async void AddLink_Click(object sender, RoutedEventArgs e)
    {
        string inputUrl = txtLink.Text.Trim();

        if (string.IsNullOrWhiteSpace(inputUrl))
        {
            txtStatus.Text = "Paste a YouTube link first ♡";
            return;
        }

        if (inputUrl.Contains("youtube.com") || inputUrl.Contains("youtu.be"))
        {
            txtLink.Clear();
            await ProcessYoutubeUrlAsync(inputUrl);
        }
        else
        {
            if (Uri.TryCreate(inputUrl, UriKind.Absolute, out Uri? uri) && (uri.Scheme == "https" || uri.Scheme == "http"))
            {
                links.Add(uri.AbsoluteUri);
                txtLink.Clear();
                txtStatus.Text = "Reference link added ♡";
            }
            else
            {
                txtStatus.Text = "Please enter a valid link ♡";
            }
        }
    }

    private void OpenSelectedLink()
    {
        if (lstLinks.SelectedItem is not string selectedLink)
        {
            txtStatus.Text = "Select a reference link first.";
            return;
        }
        try
        {
            Process.Start(new ProcessStartInfo(selectedLink) { UseShellExecute = true });
            txtStatus.Text = "Opened link in browser.";
        }
        catch (Exception ex)
        {
            txtStatus.Text = "Could not open browser: " + ex.Message;
        }
    }

    private void OpenLink_Click(object sender, RoutedEventArgs e) => OpenSelectedLink();

    private void SaveText(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            txtStatus.Text = "Notes are empty.";
            MessageBox.Show("Notes are empty. Write something first.", "Notice", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        var dialog = new SaveFileDialog { Filter = "Text files|*.txt", FileName = "hello-kitty-notes.txt" };
        if (dialog.ShowDialog() != true) return;

        try
        {
            File.WriteAllText(dialog.FileName, text);
            txtStatus.Text = "Saved: " + Path.GetFileName(dialog.FileName);
        }
        catch (Exception ex)
        {
            txtStatus.Text = "Could not save file: " + ex.Message;
        }
    }

    private void Open_Click(object sender, RoutedEventArgs e)
    {
        var dialog = new OpenFileDialog { Filter = "Text files|*.txt" };
        if (dialog.ShowDialog() != true) return;

        try
        {
            txtNotes.Text = File.ReadAllText(dialog.FileName);
            txtStatus.Text = "Notes loaded successfully ♡";
        }
        catch (Exception ex)
        {
            txtStatus.Text = "Could not open file: " + ex.Message;
        }
    }

    private void Save_Click(object sender, RoutedEventArgs e) => SaveText(txtNotes.Text);

    private void Image_Click(object sender, RoutedEventArgs e)
    {
        var dialog = new OpenFileDialog { Filter = "Images|*.png;*.jpg;*.jpeg" };
        if (dialog.ShowDialog() != true) return;

        try
        {
            var bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.CacheOption = BitmapCacheOption.OnLoad;
            bitmap.UriSource = new Uri(dialog.FileName);
            bitmap.EndInit();

            imgArtwork.Source = bitmap;
            imgButton.Source = bitmap;
            defaultKittyImage = bitmap;
            txtStatus.Text = "Custom artwork set ♡";
        }
        catch (Exception ex)
        {
            txtStatus.Text = "Could not load image: " + ex.Message;
        }
    }
}