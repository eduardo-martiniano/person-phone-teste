using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteApi.Infra.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhoneNumberTypes",
                columns: table => new
                {
                    PhoneNumberTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumberTypes", x => x.PhoneNumberTypeID);
                });

            migrationBuilder.CreateTable(
                name: "PersonPhones",
                columns: table => new
                {
                    BusinessEntityID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PhoneNumber = table.Column<string>(nullable: false),
                    PhoneNumberTypeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonPhones", x => x.BusinessEntityID);
                    table.ForeignKey(
                        name: "FK_PersonPhones_PhoneNumberTypes_PhoneNumberTypeID",
                        column: x => x.PhoneNumberTypeID,
                        principalTable: "PhoneNumberTypes",
                        principalColumn: "PhoneNumberTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonPhones_PhoneNumberTypeID",
                table: "PersonPhones",
                column: "PhoneNumberTypeID");

            migrationBuilder.InsertData(
            table: "PhoneNumberTypes",
            columns: new[] { "Name" },
            values: new object[,]
            {
                { "Cellphone" },
                { "Local phone" }
            });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonPhones");

            migrationBuilder.DropTable(
                name: "PhoneNumberTypes");
        }
    }
}
