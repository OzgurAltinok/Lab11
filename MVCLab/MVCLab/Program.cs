using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MVCLab
{
    class Program
    {
        static void Main(string[] args)
        {
            Ogrencilerim myOgr = new Ogrencilerim();

            OgrenciGorunum ogrenciGorunum = new OgrenciGorunum(myOgr);

            Ogrenci ogr = new Ogrenci();

            OgrenciKontrolcusu ogrenciKontrolcusu = new OgrenciKontrolcusu(ogr, ogrenciGorunum, myOgr);

            //Yorum satirlarini acip kapatip kodlari deneyebilirsiniz.
            //json dosyasini D:/ogrenci.json yoluna kayitladim.
            // Proje icindeki ogrenci.json'u D'ye atip deneyin.

            //binary dosyadan okuyup listeye ekleyen metot
            //ogrenciGorunum.OgrenciBilgileriniBinaryOkuGenericeKaydet();

            //Numarasi en buyuk ogrenciyi bulduk ve atadik
            //Ref : https://stackoverflow.com/questions/1101841/linq-how-to-perform-max-on-a-property-of-all-objects-in-a-collection-and-ret
            ogr = ogrenciGorunum.TumOgrencilerim.Ogrencis.OrderByDescending(item => item.No).First();
            Console.WriteLine("en buyuk nolu ogrenci: " + ogr.Isim + " " + ogr.No + " " + ogr.Ort + " " + ogr.Kayit + " " + ogr.Bolum);

            //OgrenciKontrolcusu ogrKontrol = new OgrenciKontrolcusu(ogr, ogrenciGorunum, myOgr);

            //ogrKontrol.OgrenciBilgileriniDegistirme("hayal", 342, 75, 2014, "yazilim");
            //ogrKontrol.OgrenciBilgileriniYazdir();

            //i = 0 OgrenciGorunum'den cagiriyor
            //i = 1 OgrenciKontrolcusu'nden cagiriyor
            //i = 2 Exception ornegi
            for (int i = 0; i < 3; i++)
                Console.WriteLine(VeriUretme.Get(i, ogr, ogrenciGorunum));

            Console.ReadKey();
        }
    }
}
