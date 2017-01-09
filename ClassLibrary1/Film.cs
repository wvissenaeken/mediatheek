using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFilmLibrary
{
    public class Film
    {
        public decimal Id { get; set; }
        public string Titel { get; set; }
        public int Jaar { get; set; }
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
            return $"{Titel} ({Jaar}) - Beschikbaar: {Stock}";
        }
    }
}
