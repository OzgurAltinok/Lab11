using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCLab
{
    class Ogrenci // Model
    {
        string isim;
        int no;
        int ort;
        int kayit;
        string bolum;

        public string Isim { get => isim; set => isim = value; }
        public int No { get => no; set => no = value; }
        public int Ort { get => ort; set => ort = value; }
        public int Kayit { get => kayit; set => kayit = value; }
        public string Bolum { get => bolum; set => bolum = value; }
    }
}
