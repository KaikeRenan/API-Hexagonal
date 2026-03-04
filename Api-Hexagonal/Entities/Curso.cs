namespace Api_Hexagonal.Entities
{
    public class Curso : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Aluno> Alunos { get; set; } = new List<Aluno>();
    }
}
