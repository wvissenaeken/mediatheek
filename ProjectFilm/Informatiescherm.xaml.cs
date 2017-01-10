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
        private Database filmService = new Database();

        public Informatiescherm()
        {
            InitializeComponent();
            Film = new Film();
        }
        Film Film;


        //KNOPPEN
        private void btnZoek_Click(object sender, RoutedEventArgs e)
        {
            InformatieGegevensscherm verwijzingInformatieGegevens = new InformatieGegevensscherm();
            verwijzingInformatieGegevens.ShowDialog();
        }

        private void btnZoekOnline_Click(object sender, RoutedEventArgs e)
        {
            lbOverzichtGezochteFilms.Items.Clear();
            //Definieer API key van TMDbClient
            TMDbClient client = new TMDbClient("78be0aecfd40021797c60547fb12a5e6");

            SearchContainer<SearchMovie> results = client.SearchMovieAsync(txtTitel.Text).Result;

            foreach (SearchMovie result in results.Results)
            {
                //DateTime datum = (DateTime)result.ReleaseDate;
                //string jaar = datum.ToString("yyyy");
                lbOverzichtGezochteFilms.Items.Add(result.Title);
                
            }
        }

        private void btnTerug_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        //Knop die meer info over een film toont, en gegevens wegschrijft naar Database zodat personeel bij ingeven
        //nieuwe stock minder werk zal hebben.
        private void btnMeerInfo_Click(object sender, RoutedEventArgs e)
        {
            //RESET
            filmService.opgezochtefilm.Titel = "";
            filmService.opgezochtefilm.Beschrijving = "";
            filmService.opgezochtefilm.Release = DateTime.Now;
            filmService.opgezochtefilm.Score = 0;

            //ZOEK op de selectie gemaakt in het "lbOverzichtGezochteFilms"
            TMDbClient client = new TMDbClient("78be0aecfd40021797c60547fb12a5e6");
            SearchContainer<SearchMovie> results = client.SearchMovieAsync(Film.Titel).Result;

            //UPDATE gegevens in database
            foreach (SearchMovie result in results.Results)
            {
                filmService.opgezochtefilm.Titel = result.Title;
                filmService.opgezochtefilm.Beschrijving = result.Overview;
                filmService.opgezochtefilm.Release = (DateTime)result.ReleaseDate;
                filmService.opgezochtefilm.Score = result.VoteAverage;
                
                //Update
                filmService.updateGegevensFilm();
            }
            //InformatieGegevensscherm verwijzingInformatieGegevens = new InformatieGegevensscherm();
            //verwijzingInformatieGegevens.ShowDialog(); 
        }

        //KEUZE UIT OVERZICHT MAKEN
        private void lbOverzichtGezochteFilms_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //Is er een film geselecteerd?
            if (lbOverzichtGezochteFilms.SelectedItem != null)
            {
                Film.Titel = lbOverzichtGezochteFilms.SelectedItem.ToString();
                btnMeerInfo.IsEnabled = true;
                
            }
            else
            {
                MessageBox.Show("Selecteer een film");
            }
         }

        
    }
}
