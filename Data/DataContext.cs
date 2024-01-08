using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using EMS.Models;

namespace EMS.Data
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration? Configuration;
        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(Configuration?.GetConnectionString("Supabase"));
        }

        public bool IsCombinationUnique<T>(Func<T, bool> predicate) where T : class
        {
            var queryable = Set<T>(); // Assuming `Set<T>` is available in your DbContext

            return !queryable.Any(predicate);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Element Foreign Keys
            modelBuilder.Entity<Bay>()
                .HasOne(e => e.Element)
                .WithMany()
                .HasForeignKey(e => e.ElementId);

            modelBuilder.Entity<Bus>()
                .HasOne(e => e.Element)
                .WithMany()
                .HasForeignKey(e => e.ElementId);

            modelBuilder.Entity<BusReactor>()
                .HasOne(e => e.Element)
                .WithMany()
                .HasForeignKey(e => e.ElementId);

            modelBuilder.Entity<BusReactor>()
                .HasOne(e => e.Bus)
                .WithMany()
                .HasForeignKey(e => e.BusId);

            modelBuilder.Entity<Compensator>()
                .HasOne(e => e.Element)
                .WithMany()
                .HasForeignKey(e => e.ElementId);

            modelBuilder.Entity<FilterBank>()
                .HasOne(e => e.Element)
                .WithMany()
                .HasForeignKey(e => e.ElementId);

            modelBuilder.Entity<FilterBank>()
                .HasOne(e => e.Voltage)
                .WithMany()
                .HasForeignKey(e => e.VoltageId);

            modelBuilder.Entity<FSC>()
                .HasOne(e => e.Element)
                .WithMany()
                .HasForeignKey(e => e.ElementId);

            modelBuilder.Entity<HVDCPole>()
                .HasOne(e => e.Element)
                .WithMany()
                .HasForeignKey(e => e.ElementId);

            modelBuilder.Entity<HVDCPole>()
                .HasOne(e => e.Voltage)
                .WithMany()
                .HasForeignKey(e => e.VoltageId);

            modelBuilder.Entity<Line>()
                .HasOne(e => e.Element)
                .WithMany()
                .HasForeignKey(e => e.ElementId);

            modelBuilder.Entity<Line>()
                .HasOne(e => e.FromBus)
                .WithMany()
                .HasForeignKey(e => e.FromBusId);

            modelBuilder.Entity<Line>()
                .HasOne(e => e.ToBus)
                .WithMany()
                .HasForeignKey(e => e.ToBusId);

            modelBuilder.Entity<Line>()
                .HasOne(e => e.Voltage)
                .WithMany()
                .HasForeignKey(e => e.VoltageId);

            modelBuilder.Entity<Line>()
                .HasIndex(b => new { b.FromBusId, b.ToBusId, b.CircuitNumber }).IsUnique();

            modelBuilder.Entity<LineReactor>()
                .HasOne(e => e.Element)
                .WithMany()
                .HasForeignKey(e => e.ElementId);

            

            modelBuilder.Entity<LineReactor>()
                .HasOne(e => e.Line)
                .WithMany()
                .HasForeignKey(e => e.LineId);

            modelBuilder.Entity<SubFilterBank>()
                .HasOne(e => e.Element)
                .WithMany()
                .HasForeignKey(e => e.ElementId);

            modelBuilder.Entity<SubFilterBank>()
                .HasOne(e => e.FilterBank)
                .WithMany()
                .HasForeignKey(e => e.FilterBankId);

            modelBuilder.Entity<SVC>()
                .HasOne(e => e.Element)
                .WithMany()
                .HasForeignKey(e => e.ElementId);

            modelBuilder.Entity<SVC>()
                .HasOne(e => e.Bus)
                .WithMany()
                .HasForeignKey(e => e.BusId);

            modelBuilder.Entity<Transformer>()
                .HasOne(e => e.Element)
                .WithMany()
                .HasForeignKey(e => e.ElementId);

            // One-to-many: Constituent-Owner
            modelBuilder.Entity<Owner>()
                .HasOne(o => o.Constituent)
                .WithMany(c => c.Owners)
                .HasForeignKey(o => o.ConstituentId);

            // Many-to-many: ElementOwner
            modelBuilder.Entity<ElementOwner>()
                .HasKey(eo => new { eo.ElementId, eo.OwnerId });

            modelBuilder.Entity<ElementOwner>()
                .HasOne(eo => eo.Element)
                .WithMany(e => e.ElementOwners)
                .HasForeignKey(eo => eo.ElementId);

            modelBuilder.Entity<ElementOwner>()
                .HasOne(eo => eo.Owner)
                .WithMany(o => o.ElementOwners)
                .HasForeignKey(eo => eo.OwnerId);

            // Many-to-many: OwnerSubstation
            modelBuilder.Entity<OwnerSubstation>()
                .HasKey(os => new { os.OwnerId, os.SubstationId });

            modelBuilder.Entity<OwnerSubstation>()
                .HasOne(os => os.Owner)
                .WithMany(o => o.OwnerSubstations)
                .HasForeignKey(os => os.OwnerId);

            modelBuilder.Entity<OwnerSubstation>()
                .HasOne(os => os.Substation)
                .WithMany(s => s.OwnerSubstations)
                .HasForeignKey(os => os.SubstationId);

            // Voltage-GeneratingUnit 
            modelBuilder.Entity<GeneratingUnit>()
                .HasOne(g => g.Voltage) // Navigation property to Voltage
                .WithMany()
                .HasForeignKey(g => g.VoltageId); // Foreign key property

            modelBuilder.Entity<GeneratingUnit>()
                .HasOne(g => g.GeneratingTransformerHVVoltage) // Navigation property to Voltage
                .WithMany() // Since Voltage has no navigation property back to GeneratingUnit
                .HasForeignKey(g => g.GeneratingTransformerHVVoltageId);

            modelBuilder.Entity<GeneratingUnit>()
                .HasOne(g => g.GeneratingStation)
                .WithMany()
                .HasForeignKey(g => g.GeneratingStationId);

            modelBuilder.Entity<GeneratingUnit>()
                .HasOne(g => g.Element)
                .WithMany()
                .HasForeignKey(g => g.ElementId);

            // Element-Substation
            modelBuilder.Entity<Element>()
                .HasOne(e => e.Substation1)
                .WithMany()
                .HasForeignKey(e => e.Substation1Id)
                .IsRequired(false);
            // Element-Substation
            modelBuilder.Entity<Element>()
                .HasOne(e => e.Substation2)
                .WithMany()
                .HasForeignKey(e => e.Substation2Id)
                .IsRequired(false);

            modelBuilder.Entity<Element>()
                .HasOne(e => e.Location)
                .WithMany()
                .HasForeignKey(e => e.LocationId)
                .IsRequired(false);
            modelBuilder.Entity<Transformer>()
                .HasOne(t => t.Voltage1)
                .WithMany()
                .HasForeignKey(t => t.Voltage1Id);

            modelBuilder.Entity<Transformer>()
                .HasOne(t => t.Voltage2)
                .WithMany()
                .HasForeignKey(t => t.Voltage2Id);

            modelBuilder.Entity<Bay>()
                .HasOne(b => b.ConnectingElement1)
                .WithMany()
                .HasForeignKey(b => b.ConnectingElement1Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Bay>()
                .HasOne(b => b.ConnectingElement2)
                .WithMany()
                .HasForeignKey(b => b.ConnectingElement2Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Bay>()
                .HasOne(b => b.Voltage)
                .WithMany()
                .HasForeignKey(b => b.VoltageId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<HVDCPole>()
                .HasOne(h => h.Voltage)
                .WithMany()
                .HasForeignKey(h => h.VoltageId);
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

        public DbSet<EMS.Models.HVDCPole> HVDCPole { get; set; } = default!;

        public DbSet<EMS.Models.LineReactor> LineReactor { get; set; } = default!;

        public DbSet<EMS.Models.FSC> FSC { get; set; } = default!;

        public DbSet<EMS.Models.SVC> SVC { get; set; } = default!;

        public DbSet<EMS.Models.Line> Line { get; set; } = default!;

        public DbSet<EMS.Models.Element> Element { get; set; } = default!;

        public DbSet<EMS.Models.ElementOwner> ElementOwner { get; set; } = default!;

        public DbSet<EMS.Models.OwnerSubstation> OwnerSubstation { get; set; } = default!;

        
    }
}
