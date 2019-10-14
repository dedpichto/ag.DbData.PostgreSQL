using ag.DbData.Abstraction.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ag.DbData.PostgreSQL.Services
{
    /// <summary>
    /// Represents <see cref="PostgreSQLStringProviderFactory"/> object.
    /// </summary>
    public class PostgreSQLStringProviderFactory : IDbDataStringProviderFactory<PostgreSQLStringProvider>
    {
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// Creates new instance of <see cref="PostgreSQLStringProviderFactory"/>.
        /// </summary>
        /// <param name="serviceProvider"><see cref="IServiceProvider"/>.</param>
        public PostgreSQLStringProviderFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// Creates object of type <see cref="PostgreSQLStringProvider"/>.
        /// </summary>
        /// <returns>Object of type <see cref="PostgreSQLStringProvider"/>.</returns>
        public PostgreSQLStringProvider Get()
        {
            return _serviceProvider.GetService<PostgreSQLStringProvider>();
        }
    }
}
