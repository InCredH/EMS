using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.Migrations
{
    /// <inheritdoc />
    public partial class ElementLocationUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Element_Region_RegionId",
                table: "Element");

            migrationBuilder.RenameColumn(
                name: "RegionId",
                table: "Element",
                newName: "LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Element_RegionId",
                table: "Element",
                newName: "IX_Element_LocationId");

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

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "Element",
                newName: "RegionId");

            migrationBuilder.RenameIndex(
                name: "IX_Element_LocationId",
                table: "Element",
                newName: "IX_Element_RegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Element_Region_RegionId",
                table: "Element",
                column: "RegionId",
                principalTable: "Region",
                principalColumn: "RegionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
