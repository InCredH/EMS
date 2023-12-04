using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.Migrations
{
    /// <inheritdoc />
    public partial class HVDCPoleAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TransformerType",
                table: "Element",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HVDCPole_VoltageId",
                table: "Element",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PoleNumber",
                table: "Element",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PoleType",
                table: "Element",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Element_HVDCPole_VoltageId",
                table: "Element",
                column: "HVDCPole_VoltageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Element_Voltage_HVDCPole_VoltageId",
                table: "Element",
                column: "HVDCPole_VoltageId",
                principalTable: "Voltage",
                principalColumn: "VoltageId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Element_Voltage_HVDCPole_VoltageId",
                table: "Element");

            migrationBuilder.DropIndex(
                name: "IX_Element_HVDCPole_VoltageId",
                table: "Element");

            migrationBuilder.DropColumn(
                name: "HVDCPole_VoltageId",
                table: "Element");

            migrationBuilder.DropColumn(
                name: "PoleNumber",
                table: "Element");

            migrationBuilder.DropColumn(
                name: "PoleType",
                table: "Element");

            migrationBuilder.AlterColumn<int>(
                name: "TransformerType",
                table: "Element",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
