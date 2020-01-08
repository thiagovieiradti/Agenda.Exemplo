namespace Agenda.Exemplo.Dominio.DTO
{
    public class ContatoDTO
    {
        public int contatoId { get; set; }
        public string nome { get; set; }
        public GrupoDTO grupo { get; set; }
        public int telefone { get; set; }
    }
}
