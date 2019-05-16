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
    class OgrenciGorunum : IFactoryCreator // View
    {
        Ogrencilerim tumOgrencilerim = new Ogrencilerim();
        string okunan;

        internal Ogrencilerim TumOgrencilerim { get => tumOgrencilerim; set => tumOgrencilerim = value; }
        public string Okunan { get => okunan; set => okunan = value; }

        internal OgrenciGorunum(Ogrencilerim myOgr)
        {
            TumOgrencilerim = myOgr;
            this.OgrenciBilgileriniOkuNesneyeAta();
        }

        internal OgrenciGorunum()
        {

        }

        internal void OgrenciBilgileriniYazdir(Ogrencilerim myOgr)
        {
            for (int i = 0; i < myOgr.Ogrencis.Count; i++)
                Console.WriteLine(myOgr.Ogrencis[i].Isim + " " + myOgr.Ogrencis[i].No + " " + myOgr.Ogrencis[i].Ort + " " + myOgr.Ogrencis[i].Kayit + " " + myOgr.Ogrencis[i].Bolum);
        }

        internal void SiralaVeBinaryYaz(Ogrencilerim myOgr)
        {
            //Ogrenci numarasına gore siraladik ve ardindan binary olarak yazdirdik.
            myOgr.Ogrencis.Sort((first, second) => first.No.CompareTo(second.No));

            //binary kaydetme
            //Ref : https://www.tutorialspoint.com/csharp/csharp_binary_files.htm
            BinaryWriter bw;

            //create the file
            try
            {
                bw = new BinaryWriter(new FileStream("mydata", FileMode.Create));
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message + "\n Cannot create file.");
                return;
            }

            //writing into the file
            try
            {
                //binary olarak json formatinda yaz
                //Ref : https://www.newtonsoft.com/json/help/html/SerializingJSON.htm
                string json = JsonConvert.SerializeObject(myOgr);
                bw.Write(json);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message + "\n Cannot write to file.");
                return;
            }
            bw.Close();
        }

        // BinaryDosyadan Oku ve List'e kaydet
        internal void OgrenciBilgileriniBinaryOkuGenericeKaydet()
        {
            BinaryReader br;

            //reading from the file
            //Ref : https://www.tutorialspoint.com/csharp/csharp_binary_files.htm
            try
            {
                br = new BinaryReader(new FileStream("mydata", FileMode.Open));
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message + "\n Cannot open file.");
                return;
            }

            try
            {
                //binary olarak json formatinda okudu
                string json = br.ReadString();

                //deserialization yaptik ve ogrenci generic listesine ekledik.
                TumOgrencilerim = JsonConvert.DeserializeObject<Ogrencilerim>(json);

            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message + "\n Cannot read from file.");
                return;
            }
            br.Close();
        }

        internal void OgrenciBilgileriniOkuNesneyeAta()
        {
            BinaryReader br;

            //reading from the file
            //Ref : https://www.tutorialspoint.com/csharp/csharp_binary_files.htm
            try
            {
                br = new BinaryReader(new FileStream("mydata", FileMode.Open));
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message + "\n Cannot open file.");
                return;
            }

            try
            {
                //binary olarak json formatinda okudu
                string json = br.ReadString();

                string prettyJson = JToken.Parse(json).ToString(Formatting.Indented);

                //Verigetir() fonksiyonunda string dondurebilmek icin.
                Okunan = prettyJson;
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message + "\n Cannot read from file.");
                return;
            }
            br.Close();
        }

        internal override string VeriGetir()
        {
            return Okunan;
        }
    }
}
