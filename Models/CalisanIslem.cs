namespace efcoreApp.Models
{
    public class CalisanIslem
    {
        public int CalisanId { get; set; }
        public Calisan Calisan { get; set; }

        public int IslemId { get; set; }
        public Islem Islem { get; set; }
    }
}
