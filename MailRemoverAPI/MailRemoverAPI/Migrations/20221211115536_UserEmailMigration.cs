using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MailRemoverAPI.Migrations
{
    public partial class UserEmailMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: new Guid("1f9af880-a832-422b-b12d-96f5881637a9"));

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: new Guid("301d4077-c8ad-438b-b359-4b8664c0e595"));

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: new Guid("4cca919e-c789-4d41-ba91-571072600880"));

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: new Guid("625188d2-57f5-4374-b3e9-68dcba810c48"));

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: new Guid("c4f6179c-0927-4897-b5b4-76dbab1ec412"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("01dcd694-6240-49fd-87f7-0f01cb7cb423"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("27bc6aeb-ea79-4960-af78-351563d50d95"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("cd582234-5dad-4a43-81e4-8810a69b2bb8"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("cd639164-cf49-4e73-b214-b4b8425beef6"));

            migrationBuilder.AddColumn<string>(
                name: "UserEmail",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName", "Password", "UserEmail" },
                values: new object[,]
                {
                    { new Guid("52dc0e28-6fcf-4b15-b323-8b46354d8008"), "Greta", "Virpšaitė", "$2a$10$qgynSeg0Dp9fbprj2b.REuSFWuPd7DoPOP5APhWYokQTWCxlgjYmG", "greta.virpsaite@gmail.com" },
                    { new Guid("95d18f2d-1b08-49d9-a0da-9cd2ed0287ea"), "Austėja", "Naujokaitė", "$2a$10$aF0xgR8qHekS3nmTFalK4uxQoLsiZvcIFa4KtwMdjvxHKZTzXqyiC", "austeja.naujokaite@gmail.com" },
                    { new Guid("c3ec3e62-48cc-40ea-b682-71262311e413"), "Benas", "Skripkiūnas", "$2a$10$m99AxXOwEiOgOj4I49an8uMLBqOBiFxrDanTHMmViMTGiotWAKhma", "benas.skripkunas@gmail.com" },
                    { new Guid("e02dcc2d-f5ef-4c1b-b75d-6027d5328d7e"), "Tomas", "Sinkevičius", "$2a$10$T1/7sZdhm1jSx4n9F1oGTetCPjEB9jCWue9NFiWDM9yOYRMHY03IC", "tomas.sinkevicius@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Emails",
                columns: new[] { "Id", "Address", "Token", "Type", "UserId" },
                values: new object[,]
                {
                    { new Guid("0922493f-dbc0-4a23-b5a5-2a233d369c99"), "rsdfe2ruser@gmail.com", "b07f96be-45da", 0, new Guid("52dc0e28-6fcf-4b15-b323-8b46354d8008") },
                    { new Guid("1825c40a-1712-4a59-be14-e6a6d1f4ba4a"), "lapesuo@gmail.com", "b07f75be-45da", 0, new Guid("c3ec3e62-48cc-40ea-b682-71262311e413") },
                    { new Guid("2f1a9b4b-f4e9-4cf0-a194-fe7bb8e37e50"), "1234wre2ruser@gmail.com", "a08885be-89da", 0, new Guid("e02dcc2d-f5ef-4c1b-b75d-6027d5328d7e") },
                    { new Guid("858dc5b6-3073-4fe1-a6e8-506faf29b36c"), "1234user@gmail.com", "b07f85be-45da", 0, new Guid("e02dcc2d-f5ef-4c1b-b75d-6027d5328d7e") },
                    { new Guid("f0a55e3c-e284-4d43-898c-c3a208489cb6"), "lunasuo@gmail.com", "b07f45be-45da", 0, new Guid("95d18f2d-1b08-49d9-a0da-9cd2ed0287ea") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: new Guid("0922493f-dbc0-4a23-b5a5-2a233d369c99"));

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: new Guid("1825c40a-1712-4a59-be14-e6a6d1f4ba4a"));

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: new Guid("2f1a9b4b-f4e9-4cf0-a194-fe7bb8e37e50"));

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: new Guid("858dc5b6-3073-4fe1-a6e8-506faf29b36c"));

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: new Guid("f0a55e3c-e284-4d43-898c-c3a208489cb6"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("52dc0e28-6fcf-4b15-b323-8b46354d8008"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("95d18f2d-1b08-49d9-a0da-9cd2ed0287ea"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c3ec3e62-48cc-40ea-b682-71262311e413"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e02dcc2d-f5ef-4c1b-b75d-6027d5328d7e"));

            migrationBuilder.DropColumn(
                name: "UserEmail",
                table: "Users");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName", "Password" },
                values: new object[,]
                {
                    { new Guid("01dcd694-6240-49fd-87f7-0f01cb7cb423"), "Greta", "Virpšaitė", "@G3gng9t6XBe" },
                    { new Guid("27bc6aeb-ea79-4960-af78-351563d50d95"), "Austėja", "Naujokaitė", "3Gcoj6!Z1bnc" },
                    { new Guid("cd582234-5dad-4a43-81e4-8810a69b2bb8"), "Benas", "Skripkiūnas", "*Y4!3l710POq" },
                    { new Guid("cd639164-cf49-4e73-b214-b4b8425beef6"), "Tomas", "Sinkevičius", "RjEUW1R58r" }
                });

            migrationBuilder.InsertData(
                table: "Emails",
                columns: new[] { "Id", "Address", "Token", "Type", "UserId" },
                values: new object[,]
                {
                    { new Guid("1f9af880-a832-422b-b12d-96f5881637a9"), "lapesuo@gmail.com", "b07f75be-45da", 0, new Guid("cd582234-5dad-4a43-81e4-8810a69b2bb8") },
                    { new Guid("301d4077-c8ad-438b-b359-4b8664c0e595"), "rsdfe2ruser@gmail.com", "b07f96be-45da", 0, new Guid("01dcd694-6240-49fd-87f7-0f01cb7cb423") },
                    { new Guid("4cca919e-c789-4d41-ba91-571072600880"), "lunasuo@gmail.com", "b07f45be-45da", 0, new Guid("27bc6aeb-ea79-4960-af78-351563d50d95") },
                    { new Guid("625188d2-57f5-4374-b3e9-68dcba810c48"), "1234wre2ruser@gmail.com", "a08885be-89da", 0, new Guid("cd639164-cf49-4e73-b214-b4b8425beef6") },
                    { new Guid("c4f6179c-0927-4897-b5b4-76dbab1ec412"), "1234user@gmail.com", "b07f85be-45da", 0, new Guid("cd639164-cf49-4e73-b214-b4b8425beef6") }
                });
        }
    }
}
