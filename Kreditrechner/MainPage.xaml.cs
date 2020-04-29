using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Kreditrechner.Daten;
using Kreditrechner.Model;

//Die Elementvorlage "Leere Seite" wird unter https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x407 dokumentiert.
/// <TODO>
/// 01: DataGridView richig verweisen (vom Typ her)
/// 
/// </TODO>


namespace Kreditrechner
{

    public sealed partial class MainPage : Page
    {
        private InputData Input;
        private OutputData Output;
        public MainPage()
        {
            this.InitializeComponent();
            Input = new InputData(this); //Mit "this" referenzieren wir auf die Klasse selbst, also auf das Objekt der Klasse MyForm
            Output = new OutputData(this);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


            // 1. Daten aus Formular auslesen
            Input.getInput();
            // 2. Daten validieren (Wertebereich)
            if (Input.CheckData() == true)
            {
                Annuitaet annuitaet = new Annuitaet(Input);
                annuitaet.Input = Input;
                // 3. Berechnung durchführen
                OutputData[] outputData = annuitaet.BerechneDarlehen();
                // 4. Daten an Formular ausgeben
                Output.setOutput(outputData);

            }
        }
        public string getKreditbetrag()
        {
            return textBoxKreditbetrag.Text;
        }
        public string getZinssatz()
        {
            return textBoxZinsatz.Text;
        }
        public string getTilgungssatz()
        {
            return textBoxTilgungssatz.Text;
        }
        public double getLaufzeit()
        {
            return sliderLaufzeit.Value;
        }
        public DateTimeOffset getDate()
        {
            return dateTimePicker.Date;
        }
        public DataGridView getDGV()
        {
            return dataGridView;
        }
    }
}
