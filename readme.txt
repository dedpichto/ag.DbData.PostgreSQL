
// add section to settings file (optional)
{
  "DbDataSettings": {
    "AllowExceptionLogging": false // default is "true" 
  }
}

***************************************************************************************************

// add appropriate usings
using ag.DbData.PostgreSQL.Extensions;
using ag.DbData.PostgreSQL.Factories;

***************************************************************************************************

// register services with extension method

		// ...
		services.AddAgPostgreSQL();
		// or
		services.AddAgPostgreSQL(config.GetSection("DbDataSettings"));
		// or
		services.AddAgPostgreSQL(opts =>
        {
            opts.AllowExceptionLogging = false; 
        });

***************************************************************************************************

// inject IPostgreSQLDbDataFactory into your classes

        private readonly IPostgreSQLDbDataFactory _postgreSQLFactory;

        public MyClass(IPostgreSQLDbDataFactory postgreSQLFactory)
        {
            _postgreSQLFactory = postgreSQLFactory;
        }

***************************************************************************************************

// PostgreSQLDbDataObject implements IDisposable interface, so use it into 'using' directive

        using (var postgreSQLDbData = _postgreSQLFactory.Create(YOUR_CONNECTION_STRING))
        {
            using (var t = postgreSQLDbData.FillDataTable("SELECT * FROM YOUR_TABLE"))
            {
                foreach (DataRow r in t.Rows)
                {
                    Console.WriteLine(r[0]);
                }
            }
        }

***************************************************************************************************