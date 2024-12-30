using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using deneme4;

namespace deneme4
{
    public partial class DersSecim : Form
    {
        Ogrenci ogr = new Ogrenci();
        Dersler drs = new Dersler();
        public DersSecim(string ogrnumara, int selectedOgrenciId)
        {
            InitializeComponent();
            ogr.Numara = ogrnumara;
            ogr.OgrenciId = selectedOgrenciId;
            labelnumara();
            LoadDersler();
            OgrencininAldigiDersler();
        }

        private void labelnumara()
        {
            if (string.IsNullOrEmpty(ogr.Numara))
            {
                MessageBox.Show("Öğrenci numarası boş olamaz.");
                return;
            }
            using (var ctx = new DBContext())
            {
                // Veritabanından öğrenci bilgilerini al
                var ogrenci = ctx.Ogrenciler
                    .Where(o => o.Numara == ogr.Numara)
                    .Select(o => new { o.Ad, o.Soyad, o.Numara, o.Sinif.SinifAd })  // İlgili alanları seçiyoruz
                    .FirstOrDefault();

                if (ogrenci != null)
                {
                    ogrlabel.Text = " Öğrenci Adı: " + ogrenci.Ad + " Öğrenci Soyadı: " + ogrenci.Soyad + " Öğrenci Numarası: " + ogrenci.Numara + " Öğrencinin Sınıfı: " + ogrenci.SinifAd;
                }
                else
                {
                    MessageBox.Show("Öğrenci bulunamadı.");
                }
            }
        }

        private void LoadDersler()
        {
            using (var context = new DBContext())
            {
                var dersler = context.tblDersler.Select(d => new
                {
                    d.DersId,
                    d.DersKod,
                    d.DersAd
                }).ToList();

                datagrid.DataSource = dersler;

                // DataGridView ayarları
                datagrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                datagrid.MultiSelect = true; // Çoklu seçim yapabilsin
            }
        }

        private void drsscmbtn_Click(object sender, EventArgs e)
        {
            using (var context = new DBContext())
            {
                foreach (DataGridViewRow row in datagrid.SelectedRows)
                {
                    int dersId = Convert.ToInt32(row.Cells["DersId"].Value);
                    var ders = context.tblDersler.Find(dersId);
                    var ogrenci = context.Ogrenciler.Find(ogr.OgrenciId);

                    if (ders != null && ogrenci != null)
                    {
                        var alreadyExists = context.tblOgrenciDers
                        .Any(od => od.OgrenciId == ogrenci.OgrenciId && od.DersId == ders.DersId);

                        if (alreadyExists)
                        {
                            MessageBox.Show($"'{ders.DersAd}' dersi zaten seçilmiş.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            var ogrenciDers = new OgrenciDers
                            {
                                OgrenciId = ogrenci.OgrenciId, // Principal Entity
                                DersId = ders.DersId        // Principal Entity
                            };
                            context.tblOgrenciDers.Add(ogrenciDers);
                            MessageBox.Show("Seçilen ders başarıyla kaydedildi!");
                        }
                    }
                }
                context.SaveChanges();
                OgrencininAldigiDersler();
            }
        }

        private void OgrencininAldigiDersler()
        {
            using (var context = new DBContext())
            {
                // OgrenciId'ye bağlı dersleri çek
                var kayitliDersler = context.tblOgrenciDers
                    .Where(od => od.OgrenciId == ogr.OgrenciId) // Sadece ilgili öğrenciye ait kayıtlar
                    .Select(od => new
                    {
                        DersId = od.DersId, // Ders ID
                        DersKod = od.Dersler.DersKod, // Ders Kodu
                        DersAd = od.Dersler.DersAd // Ders Adı
                    })
                    .ToList();

                // DataGridView'e bağla
                aldigidersler.DataSource = kayitliDersler;
            }
        }


    }
}
