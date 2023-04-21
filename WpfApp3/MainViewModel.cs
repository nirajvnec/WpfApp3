using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WpfApp3.Helpers;

namespace WpfApp3
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<ExcelDataModel> _dataCollection;

        private double _uploadProgress;
        public double UploadProgress
        {
            get { return _uploadProgress; }
            set
            {
                if (_uploadProgress != value)
                {
                    _uploadProgress = value;
                    OnPropertyChanged(nameof(UploadProgress));
                }
            }
        }

        private bool _isUploading;

        public bool IsUploading
        {
            get => _isUploading;
            set
            {
                _isUploading = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<ExcelDataModel> DataCollection
        {
            get => _dataCollection;
            set
            {
                _dataCollection = value;
                OnPropertyChanged();
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MainViewModel()
        {
            DataCollection = new ObservableCollection<ExcelDataModel>();
        }

        public async Task UploadExcelAsync(string filePath)
        {
            DataCollection.Clear();
            IsUploading = true;

            var progress = new Progress<double>(value => UploadProgress = value * 100);
            var cancellationTokenSource = new CancellationTokenSource();

            try
            {
                await foreach (var item in ExcelHelper.ReadExcelAsync<ExcelDataModel>(filePath, (worksheet, row) =>
                {
                    DateTime.TryParse(worksheet.Cells[row, 3].Text, out var dateOfBirth);
                    return new ExcelDataModel
                    {
                        Name = worksheet.Cells[row, 1].Text,
                        Age = int.Parse(worksheet.Cells[row, 2].Text),
                        DateOfBirth = dateOfBirth,
                        Email = worksheet.Cells[row, 4].Text
                    };
                }, progress, cancellationTokenSource.Token))
                {
                    DataCollection.Add(item);
                }
            }
            catch (OperationCanceledException)
            {
                // Handle cancellation if needed
            }
            finally
            {
                IsUploading = false;
            }
        }

    }

}
