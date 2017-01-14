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

        string voornaam, achternaam, adres, postcode_gemeente, kaartnummer, geboorteplaats, geslacht, telefoon, email;
        DateTime geboortedatum;

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

            voornaam = uck.tbVoornaam.Text;
            achternaam = uck.tbNaam.Text;
            adres = uck.tbAdres.Text;
            postcode_gemeente = uck.tbPostcodeGemeente.Text;
            geboortedatum = DateTime.Parse(uck.tbGeboortedatum.Text);
            geboorteplaats = uck.tbGeboorteplaats.Text;
            geslacht = uck.tbGeslacht.Text;
            kaartnummer = uck.tbKaartnummer.Text;
            //Lidmaatschap = vandaag, NIET VAN TOEPASSING BIJ REEDS BESTAANDE KLANT!
            telefoon = uck.tbTelefoon.Text;
            email = uck.tbEmail.Text;

            var klantgegevens = new Klant
            {
                Voornaam = voornaam,
                Achternaam = achternaam,
                Adres = adres,
                Postcode_Gemeente = postcode_gemeente,
                Geboortedatum = geboortedatum,
                Geboorteplaats = geboorteplaats,
                Geslacht = geslacht,
                Kaartnummer = kaartnummer,
                //Lidmaatschap = vandaag, NIET VAN TOEPASSING BIJ REEDS BESTAANDE KLANT!
                Telefoon = telefoon,
                Email = email
            };

            klant.Add(klantgegevens);

            klantservice.DB_VerifieerKlant();

            Winkelmandscherm winkelmandje = new Winkelmandscherm();
            winkelmandje.ShowDialog();
        }
    }
}
