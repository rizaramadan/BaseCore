using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbMigrations.Migrations
{
    [Migration(20201213134600)]
    public class CreateUser : Migration
    {
        public override void Up()
        {
            Create.Table("app_users")
                .WithColumn("id").AsInt64().PrimaryKey().Identity()
                .WithColumn("name").AsFixedLengthString(64)
                .WithColumn("username").AsFixedLengthString(64).NotNullable()
                .WithColumn("normalized_username").AsFixedLengthString(64)
                .WithColumn("email").AsFixedLengthString(64).NotNullable()
                .WithColumn("normalized_email").AsFixedLengthString(64).NotNullable()
                .WithColumn("email_confirmed").AsBoolean().NotNullable().WithDefaultValue(false)
                .WithColumn("password_hash").AsString().NotNullable()
                .WithColumn("security_stamp").AsString()
                .WithColumn("concurrency_stamp").AsString()
                .WithColumn("phone_number").AsString()
                .WithColumn("phone_number_confirmed").AsBoolean().NotNullable().WithDefaultValue(false)
                .WithColumn("two_factor_enabled").AsBoolean().NotNullable().WithDefaultValue(false)
                .WithColumn("lockout_end").AsCustom("timestamp with time zone")
                .WithColumn("lockout_enabled").AsBoolean().NotNullable().WithDefaultValue(false)
                .WithColumn("acces_failed_count").AsInt16().NotNullable().WithDefaultValue(0);
        }

        public override void Down()
        {
            Delete.Table("app_users");
        }
    }
}
