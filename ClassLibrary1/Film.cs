using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFilmLibrary
{
    public class Film
    {
        public int Id { get; set; }
        public string Barcode { get; set; }
        public string Titel { get; set; }
        public string Beschrijving { get; set; }
        public DateTime Release { get; set; }
        public string Lengte { get; set; }
        public double Score { get; set; }
        public int Stock { get; set; }
            
        public string GebruiksvriendelijkeNaam
        {
            get
            {
                return ToString();
            }
        }

        public override string ToString()
        { 
            return $"{Titel} ({Release}) - Beschikbaar: {Stock}";
        }
    }
}
