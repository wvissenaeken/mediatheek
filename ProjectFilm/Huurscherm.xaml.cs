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
    /// Interaction logic for Huurscherm.xaml
    /// </summary>
    public partial class Huurscherm : Window
    {
        private Database filmService = new Database();
        public List<Film> films;

        public Huurscherm()
        {
            InitializeComponent();
            films = filmService.GetFilm();
        }
        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            RefreshFilms();
        }


        private void RefreshFilms()
        {
            try
            {

                lbOverzichtFilm.Items.Clear();
                foreach (Film f in films)
                {
                    lbOverzichtFilm.Items.Add(f);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Graag assistentie personeel vragen.", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnTerug_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnVolgende_Click(object sender, RoutedEventArgs e)
        {
            KlantKeuzescherm klantkeuze = new KlantKeuzescherm();
            klantkeuze.ShowDialog();
        }

        private void lbOverzichtFilm_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //Is er een film geselecteerd?
            if (lbOverzichtFilm.SelectedItem != null)
            {
                lbOverzichtGekozenFilm.Items.Add(films[lbOverzichtFilm.SelectedIndex]._Titel + " (" + films[lbOverzichtFilm.SelectedIndex]._Release + ")");

            }
            else
            {
                MessageBox.Show("Selecteer een film");
            }
        }

        private void btnZoekEigenDatabase_Click(object sender, RoutedEventArgs e)
        {
            filmService.opgezochtefilm._Barcode = txtScanCode.Text;
            filmService.zoekFilmInDatabase();

            if (filmService.aanwezigInDatabase == 1)
            {
                HuurAutomaat._gezochteCode = filmService.gevondenCode;
                HuurAutomaat.zoekOnlineID();
            }
        }
    }
}
