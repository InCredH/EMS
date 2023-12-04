﻿// <auto-generated />
using System;
using EMS.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EMS.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231202102406_UpdatedSchema")]
    partial class UpdatedSchema
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.11");

            modelBuilder.Entity("EMS.Models.Constituent", b =>
                {
                    b.Property<int>("ConstituentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConstituentName")
                        .HasColumnType("TEXT");

                    b.HasKey("ConstituentId");

                    b.ToTable("Constituent");
                });

            modelBuilder.Entity("EMS.Models.Element", b =>
                {
                    b.Property<int>("ElementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CommissioningDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DecommissioningDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("ElementNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("ElementType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("RegionId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Substation1Id")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Substation2Id")
                        .HasColumnType("INTEGER");

                    b.HasKey("ElementId");

                    b.HasIndex("RegionId");

                    b.HasIndex("Substation1Id");

                    b.HasIndex("Substation2Id");

                    b.ToTable("Element");

                    b.HasDiscriminator<string>("ElementType").HasValue("Element");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("EMS.Models.Fuel", b =>
                {
                    b.Property<int>("FuelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FuelName")
                        .HasColumnType("TEXT");

                    b.HasKey("FuelId");

                    b.ToTable("Fuel");
                });

            modelBuilder.Entity("EMS.Models.GeneratingStation", b =>
                {
                    b.Property<int>("GeneratingStationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("FuelId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GeneratingStationClassificationId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("GeneratingStationName")
                        .HasColumnType("TEXT");

                    b.Property<int>("GeneratingStationTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("InstalledCapacity")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MVARCapacity")
                        .HasColumnType("INTEGER");

                    b.HasKey("GeneratingStationId");

                    b.HasIndex("FuelId");

                    b.HasIndex("GeneratingStationClassificationId");

                    b.HasIndex("GeneratingStationTypeId");

                    b.ToTable("GeneratingStation");
                });

            modelBuilder.Entity("EMS.Models.GeneratingStationClassification", b =>
                {
                    b.Property<int>("GeneratingStationClassificationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Classification")
                        .HasColumnType("TEXT");

                    b.HasKey("GeneratingStationClassificationId");

                    b.ToTable("GeneratingStationClassification");
                });

            modelBuilder.Entity("EMS.Models.GeneratingStationType", b =>
                {
                    b.Property<int>("GeneratingStationTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("StationType")
                        .HasColumnType("TEXT");

                    b.HasKey("GeneratingStationTypeId");

                    b.ToTable("GeneratingStationType");
                });

            modelBuilder.Entity("EMS.Models.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Alias")
                        .HasColumnType("TEXT");

                    b.Property<string>("LocationName")
                        .HasColumnType("TEXT");

                    b.Property<int>("RegionId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StateId")
                        .HasColumnType("INTEGER");

                    b.HasKey("LocationId");

                    b.HasIndex("RegionId");

                    b.HasIndex("StateId");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("EMS.Models.Owner", b =>
                {
                    b.Property<int>("OwnerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ConstituentId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("OwnerName")
                        .HasColumnType("TEXT");

                    b.HasKey("OwnerId");

                    b.HasIndex("ConstituentId");

                    b.ToTable("Owner");
                });

            modelBuilder.Entity("EMS.Models.OwnerElement", b =>
                {
                    b.Property<int>("OwnerElementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ElementId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OwnerId")
                        .HasColumnType("INTEGER");

                    b.HasKey("OwnerElementId");

                    b.HasIndex("ElementId");

                    b.HasIndex("OwnerId");

                    b.ToTable("OwnerElement");
                });

            modelBuilder.Entity("EMS.Models.OwnerSubstation", b =>
                {
                    b.Property<int>("OwnerSubstationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("OwnerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SubstationId")
                        .HasColumnType("INTEGER");

                    b.HasKey("OwnerSubstationId");

                    b.HasIndex("OwnerId");

                    b.HasIndex("SubstationId");

                    b.ToTable("OwnerSubstation");
                });

            modelBuilder.Entity("EMS.Models.Region", b =>
                {
                    b.Property<int>("RegionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("RegionName")
                        .HasColumnType("TEXT");

                    b.HasKey("RegionId");

                    b.ToTable("Region");
                });

            modelBuilder.Entity("EMS.Models.State", b =>
                {
                    b.Property<int>("StateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("StateName")
                        .HasColumnType("TEXT");

                    b.HasKey("StateId");

                    b.ToTable("State");
                });

            modelBuilder.Entity("EMS.Models.Substation", b =>
                {
                    b.Property<int>("SubstationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("LocationId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SubstationType")
                        .HasColumnType("TEXT");

                    b.Property<int>("VoltageId")
                        .HasColumnType("INTEGER");

                    b.HasKey("SubstationId");

                    b.HasIndex("LocationId");

                    b.HasIndex("VoltageId");

                    b.ToTable("Substation");
                });

            modelBuilder.Entity("EMS.Models.Voltage", b =>
                {
                    b.Property<int>("VoltageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("VoltageLevel")
                        .HasColumnType("INTEGER");

                    b.HasKey("VoltageId");

                    b.ToTable("Voltage");
                });

            modelBuilder.Entity("EMS.Models.Bay", b =>
                {
                    b.HasBaseType("EMS.Models.Element");

                    b.Property<string>("BayType")
                        .HasColumnType("TEXT");

                    b.Property<int>("ConnectingElement1Id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ConnectingElement2Id")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsFuture")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OwnerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("VoltageId")
                        .HasColumnType("INTEGER");

                    b.HasIndex("ConnectingElement1Id");

                    b.HasIndex("ConnectingElement2Id");

                    b.HasIndex("OwnerId");

                    b.HasIndex("VoltageId");

                    b.HasDiscriminator().HasValue("Bay");
                });

            modelBuilder.Entity("EMS.Models.Bus", b =>
                {
                    b.HasBaseType("EMS.Models.Element");

                    b.Property<string>("BusType")
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("Bus");
                });

            modelBuilder.Entity("EMS.Models.BusReactor", b =>
                {
                    b.HasBaseType("EMS.Models.Element");

                    b.Property<int>("MVARCapacity")
                        .HasColumnType("INTEGER");

                    b.HasDiscriminator().HasValue("BusReactor");
                });

            modelBuilder.Entity("EMS.Models.Compensator", b =>
                {
                    b.HasBaseType("EMS.Models.Element");

                    b.Property<int>("PercentageFixedCompensation")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PercentageVariableCompensation")
                        .HasColumnType("INTEGER");

                    b.HasDiscriminator().HasValue("Compensator");
                });

            modelBuilder.Entity("EMS.Models.FilterBank", b =>
                {
                    b.HasBaseType("EMS.Models.Element");

                    b.Property<bool>("IsSwitchable")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MVARCapacity")
                        .HasColumnType("INTEGER");

                    b.Property<int>("VoltageId")
                        .HasColumnType("INTEGER");

                    b.HasIndex("VoltageId");

                    b.ToTable("Element", t =>
                        {
                            t.Property("MVARCapacity")
                                .HasColumnName("FilterBank_MVARCapacity");

                            t.Property("VoltageId")
                                .HasColumnName("FilterBank_VoltageId");
                        });

                    b.HasDiscriminator().HasValue("FilterBank");
                });

            modelBuilder.Entity("EMS.Models.GeneratingUnit", b =>
                {
                    b.HasBaseType("EMS.Models.Element");

                    b.Property<int>("GeneratingStationId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GeneratingTransformerHVVoltageId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("InstalledCapacity")
                        .HasColumnType("INTEGER");

                    b.Property<int>("VoltageId")
                        .HasColumnType("INTEGER");

                    b.HasIndex("GeneratingStationId");

                    b.HasIndex("GeneratingTransformerHVVoltageId");

                    b.HasIndex("VoltageId");

                    b.ToTable("Element", t =>
                        {
                            t.Property("VoltageId")
                                .HasColumnName("GeneratingUnit_VoltageId");
                        });

                    b.HasDiscriminator().HasValue("GeneratingUnit");
                });

            modelBuilder.Entity("EMS.Models.HVDCPole", b =>
                {
                    b.HasBaseType("EMS.Models.Element");

                    b.Property<string>("PoleType")
                        .HasColumnType("TEXT");

                    b.Property<int>("VoltageId")
                        .HasColumnType("INTEGER");

                    b.HasIndex("VoltageId");

                    b.ToTable("Element", t =>
                        {
                            t.Property("VoltageId")
                                .HasColumnName("HVDCPole_VoltageId");
                        });

                    b.HasDiscriminator().HasValue("HVDCPole");
                });

            modelBuilder.Entity("EMS.Models.SubFilterBank", b =>
                {
                    b.HasBaseType("EMS.Models.Element");

                    b.Property<int>("FilterBankId")
                        .HasColumnType("INTEGER");

                    b.HasIndex("FilterBankId");

                    b.HasDiscriminator().HasValue("SubFilterBank");
                });

            modelBuilder.Entity("EMS.Models.Transformer", b =>
                {
                    b.HasBaseType("EMS.Models.Element");

                    b.Property<int>("LocationId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MVACapacity")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TransformerType")
                        .HasColumnType("TEXT");

                    b.Property<int>("Voltage1Id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Voltage2Id")
                        .HasColumnType("INTEGER");

                    b.HasIndex("LocationId");

                    b.HasIndex("Voltage1Id");

                    b.HasIndex("Voltage2Id");

                    b.HasDiscriminator().HasValue("Transformer");
                });

            modelBuilder.Entity("EMS.Models.Element", b =>
                {
                    b.HasOne("EMS.Models.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EMS.Models.Substation", "Substation1")
                        .WithMany()
                        .HasForeignKey("Substation1Id");

                    b.HasOne("EMS.Models.Substation", "Substation2")
                        .WithMany()
                        .HasForeignKey("Substation2Id");

                    b.Navigation("Region");

                    b.Navigation("Substation1");

                    b.Navigation("Substation2");
                });

            modelBuilder.Entity("EMS.Models.GeneratingStation", b =>
                {
                    b.HasOne("EMS.Models.Fuel", "Fuel")
                        .WithMany()
                        .HasForeignKey("FuelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EMS.Models.GeneratingStationClassification", "GeneratingStationClassification")
                        .WithMany()
                        .HasForeignKey("GeneratingStationClassificationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EMS.Models.GeneratingStationType", "GeneratingStationType")
                        .WithMany()
                        .HasForeignKey("GeneratingStationTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fuel");

                    b.Navigation("GeneratingStationClassification");

                    b.Navigation("GeneratingStationType");
                });

            modelBuilder.Entity("EMS.Models.Location", b =>
                {
                    b.HasOne("EMS.Models.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EMS.Models.State", "State")
                        .WithMany()
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Region");

                    b.Navigation("State");
                });

            modelBuilder.Entity("EMS.Models.Owner", b =>
                {
                    b.HasOne("EMS.Models.Constituent", "Constituent")
                        .WithMany("Owners")
                        .HasForeignKey("ConstituentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Constituent");
                });

            modelBuilder.Entity("EMS.Models.OwnerElement", b =>
                {
                    b.HasOne("EMS.Models.Element", "Element")
                        .WithMany("OwnerElements")
                        .HasForeignKey("ElementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EMS.Models.Owner", "Owner")
                        .WithMany("OwnerElements")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Element");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("EMS.Models.OwnerSubstation", b =>
                {
                    b.HasOne("EMS.Models.Owner", "Owner")
                        .WithMany("OwnerSubstations")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EMS.Models.Substation", "Substation")
                        .WithMany("OwnerSubstations")
                        .HasForeignKey("SubstationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");

                    b.Navigation("Substation");
                });

            modelBuilder.Entity("EMS.Models.Substation", b =>
                {
                    b.HasOne("EMS.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EMS.Models.Voltage", "Voltage")
                        .WithMany()
                        .HasForeignKey("VoltageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");

                    b.Navigation("Voltage");
                });

            modelBuilder.Entity("EMS.Models.Bay", b =>
                {
                    b.HasOne("EMS.Models.Element", "ConnectingElement1")
                        .WithMany()
                        .HasForeignKey("ConnectingElement1Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EMS.Models.Element", "ConnectingElement2")
                        .WithMany()
                        .HasForeignKey("ConnectingElement2Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EMS.Models.Owner", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EMS.Models.Voltage", "Voltage")
                        .WithMany()
                        .HasForeignKey("VoltageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ConnectingElement1");

                    b.Navigation("ConnectingElement2");

                    b.Navigation("Owner");

                    b.Navigation("Voltage");
                });

            modelBuilder.Entity("EMS.Models.FilterBank", b =>
                {
                    b.HasOne("EMS.Models.Voltage", "Voltage")
                        .WithMany()
                        .HasForeignKey("VoltageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Voltage");
                });

            modelBuilder.Entity("EMS.Models.GeneratingUnit", b =>
                {
                    b.HasOne("EMS.Models.GeneratingStation", "GeneratingStation")
                        .WithMany()
                        .HasForeignKey("GeneratingStationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EMS.Models.Voltage", "GeneratingTransformerHVVoltage")
                        .WithMany()
                        .HasForeignKey("GeneratingTransformerHVVoltageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EMS.Models.Voltage", "Voltage")
                        .WithMany()
                        .HasForeignKey("VoltageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GeneratingStation");

                    b.Navigation("GeneratingTransformerHVVoltage");

                    b.Navigation("Voltage");
                });

            modelBuilder.Entity("EMS.Models.HVDCPole", b =>
                {
                    b.HasOne("EMS.Models.Voltage", "Voltage")
                        .WithMany()
                        .HasForeignKey("VoltageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Voltage");
                });

            modelBuilder.Entity("EMS.Models.SubFilterBank", b =>
                {
                    b.HasOne("EMS.Models.FilterBank", "FilterBank")
                        .WithMany()
                        .HasForeignKey("FilterBankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FilterBank");
                });

            modelBuilder.Entity("EMS.Models.Transformer", b =>
                {
                    b.HasOne("EMS.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EMS.Models.Voltage", "Voltage1")
                        .WithMany()
                        .HasForeignKey("Voltage1Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EMS.Models.Voltage", "Voltage2")
                        .WithMany()
                        .HasForeignKey("Voltage2Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");

                    b.Navigation("Voltage1");

                    b.Navigation("Voltage2");
                });

            modelBuilder.Entity("EMS.Models.Constituent", b =>
                {
                    b.Navigation("Owners");
                });

            modelBuilder.Entity("EMS.Models.Element", b =>
                {
                    b.Navigation("OwnerElements");
                });

            modelBuilder.Entity("EMS.Models.Owner", b =>
                {
                    b.Navigation("OwnerElements");

                    b.Navigation("OwnerSubstations");
                });

            modelBuilder.Entity("EMS.Models.Substation", b =>
                {
                    b.Navigation("OwnerSubstations");
                });
#pragma warning restore 612, 618
        }
    }
}
