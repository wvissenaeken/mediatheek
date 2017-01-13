using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Threading;
using System;
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
            LeesEIDData();
        }

        private void LeesEIDData()
        {
            tbVoornaam.Text = leeskaart.GetFirstNames();
            tbNaam.Text = leeskaart.GetSurname();
            tbAdres.Text = leeskaart.GetStreetAndNumber();
            tbPostcodeGemeente.Text = $"{leeskaart.GetZipCode()} {leeskaart.GetMunicipality()}";
            tbGeboortedatum.Text = leeskaart.GetDateOfBirth();
            tbGeboorteplaats.Text = leeskaart.GetLocationOfBirth();
            tbGeslacht.Text = leeskaart.GetGender();
            tbRijksregister.Text = leeskaart.GetNationalNumber();
            tbKaartnummer.Text = leeskaart.GetCardNumber();
            //tbEmail.Text = Console.ReadLine();
         }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            BusyIndicator.IsBusy = true;
            BusyIndicator.BusyContent = "Uw kaart wordt uitgelezen...";
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (o, a) =>
            {
                for (int index = 0; index < 5; index++)
                {
                    Dispatcher.Invoke(new Action(() =>
                    {
                        BusyIndicator.BusyContent = "Status : " + index;
                    }), null);
                    Thread.Sleep(new TimeSpan(0, 0, 1));
                }
            };
            worker.RunWorkerCompleted += (o, a) =>
            {
                BusyIndicator.IsBusy = false;
            };
            worker.RunWorkerAsync();
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
