using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kreditrechner.Daten;

namespace Kreditrechner.Model
{
    abstract class Darlehen
    {
        public double KreditBetrag { get; set; }
        public double Zinssatz { get; set; }
        public int Beginn { get; set; }

        public abstract OutputData[] BerechneDarlehen(); // bleibt leer
    }
    class Annuitaet : Darlehen
    {
        public InputData Input;
        public Annuitaet(InputData input)
        {
            Input = input;
            Input.getInput();
            KreditBetrag = Input.KreditBetrag;
            Zinssatz = Input.Zinssatz;
            StartTilgungssatz = Input.Tilgungssatz;
        }
        public double StartTilgungssatz { get; set; }
        public int YearAnnu { get; set; }
        public int MonAnnu { get; set; }



        /// <summary>
        /// Hier erfolgt die Berechnung
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public override OutputData[] BerechneDarlehen()
        {

            OutputData[] data = new OutputData[Input.Laufzeit];

            // Berechnung Jahr 1  --------------------------------------------------------> muss monatlich erfolgen
            OutputData dataMonth1 = new OutputData();
            dataMonth1.Kreditbetrag = KreditBetrag;
            dataMonth1.Zinsen = KreditBetrag * Zinssatz / 100;
            dataMonth1.Tilgung = KreditBetrag * StartTilgungssatz / 100;
            dataMonth1.Annuitaet = dataMonth1.Tilgung + dataMonth1.Zinsen;
            dataMonth1.Restbetrag = dataMonth1.Kreditbetrag - dataMonth1.Tilgung;
            dataMonth1.Date = Input.Date;

            data[0] = dataMonth1;
            // Berechnung Monat 2-n 
            double lastRestBetrag = dataMonth1.Restbetrag;
            for (int i = 2; i <= Input.Laufzeit; i++)
            {
                OutputData dataMonthN = new OutputData();
                dataMonthN.Kreditbetrag = lastRestBetrag;
                dataMonthN.Zinsen = dataMonthN.Kreditbetrag * Zinssatz / 100;
                dataMonthN.Tilgung = dataMonth1.Annuitaet - dataMonthN.Zinsen;
                dataMonthN.Annuitaet = dataMonth1.Annuitaet;
                dataMonthN.Restbetrag = dataMonthN.Kreditbetrag - dataMonthN.Tilgung;
                dataMonthN.Date = Input.Date.AddMonths(i - 1);
                //dataMonthN.Date = Input.Date.AddYears(i - 1);

                lastRestBetrag = dataMonthN.Restbetrag;

                data[i - 1] = dataMonthN;
            }

            return data;
        }
    }
    //class Tilgung : Darlehen
    //{
    //    public int monTilgung { get; set; }
    //    public int jahrTilgung { get; set; }
    //    public double konstTilgungsatz { get; set; }

    //    public override OutputData[] BerechneDarlehen()
    //    {
    //        // Berechnung Jahr 1 muss monatlich erfolgen
    // Berechnung ab 2. Jahr erfolgt jährlich
    //    }
    //}
}
}
