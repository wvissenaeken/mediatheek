using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFilmLibrary
{
    public class Film
    {
        public int _Id { get; set; }
        public string _Barcode { get; set; }
        public string _Titel { get; set; }
        public string _Beschrijving { get; set; }
        public DateTime _Release { get; set; }
        public string _Lengte { get; set; }
        public double _Score { get; set; }
        public int _Stock { get; set; }
            
        public override string ToString()
        { 
            return $"{_Titel} ({_Release}) - Beschikbaar: {_Stock}";
        }
    }
}
