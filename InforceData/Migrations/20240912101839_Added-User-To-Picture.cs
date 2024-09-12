using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InforceData.Migrations
{
    /// <inheritdoc />
    public partial class AddedUserToPicture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Pictures");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "167be992-9f8d-4a35-a24a-6f95b008cb85",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "52c386c3-fac6-4d23-846f-1d794fb81109", "AQAAAAIAAYagAAAAEPbO+ziZV7i9qxq+Cboq0MUV4SDv4s79mAlhZgMAlRhzGh6A9zEtSrlPbk3Rqm+2Bg==", "e534515c-c565-4761-bdb7-6229c5d8287a" });
        }
    }
}
