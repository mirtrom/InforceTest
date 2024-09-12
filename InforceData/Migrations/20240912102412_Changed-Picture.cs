using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InforceData.Migrations
{
    /// <inheritdoc />
    public partial class ChangedPicture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Pictures");

            migrationBuilder.AddColumn<string>(
                name: "UserEmail",
                table: "Pictures",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "167be992-9f8d-4a35-a24a-6f95b008cb85",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e497e429-6e89-45ed-b1ca-d1f531195ffa", "AQAAAAIAAYagAAAAEJ1s0mk0DpTxktfJwuNpbY6PBmmaie08bZ+eeTdeKJ0FOOZe1GCMdQHgz4h6RWFKJg==", "1ffbcb2e-0de1-41be-a083-9adaf8b780cd" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserEmail",
                table: "Pictures");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Pictures",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "167be992-9f8d-4a35-a24a-6f95b008cb85",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2e1c05d1-d310-4c6e-b64b-74627693f936", "AQAAAAIAAYagAAAAENRt3zJb4dqwv1RNvmnbh3siSKe6ViOWsGHpCT+zslFloGAq/P58NpsncPs0aK5yqw==", "97233448-5f01-4658-bc0e-bbcd3a3f77a0" });
        }
    }
}
