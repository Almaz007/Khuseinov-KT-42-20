using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Khuseinov_KT_42_20.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "c_t_GroupName",
                table: "Groups",
                newName: "c_GroupName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "c_GroupName",
                table: "Groups",
                newName: "c_t_GroupName");
        }
    }
}
