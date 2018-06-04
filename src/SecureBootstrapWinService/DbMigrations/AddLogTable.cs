using FluentMigrator;

namespace SecureBootstrapWinService.DbMigrations
{
    [Migration(20180604121800)]
    public class AddLogTable : Migration
    {
        public override void Up()
        {
            Create.Table("Log")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Text").AsString();
        }

        public override void Down()
        {
        }
    }
}
