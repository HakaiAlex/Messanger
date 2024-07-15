using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Messenger.Persistence.Migrations;

/// <inheritdoc />
public partial class Initial : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Chats",
            columns: table => new
            {
                ID = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Chats", x => x.ID);
            });

        migrationBuilder.CreateTable(
            name: "Users",
            columns: table => new
            {
                ID = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                Username = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                PasswordHash = table.Column<string>(type: "text", nullable: false),
                ProfilePicture = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                Status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Users", x => x.ID);
            });

        migrationBuilder.CreateTable(
            name: "ChatEntityUserEntity",
            columns: table => new
            {
                ChatsID = table.Column<int>(type: "integer", nullable: false),
                ParticipantsID = table.Column<int>(type: "integer", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ChatEntityUserEntity", x => new { x.ChatsID, x.ParticipantsID });
                table.ForeignKey(
                    name: "FK_ChatEntityUserEntity_Chats_ChatsID",
                    column: x => x.ChatsID,
                    principalTable: "Chats",
                    principalColumn: "ID",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_ChatEntityUserEntity_Users_ParticipantsID",
                    column: x => x.ParticipantsID,
                    principalTable: "Users",
                    principalColumn: "ID",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "Contacts",
            columns: table => new
            {
                UserID = table.Column<int>(type: "integer", nullable: false),
                ContactID = table.Column<int>(type: "integer", nullable: false),
                Status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Contacts", x => new { x.UserID, x.ContactID });
                table.ForeignKey(
                    name: "FK_Contacts_Users_ContactID",
                    column: x => x.ContactID,
                    principalTable: "Users",
                    principalColumn: "ID",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "FK_Contacts_Users_UserID",
                    column: x => x.UserID,
                    principalTable: "Users",
                    principalColumn: "ID",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "Groups",
            columns: table => new
            {
                ID = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                ParticipantsID = table.Column<List<int>>(type: "integer[]", nullable: false),
                AdminID = table.Column<int>(type: "integer", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Groups", x => x.ID);
                table.ForeignKey(
                    name: "FK_Groups_Users_AdminID",
                    column: x => x.AdminID,
                    principalTable: "Users",
                    principalColumn: "ID",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "GroupEntityUserEntity",
            columns: table => new
            {
                GroupsID = table.Column<int>(type: "integer", nullable: false),
                ParticipantsID = table.Column<int>(type: "integer", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_GroupEntityUserEntity", x => new { x.GroupsID, x.ParticipantsID });
                table.ForeignKey(
                    name: "FK_GroupEntityUserEntity_Groups_GroupsID",
                    column: x => x.GroupsID,
                    principalTable: "Groups",
                    principalColumn: "ID",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_GroupEntityUserEntity_Users_ParticipantsID",
                    column: x => x.ParticipantsID,
                    principalTable: "Users",
                    principalColumn: "ID",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "Messages",
            columns: table => new
            {
                ID = table.Column<int>(type: "integer", nullable: false),
                SenderID = table.Column<int>(type: "integer", nullable: false),
                ReceiverID = table.Column<int>(type: "integer", nullable: false),
                Content = table.Column<string>(type: "character varying(4096)", maxLength: 4096, nullable: false),
                Timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                IsRead = table.Column<bool>(type: "boolean", nullable: false),
                GroupEntityID = table.Column<int>(type: "integer", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Messages", x => x.ID);
                table.ForeignKey(
                    name: "FK_Messages_Chats_ID",
                    column: x => x.ID,
                    principalTable: "Chats",
                    principalColumn: "ID",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_Messages_Groups_GroupEntityID",
                    column: x => x.GroupEntityID,
                    principalTable: "Groups",
                    principalColumn: "ID");
                table.ForeignKey(
                    name: "FK_Messages_Users_ReceiverID",
                    column: x => x.ReceiverID,
                    principalTable: "Users",
                    principalColumn: "ID",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "FK_Messages_Users_SenderID",
                    column: x => x.SenderID,
                    principalTable: "Users",
                    principalColumn: "ID",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateIndex(
            name: "IX_ChatEntityUserEntity_ParticipantsID",
            table: "ChatEntityUserEntity",
            column: "ParticipantsID");

        migrationBuilder.CreateIndex(
            name: "IX_Contacts_ContactID",
            table: "Contacts",
            column: "ContactID");

        migrationBuilder.CreateIndex(
            name: "IX_GroupEntityUserEntity_ParticipantsID",
            table: "GroupEntityUserEntity",
            column: "ParticipantsID");

        migrationBuilder.CreateIndex(
            name: "IX_Groups_AdminID",
            table: "Groups",
            column: "AdminID");

        migrationBuilder.CreateIndex(
            name: "IX_Messages_GroupEntityID",
            table: "Messages",
            column: "GroupEntityID");

        migrationBuilder.CreateIndex(
            name: "IX_Messages_ID",
            table: "Messages",
            column: "ID",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_Messages_ReceiverID",
            table: "Messages",
            column: "ReceiverID");

        migrationBuilder.CreateIndex(
            name: "IX_Messages_SenderID",
            table: "Messages",
            column: "SenderID");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "ChatEntityUserEntity");

        migrationBuilder.DropTable(
            name: "Contacts");

        migrationBuilder.DropTable(
            name: "GroupEntityUserEntity");

        migrationBuilder.DropTable(
            name: "Messages");

        migrationBuilder.DropTable(
            name: "Chats");

        migrationBuilder.DropTable(
            name: "Groups");

        migrationBuilder.DropTable(
            name: "Users");
    }
}
