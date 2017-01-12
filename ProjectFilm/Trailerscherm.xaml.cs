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
        Automaat HuurAutomaat;

        public Trailerscherm()
        {
            InitializeComponent();
            HuurAutomaat = new Automaat();
        }



        private void btnTerug_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Trailer_Loaded(object sender, RoutedEventArgs e)
        {
            //String naar Uri omzetten
            trTrailer.Source = new Uri(HuurAutomaat._Trailerkey);
        }
    }
}