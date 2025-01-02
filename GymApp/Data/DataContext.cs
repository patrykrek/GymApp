using GymApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GymApp.Data
{
    public class DataContext : IdentityDbContext<IdentityUser>
    {
        public DataContext(DbContextOptions<DataContext> opt) : base(opt) { }
        
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<UserMembership> UserMemberships { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Reservation>(eb =>
            {
                eb.HasOne(r => r.Training)
                .WithMany(t => t.Reservations)
                .HasForeignKey(r => r.TrainingId);

                eb.HasOne(r => r.User)
                .WithMany(u => u.Reservations)
                .HasForeignKey(r => r.userId);
            });

            builder.Entity<Training>(eb =>
            {
                eb.HasOne(t => t.Trainer)
                .WithMany(tr => tr.Trainings)
                .HasForeignKey(t => t.TrainerId);
            });

            builder.Entity<Membership>(eb =>
            {
                eb.HasMany(m => m.UserMemberships)
                .WithOne(um => um.Membership)
                .HasForeignKey(um => um.MembershipId);

                eb.Property(x => x.PricePerMonth).HasColumnType("decimal(10,2)");


            });

            builder.Entity<UserMembership>(eb =>
            {
                eb.HasOne(um => um.User)
                .WithMany(u => u.UserMemberships)
                .HasForeignKey(um => um.userId);
            });
        }




    }
}
