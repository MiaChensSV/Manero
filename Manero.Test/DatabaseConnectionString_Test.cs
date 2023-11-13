using Microsoft.Extensions.Configuration;

namespace Manero.Test.Niko;


public class DatabaseConnectionString_Test
{
	[Fact]
	public void ConnectionString_In_Our_Database()
	{
		//Arrange
		var expected = "Server=mysql93.unoeuro.com;Database=pahlinder_se_db;User=pahlinder_se;Password=6pHk5azFDdh49ftmnRer;";

		var configuration = new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile("appsettings.json")
			.Build();
		//Act
		var result = configuration.GetConnectionString("DefaultConnection");

		//Assert
		Assert.Equal(expected, result);


	}



}
