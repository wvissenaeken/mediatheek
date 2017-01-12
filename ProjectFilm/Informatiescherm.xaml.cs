using ProjectFilmLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TMDbLib.Client;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Movies;
using TMDbLib.Objects.Search;

namespace ProjectFilm
{
    /// <summary>
    /// Interaction logic for Informatiescherm.xaml
    /// </summary>
    public partial class Informatiescherm : Window
    {
        Database FilmService;
        Automaat HuurAutomaat; 

        public Informatiescherm()
        {
            InitializeComponent();
            HuurAutomaat = new Automaat();
            FilmService = new Database();
        }

        //-----------------------------//
        //KEUZE UIT OVERZICHT MAKEN
        //-----------------------------//
        private void lbOverzichtGezochteFilms_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //Is er een film geselecteerd?
            if (lbOverzichtGezochteFilms.SelectedItem != null)
            {
                HuurAutomaat._gezochteCode = HuurAutomaat.Filmlijst[lbOverzichtGezochteFilms.SelectedIndex]._Id;
                btnMeerInfo.IsEnabled = true;
            }
            else
            {
                MessageBox.Show("Selecteer een film");
            }
        }

        //-----------------------------//
        //KNOPPEN
        //-----------------------------//
        //KNOP ZOEK IN DATABASE ProjectFilm
        private void btnZoekEigenDatabase_Click(object sender, RoutedEventArgs e)
        {
            //Als het effectief inscannen werkt, dan is deze knop overbodig. 
            //Deze knop is een simulatie voor het inscannen, waarbij er direct een scherm met gegevens wordt geopend.
            FilmService.opgezochtefilm._Barcode = txtScanCode.Text;
            FilmService.zoekFilmInDatabase();
            
            if (FilmService.aanwezigInDatabase == 1)
            {
                HuurAutomaat._gezochteCode = FilmService.gevondenCode;
                HuurAutomaat.zoekOnlineID();
                InformatieGegevensscherm verwijzingInformatieGegevens = new InformatieGegevensscherm();
                verwijzingInformatieGegevens.ShowDialog();
            }
        }

        //KNOP ZOEK ONLINE VOOR GEGEVENS
        private void btnZoekOnline_Click(object sender, RoutedEventArgs e)
        {
            HuurAutomaat.reset();
            lbOverzichtGezochteFilms.Items.Clear();
            //ZOEK op basis van tekstbox input
            HuurAutomaat._gezochteFilm = txtTitel.Text;
            HuurAutomaat.zoekOnlineTekst();
            //UPDATE overzichtslijst
            for (int i = 0; i < HuurAutomaat.Filmlijst.Count; i++)
            {
                lbOverzichtGezochteFilms.Items.Add(HuurAutomaat.Filmlijst[i]._Titel + " ("+HuurAutomaat.Filmlijst[i]._Release+")");
            }
        }

        //KNOP NIEUW SCHERM MET GEGEVENS + DATABASE UPDATEN
        private void btnMeerInfo_Click(object sender, RoutedEventArgs e)
        {
            //RESET
            HuurAutomaat.reset();
            //UPDATE gegevens in database voor specifieke film
            HuurAutomaat.zoekOnlineID();
            //TOON gegevens in een apart scherm.
            InformatieGegevensscherm verwijzingInformatieGegevens = new InformatieGegevensscherm();
            verwijzingInformatieGegevens.ShowDialog();
        }

        //KNOP TERUGKEREN NAAR VORIG SCHERM (SLUIT)
        private void btnTerug_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        //Leeg Textbox bij aanklikken
        public void tb_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= tb_GotFocus;
        }
    }
}
