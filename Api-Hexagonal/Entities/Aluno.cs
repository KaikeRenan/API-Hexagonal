using System.Text.Json.Serialization;

namespace Api_Hexagonal.Entities
{
    public class Aluno : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Guid? CursoId { get; set; }

        [JsonIgnore]
        public Curso? Curso { get; set; }
    }
}
