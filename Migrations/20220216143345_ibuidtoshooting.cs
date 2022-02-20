using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BiathlonSuccess.Migrations
{
    public partial class ibuidtoshooting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Days",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Location = table.Column<string>(type: "TEXT", nullable: true),
                    Humidity = table.Column<int>(type: "INTEGER", nullable: true),
                    Temp = table.Column<float>(type: "REAL", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Days", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shooters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IbuId = table.Column<string>(type: "TEXT", nullable: true),
                    Fullname = table.Column<string>(type: "TEXT", nullable: true),
                    FamilyName = table.Column<string>(type: "TEXT", nullable: true),
                    GivenName = table.Column<string>(type: "TEXT", nullable: true),
                    Country = table.Column<string>(type: "TEXT", nullable: true),
                    Nationality = table.Column<string>(type: "TEXT", nullable: true),
                    GenderId = table.Column<string>(type: "TEXT", nullable: true),
                    MaxHeartRate = table.Column<int>(type: "INTEGER", nullable: false),
                    Image = table.Column<string>(type: "TEXT", nullable: true),
                    Team = table.Column<string>(type: "TEXT", nullable: true),
                    RifleWeightAdded = table.Column<float>(type: "REAL", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shooters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrainingFacilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Cityname = table.Column<string>(type: "TEXT", nullable: true),
                    Longitude = table.Column<double>(type: "REAL", nullable: false),
                    Latitude = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingFacilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HeartrateMeasurement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Time = table.Column<string>(type: "TEXT", nullable: true),
                    Value = table.Column<int>(type: "INTEGER", nullable: false),
                    DayId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeartrateMeasurement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HeartrateMeasurement_Days_DayId",
                        column: x => x.DayId,
                        principalTable: "Days",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shootings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HitRating = table.Column<float>(type: "REAL", nullable: true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Location = table.Column<string>(type: "TEXT", nullable: true),
                    IbuId = table.Column<string>(type: "TEXT", nullable: true),
                    DayId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shootings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shootings_Days_DayId",
                        column: x => x.DayId,
                        principalTable: "Days",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShooterStatistics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Season = table.Column<string>(type: "TEXT", nullable: true),
                    PronePercentage = table.Column<string>(type: "TEXT", nullable: true),
                    StandingPercentage = table.Column<string>(type: "TEXT", nullable: true),
                    ShooterIbuID = table.Column<string>(type: "TEXT", nullable: true),
                    ShooterId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShooterStatistics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShooterStatistics_Shooters_ShooterId",
                        column: x => x.ShooterId,
                        principalTable: "Shooters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShotSeries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ShotSerieNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateWithTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Location = table.Column<string>(type: "TEXT", nullable: true),
                    Duration = table.Column<TimeSpan>(type: "TEXT", nullable: true),
                    Stance = table.Column<string>(type: "TEXT", nullable: true),
                    HitRating = table.Column<float>(type: "REAL", nullable: false),
                    Wind_Speed = table.Column<float>(type: "REAL", nullable: true),
                    Wind_Deg = table.Column<int>(type: "INTEGER", nullable: true),
                    Wind_Gust = table.Column<float>(type: "REAL", nullable: true),
                    WeatherDescription = table.Column<string>(type: "TEXT", nullable: true),
                    WeatherIcon = table.Column<string>(type: "TEXT", nullable: true),
                    ShootingId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShotSeries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShotSeries_Shootings_ShootingId",
                        column: x => x.ShootingId,
                        principalTable: "Shootings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ShotNumberOfSeries = table.Column<int>(type: "INTEGER", nullable: false),
                    Result = table.Column<string>(type: "TEXT", nullable: true),
                    Time = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Wind_Speed = table.Column<float>(type: "REAL", nullable: true),
                    Wind_Deg = table.Column<int>(type: "INTEGER", nullable: true),
                    Wind_Gust = table.Column<float>(type: "REAL", nullable: true),
                    ShotSeriesId = table.Column<int>(type: "INTEGER", nullable: false),
                    Pulse = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shots_ShotSeries_ShotSeriesId",
                        column: x => x.ShotSeriesId,
                        principalTable: "ShotSeries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FiringCoordinates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    x = table.Column<float>(type: "REAL", nullable: false),
                    y = table.Column<float>(type: "REAL", nullable: false),
                    ShotId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FiringCoordinates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FiringCoordinates_Shots_ShotId",
                        column: x => x.ShotId,
                        principalTable: "Shots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FiringCoordinates_ShotId",
                table: "FiringCoordinates",
                column: "ShotId");

            migrationBuilder.CreateIndex(
                name: "IX_HeartrateMeasurement_DayId",
                table: "HeartrateMeasurement",
                column: "DayId");

            migrationBuilder.CreateIndex(
                name: "IX_ShooterStatistics_ShooterId",
                table: "ShooterStatistics",
                column: "ShooterId");

            migrationBuilder.CreateIndex(
                name: "IX_Shootings_DayId",
                table: "Shootings",
                column: "DayId");

            migrationBuilder.CreateIndex(
                name: "IX_Shots_ShotSeriesId",
                table: "Shots",
                column: "ShotSeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_ShotSeries_ShootingId",
                table: "ShotSeries",
                column: "ShootingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FiringCoordinates");

            migrationBuilder.DropTable(
                name: "HeartrateMeasurement");

            migrationBuilder.DropTable(
                name: "ShooterStatistics");

            migrationBuilder.DropTable(
                name: "TrainingFacilities");

            migrationBuilder.DropTable(
                name: "Shots");

            migrationBuilder.DropTable(
                name: "Shooters");

            migrationBuilder.DropTable(
                name: "ShotSeries");

            migrationBuilder.DropTable(
                name: "Shootings");

            migrationBuilder.DropTable(
                name: "Days");
        }
    }
}
