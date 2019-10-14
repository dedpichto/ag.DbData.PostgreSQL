using ag.DbData.Abstraction;
using ag.DbData.Abstraction.Services;
using ag.DbData.PostgreSQL.Factories;
using ag.DbData.PostgreSQL.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ag.DbData.PostgreSQL.Extensions
{
    /// <summary>
    /// Represents <see cref="ag.DbData.PostgreSQL"/> extensions.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Appends the registration of <see cref="PostgreSQLDbDataFactory"/> and <see cref="PostgreSQLDbDataObject"/> services to <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
        /// <returns><see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddAgPostgreSQL(this IServiceCollection services)
        {
            services.AddSingleton<PostgreSQLStringProvider>();
            services.AddSingleton<IDbDataStringProviderFactory<PostgreSQLStringProvider>, PostgreSQLStringProviderFactory>();
            services.AddSingleton<IPostgreSQLDbDataFactory, PostgreSQLDbDataFactory>();
            services.AddTransient<PostgreSQLDbDataObject>();
            return services;
        }

        /// <summary>
        /// Appends the registration of <see cref="PostgreSQLDbDataFactory"/> and <see cref="PostgreSQLDbDataObject"/> services to <see cref="IServiceCollection"/> and registers a configuration instance.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
        /// <param name="configurationSection">The <see cref="IConfigurationSection"/> being bound.</param>
        /// <returns><see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddAgPostgreSQL(this IServiceCollection services, IConfigurationSection configurationSection)
        {
            services.AddAgPostgreSQL();
            services.Configure<DbDataSettings>(configurationSection);
            return services;
        }

        /// <summary>
        /// Appends the registration of <see cref="PostgreSQLDbDataFactory"/> and <see cref="PostgreSQLDbDataObject"/> services to <see cref="IServiceCollection"/> and configures the options.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
        /// <param name="configureOptions">The action used to configure the options.</param>
        /// <returns><see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddAgPostgreSQL(this IServiceCollection services,
            Action<DbDataSettings> configureOptions)
        {
            services.AddAgPostgreSQL();
            services.Configure(configureOptions);
            return services;
        }
    }
}
