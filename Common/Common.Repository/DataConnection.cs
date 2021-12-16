using System.Data;
using System.Data.SqlClient;

namespace Common.Repository
{
    public class DataConnection : IDataConnection
    {
        private SqlConnection Connection { get; set; }
        public IDbConnection CreateConnection(string connection)
        {
            Connection = new SqlConnection(connection);
            return this.Connection;
        }
    }
}