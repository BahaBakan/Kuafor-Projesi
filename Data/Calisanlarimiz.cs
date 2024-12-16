using System.ComponentModel.DataAnnotations;
namespace KuaforProjesi.Data
{
    public class Calisanlarimiz
    {
        [Key]
        public int CalisanId { get; set; }
        
        public string? Ad { get; set; }
        public string? Soyad { get; set; }
        public string? UzmanlikAlani { get; set; } // Örneğin, "Kuaför", "Saç Stilisti" gibi

        // Çalışanın mevcut saat dilimlerini gösterebilmek için bir liste
        public List<CalisanSaat>? CalisanSaatleri { get; set; } 
          public List<Islem>? Islemler { get; set; }
    }
}