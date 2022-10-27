using CentralDasOngs.Models;
using Microsoft.EntityFrameworkCore;

namespace CentralDasOngs.Data
{
    public class CentralDasOngsContext : DbContext
    {
        public CentralDasOngsContext(DbContextOptions<CentralDasOngsContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Relationship between User and Address 1:1
            builder.Entity<UserModel>()
                .HasOne(a => a.Address)
                .WithOne(u => u.User)
                .HasForeignKey<AddressModel>(u => u.UserId);

            //Relationship between Address and State account 1:N
            builder.Entity<AddressModel>()
                .HasOne(a => a.State)
                .WithMany(s => s.Address)
                .HasForeignKey(a => a.StateId);


            //Relationship between UserOng and bank account 1:N
            builder.Entity<UserOngModel>()
                .HasOne(a => a.BankAccount)
                .WithOne(u => u.UserOng)
                .HasForeignKey<BankAccountModel>(u => u.UserOngId);

            //Relationship between bank and bank account 1:N
            builder.Entity<BankAccountModel>()
                .HasOne(ba => ba.Bank)
                .WithMany(b => b.BankAccount)
                .HasForeignKey(ba => ba.BankId);

        }

        public DbSet<UserVoluntarioModel> UserVoluntarioModel { get; set; }
        public DbSet<AddressModel> AddressModel { get; set; }
        public DbSet<StateModel> StateModel { get; set; }
        public DbSet<UserOngModel> UserOngModel { get; set; }
        public DbSet<BankModel> BankModel { get; set; }
        public DbSet<BankAccountModel> BankAccount { get; set; }
    }
}
