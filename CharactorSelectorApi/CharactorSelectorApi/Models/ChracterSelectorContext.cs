using CharactorSelectorApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CharactorSelectorApi.Models
{
    public class ChracterSelectorContext : DbContext
    {
        public ChracterSelectorContext(DbContextOptions<ChracterSelectorContext> options)
            : base(options)
        {
        }
        
        public virtual DbSet<Character> Characters { get; set; }
        public virtual DbSet<Option> Options { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Character>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Option>()
                .HasKey(o => o.Id);
            
            modelBuilder.Entity<Option>()
                .HasOne(o => o.Character)
                .WithMany()
                .HasForeignKey(o => o.CharacterId);
            
            base.OnModelCreating(modelBuilder);
        }
    }
}