using System.Data;

namespace ConstructionBilling.Infrastructure.DatabaseConnection
{
    public interface IDataBaseConnection
    {
        IDbConnection Connection { get; }
    }
}
