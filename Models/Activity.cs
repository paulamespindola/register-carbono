using register_caborno.Models;

public class Activity
{
    public int Id { get; set; }
    public string Descricao { get; set; }
    public float Emissao { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
}
