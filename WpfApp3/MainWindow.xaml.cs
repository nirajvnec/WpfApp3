using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;
using WpfApp3.Helpers;

namespace WpfApp3
{
    public partial class MainWindow : Window
    {
        private readonly MainViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new MainViewModel();
            DataContext = _viewModel;
        }

        private async void UploadButton_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Excel Files|*.xls;*.xlsx;*.xlsm",
                Multiselect = false
            };

            if (openFileDialog.ShowDialog() == true)
            {
                await _viewModel.UploadExcelAsync(openFileDialog.FileName);
            }
        }

        
    }
}
