using MySql.Data.MySqlClient;
using ProjektProgramowanie.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjektProgramowanie
{

    public partial class Szczegoly : Window
    {
        public string idPojazd2;

        public Szczegoly(string idPojazd)
        {
            InitializeComponent();

            DatabaseHelper szczegoldb = new DatabaseHelper();
            List<string> lista = szczegoldb.GetByID(idPojazd);
            List<string> lista2 = szczegoldb.PicsById(idPojazd);
            idPojazd2 = idPojazd;

            try
            {


                Obrazek1.Source = new BitmapImage(new System.Uri("pack://application:,,,/Images/" + lista2[1]));
                Obrazek2.Source = new BitmapImage(new System.Uri("pack://application:,,,/Images/" + lista2[3]));

             }
            catch {
                
                ButtonZdj1.Visibility = Visibility.Hidden;
                ButtonZdj2.Visibility = Visibility.Hidden;

                
            }
            finally
            {
                
            }


             idpojazdu.Text = idPojazd;

            foreach (string item in lista)
            {
                Console.WriteLine(item);
            }

            NazwaAuta.Text = lista[0] + " " + lista[1];
            PokazCena.Text = lista[2] + "zł";
            PokazStatus.Text = lista[3];
            PokazPrzebieg.Text = lista[4] + "km";
            PokazStan.Text = lista[5];
            PokazSilnik.Text = lista[6];
            PokazMoc1.Text = lista[7]+ "KM";
            PokazSkrzynia.Text = lista[8];
            PokazNaped.Text = lista[9];
            PokazKolor.Text = lista[10];
            PokazRok.Text = lista[11] + "r.";
            PokazFaktura.Text = lista[12];
            PokazVin.Text = lista[13];
            PokazPaliwo.Text = lista[14];
            Zdj.Source = new BitmapImage(new System.Uri("pack://application:,,,/Images/" + lista[15]));

            if (PokazStatus.Text == "Dostępny")
            {
                PokazStatus.Foreground = Brushes.Green;
                RezerwacjaButton.Content = "Zarezerwuj";
            }
            else if (PokazStatus.Text == "Niedostępny")
            {
                PokazStatus.Foreground = Brushes.Red;
                RezerwacjaButton.Content = "Odzarezerwuj";
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DatabaseHelper szczegoldb = new DatabaseHelper();
            string pojazdid = idpojazdu.Text;

            if (PokazStatus.Text == "Dostępny")
            {
                PokazStatus.Text = "Niedostępny";
                PokazStatus.Foreground = Brushes.Red;
                RezerwacjaButton.Content = "Odzarezerwuj";
                szczegoldb.UpdateStatus("Niedostępny", pojazdid);
            }
            else if (PokazStatus.Text == "Niedostępny")
            {
                PokazStatus.Text = "Dostępny";
                PokazStatus.Foreground = Brushes.Green;
                RezerwacjaButton.Content = "Zarezerwuj";
                szczegoldb.UpdateStatus("Dostępny", pojazdid);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            DatabaseHelper szczegoldb = new DatabaseHelper();
            List<string> lista = szczegoldb.PicsById(idPojazd2);
            Zdj.Source = new BitmapImage(new System.Uri("pack://application:,,,/Images/" + lista[3]));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DatabaseHelper szczegoldb = new DatabaseHelper();
            List<string> lista = szczegoldb.PicsById(idPojazd2);
            Zdj.Source = new BitmapImage(new System.Uri("pack://application:,,,/Images/" + lista[1]));
        }
    }
}