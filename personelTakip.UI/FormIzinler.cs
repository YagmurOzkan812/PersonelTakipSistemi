using System;
using System.Collections.Generic;
using System.Windows.Forms;
using personelTakip.BLL;
using personelTakip.Entities;

namespace personelTakip.UI
{
    public partial class FormIzinler : Form
    {
        public FormIzinler()
        {
            InitializeComponent();
            ThemeHelper.ApplyTheme(this);
        }

        // Form Açılınca Çalışacak 
        private void FormIzinler_Load(object sender, EventArgs e)
        {
            ListeleriDoldur();
        }

        void ListeleriDoldur()
        {
            // 1. Personelleri ComboBox'a Doldur
            PersonelYoneticisi perYonetici = new PersonelYoneticisi();
            List<Personel> personeller = perYonetici.TumunuGetir();

            comboBox1.DataSource = personeller;
            comboBox1.DisplayMember = "Ad"; // Listede isim
            comboBox1.ValueMember = "Id";   // Arka planda ID 

            // 2. Mevcut İzinleri Tabloya Doldur
            IzinYoneticisi izinYonetici = new IzinYoneticisi();
            dataGridView1.DataSource = izinYonetici.TumunuGetir();
        }

        // İZİN OLUŞTUR Butonu
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Izin i = new Izin();

                // Hangi personel 
                if (comboBox1.SelectedValue != null)
                {
                    i.PersonelId = Convert.ToInt32(comboBox1.SelectedValue);
                }
                else
                {
                    MessageBox.Show("Lütfen bir personel seçin!");
                    return;
                }

                // Tarihler
                i.BaslangicTarihi = dateTimePicker1.Value;
                i.BitisTarihi = dateTimePicker2.Value;

                // Açıklama
                i.Aciklama = textBox1.Text;

                // Varsayılan 
                i.Durum = "Onay Bekliyor";

                // Müdürü Çağır ve Kaydet
                IzinYoneticisi yonetici = new IzinYoneticisi();
                yonetici.Ekle(i);

                MessageBox.Show("İzin talebi oluşturuldu!");
                ListeleriDoldur(); // Tabloyu yenile
            }
            catch (Exception hata)
            {
                MessageBox.Show("HATA: " + hata.Message);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                // 1.Personel seçili mi
                if (comboBox1.SelectedValue == null)
                {
                    MessageBox.Show("Lütfen izin verilecek personeli seçiniz!");
                    return; // İşlemi durdur
                }

                // 2.Yeni bir İzin oluştur
                personelTakip.Entities.Izin yeniIzin = new personelTakip.Entities.Izin();

                // 3.Ekrandaki bilgileri doldur
                yeniIzin.PersonelId = Convert.ToInt32(comboBox1.SelectedValue); // ID
                yeniIzin.BaslangicTarihi = dateTimePicker1.Value;                // Başlangıç tarihi
                yeniIzin.BitisTarihi = dateTimePicker2.Value;                    // Bitiş tarihi
                yeniIzin.Aciklama = textBox1.Text;                               // Açıklama
                yeniIzin.Durum = "Onay Bekliyor";                                

                // 4.BLL çağır ve kaydet
                personelTakip.BLL.IzinYoneticisi yonetici = new personelTakip.BLL.IzinYoneticisi();
                yonetici.Ekle(yeniIzin);

                // 5. Başarılı
                MessageBox.Show("İzin talebi başarıyla oluşturuldu! 🎉");

                // 6.Listeyi yenile
                ListeleriDoldur();

                // 7 Kutuları temizle
                textBox1.Clear();
            }
            catch (Exception hata)
            {
                // Yanlışlık olursa
                MessageBox.Show("HATA OLUŞTU: " + hata.Message);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                DialogResult cevap = MessageBox.Show("Bu izin kaydını silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo);

                if (cevap == DialogResult.Yes)
                {
                    try
                    {
                        // Seçili satırın ID'si
                        int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);

                        // BLL ve sil
                        personelTakip.BLL.IzinYoneticisi yonetici = new personelTakip.BLL.IzinYoneticisi();
                        yonetici.Sil(id);

                        // Listeyi yenile
                        ListeleriDoldur();
                        MessageBox.Show("İzin kaydı silindi.");
                    }
                    catch (Exception hata)
                    {
                        MessageBox.Show("Hata: " + hata.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen listeden silinecek izni seçin.");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow satir = dataGridView1.Rows[e.RowIndex];

                // 1. Personeli Seç
                comboBox1.SelectedValue = Convert.ToInt32(satir.Cells["PersonelId"].Value);

                // 2. Tarihleri Doldur
                dateTimePicker1.Value = Convert.ToDateTime(satir.Cells["BaslangicTarihi"].Value);
                dateTimePicker2.Value = Convert.ToDateTime(satir.Cells["BitisTarihi"].Value);

                // 3. Açıklamayı Yaz
                textBox1.Text = satir.Cells["Aciklama"].Value.ToString();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                try
                {
                    personelTakip.Entities.Izin i = new personelTakip.Entities.Izin();
                    if (dataGridView1.CurrentRow.Cells["Id"].Value != null)
                    {
                        i.Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
                    }
                    else
                    {
                        MessageBox.Show("HATA: Tabloda ID hücresi boş görünüyor!");
                        return;
                    }
                   

                    // Diğer verileri al
                    i.PersonelId = Convert.ToInt32(comboBox1.SelectedValue);
                    i.BaslangicTarihi = dateTimePicker1.Value;
                    i.BitisTarihi = dateTimePicker2.Value;
                    i.Aciklama = textBox1.Text;

                    //durum bilgisi
                    i.Durum = cmbDurum.Text;


                    // BLL'e gönder
                    personelTakip.BLL.IzinYoneticisi yonetici = new personelTakip.BLL.IzinYoneticisi();
                    yonetici.Guncelle(i);

                    MessageBox.Show("İzin bilgileri güncellendi! ✅");
                    ListeleriDoldur(); // Listeyi yenilemeyi unutma
                }
                catch (Exception hata)
                {
                    MessageBox.Show("Hata Detayı: " + hata.Message);
                }
            }
            else
            {
                MessageBox.Show("Lütfen listeden güncellenecek satırı seçin.");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        
        {
            // Başlıklara tıklayınca hata vermesin diye kontrol
            if (e.RowIndex >= 0)
            {
                
                DataGridViewRow satir = dataGridView1.Rows[e.RowIndex];
               

                // 1. Personeli Seçtir
               
                if (satir.Cells["PersonelId"].Value != null)
                {
                    comboBox1.SelectedValue = Convert.ToInt32(satir.Cells["PersonelId"].Value);
                }

                // 2. Tarihleri Doldur
                dateTimePicker1.Value = Convert.ToDateTime(satir.Cells["BaslangicTarihi"].Value);
                dateTimePicker2.Value = Convert.ToDateTime(satir.Cells["BitisTarihi"].Value);

                // 3. Açıklamayı Yaz
                textBox1.Text = satir.Cells["Aciklama"].Value.ToString();

                // 4. DURUM KUTUSUNU DOLDUR
                if (satir.Cells["Durum"].Value != null)
                {
                    cmbDurum.Text = satir.Cells["Durum"].Value.ToString();
                }
            }
        }
    }
    
}