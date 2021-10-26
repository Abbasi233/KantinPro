using System;
namespace KantinX.Model
{
    class ISLEM
    {
        public int ID { get; set; }
        public int ISLEM_YAPAN_ID { get; set; }
        public int OGRENCI_ID { get; set; }
        public int URUN_ID { get; set; }
        public int ADET { get; set; }
        public decimal TOPLAM { get; set; }
        public DateTime ISLEM_TARIHI { get; set; }
        public string ISLEM_TURU { get; set; }
    }
}
