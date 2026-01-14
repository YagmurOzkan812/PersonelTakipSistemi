using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace personelTakip.UI
{
    public partial class FormPersoneller : Form
    {
        public FormPersoneller()
        {
            InitializeComponent();
            ThemeHelper.ApplyTheme(this);
        }
        private void FormPersoneller_Load(object sender, EventArgs e)
        {
            // 1. Departman listesini veritabanından çek
            personelTakip.BLL.DepartmanYoneticisi depYonetici = new personelTakip.BLL.DepartmanYoneticisi();
            List<personelTakip.Entities.Departman> departmanlar = depYonetici.TumunuGetir();

            // 2. ComboBox'a bu listeyi bağla
            comboBox1.DataSource = departmanlar;
            comboBox1.DisplayMember = "Ad";  // Ekranda "Ad" 
            comboBox1.ValueMember = "Id";    // Arka planda "Id"  

            // 3. Mevcut personel de aşağıdaki tabloya 
            ListeyiYenile();
        }
        private void ListeyiYenile()
        {
            // Personel listesini çekip Gride doldur
            personelTakip.BLL.PersonelYoneticisi perYonetici = new personelTakip.BLL.PersonelYoneticisi();
            dataGridView1.DataSource = perYonetici.TumunuGetir();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Yeni bir personel nesnesi oluştur
                personelTakip.Entities.Personel p = new personelTakip.Entities.Personel();

                // 2. Kutulardaki verileri al
                p.Ad = textBox1.Text;        // Ad
                p.Soyad = textBox2.Text;     // Soyad
                p.TcNo = textBox3.Text;      // TC No

                // Maaş kutusundaki yazıyı sayıya çevir 
                decimal maasDegeri;
                bool sayiMi = decimal.TryParse(textBox4.Text, out maasDegeri);

                if (sayiMi == true)
                {
                    p.Maas = maasDegeri;
                }
                else
                {
                    p.Maas = 0; // Eğer sayı girmezse 0 yap
                }

                // comboboxtan seçilen Departmanın IDsini al
                p.DepartmanId = Convert.ToInt32(comboBox1.SelectedValue);

                // Tarihi al
                p.IseGirisTarihi = dateTimePicker1.Value;

                // Şimdilik şifre olarak TC no
                p.Sifre = p.TcNo;

                // 3. BLL çağır ve kaydet 
                personelTakip.BLL.PersonelYoneticisi yonetici = new personelTakip.BLL.PersonelYoneticisi();
                yonetici.Ekle(p);

                MessageBox.Show("Personel başarıyla eklendi!");

                // Listeyi güncelle 
                ListeyiYenile();
            }
            catch (Exception hata)
            {
                MessageBox.Show("HATA: " + hata.Message);
            }
        }
        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                // Silinecek kişi emin mi 
                DialogResult cevap = MessageBox.Show("Bu personeli silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo);

                if (cevap == DialogResult.Yes)
                {
                    // Seçili satırın ID si
                    int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value); // İlk sütun ID kabul ettik

                    // BLL çağır ve sil
                    personelTakip.BLL.PersonelYoneticisi yonetici = new personelTakip.BLL.PersonelYoneticisi();
                    yonetici.Sil(id);

                    // Listeyi yenile
                    ListeyiYenile();
                    MessageBox.Show("Personel silindi.");
                }
            }
            else
            {
                MessageBox.Show("Lütfen listeden silinecek personeli seçin.");
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Başlıklara tıklarsa hata vermesin
            if (e.RowIndex >= 0)
            {
                DataGridViewRow satir = dataGridView1.Rows[e.RowIndex];

                textBox1.Text = satir.Cells["Ad"].Value.ToString();
                textBox2.Text = satir.Cells["Soyad"].Value.ToString();
                textBox3.Text = satir.Cells["TcNo"].Value.ToString();
                textBox4.Text = satir.Cells["Maas"].Value.ToString();

                // Tarihi Doldur
                dateTimePicker1.Value = Convert.ToDateTime(satir.Cells["IseGirisTarihi"].Value);

                // Departmanı Seçtirme
                comboBox1.SelectedValue = Convert.ToInt32(satir.Cells["DepartmanId"].Value);
            }
        }
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Lütfen listeden bir satır seçin.");
                return;
            }

            try
            {
                personelTakip.Entities.Personel p = new personelTakip.Entities.Personel();

                // 1. ADIM: ID KONTROLÜ
                if (dataGridView1.CurrentRow.Cells["Id"].Value != null)
                {
                    try
                    {
                        p.Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
                    }
                    catch
                    {
                        // Eğer sütun adı "Id" değilse belki 0.
                        MessageBox.Show("HATA: ID numarası okunamadı. Grid'in ilk sütununda sayı olduğundan emin misin?");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("HATA: Seçilen satırın ID'si boş görünüyor.");
                    return;
                }

                // 2. ADIM: textboxlar
                p.Ad = textBox1.Text;
                p.Soyad = textBox2.Text;
                p.TcNo = textBox3.Text;

                // 3. ADIM: maaş
                decimal maas;
                bool maasOlduMu = decimal.TryParse(textBox4.Text, out maas);
                if (maasOlduMu)
                {
                    p.Maas = maas;
                }
                else
                {
                    MessageBox.Show("HATA: Maaş kutusuna yazdığın değer sayıya çevrilemiyor. Lütfen harf veya sembol kullanma.");
                    return;
                }

                // 4. ADIM: departman
                if (comboBox1.SelectedValue != null)
                {
                    try
                    {
                        p.DepartmanId = Convert.ToInt32(comboBox1.SelectedValue);
                    }
                    catch
                    {
                        MessageBox.Show("HATA: Departman seçimi hatalı. Seçilen değer ID'ye dönüşemedi.");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen Departman Seçiniz.");
                    return;
                }

                // 5. ADIM: tarih
                p.IseGirisTarihi = dateTimePicker1.Value;

                // BLL çağır ve güncelle
                personelTakip.BLL.PersonelYoneticisi yonetici = new personelTakip.BLL.PersonelYoneticisi();
                yonetici.Guncelle(p);

                MessageBox.Show("GÜNCELLEME BAŞARILI! 🎉");
                ListeyiYenile();

                // Temizlik
                textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox4.Clear();
            }
            catch (Exception genelHata)
            {
                // Yukarıdakilerin hiçbiri değilse 
                MessageBox.Show("BEKLENMEYEN BİR HATA: " + genelHata.Message);
            }
        }



    }
}
