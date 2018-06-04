using FluentMigrator;

namespace SecureBootstrapWinService.DbMigrations
{
    [Migration(20180604121800)]
    public class AddBootstrapRequestTable : Migration
    {
        //public Guid RequestId { get; set; }
        //public string MachineId { get; set; }
        //public string NodeName { get; set; }
        //public string ClusterName { get; set; }

        public override void Up()
        {
            Create.Table("BootstrapRequest")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("RequestId").AsGuid()
                .WithColumn("MachineId").AsString()
                .WithColumn("NodeName").AsString()
                .WithColumn("ClusterName").AsString()
                ;
        }

        public override void Down()
        {
        }
    }
}
