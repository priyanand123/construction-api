using System;
namespace ConstructionBilling.Infrastructure.Constants
{
    public static class ConstantSPnames
    {

        public const string SP_GETAllMATERIALS = "sp_GetRawMaterialDetails";
        public const string SP_INSERTMATERIAL = "sp_InsertRawMaterialDetails";
        public const string SP_UPDATEMATERIAL = "sp_UpdateRawMaterialDetails";
        public const string SP_DELETEMATERIAL = "sp_DeleteRawMaterialDetails";

        public const string SP_GETAllLABOUR = "sp_GetLabourDetails";
        public const string SP_INSERTLABOUR= "sp_InsertLabourDetails";
        public const string SP_UPDATELABOUR = "sp_UpdateLabourDetails";
        public const string SP_DELETELABOUR = "sp_DeleteLabourDetails";


        public const string SP_GETAllUNIT = "sp_GetUnitsDetails";
        public const string SP_INSERTUNIT = "sp_InsertUnitDetails";
        public const string SP_UPDATEUNIT = "sp_UpdateUnitsDetails";
        public const string SP_DELETEUNIT = "sp_DeleteUnitsDetails";

        public const string SP_GETAllDIESEL = "sp_GetDieselAndMaintenanceDetails";
        public const string SP_INSERTDIESEL = "sp_InsertDieselAndMaintenanceDetails";
        public const string SP_UPDATEDIESEL = "sp_UpdateDieselAndMaintenanceDetails";
        public const string SP_DELETEDIESEL = "sp_DeleteDieselAndMaintenanceDetails";

        public const string SP_GETAllTRIP = "sp_gettripDetails";
        public const string SP_INSERTTRIP = "sp_inserttripDetails";
        public const string SP_UPDATETRIP = "sp_updatetripDetails";
        public const string SP_DELETETRIP = "sp_deletetripDetails";


        public const string SP_GETAllPURCHASEDETAIL = "sp_GetPurchaseDetails";
        public const string SP_INSERTPURCHASEDETAIL = "sp_InsertPurchaseDetails";
        public const string SP_UPDATEPURCHASEDETAIL = "sp_UpdatePurchaseDetails";
        public const string SP_DELETEPURCHASEDETAIL = "sp_DeletePurchaseDetails";
        public const string SP_GETPURCHASECOMPANYLIST = "sp_GetPurchaseCompanyList";

        public const string SP_GETAllROLEDETAIL = "sp_GetRoleDetails";
        public const string SP_INSERTROLEDETAIL = "sp_InsertRoleDetails";
        public const string SP_UPDATEROLEDETAIL = "sp_UpdateRoleDetails";
        public const string SP_DELETEROLEDETAIL = "sp_DeleteRoleDetails";


        public const string SP_GETAllSTOCK = "sp_GetStockDetails";
        public const string SP_INSERTSTOCK = "sp_InsertStockDetails";
        public const string SP_UPDATESTOCK = "[sp_UpdateStockDetails]";
        public const string SP_DELETESTOCK = "sp_DeleteStocksDetails";

        public const string SP_GETAllMATERIALHISTORY = "sp_GetMaterialHistoryDetails";

        public const string SP_GETAllMACHINELOGDETAIL = "sp_GetMachineLogDetails";
        public const string SP_INSERTMACHINELOGDETAIL = "sp_InsertMachineLogDetails";
        public const string SP_UPDATEMACHINELOGDETAIL = "sp_UpdateMachineLogDetails"; 
        public const string SP_DELETEMACHINELOGDETAIL = "[sp_DeleteMachineLogDetails]";

        public const string SP_UPDATEFILE = "sp_UploadFile";
        public const string SP_UPDATEPASSWORD = "sp_UpdatePassword";


        public const string SP_GETAllBILLINGDETAIL = "[sp_GetBillingDetails]";
        public const string SP_INSERTBILLINGDETAIL = "[sp_InsertBillingDetails]";
        public const string SP_UPDATEBILLINGDETAIL = "sp_UpdateBillingDetails";
        public const string SP_DELETEBILLINGDETAIL = "sp_DeleteBillingDetails";
        public const string SP_GETCONSIGNEELIST = "[sp_GetConsigneeList]";

        public const string SP_GETAllCOMPANYDETAILS = "sp_GetCompanyDetails";

        public const string SP_GETAllBILLINGDETAILSWITHOUTGST = "[sp_GetBillingDetailsWithoutGST]";

        public const string SP_UPDATECOMPANYDETAILS = "sp_UpdateCompanyDetails";
    }
}

