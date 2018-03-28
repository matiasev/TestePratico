using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WebApplication3.Migrations
{
    public partial class Three : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Trainings_TrainingID",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_TrainingID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TrainingID",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserID",
                table: "Trainings",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_ApplicationUserID",
                table: "Trainings",
                column: "ApplicationUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainings_AspNetUsers_ApplicationUserID",
                table: "Trainings",
                column: "ApplicationUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainings_AspNetUsers_ApplicationUserID",
                table: "Trainings");

            migrationBuilder.DropIndex(
                name: "IX_Trainings_ApplicationUserID",
                table: "Trainings");

            migrationBuilder.DropColumn(
                name: "ApplicationUserID",
                table: "Trainings");

            migrationBuilder.AddColumn<int>(
                name: "TrainingID",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TrainingID",
                table: "AspNetUsers",
                column: "TrainingID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Trainings_TrainingID",
                table: "AspNetUsers",
                column: "TrainingID",
                principalTable: "Trainings",
                principalColumn: "TrainingID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
