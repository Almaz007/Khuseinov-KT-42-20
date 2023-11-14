using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Khuseinov_KT_42_20.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcademicDegrees",
                columns: table => new
                {
                    academicDegree_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор записи для ученой степени")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_AcademicDegreeName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Название ученой степени")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_academicDegree_academicDegree_id", x => x.academicDegree_id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    department_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор записи для кафедры")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_DepartmentName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Имя Кафедры"),
                    c_department_DateFoundation = table.Column<DateTime>(type: "DateTime", nullable: false, comment: "Дата основания кафедры"),
                    c_department_TeacherCount = table.Column<int>(type: "int", nullable: false, comment: "Кол-во преподователей в кафедре")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_department_department_id", x => x.department_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_teacher",
                columns: table => new
                {
                    teacher_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор записи преподователя")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_teacher_FirstName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Имя преподователя"),
                    c_teacher_LastName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Фамилия преподователя"),
                    c_teacher_MiddleName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Отчество преподователя"),
                    c_teacher_DepartmentId = table.Column<int>(type: "int", nullable: false, comment: "Внешний ключ на Кафедру"),
                    c_teacher_AcademicDegreeId = table.Column<int>(type: "int", nullable: false, comment: "Внешний ключ на ученую ступень")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_teacher_teacher_id", x => x.teacher_id);
                    table.ForeignKey(
                        name: "fk_academicDegree_id",
                        column: x => x.c_teacher_AcademicDegreeId,
                        principalTable: "AcademicDegrees",
                        principalColumn: "academicDegree_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_department_id",
                        column: x => x.c_teacher_DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "department_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cd_teacher_c_teacher_AcademicDegreeId",
                table: "cd_teacher",
                column: "c_teacher_AcademicDegreeId");

            migrationBuilder.CreateIndex(
                name: "IX_cd_teacher_c_teacher_DepartmentId",
                table: "cd_teacher",
                column: "c_teacher_DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cd_teacher");

            migrationBuilder.DropTable(
                name: "AcademicDegrees");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
