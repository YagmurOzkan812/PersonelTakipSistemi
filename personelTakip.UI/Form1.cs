using personelTakip.BLL;      // Müdürü çağırdık
using personelTakip.Entities; // Varlıkları çağırdık
using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace personelTakip.UI
{
    public partial class FormDepartmanlar : Form
    {
        // Müdürden bir tane oluşturuyoruz ki iş yaptırabilelim
        DepartmanYoneticisi yonetici = new DepartmanYoneticisi();

        public FormDepartmanlar()
        {
            InitializeComponent();
            ThemeHelper.ApplyTheme(this);
        }

        // Form açılırken  (Listeyi yüklemek için)
        private void FormDepartmanlar_Load(object sender, EventArgs e)
        {
            ListeyiYenile();
        }

       

        // KAYDET BUTONU TIKLANINCA
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Ekrandan verileri alıp paketle
                Departman d = new Departman();
                d.Ad = dprtmnTxtBox.Text;          // Birinci 
                d.Aciklama = aciklamaTxtBox.Text;    // İkinci 

                // 2. Müdüre paketi gönder
                yonetici.Ekle(d);

                // 3. Başarılı mesajı ver
                MessageBox.Show("Departman başarıyla eklendi!");

                // 4. Kutuları temizle ve listeyi güncelle
                dprtmnTxtBox.Clear();
                aciklamaTxtBox.Clear();
                ListeyiYenile();
            }
            catch (Exception hata)
            {
                // Hata varsa mesaj kutusunda göster
                MessageBox.Show("HATA: " + hata.Message);
            }
        }//  gidip kasadaki listeyi grid'e doldur
        private void ListeyiYenile()
        {
            personelTakip.BLL.DepartmanYoneticisi yonetici = new personelTakip.BLL.DepartmanYoneticisi();

            // DataGridView içini doldur
            dataGridView1.DataSource = yonetici.TumunuGetir();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            // 1. Kullanıcı tablodan bir satır seçmiş mi?
            if (dataGridView1.CurrentRow != null)
            {
                // Seçili satırın gizli ID numarasını alıyoruz
                // Cells[0] demek ilk sütun (yani ID sütunu).
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);

                // 2. Müdürü çağırıp sildir
                personelTakip.BLL.DepartmanYoneticisi yonetici = new personelTakip.BLL.DepartmanYoneticisi();
                yonetici.Sil(id);

                // 3. Listeyi yenile 
                ListeyiYenile();

                MessageBox.Show("Kayıt başarıyla silindi.");
            }
            else
            {
                MessageBox.Show("Lütfen silmek için listeden bir satır seçin.");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Listeden bir satıra tıklayınca verileri kutulara doldur
            // Başlıklara tıklarsa hata vermesin diye 
            if (e.RowIndex >= 0)
            {
                // Tıklanan satırı al
                DataGridViewRow satir = dataGridView1.Rows[e.RowIndex];

                // Kutulara veriyi yaz
                dprtmnTxtBox.Text = satir.Cells["Ad"].Value.ToString();
                aciklamaTxtBox.Text = satir.Cells["Aciklama"].Value.ToString();

                // NOT: ID numarasını da aklımızda tutmamız lazım ama şimdilik ekranda gizli kalsın.
                // Güncelle butonuna basınca onu grid'den tekrar okuruz.
            }
        }

        private void btnguncelle(object sender, EventArgs e)
        {


            if (dataGridView1.CurrentRow != null)
            {
                // 1. Güncellenecek verileri hazırla
                personelTakip.Entities.Departman d = new personelTakip.Entities.Departman();

                // ID'yi listeden alıyoruz (Hangi satırı güncelleyeceğimizi bilmek için şart)
                d.Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);

                // Yeni bilgileri kutulardan alıyoruz
                d.Ad = dprtmnTxtBox.Text;
                d.Aciklama = aciklamaTxtBox.Text;

                // 2. Müdürü çağır ve güncelle de
                personelTakip.BLL.DepartmanYoneticisi yonetici = new personelTakip.BLL.DepartmanYoneticisi();
                yonetici.Guncelle(d);

                // 3. Listeyi yenile ve mesaj ver
                ListeyiYenile();
                MessageBox.Show("Başarıyla güncellendi!");

                // Kutuları temizle
                dprtmnTxtBox.Clear();
                dprtmnTxtBox.Clear();
            }
        }

        private void FormDepartmanlar_Load_1(object sender, EventArgs e)
        { 
             // Form yüklenir yüklenmez listeyi getir
            ListeyiYenile();
        }
    }
       
}
