using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EMS.Models;

namespace EMS.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext (DbContextOptions<SchoolContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Owner>()
                .HasOne(o => o.Constituent)
                .WithMany(c => c.Owners)
                .HasForeignKey(o => o.ConstituentId);

            //Defining specialization of element
            modelBuilder.Entity<Element>()
                .HasDiscriminator<string>("ElementType")
                .HasValue<GeneratingUnit>("GeneratingUnit")
                .HasValue<Transformer>("Transformer")
                .HasValue<SubFilterBank>("SubFilterBank")
                .HasValue<FilterBank>("FilterBank")
                .HasValue<Bay>("Bay")
                .HasValue<Compensator>("Compensator")
                //.HasValue<FSC>("FSC")
                //.HasValue<HVDCPole>("HVDCPole")
                .HasValue<Bus>("Bus")
                .HasValue<BusReactor>("BusReactor");
                //.HasValue<SVC>("SVC")
                //.HasValue<HVDCLine>("HVDCLine")
                //.HasValue<LineReactor>("LineReactor")
                //.HasValue<ACTransmissionLine>("ACTransmissionLine");
                
            modelBuilder.Entity<GeneratingUnit>()
                .HasOne(g => g.Voltage) // Navigation property to Voltage
                .WithMany() 
                .HasForeignKey(g => g.VoltageId); // Foreign key property

            modelBuilder.Entity<GeneratingUnit>()
                .HasOne(g => g.GeneratingTransformerHVVoltage) // Navigation property to Voltage
                .WithMany() // Since Voltage has no navigation property back to GeneratingUnit
                .HasForeignKey(g => g.GeneratingTransformerHVVoltageId);


            modelBuilder.Entity<Element>()
                .HasOne(e => e.Substation1)       // Each user has one manager
                .WithMany()                   // A manager can have many subordinates
                .HasForeignKey(e => e.Substation1Id); // Foreign key to represent the manager
            
            modelBuilder.Entity<Element>()
                .HasOne(e => e.Substation2)       // Each user has one manager
                .WithMany()                   // A manager can have many subordinates
                .HasForeignKey(e => e.Substation2Id); // Foreign key to represent the manager


            modelBuilder.Entity<Transformer>()
                .HasOne(t => t.Voltage1) // Navigation property to Voltage
                .WithMany() // Since Voltage has no navigation property back to GeneratingUnit
                .HasForeignKey(t => t.Voltage1Id);

            modelBuilder.Entity<Transformer>()
                .HasOne(t => t.Voltage2) // Navigation property to Voltage
                .WithMany() // Since Voltage has no navigation property back to GeneratingUnit
                .HasForeignKey(t => t.Voltage2Id);
            
            modelBuilder.Entity<Bay>()
                .HasOne(b => b.ConnectingElement1)       // Each user has one manager
                .WithMany()                   // A manager can have many subordinates
                .HasForeignKey(b => b.ConnectingElement1Id) // Foreign key to represent the manager
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            modelBuilder.Entity<Bay>()
                .HasOne(b => b.ConnectingElement2)       // Each user has one manager
                .WithMany()                   // A manager can have many subordinates
                .HasForeignKey(b => b.ConnectingElement2Id) // Foreign key to represent the manager
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete
        }

        public DbSet<EMS.Models.Bay> Bays { get; set; } = default!;

        public DbSet<EMS.Models.Bus> Bus { get; set; }

        public DbSet<EMS.Models.BusReactor> BusReactor { get; set; }

        public DbSet<EMS.Models.Compensator> Compensator { get; set; }

        public DbSet<EMS.Models.Constituent> Constituent { get; set; }

        public DbSet<EMS.Models.FilterBank> FilterBank { get; set; }

        public DbSet<EMS.Models.Fuel> Fuel { get; set; }

        public DbSet<EMS.Models.GeneratingStationClassification> GeneratingStationClassification { get; set; }

        public DbSet<EMS.Models.GeneratingStation> GeneratingStation { get; set; }

        public DbSet<EMS.Models.GeneratingStationType> GeneratingStationType { get; set; }

        public DbSet<EMS.Models.GeneratingUnit> GeneratingUnit { get; set; }

        public DbSet<EMS.Models.Location> Location { get; set; }

        public DbSet<EMS.Models.Owner> Owner { get; set; }

        public DbSet<EMS.Models.Region> Region { get; set; }

        public DbSet<EMS.Models.State> State { get; set; }

        public DbSet<EMS.Models.SubFilterBank> SubFilterBank { get; set; }

        public DbSet<EMS.Models.Substation> Substation { get; set; }

        public DbSet<EMS.Models.Transformer> Transformer { get; set; }

        public DbSet<EMS.Models.Voltage> Voltage { get; set; }
    }
}
