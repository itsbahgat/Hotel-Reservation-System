﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddReservationClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    BirthDay = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    NumberGuest = table.Column<int>(type: "int", nullable: false),
                    StreetAddress = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    AptSuite = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    RoomType = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    RoomFloor = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    RoomNumber = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    TotalBill = table.Column<double>(type: "float", nullable: false),
                    PaymentType = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CardType = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CardNumber = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CardExp = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CardCvc = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    ArrivalTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeavingTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckIn = table.Column<bool>(type: "bit", nullable: false),
                    BreakFast = table.Column<int>(type: "int", nullable: false),
                    Lunch = table.Column<int>(type: "int", nullable: false),
                    Dinner = table.Column<int>(type: "int", nullable: false),
                    Cleaning = table.Column<bool>(type: "bit", nullable: false),
                    Towel = table.Column<bool>(type: "bit", nullable: false),
                    SSurprise = table.Column<bool>(type: "bit", nullable: false),
                    SupplyStatus = table.Column<bool>(type: "bit", nullable: false),
                    FoodBill = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");
        }
    }
}
