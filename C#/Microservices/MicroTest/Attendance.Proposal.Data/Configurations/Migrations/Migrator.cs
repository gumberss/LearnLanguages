﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Attendance.Proposals.Data.Configurations.Migrations
{
    public static class Migrator
    {
        public static IHost Migrate<T>(this IHost webHost) where T : DbContext
        {
            using (var scope = webHost.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var db = services.GetRequiredService<T>();
                    db.Database.Migrate();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<DbContext>>();
                    logger.LogError(ex, "Database Creation/Migrations failed!");
                }
            }
            return webHost;
        }
    }
}
