using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCLab
{
    internal static class VeriUretme // Factory Pattern
    {
        internal static string Get(int id, Ogrenci ogr, OgrenciGorunum ogrGor)
        {
            switch (id)
            {
                case 0:
                    return new OgrenciGorunum(ogrGor.TumOgrencilerim).VeriGetir();
                case 1:
                    return new OgrenciKontrolcusu(ogr, ogrGor, ogrGor.TumOgrencilerim).VeriGetir();
                default:
                    throw new BilinmeyenNesneException("!!Bilinmeyen uygulayici sinif kullaniliyor!!");
            }
        }
    }
}
