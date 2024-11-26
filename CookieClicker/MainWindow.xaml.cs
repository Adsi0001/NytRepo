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

namespace CookieClicker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int cookieCount = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        // CookieClickButton
        private void CookieClickButton_Click(object sender, RoutedEventArgs e)
        {
            // Tilføj cookies
            cookieCount++;

            // Opdater cookie count
            CookieCountTextBlock.Text = $"Cookies: {cookieCount}";
        }

        private void GrandmaUpgrade_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AutoClickerUpgrade_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ClickerUpgrade_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}