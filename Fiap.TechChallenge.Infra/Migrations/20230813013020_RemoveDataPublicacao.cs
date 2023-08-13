using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiap.TechChallenge.Infra.Migrations
{
    /// <inheritdoc />
    public partial class RemoveDataPublicacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataPublicacao",
                table: "Noticias");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataPublicacao",
                table: "Noticias",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
