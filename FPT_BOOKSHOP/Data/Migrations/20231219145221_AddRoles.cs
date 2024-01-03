using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FPT_BOOKSHOP.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0e6ae8fc-8233-41fe-a848-151a1b09f50c", null, "customer", "CUSTOMER" },
                    { "77d107ff-3d22-4d38-92c0-d21519fda1f8", null, "storeOwner", "STOREOWNER" },
                    { "cb4301e7-0b55-4ce1-b1da-eff5cec7beff", null, "admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0e6ae8fc-8233-41fe-a848-151a1b09f50c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77d107ff-3d22-4d38-92c0-d21519fda1f8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb4301e7-0b55-4ce1-b1da-eff5cec7beff");
        }
    }
}
