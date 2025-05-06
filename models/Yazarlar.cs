namespace Kutuphane.Models
{
    public struct Yazarlar
    {
        public int? YazarID { get; set; }
        public string? Ad { get; set; }
        public string? Soyad { get; set; }
        public Yazarlar(int yid, string yazar_ad, string yazar_soyad)
        {
            YazarID = yid;
            Ad = yazar_ad;
            Soyad = yazar_soyad;
            
        } 
    }
}