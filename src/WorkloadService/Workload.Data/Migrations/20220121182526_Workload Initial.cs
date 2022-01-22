using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Workload.Data.Migrations
{
    public partial class WorkloadInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cource",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cource", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkLoadHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WorkLoad = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkLoadHistory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkLoadHistoryCources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourceId = table.Column<int>(type: "int", nullable: false),
                    WorkLoadHistoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkLoadHistoryCources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkLoadHistoryCources_Cource_CourceId",
                        column: x => x.CourceId,
                        principalTable: "Cource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkLoadHistoryCources_WorkLoadHistory_WorkLoadHistoryId",
                        column: x => x.WorkLoadHistoryId,
                        principalTable: "WorkLoadHistory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkLoadHistoryCources_CourceId",
                table: "WorkLoadHistoryCources",
                column: "CourceId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkLoadHistoryCources_WorkLoadHistoryId",
                table: "WorkLoadHistoryCources",
                column: "WorkLoadHistoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkLoadHistoryCources");

            migrationBuilder.DropTable(
                name: "Cource");

            migrationBuilder.DropTable(
                name: "WorkLoadHistory");
        }
    }
}
