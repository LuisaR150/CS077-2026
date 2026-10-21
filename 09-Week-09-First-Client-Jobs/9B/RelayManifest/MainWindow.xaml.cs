using System.IO;
using System.Windows;
using Microsoft.Win32;

namespace RelayManifest;

public partial class MainWindow : Window
{
    private List<ManifestItem> items = new();
    private bool highOnly = false;

    public MainWindow()
    {
        InitializeComponent();
    }

    private void ShowItems()
    {
        var visible = ManifestData.Select(items, highOnly);
        lstItems.ItemsSource = visible;
        txtStatus.Text = $"{visible.Count} of {items.Count} records | " +
            (highOnly ? "High priority" : "All records");
    }


    private async void Open_Click(object sender, RoutedEventArgs e)
    {
        var dialog = new OpenFileDialog
        {
            Filter = "Text files (*.txt)|*.txt"
        };
        if (dialog.ShowDialog() != true) return;
        try
        {
            if (new FileInfo(dialog.FileName).Length > 65536)
                throw new InvalidDataException("Use a file below 64 KB.");
            string[] lines = await File.ReadAllLinesAsync(dialog.FileName);
            ParseResult parsed = ManifestData.Parse(lines);
            txtWarnings.Text = parsed.Warnings.Count == 0
                ? "No skipped lines."
                : string.Join(Environment.NewLine, parsed.Warnings);
            if (parsed.Items.Count == 0)
            {
                txtStatus.Text = "No valid rows. Previous list kept.";
                return;
            }
            items = parsed.Items;
            ShowItems();
        }
        catch (Exception ex) when (ex is IOException ||
            ex is UnauthorizedAccessException || ex is InvalidDataException)
        {
            txtStatus.Text = "File not loaded. " + ex.Message;
        }
    }

    private void All_Click(object sender, RoutedEventArgs e)
    {
        highOnly = false;
        ShowItems();
    }

    private void High_Click(object sender, RoutedEventArgs e)
    {
        highOnly = true;
        ShowItems();
    }

    private async void Save_Click(object sender, RoutedEventArgs e)
    {
        var visible = ManifestData.Select(items, highOnly);
        if (visible.Count == 0)
        {
            txtStatus.Text = "No visible records to save.";
            return;
        }
        var dialog = new SaveFileDialog
        {
            Filter = "Text files (*.txt)|*.txt",
            FileName = "manifest-summary.txt"
        };
        if (dialog.ShowDialog() != true) return;
        try
        {
            await File.WriteAllTextAsync(dialog.FileName,
                ManifestData.Summary(visible));
            txtStatus.Text = "Saved visible records. Original untouched.";
        }
        catch (Exception ex) when (ex is IOException ||
            ex is UnauthorizedAccessException)
        {
            txtStatus.Text = "Summary not saved. " + ex.Message;
        }
    }

    private void Exit_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void About_Click(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("Training manifest: name|quantity|priority. " +
            "Use fictional data; no private information.", "About");
    }
}