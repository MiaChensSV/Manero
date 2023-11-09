using Microsoft.Extensions.Configuration;

namespace Manero.Test.Per.Ahlinder;

public class ConnectionStringTest
{
   
        [Fact]

        public void TestConnectionToDatabaseProvider()
        {
        //ARRANGE -- PREPARE
        var connectionString = "Server=mysql93.unoeuro.com;Database=pahlinder_se_db;User=pahlinder_se;Password=6pHk5azFDdh49ftmnRer;";
        var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();


        //ACT -- EXECUTE OPERATIONS
        var result = configuration.GetConnectionString("DefaultConnection");


        //ASSERT -- WHAT I WANT IN RETURN
        Assert.Equal(connectionString, result);
        }
}
