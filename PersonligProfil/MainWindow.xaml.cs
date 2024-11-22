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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            string relativePath = "Assets/AdamPersonlig.jpg";
            string fullPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath);

            var imageSource = new BitmapImage(new Uri(fullPath, UriKind.Absolute));

            AdamPersonlig.Source = imageSource;
        }
        private void ButtonTest_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Fun fact: En rulletrappe kan aldrig gå i stykker. Den kan kun blive lavet om til en almindelig trappe.");
        }
        private void Instagram_Click(object sender, RoutedEventArgs e)
        {
            // Åbner Instagram i webbrowseren
            Process.Start(new ProcessStartInfo("https://www.instagram.com/150.vintage/") { UseShellExecute = true });
        }
        private void Facebook_Click(object sender, RoutedEventArgs e)
        {
            // Åbner Facebook i webbrowseren
            Process.Start(new ProcessStartInfo("https://www.facebook.com/profile.php?id=100006324431887") { UseShellExecute = true });
        }
        private void GitHub_Click(object sender, RoutedEventArgs e)
        {
            // Åbner GitHub i webbrowseren
            Process.Start(new ProcessStartInfo("https://www.github.com/Adsi0001") { UseShellExecute = true });
        }
        private void YouTube_Click(object sender, RoutedEventArgs e)
        {
            // Åbner YouTube i webbrowseren
            Process.Start(new ProcessStartInfo("https://www.youtube.com") { UseShellExecute = true });
        }
        
    }
}