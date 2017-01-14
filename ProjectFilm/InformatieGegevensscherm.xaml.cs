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

namespace ProjectFilm
{
    /// <summary>
    /// Interaction logic for InformatieGegevensscherm.xaml
    /// </summary>
    public partial class InformatieGegevensscherm : Window
    {
        Database FilmService;
        Automaat HuurAutomaat;

        

        public InformatieGegevensscherm()
        {
            InitializeComponent();
            HuurAutomaat = new Automaat();
            FilmService = new Database();
        }

       

        private void btnTrailer_Click(object sender, RoutedEventArgs e)
        {
            Trailerscherm verwijzingTrailer = new Trailerscherm();
            verwijzingTrailer.ShowDialog();
        }

        private void btnTerug_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            lblFilmTitel.Content = Automaat._Titel;
            txtbBeschrijving.Text = Automaat._Beschrijving;
            lblRelease.Content = Automaat._Release.ToString();
            lblScore.Content = Automaat._Score.ToString();
        }
    }
}
