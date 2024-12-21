using Microsoft.EntityFrameworkCore;

namespace KuaforProjesi.Data 
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {
            
        }
        public DbSet<Register> Registers =>Set<Register>();
    
        public DbSet<Randevu> Randevular =>Set<Randevu>();
        public DbSet<Islem> Islemler =>Set<Islem>();
       public DbSet<Calisanlarimiz> Calisanlarimiz =>Set<Calisanlarimiz>(); 
      
    }


}