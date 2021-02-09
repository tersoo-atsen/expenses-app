using Expenses.Data.Access.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Expenses.IoC
{
  public static class ServiceExtensions
  {
    public static void Setup(IServiceCollection services, IConfiguration configuration)
    {
      AddUow(services, configuration);
    }

    private static void AddUow(IServiceCollection services, IConfiguration configuration)
    {
      var connectionString = configuration.GetConnectionString("Default");

      services.AddDbContext<ExpensesAppDbContext>(options => options.UseSqlServer(connectionString));
    }
  }
}