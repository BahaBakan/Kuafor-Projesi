using System.ComponentModel.DataAnnotations;

namespace KuaforProjesi.Data{

public class Register{
    
    [Key]
    public int RegisterId {get; set;} 

    public string? Ad {get; set;}  
    public string? Eposta {get; set;}  
    public string? Sifre {get; set;}  

}



}
