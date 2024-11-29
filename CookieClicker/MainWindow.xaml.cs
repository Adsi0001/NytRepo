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
        private int cookieCount = 0; // Antal cookies
        private int totalCookies = 0; // Total antal cookies
        private int cookiesPerClick = 1; // Cookies per klik
        private int clickerUpgradePrice = 50; // Pris for ClickerUpgrade
        private int clickerUpgradeLevel = 0; // ClickerUpgrade level
        private int autoClickerUpgradePrice = 500;  // Pris for AutoClicker upgrade
        private int autoClickerUpgradeLevel = 0; // AutoClicker upgrade level
        private DispatcherTimer autoClickerTimer;  // Timer for AutoClicker upgrade
        private int megaClickerUpgradePrice = 1000; //Pris for MegaClicker upgrade
        private int megaClickerUpgradeLevel = 0; // MegaClicker upgrade level
        private int level = 1; // Game level

        // Timere der styrer synligheden af randomEvents
        private DispatcherTimer timer1;
        private DispatcherTimer timer2;
        private DispatcherTimer timer3;
        private DispatcherTimer visibilityTimer1;
        private DispatcherTimer visibilityTimer2;
        private DispatcherTimer visibilityTimer3;

        // Timere
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

            // AutoClicker timer
            autoClickerTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1) // Kører hver sekund
            };
            autoClickerTimer.Tick += AutoClickerTick;  // Ved hvert "tick" kaldes AutoClickerTick
        }

        // CookieClickButton
        private void CookieClickButton_Click(object sender, RoutedEventArgs e)
        {
            // Tilføj cookies til både cookieCount og totalCookies plus tjek level
            cookieCount += cookiesPerClick;
            totalCookies += cookiesPerClick;
            CheckLevelUp();

            // Opdater cookie count og total cookies
            CookieCountTextBlock.Text = $"Cookies: {cookieCount}";
            TotalCookiesTextBlock.Text = $"Total Cookies: {totalCookies}";
        }
        private void ClickerUpgrade_Click(object sender, RoutedEventArgs e)
        {
            if (clickerUpgradePrice > cookieCount) // Tjek om brugeren har nok cookies til at købe upgrade
            {
                MessageBox.Show("You don't have enough cookies to upgrade.");
                AddToEventLog("You don't have enough cookies to buy ClickerUpgrade"); // Tilføj til eventlog
            }
            else
            {
                // Køb upgrade
                cookieCount -= clickerUpgradePrice; // Træk prisen fra cookieCount
                clickerUpgradePrice *= 2; // Fordobling af prisen på clickerUpgrade
                cookiesPerClick *= 2; // Cookies per click bliver fordoblet ved køb af upgrade
                clickerUpgradeLevel ++; // Level opdateres
                AddToEventLog("You bought ClickerUpgrade!"); // Tilføj til eventlog

                // Opdaterer UI
                PriceTextBlock.Text = $"Price: {clickerUpgradePrice} Cookies";
                CookieCountTextBlock.Text = $"Cookies: {cookieCount}";
                CookiesPerClickTextBlock.Text = $"Cookies per Click: {cookiesPerClick}";
                ClickerLevelTextBlock.Text = $"Clicker Upgrade Level: {clickerUpgradeLevel}";
                CheckLevelUp();
            }

        }
        private void AutoClickerUpgrade_Click(object sender, RoutedEventArgs e)
        {
            if (cookieCount < autoClickerUpgradePrice) // Tjek om brugeren har nok cookies til at købe upgrade
            {
                MessageBox.Show("Not enough cookies for AutoClicker Upgrade!");
                AddToEventLog("You don't have enough cookies to buy AutoClicker"); // Tilføj til eventlog
            }
            else
            {
                cookieCount -= autoClickerUpgradePrice; // Træk prisen fra upgradecount
                autoClickerUpgradePrice *= 2;  // Fordobling af prisen ved køb
                autoClickerUpgradeLevel++;  // Opdater level af upgrade
                AddToEventLog("You bought AutoClicker!"); // Tilføj til eventlog

                // Start autoClickerTimer hvis ikke allerede startet
                if (!autoClickerTimer.IsEnabled)
                {
                    autoClickerTimer.Start();
                }

                // Opdater UI
                AutoClickerPriceTextBlock.Text = $"Price: {autoClickerUpgradePrice} Cookies";
                CookieCountTextBlock.Text = $"Cookies: {cookieCount}";
                AutoClickerLevelTextBlock.Text = $"AutoClicker Upgrade Level: {autoClickerUpgradeLevel}";
                CheckLevelUp();

                // Opdater antallet af klik per sekund baseret på level
                autoClickerTimer.Interval = TimeSpan.FromSeconds(1.0 / autoClickerUpgradeLevel);
            }

        }

        // AutoClicker timer
        private void AutoClickerTick(object sender, EventArgs e)
        {
            // Tilføj cookies udfra autoClickerUpgradeLevel
            cookieCount += autoClickerUpgradeLevel;
            CookieCountTextBlock.Text = $"Cookies: {cookieCount}";
        }
        private void MegaClickUpgrade_Click(object sender, RoutedEventArgs e)
        {
            if (megaClickerUpgradePrice > cookieCount) // Tjek om brugeren har nok cookies til at købe upgrade
            {
                MessageBox.Show("You don't have enough cookies to upgrade.");
                AddToEventLog("You don't have enough cookies to buy MegaClick"); // Tilføj til eventlog
            }
            else
            {
                cookieCount -= megaClickerUpgradePrice; // Træk prisen fra
                cookiesPerClick += 20; // Tilføj 20 cookies per klik
                megaClickerUpgradePrice *= 2; // Dobbelt pris
                megaClickerUpgradeLevel ++; // Opdater level
                AddToEventLog("You bought Mega Click!"); // Tilføj til eventlog
            }

            // Opdater UI
            CookieCountTextBlock.Text = $"Cookies: {cookieCount}";
            MegaClickerPriceTextBlock.Text = $"Price: {megaClickerUpgradePrice} Cookies";
            CookiesPerClickTextBlock.Text = $"Cookies per Click: {cookiesPerClick}";
            MegaClickerLevelTextBlock.Text = $"MegaClicker Upgrade Level: {megaClickerUpgradeLevel}";
            CheckLevelUp();
        }

        // EventTimer1
        private void Timer1_Tick(object sender, EventArgs e)
        {
            // Gør RandomEvent1 synlig
            RandomEvent1.Visibility = Visibility.Visible;

            // Start visibilityTimer1 for at skjule RandomEvent1 igen
            visibilityTimer1.Start();
        }
        // EventTimer2
        private void Timer2_Tick(object sender, EventArgs e)
        {
            // Gør RandomEvent2 synlig
            RandomEvent2.Visibility = Visibility.Visible;
            // Start visibilityTimer2 for at skjule RandomEvent2 igen
            visibilityTimer2.Start();
        }
        // EventTimer3
        private void Timer3_Tick(object sender, EventArgs e)
        {
            // Gør RandomEvent3 synlig
            RandomEvent3.Visibility = Visibility.Visible;
            // Start visibilityTimer3 for at skjule RandomEvent3 igen
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
            TotalCookiesTextBlock.Text = $"Total Cookies: {totalCookies}";
            AddToEventLog("You got 2500 cookies from the golden cookie!"); // Tilføj til eventlog
        }
        // RandomEvent2
        private void RandomEvent2_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Congratz, you just baked 1200 cookies!");
            // Tilføj 1200 cookies
            cookieCount += 1200;
            // Opdater cookie count
            CookieCountTextBlock.Text = $"Cookies: {cookieCount}";
            TotalCookiesTextBlock.Text = $"Total Cookies: {totalCookies}";
            AddToEventLog("You got 1200 cookies from the smiling cookie!"); // Tilføj til eventlog
        }
        // RandomEvent3
        private void RandomEvent3_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Oh no, this cookie is rotten! You just lost 50 cookies!");
            // Fjern 50 cookies
            cookieCount -= 50;
            // Opdater cookie count
            CookieCountTextBlock.Text = $"Cookies: {cookieCount}";
            TotalCookiesTextBlock.Text = $"Total Cookies: {totalCookies}";
            AddToEventLog("You lost 50 cookies from the rotten cookie!"); // Tilføj til eventlog
        }
        // Knap til at se total cookies
        private void TotalCookiesBTN_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"The total amount of cookies clicked is {totalCookies}.");
            TotalCookiesTextBlock.Text = $"Total Cookies: {totalCookies}";
        }
        // Eventlog funktion
        private void AddToEventLog(string message)
        {
            EventLog.Items.Add($"{DateTime.Now:T}: {message}");
            EventLog.ScrollIntoView(EventLog.Items[EventLog.Items.Count - 1]); // Auto-scroll til nyeste log
        }
        // Tjek om der er cookies nok til levelup
        private void CheckLevelUp()
        {
            // Levelup for hver 1000 cookies
            int newLevel = (totalCookies / 1000) + 1;
            if (newLevel > level)
            {
                level = newLevel;
                AddToEventLog($"Congratulations! You've reached Level {level}!"); // Tilføj til eventlog
                LevelText.Text = $"Level: {level}"; // Opdater level tekst
            }
        }
    }
}