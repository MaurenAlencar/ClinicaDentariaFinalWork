using ClinicaDentariaFinalWork.Models;
using ClinicaDentariaFinalWork.Models.PositionViewModels;
using ClinicaDentariaFinalWork.Models.SpecialtyViewModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ClinicaDentariaFinalWork.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Invoice>()
                .HasOne(i => i.Client)
                .WithMany(c => c.Invoices)
                .HasForeignKey(i => i.ClientID)
                .OnDelete(DeleteBehavior.Restrict);


        }


        public DbSet<ProfessionalTeam> ProfessionalTeams { get; set; } = default!;
        public DbSet<Client> Clients { get; set; } = default!;

        public DbSet<Appointment> Appointments { get; set; } = default!;

        public DbSet<Invoice> Invoices { get; set; } = default!;

        public DbSet<Position> Positions { get; set; } = default!;

        public DbSet<Specialty> Specialties { get; set; } = default!;


    }
}