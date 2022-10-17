using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MailRemoverAPI.Migrations
{
    public partial class SeededUsersAndEmails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName", "Password" },
                values: new object[,]
                {
                    { new Guid("1945e44d-1c70-4378-a8c3-097a49bf7dbb"), "Austėja", "Naujokaitė", "3Gcoj6!Z1bnc" },
                    { new Guid("65d13da7-fe64-485a-999c-225b18351244"), "Benas", "Skripkiūnas", "*Y4!3l710POq" },
                    { new Guid("84a338e2-6367-4ae0-a3b4-3ce35ff5d263"), "Tomas", "Sinkevičius", "RjEUW1R58r" },
                    { new Guid("8abf7776-f21f-4861-a7b0-ee1b007de08c"), "Greta", "Virpšaitė", "@G3gng9t6XBe" }
                });

            migrationBuilder.InsertData(
                table: "Emails",
                columns: new[] { "Id", "Token", "Type", "UserId" },
                values: new object[,]
                {
                    { new Guid("11f8ccf0-da8d-4cd1-87ee-a8255fbe7c47"), "b07f85be-45da", 0, new Guid("84a338e2-6367-4ae0-a3b4-3ce35ff5d263") },
                    { new Guid("2b105217-8a39-40bf-b0a2-2f0c27693024"), "b07f45be-45da", 0, new Guid("1945e44d-1c70-4378-a8c3-097a49bf7dbb") },
                    { new Guid("4b9f76fc-e828-4e68-aa27-272692e949a6"), "b07f75be-45da", 0, new Guid("65d13da7-fe64-485a-999c-225b18351244") },
                    { new Guid("c908ff39-f339-4d08-9ce0-692f1c62623f"), "a08885be-89da", 0, new Guid("84a338e2-6367-4ae0-a3b4-3ce35ff5d263") },
                    { new Guid("e07a141b-a661-4b23-958f-2d2ad80f62d3"), "b07f96be-45da", 0, new Guid("8abf7776-f21f-4861-a7b0-ee1b007de08c") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: new Guid("11f8ccf0-da8d-4cd1-87ee-a8255fbe7c47"));

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: new Guid("2b105217-8a39-40bf-b0a2-2f0c27693024"));

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: new Guid("4b9f76fc-e828-4e68-aa27-272692e949a6"));

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: new Guid("c908ff39-f339-4d08-9ce0-692f1c62623f"));

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: new Guid("e07a141b-a661-4b23-958f-2d2ad80f62d3"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1945e44d-1c70-4378-a8c3-097a49bf7dbb"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("65d13da7-fe64-485a-999c-225b18351244"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("84a338e2-6367-4ae0-a3b4-3ce35ff5d263"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8abf7776-f21f-4861-a7b0-ee1b007de08c"));
        }
    }
}
