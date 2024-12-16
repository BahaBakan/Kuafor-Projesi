using System.ComponentModel.DataAnnotations;
namespace KuaforProjesi.Data
{
    public class Randevu
    {
         [Key]
        public int RandevuId { get; set; }
        
        // Kullanıcı bilgileri, giriş yapmış kullanıcıdan alınacak
        public string? KullaniciId { get; set; }  // User ID

        public string? Islem { get; set; }  // Yüz bakımı, saç kesimi vb.
        public int CalisanId { get; set; }  // Çalışan seçimi
        public DateTime Tarih { get; set; }
        public TimeSpan Saat { get; set; }  // Çalışanın seçilen saati
    }
}