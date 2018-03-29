using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TestePratico.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationAdminID",
                table: "Trainings",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RegisterViewModel",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ConfirmPassword = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Password = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisterViewModel", x => x.UserId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_ApplicationAdminID",
                table: "Trainings",
                column: "ApplicationAdminID");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainings_AspNetUsers_ApplicationAdminID",
                table: "Trainings",
                column: "ApplicationAdminID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainings_AspNetUsers_ApplicationAdminID",
                table: "Trainings");

            migrationBuilder.DropTable(
                name: "RegisterViewModel");

            migrationBuilder.DropIndex(
                name: "IX_Trainings_ApplicationAdminID",
                table: "Trainings");

            migrationBuilder.DropColumn(
                name: "ApplicationAdminID",
                table: "Trainings");
        }
    }
}
