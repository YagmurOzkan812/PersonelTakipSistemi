using System;

namespace personelTakip.Entities
{
    public class Personel : TemelVarlik
    {
        //veri taşıyıcıları
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string TcNo { get; set; }
        public decimal Maas { get; set; }
        public int DepartmanId { get; set; }
        public int RolId { get; set; } // 1:Admin, 2:İK, 3:Personel
        public string Sifre { get; set; }
        public DateTime IseGirisTarihi { get; set; }

        // Kod yazarken kolaylık olsun diye ad ve soyadı birleştirir
        public string AdSoyad
        {
            get { return Ad + " " + Soyad; }
        }
    }
}
