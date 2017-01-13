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
    /// Interaction logic for Klantscherm.xaml
    /// </summary>
    public partial class BestaandeKlantscherm : Window
    {
        UCKlant uckb;

        public BestaandeKlantscherm()
        {
            InitializeComponent();
            //Instantieer data uit User Control Klant
            uckb = new UCKlant();
            GenereerUCK();
        }

        private void GenereerUCK()
        {
            //Voeg User Control Klant toe aan de daarvoor voorziene container
            ContentContainer.Children.Add(uckb);
        }

        private void btnAnnuleer_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnBetalen_Click(object sender, RoutedEventArgs e)
        {
            Betalingenscherm betaalwijze = new Betalingenscherm();
            betaalwijze.ShowDialog();
        }
    }
}
