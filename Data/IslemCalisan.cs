using System.ComponentModel.DataAnnotations;

namespace KuaforProjesi.Data
{
    public class IslemCalisan
    {
        [Key]
        public int Id { get; set; }

        public int IslemId { get; set; }
        public Islem? Islem { get; set; }

        public int CalisanId { get; set; }
        public Calisanlarimiz? Calisan { get; set; }
    }
}