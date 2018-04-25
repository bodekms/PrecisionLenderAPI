using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebApplication1.DAL
{
    public class ApiInitializer : DropCreateDatabaseIfModelChanges<ApiContext>
    {
        protected override void Seed(ApiContext context)
        {
            //add test data to database
            var apis = new List<Models.API>
            {
                new Models.API { ID=1,Name="Provider A", Url="https://dev.providerA.com/api/getData" },
                new Models.API { ID=2,Name="Provider B", Url="https://www.providerB.com/api/getData" },
                new Models.API { ID=3,Name="Provider C", Url="https://api.providerC.com/lending/getData" },
                new Models.API { ID=4,Name="Provider D", Url="https://my.providerD.com/api/getData" }
            };
            apis.ForEach(a => context.APIs.Add(a));
            context.SaveChanges();
        }
    }
}