
using KuaforProjesi.Data;

namespace KuaforProjesi.ViewModels
{
    public class RandevuViewModel
    {
        public IEnumerable<Calisanlarimiz> Calisanlar { get; set; }
        public IEnumerable<CalisanSaat> CalisanSaatleri { get; set; }
        public IEnumerable<Islem> Islemler { get; set; }
  
    public int CalisanId { get; set; }
        public int IslemId { get; set; }
        public DateTime Tarih { get; set; }
        public string Saat { get; set; }
  
   }
}