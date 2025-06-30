using System;
using System.Data;
using System.Linq;

namespace database_datatable_dataview_dataset
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataTable EmployeeDT = new DataTable();
            EmployeeDT.Columns.Add("ID", typeof(int));
            EmployeeDT.Columns.Add("Name", typeof(string));
            EmployeeDT.Columns.Add("Country", typeof(string));
            EmployeeDT.Columns.Add("Salary", typeof(Double));
            EmployeeDT.Columns.Add("Date", typeof(DateTime));

            EmployeeDT.Rows.Add(1, "Ayman", "Syria", 60000, DateTime.Now);
            EmployeeDT.Rows.Add(2, "Ahmed", "Saudi Arabia", 22222, DateTime.Now);
            EmployeeDT.Rows.Add(3, "Fasil", "Jordan", 13030, DateTime.Now);
            EmployeeDT.Rows.Add(4, "Mohammed", "Egypt", 3300, DateTime.Now);
            EmployeeDT.Rows.Add(5, "Khaled", "Saudi Arabia", 55500, DateTime.Now);

            foreach (DataRow recordRow in EmployeeDT.Rows)
            {
                Console.WriteLine($"ID: {recordRow["ID"]},\tName: {recordRow["Name"]},\t\tCountry: {recordRow["Country"]}");
            }
        }
    }
}
