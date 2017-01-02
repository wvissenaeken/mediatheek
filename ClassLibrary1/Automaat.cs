using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    class Automaat
    {
        public double _HuidigeInworp;
        public List<Munt> Muntstukken = new List<Munt>()
        {
            new Munt { _MuntNaam = "twee euro", _MuntWaarde = 2.00},
            new Munt { _MuntNaam = "een euro", _MuntWaarde = 1.00},
            new Munt { _MuntNaam = "vijftig eurocent", _MuntWaarde = 0.50},
            new Munt { _MuntNaam = "twintig eurocent", _MuntWaarde = 0.20 },
            new Munt { _MuntNaam = "tien eurocent", _MuntWaarde = 0.10},
            new Munt { _MuntNaam = "vijf eurocent", _MuntWaarde = 0.05}
        };

        public List<Munt> oproepenMunt()
        {
            return Muntstukken;
        }

        public List<string> OverzichtWisselgeld = new List<string>();

        public List<string> oproepenWisselgeld()
        {
            return OverzichtWisselgeld;
        }

        //Methode berekenen teruggave wisselgeld + weergeven in lijst
        public void teruggaveWisselgeld()
        {
            double wisselgeld = _HuidigeInworp;
            int tweeEuroMunt = 0;
            int eenEuroMunt = 0;
            int vijftigEurocentMunt = 0;
            int twintigEurocentMunt = 0;
            int tienEurocentMunt = 0;
            int vijfEurocentMunt = 0;

            while (wisselgeld >= 2)
            {
                tweeEuroMunt++;
                wisselgeld -= 2;
                OverzichtWisselgeld.Add(tweeEuroMunt + " x € " + Muntstukken[0]._MuntWaarde);
            }
            while (wisselgeld >= 1)
            {
                eenEuroMunt++;
                wisselgeld -= 1;
                OverzichtWisselgeld.Add(eenEuroMunt + " x € " + Muntstukken[1]._MuntWaarde);
            }
            while (wisselgeld >= 0.5)
            {
                vijftigEurocentMunt++;
                wisselgeld -= 0.5;
                OverzichtWisselgeld.Add(vijftigEurocentMunt + " x € " + Muntstukken[2]._MuntWaarde);
            }
            while (wisselgeld >= 0.2)
            {
                twintigEurocentMunt++;
                wisselgeld -= 0.2;
                OverzichtWisselgeld.Add(twintigEurocentMunt + " x € " + Muntstukken[3]._MuntWaarde);
            }
            while (wisselgeld >= 0.1)
            {
                tienEurocentMunt++;
                wisselgeld -= 0.1;
                OverzichtWisselgeld.Add(tienEurocentMunt + " x € " + Muntstukken[4]._MuntWaarde);
            }
            while (wisselgeld > 0.04)
            {
                vijfEurocentMunt++;
                wisselgeld -= 0.05;
                OverzichtWisselgeld.Add(vijfEurocentMunt + " x € " + Muntstukken[5]._MuntWaarde);
            }
        }
    }
}

