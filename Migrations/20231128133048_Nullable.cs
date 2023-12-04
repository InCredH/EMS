using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.Migrations
{
    /// <inheritdoc />
    public partial class Nullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Constituent",
                columns: table => new
                {
                    ConstituentId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ConstituentName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Constituent", x => x.ConstituentId);
                });

            migrationBuilder.CreateTable(
                name: "Fuel",
                columns: table => new
                {
                    FuelId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FuelName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fuel", x => x.FuelId);
                });

            migrationBuilder.CreateTable(
                name: "GeneratingStationClassification",
                columns: table => new
                {
                    GeneratingStationClassificationId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Classification = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneratingStationClassification", x => x.GeneratingStationClassificationId);
                });

            migrationBuilder.CreateTable(
                name: "GeneratingStationType",
                columns: table => new
                {
                    GeneratingStationTypeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StationType = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneratingStationType", x => x.GeneratingStationTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    RegionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RegionName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.RegionId);
                });

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    StateId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StateName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.StateId);
                });

            migrationBuilder.CreateTable(
                name: "Voltage",
                columns: table => new
                {
                    VoltageId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VoltageLevel = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voltage", x => x.VoltageId);
                });

            migrationBuilder.CreateTable(
                name: "Owner",
                columns: table => new
                {
                    OwnerId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OwnerName = table.Column<string>(type: "TEXT", nullable: true),
                    ConstituentId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owner", x => x.OwnerId);
                    table.ForeignKey(
                        name: "FK_Owner_Constituent_ConstituentId",
                        column: x => x.ConstituentId,
                        principalTable: "Constituent",
                        principalColumn: "ConstituentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GeneratingStation",
                columns: table => new
                {
                    GeneratingStationId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GeneratingStationName = table.Column<string>(type: "TEXT", nullable: true),
                    InstalledCapacity = table.Column<int>(type: "INTEGER", nullable: false),
                    MVARCapacity = table.Column<int>(type: "INTEGER", nullable: false),
                    GeneratingStationClassificationId = table.Column<int>(type: "INTEGER", nullable: false),
                    GeneratingStationTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    FuelId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneratingStation", x => x.GeneratingStationId);
                    table.ForeignKey(
                        name: "FK_GeneratingStation_Fuel_FuelId",
                        column: x => x.FuelId,
                        principalTable: "Fuel",
                        principalColumn: "FuelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneratingStation_GeneratingStationClassification_GeneratingStationClassificationId",
                        column: x => x.GeneratingStationClassificationId,
                        principalTable: "GeneratingStationClassification",
                        principalColumn: "GeneratingStationClassificationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneratingStation_GeneratingStationType_GeneratingStationTypeId",
                        column: x => x.GeneratingStationTypeId,
                        principalTable: "GeneratingStationType",
                        principalColumn: "GeneratingStationTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LocationName = table.Column<string>(type: "TEXT", nullable: true),
                    RegionId = table.Column<int>(type: "INTEGER", nullable: false),
                    StateId = table.Column<int>(type: "INTEGER", nullable: false),
                    Alias = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.LocationId);
                    table.ForeignKey(
                        name: "FK_Location_Region_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Region",
                        principalColumn: "RegionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Location_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Substation",
                columns: table => new
                {
                    SubstationId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VoltageId = table.Column<int>(type: "INTEGER", nullable: false),
                    LocationId = table.Column<int>(type: "INTEGER", nullable: false),
                    SubstationType = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Substation", x => x.SubstationId);
                    table.ForeignKey(
                        name: "FK_Substation_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Substation_Voltage_VoltageId",
                        column: x => x.VoltageId,
                        principalTable: "Voltage",
                        principalColumn: "VoltageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Element",
                columns: table => new
                {
                    ElementId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Substation1Id = table.Column<int>(type: "INTEGER", nullable: true),
                    Substation2Id = table.Column<int>(type: "INTEGER", nullable: true),
                    ElementType = table.Column<string>(type: "TEXT", nullable: false),
                    ElementNumber = table.Column<string>(type: "TEXT", nullable: true),
                    CommissioningDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DecommissioningDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    RegionId = table.Column<int>(type: "INTEGER", nullable: false),
                    ConnectingElement1Id = table.Column<int>(type: "INTEGER", nullable: true),
                    ConnectingElement2Id = table.Column<int>(type: "INTEGER", nullable: true),
                    OwnerId = table.Column<int>(type: "INTEGER", nullable: true),
                    VoltageId = table.Column<int>(type: "INTEGER", nullable: true),
                    BayType = table.Column<string>(type: "TEXT", nullable: true),
                    SubstationId = table.Column<int>(type: "INTEGER", nullable: true),
                    BusType = table.Column<string>(type: "TEXT", nullable: true),
                    BusId = table.Column<int>(type: "INTEGER", nullable: true),
                    MVARCapacity = table.Column<int>(type: "INTEGER", nullable: true),
                    PercentageVariableCompensation = table.Column<int>(type: "INTEGER", nullable: true),
                    PercentageFixedCompensation = table.Column<int>(type: "INTEGER", nullable: true),
                    FilterBank_VoltageId = table.Column<int>(type: "INTEGER", nullable: true),
                    FilterBank_MVARCapacity = table.Column<int>(type: "INTEGER", nullable: true),
                    GeneratingStationId = table.Column<int>(type: "INTEGER", nullable: true),
                    InstalledCapacity = table.Column<int>(type: "INTEGER", nullable: true),
                    GeneratingUnit_VoltageId = table.Column<int>(type: "INTEGER", nullable: true),
                    GeneratingTransformerHVVoltageId = table.Column<int>(type: "INTEGER", nullable: true),
                    FilterBankId = table.Column<int>(type: "INTEGER", nullable: true),
                    SubstationType = table.Column<int>(type: "INTEGER", nullable: true),
                    Voltage1Id = table.Column<int>(type: "INTEGER", nullable: true),
                    Voltage2Id = table.Column<int>(type: "INTEGER", nullable: true),
                    MVACapacity = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Element", x => x.ElementId);
                    table.ForeignKey(
                        name: "FK_Element_Element_BusId",
                        column: x => x.BusId,
                        principalTable: "Element",
                        principalColumn: "ElementId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Element_Element_ConnectingElement1Id",
                        column: x => x.ConnectingElement1Id,
                        principalTable: "Element",
                        principalColumn: "ElementId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Element_Element_ConnectingElement2Id",
                        column: x => x.ConnectingElement2Id,
                        principalTable: "Element",
                        principalColumn: "ElementId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Element_Element_FilterBankId",
                        column: x => x.FilterBankId,
                        principalTable: "Element",
                        principalColumn: "ElementId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Element_GeneratingStation_GeneratingStationId",
                        column: x => x.GeneratingStationId,
                        principalTable: "GeneratingStation",
                        principalColumn: "GeneratingStationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Element_Owner_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owner",
                        principalColumn: "OwnerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Element_Region_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Region",
                        principalColumn: "RegionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Element_Substation_Substation1Id",
                        column: x => x.Substation1Id,
                        principalTable: "Substation",
                        principalColumn: "SubstationId");
                    table.ForeignKey(
                        name: "FK_Element_Substation_Substation2Id",
                        column: x => x.Substation2Id,
                        principalTable: "Substation",
                        principalColumn: "SubstationId");
                    table.ForeignKey(
                        name: "FK_Element_Substation_SubstationId",
                        column: x => x.SubstationId,
                        principalTable: "Substation",
                        principalColumn: "SubstationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Element_Voltage_FilterBank_VoltageId",
                        column: x => x.FilterBank_VoltageId,
                        principalTable: "Voltage",
                        principalColumn: "VoltageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Element_Voltage_GeneratingTransformerHVVoltageId",
                        column: x => x.GeneratingTransformerHVVoltageId,
                        principalTable: "Voltage",
                        principalColumn: "VoltageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Element_Voltage_GeneratingUnit_VoltageId",
                        column: x => x.GeneratingUnit_VoltageId,
                        principalTable: "Voltage",
                        principalColumn: "VoltageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Element_Voltage_Voltage1Id",
                        column: x => x.Voltage1Id,
                        principalTable: "Voltage",
                        principalColumn: "VoltageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Element_Voltage_Voltage2Id",
                        column: x => x.Voltage2Id,
                        principalTable: "Voltage",
                        principalColumn: "VoltageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Element_Voltage_VoltageId",
                        column: x => x.VoltageId,
                        principalTable: "Voltage",
                        principalColumn: "VoltageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OwnerSubstation",
                columns: table => new
                {
                    OwnerSubstationId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OwnerId = table.Column<int>(type: "INTEGER", nullable: false),
                    SubstationId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnerSubstation", x => x.OwnerSubstationId);
                    table.ForeignKey(
                        name: "FK_OwnerSubstation_Owner_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owner",
                        principalColumn: "OwnerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OwnerSubstation_Substation_SubstationId",
                        column: x => x.SubstationId,
                        principalTable: "Substation",
                        principalColumn: "SubstationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OwnerElement",
                columns: table => new
                {
                    OwnerElementId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OwnerId = table.Column<int>(type: "INTEGER", nullable: false),
                    ElementId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnerElement", x => x.OwnerElementId);
                    table.ForeignKey(
                        name: "FK_OwnerElement_Element_ElementId",
                        column: x => x.ElementId,
                        principalTable: "Element",
                        principalColumn: "ElementId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OwnerElement_Owner_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owner",
                        principalColumn: "OwnerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Element_BusId",
                table: "Element",
                column: "BusId");

            migrationBuilder.CreateIndex(
                name: "IX_Element_ConnectingElement1Id",
                table: "Element",
                column: "ConnectingElement1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Element_ConnectingElement2Id",
                table: "Element",
                column: "ConnectingElement2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Element_FilterBank_VoltageId",
                table: "Element",
                column: "FilterBank_VoltageId");

            migrationBuilder.CreateIndex(
                name: "IX_Element_FilterBankId",
                table: "Element",
                column: "FilterBankId");

            migrationBuilder.CreateIndex(
                name: "IX_Element_GeneratingStationId",
                table: "Element",
                column: "GeneratingStationId");

            migrationBuilder.CreateIndex(
                name: "IX_Element_GeneratingTransformerHVVoltageId",
                table: "Element",
                column: "GeneratingTransformerHVVoltageId");

            migrationBuilder.CreateIndex(
                name: "IX_Element_GeneratingUnit_VoltageId",
                table: "Element",
                column: "GeneratingUnit_VoltageId");

            migrationBuilder.CreateIndex(
                name: "IX_Element_OwnerId",
                table: "Element",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Element_RegionId",
                table: "Element",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Element_Substation1Id",
                table: "Element",
                column: "Substation1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Element_Substation2Id",
                table: "Element",
                column: "Substation2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Element_SubstationId",
                table: "Element",
                column: "SubstationId");

            migrationBuilder.CreateIndex(
                name: "IX_Element_Voltage1Id",
                table: "Element",
                column: "Voltage1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Element_Voltage2Id",
                table: "Element",
                column: "Voltage2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Element_VoltageId",
                table: "Element",
                column: "VoltageId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneratingStation_FuelId",
                table: "GeneratingStation",
                column: "FuelId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneratingStation_GeneratingStationClassificationId",
                table: "GeneratingStation",
                column: "GeneratingStationClassificationId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneratingStation_GeneratingStationTypeId",
                table: "GeneratingStation",
                column: "GeneratingStationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_RegionId",
                table: "Location",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_StateId",
                table: "Location",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Owner_ConstituentId",
                table: "Owner",
                column: "ConstituentId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnerElement_ElementId",
                table: "OwnerElement",
                column: "ElementId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnerElement_OwnerId",
                table: "OwnerElement",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnerSubstation_OwnerId",
                table: "OwnerSubstation",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnerSubstation_SubstationId",
                table: "OwnerSubstation",
                column: "SubstationId");

            migrationBuilder.CreateIndex(
                name: "IX_Substation_LocationId",
                table: "Substation",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Substation_VoltageId",
                table: "Substation",
                column: "VoltageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OwnerElement");

            migrationBuilder.DropTable(
                name: "OwnerSubstation");

            migrationBuilder.DropTable(
                name: "Element");

            migrationBuilder.DropTable(
                name: "GeneratingStation");

            migrationBuilder.DropTable(
                name: "Owner");

            migrationBuilder.DropTable(
                name: "Substation");

            migrationBuilder.DropTable(
                name: "Fuel");

            migrationBuilder.DropTable(
                name: "GeneratingStationClassification");

            migrationBuilder.DropTable(
                name: "GeneratingStationType");

            migrationBuilder.DropTable(
                name: "Constituent");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Voltage");

            migrationBuilder.DropTable(
                name: "Region");

            migrationBuilder.DropTable(
                name: "State");
        }
    }
}
