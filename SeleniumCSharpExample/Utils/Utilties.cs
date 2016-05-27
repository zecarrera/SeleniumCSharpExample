using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SeleniumCSharpExample.Utils
{
    public class Utilties
    {
        List<TableDataCollection> _TableDatacollections = new List<TableDataCollection>();

        public void ReadTable(IWebElement table)
        {
            var columns = table.FindElements(By.TagName("th"));
            var rows = table.FindElements(By.TagName("tr"));
            int rowIndex = 0;
            foreach (var row in rows)
            {
                int colIndex = 0;

                var colDatas = row.FindElements(By.TagName("td"));
                foreach (var colValue in colDatas)
                {
                    _TableDatacollections.Add(new TableDataCollection
                    {
                        RowNumber = rowIndex,
                        ColumnName = columns[colIndex].Text,
                        ColumnValue = colValue.Text
                    });
                    colIndex++;
                }
                rowIndex++;
            }
            
        }

        public string ReadCell(string columnName, int rowNumber)
        {
            var data = (from e in _TableDatacollections
                where e.ColumnName == columnName && e.RowNumber == rowNumber
                select e.ColumnValue).SingleOrDefault();
            return data;
        }
    }

    
public class TableDataCollection
    {
        public int RowNumber { get; set; }
        public string ColumnName { get; set; }
        public string ColumnValue { get; set; }
    }
}
