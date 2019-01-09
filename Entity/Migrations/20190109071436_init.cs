using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Entity.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sys_User",
                columns: table => new
                {
                    SysUserId = table.Column<string>(maxLength: 32, nullable: false),
                    Avatar = table.Column<string>(maxLength: 255, nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    CreateUser = table.Column<string>(maxLength: 32, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    Mobile = table.Column<string>(maxLength: 20, nullable: true),
                    NikeName = table.Column<string>(maxLength: 32, nullable: true),
                    Password = table.Column<string>(maxLength: 255, nullable: true),
                    QQ = table.Column<string>(maxLength: 200, nullable: true),
                    Remark = table.Column<string>(maxLength: 200, nullable: true),
                    Sex = table.Column<string>(maxLength: 1, nullable: true),
                    Sort = table.Column<int>(nullable: true),
                    Status = table.Column<int>(nullable: true),
                    TrueName = table.Column<string>(maxLength: 32, nullable: true),
                    UserName = table.Column<string>(maxLength: 32, nullable: false),
                    UserType = table.Column<string>(maxLength: 1, nullable: true),
                    WX = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_User", x => x.SysUserId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sys_User");
        }
    }
}
