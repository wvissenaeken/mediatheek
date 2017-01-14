using System.Windows;
using ProjectFilmLibrary;
using System.Collections.Generic;

namespace ProjectFilm
{
    /// <summary>
    /// Interaction logic for Klantscherm.xaml
    /// </summary>
    public partial class NieuweKlantscherm : Window
    {
        UCKlant uck;
        Database klantservice;
        List<Klant> klant;

        public NieuweKlantscherm()
        {
            InitializeComponent();
            //Instantieer data uit User Control Klant
            uck = new UCKlant();
            klantservice = new Database();
            klant = new List<Klant>();
            GenereerUCK();
        }

        private void GenereerUCK()
        {
            //Voeg User Control Klant toe aan de daarvoor voorziene container
            ContentContainer.Children.Add(uck);
        }

        private void btnAnnuleer_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnBetalen_Click(object sender, RoutedEventArgs e)
        {
            DateTime vandaag = DateTime.Today;
            var klantgegevens = new Klant
            {
                Voornaam = uckb.lblVoornaam.ToString(),
                Achternaam = uckb.lblNaam.ToString(),
                Adres = uckb.lblAdres.ToString(),
                Postcode_Gemeente = uckb.lblPostcodeGemeente.ToString(),
                Geboortedatum = DateTime.Parse(uckb.lblGeboortedatum.ToString()),
                Geboorteplaats = uckb.lblGeboorteplaats.ToString(),
                Geslacht = uckb.lblGeslacht.ToString(),
                Kaartnummer = uckb.lblKaartnummer.ToString(),
                Lidmaatschap = vandaag,
                Telefoon = uckb.lblTelefoon.ToString(),
                Email = uckb.lblEmail.ToString()
            };
            klant.Add(klantgegevens);

            Winkelmandscherm winkelmandje = new Winkelmandscherm();
            winkelmandje.ShowDialog();
        }
    }
}
