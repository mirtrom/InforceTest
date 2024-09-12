using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InforceData.Migrations
{
    /// <inheritdoc />
    public partial class ChangedPictureAlbum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "167be992-9f8d-4a35-a24a-6f95b008cb85",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "21617761-d9bc-4021-ae4e-d605fc297ef5", "AQAAAAIAAYagAAAAEAp3sK8XpsLGNYb5vTy8TS1Dsl9dZ7fWvjNz3S1T4LiIMU62827G76Gjt7cU9I6CuQ==", "362cdef9-c0e5-4236-831c-dfe0d77c982e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "167be992-9f8d-4a35-a24a-6f95b008cb85",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e497e429-6e89-45ed-b1ca-d1f531195ffa", "AQAAAAIAAYagAAAAEJ1s0mk0DpTxktfJwuNpbY6PBmmaie08bZ+eeTdeKJ0FOOZe1GCMdQHgz4h6RWFKJg==", "1ffbcb2e-0de1-41be-a083-9adaf8b780cd" });
        }
    }
}
