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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace ProjectFilm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Automaat HuurAutomaat = new Automaat();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnKoop_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Komt binnenkort!", "", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnHuur_Click(object sender, RoutedEventArgs e)
        {
            Huurscherm huurverwijzing = new Huurscherm();
            huurverwijzing.ShowDialog();
        }

        private void btnMeerInfo_Click(object sender, RoutedEventArgs e)
        {
            Informatiescherm informatieverwijzing = new Informatiescherm();
            informatieverwijzing.ShowDialog();
        }

        private void btnCashtest_Click(object sender, RoutedEventArgs e)
        {
            Cashscherm cash = new Cashscherm();
            cash.ShowDialog();
        }

        private void btnEidtest_Click(object sender, RoutedEventArgs e)
        {
            LeesKaartData leeskaartdata = new LeesKaartData();
            leeskaartdata.ShowDialog();
        }
    }
}
