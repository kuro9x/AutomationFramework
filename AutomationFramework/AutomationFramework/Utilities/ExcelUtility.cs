using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OfficeOpenXml;

namespace ProjectCore.Utilities
{
    public class ExcelUtility
    {
        private ExcelPackage package;
        private ExcelWorksheet worksheet;
        private string excelFilePath;
        //set up file path of excel file
        public void SetExcelFile(string excelPath, string sheetName)
        {
            FileInfo fileInfo = new FileInfo(excelPath);
            if (!fileInfo.Exists)
            {
                fileInfo.Create();
                Console.WriteLine("File doesn't exist, so created!");
            }

            using (package = new ExcelPackage(fileInfo))
            {
                worksheet = package.Workbook.Worksheets.Add(sheetName);

                this.excelFilePath = excelPath;
            }
        }

        public string GetCellData(int rowNum, int colNum)
        {
            return worksheet.Cells[rowNum, colNum].Text;
        }
        //Read data from excel
        public string GetCellData(string columnName, int rowNum)
        {
            int colNum = GetColumnIndex(columnName);
            if (colNum == -1)
            {
                return string.Empty;
            }
            return GetCellData(rowNum, colNum);
        }
        //write data into excel
        public void SetCellData(string text, int rowNum, int colNum)
        {
            worksheet.Cells[rowNum, colNum].Value = text;

            using (var fileStream = new FileStream(excelFilePath, FileMode.Create))
            {
                package.SaveAs(fileStream);
            }
        }

        private int GetColumnIndex(string columnName)
        {
            var headerRow = worksheet.Cells[1, 1, 1, worksheet.Dimension.End.Column];
            foreach (var cell in headerRow)
            {
                if (cell.Text.Equals(columnName, StringComparison.OrdinalIgnoreCase))
                {
                    return cell.Start.Column;
                }
            }
            return -1; 
        }
    }
}
    