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

namespace ProjektProgramowanie.Controls
{

    public partial class Auto : UserControl
    {
        public string idPojazd;

        public Auto(string id_pojazdu)
        {
            InitializeComponent();
            idPojazd = id_pojazdu;
            DatabaseHelper szczegoldb = new DatabaseHelper();
            
            List<string> lista = szczegoldb.GetByID(idPojazd);
            

            foreach (string item in lista)
            {
                Console.WriteLine(item);
            }

            Zdjecie.Source = new BitmapImage(new System.Uri("pack://application:,,,/Images/" + lista[15]));
        }

        private void DoSzczegolow_Click(object sender, RoutedEventArgs e)
        {
            Szczegoly newWindow = new Szczegoly(idPojazd);
            newWindow.Show();

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