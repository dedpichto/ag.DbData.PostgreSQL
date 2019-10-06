using System;
using ag.DbData.Abstraction;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;

namespace ag.DbData.PostgreSQL.Factories
{
    /// <summary>
    /// Represents OracleDbDataFactory object.
    /// </summary>
    public class PostgreSQLDbDataFactory : IPostgreSQLDbDataFactory
    {
        private readonly IServiceProvider _serviceProvider;

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
        /// Creates new OracleDbDataFactory object.
        /// </summary>
        /// <param name="serviceProvider"><see cref="IServiceProvider"/></param>
        public PostgreSQLDbDataFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
    }
}
