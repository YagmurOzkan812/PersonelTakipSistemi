using System;
using System.Data;
using MySql.Data.MySqlClient; // MySQL çağırıyoruz

namespace personelTakip.DAL
{
    public class Veritabani
    {
        //anahtar mysqle bağlar
        // Localhost connection (Default XAMPP/WAMP settings: User=root, Password="")
        private static string baglantiCumlesi = "Server=localhost; Database=26_132430040; Uid=root; Pwd=;";

        public static MySqlConnection Baglan()
        {
            MySqlConnection baglanti = new MySqlConnection(baglantiCumlesi);

            if (baglanti.State == ConnectionState.Closed)
            {
                try
                {
                    baglanti.Open();
                }
                catch (Exception hata)
                {
                    // Bağlantı hatası olursa
                    throw new Exception("Veritabanına bağlanılamadı: " + hata.Message);
                }
            }
            return baglanti;
        }
    }
}
