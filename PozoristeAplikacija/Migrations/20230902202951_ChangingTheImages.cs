using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PozoristeAplikacija.Migrations
{
    /// <inheritdoc />
    public partial class ChangingTheImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
            @"
                UPDATE Pozorista
                SET Fotografija = 'https://carolinatheatre.org/wp-content/uploads/2023/05/23_FletcherHallStage_GenericHeader_1440x810-1280x720.png';
                                ");

            migrationBuilder.Sql(
            @"
                UPDATE Predstave
                SET Fotografija = 'https://carolinatheatre.org/wp-content/uploads/2023/05/23_FletcherHallStage_GenericHeader_1440x810-1280x720.png';
                                ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
