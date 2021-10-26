namespace KantinX.Model
{
    public class UrunHesap
    {
        public int ID;
        public string Isim { get; set; }
        public decimal BirimFiyat { get; set; }
        public decimal ToplamFiyat { get; set; }
        public int Adet { get; set; }
        public UrunHesap(URUN urun, int adet)
        {
            ID = urun.ID;
            Isim = urun.URUN_ADI;
            BirimFiyat = urun.BIRIM_FIYATI;
            Adet = adet;
            ToplamFiyat = Adet * BirimFiyat;
        }
    }
}
