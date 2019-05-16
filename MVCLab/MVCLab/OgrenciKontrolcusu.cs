using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCLab
{
    class OgrenciKontrolcusu : IFactoryCreator // Controller
    {
        Ogrenci ogr = new Ogrenci();
        OgrenciGorunum ogrGor = new OgrenciGorunum();
        Ogrencilerim ogrencilerimController = new Ogrencilerim();

        internal Ogrenci Ogr { get => ogr; set => ogr = value; }
        internal OgrenciGorunum OgrGor { get => ogrGor; set => ogrGor = value; }
        internal Ogrencilerim OgrencilerimController { get => ogrencilerimController; set => ogrencilerimController = value; }

        internal OgrenciKontrolcusu(Ogrenci ogrenci, OgrenciGorunum ogrenciGorunum, Ogrencilerim myOgr)
        {
            Ogr = ogrenci;
            OgrGor = ogrenciGorunum;
            OgrencilerimController = myOgr;

            this.JsondanAlGenericeKaydet();
        }

        internal void OgrenciBilgileriniYazdir()
        {
            Console.WriteLine(Ogr.Isim + " " + Ogr.No + " " + " " + Ogr.Ort + " " + Ogr.Kayit + " " + Ogr.Bolum);
        }

        internal void OgrenciBilgileriniDegistirme(string yeniIsim, int yeniNo, int yeniOrt, int yeniKayit, string yeniBolum)
        {
            Ogr.Isim = yeniIsim;
            Ogr.No = yeniNo;
            Ogr.Ort = yeniOrt;
            Ogr.Kayit = yeniKayit;
            Ogr.Bolum = yeniBolum;
        }

        internal void JsondanAlGenericeKaydet() // JSONdosyadan oku
        {
            //Ref : https://www.newtonsoft.com/json/help/html/ReadJson.htm
            JObject o1 = JObject.Parse(File.ReadAllText(@"d:\ogrenci.json"));

            // read JSON directly from a file
            using (StreamReader file = File.OpenText(@"d:\ogrenci.json"))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject o2 = (JObject)JToken.ReadFrom(reader);
                for (int i = 0; i < o2.GetValue("ogrenciler").Count(); i++)
                {
                    OgrencilerimController.Ogrencis.Add(o2.GetValue("ogrenciler")[i].ToObject<Ogrenci>());
                }
            }
        }

        internal override string VeriGetir()
        {
            string all = "";

            for (int i = 0; i < OgrencilerimController.Ogrencis.Count; i++)
                all += OgrencilerimController.Ogrencis[i].Isim + " " + OgrencilerimController.Ogrencis[i].No + " " + OgrencilerimController.Ogrencis[i].Ort + " " + OgrencilerimController.Ogrencis[i].Kayit + " " + OgrencilerimController.Ogrencis[i].Bolum + "\n";

            return all;
        }
    }
}
