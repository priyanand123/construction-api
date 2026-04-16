
using ConstructionBilling.Infrastructure.DatabaseConnection;
using ConstructionBilling.Infrastructure.Constants;
using Dapper;
using System.Data;
using ConstructionBilling.Domain.Entities;
using ConstructionBilling.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Net;
using System;

namespace ConstructionBilling.Infrastructure.Repositories
{
    /// <summary>
    /// Repository class for performing CRUD operations on purchaseDetail.
    /// </summary>
    public class PurchaseDetailRepository : IPurchaseDetailRepository
    {
        private readonly IDataBaseConnection _db;

        /// <summary>
        /// Initializes a new instance of the <see cref="PurchaseDetailRepository"/> class.
        /// </summary>
        /// <param name="_db">The database connection for accessing purchaseDetail data.</param>
        public PurchaseDetailRepository(IDataBaseConnection db)
        {
            this._db = db;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<PurchaseDetail>> GetPurchaseDetailsDetails(int? id)
        {
            var spName = ConstantSPnames.SP_GETAllPURCHASEDETAIL; // Update the stored procedure name if necessary
            return await Task.Factory.StartNew(() => _db.Connection.Query<PurchaseDetail>(spName,
                new { Id = id }, commandType: CommandType.StoredProcedure).ToList());
        }

        public async Task<PurchaseDetail> InsertPurchaseDetailDetails(PurchaseDetail purchaseDetail)
        {
            var spName = ConstantSPnames.SP_INSERTPURCHASEDETAIL; // Name of your stored procedure

            // Define parameters for the stored procedure
            var parameters = new
            {
                MaterialId = purchaseDetail.MaterialId,
                PurchaseDate = purchaseDetail.PurchaseDate,
                BillNo = purchaseDetail.BillNo,
                BillDate = purchaseDetail.BillDate,
                BrandName = purchaseDetail.BrandName,
                GstPercentage = purchaseDetail.GstPercentage,
                GstAmount = purchaseDetail.GstAmount,
                PurchaseCompany = purchaseDetail.PurchaseCompany,
                Address = purchaseDetail.Address,
                GstNo = purchaseDetail.GstNo,
                Website = purchaseDetail.Website,
                Email = purchaseDetail.Email,
                PhoneNo = purchaseDetail.PhoneNo,
                TransportDetails = purchaseDetail.TransportDetails,
                Quantity = purchaseDetail.Quantity,
                UnitId = purchaseDetail.UnitId,
                Amount = purchaseDetail.Amount,
                LoadingAndUnloadingCost = purchaseDetail.LoadingAndUnloadingCost,
                TotalCost = purchaseDetail.TotalCost,
                PaymentDetails = purchaseDetail.PaymentDetails,
                VehicleNo = purchaseDetail.VehicleNo,
                VehiclePhoneNo = purchaseDetail.VehiclePhoneNo,
                CreatedBy = purchaseDetail.CreatedBy,
                
            };

            // Execute the stored procedure and retrieve the inserted data
            var insertedData = await _db.Connection.QuerySingleOrDefaultAsync<PurchaseDetail>(
            spName,
            parameters,
                commandType: CommandType.StoredProcedure
            );

            return insertedData;


        }
        /// <inheritdoc/>
        public async Task UpdatePurchaseDetailDetails(PurchaseDetail purchaseDetail)
        {
            var spName = ConstantSPnames.SP_UPDATEPURCHASEDETAIL; // Update the stored procedure name if necessary

            var parameters = new
            {
                Id = purchaseDetail.Id,
                MaterialId = purchaseDetail.MaterialId,
                PurchaseDate = purchaseDetail.PurchaseDate,
                BillNo = purchaseDetail.BillNo,
                BillDate = purchaseDetail.BillDate,
                BrandName = purchaseDetail.BrandName,
                GstPercentage = purchaseDetail.GstPercentage,
                GstAmount = purchaseDetail.GstAmount,
                PurchaseCompany = purchaseDetail.PurchaseCompany,
                Address = purchaseDetail.Address,
                GstNo = purchaseDetail.GstNo,
                Website = purchaseDetail.Website,
                Email = purchaseDetail.Email,
                PhoneNo = purchaseDetail.PhoneNo,
                TransportDetails = purchaseDetail.TransportDetails,
                Quantity = purchaseDetail.Quantity,
                UnitId = purchaseDetail.UnitId,
                Amount = purchaseDetail.Amount,
                LoadingAndUnloadingCost = purchaseDetail.LoadingAndUnloadingCost,
                TotalCost = purchaseDetail.TotalCost,
                PaymentDetails = purchaseDetail.PaymentDetails,
                VehicleNo = purchaseDetail.VehicleNo,
                VehiclePhoneNo = purchaseDetail.VehiclePhoneNo,
                ModifiedBy = purchaseDetail.ModifiedBy,




            };
            await Task.Factory.StartNew(() =>
                _db.Connection.Execute(spName, parameters, commandType: CommandType.StoredProcedure));
        }

        public async Task<bool> DeletePurchaseDetailDetails(int id)
        {
            var spName = ConstantSPnames.SP_DELETEPURCHASEDETAIL; // Update the stored procedure name if necessary
            await Task.Factory.StartNew(() =>
                _db.Connection.Execute(spName, new { Id = id }, commandType: CommandType.StoredProcedure));
            return true;
        }
        public async Task<IEnumerable<PurchaseDetail>> GetPurchaseCompanList(string purchaseCompany)
        {
            var spName = ConstantSPnames.SP_GETPURCHASECOMPANYLIST; // Update the stored procedure name if necessary
            return await Task.Factory.StartNew(() => _db.Connection.Query<PurchaseDetail>(spName,
                new { @PurchaseCompany = purchaseCompany }, commandType: CommandType.StoredProcedure).ToList());
        }

    }
}
