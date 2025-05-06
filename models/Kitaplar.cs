
namespace Kutuphane.Models
{
    public struct Kitaplar
    {
        public int? Kitap_ID { get; set; }
        public string? Baslik { get; set; }
        public DateTime? Yayin_Yili { get; set; }
        public string? ISBN { get; set; }
        public int? YazarID { get; set; }

    
    public Kitaplar(int kid, string baslik, DateTime? yayin_yili, string isbn, int yid)
        {
            Kitap_ID = kid;
            Baslik = baslik;
            Yayin_Yili = yayin_yili;
            ISBN = isbn;
            YazarID = yid;
            
        }
    } 
}