using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Khuseinov_KT_42_20.Migrations
{
    /// <inheritdoc />
    public partial class changename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "c_student_GroupName",
                table: "Groups",
                newName: "c_t_GroupName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "c_t_GroupName",
                table: "Groups",
                newName: "c_student_GroupName");
        }
    }
}
