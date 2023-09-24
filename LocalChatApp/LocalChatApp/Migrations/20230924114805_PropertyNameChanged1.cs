using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocalChatApp.Migrations
{
    /// <inheritdoc />
    public partial class PropertyNameChanged1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UsernameAndMessage",
                table: "Messages",
                newName: "Message_");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Message_",
                table: "Messages",
                newName: "UsernameAndMessage");
        }
    }
}
