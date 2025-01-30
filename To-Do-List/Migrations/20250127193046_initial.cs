using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace To_Do_List.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Complete = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubTask",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Done = table.Column<bool>(type: "bit", nullable: false),
                    TaskModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubTask", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubTask_Tasks_TaskModelId",
                        column: x => x.TaskModelId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "Name", "Password" },
                values: new object[] { 1, "moshera@gmail.com", "Moshera", "2021" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "Name", "Password" },
                values: new object[] { 2, "ameena@gmail.com", "Ameena", "2020" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "Name", "Password" },
                values: new object[] { 3, "a@a.a", "a", "0000" });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "Complete", "Title", "UserId" },
                values: new object[,]
                {
                    { 11, true, "Travel to Abu Dhabi", 1 },
                    { 22, false, "Midterm Exam", 2 },
                    { 33, true, "Ai project", 3 },
                    { 44, false, "Shooping", 3 }
                });

            migrationBuilder.InsertData(
                table: "SubTask",
                columns: new[] { "Id", "Done", "TaskModelId", "Title" },
                values: new object[,]
                {
                    { 50, true, 11, "Clothing" },
                    { 51, false, 22, "Lab Linux Mid" },
                    { 52, true, 22, "Software Mid" },
                    { 53, false, 11, "Accessories" },
                    { 54, true, 33, "Ai project part1" },
                    { 55, false, 44, "Perfumes" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubTask_TaskModelId",
                table: "SubTask",
                column: "TaskModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_UserId",
                table: "Tasks",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubTask");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
