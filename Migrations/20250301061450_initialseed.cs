using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace commander.Migrations
{
    /// <inheritdoc />
    public partial class initialseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            var startDate = new DateTime(2024, 1, 1);
            var endDate = startDate.AddMonths(2).AddDays(-1);
            var random = new Random();
            int rateId = 1;

            for (int phoneId = 1; phoneId <= 2; phoneId++) 
            {
                for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
                {
                    decimal rateValue = random.Next(1, 101);
                    string formattedDate = date.ToString("yyyy-MM-dd");

                   
                    migrationBuilder.Sql($"INSERT INTO Rates ( PhoneId, Amount , Date) VALUES ( {phoneId}, {rateValue}, '{formattedDate}')");
                }
            }
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Rates");
            migrationBuilder.Sql("DELETE FROM Phones");
        }
    }
}
