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

            //Hier moet DB CONN starten denk ik?
           

            Winkelmandscherm winkelmandje = new Winkelmandscherm();
            winkelmandje.ShowDialog();
        }
    }
}
