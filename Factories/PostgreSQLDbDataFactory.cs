using ag.DbData.Abstraction;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System;

namespace ag.DbData.PostgreSQL.Factories
{
    /// <summary>
    /// Represents PostgreSQLDbDataFactory object.
    /// </summary>
    public class PostgreSQLDbDataFactory : IPostgreSQLDbDataFactory
    {
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// Creates object of type <see cref="PostgreSQLDbDataObject"/>.
        /// </summary>
        /// <returns><see cref="IDbDataObject"/> implementation of <see cref="PostgreSQLDbDataObject"/> interface.</returns>
        public IDbDataObject Create()
        {
            var dbObject = _serviceProvider.GetService<PostgreSQLDbDataObject>();
            return dbObject;
        }

        /// <summary>
        /// Creates object of type <see cref="PostgreSQLDbDataObject"/>.
        /// </summary>
        /// <param name="connectionString">Database connection string</param>.
        /// <returns><see cref="IDbDataObject"/> implementation of <see cref="PostgreSQLDbDataObject"/> interface.</returns>
        public IDbDataObject Create(string connectionString)
        {
            var dbObject = _serviceProvider.GetService<PostgreSQLDbDataObject>();
            dbObject.Connection = new NpgsqlConnection(connectionString);
            return dbObject;
        }
        
        /// <summary>
        /// Creates new PostgreSQLDbDataFactory object.
        /// </summary>
        /// <param name="serviceProvider"><see cref="IServiceProvider"/></param>
        public PostgreSQLDbDataFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
    }
}
