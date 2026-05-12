
using ConstructionBilling.Infrastructure.DatabaseConnection;
using ConstructionBilling.Infrastructure.Constants;
using Dapper;
using System.Data;
using ConstructionBilling.Domain.Entities;
using ConstructionBilling.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Cryptography.Xml;
using System.Data.SqlClient;
using System.Drawing;
using Xceed.Words.NET;
using Newtonsoft.Json;
using Xceed.Document.NET;
using Humanizer;
using Newtonsoft.Json.Linq;
using System.Globalization;

namespace ConstructionBilling.Infrastructure.Repositories
{
    /// <summary>
    /// Repository class for performing CRUD operations on billing.
    /// </summary>
    public class BillingRepository : IBillingRepository
    {
        private readonly IDataBaseConnection _db;

        /// <summary>
        /// Initializes a new instance of the <see cref="BillingRepository"/> class.
        /// </summary>
        /// <param name="_db">The database connection for accessing billing data.</param>
        public BillingRepository(IDataBaseConnection db)
        {
            this._db = db;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Billings>> GetBillingsDetails(int? id)
        {
            var spName = ConstantSPnames.SP_GETAllBILLINGDETAIL; // Update the stored procedure name if necessary
            return await Task.Factory.StartNew(() => _db.Connection.Query<Billings>(spName,
                new { Id = id }, commandType: CommandType.StoredProcedure).ToList());
        }

        public async Task<Billings> InsertBillingDetails(Billings billing)
        {
            var spName = ConstantSPnames.SP_INSERTBILLINGDETAIL; // Name of your stored procedure
                                                                 // Define parameters for the stored procedure
            billing.TaxAmountInWords = ConvertAmountToWords(Convert.ToDecimal(billing.TaxableValue));
            billing.TotalAmountInWords = ConvertAmountToWords(Convert.ToDecimal(billing.TotalAmount));
            billing.TotalTaxAmountInWords = ConvertAmountToWords(Convert.ToDecimal(billing.TotalTaxAmount));
            // Convert the integer part of the decimal value to words

            var parameters = new
            {

                ConsigneeDetails = billing.ConsigneeDetails,
                InvoiceNo = billing.InvoiceNo,
                Dated = billing.Dated,
                DeliveryNote = billing.DeliveryNote,
                ModeTermsOfPayment = billing.ModeTermsOfPayment,
                ReferenceNo = billing.ReferenceNo,
                ReferenceDate = billing.ReferenceDate,
                OtherReferences = billing.OtherReferences,
                BuyersOrderNo = billing.BuyersOrderNo,
                CompanyGstNo = billing.CompanyGstNo,
                BuyersOrderNoDated = billing.BuyersOrderNoDated,
                DeliveryNoteDate = billing.DeliveryNoteDate,
                DispatchedThrough = billing.DispatchedThrough,
                Destination = billing.Destination,
                BillOfLading_LRRRNo = billing.BillOfLading_LRRRNo,
                HSNorSAC = billing.HSNorSAC,
                TotalQty = billing.TotalQty,
                TotalAmount = billing.TotalAmount,
                TaxAmountInWords = billing.TaxAmountInWords,
                TotalAmountInWords = billing.TotalAmountInWords,
                TotalTaxAmountInWords = billing.TotalTaxAmountInWords,
                CGSTAmount = billing.CGSTAmount,
                SGSTAmount = billing.SGSTAmount,
                TaxableValue = billing.TaxableValue,
                TotalTaxAmount = billing.TotalTaxAmount,
                MotorVehicleNo = billing.MotorVehicleNo,
                TermsOfDelivery = billing.TermsOfDelivery,
                GoodsInformation = billing.GoodsInformation,
                DeliveryManName = billing.DeliveryManName,
                DeliveryManPhoneNo = billing.DeliveryManPhoneNo,
                CreatedBy = billing.CreatedBy,
                IsGSTInclude = billing.IsGSTInclude,
                Buyer = billing.Buyer,



            };

            // Execute the stored procedure and retrieve the inserted data
            var insertedData = await _db.Connection.QuerySingleOrDefaultAsync<Billings>(
                spName,
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return insertedData;


        }
        /// <inheritdoc/>
        public async Task UpdateBillingDetails(Billings billing)
        {
            var spName = ConstantSPnames.SP_UPDATEBILLINGDETAIL; // Update the stored procedure name if necessary
            billing.TaxAmountInWords = ConvertAmountToWords(Convert.ToDecimal(billing.TaxableValue));
            billing.TotalAmountInWords = ConvertAmountToWords(Convert.ToDecimal(billing.TotalAmount));
            billing.TotalTaxAmountInWords = ConvertAmountToWords(Convert.ToDecimal(billing.TotalTaxAmount));

            var parameters = new
            {
                Id = billing.Id,
                ConsigneeDetails = billing.ConsigneeDetails,
                InvoiceNo = billing.InvoiceNo,
                Dated = billing.Dated,
                DeliveryNote = billing.DeliveryNote,
                ModeTermsOfPayment = billing.ModeTermsOfPayment,
                ReferenceNo = billing.ReferenceNo,
                ReferenceDate = billing.ReferenceDate,
                CompanyGstNo = billing.CompanyGstNo,
                OtherReferences = billing.OtherReferences,
                BuyersOrderNo = billing.BuyersOrderNo,
                BuyersOrderNoDated = billing.BuyersOrderNoDated,
                DispatchDocNo = billing.DispatchDocNo,
                DeliveryNoteDate = billing.DeliveryNoteDate,
                DispatchedThrough = billing.DispatchedThrough,
                Destination = billing.Destination,
                BillOfLading_LRRRNo = billing.BillOfLading_LRRRNo,
                HSNorSAC = billing.HSNorSAC,
                TotalQty = billing.TotalQty,
                TotalAmount = billing.TotalAmount,
                TaxAmountInWords = billing.TaxAmountInWords,
                TotalAmountInWords = billing.TotalAmountInWords,
                TotalTaxAmountInWords = billing.TotalTaxAmountInWords,
                CGSTAmount = billing.CGSTAmount,
                SGSTAmount = billing.SGSTAmount,
                TaxableValue = billing.TaxableValue,
                TotalTaxAmount = billing.TotalTaxAmount,
                MotorVehicleNo = billing.MotorVehicleNo,
                TermsOfDelivery = billing.TermsOfDelivery,
                GoodsInformation = billing.GoodsInformation,
                DeliveryManName = billing.DeliveryManName,
                DeliveryManPhoneNo = billing.DeliveryManPhoneNo,
                ModifiedBy = billing.ModifiedBy,
                IsGSTInclude= billing.IsGSTInclude,
                Buyer = billing.Buyer,


            };
            await Task.Factory.StartNew(() =>
                _db.Connection.Execute(spName, parameters, commandType: CommandType.StoredProcedure));
        }

        public async Task<bool> DeleteBillingDetails(int id)

        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid invoice ID");
            }
            var spName = ConstantSPnames.SP_DELETEBILLINGDETAIL; // Update the stored procedure name if necessary
            await Task.Factory.StartNew(() =>
                _db.Connection.Execute(spName, new { Id = id }, commandType: CommandType.StoredProcedure));
            return true;
        }
        public string DownloadInvoice(int id)
        {
            string column = string.Empty;
            var spName = ConstantSPnames.SP_GETAllBILLINGDETAIL;
            string strfilepath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "invoice.docx");
            DataTable ds = new DataTable();
            var con = "Data Source=SQL5111.site4now.net;Initial Catalog=db_a85a40_tptserverdb;User Id=db_a85a40_tptserverdb_admin;Password=Lore@123";

            // var con = "Data Source=SQL5109.site4now.net;Initial Catalog=db_a85a40_sona;User Id=db_a85a40_sona_admin;Password=Lore@123";
            // var con = "Data Source=SQL8001.site4now.net;Initial Catalog=db_a85a40_loreconstruction;User Id=db_a85a40_loreconstruction_admin;Password=Lore@123";
            // var con = "Data Source=SQL8001.site4now.net;Initial Catalog=db_a85a40_loreconstruction;User Id=db_a85a40_loreconstruction_admin;Password=Lore@123";
            using (SqlConnection myConnection = new SqlConnection(con))
            {
                myConnection.Open();
                SqlCommand command = new SqlCommand(spName, myConnection);
                command.CommandType = CommandType.StoredProcedure; command.Parameters.Add("Id", SqlDbType.Int).Value = id; command.ExecuteNonQuery();
                using (var da = new SqlDataAdapter(command))
                {
                    da.Fill(ds);
                }
            }

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Template");
            var files = Directory.GetFiles(Path.Combine(filePath)).ToList();
            var doc = DocX.Load(files.Find(x => Path.GetFileName(x) == "Invoice.docx"));
            var row = ds.Rows[0].ItemArray;
            var col = ds.Columns;
            for (int i = 0; i < ds.Columns.Count; i++)
            {
                System.Diagnostics.Debug.WriteLine(i + " -> " + ds.Columns[i].ColumnName + " = " + row[i]);
            }
            var signPath = Path.Combine(Directory.GetCurrentDirectory(), "Signature");
         
            
            for (int i = 0; i < row.Count(); i++)
            {
                if (i == 3 || i == 7 || i == 10 || i == 12)
                {
                    if (DateTime.TryParse(row[i].ToString(), out DateTime dateValue))
                    {
                        // Format the date as "dd-MM-yyyy"
                        row[i] = dateValue.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    }
                }
                if (i == 28)
                {
                    var items = JsonConvert.DeserializeObject<List<GoodsDetails>>(row[28].ToString());
                    // var cgstPercent = Math.Round((decimal)(items?.Sum(i => i.Amount) * Convert.ToDecimal(row[53])) / 100, 2);
                    //  var sgstPercent = Math.Round((decimal)((items?.Sum(i => i.Amount) * Convert.ToDecimal(row[54])) / 100), 2);
                    var cgstPercent = Math.Round((decimal)(items?.Sum(i => i.Amount) * Convert.ToDecimal(row[52])) / 100, 2);
                    var sgstPercent = Math.Round((decimal)((items?.Sum(i => i.Amount) * Convert.ToDecimal(row[53])) / 100), 2);
                    doc.InsertParagraph();
                    Table t = doc.AddTable(items.Count + 4, 7);
                    t.Alignment = Alignment.center;
                    t.Rows[0].Cells[0].Paragraphs.First().Append("S.No").Font(new Xceed.Document.NET.Font("Arial")).FontSize(10);
                    t.SetWidths(new float[] { 35, 400, 160, 60, 100, 100, 120 });
                    t.Rows[0].Cells[1].Paragraphs.First().Append("Description of Goods").Font(new Xceed.Document.NET.Font("Arial")).FontSize(10);
                    t.Rows[0].Cells[2].Paragraphs.First().Append("HSN or SAC").Font(new Xceed.Document.NET.Font("Arial")).FontSize(10);
                    t.Rows[0].Cells[3].Paragraphs.First().Append("Qty").Font(new Xceed.Document.NET.Font("Arial")).FontSize(10);
                    t.Rows[0].Cells[4].Paragraphs.First().Append("Rate").Font(new Xceed.Document.NET.Font("Arial")).FontSize(10);
                    t.Rows[0].Cells[5].Paragraphs.First().Append("Per").Font(new Xceed.Document.NET.Font("Arial")).FontSize(10);
                    t.Rows[0].Cells[6].Paragraphs.First().Append("Amount").Font(new Xceed.Document.NET.Font("Arial")).FontSize(10);


                    for (int k = 0; k < items.Count; k++)
                    {
                        t.Rows[k + 1].Cells[0].Paragraphs.First().Append(items[k].SNo.ToString());
                        t.SetWidths(new float[] { 35, 400, 160, 60, 100, 100, 120 });
                        //{ 35, 300, 120, 130, 120 });
                        t.Rows[k + 1].Cells[1].Paragraphs.First().Append(items[k].DescriptionOfGoods == null ? "" : items[k].DescriptionOfGoods.ToString()).Font(new Xceed.Document.NET.Font("Arial")).FontSize(10);
                        t.Rows[k + 1].Cells[2].Paragraphs.First().Append(items[k].hsnsac == 0 ? "" : items[k].hsnsac.ToString()).Font(new Xceed.Document.NET.Font("Arial")).FontSize(10);
                        t.Rows[k + 1].Cells[3].Paragraphs.First().Append(items[k].Quantity.ToString()).Font(new Xceed.Document.NET.Font("Arial")).FontSize(10);
                        t.Rows[k + 1].Cells[4].Paragraphs.First().Append(items[k].Rate.ToString()).Font(new Xceed.Document.NET.Font("Arial")).FontSize(10);
                        t.Rows[k + 1].Cells[5].Paragraphs.First().Append(((items[k].Per == null) ? "0" : items[k].Per).ToString()).Font(new Xceed.Document.NET.Font("Arial")).FontSize(10);
                        t.Rows[k + 1].Cells[6].Paragraphs.First().Append(items[k].Amount.ToString()).Font(new Xceed.Document.NET.Font("Arial")).FontSize(10);
                    }
                    doc.ReplaceText("<hsnsac>", items[0].hsnsac == null ? "" : items[0].hsnsac.ToString());

                    int LastRow = items.Count + 1;
                    t.Rows[LastRow].Cells[1].Paragraphs.First().Append("CGST @").Font(new Xceed.Document.NET.Font("Arial")).FontSize(10);
                    t.Rows[LastRow].Cells[4].Paragraphs.First().Append(row[52].ToString()).FontSize(10);
                    t.Rows[LastRow].Cells[5].Paragraphs.First().Append("%").FontSize(10);
                    t.Rows[LastRow].Cells[6].Paragraphs.First().Append(cgstPercent.ToString()).FontSize(10);
                    t.Rows[++LastRow].Cells[1].Paragraphs.First().Append("SGST @").Font(new Xceed.Document.NET.Font("Arial")).FontSize(10);
                    t.Rows[LastRow].Cells[4].Paragraphs.First().Append(row[53].ToString()).FontSize(10);
                    t.Rows[LastRow].Cells[5].Paragraphs.First().Append("%").FontSize(10);
                    t.Rows[LastRow].Cells[6].Paragraphs.First().Append(sgstPercent.ToString()).FontSize(10);
                    t.Rows[++LastRow].Cells[1].Paragraphs.First().Append("Total").Font(new Xceed.Document.NET.Font("Arial")).FontSize(10);
                    t.Rows[LastRow].Cells[3].Paragraphs.First().Append(items.Sum(i => i.Quantity).ToString()).FontSize(10);
                    t.Rows[LastRow].Cells[6].Paragraphs.First().Append((items.Sum(i => i.Amount)+cgstPercent+sgstPercent).ToString()).FontSize(10);
                    //doc.InsertTable(t);
                    doc.ReplaceTextWithObject("<Table>", t);
                }
                else
                {
                    var formatcolumn = "<" + col[i] + ">";
                    doc.ReplaceText(formatcolumn, row[i].ToString());
                }
            }
            doc.AddProtection(EditRestrictions.readOnly);
            doc.SaveAs(strfilepath);
            //var docp = new Aspose.Words.Document("Input.docx");
            // docp.Save("Output.pdf");
            return strfilepath;
        }
        public string DownloadPaymentVoucher(int id)
        {
            string column = string.Empty;
            var spName = ConstantSPnames.SP_GETAllBILLINGDETAIL;
            string strfilepath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "paymentVoucher.docx");
            DataTable ds = new DataTable();
            //var con = "Data Source=SQL5109.site4now.net;Initial Catalog=db_ab072a_jkbbrickingnew;User Id=db_ab072a_jkbbrickingnew_admin;Password=Lore@123";
            // var con = "Data Source=SQL8001.site4now.net;Initial Catalog=db_a85a40_loreconstruction;User Id=db_a85a40_loreconstruction_admin;Password=Lore@123";
            var con = "Data Source=SQL5111.site4now.net;Initial Catalog=db_a85a40_tptserverdb;User Id=db_a85a40_tptserverdb_admin;Password=Lore@123";

            //var con = "Data Source=SQL5109.site4now.net;Initial Catalog=db_a85a40_sona;User Id=db_a85a40_sona_admin;Password=Lore@123";

            using (SqlConnection myConnection = new SqlConnection(con))
            {
                myConnection.Open();
                SqlCommand command = new SqlCommand(spName, myConnection);
                command.CommandType = CommandType.StoredProcedure; command.Parameters.Add("Id", SqlDbType.Int).Value = id; command.ExecuteNonQuery();
                using (var da = new SqlDataAdapter(command))
                {
                    da.Fill(ds);
                }
            }

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Template");
            var files = Directory.GetFiles(Path.Combine(filePath)).ToList();
            var doc = DocX.Load(files.Find(x => Path.GetFileName(x) == "PaymentVoucher.docx"));
            var row = ds.Rows[0].ItemArray;
            var col = ds.Columns;
            var signPath = Path.Combine(Directory.GetCurrentDirectory(), "Signature");


            for (int i = 0; i < row.Count(); i++)
            {


                if (i == 18)
                {
                    decimal value = Convert.ToDecimal(row[18]);

                    // Convert the integer part of the decimal value to words
                    int integerPart = (int)Math.Floor(value);

                    // Combine integer part to words and fractional part if exists
                    string result = $"{integerPart.ToWords()} {(value % 1 != 0 ? "point " + ((int)((value % 1) * 100)).ToWords() : "")}";

                    // Capitalize the first letter of the result
                    row[20] = char.ToUpper(result[0]) + result.Substring(1);

                }
                if (i == 3)
                {
                    DateTime dateValue;

                    // Try to parse the value in row[3] as a DateTime
                    if (DateTime.TryParse(row[3].ToString(), out dateValue))
                    {
                        // Format the date as "dd-MM-yyyy"
                        row[3] = dateValue.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    }
                }
                var formatcolumn = "<" + col[i] + ">";
                doc.ReplaceText(formatcolumn, row[i].ToString());

            }
            doc.AddProtection(EditRestrictions.readOnly);
            doc.SaveAs(strfilepath);
            //var docp = new Aspose.Words.Document("Input.docx");
            // docp.Save("Output.pdf");
            return strfilepath;
        }

        public string DownloadDeliveryChallen(int id)
        {
            string column = string.Empty;
            var spName = ConstantSPnames.SP_GETAllBILLINGDETAIL;
            string strfilepath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "deliveryChallan.docx");
            DataTable ds = new DataTable();
            // var con = "Data Source=SQL5109.site4now.net;Initial Catalog=db_ab072a_jkbbrickingnew;User Id=db_ab072a_jkbbrickingnew_admin;Password=Lore@123";

            var con = "Data Source=SQL5111.site4now.net;Initial Catalog=db_a85a40_tptserverdb;User Id=db_a85a40_tptserverdb_admin;Password=Lore@123";

            //  var con = "Data Source=SQL5109.site4now.net;Initial Catalog=db_a85a40_sona;User Id=db_a85a40_sona_admin;Password=Lore@123";
            using (SqlConnection myConnection = new SqlConnection(con))
            {
                myConnection.Open();
                SqlCommand command = new SqlCommand(spName, myConnection);
                command.CommandType = CommandType.StoredProcedure; command.Parameters.Add("Id", SqlDbType.Int).Value = id; command.ExecuteNonQuery();
                using (var da = new SqlDataAdapter(command))
                {
                    da.Fill(ds);
                }
            }

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Template");
            var files = Directory.GetFiles(Path.Combine(filePath)).ToList();
            var doc = DocX.Load(files.Find(x => Path.GetFileName(x) == "DeliveryChallan.docx"));
            var row = ds.Rows[0].ItemArray;
            var col = ds.Columns;
            var signPath = Path.Combine(Directory.GetCurrentDirectory(), "Signature");


            for (int i = 0; i < row.Count(); i++)
            {
                if (i == 28)
                {
                    var items = JsonConvert.DeserializeObject<List<GoodsDetails>>(row[28].ToString());
                    doc.InsertParagraph();
                    Table t = doc.AddTable(items.Count + 1, 4);
                    t.Alignment = Alignment.center;
                    t.SetWidths(new float[] { 50, 300, 100, 120 });
                    t.Rows[0].Cells[0].Paragraphs.First().Append("S.No").Font(new Xceed.Document.NET.Font("Arial")).FontSize(10);
                    t.Rows[0].Cells[1].Paragraphs.First().Append("Particulars").Font(new Xceed.Document.NET.Font("Arial")).FontSize(10);

                    t.Rows[0].Cells[2].Paragraphs.First().Append("Quantity").Font(new Xceed.Document.NET.Font("Arial")).FontSize(10);
                    t.Rows[0].Cells[3].Paragraphs.First().Append("Amount").Font(new Xceed.Document.NET.Font("Arial")).FontSize(10);

                    for (int k = 0; k < items.Count; k++)
                    {
                        t.Rows[k + 1].Cells[0].Paragraphs.First().Append(items[k].SNo.ToString());
                        t.SetWidths(new float[] { 35, 350,110 });
                        //{ 35, 300, 120, 130, 120 });
                        t.Rows[k + 1].Cells[1].Paragraphs.First().Append(items[k].DescriptionOfGoods == null ? "" : items[k].DescriptionOfGoods.ToString()).Font(new Xceed.Document.NET.Font("Arial")).FontSize(10);
                        t.Rows[k + 1].Cells[2].Paragraphs.First().Append(items[k].Quantity.ToString()).Font(new Xceed.Document.NET.Font("Arial")).FontSize(10);
                        t.Rows[k + 1].Cells[3].Paragraphs.First().Append(items[k].Amount.ToString()).Font(new Xceed.Document.NET.Font("Arial")).FontSize(10);
                    }

                    //doc.InsertTable(t);
                    doc.ReplaceTextWithObject("<Table>", t);
                }

                if (i == 18)
                {
                    decimal value = Convert.ToDecimal(row[18]);                  

                    // Capitalize the first letter of the result
                    row[20] = ConvertAmountToWords(value);

                }
                if (i == 12)
                {
                    DateTime dateValue;

                    // Try to parse the value in row[3] as a DateTime
                    if (DateTime.TryParse(row[12].ToString(), out dateValue))
                    {
                        // Format the date as "dd-MM-yyyy"
                        row[12] = dateValue.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    }
                }
                var formatcolumn = "<" + col[i] + ">";
                doc.ReplaceText(formatcolumn, row[i].ToString());

            }
            doc.AddProtection(EditRestrictions.readOnly);
            doc.SaveAs(strfilepath);
            //var docp = new Aspose.Words.Document("Input.docx");
            // docp.Save("Output.pdf");
            return strfilepath;
        }
        private static string ConvertAmountToWords(decimal num)
        {
            // Convert the integer part of the decimal value to words
            int integerPart = (int)Math.Floor(num);

            // Combine integer part to words and fractional part if exists
            string result = $"{integerPart.ToWords()} {(num % 1 != 0 ? "point " + ((int)((num % 1) * 100)).ToWords() : "")}";

            // Capitalize the first letter of the result
            result = char.ToUpper(result[0]) + result.Substring(1)+ " only/-";
            return result;
        }
        public async Task<IEnumerable<Billings>> GetConsigneeList(string consigneeList)
        {
            var spName = ConstantSPnames.SP_GETCONSIGNEELIST; // Update the stored procedure name if necessary
            return await Task.Factory.StartNew(() => _db.Connection.Query<Billings>(spName,
                new { @ConsigneeList = consigneeList }, commandType: CommandType.StoredProcedure).ToList());
        }
    }
}
    

    
