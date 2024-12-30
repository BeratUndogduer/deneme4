namespace deneme4
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            grpogrenci = new GroupBox();
            drssecim = new Button();
            SinifCombobox = new ComboBox();
            siniflbl = new Label();
            btnbul = new Button();
            btnguncel = new Button();
            numara = new Label();
            soyad = new Label();
            ad = new Label();
            btnkaydet = new Button();
            TxtNumara = new TextBox();
            TxtSoyad = new TextBox();
            TxtAd = new TextBox();
            groupBox1 = new GroupBox();
            drsguncelle = new Button();
            drsbul = new Button();
            drskaydet = new Button();
            label2 = new Label();
            label1 = new Label();
            dersadtxt = new TextBox();
            derskodtxt = new TextBox();
            groupBox2 = new GroupBox();
            snfbul = new Button();
            snfguncelle = new Button();
            snfkaydet = new Button();
            label4 = new Label();
            kontenjantxt = new TextBox();
            label3 = new Label();
            sinifadtxt = new TextBox();
            grpogrenci.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // grpogrenci
            // 
            grpogrenci.Controls.Add(drssecim);
            grpogrenci.Controls.Add(SinifCombobox);
            grpogrenci.Controls.Add(siniflbl);
            grpogrenci.Controls.Add(btnbul);
            grpogrenci.Controls.Add(btnguncel);
            grpogrenci.Controls.Add(numara);
            grpogrenci.Controls.Add(soyad);
            grpogrenci.Controls.Add(ad);
            grpogrenci.Controls.Add(btnkaydet);
            grpogrenci.Controls.Add(TxtNumara);
            grpogrenci.Controls.Add(TxtSoyad);
            grpogrenci.Controls.Add(TxtAd);
            grpogrenci.Location = new Point(12, 13);
            grpogrenci.Margin = new Padding(3, 4, 3, 4);
            grpogrenci.Name = "grpogrenci";
            grpogrenci.Padding = new Padding(3, 4, 3, 4);
            grpogrenci.Size = new Size(431, 405);
            grpogrenci.TabIndex = 0;
            grpogrenci.TabStop = false;
            grpogrenci.Text = "Öğrenci Ekleme";
            // 
            // drssecim
            // 
            drssecim.Location = new Point(167, 355);
            drssecim.Margin = new Padding(3, 4, 3, 4);
            drssecim.Name = "drssecim";
            drssecim.Size = new Size(106, 33);
            drssecim.TabIndex = 13;
            drssecim.Text = "Ders Seçimi";
            drssecim.UseVisualStyleBackColor = true;
            drssecim.Click += drssecim_Click_1;
            // 
            // SinifCombobox
            // 
            SinifCombobox.FormattingEnabled = true;
            SinifCombobox.Location = new Point(112, 236);
            SinifCombobox.Name = "SinifCombobox";
            SinifCombobox.Size = new Size(236, 28);
            SinifCombobox.TabIndex = 12;

          
            // 
            // siniflbl
            // 
            siniflbl.AutoSize = true;
            siniflbl.Location = new Point(18, 239);
            siniflbl.Name = "siniflbl";
            siniflbl.Size = new Size(88, 20);
            siniflbl.TabIndex = 11;
            siniflbl.Text = "Sınıf Seçiniz";
            // 
            // btnbul
            // 
            btnbul.Location = new Point(279, 305);
            btnbul.Margin = new Padding(3, 4, 3, 4);
            btnbul.Name = "btnbul";
            btnbul.Size = new Size(106, 33);
            btnbul.TabIndex = 10;
            btnbul.Text = "Bul";
            btnbul.UseVisualStyleBackColor = true;
            btnbul.Click += btnbul_Click;
            // 
            // btnguncel
            // 
            btnguncel.Location = new Point(55, 305);
            btnguncel.Margin = new Padding(3, 4, 3, 4);
            btnguncel.Name = "btnguncel";
            btnguncel.Size = new Size(106, 33);
            btnguncel.TabIndex = 9;
            btnguncel.Text = "Güncelle";
            btnguncel.UseVisualStyleBackColor = true;
            btnguncel.Click += btnguncel_Click;
            // 
            // numara
            // 
            numara.AutoSize = true;
            numara.Location = new Point(44, 190);
            numara.Name = "numara";
            numara.Size = new Size(62, 20);
            numara.TabIndex = 6;
            numara.Text = "Numara";
            // 
            // soyad
            // 
            soyad.AutoSize = true;
            soyad.Location = new Point(52, 142);
            soyad.Name = "soyad";
            soyad.Size = new Size(50, 20);
            soyad.TabIndex = 5;
            soyad.Text = "Soyad";
            // 
            // ad
            // 
            ad.AutoSize = true;
            ad.Location = new Point(55, 97);
            ad.Name = "ad";
            ad.Size = new Size(28, 20);
            ad.TabIndex = 4;
            ad.Text = "Ad";
            // 
            // btnkaydet
            // 
            btnkaydet.Location = new Point(167, 305);
            btnkaydet.Margin = new Padding(3, 4, 3, 4);
            btnkaydet.Name = "btnkaydet";
            btnkaydet.Size = new Size(106, 33);
            btnkaydet.TabIndex = 3;
            btnkaydet.Text = "Kaydet";
            btnkaydet.UseVisualStyleBackColor = true;
            btnkaydet.Click += button1_Click;
            // 
            // TxtNumara
            // 
            TxtNumara.Location = new Point(112, 187);
            TxtNumara.Margin = new Padding(3, 4, 3, 4);
            TxtNumara.MaxLength = 20;
            TxtNumara.Name = "TxtNumara";
            TxtNumara.Size = new Size(236, 27);
            TxtNumara.TabIndex = 2;
            // 
            // TxtSoyad
            // 
            TxtSoyad.Location = new Point(112, 142);
            TxtSoyad.Margin = new Padding(3, 4, 3, 4);
            TxtSoyad.MaxLength = 20;
            TxtSoyad.Name = "TxtSoyad";
            TxtSoyad.Size = new Size(236, 27);
            TxtSoyad.TabIndex = 1;
            // 
            // TxtAd
            // 
            TxtAd.Location = new Point(112, 94);
            TxtAd.Margin = new Padding(3, 4, 3, 4);
            TxtAd.MaxLength = 20;
            TxtAd.Name = "TxtAd";
            TxtAd.Size = new Size(236, 27);
            TxtAd.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(drsguncelle);
            groupBox1.Controls.Add(drsbul);
            groupBox1.Controls.Add(drskaydet);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(dersadtxt);
            groupBox1.Controls.Add(derskodtxt);
            groupBox1.Location = new Point(464, 13);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(320, 402);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ders Ekleme";
            // 
            // drsguncelle
            // 
            drsguncelle.Location = new Point(20, 305);
            drsguncelle.Margin = new Padding(3, 4, 3, 4);
            drsguncelle.Name = "drsguncelle";
            drsguncelle.Size = new Size(88, 33);
            drsguncelle.TabIndex = 10;
            drsguncelle.Text = "Güncelle";
            drsguncelle.UseVisualStyleBackColor = true;
            drsguncelle.Click += drsguncelle_Click;
            // 
            // drsbul
            // 
            drsbul.Location = new Point(212, 305);
            drsbul.Margin = new Padding(3, 4, 3, 4);
            drsbul.Name = "drsbul";
            drsbul.Size = new Size(87, 33);
            drsbul.TabIndex = 8;
            drsbul.Text = "Bul";
            drsbul.UseVisualStyleBackColor = true;
            drsbul.Click += drsbul_Click;
            // 
            // drskaydet
            // 
            drskaydet.Location = new Point(114, 305);
            drskaydet.Margin = new Padding(3, 4, 3, 4);
            drskaydet.Name = "drskaydet";
            drskaydet.Size = new Size(92, 33);
            drskaydet.TabIndex = 7;
            drskaydet.Text = "Kaydet";
            drskaydet.UseVisualStyleBackColor = true;
            drskaydet.Click += drskaydet_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(94, 159);
            label2.Name = "label2";
            label2.Size = new Size(112, 20);
            label2.TabIndex = 6;
            label2.Text = "Ders Adı Giriniz";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(94, 73);
            label1.Name = "label1";
            label1.Size = new Size(124, 20);
            label1.TabIndex = 5;
            label1.Text = "Ders Kodu Giriniz";
            // 
            // dersadtxt
            // 
            dersadtxt.Location = new Point(38, 183);
            dersadtxt.Margin = new Padding(3, 4, 3, 4);
            dersadtxt.MaxLength = 20;
            dersadtxt.Name = "dersadtxt";
            dersadtxt.Size = new Size(236, 27);
            dersadtxt.TabIndex = 2;
            // 
            // derskodtxt
            // 
            derskodtxt.Location = new Point(38, 97);
            derskodtxt.Margin = new Padding(3, 4, 3, 4);
            derskodtxt.MaxLength = 20;
            derskodtxt.Name = "derskodtxt";
            derskodtxt.Size = new Size(236, 27);
            derskodtxt.TabIndex = 1;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(snfbul);
            groupBox2.Controls.Add(snfguncelle);
            groupBox2.Controls.Add(snfkaydet);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(kontenjantxt);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(sinifadtxt);
            groupBox2.Location = new Point(805, 13);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(308, 398);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Sınıf Ekleme";
            // 
            // snfbul
            // 
            snfbul.Location = new Point(212, 305);
            snfbul.Margin = new Padding(3, 4, 3, 4);
            snfbul.Name = "snfbul";
            snfbul.Size = new Size(87, 33);
            snfbul.TabIndex = 12;
            snfbul.Text = "Bul";
            snfbul.UseVisualStyleBackColor = true;
            snfbul.Click += snfbul_Click;
            // 
            // snfguncelle
            // 
            snfguncelle.Location = new Point(6, 305);
            snfguncelle.Margin = new Padding(3, 4, 3, 4);
            snfguncelle.Name = "snfguncelle";
            snfguncelle.Size = new Size(88, 33);
            snfguncelle.TabIndex = 11;
            snfguncelle.Text = "Güncelle";
            snfguncelle.UseVisualStyleBackColor = true;
            snfguncelle.Click += snfguncelle_Click;
            // 
            // snfkaydet
            // 
            snfkaydet.Location = new Point(100, 305);
            snfkaydet.Margin = new Padding(3, 4, 3, 4);
            snfkaydet.Name = "snfkaydet";
            snfkaydet.Size = new Size(106, 33);
            snfkaydet.TabIndex = 9;
            snfkaydet.Text = "Kaydet";
            snfkaydet.UseVisualStyleBackColor = true;
            snfkaydet.Click += snfkaydet_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(100, 159);
            label4.Name = "label4";
            label4.Size = new Size(122, 20);
            label4.TabIndex = 8;
            label4.Text = "Kontenjan Giriniz";
            // 
            // kontenjantxt
            // 
            kontenjantxt.Location = new Point(38, 183);
            kontenjantxt.Margin = new Padding(3, 4, 3, 4);
            kontenjantxt.MaxLength = 20;
            kontenjantxt.Name = "kontenjantxt";
            kontenjantxt.Size = new Size(236, 27);
            kontenjantxt.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(88, 73);
            label3.Name = "label3";
            label3.Size = new Size(111, 20);
            label3.TabIndex = 6;
            label3.Text = "Sınıf Adı Giriniz";
            // 
            // sinifadtxt
            // 
            sinifadtxt.Location = new Point(38, 97);
            sinifadtxt.Margin = new Padding(3, 4, 3, 4);
            sinifadtxt.MaxLength = 20;
            sinifadtxt.Name = "sinifadtxt";
            sinifadtxt.Size = new Size(236, 27);
            sinifadtxt.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1149, 445);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(grpogrenci);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            grpogrenci.ResumeLayout(false);
            grpogrenci.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private GroupBox grpogrenci;
        private Button btnkaydet;
        private TextBox TxtNumara;
        private TextBox TxtSoyad;
        private TextBox TxtAd;
        private Label numara;
        private Label soyad;
        private Label ad;
        private Button btnbul;
        private Button btnguncel;
        private Label siniflbl;
        private ComboBox SinifCombobox;
        private Button drssecim;
        private GroupBox groupBox1;
        private TextBox derskodtxt;
        private Button drskaydet;
        private Label label2;
        private Label label1;
        private TextBox dersadtxt;
        private GroupBox groupBox2;
        private Button snfkaydet;
        private Label label4;
        private TextBox kontenjantxt;
        private Label label3;
        private TextBox sinifadtxt;
        private Button drsguncelle;
        private Button drsbul;
        private Button snfbul;
        private Button snfguncelle;
    }
}