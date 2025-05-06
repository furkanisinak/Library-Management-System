using Kutuphane;
using Kutuphane.Services;
using Kutuphane.Models;

namespace Kutuphane;

class Program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\n=== KÜTÜPHANE MENÜ ===");
            Console.WriteLine("1 - Yazar Ekle");
            Console.WriteLine("2 - Yazar Listele");
            Console.WriteLine("3 - Yazar Sil");
            Console.WriteLine("-----------------------");
            Console.WriteLine("4 - Kitap Ekle");
            Console.WriteLine("5 - Kitap Listele");
            Console.WriteLine("6 - Kitap Sil");
            Console.WriteLine("-----------------------");
            Console.WriteLine("7 - Üye Ekle");
            Console.WriteLine("8 - Üye Listele");
            Console.WriteLine("9 - Üye Sil");
            Console.WriteLine("10 - Üye Güncelle");
            Console.WriteLine("-----------------------");
            Console.WriteLine("11 - Ödünç Ekle");
            Console.WriteLine("12 - Ödünç Sil");
            Console.WriteLine("0 - Çıkış");
            Console.Write("Seçiminiz: ");
            string secim = Console.ReadLine() ?? ""; // Null kontrolü ekledik

            switch (secim)
            {
                case "1":
                    // Yazar Ekle
                    Console.Write("Yazar adı: ");
                    string yazarAd = Console.ReadLine() ?? ""; // Null kontrolü ekledik
                    Console.Write("Yazar soyadı: ");
                    string yazarSoyad = Console.ReadLine() ?? ""; // Null kontrolü ekledik
                    YazarService yazarService1 = new YazarService();
                    Yazarlar yazar = new Yazarlar(0, yazarAd, yazarSoyad);
                    int resultYazar = yazarService1.AddYazar(yazar);
                    Console.WriteLine(resultYazar > 0 ? "Yazar başarıyla eklendi." : "Yazar eklenemedi.");
                    break;

                case "2":
                    // Yazar Listele
                    Console.WriteLine("----------Tüm Yazarlar----------");
                    YazarService yazarService2 = new YazarService();
                    List<Yazarlar> yazarlar = yazarService2.GetAllYazar();
                    foreach (var item in yazarlar)
                    {
                        Console.WriteLine(item.YazarID + " " + item.Ad + " " + item.Soyad);
                    }
                    Console.WriteLine("---------------------------------");
                    break;

                case "3":
                    // Yazar Sil
                    Console.Write("Silinecek Yazar ID: ");
                    int silinecekYazarId = Convert.ToInt32(Console.ReadLine());
                    YazarService yazarService3 = new YazarService();
                    int resultDeleteYazar = yazarService3.DeletedYazar(silinecekYazarId);
                    Console.WriteLine(resultDeleteYazar > 0 ? "Yazar silindi." : "Yazar silinemedi.");
                    break;

                case "4":
                    // Kitap Ekle
                    Console.Write("Kitap başlığı: ");
                    string kitapBaslik = Console.ReadLine() ?? ""; // Null kontrolü ekledik
                    Console.Write("Kitap ISBN: ");
                    string kitapIsbn = Console.ReadLine() ?? ""; // Null kontrolü ekledik
                    Console.Write("Yazar ID: ");
                    int kitapYazarId = Convert.ToInt32(Console.ReadLine());
                    KitapService kitapService1 = new KitapService();
                    Kitaplar kitap = new Kitaplar(0, kitapBaslik, DateTime.Now, kitapIsbn, kitapYazarId);
                    int resultKitap = kitapService1.AddKitap(kitap);
                    Console.WriteLine(resultKitap > 0 ? "Kitap başarıyla eklendi." : "Kitap eklenemedi.");
                    break;

                case "5":
                    // Kitap Listele
                    Console.WriteLine("----------Tüm Kitaplar----------");
                    KitapService kitapService2 = new KitapService();
                    List<Kitaplar> kitaplar = kitapService2.GetAllKitap();
                    foreach (var item in kitaplar)
                    {
                        Console.WriteLine(item.Kitap_ID + " " + item.Baslik + " " + item.ISBN + " " + item.Yayin_Yili + " " + item.YazarID);
                    }
                    Console.WriteLine("---------------------------------");
                    break;

                case "6":
                    // Kitap Sil
                    Console.Write("Silinecek Kitap ID: ");
                    int silinecekKitapId = Convert.ToInt32(Console.ReadLine());
                    KitapService kitapService3 = new KitapService();
                    int resultDeleteKitap = kitapService3.DeletedKitap(silinecekKitapId);
                    Console.WriteLine(resultDeleteKitap > 0 ? "Kitap silindi." : "Kitap silinemedi.");
                    break;

                case "7":
                    // Üye Ekle
                    Console.Write("Üye adı: ");
                    string uyeAd = Console.ReadLine() ?? ""; // Null kontrolü ekledik
                    Console.Write("Üye soyadı: ");
                    string uyeSoyad = Console.ReadLine() ?? ""; // Null kontrolü ekledik
                    Console.Write("Üye e-posta: ");
                    string uyeEmail = Console.ReadLine() ?? ""; // Null kontrolü ekledik
                    Console.Write("Üye telefon: ");
                    string uyeTelefon = Console.ReadLine() ?? ""; // Null kontrolü ekledik
                    UyelerService uyelerService1 = new UyelerService();
                    Uyeler uyeEkle = new Uyeler(0, uyeAd, uyeSoyad, uyeEmail, uyeTelefon);
                    int resultUyeEkle = uyelerService1.AddUye(uyeEkle);
                    Console.WriteLine(resultUyeEkle > 0 ? "Üye başarıyla eklendi." : "Üye eklenemedi.");
                    break;

                case "8":
                    // Üye Listele
                    Console.WriteLine("----------Tüm Üyeler----------");
                    UyelerService uyelerService2 = new UyelerService();
                    List<Uyeler> uyeler = uyelerService2.GetAllUye();
                    foreach (var item in uyeler)
                    {
                        Console.WriteLine(item.UyeID + " " + item.Uye_Ad + " " + item.Uye_Soyad + " " + item.Email + " " + item.Phone);
                    }
                    Console.WriteLine("---------------------------------");
                    break;

                case "9":
                    // Üye Sil
                    Console.Write("Silinecek Üye ID: ");
                    int silinecekUyeId = Convert.ToInt32(Console.ReadLine());
                    UyelerService uyelerService3 = new UyelerService();
                    int resultDeleteUye = uyelerService3.DeletedUye(silinecekUyeId);
                    Console.WriteLine(resultDeleteUye > 0 ? "Üye silindi." : "Üye silinemedi.");
                    break;

                case "10":
                    // Üye Güncelle
                    Console.Write("Güncellenecek Üye ID: ");
                    int guncelleUyeId = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Yeni Üye adı: ");
                    string guncelleUyeAd = Console.ReadLine() ?? ""; // Null kontrolü ekledik
                    Console.Write("Yeni Üye soyadı: ");
                    string guncelleUyeSoyad = Console.ReadLine() ?? ""; // Null kontrolü ekledik
                    Console.Write("Yeni Üye e-posta: ");
                    string guncelleUyeEmail = Console.ReadLine() ?? ""; // Null kontrolü ekledik
                    Console.Write("Yeni Üye telefon: ");
                    string guncelleUyeTelefon = Console.ReadLine() ?? ""; // Null kontrolü ekledik
                    UyelerService uyelerService4 = new UyelerService();
                    Uyeler uyeGuncelle = new Uyeler(guncelleUyeId, guncelleUyeAd, guncelleUyeSoyad, guncelleUyeEmail, guncelleUyeTelefon);
                    int resultGuncelle = uyelerService4.UpdateUye(uyeGuncelle);
                    Console.WriteLine(resultGuncelle > 0 ? "Üye başarıyla güncellendi." : "Üye güncellenemedi.");
                    break;

                case "11":
                    // Ödünç Ekle
                    Console.Write("Üye ID: ");
                    int oduncUyeId = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Kitap ID: ");
                    int oduncKitapId = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Ödünç alma tarihi: ");
                    DateTime oduncTarihi = DateTime.Parse(Console.ReadLine() ?? DateTime.Now.ToString());
                    Console.Write("Ödünç teslim tarihi: ");
                    DateTime oduncTeslimTarihi = DateTime.Parse(Console.ReadLine() ?? DateTime.Now.ToString());
                    OduncService oduncService1 = new OduncService();
                    Oduncler odunc = new Oduncler(0, oduncUyeId, oduncKitapId, oduncTarihi, oduncTeslimTarihi);
                    int resultOdunc = oduncService1.AddOdunc(odunc);
                    Console.WriteLine(resultOdunc > 0 ? "Ödünç başarıyla eklendi." : "Ödünç eklenemedi.");
                    break;

                case "12":
                    // Ödünç Sil
                    Console.Write("Silinecek Ödünç ID: ");
                    int silinecekOduncId = Convert.ToInt32(Console.ReadLine());
                    OduncService oduncService2 = new OduncService();
                    int resultDeleteOdunc = oduncService2.DeletedOdunc(silinecekOduncId);
                    Console.WriteLine(resultDeleteOdunc > 0 ? "Ödünç silindi." : "Ödünç silinemedi.");
                    break;

                case "0":
                    // Çıkış
                    Console.WriteLine("Programdan çıkılıyor...");
                    return;

                default:
                    Console.WriteLine("Geçersiz bir seçim yaptınız.");
                    break;
            }
        }
    }
}
