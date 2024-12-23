using System.ComponentModel.DataAnnotations;

namespace KuaforProjesi.Data
{
    public class Calisanlarimiz
    {
        [Key]
        public int CalisanId { get; set; }
        
        [Required]
        public string? Ad { get; set; }

        [Required]
        public string? Soyad { get; set; }

        public string? UzmanlikAlani { get; set; } // Çalışanın uzmanlık alanı

        // Çalışma saat aralığı

        public string? calismaSaati {get; set;}

        // Çalışanın yapabildiği işlemler 

        public List<Randevu>? randevular {get; set;} 
           public List<IslemCalisan>? IslemCalisanlar { get; set; }
    }
}
