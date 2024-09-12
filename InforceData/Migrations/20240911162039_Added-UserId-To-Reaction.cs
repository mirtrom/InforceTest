using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InforceData.Migrations
{
    /// <inheritdoc />
    public partial class AddedUserIdToReaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reactions_AspNetUsers_UserId",
                table: "Reactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Reactions_Reactions_ReactionId",
                table: "Reactions");

            migrationBuilder.DropIndex(
                name: "IX_Reactions_PictureId",
                table: "Reactions");

            migrationBuilder.DropIndex(
                name: "IX_Reactions_ReactionId",
                table: "Reactions");

            migrationBuilder.DropIndex(
                name: "IX_Reactions_UserId",
                table: "Reactions");

            migrationBuilder.DropColumn(
                name: "ReactionId",
                table: "Reactions");

            migrationBuilder.DropColumn(
                name: "Dislikes",
                table: "Albums");

            migrationBuilder.DropColumn(
                name: "Likes",
                table: "Albums");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Reactions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Reactions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "167be992-9f8d-4a35-a24a-6f95b008cb85",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "52c386c3-fac6-4d23-846f-1d794fb81109", "AQAAAAIAAYagAAAAEPbO+ziZV7i9qxq+Cboq0MUV4SDv4s79mAlhZgMAlRhzGh6A9zEtSrlPbk3Rqm+2Bg==", "e534515c-c565-4761-bdb7-6229c5d8287a" });

            migrationBuilder.CreateIndex(
                name: "IX_Reactions_PictureId",
                table: "Reactions",
                column: "PictureId");

            migrationBuilder.CreateIndex(
                name: "IX_Reactions_UserId1",
                table: "Reactions",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Reactions_AspNetUsers_UserId1",
                table: "Reactions",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reactions_AspNetUsers_UserId1",
                table: "Reactions");

            migrationBuilder.DropIndex(
                name: "IX_Reactions_PictureId",
                table: "Reactions");

            migrationBuilder.DropIndex(
                name: "IX_Reactions_UserId1",
                table: "Reactions");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Reactions");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Reactions",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "ReactionId",
                table: "Reactions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Dislikes",
                table: "Albums",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "Albums",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "167be992-9f8d-4a35-a24a-6f95b008cb85",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1019973c-1d32-4f6b-893d-25ef6a97331b", "AQAAAAIAAYagAAAAEFUj+1MjhchuHkrUVVegpdHcMGrCekGpw4mQNN4b+0zB1UIMBzeZdk8jPxJwpKYyEQ==", "00de4adb-e309-4c08-96cc-c75630621a41" });

            migrationBuilder.CreateIndex(
                name: "IX_Reactions_PictureId",
                table: "Reactions",
                column: "PictureId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reactions_ReactionId",
                table: "Reactions",
                column: "ReactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Reactions_UserId",
                table: "Reactions",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reactions_AspNetUsers_UserId",
                table: "Reactions",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reactions_Reactions_ReactionId",
                table: "Reactions",
                column: "ReactionId",
                principalTable: "Reactions",
                principalColumn: "Id");
        }
    }
}
