using System.Windows;
using ProjectFilmLibrary;
using System;
using System.Windows.Controls;
using System.Drawing;
using System.Collections.Generic;

namespace ProjectFilm
{
    /// <summary>
    /// Interaction logic for Cashscherm.xaml
    /// </summary>
    public partial class Cashscherm : Window
    {
       
        public Cashscherm()
        {
            InitializeComponent();
            automaat = new Automaat();
            //foreach (Control c in Controls) { if (c is Button) { ((Button)c).Foreground = null; } }
        }

        Automaat automaat;

        //Declareer nodige variabelen
        public decimal TotaalInworp;
        public decimal Wisselgeld;
        public int Teller100, Teller50;

        public IEnumerable<Control> Controls { get; private set; }

        //Methode voor click events mbt Geld
        public void GeldPlusClick(decimal Inworp)
        {
            TotaalInworp += Inworp;
            lblHuidigeInworp.Content = String.Format("€ {0}", TotaalInworp);
            //Zie methode lager
            //VerifieerTotaalInworp();
        }

        public void GeldMinClick(decimal Inworp)
        {
            TotaalInworp -= Inworp;
            lblHuidigeInworp.Content = String.Format("€ {0}", TotaalInworp);
            //Zie methode lager
            //VerifieerTotaalInworp();
        }

        //Enkel click event voor alle knoppen mbt Geld
        private void btnGeldPlus_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            switch (btn.Name.ToString())
            {
                case "btn100_plus":
                    GeldPlusClick(100.00M);
                    lbl100_teller.Content = (Teller100 += 1).ToString();
                    break;
                case "btn50_plus":
                    GeldPlusClick(50.00M);
                    lbl50_teller.Content = (Teller50 += 1).ToString();
                    break;
                case "20":
                    GeldPlusClick(20.00M);
                    break;
                case "10":
                    GeldPlusClick(10.00M);
                    break;
                case "5":
                    GeldPlusClick(5.00M);
                    break;
                case "2":
                    GeldPlusClick(2.00M);
                    break;
                case "1":
                    GeldPlusClick(1.00M);
                    break;
                case "0,50":
                    GeldPlusClick(0.50M);
                    break;
                case "0,20":
                    GeldPlusClick(0.20M);
                    break;
                case "0,10":
                    GeldPlusClick(0.10M);
                    break;
                case "0,05":
                    GeldPlusClick(0.05M);
                    break;
            }
        }

        private void btnGeldMin_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            //Teller kan en mag niet kleiner zijn dan nul!
            if (Teller100 > 0 || Teller50 > 0)
            {
                switch (btn.Name.ToString())
                {
                    case "btn100_min":
                        GeldPlusClick(-100.00M);
                        lbl100_teller.Content = (Teller100 -= 1).ToString();
                        break;
                    case "btn50_min":
                        GeldPlusClick(-50.00M);
                        lbl50_teller.Content = (Teller50 -= 1).ToString();
                        break;
                }
            }
        }

        private void btnTerug_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
