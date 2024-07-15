﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Messenger.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Messenger.Persistence.Migrations
{
    [DbContext(typeof(MessengerDbContext))]
    [Migration("20240715120629_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ChatEntityUserEntity", b =>
                {
                    b.Property<int>("ChatsID")
                        .HasColumnType("integer");

                    b.Property<int>("ParticipantsID")
                        .HasColumnType("integer");

                    b.HasKey("ChatsID", "ParticipantsID");

                    b.HasIndex("ParticipantsID");

                    b.ToTable("ChatEntityUserEntity");
                });

            modelBuilder.Entity("GroupEntityUserEntity", b =>
                {
                    b.Property<int>("GroupsID")
                        .HasColumnType("integer");

                    b.Property<int>("ParticipantsID")
                        .HasColumnType("integer");

                    b.HasKey("GroupsID", "ParticipantsID");

                    b.HasIndex("ParticipantsID");

                    b.ToTable("GroupEntityUserEntity");
                });

            modelBuilder.Entity("Messenger.Persistence.Entities.ChatEntity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.HasKey("ID");

                    b.ToTable("Chats");
                });

            modelBuilder.Entity("Messenger.Persistence.Entities.ContactEntity", b =>
                {
                    b.Property<int>("UserID")
                        .HasColumnType("integer");

                    b.Property<int>("ContactID")
                        .HasColumnType("integer");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("UserID", "ContactID");

                    b.HasIndex("ContactID");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("Messenger.Persistence.Entities.GroupEntity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<int>("AdminID")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<List<int>>("ParticipantsID")
                        .IsRequired()
                        .HasColumnType("integer[]");

                    b.HasKey("ID");

                    b.HasIndex("AdminID");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("Messenger.Persistence.Entities.MessageEntity", b =>
                {
                    b.Property<int>("ID")
                        .HasColumnType("integer");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(4096)
                        .HasColumnType("character varying(4096)");

                    b.Property<int?>("GroupEntityID")
                        .HasColumnType("integer");

                    b.Property<bool>("IsRead")
                        .HasColumnType("boolean");

                    b.Property<int>("ReceiverID")
                        .HasColumnType("integer");

                    b.Property<int>("SenderID")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("ID");

                    b.HasIndex("GroupEntityID");

                    b.HasIndex("ID")
                        .IsUnique();

                    b.HasIndex("ReceiverID");

                    b.HasIndex("SenderID");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Messenger.Persistence.Entities.UserEntity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ProfilePicture")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ChatEntityUserEntity", b =>
                {
                    b.HasOne("Messenger.Persistence.Entities.ChatEntity", null)
                        .WithMany()
                        .HasForeignKey("ChatsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Messenger.Persistence.Entities.UserEntity", null)
                        .WithMany()
                        .HasForeignKey("ParticipantsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GroupEntityUserEntity", b =>
                {
                    b.HasOne("Messenger.Persistence.Entities.GroupEntity", null)
                        .WithMany()
                        .HasForeignKey("GroupsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Messenger.Persistence.Entities.UserEntity", null)
                        .WithMany()
                        .HasForeignKey("ParticipantsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Messenger.Persistence.Entities.ContactEntity", b =>
                {
                    b.HasOne("Messenger.Persistence.Entities.UserEntity", "Contact")
                        .WithMany()
                        .HasForeignKey("ContactID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Messenger.Persistence.Entities.UserEntity", "User")
                        .WithMany("Contacts")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Contact");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Messenger.Persistence.Entities.GroupEntity", b =>
                {
                    b.HasOne("Messenger.Persistence.Entities.UserEntity", "Admin")
                        .WithMany()
                        .HasForeignKey("AdminID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Admin");
                });

            modelBuilder.Entity("Messenger.Persistence.Entities.MessageEntity", b =>
                {
                    b.HasOne("Messenger.Persistence.Entities.GroupEntity", null)
                        .WithMany("Messages")
                        .HasForeignKey("GroupEntityID");

                    b.HasOne("Messenger.Persistence.Entities.ChatEntity", null)
                        .WithMany("Messages")
                        .HasForeignKey("ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Messenger.Persistence.Entities.UserEntity", "Receiver")
                        .WithMany("ReceivedMessages")
                        .HasForeignKey("ReceiverID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Messenger.Persistence.Entities.UserEntity", "Sender")
                        .WithMany("SentMessages")
                        .HasForeignKey("SenderID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Receiver");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("Messenger.Persistence.Entities.ChatEntity", b =>
                {
                    b.Navigation("Messages");
                });

            modelBuilder.Entity("Messenger.Persistence.Entities.GroupEntity", b =>
                {
                    b.Navigation("Messages");
                });

            modelBuilder.Entity("Messenger.Persistence.Entities.UserEntity", b =>
                {
                    b.Navigation("Contacts");

                    b.Navigation("ReceivedMessages");

                    b.Navigation("SentMessages");
                });
#pragma warning restore 612, 618
        }
    }
}