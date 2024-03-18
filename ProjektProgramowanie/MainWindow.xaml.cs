using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
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
using MySql.Data.MySqlClient;
using ProjektProgramowanie.Controls;
using static System.Net.Mime.MediaTypeNames;

namespace ProjektProgramowanie
{

    public partial class MainWindow : Window
    {
        public string zapytanie = "SELECT p.id_pojazd, ma.nazwa_marka, m.nazwa_model, p.cena, p.rodzaj_paliwa, p.przebieg, p.rok_produkcji FROM pojazd p INNER JOIN model m ON p.model_id = m.id_model INNER JOIN marka ma ON m.marka_id = ma.id_marka";
        public string zapytanieMarka, zapytanieModel, zapytanieKolor, zapytaniePaliwo, zapytanieStan, zapytanieSkrzynia ,zapytanieFinal, zapytanieCenaOd, zapytanieCenaDo, zapytanieRokOd, zapytanieRokDo, zapytanieSort;

        public MainWindow()
        {
            InitializeComponent();
            DatabaseHelper db = new DatabaseHelper();
            List<string> carColor = db.GetColors();
            List<string> carBrands = db.GetBrands();
            List<string> carFuel = db.GetFuel();
            List<string> lata = new List<string>();
            List<string> latar = new List<string>();
            List<string> ascdescl = new List<string>() { "rosnąco", "malejąco" };
            for (int i = 2023; i > 1990; i--)
            {
                lata.Add(i.ToString());
                latar.Add(i.ToString());
            }
            List<string> cena = new List<string>();
            for (int i = 1000; i < 1000000; i++)
            {
                cena.Add(i.ToString());

                if (i >= 10000 && i < 100000)
                {
                    i += 9999;
                }
                else if (i >= 100000)
                {
                    i += 99999;
                }
                else
                    i += 999;
            }

            latar.Reverse();
            RokOd.ItemsSource = latar;
            RokDo.ItemsSource = lata;
            CenaOd.ItemsSource = cena;
            CenaDo.ItemsSource = cena;
            brandComboBox.ItemsSource = carBrands;
            brandComboBox.Text = "Marka";
            paliwoComboBox.ItemsSource = carFuel;
            kolorComboBox.ItemsSource = carColor;
            ascdesc.ItemsSource = ascdescl;


            List<string> list = db.GetByBrand1();


            int chunkSize = 7;
            int numChunks = (int)Math.Ceiling((double)list.Count / chunkSize);


            for (int i = 0; i < numChunks; i++)
            {

                int startIndex = i * chunkSize;
                Auto PokazAuto = new Auto(list[startIndex]);
                PokazAuto.markaLable.Content = list[startIndex + 1];
                PokazAuto.modelLable.Content = list[startIndex + 2];
                PokazAuto.cenaLable.Content = list[startIndex + 3] + "zł";
                PokazAuto.paliwoLable.Content = list[startIndex + 4];
                PokazAuto.stanLable.Content = list[startIndex + 5] + "km";
                PokazAuto.rocznikLable.Content = list[startIndex + 6];
                AutaStackPanel.Children.Add(PokazAuto);
            }

        }


        private void NieuszkodzonyRB_Checked(object sender, RoutedEventArgs e)
        {
            zapytanieStan = " and p.stan_techniczny like \"Nieuszkodzony\"";
        }

        private void UszkodzonyRB_Checked_1(object sender, RoutedEventArgs e)
        {
            zapytanieStan = " and p.stan_techniczny like \"Uszkodzony\"";
        }

        private void RokOd_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (RokOd.SelectedItem != null)
            {
                string selectedRokOd = RokOd.SelectedItem.ToString();

                zapytanieRokOd = string.Format(" and p.rok_produkcji > {0}", selectedRokOd);
            }
        }

        private void RokDo_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (RokDo.SelectedItem != null)
            {
                string selectedRokDo = RokDo.SelectedItem.ToString();

                zapytanieRokDo = string.Format(" and p.rok_produkcji < {0}", selectedRokDo);
            }
        }

        private void ascdesc_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (ascdesc.SelectedItem != null)
            {
                string wyborsort = ascdesc.SelectedItem.ToString();

                switch (wyborsort)
                {
                    case "rosnąco":
                        zapytanieSort = " group by p.cena asc";
                        return;

                    case "malejąco":
                        zapytanieSort = " group by p.cena desc";
                        return;

                }
            }
        }

        private void CenaDo_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (CenaDo.SelectedItem != null)
            {
                string selectedCenaDo = CenaDo.SelectedItem.ToString();

                zapytanieCenaDo = string.Format(" and cena < {0}", selectedCenaDo);
            }
        }

        private void CenaOd_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (CenaOd.SelectedItem != null)
            {
                string selectedCenaOd = CenaOd.SelectedItem.ToString();

                zapytanieCenaOd = string.Format(" and cena > {0}", selectedCenaOd);
            }
        }

        private void ManualRB_Checked_1(object sender, RoutedEventArgs e)
        {
            zapytanieSkrzynia = " and p.skrzynia_biegow like \"Manualna\"";
        }

        private void AutomatRB_Checked_1(object sender, RoutedEventArgs e)
        {
            zapytanieSkrzynia = " and p.skrzynia_biegow like \"Automat\"";
        }


        private void brandComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            DatabaseHelper db = new DatabaseHelper();

            if (brandComboBox.SelectedItem != null)
            {
                string selectedBrand = brandComboBox.SelectedItem.ToString();

                MarkaLabel.Content = selectedBrand; 
                zapytanieMarka = string.Format(" and ma.nazwa_marka like \"{0}\"", selectedBrand);
                zapytanieModel = "";
                ModelLabel.Content = "MODEL";
                modelComboBox.ItemsSource = db.GetModels(selectedBrand);
            }

        }

        private void modelComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (modelComboBox.SelectedItem != null)
            {
                string selectedModel = modelComboBox.SelectedItem.ToString();
                ModelLabel.Content = selectedModel;

                zapytanieModel = string.Format(" and m.nazwa_model like \"{0}\"", selectedModel);

            }

        }


        private void kolorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (kolorComboBox.SelectedItem != null)
            {
                string selectedKolor = kolorComboBox.SelectedItem.ToString();
                KolorLabel.Content = selectedKolor;

                zapytanieKolor = string.Format(" and p.kolor like \"{0}\"", selectedKolor);
            }
        }
        private void paliwoComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (paliwoComboBox.SelectedItem != null)
            {
                string selectedPaliwo = paliwoComboBox.SelectedItem.ToString();
                PaliwoLabel.Content = selectedPaliwo;

                zapytaniePaliwo = string.Format(" and p.rodzaj_paliwa like \"{0}\"", selectedPaliwo);

            }
        }
        private void Szukaj_Click(object sender, RoutedEventArgs e)
        {
            DatabaseHelper db = new DatabaseHelper();
            List<string> list;
            AutaStackPanel.Children.Clear();



            zapytanieFinal = zapytanie + zapytanieMarka + zapytanieModel + zapytanieKolor + zapytaniePaliwo + zapytanieStan + zapytanieSkrzynia + zapytanieRokOd + zapytanieRokDo + zapytanieCenaOd + zapytanieCenaDo + zapytanieSort;

            zapytanieFinal += ";";

            list = db.GetByZapytanie(zapytanieFinal);


            Console.WriteLine(zapytanieFinal);


            int chunkSize = 7;
            int numChunks = (int)Math.Ceiling((double)list.Count / chunkSize);


            for (int i = 0; i < numChunks; i++)
            {

                int startIndex = i * chunkSize;
                Auto PokazAuto = new Auto(list[startIndex]);
                PokazAuto.markaLable.Content = list[startIndex + 1];
                PokazAuto.modelLable.Content = list[startIndex + 2];
                PokazAuto.cenaLable.Content = list[startIndex + 3] + "zł";
                PokazAuto.paliwoLable.Content = list[startIndex + 4];
                PokazAuto.stanLable.Content = list[startIndex + 5] + "km";
                PokazAuto.rocznikLable.Content = list[startIndex + 6];
                AutaStackPanel.Children.Add(PokazAuto);
            }

          

            if (numChunks == 0)
            {
                LiczbaAutLabel.Content = "Niestety, nie możemy spełnić twoich oczekiwań.";
            }
            else if (numChunks == 1)
            {
                LiczbaAutLabel.Content = "Znaleziono " + numChunks + " ogłoszenie.";
            }
            else if (numChunks > 1 && numChunks < 5)
            {
                LiczbaAutLabel.Content = "Znaleziono " + numChunks + " ogłoszenia.";
            }
            else if (numChunks >= 5)
            {
                LiczbaAutLabel.Content = "Znaleziono " + numChunks + " ogłoszeń.";
            }
        }
          

    private void ClearButton_Click(object sender, RoutedEventArgs e)
            {
                Szukaj.IsEnabled = true;

                brandComboBox.SelectedItem = null;
                MarkaLabel.Content = "MARKA";
                zapytanieMarka = "";

                modelComboBox.SelectedItem = null;
                ModelLabel.Content = "MODEL";
                zapytanieModel = "";
                modelComboBox.ItemsSource = null;
               
                kolorComboBox.SelectedItem = null;
                KolorLabel.Content = "KOLOR";
                zapytanieKolor = "";

                paliwoComboBox.SelectedItem = null;
                PaliwoLabel.Content = "PALIWO";
                zapytaniePaliwo = "";

                NieuszkodzonyRB.IsChecked = false;
                UszkodzonyRB.IsChecked = false;
                zapytanieStan = "";

                ManualRB.IsChecked = false;
                AutomatRB.IsChecked = false;
                zapytanieSkrzynia = "";

                RokOd.SelectedItem = null;
                zapytanieRokOd = "";

                RokDo.SelectedItem = null;
                zapytanieRokDo = "";

                CenaOd.SelectedItem = null;
                zapytanieCenaOd = "";

                CenaDo.SelectedItem = null;
                zapytanieCenaDo = "";

                ascdesc.SelectedItem = null;
                zapytanieSort = "";


            }
        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                button.Cursor = Cursors.Hand;
            }
        }
    }

}


