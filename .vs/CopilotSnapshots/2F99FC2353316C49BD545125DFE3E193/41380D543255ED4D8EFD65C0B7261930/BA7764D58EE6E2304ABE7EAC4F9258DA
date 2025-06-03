using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data; 
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    public partial class MainWindow : Window, INotifyPropertyChanged 
    {
        private string _rowsInput = string.Empty;
        private string _columnsInput = string.Empty;
        private DataTable _gridData = new DataTable(); 

        public string RowsInput
        {
            get => _rowsInput;
            set { _rowsInput = value; OnPropertyChanged(nameof(RowsInput)); }
        }

        public string ColumnsInput
        {
            get => _columnsInput;
            set { _columnsInput = value; OnPropertyChanged(nameof(ColumnsInput)); }
        }

        public DataTable GridData
        {
            get => _gridData;
            set { _gridData = value; OnPropertyChanged(nameof(GridData)); }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(RowsInput, out int rows) || !int.TryParse(ColumnsInput, out int columns))
            {
                MessageBox.Show("Please enter valid numbers for rows and columns.");
                return;
            }
            if (rows < 1 || columns < 1)
            {
                MessageBox.Show("Rows and columns must be at least 1.");
                return;
            }

            var table = new DataTable();
            for (int j = 0; j < columns; j++)
            {
                table.Columns.Add($"C{j + 1}");
            }
            for (int i = 0; i < rows; i++)
            {
                var row = table.NewRow();
                for (int j = 0; j < columns; j++)
                {
                    row[j] = $"R{i + 1}C{j + 1}";
                }
                table.Rows.Add(row);
            }
            GridData = table;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}