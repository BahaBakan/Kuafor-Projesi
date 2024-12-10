using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace efcoreApp.Data
{
    public class Islem
    {
        [Key]
        public int IslemId { get; set; }

        [Required]
        public string IslemAdi { get; set; }

        // İşlemi yapabilen çalışanlarla ilişki
        public List<CalisanIslem> CalisanIslemler { get; set; }
    }
}