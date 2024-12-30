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
        Dersler? drs;  //bo� dn�yorsa bilgilendirmesi i�in ? kullan�l�r
        Sinif? snf;


        public Form1()
        {
            InitializeComponent();
            ogrsiniflist(); //uygulama ba�lad���nda direkt olarak s�n�f listesine default combobox doldurur.
        }


        private void button1_Click(object sender, EventArgs e)
        {

            try
            {           //t�m alanlar�n dolu olmas� zorunlulu�u i�in.
                if (TxtAd.Text == string.Empty || TxtSoyad.Text == string.Empty || TxtNumara.Text == string.Empty || SinifCombobox.SelectedIndex == -1)
                {
                    MessageBox.Show("T�m Alanlar Doldurmak Zorunludur");
                    return;
                }

                using (var ctx = new DBContext())  //varsay�lan bir numaray� tekrar kaydetmemesi i�in.  FirstOrDefault ilkini bulmas� i�in
                {
                    var snf = ctx.tblSiniflar.FirstOrDefault(s => s.SinifAd == SinifCombobox.SelectedItem.ToString());
                    if (snf != null)
                    {
                        if (snf.Kontenjan != 0 && snf.Kontenjan > 0)  //kontenjan her kay�tta 1 azals�n 0 de�ilse ve 0 dan b�y�k oldu�u s�rece �al��s�n
                        {
                            snf.Kontenjan--;
                            ctx.SaveChanges();
                            using (var context = new DBContext())
                            {
                                // Benzersizli�i kontrol etmesi i�in ekledim
                                bool numaraVarMi = context.Ogrenciler.Any(o => o.Numara == TxtNumara.Text.Trim());  //o => o lambda ifadesi kontrol ediyor e�le�medi�ini
                                if (numaraVarMi)
                                {
                                    MessageBox.Show("Bu numara zaten mevcut.");
                                    return;
                                }

                            }
                            try
                            {
                                using (var context = new DBContext()) //��renci bilgilerini kaydetmesi i�in ekledim
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
                                    MessageBox.Show("��renci ba�ar�yla kaydedildi.");
                                }
                            }
                            catch (Exception ex)
                            {

                                MessageBox.Show("��renci Kaydedilemedi Hata!" + "/n" + ex);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Kontenjan Doludur!!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("S�n�f Se�imi Bo� B�rak�lamaz.");
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Bir hata Olu�tu" + ex.Message);
            }


        }


        private void btnbul_Click(object sender, EventArgs e)  //��renci ekleme Bul Butonu
        {
            using (var ctx = new DBContext())
            {
                // Numara alan�na g�re ��renci bulma    //FirstOrDefault-First �nceden 2 tane ayn� numara ekleniyodu 1. sini getirmesi i�indi
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
                    MessageBox.Show("��renci Bulunamad�!");
                }
            }
        }

        private void btnguncel_Click(object sender, EventArgs e) //Buton G�ncelle
        {
            using (var ctx = new DBContext())
            {
                if (ogr != null)  //g�ncelle butonundan sonra yenileme yapt��� i�in tekrar 1 kontenjan d���rmesi gerekiyordu
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
                    ctx.Entry(ogr).State = EntityState.Modified;  //update yapmas� i�in databaseye -- ctx entry de verileri giriyor
                    MessageBox.Show(ctx.SaveChanges() > 0 ? "G�ncelleme Ba�ar�l�" : "G�ncelleme Ba�ar�s�z");
                }
                else
                {
                    MessageBox.Show("�nce ��renci Bulunmal�d�r.");
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
                // DersKod alan�na g�re ��renci bulma    //FirstOrDefault-First �nceden 2 tane ayn� numara ekleniyodu 1. sini getirmesi i�indi
                var drs = ctx.tblDersler.FirstOrDefault(d => d.DersKod == derskodtxt.Text.Trim());
                if (drs != null)
                {
                    dersadtxt.Text = drs.DersAd;
                    this.drs = drs;
                }
                else
                {
                    MessageBox.Show("Ders Bulunamad�!");
                }
            }
        }

        private void drskaydet_Click(object sender, EventArgs e)
        {
            if (derskodtxt.Text == string.Empty || dersadtxt.Text == string.Empty)
            {
                MessageBox.Show("T�m Alanlar Zorunludur");
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
                MessageBox.Show("Bir hata ile kar��la��ld�:\n" + ex.Message);
            }

            try
            {
                using (var context = new DBContext())
                {
                    // Benzersizli�i kontrol etmesi i�in ekledim
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
                MessageBox.Show("Bir hata ile kar��la��ld�:\n" + ex.Message);
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
                    MessageBox.Show("Ders ba�ar�yla kaydedildi.");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Bir hata ile kar��la��ld�." + "/n" + ex);
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
                            // Benzersizli�i kontrol etmesi i�in ekledim
                            bool DersAdVarmi = context.tblDersler.Any(d => d.DersAd == dersadtxt.Text.Trim());
                            if (DersAdVarmi)
                            {
                                MessageBox.Show("Se�ti�iniz ders mevcut olan bir dersle de�i�tirilemez.");
                                return;
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Bir hata ile kar��la��ld�:\n" + ex.Message);
                    }

                    MessageBox.Show(gnc.SaveChanges() > 0 ? "G�ncelleme Ba�ar�l�" : "G�ncelleme Ba�ar�s�z");


                }

                else
                {
                    MessageBox.Show("�nce Ders Bulunmal�d�r.");
                }


            }

        }

        private void snfkaydet_Click(object sender, EventArgs e)
        {
            if (sinifadtxt.Text == string.Empty || kontenjantxt.Text == string.Empty)
            {
                MessageBox.Show("T�m Alanlar Zorunludur");
                return;
            }

            try
            {
                using (var context = new DBContext())
                {
                    bool sinifadvarmi = context.tblSiniflar.Any(d => d.SinifAd == sinifadtxt.Text.Trim());
                    if (sinifadvarmi)
                    {
                        MessageBox.Show("Bu S�n�f Ad� zaten mevcut.");
                        return;
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Bir hata ile kar��la��ld�:\n" + ex.Message);
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
                    MessageBox.Show("S�n�f ba�ar�yla kaydedildi.");
                    ogrsiniflist(); //yeni s�n�f eklendi�inde s�n�f se�iniz comboboxu yenilenmesi i�in �a��rd�m.
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Bir hata ile kar��la��ld�." + "/n" + ex);
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


                    MessageBox.Show(gnc.SaveChanges() > 0 ? "G�ncelleme Ba�ar�l�" : "G�ncelleme Ba�ar�s�z");

                }

                else
                {
                    MessageBox.Show("�nce S�n�f Bulunmal�d�r.");
                }


            }
        }

        private void snfbul_Click(object sender, EventArgs e)
        {
            using (var ctx = new DBContext())
            {
                // DersKod alan�na g�re ��renci bulma    //FirstOrDefault-First �nceden 2 tane ayn� numara ekleniyodu 1. sini getirmesi i�indi
                var snf = ctx.tblSiniflar.FirstOrDefault(d => d.SinifAd == sinifadtxt.Text.Trim());
                if (snf != null)
                {
                    kontenjantxt.Text = snf.Kontenjan.ToString();
                    this.snf = snf;  //G�ncelleme yaparken snf nin i�erisine at�lan S�n�f Ad�n� g�rebilmesi i�in.
                }
                else
                {
                    MessageBox.Show("Kontenjan Bulunamad�!");
                }
            }
        }

        private void ogrsiniflist() //Bu metodu ��renci list i g�ncellemek i�in yazd�m bunu form1  in construcktorunda �a��r�yorum ve snfkaydet de �a��r�yorum listeyi g�ncelliyorum
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
                    MessageBox.Show("Hi� S�n�f Bulunamad�");
                }
            }
        }

    }
}

