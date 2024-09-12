using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InforceData.Migrations
{
    /// <inheritdoc />
    public partial class AddLikesandDislikes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "167be992-9f8d-4a35-a24a-6f95b008cb85",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "63ed96b6-d3e8-4c2d-b994-7c286834601a", "AQAAAAIAAYagAAAAEGxkwsmlXZOnQvNZTwxdcOJZqRq4IKCQTIKdbadugRuhkWnH/ks4cYx70vvRCtq8Bw==", "41047b27-67bf-47a9-bd5c-35ec8293a053" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "167be992-9f8d-4a35-a24a-6f95b008cb85",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "21617761-d9bc-4021-ae4e-d605fc297ef5", "AQAAAAIAAYagAAAAEAp3sK8XpsLGNYb5vTy8TS1Dsl9dZ7fWvjNz3S1T4LiIMU62827G76Gjt7cU9I6CuQ==", "362cdef9-c0e5-4236-831c-dfe0d77c982e" });
        }
    }
}
