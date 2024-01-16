using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagementSystemMvc.Data.Migrations
{
    /// <inheritdoc />
    public partial class typofix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BilligId",
                table: "Billings",
                newName: "BillingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BillingId",
                table: "Billings",
                newName: "BilligId");
        }
    }
}
