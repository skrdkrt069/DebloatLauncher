using System.Diagnostics;
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
using System.Threading.Tasks;
using System.Media;

namespace DebloatLauncher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isRunning = false;

        private MediaPlayer musicPlayer = new MediaPlayer();

        public MainWindow()
        {
            InitializeComponent();

            PlayMusic();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.E)
            {
                LaunchButton_Click(this, new RoutedEventArgs());
            }
        }
        private void Window_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
        private void WindowDrag(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        private async void LaunchButton_Click(object sender, RoutedEventArgs e)
        {
            PressEText.Visibility = Visibility.Collapsed;

            if (isRunning)
                return;
            
            isRunning = true;

            PlayClickSound();

            LogBox.Clear();

            CyberProgress.Value = 15;
            AddLog("Já, já começa");
            await Task.Delay(1200);

            CyberProgress.Value = 40;
            AddLog("Vai pegar um suco");
            await Task.Delay(1200);

            CyberProgress.Value = 69;
            AddLog("Prepara a VPN");
            await Task.Delay(2000);

            CyberProgress.Value = 100;
            AddLog("Xablingas");
            FontWeight = FontWeights.Bold;
            PlayCompleteSound();
            await Task.Delay(1000);

            AddLog("");
            AddLog("────────────────");
            AddLog("");
            CyberProgress.Value = 169;
            AddLog("made by: skrr");
            await Task.Delay(1000);
            FontWeight = FontWeights.Bold;

            CyberProgress.Visibility = Visibility.Collapsed;

            LaunchInstaller();
          
            await Task.Delay(500);

            Application.Current.Shutdown();

            isRunning = false;
        }

        private void AddLog(string message)
        {
            LogBox.AppendText(message + Environment.NewLine);
            LogBox.ScrollToEnd();
        }

        private void PlayClickSound()
        {
            string soundPath = System.IO.Path.Combine(
        AppDomain.CurrentDomain.BaseDirectory,
        "click.wav");

            SoundPlayer player = new SoundPlayer(soundPath);
            player.Play();
        }

        private void PlayCompleteSound()
        {
            string soundPath = System.IO.Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "complete.wav");

            SoundPlayer player = new SoundPlayer(soundPath);
            player.Play();
        }

        private void PlayMusic()
        {
            string musicPath = System.IO.Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "music.mp3");

            musicPlayer.Open(new Uri(musicPath));

            musicPlayer.MediaOpened += (s, e) =>
            {
                musicPlayer.Volume = 0.69;
                musicPlayer.Play();
            };
        }

        private void LaunchInstaller()
        {
            try
            {
                string exePath = System.IO.Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "DWin_v0.69.exe");

                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = exePath,
                    WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory,
                    UseShellExecute = true
                };

                Process.Start(startInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}