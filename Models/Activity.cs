using register_caborno.Models;

public class Activity
{
    public int Id { get; set; }
    public string Descricao { get; set; }
    public string Categoria { get; set; } 
    public double EmissoesCO2 { get; set; } 
    public DateTime DataRegistro { get; set; }
    public bool EhReducao { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
}
