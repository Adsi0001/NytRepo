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
using System.Windows.Threading;

namespace CookieClicker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int cookieCount = 0;
        // Timere der styrer synligheden af knapperne
        private DispatcherTimer timer1;
        private DispatcherTimer timer2;
        private DispatcherTimer timer3;
        private DispatcherTimer visibilityTimer1;
        private DispatcherTimer visibilityTimer2;
        private DispatcherTimer visibilityTimer3;

        public MainWindow()
        {
            InitializeComponent();

            // Kode til at køre Timer1 i 300 sek til RandomEvent1
            timer1 = new DispatcherTimer();
            timer1.Interval = TimeSpan.FromSeconds(300);
            timer1.Tick += Timer1_Tick;
            timer1.Start();

            // Kode til at køre Timer2 i 100 sek til RandomEvent2
            timer2 = new DispatcherTimer();
            timer2.Interval = TimeSpan.FromSeconds(100);
            timer2.Tick += Timer2_Tick;
            timer2.Start();

            // Kode til at køre Timer3 i 60 sek til RandomEvent3
            timer3 = new DispatcherTimer();
            timer3.Interval = TimeSpan.FromSeconds(60);
            timer3.Tick += Timer3_Tick;
            timer3.Start();

            // Timer til at skjule knappen efter 8 sek for RandomEvent1
            visibilityTimer1 = new DispatcherTimer();
            visibilityTimer1.Interval = TimeSpan.FromSeconds(8);
            visibilityTimer1.Tick += VisibilityTimer1_Tick;

            // Timer til at skjule knappen efter 6 sek for RandomEvent2
            visibilityTimer2 = new DispatcherTimer();
            visibilityTimer2.Interval = TimeSpan.FromSeconds(6);
            visibilityTimer2.Tick += VisibilityTimer2_Tick;

            // Timer til at skjule knappen efter 4 sek for RandomEvent3
            visibilityTimer3 = new DispatcherTimer();
            visibilityTimer3.Interval = TimeSpan.FromSeconds(4);
            visibilityTimer3.Tick += VisibilityTimer3_Tick;
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
        // EventTimer1
        private void Timer1_Tick(object sender, EventArgs e)
        {
            // Gør RandomEvent1 synlig
            RandomEvent1.Visibility = Visibility.Visible;

            // Start visibilityTimer1 for at skjule RandomEvent1
            visibilityTimer1.Start();
        }
        // EventTimer2
        private void Timer2_Tick(object sender, EventArgs e)
        {
            // Gør RandomEvent2 synlig
            RandomEvent2.Visibility = Visibility.Visible;
            // Start visibilityTimer2 for at skjule RandomEvent2
            visibilityTimer2.Start();
        }
        // EventTimer3
        private void Timer3_Tick(object sender, EventArgs e)
        {
            // Gør RandomEvent3 synlig
            RandomEvent3.Visibility = Visibility.Visible;
            // Start visibilityTimer3 for at skjule RandomEvent3
            visibilityTimer3.Start();
        }
        // EventVisibility1
        private void VisibilityTimer1_Tick(object sender, EventArgs e)
        {
            // Skjul RandomEvent1
            RandomEvent1.Visibility = Visibility.Hidden;
            // Stop visibilityTimer1
            visibilityTimer1.Stop();
        }
        // EventVisibility2
        private void VisibilityTimer2_Tick(object sender, EventArgs e)
        {
            // Skjul RandomEvent2
            RandomEvent2.Visibility = Visibility.Hidden;
            // Stop visibilityTimer2
            visibilityTimer2.Stop();
        }
        // EventVisibility3
        private void VisibilityTimer3_Tick(object sender, EventArgs e)
        {
            // Skjul RandomEvent3
            RandomEvent3.Visibility = Visibility.Hidden;
            // Stop visibilityTimer3
            visibilityTimer3.Stop();
        }
        // RandomEvent1
        private void RandomEvent1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Congratz, you just baked 2500 cookies!");
            // Tilføj 2500 cookies
            cookieCount += 2500;
            // Opdater cookie count
            CookieCountTextBlock.Text = $"Cookies: {cookieCount}";
        }
        // RandomEvent2
        private void RandomEvent2_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Congratz, you just baked 1200 cookies!");
            // Tilføj 1200 cookies
            cookieCount += 1200;
            // Opdater cookie count
            CookieCountTextBlock.Text = $"Cookies: {cookieCount}";
        }
        // RandomEvent3
        private void RandomEvent3_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Oh no, this cookies is rotten! You just lost 50 cookies!");
            // Fjern 50 cookies
            cookieCount -= 50;
            // Opdater cookie count
            CookieCountTextBlock.Text = $"Cookies: {cookieCount}";
        }
    }
}