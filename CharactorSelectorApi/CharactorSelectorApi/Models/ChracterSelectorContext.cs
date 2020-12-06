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
        public virtual DbSet<CustomiseCharacter> Customises { get; set; }
        public virtual DbSet<CustomiseOption> CustomiseOptions { get; set; }
        public virtual DbSet<Option> Options { get; set; }
        public virtual DbSet<User> Users { get; set; }

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

            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<CustomiseCharacter>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<CustomiseOption>()
                .HasKey(u => new {u.CustomiseId, u.OptionId});

            base.OnModelCreating(modelBuilder);
        }
    }
}