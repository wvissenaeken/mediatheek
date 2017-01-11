using ProjectFilmLibrary;
using System.Windows;
using System;
using System.Windows.Controls;

namespace ProjectFilm
{
    /// <summary>
    /// Interaction logic for LeesKaartscherm.xaml
    /// </summary>
    public partial class LeesKaartscherm : Window
    {
        public LeesKaartscherm()
        {
            InitializeComponent();
            leeskaart = new LeesKaart();
        }

        LeesKaart leeskaart;

        private void DefaultFontSize()
        {
            foreach (UIElement control in LeesKaartscherm.Children)
            {
                if (control.GetType() == typeof(Label))
                {
                    Label lbl = (Label)control;
                    lbl.FontSize = 20;
                }
            }
        }

        private void btn_LeesKaart_Click(object sender, RoutedEventArgs e)
        {
        
            imgphoto.Source = leeskaart.GetPhotoFile();
            lblNaam.Content = leeskaart.GetSurname();
            lblVoornaam.Content = leeskaart.GetFirstNames();
            lblStraat.Content = leeskaart.GetStreetAndNumber();
            lblZipCode.Content = leeskaart.GetZipCode();
            lblStad.Content = leeskaart.GetMunicipality();
            lblGeboorteDatum.Content = DateTime.Parse(leeskaart.GetDateOfBirth());
            lblGeboortePlaats.Content = leeskaart.GetLocationOfBirth();
            lblRR.Content = leeskaart.GetNationalNumber();
            lblKaartNummer.Content = leeskaart.GetCardNumber();
        }
    }
}
