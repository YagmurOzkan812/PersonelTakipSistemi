using System;
using System.Data;
using MySql.Data.MySqlClient; // MySQL çağırıyoruz

namespace personelTakip.DAL
{
    public class Veritabani
    {
        //anahtar mysqle bağlar
        private static string baglantiCumlesi = "Server=172.21.54.253; Database=26_132430040; Uid=26_132430040; Pwd=İnif123.;";

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
