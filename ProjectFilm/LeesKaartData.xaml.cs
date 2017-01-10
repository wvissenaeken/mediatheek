using ProjectFilmLibrary;
using System.Windows;
using System;

namespace ProjectFilm
{
    /// <summary>
    /// Interaction logic for LeesKaartData.xaml
    /// </summary>
    public partial class LeesKaartData : Window
    {
        public LeesKaartData()
        {
            InitializeComponent();
            leeskaart = new LeesKaart();
        }

        LeesKaart leeskaart;

        private void btn_LeesKaart_Click(object sender, RoutedEventArgs e)
        {
        
            imgphoto.Source = leeskaart.GetPhotoFile();
            lblNaam.Content = leeskaart.GetSurname();
            lblVoornaam.Content = leeskaart.GetFirstNames();
            lblStraat.Content = leeskaart.GetStreetAndNumber();
            lblZipCode.Content = leeskaart.GetZipCode();
            lblStad.Content = leeskaart.GetMunicipality();
            lblGeboorteDatum.Content = DateTime.Parse(leeskaart.GetDateOfBirth());
            lblRR.Content = leeskaart.GetNationalNumber();
            lblKaartNummer.Content = leeskaart.GetCardNumber();
        }
    }
}
