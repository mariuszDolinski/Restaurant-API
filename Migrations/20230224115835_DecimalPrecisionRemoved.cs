﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant_API.Migrations
{
    /// <inheritdoc />
    public partial class DecimalPrecisionRemoved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Dishes",
                type: "decimal(18,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)",
                oldPrecision: 5,
                oldScale: 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Dishes",
                type: "decimal(5,2)",
                precision: 5,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,0)");
        }
    }
}
