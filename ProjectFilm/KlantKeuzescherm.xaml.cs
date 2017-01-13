using ProjectFilmLibrary;
using System.Windows;


namespace ProjectFilm
{
    /// <summary>
    /// Interaction logic for KlantKeuzescherm.xaml
    /// </summary>
    public partial class KlantKeuzescherm : Window
    {
        LeesKaart leeskaart;

        public KlantKeuzescherm()
        {
            InitializeComponent();
            leeskaart = new LeesKaart();
        }
        public bool btnnieuweklant = false;
        public bool btnbestaandeklant = false;

        private void btnNieuweKlant_Click(object sender, RoutedEventArgs e)
        {
            KlantKeuze.IsEnabled = false;
            VoerKaartIn.Visibility = Visibility.Visible;
            btnnieuweklant = true;

        }

        private void btnBestaandeKlant_Click(object sender, RoutedEventArgs e)
        {
            KlantKeuze.IsEnabled = false;
            VoerKaartIn.Visibility = Visibility.Visible;
            btnbestaandeklant = true;

        }

        private void btnLeesKaart_Click(object sender, RoutedEventArgs e)
        {
            if (btnnieuweklant)
            {
                NieuweKlantscherm nieuweklant = new NieuweKlantscherm();
                nieuweklant.ShowDialog();
            }
            BestaandeKlantscherm bestaandeklant = new BestaandeKlantscherm();
            bestaandeklant.ShowDialog();
        }
    }
}
