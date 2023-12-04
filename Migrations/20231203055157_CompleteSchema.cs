using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.Migrations
{
    /// <inheritdoc />
    public partial class CompleteSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Element_Element_ConnectingElement1Id",
                table: "Element");

            migrationBuilder.DropForeignKey(
                name: "FK_Element_Element_ConnectingElement2Id",
                table: "Element");

            migrationBuilder.DropForeignKey(
                name: "FK_Element_Element_FilterBankId",
                table: "Element");

            migrationBuilder.DropForeignKey(
                name: "FK_Element_GeneratingStation_GeneratingStationId",
                table: "Element");

            migrationBuilder.DropForeignKey(
                name: "FK_Element_Location_LocationId",
                table: "Element");

            migrationBuilder.DropForeignKey(
                name: "FK_Element_Owner_OwnerId",
                table: "Element");

            migrationBuilder.DropForeignKey(
                name: "FK_Element_Voltage_FilterBank_VoltageId",
                table: "Element");

            migrationBuilder.DropForeignKey(
                name: "FK_Element_Voltage_GeneratingTransformerHVVoltageId",
                table: "Element");

            migrationBuilder.DropForeignKey(
                name: "FK_Element_Voltage_GeneratingUnit_VoltageId",
                table: "Element");

            migrationBuilder.DropForeignKey(
                name: "FK_Element_Voltage_HVDCPole_VoltageId",
                table: "Element");

            migrationBuilder.DropForeignKey(
                name: "FK_Element_Voltage_Voltage1Id",
                table: "Element");

            migrationBuilder.DropForeignKey(
                name: "FK_Element_Voltage_Voltage2Id",
                table: "Element");

            migrationBuilder.DropForeignKey(
                name: "FK_Element_Voltage_VoltageId",
                table: "Element");

            migrationBuilder.DropTable(
                name: "OwnerElement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OwnerSubstation",
                table: "OwnerSubstation");

            migrationBuilder.DropIndex(
                name: "IX_OwnerSubstation_OwnerId",
                table: "OwnerSubstation");

            migrationBuilder.DropIndex(
                name: "IX_Element_ConnectingElement1Id",
                table: "Element");

            migrationBuilder.DropIndex(
                name: "IX_Element_ConnectingElement2Id",
                table: "Element");

            migrationBuilder.DropIndex(
                name: "IX_Element_FilterBank_VoltageId",
                table: "Element");

            migrationBuilder.DropIndex(
                name: "IX_Element_FilterBankId",
                table: "Element");

            migrationBuilder.DropIndex(
                name: "IX_Element_GeneratingStationId",
                table: "Element");

            migrationBuilder.DropIndex(
                name: "IX_Element_GeneratingTransformerHVVoltageId",
                table: "Element");

            migrationBuilder.DropIndex(
                name: "IX_Element_GeneratingUnit_VoltageId",
                table: "Element");

            migrationBuilder.DropIndex(
                name: "IX_Element_HVDCPole_VoltageId",
                table: "Element");

            migrationBuilder.DropIndex(
                name: "IX_Element_LocationId",
                table: "Element");

            migrationBuilder.DropIndex(
                name: "IX_Element_OwnerId",
                table: "Element");

            migrationBuilder.DropIndex(
                name: "IX_Element_Voltage1Id",
                table: "Element");

            migrationBuilder.DropIndex(
                name: "IX_Element_Voltage2Id",
                table: "Element");

            migrationBuilder.DropIndex(
                name: "IX_Element_VoltageId",
                table: "Element");

            migrationBuilder.DropColumn(
                name: "OwnerSubstationId",
                table: "OwnerSubstation");

            migrationBuilder.DropColumn(
                name: "BayType",
                table: "Element");

            migrationBuilder.DropColumn(
                name: "BusType",
                table: "Element");

            migrationBuilder.DropColumn(
                name: "ConnectingElement1Id",
                table: "Element");

            migrationBuilder.DropColumn(
                name: "ConnectingElement2Id",
                table: "Element");

            migrationBuilder.DropColumn(
                name: "FilterBankId",
                table: "Element");

            migrationBuilder.DropColumn(
                name: "FilterBank_MVARCapacity",
                table: "Element");

            migrationBuilder.DropColumn(
                name: "FilterBank_VoltageId",
                table: "Element");

            migrationBuilder.DropColumn(
                name: "GeneratingStationId",
                table: "Element");

            migrationBuilder.DropColumn(
                name: "GeneratingTransformerHVVoltageId",
                table: "Element");

            migrationBuilder.DropColumn(
                name: "GeneratingUnit_VoltageId",
                table: "Element");

            migrationBuilder.DropColumn(
                name: "HVDCPole_VoltageId",
                table: "Element");

            migrationBuilder.DropColumn(
                name: "InstalledCapacity",
                table: "Element");

            migrationBuilder.DropColumn(
                name: "IsFuture",
                table: "Element");

            migrationBuilder.DropColumn(
                name: "IsSwitchable",
                table: "Element");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Element");

            migrationBuilder.DropColumn(
                name: "MVACapacity",
                table: "Element");

            migrationBuilder.DropColumn(
                name: "MVARCapacity",
                table: "Element");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Element");

            migrationBuilder.DropColumn(
                name: "PercentageFixedCompensation",
                table: "Element");

            migrationBuilder.DropColumn(
                name: "PercentageVariableCompensation",
                table: "Element");

            migrationBuilder.DropColumn(
                name: "PoleType",
                table: "Element");

            migrationBuilder.DropColumn(
                name: "TransformerType",
                table: "Element");

            migrationBuilder.DropColumn(
                name: "Voltage1Id",
                table: "Element");

            migrationBuilder.DropColumn(
                name: "Voltage2Id",
                table: "Element");

            migrationBuilder.DropColumn(
                name: "VoltageId",
                table: "Element");

            migrationBuilder.AlterColumn<string>(
                name: "ElementType",
                table: "Element",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OwnerSubstation",
                table: "OwnerSubstation",
                columns: new[] { "OwnerId", "SubstationId" });

            migrationBuilder.CreateTable(
                name: "Bays",
                columns: table => new
                {
                    BayId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ElementId = table.Column<int>(type: "INTEGER", nullable: false),
                    ConnectingElement1Id = table.Column<int>(type: "INTEGER", nullable: false),
                    ConnectingElement2Id = table.Column<int>(type: "INTEGER", nullable: false),
                    VoltageId = table.Column<int>(type: "INTEGER", nullable: false),
                    BayType = table.Column<string>(type: "TEXT", nullable: true),
                    IsFuture = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bays", x => x.BayId);
                    table.ForeignKey(
                        name: "FK_Bays_Element_ConnectingElement1Id",
                        column: x => x.ConnectingElement1Id,
                        principalTable: "Element",
                        principalColumn: "ElementId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bays_Element_ConnectingElement2Id",
                        column: x => x.ConnectingElement2Id,
                        principalTable: "Element",
                        principalColumn: "ElementId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bays_Element_ElementId",
                        column: x => x.ElementId,
                        principalTable: "Element",
                        principalColumn: "ElementId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bays_Voltage_VoltageId",
                        column: x => x.VoltageId,
                        principalTable: "Voltage",
                        principalColumn: "VoltageId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bus",
                columns: table => new
                {
                    BusId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ElementId = table.Column<int>(type: "INTEGER", nullable: false),
                    SubstationId = table.Column<int>(type: "INTEGER", nullable: false),
                    BusType = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bus", x => x.BusId);
                    table.ForeignKey(
                        name: "FK_Bus_Element_ElementId",
                        column: x => x.ElementId,
                        principalTable: "Element",
                        principalColumn: "ElementId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bus_Substation_SubstationId",
                        column: x => x.SubstationId,
                        principalTable: "Substation",
                        principalColumn: "SubstationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Compensator",
                columns: table => new
                {
                    CompensatorId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ElementId = table.Column<int>(type: "INTEGER", nullable: false),
                    PercentageVariableCompensation = table.Column<int>(type: "INTEGER", nullable: false),
                    PercentageFixedCompensation = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compensator", x => x.CompensatorId);
                    table.ForeignKey(
                        name: "FK_Compensator_Element_ElementId",
                        column: x => x.ElementId,
                        principalTable: "Element",
                        principalColumn: "ElementId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ElementOwner",
                columns: table => new
                {
                    ElementId = table.Column<int>(type: "INTEGER", nullable: false),
                    OwnerId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElementOwner", x => new { x.ElementId, x.OwnerId });
                    table.ForeignKey(
                        name: "FK_ElementOwner_Element_ElementId",
                        column: x => x.ElementId,
                        principalTable: "Element",
                        principalColumn: "ElementId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ElementOwner_Owner_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owner",
                        principalColumn: "OwnerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FilterBank",
                columns: table => new
                {
                    FilterBankId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VoltageId = table.Column<int>(type: "INTEGER", nullable: false),
                    ElementId = table.Column<int>(type: "INTEGER", nullable: false),
                    MVARCapacity = table.Column<int>(type: "INTEGER", nullable: false),
                    IsSwitchable = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilterBank", x => x.FilterBankId);
                    table.ForeignKey(
                        name: "FK_FilterBank_Element_ElementId",
                        column: x => x.ElementId,
                        principalTable: "Element",
                        principalColumn: "ElementId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilterBank_Voltage_VoltageId",
                        column: x => x.VoltageId,
                        principalTable: "Voltage",
                        principalColumn: "VoltageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FSC",
                columns: table => new
                {
                    FSCId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ElementId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FSC", x => x.FSCId);
                    table.ForeignKey(
                        name: "FK_FSC_Element_ElementId",
                        column: x => x.ElementId,
                        principalTable: "Element",
                        principalColumn: "ElementId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GeneratingUnit",
                columns: table => new
                {
                    GeneratingUnitId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ElementId = table.Column<int>(type: "INTEGER", nullable: false),
                    GeneratingUnitName = table.Column<string>(type: "TEXT", nullable: true),
                    GeneratingStationId = table.Column<int>(type: "INTEGER", nullable: false),
                    InstalledCapacity = table.Column<int>(type: "INTEGER", nullable: false),
                    VoltageId = table.Column<int>(type: "INTEGER", nullable: false),
                    GeneratingTransformerHVVoltageId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneratingUnit", x => x.GeneratingUnitId);
                    table.ForeignKey(
                        name: "FK_GeneratingUnit_Element_ElementId",
                        column: x => x.ElementId,
                        principalTable: "Element",
                        principalColumn: "ElementId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneratingUnit_GeneratingStation_GeneratingStationId",
                        column: x => x.GeneratingStationId,
                        principalTable: "GeneratingStation",
                        principalColumn: "GeneratingStationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneratingUnit_Voltage_GeneratingTransformerHVVoltageId",
                        column: x => x.GeneratingTransformerHVVoltageId,
                        principalTable: "Voltage",
                        principalColumn: "VoltageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneratingUnit_Voltage_VoltageId",
                        column: x => x.VoltageId,
                        principalTable: "Voltage",
                        principalColumn: "VoltageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HVDCPole",
                columns: table => new
                {
                    HVDCPoleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ElementId = table.Column<int>(type: "INTEGER", nullable: false),
                    PoleType = table.Column<string>(type: "TEXT", nullable: true),
                    VoltageId = table.Column<int>(type: "INTEGER", nullable: false),
                    PoleName = table.Column<string>(type: "TEXT", nullable: true),
                    PoleNumber = table.Column<string>(type: "TEXT", nullable: true),
                    MaxFiringAngle = table.Column<double>(type: "REAL", nullable: false),
                    MinFiringAngle = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HVDCPole", x => x.HVDCPoleId);
                    table.ForeignKey(
                        name: "FK_HVDCPole_Element_ElementId",
                        column: x => x.ElementId,
                        principalTable: "Element",
                        principalColumn: "ElementId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HVDCPole_Voltage_VoltageId",
                        column: x => x.VoltageId,
                        principalTable: "Voltage",
                        principalColumn: "VoltageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transformer",
                columns: table => new
                {
                    TransformerId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ElementId = table.Column<int>(type: "INTEGER", nullable: false),
                    TransformerName = table.Column<string>(type: "TEXT", nullable: true),
                    TransformerType = table.Column<string>(type: "TEXT", nullable: true),
                    Voltage1Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Voltage2Id = table.Column<int>(type: "INTEGER", nullable: false),
                    LocationId = table.Column<int>(type: "INTEGER", nullable: false),
                    MVACapacity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transformer", x => x.TransformerId);
                    table.ForeignKey(
                        name: "FK_Transformer_Element_ElementId",
                        column: x => x.ElementId,
                        principalTable: "Element",
                        principalColumn: "ElementId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transformer_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transformer_Voltage_Voltage1Id",
                        column: x => x.Voltage1Id,
                        principalTable: "Voltage",
                        principalColumn: "VoltageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transformer_Voltage_Voltage2Id",
                        column: x => x.Voltage2Id,
                        principalTable: "Voltage",
                        principalColumn: "VoltageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BusReactor",
                columns: table => new
                {
                    BusReactorId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ElementId = table.Column<int>(type: "INTEGER", nullable: false),
                    BusId = table.Column<int>(type: "INTEGER", nullable: false),
                    MVARCapacity = table.Column<int>(type: "INTEGER", nullable: false),
                    BusName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusReactor", x => x.BusReactorId);
                    table.ForeignKey(
                        name: "FK_BusReactor_Bus_BusId",
                        column: x => x.BusId,
                        principalTable: "Bus",
                        principalColumn: "BusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusReactor_Element_ElementId",
                        column: x => x.ElementId,
                        principalTable: "Element",
                        principalColumn: "ElementId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Line",
                columns: table => new
                {
                    LineId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LineType = table.Column<string>(type: "TEXT", nullable: true),
                    ElementId = table.Column<int>(type: "INTEGER", nullable: false),
                    FromBusId = table.Column<int>(type: "INTEGER", nullable: false),
                    ToBusId = table.Column<int>(type: "INTEGER", nullable: false),
                    VoltageId = table.Column<int>(type: "INTEGER", nullable: true),
                    CircuitNumber = table.Column<string>(type: "TEXT", nullable: true),
                    LineName = table.Column<string>(type: "TEXT", nullable: true),
                    Length = table.Column<double>(type: "REAL", nullable: false),
                    ConductorType = table.Column<string>(type: "TEXT", nullable: true),
                    AutoReclosure = table.Column<bool>(type: "INTEGER", nullable: false),
                    LineCircuitName = table.Column<string>(type: "TEXT", nullable: true),
                    SendingEndSPS = table.Column<bool>(type: "INTEGER", nullable: false),
                    ReceivingEndSPS = table.Column<bool>(type: "INTEGER", nullable: false),
                    FirstChargingDate = table.Column<DateOnly>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Line", x => x.LineId);
                    table.ForeignKey(
                        name: "FK_Line_Bus_FromBusId",
                        column: x => x.FromBusId,
                        principalTable: "Bus",
                        principalColumn: "BusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Line_Bus_ToBusId",
                        column: x => x.ToBusId,
                        principalTable: "Bus",
                        principalColumn: "BusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Line_Element_ElementId",
                        column: x => x.ElementId,
                        principalTable: "Element",
                        principalColumn: "ElementId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Line_Voltage_VoltageId",
                        column: x => x.VoltageId,
                        principalTable: "Voltage",
                        principalColumn: "VoltageId");
                });

            migrationBuilder.CreateTable(
                name: "SVC",
                columns: table => new
                {
                    SVCId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ElementId = table.Column<int>(type: "INTEGER", nullable: false),
                    BusId = table.Column<int>(type: "INTEGER", nullable: false),
                    SVCName = table.Column<string>(type: "TEXT", nullable: true),
                    SVCNumber = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SVC", x => x.SVCId);
                    table.ForeignKey(
                        name: "FK_SVC_Bus_BusId",
                        column: x => x.BusId,
                        principalTable: "Bus",
                        principalColumn: "BusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SVC_Element_ElementId",
                        column: x => x.ElementId,
                        principalTable: "Element",
                        principalColumn: "ElementId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubFilterBank",
                columns: table => new
                {
                    SubFilterBankId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ElementId = table.Column<int>(type: "INTEGER", nullable: false),
                    FilterBankId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubFilterBank", x => x.SubFilterBankId);
                    table.ForeignKey(
                        name: "FK_SubFilterBank_Element_ElementId",
                        column: x => x.ElementId,
                        principalTable: "Element",
                        principalColumn: "ElementId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubFilterBank_FilterBank_FilterBankId",
                        column: x => x.FilterBankId,
                        principalTable: "FilterBank",
                        principalColumn: "FilterBankId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LineReactor",
                columns: table => new
                {
                    LineReactorId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ElementId = table.Column<int>(type: "INTEGER", nullable: false),
                    SubstationId = table.Column<int>(type: "INTEGER", nullable: false),
                    LineId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineReactor", x => x.LineReactorId);
                    table.ForeignKey(
                        name: "FK_LineReactor_Element_ElementId",
                        column: x => x.ElementId,
                        principalTable: "Element",
                        principalColumn: "ElementId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LineReactor_Line_LineId",
                        column: x => x.LineId,
                        principalTable: "Line",
                        principalColumn: "LineId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LineReactor_Substation_SubstationId",
                        column: x => x.SubstationId,
                        principalTable: "Substation",
                        principalColumn: "SubstationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bays_ConnectingElement1Id",
                table: "Bays",
                column: "ConnectingElement1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Bays_ConnectingElement2Id",
                table: "Bays",
                column: "ConnectingElement2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Bays_ElementId",
                table: "Bays",
                column: "ElementId");

            migrationBuilder.CreateIndex(
                name: "IX_Bays_VoltageId",
                table: "Bays",
                column: "VoltageId");

            migrationBuilder.CreateIndex(
                name: "IX_Bus_ElementId",
                table: "Bus",
                column: "ElementId");

            migrationBuilder.CreateIndex(
                name: "IX_Bus_SubstationId",
                table: "Bus",
                column: "SubstationId");

            migrationBuilder.CreateIndex(
                name: "IX_BusReactor_BusId",
                table: "BusReactor",
                column: "BusId");

            migrationBuilder.CreateIndex(
                name: "IX_BusReactor_ElementId",
                table: "BusReactor",
                column: "ElementId");

            migrationBuilder.CreateIndex(
                name: "IX_Compensator_ElementId",
                table: "Compensator",
                column: "ElementId");

            migrationBuilder.CreateIndex(
                name: "IX_ElementOwner_OwnerId",
                table: "ElementOwner",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_FilterBank_ElementId",
                table: "FilterBank",
                column: "ElementId");

            migrationBuilder.CreateIndex(
                name: "IX_FilterBank_VoltageId",
                table: "FilterBank",
                column: "VoltageId");

            migrationBuilder.CreateIndex(
                name: "IX_FSC_ElementId",
                table: "FSC",
                column: "ElementId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneratingUnit_ElementId",
                table: "GeneratingUnit",
                column: "ElementId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneratingUnit_GeneratingStationId",
                table: "GeneratingUnit",
                column: "GeneratingStationId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneratingUnit_GeneratingTransformerHVVoltageId",
                table: "GeneratingUnit",
                column: "GeneratingTransformerHVVoltageId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneratingUnit_VoltageId",
                table: "GeneratingUnit",
                column: "VoltageId");

            migrationBuilder.CreateIndex(
                name: "IX_HVDCPole_ElementId",
                table: "HVDCPole",
                column: "ElementId");

            migrationBuilder.CreateIndex(
                name: "IX_HVDCPole_VoltageId",
                table: "HVDCPole",
                column: "VoltageId");

            migrationBuilder.CreateIndex(
                name: "IX_Line_ElementId",
                table: "Line",
                column: "ElementId");

            migrationBuilder.CreateIndex(
                name: "IX_Line_FromBusId",
                table: "Line",
                column: "FromBusId");

            migrationBuilder.CreateIndex(
                name: "IX_Line_ToBusId",
                table: "Line",
                column: "ToBusId");

            migrationBuilder.CreateIndex(
                name: "IX_Line_VoltageId",
                table: "Line",
                column: "VoltageId");

            migrationBuilder.CreateIndex(
                name: "IX_LineReactor_ElementId",
                table: "LineReactor",
                column: "ElementId");

            migrationBuilder.CreateIndex(
                name: "IX_LineReactor_LineId",
                table: "LineReactor",
                column: "LineId");

            migrationBuilder.CreateIndex(
                name: "IX_LineReactor_SubstationId",
                table: "LineReactor",
                column: "SubstationId");

            migrationBuilder.CreateIndex(
                name: "IX_SubFilterBank_ElementId",
                table: "SubFilterBank",
                column: "ElementId");

            migrationBuilder.CreateIndex(
                name: "IX_SubFilterBank_FilterBankId",
                table: "SubFilterBank",
                column: "FilterBankId");

            migrationBuilder.CreateIndex(
                name: "IX_SVC_BusId",
                table: "SVC",
                column: "BusId");

            migrationBuilder.CreateIndex(
                name: "IX_SVC_ElementId",
                table: "SVC",
                column: "ElementId");

            migrationBuilder.CreateIndex(
                name: "IX_Transformer_ElementId",
                table: "Transformer",
                column: "ElementId");

            migrationBuilder.CreateIndex(
                name: "IX_Transformer_LocationId",
                table: "Transformer",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Transformer_Voltage1Id",
                table: "Transformer",
                column: "Voltage1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Transformer_Voltage2Id",
                table: "Transformer",
                column: "Voltage2Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bays");

            migrationBuilder.DropTable(
                name: "BusReactor");

            migrationBuilder.DropTable(
                name: "Compensator");

            migrationBuilder.DropTable(
                name: "ElementOwner");

            migrationBuilder.DropTable(
                name: "FSC");

            migrationBuilder.DropTable(
                name: "GeneratingUnit");

            migrationBuilder.DropTable(
                name: "HVDCPole");

            migrationBuilder.DropTable(
                name: "LineReactor");

            migrationBuilder.DropTable(
                name: "SubFilterBank");

            migrationBuilder.DropTable(
                name: "SVC");

            migrationBuilder.DropTable(
                name: "Transformer");

            migrationBuilder.DropTable(
                name: "Line");

            migrationBuilder.DropTable(
                name: "FilterBank");

            migrationBuilder.DropTable(
                name: "Bus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OwnerSubstation",
                table: "OwnerSubstation");

            migrationBuilder.AddColumn<int>(
                name: "OwnerSubstationId",
                table: "OwnerSubstation",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<string>(
                name: "ElementType",
                table: "Element",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BayType",
                table: "Element",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BusType",
                table: "Element",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ConnectingElement1Id",
                table: "Element",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ConnectingElement2Id",
                table: "Element",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FilterBankId",
                table: "Element",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FilterBank_MVARCapacity",
                table: "Element",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FilterBank_VoltageId",
                table: "Element",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GeneratingStationId",
                table: "Element",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GeneratingTransformerHVVoltageId",
                table: "Element",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GeneratingUnit_VoltageId",
                table: "Element",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HVDCPole_VoltageId",
                table: "Element",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InstalledCapacity",
                table: "Element",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsFuture",
                table: "Element",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSwitchable",
                table: "Element",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Element",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MVACapacity",
                table: "Element",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MVARCapacity",
                table: "Element",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Element",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PercentageFixedCompensation",
                table: "Element",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PercentageVariableCompensation",
                table: "Element",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PoleType",
                table: "Element",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TransformerType",
                table: "Element",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Voltage1Id",
                table: "Element",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Voltage2Id",
                table: "Element",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VoltageId",
                table: "Element",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OwnerSubstation",
                table: "OwnerSubstation",
                column: "OwnerSubstationId");

            migrationBuilder.CreateTable(
                name: "OwnerElement",
                columns: table => new
                {
                    OwnerElementId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ElementId = table.Column<int>(type: "INTEGER", nullable: false),
                    OwnerId = table.Column<int>(type: "INTEGER", nullable: false)
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
                name: "IX_OwnerSubstation_OwnerId",
                table: "OwnerSubstation",
                column: "OwnerId");

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
                name: "IX_Element_HVDCPole_VoltageId",
                table: "Element",
                column: "HVDCPole_VoltageId");

            migrationBuilder.CreateIndex(
                name: "IX_Element_LocationId",
                table: "Element",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Element_OwnerId",
                table: "Element",
                column: "OwnerId");

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
                name: "IX_OwnerElement_ElementId",
                table: "OwnerElement",
                column: "ElementId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnerElement_OwnerId",
                table: "OwnerElement",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Element_Element_ConnectingElement1Id",
                table: "Element",
                column: "ConnectingElement1Id",
                principalTable: "Element",
                principalColumn: "ElementId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Element_Element_ConnectingElement2Id",
                table: "Element",
                column: "ConnectingElement2Id",
                principalTable: "Element",
                principalColumn: "ElementId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Element_Element_FilterBankId",
                table: "Element",
                column: "FilterBankId",
                principalTable: "Element",
                principalColumn: "ElementId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Element_GeneratingStation_GeneratingStationId",
                table: "Element",
                column: "GeneratingStationId",
                principalTable: "GeneratingStation",
                principalColumn: "GeneratingStationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Element_Location_LocationId",
                table: "Element",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Element_Owner_OwnerId",
                table: "Element",
                column: "OwnerId",
                principalTable: "Owner",
                principalColumn: "OwnerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Element_Voltage_FilterBank_VoltageId",
                table: "Element",
                column: "FilterBank_VoltageId",
                principalTable: "Voltage",
                principalColumn: "VoltageId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Element_Voltage_GeneratingTransformerHVVoltageId",
                table: "Element",
                column: "GeneratingTransformerHVVoltageId",
                principalTable: "Voltage",
                principalColumn: "VoltageId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Element_Voltage_GeneratingUnit_VoltageId",
                table: "Element",
                column: "GeneratingUnit_VoltageId",
                principalTable: "Voltage",
                principalColumn: "VoltageId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Element_Voltage_HVDCPole_VoltageId",
                table: "Element",
                column: "HVDCPole_VoltageId",
                principalTable: "Voltage",
                principalColumn: "VoltageId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Element_Voltage_Voltage1Id",
                table: "Element",
                column: "Voltage1Id",
                principalTable: "Voltage",
                principalColumn: "VoltageId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Element_Voltage_Voltage2Id",
                table: "Element",
                column: "Voltage2Id",
                principalTable: "Voltage",
                principalColumn: "VoltageId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Element_Voltage_VoltageId",
                table: "Element",
                column: "VoltageId",
                principalTable: "Voltage",
                principalColumn: "VoltageId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
