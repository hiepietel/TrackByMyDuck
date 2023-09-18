using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrackByMyDuck.Migrations
{
    /// <inheritdoc />
    public partial class UserImgHref : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImgHref",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgHref",
                table: "Users");
        }
    }
}
