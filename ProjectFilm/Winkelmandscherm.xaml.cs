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
            Betalingenscherm betaal = new Betalingenscherm();
            betaal.ShowDialog();
        }
    }
}
