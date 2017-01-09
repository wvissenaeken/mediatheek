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
        public Informatiescherm()
        {
            InitializeComponent();
            Film = new Film();
        }
        Film Film;
        private Automaat filmService = new Automaat(); 


        //KNOPPEN
        private void btnZoek_Click(object sender, RoutedEventArgs e)
        {
            InformatieGegevensscherm verwijzingInformatieGegevens = new InformatieGegevensscherm();
            verwijzingInformatieGegevens.ShowDialog();
        }

        private void btnZoek_Copy_Click(object sender, RoutedEventArgs e)
        {
            
            TMDbClient client = new TMDbClient("78be0aecfd40021797c60547fb12a5e6");
    
            SearchContainer<SearchMovie> results = client.SearchMovieAsync(txtTitel.Text).Result;

            foreach (SearchMovie result in results.Results)
                lbOverzichtGezochteFilms.Items.Add(result.Title);
        }

        private void btnTerug_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnMeerInfo_Click(object sender, RoutedEventArgs e)
        {
            InformatieGegevensscherm verwijzingInformatieGegevens = new InformatieGegevensscherm();
            verwijzingInformatieGegevens.ShowDialog();
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
                btnMeerInfo.IsEnabled = false;
            }
         }
    }
}
