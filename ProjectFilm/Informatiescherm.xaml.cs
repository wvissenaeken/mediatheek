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
        //TMDbClient client = new TMDbClient("78be0aecfd40021797c60547fb12a5e6");

        public Informatiescherm()
        {
            InitializeComponent();
        }

        private void btnZoek_Click(object sender, RoutedEventArgs e)
        {
            InformatieGegevensscherm verwijzingInformatieGegevens = new InformatieGegevensscherm();
            verwijzingInformatieGegevens.ShowDialog();
        }

       

        private void btnZoek_Copy_Click(object sender, RoutedEventArgs e)
        {
            //InformatieGegevensscherm verwijzingInformatieGegevens = new InformatieGegevensscherm();
            //verwijzingInformatieGegevens.ShowDialog();


            //SearchContainer<SearchMovie> results = client.SearchMovieAsync(txtTitel.Text).Result;

            //Console.WriteLine($"Got {results.Results.Count:N0} of {results.TotalResults:N0} results");
            //foreach (SearchMovie result in results.Results)
            //    Console.WriteLine(result.Title);

            TMDbClient client = new TMDbClient("78be0aecfd40021797c60547fb12a5e6");
    
            SearchContainer<SearchMovie> results = client.SearchMovieAsync(txtTitel.Text).Result;

            foreach (SearchMovie result in results.Results)
                lbOverzichtGezochteFilms.Items.Add(result.Title);
        }

        private void btnTerug_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

       
    }
}
