using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MessageBox = System.Windows.MessageBox;

namespace B4_Profilberechnung_Obj
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
            Hide();
        }

        private void Button_Click_Ende(object sender, RoutedEventArgs e)
        {
            //schließt die Anwendung nach erneuter Abfrage in einer Messagebox
            MessageBoxResult msgAbfrage = MessageBox.Show("Wirklich Beenden?", "Wirklich Beenden?",
                                                          MessageBoxButton.YesNo);

            if (msgAbfrage == MessageBoxResult.Yes)
            {
                Close();
            }

        }
        private void Button_Click_Reset(object sender, RoutedEventArgs e)
        {
            //setzt die Parameter in den Textboxen zurück
            txtParameter1.Text = "";
            txtParameter2.Text = "";
            txtParameter3.Text = "";
            txtParameter4.Text = "";
            txtParameter5.Text = "";
            txtParameter6.Text = "";
            txtLoesung.Text = "";

            txtLoesung.Visibility = Visibility.Hidden;
            lblLoesung.Visibility = Visibility.Hidden;
        }

        private void Button_Click_Berechne(object sender, RoutedEventArgs e)
        {
            TreeViewItem auswahlItem = (TreeViewItem)trvFigur.SelectedItem;
            string Variable = auswahlItem.Name;

            switch (Variable)
            {
                case ("itmRechteck"):
                    PruefeRechteck();
                    break;
                case ("itmDreieck"):
                    PruefeDreieck();
                    break;
                case ("itmKasten"):
                    PruefeKasten();
                    break;
                case ("itmKreisring"):
                    PruefeKreisring();
                    break;
                case ("itmUProfil"):
                    PruefeUProfil();
                    break;
                case ("itmIProfil"):
                    PruefeIProfil();
                    break;
            }                       
        }

        private void PruefeIProfil()
        {
            throw new NotImplementedException();
        }

        private void PruefeUProfil()
        {
            throw new NotImplementedException();
        }

        private void PruefeKreisring()
        {
            throw new NotImplementedException();
        }

        private void PruefeKasten()
        {
            Boolean EingabeOK = true;
            double KastenH;
            double Kastenh;
            double KastenB;
            double Kastenb;
            double KastenT;
            double Volumen;


            try
            {
                KastenH = Convert.ToDouble(txtParameter1.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Bitte nur Zahlen eingeben");
                EingabeOK = false;
                return;
            }

            if (KastenH <= 0)
            {
                MessageBox.Show("Bitte nur Zahlen größer 0 eingeben");
                EingabeOK = false;
                return;
            }

            try
            {
                Kastenh = Convert.ToDouble(txtParameter2.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Bitte nur Zahlen eingeben");
                EingabeOK = false;
                return;
            }
            if (Kastenh <= 0)
            {
                MessageBox.Show("Bitte nur Zahlen größer 0 eingeben");
                EingabeOK = false;
                return;
            }

            try
            {
                KastenB = Convert.ToDouble(txtParameter3.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Bitte nur Zahlen eingeben");
                EingabeOK = false;
                return;
            }
            if (KastenB <= 0)
            {
                MessageBox.Show("Bitte nur Zahlen größer 0 eingeben");
                EingabeOK = false;
                return;
            }
            
            try
            {
                Kastenb = Convert.ToDouble(txtParameter3.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Bitte nur Zahlen eingeben");
                EingabeOK = false;
                return;
            }
            if (Kastenb <= 0)
            {
                MessageBox.Show("Bitte nur Zahlen größer 0 eingeben");
                EingabeOK = false;
                return;
            }

            try
            {
                KastenT = Convert.ToDouble(txtParameter3.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Bitte nur Zahlen eingeben");
                EingabeOK = false;
                return;
            }

            if (Kastenh > KastenH || Kastenb>KastenB )
            {
                MessageBox.Show("Bitte nur h kleiner H oder b kleiner B eingeben");
                EingabeOK = false;
                return;
            }
          

            if (EingabeOK)
            {
                txtLoesung.Visibility = Visibility.Visible;
                lblLoesung.Visibility = Visibility.Visible;
                lblLoesung.Content = "Volumen:";

                Volumen = KastenH * KastenB * KastenT - Kastenh * Kastenb * KastenT;
                txtLoesung.Text = Convert.ToString(Volumen);
            }
        }

        private void PruefeDreieck()
        {
            Boolean EingabeOK = true;
            double DreieckH;
            double DreieckA;
            double DreieckT;
            double Volumen;


            try
            {
                DreieckH = Convert.ToDouble(txtParameter1.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Bitte nur Zahlen eingeben");
                EingabeOK = false;
                return;
            }

            if (DreieckH <= 0)
            {
                MessageBox.Show("Bitte nur Zahlen größer 0 eingeben");
                EingabeOK = false;
                return;
            }

            try
            {
                DreieckA = Convert.ToDouble(txtParameter2.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Bitte nur Zahlen eingeben");
                EingabeOK = false;
                return;
            }
            if (DreieckA <= 0)
            {
                MessageBox.Show("Bitte nur Zahlen größer 0 eingeben");
                EingabeOK = false;
                return;
            }

            try
            {
                DreieckT = Convert.ToDouble(txtParameter3.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Bitte nur Zahlen eingeben");
                EingabeOK = false;
                return;
            }
            if (DreieckT <= 0)
            {
                MessageBox.Show("Bitte nur Zahlen größer 0 eingeben");
                EingabeOK = false;
                return;
            }

            if (EingabeOK)
            {
                txtLoesung.Visibility = Visibility.Visible;
                lblLoesung.Visibility = Visibility.Visible;
                lblLoesung.Content = "Volumen:";

                Volumen = DreieckH * 1/2 * DreieckA * DreieckT;
                txtLoesung.Text = Convert.ToString(Volumen);
            }
        }

        private void PruefeRechteck()
        {
            Boolean EingabeOK = true;
            double RechteckH;
            double RechteckB;
            double RechteckT;
            double Volumen;

           
            try
            {
                RechteckH = Convert.ToDouble(txtParameter1.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Bitte nur Zahlen eingeben");
                EingabeOK = false;
                return;
            }

            if (RechteckH <= 0)
            {
                MessageBox.Show("Bitte nur Zahlen größer 0 eingeben");
                EingabeOK = false;
                return;
            }                       

            try
            {
                RechteckB = Convert.ToDouble(txtParameter2.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Bitte nur Zahlen eingeben");
                EingabeOK = false;
                return;
            }
            if (RechteckB <= 0)
            {
                MessageBox.Show("Bitte nur Zahlen größer 0 eingeben");
                EingabeOK = false;
                return;
            }

            try
            {
                RechteckT = Convert.ToDouble(txtParameter3.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Bitte nur Zahlen eingeben");
                EingabeOK = false;
                return;
            }
            if (RechteckT <= 0)
            {
                MessageBox.Show("Bitte nur Zahlen größer 0 eingeben");
                EingabeOK = false;
                return;
            }

            if (EingabeOK)
            {
                txtLoesung.Visibility = Visibility.Visible;
                lblLoesung.Visibility = Visibility.Visible;
                lblLoesung.Content = "Volumen:";

                Volumen = RechteckH * RechteckB * RechteckT;
                txtLoesung.Text = Convert.ToString(Volumen);
            }

        }

        private new void Hide()
        {
            // versteckt alle Textfelder und Parameterboxen und Bilder
            imRechteck.Visibility = Visibility.Hidden;
            imKasten.Visibility = Visibility.Hidden;
            imDreieck.Visibility = Visibility.Hidden;
            imKreisring.Visibility = Visibility.Hidden;
            imUProfil.Visibility = Visibility.Hidden;
            imIProfil.Visibility = Visibility.Hidden;

            lblParameter1.Visibility = Visibility.Hidden;
            lblParameter2.Visibility = Visibility.Hidden;
            lblParameter3.Visibility = Visibility.Hidden;
            lblParameter4.Visibility = Visibility.Hidden;
            lblParameter5.Visibility = Visibility.Hidden;
            lblParameter6.Visibility = Visibility.Hidden;
            lblHeader.Visibility = Visibility.Hidden;
            lblLoesung.Visibility = Visibility.Hidden;

            txtParameter1.Visibility = Visibility.Hidden;
            txtParameter2.Visibility = Visibility.Hidden;
            txtParameter3.Visibility = Visibility.Hidden;
            txtParameter4.Visibility = Visibility.Hidden;
            txtParameter5.Visibility = Visibility.Hidden;
            txtParameter6.Visibility = Visibility.Hidden;
            txtLoesung.Visibility = Visibility.Hidden;

            btnBerechne.IsEnabled = false;

        }        
        public void ShowRechteck()
        {
            // die für den ausgewählten Fall benötigten Label und Textboxen, sowie das passende Bild werden hier eingebledet
            lblParameter1.Visibility = Visibility.Visible;
            lblParameter2.Visibility = Visibility.Visible;
            lblParameter3.Visibility = Visibility.Visible;
            lblHeader.Visibility = Visibility.Visible;
            txtParameter1.Visibility = Visibility.Visible;
            txtParameter2.Visibility = Visibility.Visible;
            txtParameter3.Visibility = Visibility.Visible;
            imRechteck.Visibility = Visibility.Visible;

            // Beschriftung der Labels
            lblParameter1.Content = "h:";
            lblParameter2.Content = "b:";
            lblParameter3.Content = "Tiefe:";
            lblHeader.Content = "Rechteck";       
                   
            btnBerechne.IsEnabled = true;
        }
        public void ShowDreieck()
        {
            // die für den ausgewählten Fall benötigten Label und Textboxen, sowie das passende Bild werden hier eingebledet
            lblParameter1.Visibility = Visibility.Visible;
            lblParameter2.Visibility = Visibility.Visible;
            lblParameter3.Visibility = Visibility.Visible;
            lblHeader.Visibility = Visibility.Visible;
            txtParameter1.Visibility = Visibility.Visible;
            txtParameter2.Visibility = Visibility.Visible;
            txtParameter3.Visibility = Visibility.Visible;
            imDreieck.Visibility = Visibility.Visible;

            // Beschriftung der Labels
            lblParameter1.Content = "h:";
            lblParameter2.Content = "a:";
            lblParameter3.Content = "Tiefe:";
            lblHeader.Content = "Dreieck";

            btnBerechne.IsEnabled = true;
        }
        public void ShowKasten()
        {
            // die für den ausgewählten Fall benötigten Label und Textboxen, sowie das passende Bild werden hier eingebledet
            lblParameter1.Visibility = Visibility.Visible;
            lblParameter2.Visibility = Visibility.Visible;
            lblParameter3.Visibility = Visibility.Visible;
            lblParameter4.Visibility = Visibility.Visible;
            lblParameter5.Visibility = Visibility.Visible;
            lblHeader.Visibility = Visibility.Visible;
            txtParameter1.Visibility = Visibility.Visible;
            txtParameter2.Visibility = Visibility.Visible;
            txtParameter3.Visibility = Visibility.Visible;
            txtParameter4.Visibility = Visibility.Visible;
            txtParameter5.Visibility = Visibility.Visible;
            imKasten.Visibility = Visibility.Visible;

            // Beschriftung der Labels
            lblParameter1.Content = "H:";
            lblParameter2.Content = "h:";
            lblParameter3.Content = "B:";
            lblParameter4.Content = "b:";
            lblParameter5.Content = "Tiefe:";
            lblHeader.Content = "Kasten";

            btnBerechne.IsEnabled = true;

            
            
        }
        public void ShowKreisring()
        {
            // die für den ausgewählten Fall benötigten Label und Textboxen, sowie das passende Bild werden hier eingebledet
            lblParameter1.Visibility = Visibility.Visible;
            lblParameter2.Visibility = Visibility.Visible;
            lblParameter3.Visibility = Visibility.Visible;
            lblHeader.Visibility = Visibility.Visible;
            txtParameter1.Visibility = Visibility.Visible;
            txtParameter2.Visibility = Visibility.Visible;
            txtParameter3.Visibility = Visibility.Visible;
            imKreisring.Visibility = Visibility.Visible;

            // Beschriftung der Labels
            lblParameter1.Content = "R:";
            lblParameter2.Content = "r:";
            lblParameter3.Content = "Tiefe:";
            lblHeader.Content = "Kreisring";

            btnBerechne.IsEnabled = true;
        }
        public void ShowUProfil()
        {
            // die für den ausgewählten Fall benötigten Label und Textboxen, sowie das passende Bild werden hier eingebledet
            lblParameter1.Visibility = Visibility.Visible;
            lblParameter2.Visibility = Visibility.Visible;
            lblParameter3.Visibility = Visibility.Visible;
            lblParameter4.Visibility = Visibility.Visible;
            lblParameter5.Visibility = Visibility.Visible;
            lblHeader.Visibility = Visibility.Visible;
            txtParameter1.Visibility = Visibility.Visible;
            txtParameter2.Visibility = Visibility.Visible;
            txtParameter3.Visibility = Visibility.Visible;
            txtParameter4.Visibility = Visibility.Visible;
            txtParameter5.Visibility = Visibility.Visible;
            imUProfil.Visibility = Visibility.Visible;

            // Beschriftung der Labels
            lblParameter1.Content = "H:";
            lblParameter2.Content = "h:";
            lblParameter3.Content = "B:";
            lblParameter4.Content = "b:";
            lblParameter5.Content = "Tiefe:";
            lblHeader.Content = "U-Profil";

            btnBerechne.IsEnabled = true;
        }
        public void ShowIProfil()
        {
            // die für den ausgewählten Fall benötigten Label und Textboxen, sowie das passende Bild werden hier eingebledet
            lblParameter1.Visibility = Visibility.Visible;
            lblParameter2.Visibility = Visibility.Visible;
            lblParameter3.Visibility = Visibility.Visible;
            lblParameter4.Visibility = Visibility.Visible;
            lblParameter5.Visibility = Visibility.Visible;
            lblHeader.Visibility = Visibility.Visible;
            txtParameter1.Visibility = Visibility.Visible;
            txtParameter2.Visibility = Visibility.Visible;
            txtParameter3.Visibility = Visibility.Visible;
            txtParameter4.Visibility = Visibility.Visible;
            txtParameter5.Visibility = Visibility.Visible;
            imIProfil.Visibility = Visibility.Visible;

            // Beschriftung der Labels
            lblParameter1.Content = "H:";
            lblParameter2.Content = "h:";
            lblParameter3.Content = "B:";
            lblParameter4.Content = "b/2:";
            lblParameter5.Content = "Tiefe:";
            lblHeader.Content = "I-Profil";

            btnBerechne.IsEnabled = true;
        }


        private void trvFigur_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            Hide();

            // Test um mit dem Debugger zu testen, was denn überhaupt für ein Typ übergeben wir
            // Mit einem "object" kann man nicht wirklich arbeiten - var kann alles aufnehmen was kommt
            //    var eventargs = e.NewValue;
            //    var send = sender;

            // Variante 2
            //  TreeViewItem myE = (TreeViewItem) e.NewValue  ;
            //   string Variable = myE.Name;

            // Variante 3
            TreeViewItem auswahlItem = (TreeViewItem)trvFigur.SelectedItem;
            string Variable = auswahlItem.Name;

            switch (Variable)
            {
                case ("itmRechteck"):
                    ShowRechteck();
                    break;
                case ("itmDreieck"):
                    ShowDreieck();
                    break;
                case ("itmKasten"):
                    ShowKasten();
                    break;
                case ("itmKreisring"):
                    ShowKreisring();
                    break;
                case ("itmUProfil"):
                    ShowUProfil();
                    break;
                case ("itmIProfil"):
                    ShowIProfil();
                    break;
            }
        }
    }

       // private void itmRechteck_Selected(object sender, RoutedEventArgs e)
       //  {
            //  Variante 1
            //  var ev = e.Source;
            //  string auswahl1 = ((TreeViewItem)e.Source).Name.ToString();

            // Variante 4 
            //   var send = sender;
            //   string auswahl2 = ((TreeViewItem)sender).Name.ToString();

            // hier brauchen Sie die switch/case Abfrage nicht, denn sie wissen schon, dass itmRechteck die Quelle ist
            // Danke für die Fingerübung!
       //  }

    }    

