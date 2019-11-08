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

namespace B4_Profilberechnung_Obj
{
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            
            InitializeComponent();
            Hide();
        }

         private void ZeigeBild(string strImage)
         {
        //      BitmapImage btMap;
        //      btMap.BeginInit();
        //      btMap.UriSource = new Uri(strImage, UriKind.Relative);
        //      btMap.EndInit();
        //      imFigur.Visibility = Visibility.Visible;
        //      imFigur.Source = btMap;
          }


        private void Button_Click_Ende(object sender, RoutedEventArgs e)
        {
            //schließt die Anwendung
            Close();
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
        }

        private void Button_Click_Berechne(object sender, RoutedEventArgs e)
        {

        }

        private new void Hide()
        {
            // versteckt alle Textfelder und Parameterboxen
            imFigur.Visibility = Visibility.Hidden;
            lblParameter1.Visibility = Visibility.Hidden;
            lblParameter2.Visibility = Visibility.Hidden;
            lblParameter3.Visibility = Visibility.Hidden;
            lblParameter4.Visibility = Visibility.Hidden;
            lblParameter5.Visibility = Visibility.Hidden;
            lblParameter6.Visibility = Visibility.Hidden;

            txtParameter1.Visibility = Visibility.Hidden;
            txtParameter2.Visibility = Visibility.Hidden;
            txtParameter3.Visibility = Visibility.Hidden;
            txtParameter4.Visibility = Visibility.Hidden;
            txtParameter5.Visibility = Visibility.Hidden;
            txtParameter6.Visibility = Visibility.Hidden;
            btnBerechne.IsEnabled=false;
            
        }

        public void Rechteck()
        {
             lblParameter1.Visibility = Visibility.Visible;
             lblParameter2.Visibility = Visibility.Visible;
             lblParameter3.Visibility = Visibility.Visible;
             txtParameter1.Visibility = Visibility.Visible;
             txtParameter2.Visibility = Visibility.Visible;
             txtParameter3.Visibility = Visibility.Visible;

             lblParameter1.Content = "Höhe:";
             lblParameter2.Content = "Breite:";
             lblParameter3.Content = "Tiefe:";

            btnBerechne.IsEnabled = true;
        }
        public void Dreieck()
        {
            lblParameter1.Visibility = Visibility.Visible;
            lblParameter2.Visibility = Visibility.Visible;
            lblParameter3.Visibility = Visibility.Visible;
            txtParameter1.Visibility = Visibility.Visible;
            txtParameter2.Visibility = Visibility.Visible;
            txtParameter3.Visibility = Visibility.Visible;

            lblParameter1.Content = "Höhe:";
            lblParameter2.Content = "Breite:";
            lblParameter3.Content = "Tiefe:";

            btnBerechne.IsEnabled = true;
        }
        public void Kasten()
        {

        }
        public void Kreis()
        {

        }
        public void UProfil()
        {

        }
        public void IProfil()
        {

        }


        private void trvFigur_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            Hide();

            trvFigur.SelectedItem.

            string Variable = ;

            switch (Variable)
            {
                case ("itmRechteck"):
                    Rechteck();
                    break;
                case ("itmDreieck"):
                    Dreieck();
                    break;
                case ("itmKasten"):
                    Kasten();
                    break;
                case ("itmKreis"):
                    Kreis();
                    break;
                case ("itmUProfil"):
                    UProfil();
                    break;
                case ("itmIProfil"):
                    IProfil();
                    break;
                
                        
            } 
            
        }

        
}
