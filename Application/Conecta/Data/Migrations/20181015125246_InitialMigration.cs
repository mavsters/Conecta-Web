using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Conecta.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    CountryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    IATA = table.Column<string>(nullable: true),
                    Indicator = table.Column<string>(nullable: true),
                    About = table.Column<string>(nullable: true),
                    CountryFlagUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "Province",
                columns: table => new
                {
                    ProvinceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    CountryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Province", x => x.ProvinceId);
                    table.ForeignKey(
                        name: "FK_Province_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Commune",
                columns: table => new
                {
                    CommuneId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    ProvinceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commune", x => x.CommuneId);
                    table.ForeignKey(
                        name: "FK_Commune_Province_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Province",
                        principalColumn: "ProvinceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Neighborhood",
                columns: table => new
                {
                    NeighborhoodId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    CommuneId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Neighborhood", x => x.NeighborhoodId);
                    table.ForeignKey(
                        name: "FK_Neighborhood_Commune_CommuneId",
                        column: x => x.CommuneId,
                        principalTable: "Commune",
                        principalColumn: "CommuneId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Map",
                columns: table => new
                {
                    MapId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(nullable: true),
                    NeighborhoodId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Map", x => x.MapId);
                    table.ForeignKey(
                        name: "FK_Map_Neighborhood_NeighborhoodId",
                        column: x => x.NeighborhoodId,
                        principalTable: "Neighborhood",
                        principalColumn: "NeighborhoodId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Commune_ProvinceId",
                table: "Commune",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Map_NeighborhoodId",
                table: "Map",
                column: "NeighborhoodId");

            migrationBuilder.CreateIndex(
                name: "IX_Neighborhood_CommuneId",
                table: "Neighborhood",
                column: "CommuneId");

            migrationBuilder.CreateIndex(
                name: "IX_Province_CountryId",
                table: "Province",
                column: "CountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Map");

            migrationBuilder.DropTable(
                name: "Neighborhood");

            migrationBuilder.DropTable(
                name: "Commune");

            migrationBuilder.DropTable(
                name: "Province");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
