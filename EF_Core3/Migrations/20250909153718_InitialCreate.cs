using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Core3.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ins_ID = table.Column<int>(type: "int", nullable: false),
                    HiringDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HourRateBouns = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Dept_ID = table.Column<int>(type: "int", nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Instructors_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Dep_Id = table.Column<int>(type: "int", nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Students_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Top_ID = table.Column<int>(type: "int", nullable: false),
                    TopicID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Courses_Topics_TopicID",
                        column: x => x.TopicID,
                        principalTable: "Topics",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Course_Insts",
                columns: table => new
                {
                    Inst_ID = table.Column<int>(type: "int", nullable: false),
                    Course_ID = table.Column<int>(type: "int", nullable: false),
                    InstructorID = table.Column<int>(type: "int", nullable: true),
                    CourseID = table.Column<int>(type: "int", nullable: true),
                    Evaluate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course_Insts", x => new { x.Inst_ID, x.Course_ID });
                    table.ForeignKey(
                        name: "FK_Course_Insts_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Course_Insts_Instructors_InstructorID",
                        column: x => x.InstructorID,
                        principalTable: "Instructors",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Stud_Courses",
                columns: table => new
                {
                    Stud_ID = table.Column<int>(type: "int", nullable: false),
                    Course_ID = table.Column<int>(type: "int", nullable: false),
                    StudentID = table.Column<int>(type: "int", nullable: true),
                    CourseID = table.Column<int>(type: "int", nullable: true),
                    Grade = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stud_Courses", x => new { x.Stud_ID, x.Course_ID });
                    table.ForeignKey(
                        name: "FK_Stud_Courses_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Stud_Courses_Students_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Students",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Course_Insts_CourseID",
                table: "Course_Insts",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Course_Insts_InstructorID",
                table: "Course_Insts",
                column: "InstructorID");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_TopicID",
                table: "Courses",
                column: "TopicID");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_DepartmentID",
                table: "Instructors",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Stud_Courses_CourseID",
                table: "Stud_Courses",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Stud_Courses_StudentID",
                table: "Stud_Courses",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_DepartmentID",
                table: "Students",
                column: "DepartmentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Course_Insts");

            migrationBuilder.DropTable(
                name: "Stud_Courses");

            migrationBuilder.DropTable(
                name: "Instructors");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
