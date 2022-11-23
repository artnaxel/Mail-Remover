using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MailRemoverAPI.Migrations
{
    public partial class AddedAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: new Guid("6c49fbbb-728d-476b-83c4-f4655930458e"));

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: new Guid("aeaea436-a85d-40e7-83e9-2b26505abe32"));

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: new Guid("c7b770dc-5e86-4765-8426-31cd37282361"));

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: new Guid("e9cde072-11f9-4de9-9e2c-0ef77136484d"));

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: new Guid("f20266e0-d7bb-4d10-a231-7dc188d610bc"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("41fef1fb-17ed-4ec7-9cde-d51655ca5f15"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b2001791-a6f6-4f83-ad57-c0aef67f22e8"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ba0e4f4d-913e-4406-a2bf-9ff49a6a9f58"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f5d45886-1e2b-4547-bd09-e688bd266d84"));

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Gmails",
                type: "nvarchar(320)",
                maxLength: 320,
                nullable: false,
                defaultValue: "");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Gmails");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName", "Password" },
                values: new object[,]
                {
                    { new Guid("41fef1fb-17ed-4ec7-9cde-d51655ca5f15"), "Austėja", "Naujokaitė", "3Gcoj6!Z1bnc" },
                    { new Guid("b2001791-a6f6-4f83-ad57-c0aef67f22e8"), "Tomas", "Sinkevičius", "RjEUW1R58r" },
                    { new Guid("ba0e4f4d-913e-4406-a2bf-9ff49a6a9f58"), "Greta", "Virpšaitė", "@G3gng9t6XBe" },
                    { new Guid("f5d45886-1e2b-4547-bd09-e688bd266d84"), "Benas", "Skripkiūnas", "*Y4!3l710POq" }
                });

            migrationBuilder.InsertData(
                table: "Emails",
                columns: new[] { "Id", "Address", "Token", "Type", "UserId" },
                values: new object[,]
                {
                    { new Guid("6c49fbbb-728d-476b-83c4-f4655930458e"), "lunasuo@gmail.com", "b07f45be-45da", 0, new Guid("41fef1fb-17ed-4ec7-9cde-d51655ca5f15") },
                    { new Guid("aeaea436-a85d-40e7-83e9-2b26505abe32"), "rsdfe2ruser@gmail.com", "b07f96be-45da", 0, new Guid("ba0e4f4d-913e-4406-a2bf-9ff49a6a9f58") },
                    { new Guid("c7b770dc-5e86-4765-8426-31cd37282361"), "lapesuo@gmail.com", "b07f75be-45da", 0, new Guid("f5d45886-1e2b-4547-bd09-e688bd266d84") },
                    { new Guid("e9cde072-11f9-4de9-9e2c-0ef77136484d"), "1234wre2ruser@gmail.com", "a08885be-89da", 0, new Guid("b2001791-a6f6-4f83-ad57-c0aef67f22e8") },
                    { new Guid("f20266e0-d7bb-4d10-a231-7dc188d610bc"), "1234user@gmail.com", "b07f85be-45da", 0, new Guid("b2001791-a6f6-4f83-ad57-c0aef67f22e8") }
                });
        }
    }
}
