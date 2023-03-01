using Microsoft.Data.SqlClient;
using System.Data;

namespace AddressBookApp.Context
{
	public interface IDapperContext
	{
		IDbConnection Connection { get; }
		string _connectionString { get; set; }
	}

	public class DapperContext : IDapperContext
	{
		public string _connectionString { get; set; }
		private IDbConnection _connection;

		public DapperContext(IConfiguration configuration)
		{
			_connectionString = configuration.GetConnectionString("SQLConnection");
		}
		public IDbConnection Connection
		{
			get
			{
				if (_connection == null)
				{
					_connection = new SqlConnection(_connectionString);
				}
				return _connection;
			}
		}
	}
}