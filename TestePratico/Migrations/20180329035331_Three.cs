using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TestePratico.Migrations
{
    public partial class Three : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainings_AspNetUsers_ApplicationAdminID",
                table: "Trainings");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainings_AspNetUsers_ApplicationUserID",
                table: "Trainings");

            migrationBuilder.RenameColumn(
                name: "TimeTraining",
                table: "Trainings",
                newName: "Time");

            migrationBuilder.RenameColumn(
                name: "DataTraining",
                table: "Trainings",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserID",
                table: "Trainings",
                newName: "PlayerID");

            migrationBuilder.RenameColumn(
                name: "ApplicationAdminID",
                table: "Trainings",
                newName: "CoachID");

            migrationBuilder.RenameIndex(
                name: "IX_Trainings_ApplicationUserID",
                table: "Trainings",
                newName: "IX_Trainings_PlayerID");

            migrationBuilder.RenameIndex(
                name: "IX_Trainings_ApplicationAdminID",
                table: "Trainings",
                newName: "IX_Trainings_CoachID");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainings_AspNetUsers_CoachID",
                table: "Trainings",
                column: "CoachID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainings_AspNetUsers_PlayerID",
                table: "Trainings",
                column: "PlayerID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainings_AspNetUsers_CoachID",
                table: "Trainings");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainings_AspNetUsers_PlayerID",
                table: "Trainings");

            migrationBuilder.RenameColumn(
                name: "Time",
                table: "Trainings",
                newName: "TimeTraining");

            migrationBuilder.RenameColumn(
                name: "PlayerID",
                table: "Trainings",
                newName: "ApplicationUserID");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Trainings",
                newName: "DataTraining");

            migrationBuilder.RenameColumn(
                name: "CoachID",
                table: "Trainings",
                newName: "ApplicationAdminID");

            migrationBuilder.RenameIndex(
                name: "IX_Trainings_PlayerID",
                table: "Trainings",
                newName: "IX_Trainings_ApplicationUserID");

            migrationBuilder.RenameIndex(
                name: "IX_Trainings_CoachID",
                table: "Trainings",
                newName: "IX_Trainings_ApplicationAdminID");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainings_AspNetUsers_ApplicationAdminID",
                table: "Trainings",
                column: "ApplicationAdminID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainings_AspNetUsers_ApplicationUserID",
                table: "Trainings",
                column: "ApplicationUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
