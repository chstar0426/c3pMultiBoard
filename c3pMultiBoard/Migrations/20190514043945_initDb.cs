using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace c3pMultiBoard.Migrations
{
    public partial class initDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mBoard",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    WriterID = table.Column<string>(maxLength: 30, nullable: false),
                    Password = table.Column<string>(maxLength: 30, nullable: false),
                    Title = table.Column<string>(maxLength: 255, nullable: false),
                    Content = table.Column<string>(nullable: true),
                    Category = table.Column<int>(nullable: false),
                    PosteDate = table.Column<DateTime>(nullable: false),
                    PostIp = table.Column<string>(maxLength: 30, nullable: true),
                    ReadCount = table.Column<int>(nullable: false),
                    ReplySubCount = table.Column<int>(nullable: false),
                    Encoing = table.Column<int>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: true),
                    ModifyIp = table.Column<string>(maxLength: 30, nullable: true),
                    Ref = table.Column<int>(nullable: false),
                    Step = table.Column<int>(nullable: false),
                    RefOrder = table.Column<int>(nullable: false),
                    DelFlag = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mBoard", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mBoard");
        }
    }
}
