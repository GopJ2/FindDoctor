using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FindDoc.Data.Migrations
{
    public partial class ChangeProfilesLogic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorProfiles_Profiles_ApplicationUserId",
                table: "DoctorProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientProfiles_Profiles_ApplicationUserId",
                table: "PatientProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_AspNetUsers_ApplicationUserId",
                table: "Profiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profiles",
                table: "Profiles");

            migrationBuilder.RenameTable(
                name: "Profiles",
                newName: "Profile");

            migrationBuilder.AddColumn<string>(
                name: "AllergicReactions",
                table: "PatientProfiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BloodGroup",
                table: "PatientProfiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Degree",
                table: "DoctorProfiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "DoctorProfiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Experience",
                table: "DoctorProfiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Hospital",
                table: "DoctorProfiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "DoctorProfiles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "DoctorProfiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Speciality",
                table: "DoctorProfiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "University",
                table: "DoctorProfiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserProfileId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Age",
                table: "Profile",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Avatar",
                table: "Profile",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Profile",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Profile",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Facebook",
                table: "Profile",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Profile",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Instagram",
                table: "Profile",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Twitter",
                table: "Profile",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VK",
                table: "Profile",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profile",
                table: "Profile",
                column: "ApplicationUserId");

            migrationBuilder.CreateTable(
                name: "CerificationDocuments",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Direction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Result = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityOfStudying = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DoctorProfileApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CerificationDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CerificationDocuments_DoctorProfiles_DoctorProfileApplicationUserId",
                        column: x => x.DoctorProfileApplicationUserId,
                        principalTable: "DoctorProfiles",
                        principalColumn: "ApplicationUserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Relative",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telegram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Viber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Whatsapp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientProfileApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relative", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Relative_PatientProfiles_PatientProfileApplicationUserId",
                        column: x => x.PatientProfileApplicationUserId,
                        principalTable: "PatientProfiles",
                        principalColumn: "ApplicationUserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SecureDocuments",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    DoctorProfileApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecureDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SecureDocuments_DoctorProfiles_DoctorProfileApplicationUserId",
                        column: x => x.DoctorProfileApplicationUserId,
                        principalTable: "DoctorProfiles",
                        principalColumn: "ApplicationUserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserProfileId",
                table: "AspNetUsers",
                column: "UserProfileId",
                unique: true,
                filter: "[UserProfileId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CerificationDocuments_DoctorProfileApplicationUserId",
                table: "CerificationDocuments",
                column: "DoctorProfileApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Relative_PatientProfileApplicationUserId",
                table: "Relative",
                column: "PatientProfileApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SecureDocuments_DoctorProfileApplicationUserId",
                table: "SecureDocuments",
                column: "DoctorProfileApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Profile_UserProfileId",
                table: "AspNetUsers",
                column: "UserProfileId",
                principalTable: "Profile",
                principalColumn: "ApplicationUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorProfiles_Profile_ApplicationUserId",
                table: "DoctorProfiles",
                column: "ApplicationUserId",
                principalTable: "Profile",
                principalColumn: "ApplicationUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientProfiles_Profile_ApplicationUserId",
                table: "PatientProfiles",
                column: "ApplicationUserId",
                principalTable: "Profile",
                principalColumn: "ApplicationUserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Profile_UserProfileId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_DoctorProfiles_Profile_ApplicationUserId",
                table: "DoctorProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientProfiles_Profile_ApplicationUserId",
                table: "PatientProfiles");

            migrationBuilder.DropTable(
                name: "CerificationDocuments");

            migrationBuilder.DropTable(
                name: "Relative");

            migrationBuilder.DropTable(
                name: "SecureDocuments");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UserProfileId",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profile",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "AllergicReactions",
                table: "PatientProfiles");

            migrationBuilder.DropColumn(
                name: "BloodGroup",
                table: "PatientProfiles");

            migrationBuilder.DropColumn(
                name: "Degree",
                table: "DoctorProfiles");

            migrationBuilder.DropColumn(
                name: "Department",
                table: "DoctorProfiles");

            migrationBuilder.DropColumn(
                name: "Experience",
                table: "DoctorProfiles");

            migrationBuilder.DropColumn(
                name: "Hospital",
                table: "DoctorProfiles");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "DoctorProfiles");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "DoctorProfiles");

            migrationBuilder.DropColumn(
                name: "Speciality",
                table: "DoctorProfiles");

            migrationBuilder.DropColumn(
                name: "University",
                table: "DoctorProfiles");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "Facebook",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "Instagram",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "Twitter",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "VK",
                table: "Profile");

            migrationBuilder.RenameTable(
                name: "Profile",
                newName: "Profiles");

            migrationBuilder.AlterColumn<string>(
                name: "UserProfileId",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profiles",
                table: "Profiles",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorProfiles_Profiles_ApplicationUserId",
                table: "DoctorProfiles",
                column: "ApplicationUserId",
                principalTable: "Profiles",
                principalColumn: "ApplicationUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientProfiles_Profiles_ApplicationUserId",
                table: "PatientProfiles",
                column: "ApplicationUserId",
                principalTable: "Profiles",
                principalColumn: "ApplicationUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_AspNetUsers_ApplicationUserId",
                table: "Profiles",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
