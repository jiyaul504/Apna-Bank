using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Apna_Bank.Migrations
{
    public partial class Bank : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transactioncs",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountNumber = table.Column<string>(type: "nvarchar(15)", nullable: true),
                    BeneficiaryName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    BankName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    IfscCode = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactioncs", x => x.TransactionId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactioncs");
        }
    }
}
