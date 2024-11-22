using System;
using System.Windows;

namespace SimpleVideoPlayer
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Event handler for Play Button click
        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            // Angiv stien til din video
            string videoPath = @"Assets\VideoTest.mp4";  // Sørg for at din video er korrekt placeret i Assets-mappen.

            // Indstil videoens kilde og start afspilning
            videoPlayer.Source = new Uri(videoPath, UriKind.Relative);
            videoPlayer.Play();
        }

        // Event handler for when the video ends
        private void VideoPlayer_MediaEnded(object sender, RoutedEventArgs e)
        {
            // Når videoen er færdig, stopper vi afspilningen og rydder kilde
            videoPlayer.Stop();

            // Fjern videoens kilde
            videoPlayer.Source = null;

            // Eventuelt vise en besked til brugeren
            MessageBox.Show("Videoen er færdig!");
        }
    }
}
