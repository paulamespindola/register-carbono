namespace register_caborno.Models.Dtos
{
    public class ActivityDto
    {
        public string Descricao { get; set; }
        public double EmissoesCO2 { get; set; }
        public DateTime DataRegistro { get; set; }
        public bool EhReducao { get; set; }
        public int UserId { get; set; }
    }
}
