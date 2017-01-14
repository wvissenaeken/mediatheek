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
        Cash checkchildren;
        Automaat automaat;
        Film film;

        public Cashscherm()
        {
            checkchildren = new Cash();
            InitializeComponent();
            //Deactiveer knoppen met _min totdat knoppen met _plus worden geactiveerd
            DeactiveerButtons();
            btnBetalen.IsEnabled = false;
            automaat = new Automaat();
            film = new Film();
        }

        public Cashscherm(decimal totaalprijs)
        {
            this.totaalprijs = totaalprijs;
        }

        //Declareer nodige variabelen
        public decimal TotaalInworp;
        public decimal Wisselgeld;
        public int Teller100, Teller50, Teller20, Teller10, Teller5, Teller2, Teller1, Teller50C, Teller20C, Teller10C, Teller5C;
        private decimal totaalprijs;

        private void btnBetalen_Click(object sender, RoutedEventArgs e)
        {
            BetalingenOKscherm betaald = new BetalingenOKscherm();
            betaald.ShowDialog();
        }

        private void btnAnnuleren_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        //Methode voor click events mbt Geld
        public void GeldPlusClick(decimal Inworp)
        {
            TotaalInworp += Inworp;
            lblHuidigeInworp.Content = String.Format("€ {0}", TotaalInworp);
        }

        public void GeldMinClick(decimal Inworp)
        {
            TotaalInworp -= Inworp;
            lblHuidigeInworp.Content = String.Format("€ {0}", TotaalInworp);
        }

        public void DeactiveerButtons()
        {
            foreach (object o in checkchildren.GetChildren(DockPanelInworp, 5))
            {
                if (o.GetType() == typeof(Button))
                {
                    Button b = (Button)o;
                    if (b.Name.Contains("_min"))
                    {
                        b.IsEnabled = false;
                    }
                }
            }
        }

        //Enkel click event voor alle knoppen mbt Geld+
        private void btnGeldPlus_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            switch (btn.Name.ToString())
            {
                case "btn100_plus":
                    GeldPlusClick(100.00M);
                    lbl100_teller.Content = (Teller100 += 1).ToString();
                    btn100_min.IsEnabled = true;
                    break;
                case "btn50_plus":
                    GeldPlusClick(50.00M);
                    lbl50_teller.Content = (Teller50 += 1).ToString();
                    btn50_min.IsEnabled = true;
                    break;
                case "btn20_plus":
                    GeldPlusClick(20.00M);
                    lbl20_teller.Content = (Teller20 += 1).ToString();
                    btn20_min.IsEnabled = true;
                    break;
                case "btn10_plus":
                    GeldPlusClick(10.00M);
                    lbl10_teller.Content = (Teller10 += 1).ToString();
                    btn10_min.IsEnabled = true;
                    break;
                case "btn5_plus":
                    GeldPlusClick(5.00M);
                    lbl5_teller.Content = (Teller5 += 1).ToString();
                    btn5_min.IsEnabled = true;
                    break;
                case "btn2_plus":
                    GeldPlusClick(2.00M);
                    lbl2_teller.Content = (Teller2 += 1).ToString();
                    btn2_min.IsEnabled = true;
                    break;
                case "btn1_plus":
                    GeldPlusClick(1.00M);
                    lbl1_teller.Content = (Teller1 += 1).ToString();
                    btn1_min.IsEnabled = true;
                    break;
                case "btn50C_plus":
                    GeldPlusClick(0.50M);
                    lbl50C_teller.Content = (Teller50C += 1).ToString();
                    btn50C_min.IsEnabled = true;
                    break;
                case "btn20C_plus":
                    GeldPlusClick(0.20M);
                    lbl20C_teller.Content = (Teller20C += 1).ToString();
                    btn20C_min.IsEnabled = true;
                    break;
                case "btn10C_plus":
                    GeldPlusClick(0.10M);
                    lbl10C_teller.Content = (Teller10C += 1).ToString();
                    btn10C_min.IsEnabled = true;
                    break;
            }
            Wisselgeld = TotaalInworp - totaalprijs;
            if (TotaalInworp > totaalprijs)
            {
                DeactiveerButtons();
                btnBetalen.IsEnabled = true;
                tbWisselgeld.Text = String.Format("Wisselgeld: € {0}\n", Wisselgeld) + automaat.WisselGeldBerekenen(Wisselgeld);
            }
        }

        //Enkel click event voor alle knoppen mbt Geld-
        private void btnGeldMin_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            //Teller kan en mag niet kleiner zijn dan nul!
            if (Teller100 > 0 || Teller50 > 0 || Teller20 > 0 || Teller10 > 0 || Teller5 > 0 ||
                Teller2 > 0 || Teller1 > 0 || Teller50C > 0 || Teller20C > 0 || Teller10C > 0)
            {
                switch (btn.Name.ToString())
                {
                    case "btn100_min":
                        GeldMinClick(100.00M);
                        lbl100_teller.Content = (Teller100 -= 1).ToString();
                        break;
                    case "btn50_min":
                        GeldMinClick(50.00M);
                        lbl50_teller.Content = (Teller50 -= 1).ToString();
                        break;
                    case "btn20_min":
                        GeldMinClick(20.00M);
                        lbl20_teller.Content = (Teller20 -= 1).ToString();
                        break;
                    case "btn10_min":
                        GeldMinClick(10.00M);
                        lbl10_teller.Content = (Teller10 -= 1).ToString();
                        break;
                    case "btn5_min":
                        GeldMinClick(5.00M);
                        lbl5_teller.Content = (Teller5 -= 1).ToString();
                        break;
                    case "btn2_min":
                        GeldMinClick(2.00M);
                        lbl2_teller.Content = (Teller2 -= 1).ToString();
                        break;
                    case "btn1_min":
                        GeldMinClick(1.00M);
                        lbl1_teller.Content = (Teller1 -= 1).ToString();
                        break;
                    case "btn50C_min":
                        GeldMinClick(0.50M);
                        lbl50C_teller.Content = (Teller50C -= 1).ToString();
                        break;
                    case "btn20C_min":
                        GeldMinClick(0.20M);
                        lbl20C_teller.Content = (Teller20C -= 1).ToString();
                        break;
                    case "btn10C_min":
                        GeldMinClick(0.10M);
                        lbl10C_teller.Content = (Teller10C -= 1).ToString();
                        break;
                }
            }

            if (Teller100 == 0) { btn100_min.IsEnabled = false; }
            if (Teller50 == 0) { btn50_min.IsEnabled = false; }
            if (Teller20 == 0) { btn20_min.IsEnabled = false; }
            if (Teller10 == 0) { btn10_min.IsEnabled = false; }
            if (Teller5 == 0) { btn5_min.IsEnabled = false; }
            if (Teller2 == 0) { btn2_min.IsEnabled = false; }
            if (Teller1 == 0) { btn1_min.IsEnabled = false; }
            if (Teller50C == 0) { btn50C_min.IsEnabled = false; }
            if (Teller20C == 0) { btn20C_min.IsEnabled = false; }
            if (Teller10C == 0) { btn10C_min.IsEnabled = false; }
        }

        public void VerifieerTotaalInworp()
        {
            if (TotaalInworp >= totaalprijs)
            {
                btnBetalen.IsEnabled = true;
            }
        }

        private void btnTerug_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
