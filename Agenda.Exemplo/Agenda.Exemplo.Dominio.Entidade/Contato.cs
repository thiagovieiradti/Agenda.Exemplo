namespace Agenda.Exemplo.Dominio.Entidade
{
    public class Contato
    {
        public int ContatoId { get; set; }
        public string Nome { get; set; }
        public Grupo Grupo { get; set; }
    }
}
