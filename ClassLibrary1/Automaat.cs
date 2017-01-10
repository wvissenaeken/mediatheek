using ProjectFilmLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjectFilmLibrary
{
    public class Automaat
    {
        public string _Titel, _Beschrijving;
        public int _Barcode, _Stock;

        public List<Film> Filmlijst = new List<Film>()
        {
            new Film { _Titel = "", _Barcode="",_Beschrijving="",_Stock=0}
        };

        public List<Film> oproepenFilms()
        {
            return Filmlijst;
        }

        //WISSELGELD BEREKENAAR
        //Berekent het wisselgeld en retourneert resultaat als een string
        public string WisselGeldBerekenen(decimal wisselgeld)
        {
            //Maak een nieuwe array geld met de betrokken waarden
            var geld = new[]
            {
                new { waarde = 100.00m },
                new { waarde = 50.00m },
                new { waarde = 20.00m },
                new { waarde = 10.00m },
                new { waarde = 5.00m },
                new { waarde = 2.00m },
                new { waarde = 1.00m },
                new { waarde = 0.50m },
                new { waarde = 0.20m },
                new { waarde = 0.10m },
                new { waarde = 0.05m }
            };

            //Initialiseer het resultaat met lege string 
            string resultaat = "";

            //Bereken het wisselgeld op basis van elke betrokken waarde in het array geld
            foreach (var type in geld)
            {
                int teller = (int)(wisselgeld / type.waarde);
                wisselgeld -= teller * type.waarde;
                //Toon enkel de waarden die van toepassing zijn
                if (teller > 0)
                {
                    //Definieer resultaat als string
                    resultaat += String.Format("{0} x € {1}\n", teller, type.waarde);
                }
            }
            //Retourneer resultaat (als string)
            return resultaat;
        }
    }
}

