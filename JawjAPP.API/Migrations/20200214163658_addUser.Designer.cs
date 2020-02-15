﻿// <auto-generated />
using System;
using JawjAPP.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JawjAPP.API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200214163658_addUser")]
    partial class addUser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113");

            modelBuilder.Entity("JawjAPP.API.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("Hashpassword");

                    b.Property<byte[]>("Passwordalt");

                    b.Property<int>("UserName");

                    b.HasKey("Id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("JawjAPP.API.Models.Value", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("name");

                    b.HasKey("id");

                    b.ToTable("values");
                });
#pragma warning restore 612, 618
        }
    }
}
