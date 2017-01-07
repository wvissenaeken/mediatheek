using System.Windows;
using ProjectFilmLibrary;

namespace ProjectFilm
{
    /// <summary>
    /// Interaction logic for Cashscherm.xaml
    /// </summary>
    public partial class Cashscherm : Window
    {
        Automaat Huurautomaat = new Automaat();

        public Cashscherm()
        {
            InitializeComponent();
            //List<Munt> Munten = Automaat.oproepenMunt();
            //List<string> OverzichtWisselgeld = Automaat.oproepenWisselgeld();
        }

        //Methode huidige inworp tonen, controle, knop annuleren activeren.
        private void huidigeInworp()
        {
            //lblHuidigeInworpResultaat.Content = "€ " + string.Format("{0:0.00}", Automaat._HuidigeInworp);
        }

        //Knoppen voor de keuze van de muntstukken + toewijzing naar de huidigeInworp.
        //Melding veranderd naar "Koop" wanneer er genoeg muntstukken ingeworpen zijn.
        private void btnTweeEuro_Click(object sender, RoutedEventArgs e)
        {
            //Automaat._HuidigeInworp = Automaat._HuidigeInworp + 2;
            huidigeInworp();
        }

        private void btnEenEuro_Click(object sender, RoutedEventArgs e)
        {
            //Automaat._HuidigeInworp += 1;
            huidigeInworp();
        }

        private void btn50Cent_Click(object sender, RoutedEventArgs e)
        {
            //Automaat._HuidigeInworp += 0.5;
            huidigeInworp();
        }

        private void btn20Cent_Click(object sender, RoutedEventArgs e)
        {
            //Automaat._HuidigeInworp += 0.2;
            huidigeInworp();
        }

        private void btn10Cent_Click(object sender, RoutedEventArgs e)
        {
            //Automaat._HuidigeInworp += 0.1;
            huidigeInworp();
        }

        private void btn5Cent_Click(object sender, RoutedEventArgs e)
        {
            //Automaat._HuidigeInworp += 0.05;
            huidigeInworp();
        }

        private void btnTerug_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
