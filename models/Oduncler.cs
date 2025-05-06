namespace Kutuphane.Models
{
    public struct Oduncler
    {
        public int OduncID { get; set; }
        public int UyeID { get; set; }
        public int Kitap_ID { get; set; }
        public DateTime OduncTarihi { get; set; }
        public DateTime? IadeTarihi { get; set; }

        public Oduncler()
        {
            OduncTarihi = DateTime.Now;
        }

        public Oduncler(int uid, int kid, int oid, DateTime? iade_tarih, DateTime odunc_tarih)
        {
            UyeID = uid;
            Kitap_ID = kid;
            OduncID = oid;
            OduncTarihi = odunc_tarih;
            IadeTarihi = iade_tarih;
        }
        
        
    }
}