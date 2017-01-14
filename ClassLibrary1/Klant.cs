using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ProjectFilmLibrary
{
    public class Klant
    {
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string Adres { get; set; }
        public string Postcode_Gemeente { get; set; }
        public string Geslacht { get; set; }
        public DateTime Geboortedatum { get; set; }
        public int Lidmaatschap { get; set; }
        public string Geboorteplaats { get; set; }
        public string Kaartnummer { get; set; }
        public string Telefoon { get; set; }
        public string Email { get; set; }
        public ImageSource Foto { get; set; } //Nog na te gaan of het opportuun is afbeelding op te slaan?
    }
}
