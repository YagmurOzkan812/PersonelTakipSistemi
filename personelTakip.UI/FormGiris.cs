using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using personelTakip.DAL;
using personelTakip.Entities;

namespace personelTakip.UI
{
    public partial class FormGiris : Form
    {
        public FormGiris()
        {
            InitializeComponent();
            ThemeHelper.ApplyTheme(this);
        }

        // Giriş butonu
        private void button1_Click(object sender, EventArgs e)
        {
            string kAdi = textBox1.Text;
            string sifre = textBox2.Text;

            if (string.IsNullOrEmpty(kAdi) || string.IsNullOrEmpty(sifre))
            {
                MessageBox.Show("Lütfen bilgileri doldurun.");
                return;
            }

            // 1. Yönetici girişi seçiliyse
            if (radioButton1.Checked)
            {
                if (YoneticiGirisKontrol(kAdi, sifre))
                {
                    Genel.IsAdmin = true;
                    FormAnaMenu menu = new FormAnaMenu();
                    this.Hide();
                    menu.Show();
                }
                else
                {
                    MessageBox.Show("Hatalı Yönetici Bilgisi!");
                }
            }
            // 2. Personel girişi seçiliyse
            else
            {
                PersonelGirisKontrol(kAdi, sifre);
            }
        }

        // Yönetici kontrolü
        bool YoneticiGirisKontrol(string kadi, string sifre)
        {
            using (MySqlConnection baglanti = Veritabani.Baglan())
            {
                string sorgu = "SELECT * FROM admins WHERE kullanici_adi=@p1 AND sifre=@p2";
                MySqlCommand komut = new MySqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@p1", kadi);
                komut.Parameters.AddWithValue("@p2", sifre);

                MySqlDataReader oku = komut.ExecuteReader();
                return oku.Read();
            }
        }

        // Personel kontrolü
        void PersonelGirisKontrol(string tc, string sifre)
        {
            using (MySqlConnection baglanti = Veritabani.Baglan())
            {
                // Direkt TC ve Şifre eşleşmesi
                string sorgu = "SELECT * FROM employees WHERE tc_no=@p1 AND sifre=@p2";

                MySqlCommand komut = new MySqlCommand(sorgu, baglanti);

                komut.Parameters.AddWithValue("@p1", tc.Trim());
                komut.Parameters.AddWithValue("@p2", sifre.Trim());

                MySqlDataReader oku = komut.ExecuteReader();

                if (oku.Read())
                {
                    // GİRİŞ BAŞARILI
                    Genel.AktifPersonelId = Convert.ToInt32(oku["id"]);
                    Genel.AktifPersonelAdSoyad = oku["ad"].ToString() + " " + oku["soyad"].ToString();

                    int personelDepartmanId = Convert.ToInt32(oku["departman_id"]);

                    
                    int ikDepartmanId = 5;

                    if (personelDepartmanId == ikDepartmanId)
                    {
                        // İK İSE YÖNETİCİ PANELİ
                        Genel.IsAdmin = true;
                        MessageBox.Show("İK Yetkili Girişi Başarılı! 🚀");
                        FormAnaMenu anaMenu = new FormAnaMenu();
                        this.Hide();
                        anaMenu.Show();
                    }
                    else
                    {
                        // NORMAL ÇALIŞAN İSE KISITLI PANEL
                        Genel.IsAdmin = false;
                        FormCalisanPaneli calisanPanel = new FormCalisanPaneli();
                        this.Hide();
                        calisanPanel.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Giriş Başarısız!\n\nLütfen şunları kontrol edin:\n1. TC Kimlik Numaranızı doğru girdiniz mi?\n2. Şifreniz (Varsayılan olarak TC No) doğru mu?");
                }
            }
        }
        // Program kapandığında durur
        private void FormGiris_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}