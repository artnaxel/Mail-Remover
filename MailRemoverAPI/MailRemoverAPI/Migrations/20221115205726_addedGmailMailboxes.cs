using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MailRemoverAPI.Migrations
{
    public partial class addedGmailMailboxes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: new Guid("3643d36c-3ea1-4bfd-b35f-21a3de71a8d0"));

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: new Guid("64f39d58-18a8-4e2d-a687-bc9fc8beb87a"));

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: new Guid("7634dd4d-43e1-4c12-8f28-728b378b2e6d"));

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: new Guid("c8d69fc2-45d6-4112-b853-6f6c5cd7c498"));

            migrationBuilder.DeleteData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: new Guid("dd1e53db-2b4d-405f-99d8-5fb22549ce92"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("487d101f-ab59-42f2-839e-039b680667cb"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a42e6f76-87a0-4c20-a48d-f14edd1eaaa8"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b1fa4b39-d2d7-48d4-8719-3e692944468f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("bb0b7544-c8ff-4f63-97c3-506962ca5b6e"));

            migrationBuilder.CreateTable(
                name: "Gmails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccessToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Expires = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gmails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gmails_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Gmails_UserId",
                table: "Gmails",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gmails");

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

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName", "Password" },
                values: new object[,]
                {
                    { new Guid("487d101f-ab59-42f2-839e-039b680667cb"), "Tomas", "Sinkevičius", "RjEUW1R58r" },
                    { new Guid("a42e6f76-87a0-4c20-a48d-f14edd1eaaa8"), "Austėja", "Naujokaitė", "3Gcoj6!Z1bnc" },
                    { new Guid("b1fa4b39-d2d7-48d4-8719-3e692944468f"), "Benas", "Skripkiūnas", "*Y4!3l710POq" },
                    { new Guid("bb0b7544-c8ff-4f63-97c3-506962ca5b6e"), "Greta", "Virpšaitė", "@G3gng9t6XBe" }
                });

            migrationBuilder.InsertData(
                table: "Emails",
                columns: new[] { "Id", "Address", "Token", "Type", "UserId" },
                values: new object[,]
                {
                    { new Guid("3643d36c-3ea1-4bfd-b35f-21a3de71a8d0"), "1234user@gmail.com", "b07f85be-45da", 0, new Guid("487d101f-ab59-42f2-839e-039b680667cb") },
                    { new Guid("64f39d58-18a8-4e2d-a687-bc9fc8beb87a"), "rsdfe2ruser@gmail.com", "b07f96be-45da", 0, new Guid("bb0b7544-c8ff-4f63-97c3-506962ca5b6e") },
                    { new Guid("7634dd4d-43e1-4c12-8f28-728b378b2e6d"), "lapesuo@gmail.com", "b07f75be-45da", 0, new Guid("b1fa4b39-d2d7-48d4-8719-3e692944468f") },
                    { new Guid("c8d69fc2-45d6-4112-b853-6f6c5cd7c498"), "1234wre2ruser@gmail.com", "a08885be-89da", 0, new Guid("487d101f-ab59-42f2-839e-039b680667cb") },
                    { new Guid("dd1e53db-2b4d-405f-99d8-5fb22549ce92"), "lunasuo@gmail.com", "b07f45be-45da", 0, new Guid("a42e6f76-87a0-4c20-a48d-f14edd1eaaa8") }
                });
        }
    }
}
