using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KuaforProjesi.Data
{
    public class Randevu
    {
        [Key]
        public int RandevuId { get; set; }


        [ForeignKey("IslemId")]
        public Islem? Islem { get; set; } 

         [Required]
        public int IslemId { get; set; }

        // Müşteri bilgisi
        [Required]
        public string? MusteriAdi { get; set;}

        // Randevu tarihi
        [Required]
        public DateTime Tarih { get; set;}

        // Randevu saati
        [Required]
        public int Saat { get; set;} // TimeSpan kullanımı, saat formatını düzenler 
        
        public string? calisanAdi {get; set;} 

        public string? IslemAdi {get; set;}
    }
}
