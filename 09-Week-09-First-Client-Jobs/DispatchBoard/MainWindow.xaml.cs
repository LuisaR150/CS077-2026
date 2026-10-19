using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Windows;
using Microsoft.Win32;

namespace DispatchBoard;

public partial class MainWindow : Window
{
    private static readonly HttpClient client = new()
    {
        Timeout = TimeSpan.FromSeconds(15)
    };
    private List<DispatchTask> tasks = new();
    private bool openOnly = false;

    public MainWindow()
    {
        InitializeComponent();
    }

    private void SetBusy(bool busy)
    {
        btnLoad.IsEnabled = !busy;
        btnOpen.IsEnabled = !busy;
        btnFilter.IsEnabled = !busy;
        btnExport.IsEnabled = !busy;
    }

    private void ShowTasks()
    {
        var visible = TaskData.Select(tasks, openOnly);
        lstTasks.ItemsSource = visible;
        txtStatus.Text = $"{visible.Count} of {tasks.Count} tasks | " +
            (openOnly ? "Open only" : "All tasks");
    }


    private async void Load_Click(object sender, RoutedEventArgs e)
    {
        SetBusy(true);
        txtStatus.Text = "Loading practice tasks...";
        try
        {
            const string url =
                "https://jsonplaceholder.typicode.com/users/1/todos";
            string json = await client.GetStringAsync(url);
            tasks = TaskData.Parse(json);
            ShowTasks();
        }
        catch (Exception ex) when (ex is HttpRequestException ||
            ex is TaskCanceledException || ex is JsonException ||
            ex is InvalidDataException)
        {
            txtStatus.Text = "Online load failed. Try Open saved JSON. " +
                ex.Message;
        }
        finally { SetBusy(false); }
    }

    private async void Open_Click(object sender, RoutedEventArgs e)
    {
        var dialog = new OpenFileDialog
        {
            Filter = "JSON files (*.json)|*.json"
        };
        if (dialog.ShowDialog() != true) return;
        SetBusy(true);
        try
        {
            if (new FileInfo(dialog.FileName).Length > 262144)
                throw new InvalidDataException("Use a file below 256 KB.");
            string json = await File.ReadAllTextAsync(dialog.FileName);
            tasks = TaskData.Parse(json);
            ShowTasks();
        }
        catch (Exception ex) when (ex is IOException ||
            ex is UnauthorizedAccessException || ex is JsonException ||
            ex is InvalidDataException)
        {
            txtStatus.Text = "File not loaded. " + ex.Message;
        }
        finally { SetBusy(false); }
    }


    private void Filter_Click(object sender, RoutedEventArgs e)
    {
        openOnly = !openOnly;
        ShowTasks();
    }

    private async void Export_Click(object sender, RoutedEventArgs e)
    {
        var visible = TaskData.Select(tasks, openOnly);
        if (visible.Count == 0)
        {
            txtStatus.Text = "No visible tasks to save.";
            return;
        }
        var dialog = new SaveFileDialog
        {
            Filter = "Text files (*.txt)|*.txt",
            FileName = "task-summary.txt"
        };
        if (dialog.ShowDialog() != true) return;
        SetBusy(true);
        try
        {
            await File.WriteAllTextAsync(dialog.FileName,
                TaskData.Summary(visible));
            txtStatus.Text = "Saved the visible task summary.";
        }
        catch (Exception ex) when (ex is IOException ||
            ex is UnauthorizedAccessException || ex is InvalidDataException)
        {
            txtStatus.Text = "Summary not saved. " + ex.Message;
        }
        finally { SetBusy(false); }
    }
}