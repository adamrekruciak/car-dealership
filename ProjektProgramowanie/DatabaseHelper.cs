using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ProjektProgramowanie
{
    public class DatabaseHelper
    {

        private string connectionString = "server=localhost; user=root; database=komisdb; password=";

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        public List<string> GetByZapytanie(string zapytanie)
        {
            List<string> list = new List<string>();
            MySqlConnection conn = GetConnection();
            try
            {
            conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = zapytanie;
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(reader.GetString(0));
                list.Add(reader.GetString(1));
                list.Add(reader.GetString(2));
                list.Add(reader.GetString(3));
                list.Add(reader.GetString(4));
                list.Add(reader.GetString(5));
                list.Add(reader.GetString(6));
            }
            reader.Close();
            conn.Close();
            
            return list;

        }

        public List<string> GetByBrand1()
        {
            List<string> list = new List<string>();
            MySqlConnection conn = GetConnection();
            try
            {
                conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = string.Format("SELECT p.id_pojazd, ma.nazwa_marka, m.nazwa_model, p.cena, p.rodzaj_paliwa, p.przebieg, p.rok_produkcji " +
                "FROM pojazd p INNER JOIN model m ON p.model_id = m.id_model INNER JOIN marka ma ON m.marka_id = ma.id_marka;");
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(reader.GetString(0));
                list.Add(reader.GetString(1));
                list.Add(reader.GetString(2));
                list.Add(reader.GetString(3));
                list.Add(reader.GetString(4));
                list.Add(reader.GetString(5));
                list.Add(reader.GetString(6));
            }
            reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                System.Windows.Application.Current.Shutdown();
            }
            conn.Close();
            return list;

        }

        public List<string> GetByID(string idpojazd)
        {
            List<string> list = new List<string>();
            MySqlConnection conn = GetConnection();
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = string.Format("SELECT ma.nazwa_marka, m.nazwa_model, p.cena, p.status, p.przebieg, p.stan_techniczny, p.silnik, p.moc, p.skrzynia_biegow, m.naped, p.kolor, p.rok_produkcji, p.faktura, p.vin, p.rodzaj_paliwa, zd.filename FROM pojazd p INNER JOIN model m ON p.model_id = m.id_model INNER JOIN marka ma ON m.marka_id = ma.id_marka LEFT JOIN image zd ON p.id_obrazek = zd.id_obrazek WHERE p.id_pojazd  LIKE \"{0}\";", idpojazd);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(reader.GetString(0));
                list.Add(reader.GetString(1));
                list.Add(reader.GetString(2));
                list.Add(reader.GetString(3));
                list.Add(reader.GetString(4));
                list.Add(reader.GetString(5));
                list.Add(reader.GetString(6));
                list.Add(reader.GetString(7));
                list.Add(reader.GetString(8));
                list.Add(reader.GetString(9));
                list.Add(reader.GetString(10));
                list.Add(reader.GetString(11));
                list.Add(reader.GetString(12));
                list.Add(reader.GetString(13));
                list.Add(reader.GetString(14));
                list.Add(reader.GetString(15));
            }
            reader.Close();
            conn.Close();
            return list;

        }

        public List<string> GetBrands()
        {
            List<string> list = new List<string>();
            MySqlConnection conn = GetConnection();
            try
            {
                conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = string.Format("SELECT nazwa_marka from marka;");
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(reader.GetString(0));
            }
            reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
            conn.Close();
            }
                return list;
            }

        public List<string> GetColors()
        {
            List<string> list = new List<string>();
            MySqlConnection conn = GetConnection();
            try
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = string.Format("Select DISTINCT kolor from pojazd;");
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(reader.GetString(0));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return list;
        }

        public List<string> GetFuel()
        {
            List<string> list = new List<string>();
            MySqlConnection conn = GetConnection();
            try
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = string.Format("Select DISTINCT rodzaj_paliwa from pojazd;");
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(reader.GetString(0));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return list;
        }

        public List<string> GetModels(string marka)
        {
            List<string> list = new List<string>();
            MySqlConnection conn = GetConnection();
            try
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = string.Format("SELECT nazwa_model FROM model m INNER JOIN marka ma ON m.marka_id=ma.id_marka WHERE nazwa_marka LIKE \"{0}\";", marka);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(reader.GetString(0));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return list;
        }

        public void UpdateStatus(string status, string pojazdid)
        {
            MySqlConnection conn = GetConnection();
            try
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                if (status == "Dostępny")
                {
                    cmd.CommandText = string.Format("update pojazd set status = \"Dostępny\" where id_pojazd={0}",pojazdid);
                }
                else if (status == "Niedostępny")
                {
                    cmd.CommandText = string.Format("update pojazd set status = \"Niedostępny\" where id_pojazd={0}", pojazdid);
                }
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            
        }

        public List<string> PicsById(string idpojazd)
        {
            List<string> list = new List<string>();
            MySqlConnection conn = GetConnection();
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = string.Format("SELECT p.id_pojazd, i.filename FROM pojazd p JOIN pojazd_images pi ON p.id_pojazd = pi.id_pojazd JOIN image i ON pi.id_obrazek = i.id_obrazek WHERE p.id_pojazd\r\n LIKE \"{0}\";", idpojazd);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(reader.GetString(0));
                list.Add(reader.GetString(1));
            }
            reader.Close();
            conn.Close();
            return list;

        }

    }
}
