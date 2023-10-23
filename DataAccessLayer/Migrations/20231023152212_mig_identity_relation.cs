using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class mig_identity_relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Writers_WriterID",
                table: "Blogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages2_Writers_ReceiverID",
                table: "Messages2");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages2_Writers_SenderID",
                table: "Messages2");

            migrationBuilder.RenameColumn(
                name: "WriterID",
                table: "Blogs",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Blogs_WriterID",
                table: "Blogs",
                newName: "IX_Blogs_UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_AspNetUsers_UserID",
                table: "Blogs",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages2_AspNetUsers_ReceiverID",
                table: "Messages2",
                column: "ReceiverID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages2_AspNetUsers_SenderID",
                table: "Messages2",
                column: "SenderID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_AspNetUsers_UserID",
                table: "Blogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages2_AspNetUsers_ReceiverID",
                table: "Messages2");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages2_AspNetUsers_SenderID",
                table: "Messages2");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Blogs",
                newName: "WriterID");

            migrationBuilder.RenameIndex(
                name: "IX_Blogs_UserID",
                table: "Blogs",
                newName: "IX_Blogs_WriterID");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Writers_WriterID",
                table: "Blogs",
                column: "WriterID",
                principalTable: "Writers",
                principalColumn: "WriterID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages2_Writers_ReceiverID",
                table: "Messages2",
                column: "ReceiverID",
                principalTable: "Writers",
                principalColumn: "WriterID");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages2_Writers_SenderID",
                table: "Messages2",
                column: "SenderID",
                principalTable: "Writers",
                principalColumn: "WriterID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
