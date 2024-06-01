
using Fermaloc.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Fermaloc.Infra.Tests;
public class DatabaseConnectionTest
{
    protected ApplicationDbContext context;

    [Fact]
    public void TestDatabaseConnection(){
        
        //Arrange
        var connectionString = "server=puc-fermaloc.cypx3jljksqs.sa-east-1.rds.amazonaws.com;database=Fermaloc;user=fermaloc;password=fermaloc1337";
        var option = new DbContextOptionsBuilder<ApplicationDbContext>();
        option.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        context = new ApplicationDbContext(option.Options);
        bool connected;

        //Act
        try{
            connected = context.Database.CanConnect();
        }catch(Exception ex){
            throw new Exception("Não foi possivel conectao ao banco de dados");
        }

        //Assert
        Assert.True(connected);
    }
}
