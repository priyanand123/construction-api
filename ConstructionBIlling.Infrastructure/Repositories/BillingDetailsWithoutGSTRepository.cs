using ConstructionBilling.Infrastructure.DatabaseConnection;
using ConstructionBilling.Infrastructure.Constants;
using Dapper;
using System.Data;
using ConstructionBilling.Domain.Entities;
using ConstructionBilling.Infrastructure.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Drawing;
using Xceed.Document.NET;
using Xceed.Words.NET;
using System.Globalization;

namespace ConstructionBilling.Infrastructure.Repositories
{
    /// <summary>
    /// Repository class for performing operations on BillingDetailsWithoutGSTDetail.
    /// </summary>
    public class BillingDetailsWithoutGSTRepository : IBillingDetailsWithoutGSTRepository
    {
        private readonly IDataBaseConnection _db;

        /// <summary>
        /// Initializes a new instance of the <see cref="BillingDetailsWithoutGSTDetailRepository"/> class.
        /// </summary>
        /// <param name="db">The database connection for accessing machineLogDetail data.</param>
        public BillingDetailsWithoutGSTRepository(IDataBaseConnection db)
        {
            this._db = db;
        }

        public Task GetBillingDetailsWithoutGST(int? id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<BillingDetailsWithoutGST>> GetBillingDetailsWithoutGSTDetails(int? id)
        {
            var spName = ConstantSPnames.SP_GETAllBILLINGDETAILSWITHOUTGST; // Update the stored procedure name if necessary
            return await Task.Factory.StartNew(() => _db.Connection.Query<BillingDetailsWithoutGST>(spName,
                new { Id = id }, commandType: CommandType.StoredProcedure).ToList());
        }
        public string DownloadInvoice(int id)
        {
            string column = string.Empty;
            var spName = ConstantSPnames.SP_GETAllBILLINGDETAILSWITHOUTGST;
            string strfilepath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "invoiceWithoutGST.docx");
            DataTable ds = new DataTable();
            // var con = "Data Source=SQL5109.site4now.net;Initial Catalog=db_ab072a_jkbbrickingnew;User Id=db_ab072a_jkbbrickingnew_admin;Password=Lore@123";
            // var con = "Data Source=SQL8001.site4now.net;Initial Catalog=db_a85a40_loreconstruction;User Id=db_a85a40_loreconstruction_admin;Password=Lore@123";
            var con = "Data Source=SQL5111.site4now.net;Initial Catalog=db_a85a40_tptserverdb;User Id=db_a85a40_tptserverdb_admin;Password=Lore@123";

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
            var doc = DocX.Load(files.Find(x => Path.GetFileName(x) == "InvoiceWithoutGST.docx"));
            var row = ds.Rows[0].ItemArray;
            var col = ds.Columns;
            var signPath = Path.Combine(Directory.GetCurrentDirectory(), "Signature");


            for (int i = 0; i < row.Count(); i++)
            {

                if (i == 4)
                {

                    if (DateTime.TryParse(row[4].ToString(), out DateTime dateValue))
                    {
                        // Format the date as "dd-MM-yyyy"
                        row[4] = dateValue.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    }
                }
                if (i == 14)
                {
                    var items = JsonConvert.DeserializeObject<List<GoodsDetails>>(row[14].ToString());
                    doc.InsertParagraph();
                    Table t = doc.AddTable(items.Count + 2, 7);
                    t.Alignment = Alignment.center;
                    t.Rows[0].Cells[0].Paragraphs.First().Append("S.No").Font(new Xceed.Document.NET.Font("Arial"));
                    t.SetWidths(new float[] { 35, 400, 160, 60, 100, 100, 120 });
                    t.Rows[0].Cells[1].Paragraphs.First().Append("Description of Goods").Font(new Xceed.Document.NET.Font("Arial"));
                    t.Rows[0].Cells[2].Paragraphs.First().Append("HSN or SAC").Font(new Xceed.Document.NET.Font("Arial"));
                    t.Rows[0].Cells[3].Paragraphs.First().Append("Quantity").Font(new Xceed.Document.NET.Font("Arial"));
                    t.Rows[0].Cells[4].Paragraphs.First().Append("Rate").Font(new Xceed.Document.NET.Font("Arial"));
                    t.Rows[0].Cells[5].Paragraphs.First().Append("Per").Font(new Xceed.Document.NET.Font("Arial"));
                    t.Rows[0].Cells[6].Paragraphs.First().Append("Amount").Font(new Xceed.Document.NET.Font("Arial"));


                    for (int k = 0; k < items.Count; k++)
                    {
                        t.Rows[k + 1].Cells[0].Paragraphs.First().Append(items[k].SNo.ToString());
                        t.SetWidths(new float[] { 35, 400, 160, 60, 100, 100, 120 });
                        //{ 35, 300, 120, 130, 120 });
                        t.Rows[k + 1].Cells[1].Paragraphs.First().Append(items[k].DescriptionOfGoods == null ? "" : items[k].DescriptionOfGoods.ToString()).Font(new Xceed.Document.NET.Font("Arial"));
                        t.Rows[k + 1].Cells[1].Paragraphs.First().Append(items[k].DescriptionOfGoods == null ? "" : items[k].DescriptionOfGoods.ToString()).Font(new Xceed.Document.NET.Font("Arial"));
                        t.Rows[k + 1].Cells[2].Paragraphs.First().Append(items[k].hsnsac == null ? "" : items[k].hsnsac.ToString()).Font(new Xceed.Document.NET.Font("Arial"));
                        t.Rows[k + 1].Cells[3].Paragraphs.First().Append(items[k].Quantity.ToString()).Font(new Xceed.Document.NET.Font("Arial"));
                        t.Rows[k + 1].Cells[4].Paragraphs.First().Append(items[k].Rate.ToString()).Font(new Xceed.Document.NET.Font("Arial"));
                        t.Rows[k + 1].Cells[5].Paragraphs.First().Append(((items[k].Per == null) ? "0" : items[k].Per).ToString()).Font(new Xceed.Document.NET.Font("Arial"));
                        t.Rows[k + 1].Cells[6].Paragraphs.First().Append(items[k].Amount.ToString()).Font(new Xceed.Document.NET.Font("Arial"));
                    }
                    int LastRow = items.Count + 1;
                    t.Rows[LastRow].Cells[1].Paragraphs.First().Append("Total").Font(new Xceed.Document.NET.Font("Arial"));
                    t.Rows[LastRow].Cells[3].Paragraphs.First().Append(items.Sum(i => i.Quantity).ToString());
                    t.Rows[LastRow].Cells[6].Paragraphs.First().Append(items.Sum(i => i.Amount).ToString());
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
    }
}
