using System.Windows;
using ProjectFilmLibrary;
using System;
using System.Windows.Controls;

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

        //Declareer nodige variabelen
        public decimal TotaalInworp;
        public decimal Wisselgeld;

        //Methode voor click events mbt Geld
        public void GeldClick(decimal Inworp)
        {
            TotaalInworp += Inworp;
            lblHuidigeInworp.Content = String.Format("€ {0}", TotaalInworp);
            //Zie methode lager
            //VerifieerTotaalInworp();
        }

        //Enkel click event voor alle knoppen mbt Geld
        private void btnGeld_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            switch (btn.Content.ToString())
            {
                case "100":
                    GeldClick(100.00M);
                    break;
                case "50":
                    GeldClick(50.00M);
                    break;
                case "20":
                    GeldClick(20.00M);
                    break;
                case "10":
                    GeldClick(10.00M);
                    break;
                case "5":
                    GeldClick(5.00M);
                    break;
                case "2":
                    GeldClick(2.00M);
                    break;
                case "1":
                    GeldClick(1.00M);
                    break;
                case "0,50":
                    GeldClick(0.50M);
                    break;
                case "0,20":
                    GeldClick(0.20M);
                    break;
                case "0,10":
                    GeldClick(0.10M);
                    break;
                case "0,05":
                    GeldClick(0.05M);
                    break;
            }
        }

        private void btnTerug_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
