using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCLab
{
    class Ogrencilerim
    {
        List<Ogrenci> ogrencis = new List<Ogrenci>();

        public List<Ogrenci> Ogrencis { get => ogrencis; set => ogrencis = value; }
    }
}
