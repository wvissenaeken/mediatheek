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
        Database _FilmService;
        Automaat HuurAutomaat; 


        public Informatiescherm()
        {
            InitializeComponent();
            HuurAutomaat = new Automaat();
            _FilmService = new Database();
            
            
        }

        ////-----------------------------//    
        ////DEFINEER API KEY VAN TMdbClient
        ////-----------------------------//
        //TMDbClient client = new TMDbClient("78be0aecfd40021797c60547fb12a5e6");
        //SearchContainer<SearchMovie> results = new SearchContainer<SearchMovie>();

        //-----------------------------//
        //KEUZE UIT OVERZICHT MAKEN
        //-----------------------------//
        private void lbOverzichtGezochteFilms_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //Is er een film geselecteerd?
            if (lbOverzichtGezochteFilms.SelectedItem != null)
            {
                HuurAutomaat._gezochteCode = HuurAutomaat.Filmlijst[lbOverzichtGezochteFilms.SelectedIndex]._Id;
                //Datum uit string halen.
                //string geselecteerdeFilm = lbOverzichtGezochteFilms.SelectedItem.ToString();
                //HuurAutomaat._Id = geselecteerdeFilm.Substring(0, geselecteerdeFilm.Length - 6);
                //Automaat geselecteerdeFilm = lbOverzichtGezochteFilms.GetValue. as Automaat;
                //geselecteerdeFilm._Id
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
        private void btnZoek_Click(object sender, RoutedEventArgs e)
        {
            InformatieGegevensscherm verwijzingInformatieGegevens = new InformatieGegevensscherm();
            verwijzingInformatieGegevens.ShowDialog();
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
                //DateTime datum = (DateTime)HuurAutomaat.Filmlijst[i]._Release;
                //int jaar = datum.Year;
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
            //InformatieGegevensscherm verwijzingInformatieGegevens = new InformatieGegevensscherm();
            //verwijzingInformatieGegevens.ShowDialog(); 
        }

        //KNOP TERUGKEREN NAAR VORIG SCHERM (SLUIT)
        private void btnTerug_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
