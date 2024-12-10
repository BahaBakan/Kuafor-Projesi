using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace efcoreApp.Data
{
    public class Musteri
    {
        [Key]
        public int MusteriId { get; set; }

        [Required]
        public string Ad { get; set; }

        [Required]
        public string Soyad { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string SifreHash { get; set; }

        // Müşterinin randevuları
        public List<Randevu> Randevular { get; set; }
    }
}