using ChatRoom.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

namespace ChatRoom.Web.Extensions
{
    public static class DatabaseInitializer
    {
        public static IApplicationBuilder DatabaseMigrateSeed(this IApplicationBuilder appBuilder)
        {
            using (var dbContext = new DesignTimeDbContextFactory().CreateDbContext(new string[0]))
            {
                dbContext.Database.Migrate();
            }

            return appBuilder;
        }
    }
}