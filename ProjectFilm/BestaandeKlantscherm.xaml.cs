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
    public partial class BestaandeKlantscherm : Window
    {
        UCKlant uckb;
        Database klantservice;
        List<Klant> klant;
        
        public BestaandeKlantscherm()
        {
            InitializeComponent();
            //Instantieer data uit User Control Klant
            uckb = new UCKlant();
            klantservice = new Database();
            klant = new List<Klant>();
            GenereerUCK();
        }

        string voornaam, achternaam, adres, postcode_gemeente, kaartnummer, geboorteplaats, geslacht, telefoon, email;
        DateTime geboortedatum;

        private void GenereerUCK()
        {
            //Voeg User Control Klant toe aan de daarvoor voorziene container
            ContentContainer.Children.Add(uckb);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BusyIndicator.IsBusy = true;
            BusyIndicator.BusyContent = "Uw kaart wordt uitgelezen...";
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (o, a) =>
            {
                for (int index = 0; index < 5; index++)
                {
                    Dispatcher.Invoke(new Action(() =>
                    {
                        BusyIndicator.BusyContent = "Status : " + index;
                    }), null);
                    Thread.Sleep(new TimeSpan(0, 0, 1));
                }
            };
            worker.RunWorkerCompleted += (o, a) =>
            {
                BusyIndicator.IsBusy = false;
            };
            worker.RunWorkerAsync();
        }

        private void btnAnnuleer_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnBetalen_Click(object sender, RoutedEventArgs e)
        {
            voornaam = uckb.tbVoornaam.Text;
            achternaam = uckb.tbNaam.Text;
            adres = uckb.tbAdres.Text;
            postcode_gemeente = uckb.tbPostcodeGemeente.Text;
            geboortedatum = DateTime.Parse(uckb.tbGeboortedatum.Text);
            geboorteplaats = uckb.tbGeboorteplaats.Text;
            geslacht = uckb.tbGeslacht.Text;
            kaartnummer = uckb.tbKaartnummer.Text;
                //Lidmaatschap = vandaag, NIET VAN TOEPASSING BIJ REEDS BESTAANDE KLANT!
            telefoon = uckb.tbTelefoon.Text;
            email = uckb.tbEmail.Text;

            klantservice.VerifieerKlant.Voornaam = voornaam;
            klantservice.VerifieerKlant.Achternaam = achternaam;
            klantservice.VerifieerKlant.Adres = adres;
            klantservice.VerifieerKlant.Postcode_Gemeente = postcode_gemeente;
            klantservice.VerifieerKlant.Geboortedatum = geboortedatum;
            klantservice.VerifieerKlant.Geboorteplaats = geboorteplaats;
            klantservice.VerifieerKlant.Geslacht = geslacht;
            klantservice.VerifieerKlant.Kaartnummer = kaartnummer;
            klantservice.VerifieerKlant.Telefoon = telefoon;
            klantservice.VerifieerKlant.Email = email.ToString();

            //Hier moet DB CONN starten
            //klantservice.DB_UpdateKlant();

            Winkelmandscherm winkelmandje = new Winkelmandscherm();
            winkelmandje.ShowDialog();
        }
    }
}
