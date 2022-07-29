﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class RentalDBContext : DbContext

    {
        public virtual DbSet<Device> Devices { get; set; }
        public virtual DbSet<Contract> Contracts { get; set; }
        public virtual DbSet<ContractDevice> Contract_Device_Relations { get; set; }
        public virtual DbSet<History> History { get; set; }

        public RentalDBContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database\Database.mdf;Integrated Security=True;MultipleActiveResultSets=True";
                builder.UseLazyLoadingProxies().UseSqlServer(conn);
            }
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {

            //Connection between Device and Contracts with a connection table
            mb.Entity<ContractDevice>().HasKey(pt => new { pt.DeviceId, pt.ContractId });
            mb.Entity<ContractDevice>().HasOne(y => y.Device).WithMany(y => y.Contract_Device_Relations).HasForeignKey(y => y.DeviceId).OnDelete(DeleteBehavior.Cascade);//Restrict volt
            mb.Entity<ContractDevice>().HasOne(x => x.Contract).WithMany(x => x.Contract_Device_Relations).HasForeignKey(x => x.ContractId).OnDelete(DeleteBehavior.Cascade);



            Contract c1 = new Contract() { 
                Id=1, Name="Contract1", 
                Startdate=DateTime.Now, 
                Enddate= new DateTime(2022, 12, 31, 23, 59, 59),
                Email="contract1@c1.com",
                Phone="15234356345",
                Address="test street 1"
            };
            Contract c2 = new Contract()
            {
                Id = 2,
                Name = "Contract2",
                Startdate = DateTime.Now,
                Enddate = new DateTime(2022, 12, 31, 23, 59, 59),
                Email = "contract2@c2.com",
                Phone = "152343563222",
                Address = "test street 2"
            };
            Device n1 = new Device() { Id = 1, Name = "Device Test1", Price=50, State="Available", Date= new DateTime(2021,11,20)};
            Device n2 = new Device() { Id = 2, Name = "Device Test2", Price = 100, State = "Rented", Date = new DateTime(2022, 03, 13) };
            History h1 = new History() { Id=1, Executor=1, Date= new DateTime(2022, 12, 31, 23, 59, 59) , Type="Create"};
            ContractDevice cd1 = new() { Id = 1, ContractId = 1, DeviceId = 1 };
            ContractDevice cd2 = new() { Id = 2, ContractId = 2, DeviceId = 2 };
            mb.Entity<Contract>().HasData(c1, c2);
            mb.Entity<Device>().HasData(n1, n2);
            mb.Entity<History>().HasData(h1);
            mb.Entity<ContractDevice>().HasData(cd1,cd2);
            
        }
    }
}
