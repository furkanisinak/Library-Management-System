namespace Kutuphane.Models
{
    public struct Uyeler
    {
        public int? UyeID { get; set; }
        public string? Uye_Ad { get; set; }
        public string? Uye_Soyad { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public Uyeler(int uid, string uye_ad, string uye_soyad, string email, string phone)
        {
            UyeID = uid;
            Uye_Ad = uye_ad;
            Uye_Soyad = uye_soyad;
            Email = email;
            Phone = phone;
            
        } 
    }
}