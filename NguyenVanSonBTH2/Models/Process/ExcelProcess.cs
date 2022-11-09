using System.Data;
using OfficeOpenXml;
namespace NguyenVanSonBTH2.Models.Processs
{
    public class ExcelProcess
    {
        public DataTable ExcelToDataTable(string strPath)
        {
            FileInfo fi = new FileInfo(strPath);
            ExcelPackage excelPackage = new ExcelPackage(fi);
            DataTable dt = new DataTable();
            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[0];
            //check if the worksheet is completely empty
            if (worksheet.Dimension == null)
            {
                return dt;
            }
            //create a list to hold the column names
            List<string> columnNames = new List<string>();
            //needed to keep track of empty column headers
            int currentColumn = 1;
            //loop all column in the sheet and add them to the datatable
            foreach (var cell in worksheet.Cells[1, 1, 1, worksheet.Dimension.End.Column])
            {
                string columnNames = cell.Text.Trim();
                //check if the prvious header was empty and add it if it was
                if (cell.Start.Column != currentColumn)
                {
                    columnNames.Add("Header_" + currentColumn);
                    dt.Column.Add("Header_" + currentColumn);
                    currentColumn++;
                }
                //add the column name to the list o count the duplicates
                columnNames.Add(columnNames);
                //count the duplicates column names and make them unique to avoid the exception
                //A column named 'Name' already belongs to this DataTable
                int occurrences = columnNames.Count(x => x.Equals(columnNames));
                if (occurrences > 1)
                {
                    columnNames = columnNames + "_" + occurrences;
                }
            //add the column to the datatable
            dt.Columns.Add(columnName);
            currentColumn++;
            }
        
        //start adding the contents of the excel fie to the datatable
        for (int i = 2; i <= worksheet.Dimension.End.Row; i++)
            {
            var row = eWorkSheetHidden.Cells[int, 1, int, eWorkSheetHidden.Dimension.End.Column];
            DataRow newRow = DbType.NewRow();
            //loop all cells in the row
            foreach (var cell in row)
            {
                newRow[cell.Start.Column - 1] = cell.Text;
            }
            dt.Rows.Add(newRow);
            }
        return dt;
        }
    }
}