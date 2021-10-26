namespace KantinX.Model
{
    public class URUN
    {
        public int ID { get; set; }
        public int KATEGORI_ID { get; set; }
        public string BARKOD_NO { get; set; }
        public string URUN_ADI { get; set; }
        public decimal BIRIM_FIYATI { get; set; }

        public int STOK { get; set; }
    }
}
