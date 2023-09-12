using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocalChatApp.Migrations
{
    /// <inheritdoc />
    public partial class PropertyNameChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MessageProp",
                table: "Messages",
                newName: "UsernameAndMessage");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UsernameAndMessage",
                table: "Messages",
                newName: "MessageProp");
        }
    }
}
