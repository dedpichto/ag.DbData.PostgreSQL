
// add section to settings file (optional)
{
  "PostgreSQLDbDataSettings": {
    "AllowExceptionLogging": false, // optional, default is "true"
    "ConnectionString": "YOUR_CONNECTION_STRING" // optional
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
		services.AddAgPostgreSQL(config.GetSection("PostgreSQLDbDataSettings"));
		// or
		services.AddAgPostgreSQL(opts =>
        {
            opts.AllowExceptionLogging = false; // optional
			opts.ConnectionString = YOUR_CONNECTION_STRING; // optional 
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

// in case you have defined connection string in configuration setting you may call Create() method
// without parameter

        using (var postgreSQLDbData = _postgreSQLFactory.Create())
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