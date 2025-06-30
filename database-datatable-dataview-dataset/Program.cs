using System;
using System.Data;
using System.Linq;

namespace database_datatable_dataview_dataset
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Like Database in memory.

            DataTable employeeDT = new DataTable();
            employeeDT.Columns.Add("ID", typeof(int));
            employeeDT.Columns.Add("Name", typeof(string));
            employeeDT.Columns.Add("Country", typeof(string));
            employeeDT.Columns.Add("Salary", typeof(Double));
            employeeDT.Columns.Add("Date", typeof(DateTime));

            employeeDT.Rows.Add(1, "Ayman", "Syria", 60000, DateTime.Now);
            employeeDT.Rows.Add(2, "Ahmed", "Saudi Arabia", 22222, DateTime.Now);
            employeeDT.Rows.Add(3, "Fasil", "Jordan", 13030, DateTime.Now);
            employeeDT.Rows.Add(4, "Mohammed", "Egypt", 3300, DateTime.Now);
            employeeDT.Rows.Add(5, "Khaled", "Saudi Arabia", 55500, DateTime.Now);

            int employeesCount = employeeDT.Rows.Count;
            double totalSalaries = Convert.ToDouble(employeeDT.Compute("SUM(Salary)", string.Empty));
            double avgSalaries = Convert.ToDouble(employeeDT.Compute("AVG(Salary)", string.Empty));
            double minSalary = Convert.ToDouble(employeeDT.Compute("MIN(Salary)", string.Empty));
            double maxSalary = Convert.ToDouble(employeeDT.Compute("MAX(Salary)", string.Empty));

            foreach (DataRow recordRow in employeeDT.Rows)
            {
                Console.WriteLine($"ID: {recordRow["ID"]},\tName: {recordRow["Name"]},\t\tCountry: {recordRow["Country"]}");
            }

            Console.WriteLine("\nCount of Employees: " + employeesCount);
            Console.WriteLine("Total Employees Salaries: " + totalSalaries);
            Console.WriteLine("Average Employees Salaries: " + avgSalaries);
            Console.WriteLine("Minimum Salary: " + minSalary);
            Console.WriteLine("Maximum Salary: " + maxSalary);
        }
    }
}
