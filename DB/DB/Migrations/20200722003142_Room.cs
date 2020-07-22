using Microsoft.EntityFrameworkCore.Migrations;

namespace DB.Migrations
{
    public partial class Room : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Hotels");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Hotels",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Amenities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amenities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Layout = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "Address", "City", "Name", "PhoneNumber", "State" },
                values: new object[] { 1, "2055 Kalia Rd", "Honolulu", "Hale Koa", "+1 (808) 955-0555", "Hawaii" });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "Address", "City", "Name", "PhoneNumber", "State" },
                values: new object[] { 2, "2259 Kalakaua", "Honolulu", "The Royal Hawaiian", "+1 (808) 923-7311", "Hawaii" });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "Address", "City", "Name", "PhoneNumber", "State" },
                values: new object[] { 3, "2005 Kalia Rd", "Honolulu", "Hilton Hawaiian Village", "+1 (808) 949-4321", "Hawaii" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Amenities");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Hotels");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Hotels",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
