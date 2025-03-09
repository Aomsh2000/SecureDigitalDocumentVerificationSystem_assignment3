using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DocumentVerificationSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "Role" },
                values: new object[,]
                {
                    { 1, "johndoe@example.com", "John Doe", "password123", "Admin" },
                    { 2, "janesmith@example.com", "Jane Smith", "password456", "User" },
                    { 3, "michael.johnson@example.com", "Michael Johnson", "password789", "User" },
                    { 4, "emily.davis@example.com", "Emily Davis", "password101", "User" },
                    { 5, "david.brown@example.com", "David Brown", "password202", "Admin" },
                    { 6, "sarah.wilson@example.com", "Sarah Wilson", "password303", "User" }
                });

            migrationBuilder.InsertData(
                table: "Documents",
                columns: new[] { "Id", "CreatedAt", "FilePath", "Status", "Title", "UserId", "VerificationCode" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 8, 17, 28, 55, 610, DateTimeKind.Local).AddTicks(7311), "/files/doc1.pdf", "Verified", "Official Document 1", 1, "ABCD1234" },
                    { 2, new DateTime(2025, 3, 8, 17, 28, 55, 612, DateTimeKind.Local).AddTicks(3792), "/files/doc2.pdf", "Pending", "Official Document 2", 2, "EFGH5678" },
                    { 3, new DateTime(2025, 3, 3, 17, 28, 55, 612, DateTimeKind.Local).AddTicks(3808), "/files/doc3.pdf", "Pending", "Official Document 3", 3, "IJKL9101" },
                    { 4, new DateTime(2025, 2, 26, 17, 28, 55, 612, DateTimeKind.Local).AddTicks(3886), "/files/doc4.pdf", "Verified", "Official Document 4", 4, "MNOP1122" },
                    { 5, new DateTime(2025, 3, 6, 17, 28, 55, 612, DateTimeKind.Local).AddTicks(3890), "/files/doc5.pdf", "Verified", "Official Document 5", 5, "QRST2233" },
                    { 6, new DateTime(2025, 3, 7, 17, 28, 55, 612, DateTimeKind.Local).AddTicks(3893), "/files/doc6.pdf", "Pending", "Official Document 6", 6, "UVWX3344" }
                });

            migrationBuilder.InsertData(
                table: "VerificationLogs",
                columns: new[] { "Id", "DocumentId", "Status", "Timestamp", "VerifiedBy" },
                values: new object[,]
                {
                    { 1, 1, "Verified", new DateTime(2025, 3, 8, 17, 28, 55, 612, DateTimeKind.Local).AddTicks(5868), "Admin" },
                    { 2, 4, "Verified", new DateTime(2025, 2, 26, 17, 28, 55, 612, DateTimeKind.Local).AddTicks(6290), "Admin" },
                    { 3, 5, "Verified", new DateTime(2025, 3, 6, 17, 28, 55, 612, DateTimeKind.Local).AddTicks(6295), "Admin" },
                    { 4, 2, "Pending", new DateTime(2025, 3, 3, 17, 28, 55, 612, DateTimeKind.Local).AddTicks(6296), "Admin" },
                    { 5, 6, "Pending", new DateTime(2025, 3, 7, 17, 28, 55, 612, DateTimeKind.Local).AddTicks(6298), "User" },
                    { 6, 3, "Pending", new DateTime(2025, 3, 2, 17, 28, 55, 612, DateTimeKind.Local).AddTicks(6300), "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VerificationLogs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VerificationLogs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "VerificationLogs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "VerificationLogs",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "VerificationLogs",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "VerificationLogs",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
