using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.Migrations
{
    /// <inheritdoc />
    public partial class UpdateElementandTransformerModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Element_Region_RegionId",
                table: "Element");

            migrationBuilder.DropForeignKey(
                name: "FK_Transformer_Location_LocationId",
                table: "Transformer");

            migrationBuilder.DropIndex(
                name: "IX_Transformer_LocationId",
                table: "Transformer");

            migrationBuilder.DropIndex(
                name: "IX_Element_RegionId",
                table: "Element");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Transformer");

            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "Element");

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
                principalColumn: "LocationId");
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
                name: "LocationId",
                table: "Element");

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Transformer",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RegionId",
                table: "Element",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Transformer_LocationId",
                table: "Transformer",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Element_RegionId",
                table: "Element",
                column: "RegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Element_Region_RegionId",
                table: "Element",
                column: "RegionId",
                principalTable: "Region",
                principalColumn: "RegionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transformer_Location_LocationId",
                table: "Transformer",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
