using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deneme4
{
    internal class Ogrenci
    {
        public int OgrenciId { get; set; } //en başa yazıp altına özellik girince PK oluyor

        [Column(TypeName = "varchar")]
        [MaxLength(20)]
        [Required]
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Numara { get; set; }

        public int SinifId { get; set; }

        public Sinif Sinif { get; set; }  //Navigation Property nesneler arası ilişki ifade etsin diye kullandım

        public ICollection<OgrenciDers> OgrenciDersler { get; set; }  //ICollection tabloya veri ekleyip silmek için EF gereksinimi için kullandım

        public override string ToString()
        {
            return $"Ad:{this.Ad}-Soyad:{this.Soyad}-Numara:{this.Numara}";
        }
    }
    //Sınıf classını oluşturdum sinifıd'nin özelliklerini belirledim
    internal class Sinif
    {
        [Column(TypeName = "int")]  //altındakini tetikliyor bu özellikler
        [MaxLength(20)]
        [Required]
        public int SinifId { get; set; }

        public string SinifAd { get; set; }

        public int Kontenjan { get; set; }

        public ICollection<Ogrenci> Ogrenciler { get; set; }
    }

    internal class OgrenciDers
    {
        public int DersId { get; set; }  //eğer belirtmezsen ilk yazdıgını PK alır
        public Dersler Dersler { get; set; }
        public int OgrenciId { get; set; }
        public Ogrenci Ogrenci { get; set; }


    }

    internal class Dersler
    {
        [Column(TypeName = "int")]
        [MaxLength(20)]
        [Required]
        public int DersId { get; set; }


        public string DersKod { get; set; }

        public string DersAd { get; set; }

        public ICollection<OgrenciDers> OgrenciDersler { get; set; }
    }
}