
using ConstructionBilling.Infrastructure.DatabaseConnection;
using ConstructionBilling.Infrastructure.Constants;
using Dapper;
using System.Data;
using ConstructionBilling.Domain.Entities;
using ConstructionBilling.Infrastructure.Interfaces;

namespace ConstructionBilling.Infrastructure.Repositories
{
    /// <summary>
    /// Repository class for performing CRUD operations on attachment.
    /// </summary>
    public class AttachmentRepository : IAttachmentRepository
    {
        private readonly IDataBaseConnection _db;

        /// <summary>
        /// Initializes a new instance of the <see cref="AttachmentRepository"/> class.
        /// </summary>
        /// <param name="_db">The database connection for accessing attachment data.</param>
        public AttachmentRepository(IDataBaseConnection db)
        {
            this._db = db;
        }

        /// <inheritdoc/>
     
        public Task<string> UpdateFilepathdata(string target, int id, string filesList, string TypeofFile)
        {
            var spName = ConstantSPnames.SP_UPDATEFILE;

            return Task.Factory.StartNew(() => _db.Connection.Query<string>(spName,
                new { Id = id, filepath = target, files = filesList, typeofFile = TypeofFile },
                commandType: CommandType.StoredProcedure).ToString());
        }


    }
}
