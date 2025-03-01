using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace commander.Migrations
{
    /// <inheritdoc />
    public partial class ModelChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Rates_RateId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Rates_RateId1",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_RateId1",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "RateId1",
                table: "Transactions");

            migrationBuilder.AlterColumn<int>(
                name: "RateId",
                table: "Transactions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Rates_RateId",
                table: "Transactions",
                column: "RateId",
                principalTable: "Rates",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Rates_RateId",
                table: "Transactions");

            migrationBuilder.AlterColumn<int>(
                name: "RateId",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RateId1",
                table: "Transactions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_RateId1",
                table: "Transactions",
                column: "RateId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Rates_RateId",
                table: "Transactions",
                column: "RateId",
                principalTable: "Rates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Rates_RateId1",
                table: "Transactions",
                column: "RateId1",
                principalTable: "Rates",
                principalColumn: "Id");
        }
    }
}
