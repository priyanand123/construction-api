using ConstructionBilling.Infrastructure.DatabaseConnection;
using ConstructionBilling.Infrastructure.Constants;
using Dapper;
using System.Data;
using ConstructionBilling.Domain.Entities;
using ConstructionBilling.Infrastructure.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ConstructionBilling.Infrastructure.Repositories
{
    /// <summary>
    /// Repository class for performing operations on machine log details.
    /// </summary>
    public class CompanyDetailsRepository : ICompanyDetailsRepository
    {
        private readonly IDataBaseConnection _db;

        /// <summary>
        /// Initializes a new instance of the <see cref="CompanyDetailsRepository"/> class.
        /// </summary>
        /// <param name="db">The database connection for accessing machine log detail data.</param>
        public CompanyDetailsRepository(IDataBaseConnection db)
        {
            this._db = db;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<CompanyDetails>> GetCompanyDetails(int? id)
        {
            var spName = ConstantSPnames.SP_GETAllCOMPANYDETAILS; // Name of your stored procedure for fetching machine log details
            return await Task.Factory.StartNew(() =>
                _db.Connection.Query<CompanyDetails>(spName, new { Id = id }, commandType: CommandType.StoredProcedure).ToList());
        }
        public async Task UpdateCompanyDetails(CompanyDetails companyDetails)
        {
            var spName = ConstantSPnames.SP_UPDATECOMPANYDETAILS;

            var parameters = new
            {

                Id = companyDetails.Id,
                CompanyName = companyDetails.CompanyName,
                Address = companyDetails.Address,
                Manufacturersof = companyDetails.Manufacturersof,
                MobileNo1 = companyDetails.MobileNo1,
                MobileNo2 = companyDetails.MobileNo2,
                Email = companyDetails.Email,
                Website = companyDetails.Website,
                GSTIN = companyDetails.GSTIN,
                BankName = companyDetails.BankName,
                AccountHolderName = companyDetails.AccountHolderName,

                AccountNo = companyDetails.AccountNo,

                HsnSac =companyDetails.HsnSac,

                Branch = companyDetails.Branch,
                IFSECode = companyDetails.IFSECode,
                UpiId1 = companyDetails.UpiId1,
                UpiId2 = companyDetails.UpiId2,
                CGSTPercentage = companyDetails.CGSTPercentage,
                SGSTorUTGSTPercentage = companyDetails.SGSTorUTGSTPercentage,
                ModifiedBy = companyDetails.ModifiedBy,

            };
            await Task.Factory.StartNew(() =>
                _db.Connection.Execute(spName, parameters, commandType: CommandType.StoredProcedure));
        }
    }
}
