using System.Windows;

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
