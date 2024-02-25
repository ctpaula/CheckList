using CheckList.Domain;
using Microsoft.EntityFrameworkCore;

namespace Checklist.Infra
{
    public class RDbContext : DbContext
    {
        public RDbContext(DbContextOptions<RDbContext> options)
        : base(options) { }

        public DbSet<Usuario> Usuario{ get; set; }
        public DbSet<Pergunta> Pergunta { get; set; }
        public DbSet<CheckListBody> CheckListBody { get; set; }
        public DbSet<CheckListItem> CheckListItem { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            base.OnModelCreating(modelBuilder);
        }
    }
}