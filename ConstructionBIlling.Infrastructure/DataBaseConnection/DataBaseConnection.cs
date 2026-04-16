using System.Data;
using System.Data.SqlClient;
using ConstructionBilling.Infrastructure.DatabaseConnection;
using Microsoft.Extensions.Options;

namespace ConstructionBilling.Infrastructure.DatabaseConnection
{
    public sealed class DataBaseConnection : IDataBaseConnection
    {
        public DataBaseConnection(IOptions<ConnectionStrings> connectionStrings)
        {
            Connection = new SqlConnection(connectionStrings.Value.DbConnection);
        }
        public IDbConnection Connection { get; }
    }
}
