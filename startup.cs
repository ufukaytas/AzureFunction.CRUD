using System;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using CRUD.Function.Services;
using CRUD.Function.Data;


[assembly: FunctionsStartup(typeof(CRUD.Function.Startup))]
namespace CRUD.Function
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {

            var connectionString = Environment.GetEnvironmentVariable("SqlServerConnection");

            builder.Services.AddDbContext<DataContext>(x => 
            {
                x.UseSqlServer(connectionString
                , options=>options.EnableRetryOnFailure());
            });

            builder.Services.AddTransient<ICRUDService, CrudService>();

        }
    }



}
