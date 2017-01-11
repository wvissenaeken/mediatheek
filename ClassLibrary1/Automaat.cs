using System;
using System.Collections.Generic;
using TMDbLib.Client;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Search;

namespace ProjectFilmLibrary
{
    public class Automaat
    {
        public List<Film> Filmlijst = new List<Film>();
        public string _gezochteFilm;

        //-----------------------------//    
        //ONLINE DATABASE RAADPLEGEN
        //-----------------------------//
        ////////definieer api-key van tmdbClient
        //////TMDbClient client = new TMDbClient("78be0aecfd40021797c60547fb12a5e6");
        //////SearchContainer<SearchMovie> results = new SearchContainer<SearchMovie>();

        //Zoek online
        //ZOEK naar alle films op basis keywoord
        public void zoekOnline()
        {
            //definieer api-key van tmdbClient
            TMDbClient client = new TMDbClient("78be0aecfd40021797c60547fb12a5e6");
            SearchContainer<SearchMovie> results = new SearchContainer<SearchMovie>();
            SearchMovie result = new SearchMovie();
            results = client.SearchMovieAsync(_gezochteFilm).Result;
            //UPDATE overzichtslijst
            for (int i = 0; i < results.Results.Count; i++)
            {
                Filmlijst[i]._Titel = result.Title;
                Filmlijst[i]._Id = result.Id;
                Filmlijst[i]._Beschrijving = result.Overview;
                Filmlijst[i]._Release = (DateTime)result.ReleaseDate;
                Filmlijst[i]._Score = result.VoteAverage;
            }
        }

        //Reset Filmlijst
        public void reset()
        {
            Filmlijst.Clear();
        }

        //public string _Titel, _Beschrijving;
        //public int _Barcode, _Stock, _Id;



            //public List<Film> oproepenFilms()
            //{
            //    return Filmlijst;
            //}

            //-----------------------------//
            //WISSELGELD BEREKENAAR
            //-----------------------------//
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

