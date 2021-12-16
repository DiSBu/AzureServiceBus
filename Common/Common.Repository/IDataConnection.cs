using System.Data;

namespace Common.Repository
{
    public interface IDataConnection
    {
        IDbConnection CreateConnection(string connection);
    }
}