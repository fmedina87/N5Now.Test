using Microsoft.EntityFrameworkCore.Migrations;
using N5Now.Test.Infrastructure.Helper;

#nullable disable

namespace N5Now.Test.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class loaddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string query = HelperMigration.ReadSqlFile("LoadEmployess.sql");
            migrationBuilder.Sql(query);
            query = HelperMigration.ReadSqlFile("LoadPermissionTypes.sql");
            migrationBuilder.Sql(query);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
