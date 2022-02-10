using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ctesp2022_final_gg.Migrations
{
    public partial class insertData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cliente",
                columns: new[] { "ClienteId", "Contacto", "Morada", "NomeCliente" },
                values: new object[,]
                {
                    { 1, 123, "Rua Direita 1", "Antonio" },
                    { 2, 456, "Rua Esquerda 1", "Jose" }
                });

            migrationBuilder.InsertData(
                table: "TipoTransacao",
                columns: new[] { "TipoTransacaoId", "NomeTipoTransacao" },
                values: new object[,]
                {
                    { 1, "Credito" },
                    { 2, "Debito" }
                });

            migrationBuilder.InsertData(
                table: "ContaBancaria",
                columns: new[] { "ContaBancariaId", "ClienteId", "IBAN", "NumeroConta", "SaldoCorrente" },
                values: new object[] { 1, 1, "PT50-123", 1, 100.0 });

            migrationBuilder.InsertData(
                table: "ContaBancaria",
                columns: new[] { "ContaBancariaId", "ClienteId", "IBAN", "NumeroConta", "SaldoCorrente" },
                values: new object[] { 2, 2, "PT50-456", 2, 200.0 });

            migrationBuilder.InsertData(
                table: "Transacao",
                columns: new[] { "TransacaoId", "ContaBancariaId", "Dia", "TipoTransacaoId", "Valor" },
                values: new object[] { 1, 1, new DateTime(2022, 2, 8, 13, 20, 37, 886, DateTimeKind.Local).AddTicks(634), 1, 100.0 });

            migrationBuilder.InsertData(
                table: "Transacao",
                columns: new[] { "TransacaoId", "ContaBancariaId", "Dia", "TipoTransacaoId", "Valor" },
                values: new object[] { 2, 2, new DateTime(2022, 2, 9, 13, 20, 37, 888, DateTimeKind.Local).AddTicks(4354), 1, 200.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TipoTransacao",
                keyColumn: "TipoTransacaoId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Transacao",
                keyColumn: "TransacaoId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Transacao",
                keyColumn: "TransacaoId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ContaBancaria",
                keyColumn: "ContaBancariaId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ContaBancaria",
                keyColumn: "ContaBancariaId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TipoTransacao",
                keyColumn: "TipoTransacaoId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cliente",
                keyColumn: "ClienteId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cliente",
                keyColumn: "ClienteId",
                keyValue: 2);
        }
    }
}
