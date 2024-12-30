using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace deneme4
{
    public partial class Form1 : Form
    {
        Ogrenci? ogr;
        Dersler? drs;  //boþ dnüyorsa bilgilendirmesi için ? kullanýlýr
        Sinif? snf;


        public Form1()
        {
            InitializeComponent();
            ogrsiniflist(); //uygulama baþladýðýnda direkt olarak sýnýf listesine default combobox doldurur.
        }


        private void button1_Click(object sender, EventArgs e)
        {

            try
            {           //tüm alanlarýn dolu olmasý zorunluluðu için.
                if (TxtAd.Text == string.Empty || TxtSoyad.Text == string.Empty || TxtNumara.Text == string.Empty || SinifCombobox.SelectedIndex == -1)
                {
                    MessageBox.Show("Tüm Alanlar Doldurmak Zorunludur");
                    return;
                }

                using (var ctx = new DBContext())  //varsayýlan bir numarayý tekrar kaydetmemesi için.  FirstOrDefault ilkini bulmasý için
                {
                    var snf = ctx.tblSiniflar.FirstOrDefault(s => s.SinifAd == SinifCombobox.SelectedItem.ToString());
                    if (snf != null)
                    {
                        if (snf.Kontenjan != 0 && snf.Kontenjan > 0)  //kontenjan her kayýtta 1 azalsýn 0 deðilse ve 0 dan büyük olduðu sürece çalýþsýn
                        {
                            snf.Kontenjan--;
                            ctx.SaveChanges();
                            using (var context = new DBContext())
                            {
                                // Benzersizliði kontrol etmesi için ekledim
                                bool numaraVarMi = context.Ogrenciler.Any(o => o.Numara == TxtNumara.Text.Trim());  //o => o lambda ifadesi kontrol ediyor eþleþmediðini
                                if (numaraVarMi)
                                {
                                    MessageBox.Show("Bu numara zaten mevcut.");
                                    return;
                                }

                            }
                            try
                            {
                                using (var context = new DBContext()) //Öðrenci bilgilerini kaydetmesi için ekledim
                                {
                                    var ogr = new Ogrenci
                                    {
                                        Ad = TxtAd.Text,
                                        Soyad = TxtSoyad.Text,
                                        Numara = TxtNumara.Text,
                                        SinifId = snf.SinifId,
                                    };

                                    context.Ogrenciler.Add(ogr);
                                    context.SaveChanges();
                                    MessageBox.Show("Öðrenci baþarýyla kaydedildi.");
                                }
                            }
                            catch (Exception ex)
                            {

                                MessageBox.Show("Öðrenci Kaydedilemedi Hata!" + "/n" + ex);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Kontenjan Doludur!!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Sýnýf Seçimi Boþ Býrakýlamaz.");
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Bir hata Oluþtu" + ex.Message);
            }


        }


        private void btnbul_Click(object sender, EventArgs e)  //Öðrenci ekleme Bul Butonu
        {
            using (var ctx = new DBContext())
            {
                // Numara alanýna göre öðrenci bulma    //FirstOrDefault-First önceden 2 tane ayný numara ekleniyodu 1. sini getirmesi içindi
                var ogr = ctx.Ogrenciler.FirstOrDefault(o => o.Numara == TxtNumara.Text.Trim());
                if (ogr != null)
                {
                    this.ogr = ogr;
                    TxtAd.Text = ogr.Ad;
                    TxtSoyad.Text = ogr.Soyad;
                    TxtNumara.Text = ogr.Numara;
                    var snf = ctx.tblSiniflar.FirstOrDefault(s => s.SinifAd == SinifCombobox.SelectedItem.ToString());
                    if (snf != null)
                    {
                        SinifCombobox.SelectedItem = snf.SinifAd;
                    }
                }
                else
                {
                    MessageBox.Show("Öðrenci Bulunamadý!");
                }
            }
        }

        private void btnguncel_Click(object sender, EventArgs e) //Buton Güncelle
        {
            using (var ctx = new DBContext())
            {
                if (ogr != null)  //güncelle butonundan sonra yenileme yaptýðý için tekrar 1 kontenjan düþürmesi gerekiyordu
                {
                    ogr.Numara = TxtNumara.Text.Trim();
                    ogr.Ad = TxtAd.Text.Trim();
                    ogr.Soyad = TxtSoyad.Text.Trim();
                    var snf = ctx.tblSiniflar.FirstOrDefault(s => s.SinifAd == SinifCombobox.SelectedItem.ToString());
                    if (snf != null && snf.Kontenjan != 0 && snf.Kontenjan > 0)
                    {
                        ogr.SinifId = snf.SinifId;
                        snf.Kontenjan--;
                    }
                    ctx.Entry(ogr).State = EntityState.Modified;  //update yapmasý için databaseye -- ctx entry de verileri giriyor
                    MessageBox.Show(ctx.SaveChanges() > 0 ? "Güncelleme Baþarýlý" : "Güncelleme Baþarýsýz");
                }
                else
                {
                    MessageBox.Show("Önce Öðrenci Bulunmalýdýr.");
                }
            }
        }

        private void drssecim_Click_1(object sender, EventArgs e)
        {
            try
            {
                using (var ctx = new DBContext())
                {
                    var ogr = ctx.Ogrenciler.FirstOrDefault(o => o.Numara == TxtNumara.Text.Trim());
                    if (ogr != null)
                    {
                        this.ogr = ogr;
                        DersSecim form2 = new DersSecim(ogr.Numara, ogr.OgrenciId);
                        form2.Show();
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Bir hata" + ex.Message);
            }

        }

        private void drsbul_Click(object sender, EventArgs e)
        {
            using (var ctx = new DBContext())
            {
                // DersKod alanýna göre öðrenci bulma    //FirstOrDefault-First önceden 2 tane ayný numara ekleniyodu 1. sini getirmesi içindi
                var drs = ctx.tblDersler.FirstOrDefault(d => d.DersKod == derskodtxt.Text.Trim());
                if (drs != null)
                {
                    dersadtxt.Text = drs.DersAd;
                    this.drs = drs;
                }
                else
                {
                    MessageBox.Show("Ders Bulunamadý!");
                }
            }
        }

        private void drskaydet_Click(object sender, EventArgs e)
        {
            if (derskodtxt.Text == string.Empty || dersadtxt.Text == string.Empty)
            {
                MessageBox.Show("Tüm Alanlar Zorunludur");
                return;
            }

            try
            {
                using (var context = new DBContext())
                {
                    bool derskodvarmi = context.tblDersler.Any(d => d.DersKod == derskodtxt.Text.Trim());
                    if (derskodvarmi)
                    {
                        MessageBox.Show("Bu ders kodu zaten mevcut.");
                        return;
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Bir hata ile karþýlaþýldý:\n" + ex.Message);
            }

            try
            {
                using (var context = new DBContext())
                {
                    // Benzersizliði kontrol etmesi için ekledim
                    bool DersAdVarmi = context.tblDersler.Any(d => d.DersAd == dersadtxt.Text.Trim());
                    if (DersAdVarmi)
                    {
                        MessageBox.Show("Bu Ders zaten mevcut.");
                        return;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata ile karþýlaþýldý:\n" + ex.Message);
            }

            try
            {
                using (var context = new DBContext())
                {
                    var drs = new Dersler
                    {
                        DersAd = dersadtxt.Text,
                        DersKod = derskodtxt.Text,

                    };

                    context.tblDersler.Add(drs);
                    context.SaveChanges();
                    MessageBox.Show("Ders baþarýyla kaydedildi.");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Bir hata ile karþýlaþýldý." + "/n" + ex);
            }
        }

        private void drsguncelle_Click(object sender, EventArgs e)
        {
            using (var gnc = new DBContext())
            {

                if (drs != null)
                {
                    drs.DersKod = derskodtxt.Text.Trim();
                    drs.DersAd = dersadtxt.Text.Trim();
                    gnc.Entry(drs).State = EntityState.Modified;

                    try
                    {
                        using (var context = new DBContext())
                        {
                            // Benzersizliði kontrol etmesi için ekledim
                            bool DersAdVarmi = context.tblDersler.Any(d => d.DersAd == dersadtxt.Text.Trim());
                            if (DersAdVarmi)
                            {
                                MessageBox.Show("Seçtiðiniz ders mevcut olan bir dersle deðiþtirilemez.");
                                return;
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Bir hata ile karþýlaþýldý:\n" + ex.Message);
                    }

                    MessageBox.Show(gnc.SaveChanges() > 0 ? "Güncelleme Baþarýlý" : "Güncelleme Baþarýsýz");


                }

                else
                {
                    MessageBox.Show("Önce Ders Bulunmalýdýr.");
                }


            }

        }

        private void snfkaydet_Click(object sender, EventArgs e)
        {
            if (sinifadtxt.Text == string.Empty || kontenjantxt.Text == string.Empty)
            {
                MessageBox.Show("Tüm Alanlar Zorunludur");
                return;
            }

            try
            {
                using (var context = new DBContext())
                {
                    bool sinifadvarmi = context.tblSiniflar.Any(d => d.SinifAd == sinifadtxt.Text.Trim());
                    if (sinifadvarmi)
                    {
                        MessageBox.Show("Bu Sýnýf Adý zaten mevcut.");
                        return;
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Bir hata ile karþýlaþýldý:\n" + ex.Message);
            }


            try
            {

                using (var context = new DBContext())
                {
                    var snf = new Sinif
                    {
                        SinifAd = sinifadtxt.Text,
                        Kontenjan = Int32.Parse(kontenjantxt.Text),

                    };


                    context.tblSiniflar.Add(snf);
                    context.SaveChanges();
                    MessageBox.Show("Sýnýf baþarýyla kaydedildi.");
                    ogrsiniflist(); //yeni sýnýf eklendiðinde sýnýf seçiniz comboboxu yenilenmesi için çaðýrdým.
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Bir hata ile karþýlaþýldý." + "/n" + ex);
            }
        }

        private void snfguncelle_Click(object sender, EventArgs e)
        {
            using (var gnc = new DBContext())
            {

                if (snf != null)
                {
                    snf.SinifAd = sinifadtxt.Text.Trim();
                    snf.Kontenjan = Int32.Parse(kontenjantxt.Text);
                    gnc.Entry(snf).State = EntityState.Modified;


                    MessageBox.Show(gnc.SaveChanges() > 0 ? "Güncelleme Baþarýlý" : "Güncelleme Baþarýsýz");

                }

                else
                {
                    MessageBox.Show("Önce Sýnýf Bulunmalýdýr.");
                }


            }
        }

        private void snfbul_Click(object sender, EventArgs e)
        {
            using (var ctx = new DBContext())
            {
                // DersKod alanýna göre öðrenci bulma    //FirstOrDefault-First önceden 2 tane ayný numara ekleniyodu 1. sini getirmesi içindi
                var snf = ctx.tblSiniflar.FirstOrDefault(d => d.SinifAd == sinifadtxt.Text.Trim());
                if (snf != null)
                {
                    kontenjantxt.Text = snf.Kontenjan.ToString();
                    this.snf = snf;  //Güncelleme yaparken snf nin içerisine atýlan Sýnýf Adýný görebilmesi için.
                }
                else
                {
                    MessageBox.Show("Kontenjan Bulunamadý!");
                }
            }
        }

        private void ogrsiniflist() //Bu metodu öðrenci list i gðncellemek için yazdým bunu form1  in construcktorunda çaðýrýyorum ve snfkaydet de çaðýrýyorum listeyi güncelliyorum
        {
            using (var ctx = new DBContext())
            {
                var siniflist = ctx.tblSiniflar.Select(s => s.SinifAd).ToList();

                if (siniflist != null && siniflist.Any())
                {
                    SinifCombobox.DataSource = siniflist;
                }
                else
                {
                    MessageBox.Show("Hiç Sýnýf Bulunamadý");
                }
            }
        }

    }
}

