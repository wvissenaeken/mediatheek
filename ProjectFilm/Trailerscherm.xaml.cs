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
using System.Windows.Threading;

namespace ProjectFilm
{
    /// <summary>
    /// Interaction logic for Trailerscherm.xaml
    /// </summary>
    public partial class Trailerscherm : Window
    {
        Automaat TrailerService;

        public Trailerscherm()
        {
            InitializeComponent();
            TrailerService = new Automaat();
        }
     

        private void Trailer_Loaded(object sender, RoutedEventArgs e)
        {
            //String naar Uri omzetten
            System.Uri uri = new System.Uri(Automaat._Trailerkey);
            trTrailer.Source = uri; //FOUT HIER, URI IS DE KEY, bij uitvoeren is NULL, check via BREAK
        }

        

        private void btnTerug_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

       
    }
}