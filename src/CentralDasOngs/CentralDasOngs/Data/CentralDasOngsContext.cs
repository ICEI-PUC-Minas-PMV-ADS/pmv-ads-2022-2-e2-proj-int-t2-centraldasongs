﻿using CentralDasOngs.Models;
using Microsoft.EntityFrameworkCore;

namespace CentralDasOngs.Data
{
    public class CentralDasOngsContext : DbContext
    {
        public CentralDasOngsContext(DbContextOptions<CentralDasOngsContext> options) : base(options)
        {
        }

        public DbSet<UserVoluntarioModel> UserVoluntarioModel { get; set; }
        public DbSet<AdressModel> AdressModel { get; set; }
        public DbSet<StateModel> StateModel { get; set; }
        public DbSet<UserOngModel> UserOngModel { get; set; }
        public DbSet<BankModel> BankModel { get; set; }
        public DbSet<OngBankInformationModel> OngBankInformationModel { get; set; }
    }
}