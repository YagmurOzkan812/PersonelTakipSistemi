namespace personelTakip.UI
{
    partial class FormDepartmanlar
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.dprtmnTxtBox = new System.Windows.Forms.TextBox();
            this.aciklamaTxtBox = new System.Windows.Forms.TextBox();
            this.dprtmnAdıLabel = new System.Windows.Forms.Label();
            this.aciklamaLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnsil = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dprtmnTxtBox
            // 
            this.dprtmnTxtBox.BackColor = System.Drawing.Color.Lavender;
            this.dprtmnTxtBox.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dprtmnTxtBox.Location = new System.Drawing.Point(195, 48);
            this.dprtmnTxtBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dprtmnTxtBox.Name = "dprtmnTxtBox";
            this.dprtmnTxtBox.Size = new System.Drawing.Size(385, 34);
            this.dprtmnTxtBox.TabIndex = 0;
            // 
            // aciklamaTxtBox
            // 
            this.aciklamaTxtBox.BackColor = System.Drawing.Color.Lavender;
            this.aciklamaTxtBox.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.aciklamaTxtBox.Location = new System.Drawing.Point(195, 133);
            this.aciklamaTxtBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.aciklamaTxtBox.Name = "aciklamaTxtBox";
            this.aciklamaTxtBox.Size = new System.Drawing.Size(385, 34);
            this.aciklamaTxtBox.TabIndex = 1;
            // 
            // dprtmnAdıLabel
            // 
            this.dprtmnAdıLabel.AutoSize = true;
            this.dprtmnAdıLabel.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dprtmnAdıLabel.Location = new System.Drawing.Point(27, 56);
            this.dprtmnAdıLabel.Name = "dprtmnAdıLabel";
            this.dprtmnAdıLabel.Size = new System.Drawing.Size(162, 27);
            this.dprtmnAdıLabel.TabIndex = 2;
            this.dprtmnAdıLabel.Text = "Departman Adı:";
            // 
            // aciklamaLabel
            // 
            this.aciklamaLabel.AutoSize = true;
            this.aciklamaLabel.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.aciklamaLabel.Location = new System.Drawing.Point(27, 141);
            this.aciklamaLabel.Name = "aciklamaLabel";
            this.aciklamaLabel.Size = new System.Drawing.Size(103, 27);
            this.aciklamaLabel.TabIndex = 3;
            this.aciklamaLabel.Text = "Açıklama:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Lavender;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(647, 48);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 119);
            this.button1.TabIndex = 4;
            this.button1.Text = "KAYDET";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Lavender;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.Location = new System.Drawing.Point(33, 291);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(547, 178);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnsil
            // 
            this.btnsil.BackColor = System.Drawing.Color.Lavender;
            this.btnsil.FlatAppearance.BorderSize = 0;
            this.btnsil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsil.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnsil.ForeColor = System.Drawing.Color.Black;
            this.btnsil.Location = new System.Drawing.Point(657, 286);
            this.btnsil.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnsil.Name = "btnsil";
            this.btnsil.Size = new System.Drawing.Size(137, 62);
            this.btnsil.TabIndex = 6;
            this.btnsil.Text = "SİL";
            this.btnsil.UseVisualStyleBackColor = false;
            this.btnsil.Click += new System.EventHandler(this.btnsil_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Lavender;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(657, 407);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(137, 62);
            this.button2.TabIndex = 7;
            this.button2.Text = "GÜNCELLE";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.TextChanged += new System.EventHandler(this.btnguncelle);
            this.button2.Click += new System.EventHandler(this.btnguncelle);
            // 
            // FormDepartmanlar
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(832, 503);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnsil);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.aciklamaLabel);
            this.Controls.Add(this.dprtmnAdıLabel);
            this.Controls.Add(this.aciklamaTxtBox);
            this.Controls.Add(this.dprtmnTxtBox);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormDepartmanlar";
            this.Text = "Personel Takip Sistemi";
            this.Load += new System.EventHandler(this.FormDepartmanlar_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox dprtmnTxtBox;
        private System.Windows.Forms.TextBox aciklamaTxtBox;
        private System.Windows.Forms.Label dprtmnAdıLabel;
        private System.Windows.Forms.Label aciklamaLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnsil;
        private System.Windows.Forms.Button button2;
    }
}

