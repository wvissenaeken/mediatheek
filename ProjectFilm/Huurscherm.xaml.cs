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

        public Huurscherm()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshFilms();
        }

        private void RefreshFilms()
        {
            try
            {
                List<Film> films = filmService.GetFilm();
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

        private void button_Click(object sender, RoutedEventArgs e)
        {
            RefreshFilms();
        }
    }
}
