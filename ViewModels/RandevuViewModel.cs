
using KuaforProjesi.Data;

namespace KuaforProjesi.ViewModels
{
    public class RandevuViewModel
    {
        public IEnumerable<Calisanlarimiz>? Calisanlar { get; set; }

        public IEnumerable<Islem>? Islemler { get; set; }
  
        public string? calisanAdi { get; set; }
        public string? IslemAdi { get; set; }
        public DateTime Tarih { get; set; }
        public int Saat { get; set; } 
        public int? IslemId { get; set; } 

        public int? CalisanId { get; set; }
  
   }
}