using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    public partial class DynamicGridControl : UserControl, INotifyPropertyChanged
    {
        private string _rowsInput = string.Empty;
        private string _columnsInput = string.Empty;

        public string RowsInput
        {
            get { return _rowsInput; }
            set
            {
                if (_rowsInput != value)
                {
                    _rowsInput = value;
                    OnPropertyChanged(nameof(RowsInput));
                    RegenerateGridData();
                }
            }
        }

        public string ColumnsInput
        {
            get { return _columnsInput; }
            set
            {
                if (_columnsInput != value)
                {
                    _columnsInput = value;
                    OnPropertyChanged(nameof(ColumnsInput));
                    RegenerateGridData();
                }
            }
        }

        public DynamicGridControl()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void RegenerateGridData()
        {
            if (!int.TryParse(RowsInput, out int rows) || !int.TryParse(ColumnsInput, out int columns) || rows < 1 || columns < 1)
            {
                RowColGrid.ItemsSource = null;
                return;
            }

            var table = new DataTable();
            for (int j = 0; j < columns; j++)
                table.Columns.Add($"C{j + 1}");
            for (int i = 0; i < rows; i++)
            {
                var row = table.NewRow();
                for (int j = 0; j < columns; j++)
                    row[j] = $"R{i + 1}C{j + 1}";
                table.Rows.Add(row);
            }
            RowColGrid.ItemsSource = table.DefaultView;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
