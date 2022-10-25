using System;
using CentralOngs.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;
using System.Reflection.Metadata;

namespace CentralOngs
{
    public class DatabaseContext : DbContext
    {
        public DbSet<UserVoluntarioModel> UserVoluntarioModel { get; set; }
        public DbSet<AddressModel> AdressModel { get; set; }
        public DbSet<StateModel> StateModel { get; set; }
        public DbSet<UserOngModel> UserOngModel { get; set; }
        public DbSet<BankModel> BankModel { get; set; }
        public DbSet<OngBankInformationModel> OngBankInformationModel { get; set; }
    }
}