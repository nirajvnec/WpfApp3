using System;
using System.Globalization;
using System.Windows.Data;

namespace WpfApp3
{
    public class UploadProgressTextConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            double uploadProgress = (double)values[0];
            bool isUploading = (bool)values[1];
            string progressText = isUploading ? $"Uploading Data - Percent completion: {uploadProgress:0.00}%" : "Upload complete";
            return progressText;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

