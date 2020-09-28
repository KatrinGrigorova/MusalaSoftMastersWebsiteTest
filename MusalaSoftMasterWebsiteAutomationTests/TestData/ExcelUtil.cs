using ExcelDataReader;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace MusalaSoftMasterWebsiteAutomationTests.TestData
{
    public class ExcelUtil
    {
        public DataTable ExcelToDataTable(string fileName)
        {
            FileStream stream = File.Open(fileName, FileMode.Open, FileAccess.Read);
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            IExcelDataReader reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
            {
                ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                {
                    UseHeaderRow = true
                }
            });
            DataTableCollection table = result.Tables;
            DataTable resultTable = table["Sheet1"];

            return resultTable;
        }
       

        public Dictionary<string, string> GetCredentials(string fileName)
        {
            DataTable table = ExcelToDataTable(fileName);

            return table.AsEnumerable()
                    .ToDictionary<DataRow, string, string>(row => row.Field<string>(0).ToString(),
                                row => row.Field<string>(1).ToString());
        }
    }
}
