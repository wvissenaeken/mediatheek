using System.Windows;
using System.ComponentModel;
using System.Threading;
using System;
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

        string voornaam, achternaam, adres, postcode_gemeente, kaartnummer, geboorteplaats, geslacht, telefoon, email;
        DateTime geboortedatum;
        int lidmaatschap;

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
            DateTime vandaagdedag = DateTime.Now;
            int vandaag = vandaagdedag.Year;

            voornaam = uck.tbVoornaam.Text;
            achternaam = uck.tbNaam.Text;
            adres = uck.tbAdres.Text;
            postcode_gemeente = uck.tbPostcodeGemeente.Text;
            geboortedatum = DateTime.Parse(uck.tbGeboortedatum.Text);
            geboorteplaats = uck.tbGeboorteplaats.Text;
            geslacht = uck.tbGeslacht.Text;
            kaartnummer = uck.tbKaartnummer.Text;
            lidmaatschap = vandaag;// NIET VAN TOEPASSING BIJ REEDS BESTAANDE KLANT!
            telefoon = uck.tbTelefoon.Text;
            email = uck.tbEmail.Text;

            klantservice.VerifieerKlant.Voornaam = voornaam;
            klantservice.VerifieerKlant.Achternaam= achternaam;
            klantservice.VerifieerKlant.Adres= adres;
            klantservice.VerifieerKlant.Postcode_Gemeente=postcode_gemeente;
            klantservice.VerifieerKlant.Geboortedatum=geboortedatum;
            klantservice.VerifieerKlant.Geboorteplaats=geboorteplaats;
            klantservice.VerifieerKlant.Geslacht=geslacht;
            klantservice.VerifieerKlant.Lidmaatschap = lidmaatschap;
            klantservice.VerifieerKlant.Kaartnummer=kaartnummer;
            klantservice.VerifieerKlant.Telefoon = telefoon;
            klantservice.VerifieerKlant.Email = email.ToString();

            klantservice.DB_UpdateKlant();

            klantservice.DB_VerifieerKlant();

            Winkelmandscherm winkelmandje = new Winkelmandscherm();
            winkelmandje.ShowDialog();
        }
    }
}
