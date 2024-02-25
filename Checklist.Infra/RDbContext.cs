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

    }
}