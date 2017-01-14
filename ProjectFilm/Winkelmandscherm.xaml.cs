using System.Windows;

namespace ProjectFilm
{
    /// <summary>
    /// Interaction logic for Winkelmandscherm.xaml
    /// </summary>
    public partial class Winkelmandscherm : Window
    {
        public Winkelmandscherm()
        {
            InitializeComponent();
        }

        private void Annuleren_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnBetalen_Click(object sender, RoutedEventArgs e)
        {
            int totaal = lbBestelling.Items.Count;
            decimal totaalprijs = 0;
            for (int i=0; i <= totaal; i++)
            {
                totaalprijs += 4.00M;
            }

            Betalingenscherm betaal = new Betalingenscherm(/*totaalprijs*/);
            betaal.ShowDialog();
        }
    }
}
