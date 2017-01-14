using System.Windows;
using ProjectFilmLibrary;
using System.Collections.Generic;

namespace ProjectFilm
{
    /// <summary>
    /// Interaction logic for Winkelmandscherm.xaml
    /// </summary>
    public partial class Winkelmandscherm : Window {

        private Database filmService = new Database();
        public List<Film> films;

        public decimal totaalprijs;

        public Winkelmandscherm()
        {
            InitializeComponent();
            films = filmService.GetFilm();
        }

        private void LaadSelectie()
        {
            //lbBestelling.Items.Add(films[lbOverzichtFilm.SelectedIndex]._Titel + " (" + films[lbOverzichtFilm.SelectedIndex]._Release + ")");
        }

        private void Annuleren_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnBetalen_Click(object sender, RoutedEventArgs e)
        {
            //int totaal = lbBestelling.Items.Count;
            //decimal totaalprijs = 0;
            //for (int i=0; i <= totaal; i++)
            //{
            //    totaalprijs += 4.00M;
            //}

            Betalingenscherm betaal = new Betalingenscherm();
            betaal.ShowDialog();
        }
    }
}
