using System.Windows;
using ProjectFilmLibrary;
using System.Collections.Generic;
using System;

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
                Voornaam = uck.tbVoornaam.Text,
                Achternaam = uck.tbNaam.Text,
                Adres = uck.tbAdres.Text,
                Postcode_Gemeente = uck.tbPostcodeGemeente.Text,
                Geboortedatum = DateTime.Parse(uck.tbGeboortedatum.Text),
                Geboorteplaats = uck.tbGeboorteplaats.Text,
                Geslacht = uck.tbGeslacht.Text,
                Kaartnummer = uck.tbKaartnummer.Text,
                Lidmaatschap = vandaag,
                Telefoon = uck.tbTelefoon.Text,
                Email = uck.tbEmail.Text
            };
            klant.Add(klantgegevens);

            Winkelmandscherm winkelmandje = new Winkelmandscherm();
            winkelmandje.ShowDialog();
        }
    }
}
