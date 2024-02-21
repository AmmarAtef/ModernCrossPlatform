using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Northwind.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Common.EntityModels.SqlServer.Model
{
    public static class NorthwindContextExtensions
    {
        public static IServiceCollection AddNorthwindContext(this IServiceCollection services,
            string connectionString = "Data Source=.;Initial Catalog=Northwind;" +
            "Integrated Security=true;MultipleActiveResultsets=true;")
        {
            services.AddDbContext<NorthwindContext>(opt =>
            {
                opt.UseSqlServer(connectionString);
            });
            return services;
        }
    }
}
