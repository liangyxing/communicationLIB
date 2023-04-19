﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConfigDB.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TypeName",
                table: "DANodeInfo",
                newName: "MachineName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MachineName",
                table: "DANodeInfo",
                newName: "TypeName");
        }
    }
}
