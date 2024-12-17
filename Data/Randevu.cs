using System.ComponentModel.DataAnnotations;
namespace KuaforProjesi.Data
{
    public class Randevu
    {
         [Key]
        public int RandevuId { get; set; }

        // Çalışan ile ilişkilendirme
        public int CalisanId { get; set; }
        public Calisanlarimiz Calisan { get; set; } // İlgili çalışanın bilgileri

        // İşlem ile ilişkilendirme
        public int IslemId { get; set; }
        public Islem Islem { get; set; } // İlgili işlem bilgileri

        // Randevu tarihi ve saati
        public DateTime Tarih { get; set; }
       public String Saat { get; set; }  // Saat bilgisi
    }
}