using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KuaforProjesi.Data
{
    public class Islem
    {
        [Key]
        public int IslemId { get; set; }

        [Required]
        public string? IslemAdi { get; set; } // Örn: Saç Kesimi, Boyama
        
        public int fiyati {get; set;}

        // Çalışan ile ilişki
          public List<IslemCalisan>? IslemCalisanlar { get; set; }
    }
}
