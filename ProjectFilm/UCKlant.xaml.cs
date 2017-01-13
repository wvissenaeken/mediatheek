using System.Windows;
using System.Windows.Controls;
using ProjectFilmLibrary;

namespace ProjectFilm
{
    /// <summary>
    /// Interaction logic for UCKlant.xaml
    /// </summary>
    public partial class UCKlant : UserControl
    {
        LeesKaart leeskaart;
        
        public UCKlant()
        {
            InitializeComponent();
            leeskaart = new LeesKaart();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            tbVoornaam.Text = leeskaart.GetFirstNames();
            tbNaam.Text = leeskaart.GetSurname();
            tbAdres.Text = leeskaart.GetStreetAndNumber();
            tbPostcodeGemeente.Text = $"{leeskaart.GetZipCode()} {leeskaart.GetMunicipality()}";
            tbGeboortedatum.Text = leeskaart.GetDateOfBirth();
            tbGeboorteplaats.Text = leeskaart.GetLocationOfBirth();
            tbGeslacht.Text = leeskaart.GetGender();
            tbKaartnummer.Text = leeskaart.GetCardNumber();
            //tbTelefoon.Text = Console.ReadLine();
            //tbEmail.Text = Console.ReadLine();
        }

        //Leeg Textbox bij aanklikken en herstel standaardwaarde bij verlaten 
        private void tb_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= tb_GotFocus;
        }
    }
}
