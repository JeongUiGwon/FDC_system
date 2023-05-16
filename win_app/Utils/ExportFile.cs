using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Data;

namespace SOM.Utils
{
    public class ExportFile
    {
        public static void ExportCSV(DataGrid datagrid)
        {
            Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();
            saveFileDialog.Filter = "CSV 파일 (*.csv)|*.csv|모든 파일 (*.*)|*.*";

            bool? result = saveFileDialog.ShowDialog();

            if (result == true)
            {
                string fileName = saveFileDialog.FileName;

                // 데이터 그리드(DataGrid)에서 ItemsSource 값 가져오기
                IEnumerable itemsSource = datagrid.ItemsSource;
                // CSV 파일 생성
                using (StreamWriter writer = new StreamWriter(fileName, false, Encoding.Default))
                {
                    // CSV 헤더(열 이름) 작성
                    string headerLine = string.Join(",", datagrid.Columns.Select(column => column.Header));
                    writer.WriteLine(headerLine);

                    // CSV 데이터(행) 작성
                    foreach (object item in itemsSource)
                    {
                        string dataLine = string.Join(",", datagrid.Columns.Select(column =>
                        {
                            // 데이터 그리드(DataGrid)의 해당 열의 값을 가져오기
                            var dataGridBoundColumn = column as DataGridBoundColumn;
                            if (dataGridBoundColumn != null)
                            {
                                var binding = dataGridBoundColumn.Binding as Binding;
                                if (binding != null)
                                {
                                    var propertyName = binding.Path.Path;
                                    var propertyInfo = item.GetType().GetProperty(propertyName);
                                    var cellValue = propertyInfo.GetValue(item);
                                    return cellValue?.ToString();
                                }
                            }
                            return string.Empty;
                        }));

                        writer.WriteLine(dataLine);
                    }
                }

                MessageBox.Show($"{fileName} 파일이 생성되었습니다.", "파일 내보내기 완료", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
