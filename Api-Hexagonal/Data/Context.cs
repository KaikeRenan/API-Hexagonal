using Api_Hexagonal.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api_Hexagonal.Infrastructure.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options) { }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Curso> Cursos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Aluno>(entity =>
            {
                entity.HasKey(aluno => aluno.Id);

                entity.Property(aluno => aluno.FirstName).IsRequired().HasMaxLength(50);

                entity.Property(aluno => aluno.LastName).IsRequired();

                entity.Property(aluno => aluno.Email).IsRequired();

                entity.HasIndex(aluno => aluno.Email).IsUnique();

                entity.Property(aluno => aluno.Password).IsRequired();
            });

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.HasKey(curso => curso.Id);

                entity.Property(curso => curso.Name).IsRequired();

                entity.Property(curso => curso.Description).IsRequired();

                entity.HasMany(curso => curso.Alunos).WithOne(aluno => aluno.Curso).HasForeignKey(aluno => aluno.CursoId).OnDelete(DeleteBehavior.Restrict);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
