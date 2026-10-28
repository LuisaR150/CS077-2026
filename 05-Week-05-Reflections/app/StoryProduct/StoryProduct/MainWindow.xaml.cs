using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StoryProduct
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Build_Click(object sender, RoutedEventArgs e)
        {
            ResultText.Text = BuildChecklist(NameInput.Text);
        }
        private string BuildChecklist(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                return "Enter a name before continuing.";
            }

            string[] tasks = { "Check the item", "Record the result", "Return the tool" };

            string cleanName = userName.Trim();
            cleanName = char.ToUpper(cleanName[0]) + cleanName.Substring(1);

            string result = $"Checklist for {cleanName}:\n";


            for (int index = 0; index < tasks.Length; index++)
            {
                result += $"{index + 1}. {tasks[index]}\n";
            }

            return result;
        }

// MainWindow.xaml.cs
private readonly System.Media.SoundPlayer previewPlayer = new();

        private void PreviewSound_Click(object sender, RoutedEventArgs e)
        {
            if (SoundEnabled.IsChecked != true)
            {
                ResultText.Text = "Sound is off. The app still works.";
                return;
            }
            try
            {
                string file = System.IO.Path.Combine(
                    System.AppContext.BaseDirectory, "Assets", "Audio", "confirm.wav");
                previewPlayer.SoundLocation = file;
                previewPlayer.Load();
                previewPlayer.Play();
                ResultText.Text = "Sound requested. Continue using the visible controls.";
            }
            catch (System.Exception)
            {
                ResultText.Text = "Sound unavailable. You can continue without it.";
            }
        }
    }
}