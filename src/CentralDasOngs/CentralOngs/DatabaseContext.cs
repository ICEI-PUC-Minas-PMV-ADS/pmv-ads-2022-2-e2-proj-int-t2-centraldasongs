using System;
using CentralOngs.Models;
using Microsoft.EntityFrameworkCore;

namespace CentralOngs
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<UserVoluntarioModel> UserVoluntarioModel { get; set; }
        public DbSet<AddressModel> AdressModel { get; set; }
        public DbSet<StateModel> StateModel { get; set; }
        public DbSet<UserOngModel> UserOngModel { get; set; }
        public DbSet<BankModel> BankModel { get; set; }
        public DbSet<OngBankInformationModel> OngBankInformationModel { get; set; }
    }
}

