using Demo.Todo.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Demo.Todo.Infrastructure.Persistence
{
    public class TodoDbContext : DbContext, ITodoDbContext
    {
        public DbSet<Domain.Todo> Todos => Set<Domain.Todo>();

        public TodoDbContext(DbContextOptions options) :base(options)
        {
            Database.EnsureCreated();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Domain.Todo>()
                .HasKey(t => t.Id);

            modelBuilder
                .Entity<Domain.Todo>()
                .Property(t => t.Id)
                .ValueGeneratedOnAdd();

            base.OnModelCreating(modelBuilder);
        }
    }
}
