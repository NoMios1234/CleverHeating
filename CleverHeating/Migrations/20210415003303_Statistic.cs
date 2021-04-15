using Microsoft.EntityFrameworkCore.Migrations;

namespace CleverHeating.Migrations
{
    public partial class Statistic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscribe_Equipment_EquipmentId1",
                table: "Subscribe");

            migrationBuilder.DropIndex(
                name: "IX_Subscribe_EquipmentId1",
                table: "Subscribe");

            migrationBuilder.DropColumn(
                name: "EquipmentId1",
                table: "Subscribe");

            migrationBuilder.AlterColumn<int>(
                name: "EquipmentId",
                table: "Subscribe",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subscribe_EquipmentId",
                table: "Subscribe",
                column: "EquipmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscribe_Equipment_EquipmentId",
                table: "Subscribe",
                column: "EquipmentId",
                principalTable: "Equipment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscribe_Equipment_EquipmentId",
                table: "Subscribe");

            migrationBuilder.DropIndex(
                name: "IX_Subscribe_EquipmentId",
                table: "Subscribe");

            migrationBuilder.AlterColumn<string>(
                name: "EquipmentId",
                table: "Subscribe",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "EquipmentId1",
                table: "Subscribe",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subscribe_EquipmentId1",
                table: "Subscribe",
                column: "EquipmentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscribe_Equipment_EquipmentId1",
                table: "Subscribe",
                column: "EquipmentId1",
                principalTable: "Equipment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
