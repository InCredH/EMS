using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.Migrations
{
    /// <inheritdoc />
    public partial class TransformerUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_Element_LocationId",
                table: "Element",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Element_Location_LocationId",
                table: "Element",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Element_Location_LocationId",
                table: "Element");

            migrationBuilder.DropIndex(
                name: "IX_Element_LocationId",
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
        }
    }
}
