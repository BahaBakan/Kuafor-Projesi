using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KuaforProjesi.Data
{
    public class Islem
    {
        [Key]
        public int IslemId { get; set; }
        
        [Required]
        public string? IslemAdi { get; set; }

        // Çalışan ile ilişkilendiriyoruz
        public int CalisanId { get; set; }
        
        [ForeignKey("CalisanId")]
        public Calisanlarimiz? Calisanlarimiz { get; set; }  // Çalışan tablosuyla ilişki
    }
}