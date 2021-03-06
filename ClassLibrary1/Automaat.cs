﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using TMDbLib.Client;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Movies;
using TMDbLib.Objects.Search;

namespace ProjectFilmLibrary
{
    public class Automaat
    {
        Database _Filmservice = new Database();
        public List<Film> Filmlijst = new List<Film>();
        public string _gezochteFilm;
        public int _gezochteCode;
        public string _gezochteBarcode;

        public static string _Trailerkey;
        public static string _Titel;
        public static string _Beschrijving;
        public static int _Release;
        public static double _Score;

        //-----------------------------//    
        //DATABASE RAADPLEGEN
        //-----------------------------//
        //definieer api-key van tmdbClient
        TMDbClient client = new TMDbClient("78be0aecfd40021797c60547fb12a5e6");
        public SearchContainer<SearchMovie> results = new SearchContainer<SearchMovie>();
        SearchMovie result = new SearchMovie();
        public SearchContainer<Movie> gezochteMovie = new SearchContainer<Movie>();
        Movie movie = new Movie();

        //ZOEK EIGEN DATABASE

        //ZOEK ONLINE
        //ZOEK naar alle films op basis keywoord
        public void zoekOnlineTekst()
        { 
            results = client.SearchMovieAsync(_gezochteFilm).Result;
            //UPDATE overzichtslijst
           
                foreach (SearchMovie result in results.Results)
                {
                if (result != null)
                {
                    int jaar;
                    if (result.ReleaseDate != null)
                    {
                        DateTime datum = (DateTime)result.ReleaseDate;
                        jaar = datum.Year;
                    }
                    else
                    {
                        jaar = DateTime.MinValue.Year;
                    }
                    Filmlijst.Add(new Film { _Titel = result.Title, _Barcode = "", _Lengte = "", _Stock = 0, _Id = result.Id, _Beschrijving = result.Overview, _Release = jaar, _Score = result.VoteAverage });
                }
                else
                {
                    MessageBox.Show("Gelieve nieuwe zoekterm in te geven.", "Niets gevonden.", MessageBoxButton.OK);
                }
            }          
        }

        //ZOEK naar specifieke film
        public async void zoekOnlineID()
        {
           
            int jaartal;
            int jaar;
            movie = await client.GetMovieAsync(_gezochteCode, MovieMethods.Videos);
            
            
            if (movie.ReleaseDate != null)
            {
                DateTime datum = (DateTime)movie.ReleaseDate;
                jaartal = datum.Year;
            }
            else
            {
                jaartal = DateTime.MinValue.Year;
            }
            Filmlijst.Add(new Film { _Titel = movie.Title, _Barcode = "", _Lengte = "", _Stock = 0, _Id = movie.Id, _Beschrijving = movie.Overview, _Release = jaartal, _Score = movie.VoteAverage });
            //UPDATE database
            if (movie.ReleaseDate != null)
            {
                DateTime datumB = (DateTime)movie.ReleaseDate;
                jaar = datumB.Year;
            }
            else
            {
                jaar = DateTime.MinValue.Year;
            }
            _Filmservice.opgezochtefilm._Id = movie.Id;
            _Filmservice.opgezochtefilm._Titel = movie.Title;
            _Filmservice.opgezochtefilm._Beschrijving = movie.Overview;
            _Filmservice.opgezochtefilm._Release = jaar;
            _Filmservice.opgezochtefilm._Score = movie.VoteAverage;

            //Gegevens voor het InformatieGegevensscherm
           List<Film> filmgegevens = new List<Film>();
           filmgegevens.Add(new Film()
            {
                _Titel = movie.Title,
                _Beschrijving = movie.Overview,
                _Release = jaar,
                _Score = movie.VoteAverage
            });
            _Titel = $"{filmgegevens[0]._Titel}";
            _Beschrijving= $"{filmgegevens[0]._Beschrijving}";
            _Release= filmgegevens[0]._Release;
            _Score= filmgegevens[0]._Score;

            //Update
            _Filmservice.updateGegevensFilm();

            //Krijg trailerkey 
            List<string> filmkey = new List<string>();
            foreach (var video in movie.Videos.Results)
            {
                filmkey.Add(video.Key);
            }
            _Trailerkey = $"http://www.youtube.com/embed/{filmkey[0]}";
        }
            
        //Reset Filmlijst
        public void reset()
        {
            Filmlijst.Clear();
        }

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


