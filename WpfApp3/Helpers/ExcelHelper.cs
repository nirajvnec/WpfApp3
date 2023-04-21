using System.Collections.Generic;
using System.IO;
using OfficeOpenXml;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Windows.Controls;
using System.Threading;

namespace WpfApp3.Helpers
{
    public static class ExcelHelper
    {
        public static async IAsyncEnumerable<T> ReadExcelAsync<T>(string filePath, Func<ExcelWorksheet, int, T> selector, IProgress<double> progress, CancellationToken cancellationToken) where T : class
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using var package = new ExcelPackage(new FileInfo(filePath));
            var worksheet = package.Workbook.Worksheets[0]; // Assuming the data is in the first sheet
            var rowCount = worksheet.Dimension.Rows;
            int processedRowCount = 0;

            for (int row = 2; row <= rowCount; row++) // Start from the second row to skip header
            {
                cancellationToken.ThrowIfCancellationRequested();

                var item = selector(worksheet, row);
                if (item != null)
                {
                    yield return item;
                    processedRowCount++;
                    progress?.Report((double)processedRowCount / (rowCount - 1));
                }

                // Use a short delay to allow the UI thread to process updates
                await Task.Delay(1, cancellationToken);
            }
        }




    }
}
