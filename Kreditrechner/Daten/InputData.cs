using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kreditrechner.Daten
{
    public class InputData
    {
        public MainPage mainPage; // DEFINITION der Variablen Form1
        public InputData(MainPage mainPage1)
        {
            this.mainPage = mainPage1; //this ist immer ein Bezug auf die Klasse // DEKLARATION der Variablen Form1
        }
        public double KreditBetrag { get; set; }
        public double Zinssatz { get; set; }
        public double Tilgungssatz { get; set; }
        public int Laufzeit { get; set; }
        public DateTime Date { get; set; }

        /// <summary>
        /// Prüfung des Wertebereichs
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public bool CheckData()
        {
            if ((CheckValue(1000, 1000000, KreditBetrag, "Kreditbetrag")) &&
               (CheckValue(1, 10, Zinssatz, "Zinssatz")) &&
               (CheckValue(1, 10, Tilgungssatz, "Tilgungssatz")) &&
               (CheckValue(1, 20, Laufzeit, "Laufzeit")))
            {
                return true;
            }
            else
                return false;
        }

        private bool CheckValue(double minValue, double maxValue, double value, string message)
        {
            // Prüfung Wertbereich
            if ((value < minValue) || (value > maxValue))
            {
                MessageBox.Show(message + " muss zwischen " + minValue.ToString() + " und " + maxValue.ToString() + " liegen");
                return false;
            }
            else
                return true;
        }
        /// <summary>
        /// Es werden die Daten aus dem Formular entgegengenommen
        /// </summary>
        /// <returns></returns>
        public void getInput()
        {
            KreditBetrag = double.Parse(mainPage.getKreditbetrag());
            Zinssatz = double.Parse(mainPage.getZinssatz());
            Tilgungssatz = double.Parse(mainPage.getTilgungssatz());
            Laufzeit = int.Parse(mainPage.getLaufzeit());
            Date = mainPage.getDate();
        }
    }
}
}
