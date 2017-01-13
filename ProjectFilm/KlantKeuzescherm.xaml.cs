using ProjectFilmLibrary;
using System;
using System.Windows;
using System.Threading;


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

        private void btnNieuweKlant_Click(object sender, RoutedEventArgs e)
        {
            KlantKeuze.IsEnabled = false;
            VoerKaartIn.Visibility = Visibility.Visible;

            NieuweKlantscherm nieuweklant = new NieuweKlantscherm();
            nieuweklant.ShowDialog();
        }

        private void btnBestaandeKlant_Click(object sender, RoutedEventArgs e)
        {
            KlantKeuze.IsEnabled = false;
            VoerKaartIn.Visibility = Visibility.Visible;

            BestaandeKlantscherm bestaandeklant = new BestaandeKlantscherm();
            bestaandeklant.ShowDialog();
        }

        private void LeesKaartData()
        {

        }
    }
}
