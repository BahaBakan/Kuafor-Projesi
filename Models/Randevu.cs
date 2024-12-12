using System.ComponentModel.DataAnnotations;

namespace efcoreApp.Models
{
    public class Randevu
    {
        [Key]
        public int RandevuId { get; set; }

        [Required]
        public int MusteriId { get; set; }
        public Musteri Musteri { get; set; }

        [Required]
        public int CalisanId { get; set; }
        public Calisan Calisan { get; set; }

        [Required]
        public DateTime Tarih { get; set; }

        [Required]
        public int IslemId { get; set; }
        public Islem Islem { get; set; }
    }
}
