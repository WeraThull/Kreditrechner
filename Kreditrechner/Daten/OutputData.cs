//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Kreditrechner.Daten
//{
//    public class OutputData
//    {
//        MainPage mainPage;
//        public OutputData() { }
//        public OutputData(MainPage mainPage1)
//        {
//            this.mainPage = mainPage1; //this ist immer ein Bezug auf die Klasse
//        }
//        public double Kreditbetrag { get; set; }
//        public double Zinsen { get; set; }
//        public double Tilgung { get; set; }
//        public double Annuitaet { get; set; }
//        public double Restbetrag { get; set; }
//        public DateTime Date { get; set; }

//        /// <summary>
//        /// Hier erfolgt die Ausgabe in das Formular
//        /// </summary>
//        /// <param name="data"></param>
//        public void setOutput(OutputData[] value)
//        { /// 
//            mainPage.getDGV().RowCount = value.Length;
//            for (int i = 0; i < value.Length; i++)
//            {
//                mainPage.getDGV().Rows[0].Cells[0].Value = value[i].Date.Year;
//                mainPage.getDGV().Rows[i].Cells[1].Value = value[i].Date.Month;
//                mainPage.getDGV().Rows[i].Cells[2].Value = value[i].Kreditbetrag.ToString("#.00");
//                mainPage.getDGV().Rows[i].Cells[3].Value = value[i].Zinsen.ToString("#.00");
//                mainPage.getDGV().Rows[i].Cells[4].Value = value[i].Tilgung.ToString("#.00");
//                mainPage.getDGV().Rows[i].Cells[5].Value = value[i].Annuitaet.ToString("#.00");
//                mainPage.getDGV().Rows[i].Cells[6].Value = value[i].Restbetrag.ToString("#.00");
//                if (i > 11)
//                {
//                    mainPage.getDGV().Rows[i].Cells[0].Value = value[i].Date.Year;
//                    mainPage.getDGV().Rows[i].Cells[1].Value = value[12].Date.Month; // hier dann der fixe Monat aus dem DateTime-Picker
//                    mainPage.getDGV().Rows[i].Cells[2].Value = value[i].Kreditbetrag.ToString("#.00");
//                    mainPage.getDGV().Rows[i].Cells[3].Value = value[i].Zinsen.ToString("#.00");
//                    mainPage.getDGV().Rows[i].Cells[4].Value = value[i].Tilgung.ToString("#.00");
//                    mainPage.getDGV().Rows[i].Cells[5].Value = value[i].Annuitaet.ToString("#.00");
//                    mainPage.getDGV().Rows[i].Cells[6].Value = value[i].Restbetrag.ToString("#.00");
//                }
//            }
//        }
//    }
//}