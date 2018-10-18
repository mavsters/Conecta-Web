using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Conecta.Data.Migrations
{
    public partial class DataBase_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "About",
                table: "Country");

            migrationBuilder.DropColumn(
                name: "Indicator",
                table: "Country");

            migrationBuilder.CreateTable(
                name: "BenefitType",
                columns: table => new
                {
                    BenefitTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BenefitType", x => x.BenefitTypeId);
                });

            migrationBuilder.CreateTable(
                name: "CategoryType",
                columns: table => new
                {
                    CategoryTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryType", x => x.CategoryTypeID);
                });

            migrationBuilder.CreateTable(
                name: "EventType",
                columns: table => new
                {
                    EventTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventType", x => x.EventTypeID);
                });

            migrationBuilder.CreateTable(
                name: "UserMain",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMain", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "PlaceType",
                columns: table => new
                {
                    PlaceTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    CategoryTypeID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaceType", x => x.PlaceTypeID);
                    table.ForeignKey(
                        name: "FK_PlaceType_CategoryType_CategoryTypeID",
                        column: x => x.CategoryTypeID,
                        principalTable: "CategoryType",
                        principalColumn: "CategoryTypeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    EventTypeID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Event_EventType_EventTypeID",
                        column: x => x.EventTypeID,
                        principalTable: "EventType",
                        principalColumn: "EventTypeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_Person_UserMain_UserId",
                        column: x => x.UserId,
                        principalTable: "UserMain",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Place",
                columns: table => new
                {
                    PlaceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    PlaceTypeID = table.Column<int>(nullable: true),
                    MapId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Place", x => x.PlaceId);
                    table.ForeignKey(
                        name: "FK_Place_Map_MapId",
                        column: x => x.MapId,
                        principalTable: "Map",
                        principalColumn: "MapId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Place_PlaceType_PlaceTypeID",
                        column: x => x.PlaceTypeID,
                        principalTable: "PlaceType",
                        principalColumn: "PlaceTypeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserMain_Event",
                columns: table => new
                {
                    UserMain_EventId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Attend = table.Column<bool>(nullable: false),
                    UserMainId = table.Column<int>(nullable: false),
                    EventId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMain_Event", x => x.UserMain_EventId);
                    table.ForeignKey(
                        name: "FK_UserMain_Event_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserMain_Event_UserMain_UserMainId",
                        column: x => x.UserMainId,
                        principalTable: "UserMain",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LocationMain",
                columns: table => new
                {
                    LocationMainId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Lat = table.Column<int>(nullable: false),
                    Lon = table.Column<int>(nullable: false),
                    PlaceId = table.Column<int>(nullable: false),
                    UserMainId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationMain", x => x.LocationMainId);
                    table.ForeignKey(
                        name: "FK_LocationMain_Place_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Place",
                        principalColumn: "PlaceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocationMain_UserMain_UserMainId",
                        column: x => x.UserMainId,
                        principalTable: "UserMain",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Place_Event",
                columns: table => new
                {
                    Place_EventId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EventId = table.Column<int>(nullable: false),
                    PlaceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Place_Event", x => x.Place_EventId);
                    table.ForeignKey(
                        name: "FK_Place_Event_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Place_Event_Place_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Place",
                        principalColumn: "PlaceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QRMain",
                columns: table => new
                {
                    QRMainId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    active = table.Column<bool>(nullable: false),
                    scan = table.Column<bool>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    PlaceId = table.Column<int>(nullable: false),
                    EventId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QRMain", x => x.QRMainId);
                    table.ForeignKey(
                        name: "FK_QRMain_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QRMain_Place_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Place",
                        principalColumn: "PlaceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QRMain_UserMain_UserId",
                        column: x => x.UserId,
                        principalTable: "UserMain",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Route",
                columns: table => new
                {
                    RouteID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Lat = table.Column<int>(nullable: false),
                    Lon = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    LocationMainId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Route", x => x.RouteID);
                    table.ForeignKey(
                        name: "FK_Route_LocationMain_LocationMainId",
                        column: x => x.LocationMainId,
                        principalTable: "LocationMain",
                        principalColumn: "LocationMainId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Route_UserMain_UserId",
                        column: x => x.UserId,
                        principalTable: "UserMain",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PointsMain",
                columns: table => new
                {
                    PointsMainId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    count = table.Column<double>(nullable: false),
                    QRMainId = table.Column<int>(nullable: false),
                    UserMain_EventId = table.Column<int>(nullable: false),
                    UserMainUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointsMain", x => x.PointsMainId);
                    table.ForeignKey(
                        name: "FK_PointsMain_QRMain_QRMainId",
                        column: x => x.QRMainId,
                        principalTable: "QRMain",
                        principalColumn: "QRMainId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PointsMain_UserMain_UserMainUserId",
                        column: x => x.UserMainUserId,
                        principalTable: "UserMain",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PointsMain_UserMain_Event_UserMain_EventId",
                        column: x => x.UserMain_EventId,
                        principalTable: "UserMain_Event",
                        principalColumn: "UserMain_EventId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Benefits",
                columns: table => new
                {
                    BenefitsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BenefitTypeId = table.Column<int>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    DateEnd = table.Column<DateTime>(nullable: false),
                    Count = table.Column<double>(nullable: false),
                    PointsMainId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Benefits", x => x.BenefitsId);
                    table.ForeignKey(
                        name: "FK_Benefits_BenefitType_BenefitTypeId",
                        column: x => x.BenefitTypeId,
                        principalTable: "BenefitType",
                        principalColumn: "BenefitTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Benefits_PointsMain_PointsMainId",
                        column: x => x.PointsMainId,
                        principalTable: "PointsMain",
                        principalColumn: "PointsMainId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Benefits_BenefitTypeId",
                table: "Benefits",
                column: "BenefitTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Benefits_PointsMainId",
                table: "Benefits",
                column: "PointsMainId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Event_EventTypeID",
                table: "Event",
                column: "EventTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_LocationMain_PlaceId",
                table: "LocationMain",
                column: "PlaceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LocationMain_UserMainId",
                table: "LocationMain",
                column: "UserMainId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_UserId",
                table: "Person",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Place_MapId",
                table: "Place",
                column: "MapId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Place_PlaceTypeID",
                table: "Place",
                column: "PlaceTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Place_Event_EventId",
                table: "Place_Event",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Place_Event_PlaceId",
                table: "Place_Event",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaceType_CategoryTypeID",
                table: "PlaceType",
                column: "CategoryTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_PointsMain_QRMainId",
                table: "PointsMain",
                column: "QRMainId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PointsMain_UserMainUserId",
                table: "PointsMain",
                column: "UserMainUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PointsMain_UserMain_EventId",
                table: "PointsMain",
                column: "UserMain_EventId");

            migrationBuilder.CreateIndex(
                name: "IX_QRMain_EventId",
                table: "QRMain",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_QRMain_PlaceId",
                table: "QRMain",
                column: "PlaceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QRMain_UserId",
                table: "QRMain",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Route_LocationMainId",
                table: "Route",
                column: "LocationMainId");

            migrationBuilder.CreateIndex(
                name: "IX_Route_UserId",
                table: "Route",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMain_Event_EventId",
                table: "UserMain_Event",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMain_Event_UserMainId",
                table: "UserMain_Event",
                column: "UserMainId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Benefits");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Place_Event");

            migrationBuilder.DropTable(
                name: "Route");

            migrationBuilder.DropTable(
                name: "BenefitType");

            migrationBuilder.DropTable(
                name: "PointsMain");

            migrationBuilder.DropTable(
                name: "LocationMain");

            migrationBuilder.DropTable(
                name: "QRMain");

            migrationBuilder.DropTable(
                name: "UserMain_Event");

            migrationBuilder.DropTable(
                name: "Place");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "UserMain");

            migrationBuilder.DropTable(
                name: "PlaceType");

            migrationBuilder.DropTable(
                name: "EventType");

            migrationBuilder.DropTable(
                name: "CategoryType");

            migrationBuilder.AddColumn<string>(
                name: "About",
                table: "Country",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Indicator",
                table: "Country",
                nullable: true);
        }
    }
}
