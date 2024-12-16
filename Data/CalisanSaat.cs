using System.ComponentModel.DataAnnotations;
namespace KuaforProjesi.Data
{
    public class CalisanSaat
    {
        [Key]
        public int CalisanSaatId { get; set; }

        public int CalisanId { get; set; }
        public Calisanlarimiz? Calisanlarimiz { get; set; }

        public TimeSpan Saat { get; set; }  // Çalışanın çalışma saati
    }
}