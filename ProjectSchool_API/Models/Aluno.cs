namespace ProjectSchool_API.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string DataNasc { get; set; }
        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }
    }
}