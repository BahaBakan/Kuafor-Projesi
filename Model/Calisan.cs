using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace efcoreApp.Data
{
    public class Calisan
    {
        [Key]
        public int CalisanId { get; set; }

        [Required]
        public string CalisanAd { get; set; }

        [Required]
        public string CalisanSoyad { get; set; }

        // Çalışanın yapabildiği işlemler
        public List<CalisanIslem> CalisanIslemler { get; set; }
    }
}
