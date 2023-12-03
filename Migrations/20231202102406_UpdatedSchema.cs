using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Element_Element_BusId",
                table: "Element");

            migrationBuilder.DropForeignKey(
                name: "FK_Element_Substation_SubstationId",
                table: "Element");

            migrationBuilder.DropIndex(
                name: "IX_Element_BusId",
                table: "Element");

            migrationBuilder.DropIndex(
                name: "IX_Element_SubstationId",
                table: "Element");

            migrationBuilder.DropColumn(
                name: "BusId",
                table: "Element");

            migrationBuilder.DropColumn(
                name: "SubstationId",
                table: "Element");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BusId",
                table: "Element",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubstationId",
                table: "Element",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Element_BusId",
                table: "Element",
                column: "BusId");

            migrationBuilder.CreateIndex(
                name: "IX_Element_SubstationId",
                table: "Element",
                column: "SubstationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Element_Element_BusId",
                table: "Element",
                column: "BusId",
                principalTable: "Element",
                principalColumn: "ElementId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Element_Substation_SubstationId",
                table: "Element",
                column: "SubstationId",
                principalTable: "Substation",
                principalColumn: "SubstationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
