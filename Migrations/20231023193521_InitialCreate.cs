using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace processDataShare.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OpelArmrestDatas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tempLeftUp = table.Column<float>(type: "real", nullable: false),
                    tempRightUp = table.Column<float>(type: "real", nullable: false),
                    tempRightDown = table.Column<float>(type: "real", nullable: false),
                    tempLeftDown = table.Column<float>(type: "real", nullable: false),
                    heatingTime = table.Column<int>(type: "int", nullable: false),
                    heatingSetPointMax = table.Column<int>(type: "int", nullable: false),
                    foldingTime = table.Column<int>(type: "int", nullable: false),
                    foldingSetPointMax = table.Column<int>(type: "int", nullable: false),
                    cycleTime = table.Column<int>(type: "int", nullable: false),
                    shotDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    mouldNumber = table.Column<int>(type: "int", nullable: false),
                    recipe = table.Column<int>(type: "int", nullable: false),
                    pyroIndicatorOnOff = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpelArmrestDatas", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OpelArmrestDatas");
        }
    }
}
