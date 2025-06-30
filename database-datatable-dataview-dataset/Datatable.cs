using System;
using System.Data;
using System.Linq;

namespace database_datatable_dataview_dataset
{
    internal class Datatable
    {
        //static void Main(string[] args)
        //{
        //    // Like Database in memory.

        //    DataTable employeeDT = new DataTable();

        //    // Way one to add columns
        //    //employeeDT.Columns.Add("ID", typeof(int));
        //    //employeeDT.Columns.Add("Name", typeof(string));
        //    employeeDT.Columns.Add("Country", typeof(string));
        //    employeeDT.Columns.Add("Salary", typeof(Double));
        //    employeeDT.Columns.Add("Date", typeof(DateTime));

        //    // Second way to add columns (more better)
        //    DataColumn dataColumn = new DataColumn();

        //    // For ID
        //    dataColumn.DataType = typeof(int);
        //    dataColumn.ColumnName = "ID";
        //    dataColumn.AutoIncrement = true;
        //    dataColumn.AutoIncrementSeed = 1;
        //    dataColumn.AutoIncrementStep = 1;
        //    dataColumn.Caption = "Employee ID";
        //    dataColumn.ReadOnly = true;
        //    dataColumn.Unique = true;
        //    employeeDT.Columns.Add(dataColumn);

        //    // For Name
        //    dataColumn = new DataColumn();
        //    dataColumn.DataType = typeof(string);
        //    dataColumn.ColumnName = "Name";
        //    dataColumn.AutoIncrement = false;
        //    dataColumn.Caption = "Employee Name";
        //    dataColumn.ReadOnly = false;
        //    dataColumn.Unique = false;
        //    employeeDT.Columns.Add(dataColumn);

        //    DataColumn[] primaryKeyColumns = new DataColumn[1];
        //    primaryKeyColumns[0] = employeeDT.Columns["ID"];
        //    employeeDT.PrimaryKey = primaryKeyColumns;

        //    // We put the ID null because it's auto increment
        //    employeeDT.Rows.Add(null, "Ayman", "Syria", 60000, DateTime.Now);
        //    employeeDT.Rows.Add(null, "Ahmed", "Saudi Arabia", 22222, DateTime.Now);
        //    employeeDT.Rows.Add(null, "Fasil", "Jordan", 13030, DateTime.Now);
        //    employeeDT.Rows.Add(null, "Mohammed", "Egypt", 3300, DateTime.Now);
        //    employeeDT.Rows.Add(null, "Khaled", "Saudi Arabia", 55500, DateTime.Now);

        //    int employeesCount = employeeDT.Rows.Count;
        //    double totalSalaries = Convert.ToDouble(employeeDT.Compute("SUM(Salary)", string.Empty));
        //    double avgSalaries = Convert.ToDouble(employeeDT.Compute("AVG(Salary)", string.Empty));
        //    double minSalary = Convert.ToDouble(employeeDT.Compute("MIN(Salary)", string.Empty));
        //    double maxSalary = Convert.ToDouble(employeeDT.Compute("MAX(Salary)", string.Empty));

        //    foreach (DataRow recordRow in employeeDT.Rows)
        //    {
        //        Console.WriteLine($"ID: {recordRow["ID"]},\tName: {recordRow["Name"]},\t\tCountry: {recordRow["Country"]}");
        //    }

        //    Console.WriteLine("\nCount of Employees: " + employeesCount);
        //    Console.WriteLine("Total Employees Salaries: " + totalSalaries);
        //    Console.WriteLine("Average Employees Salaries: " + avgSalaries);
        //    Console.WriteLine("Minimum Salary: " + minSalary);
        //    Console.WriteLine("Maximum Salary: " + maxSalary);


        //    // string filter = "Country='Saudi Arabia' or Country='Jordan'";
        //    // string filter = "ID=1";

        //    // Filter by country Saudi Arabia
        //    string filter = "Country='Saudi Arabia'";
        //    DataRow[] resultRows = employeeDT.Select(filter);

        //    int resultCount = resultRows.Count();
        //    totalSalaries = Convert.ToDouble(employeeDT.Compute("SUM(Salary)", filter));
        //    avgSalaries = Convert.ToDouble(employeeDT.Compute("AVG(Salary)", filter));
        //    minSalary = Convert.ToDouble(employeeDT.Compute("MIN(Salary)", filter));
        //    maxSalary = Convert.ToDouble(employeeDT.Compute("MAX(Salary)", filter));

        //    Console.WriteLine("\n\n------- Filter by Country Saudi Arabia -------");

        //    foreach (DataRow recordRow in resultRows)
        //    {
        //        Console.WriteLine($"ID: {recordRow["ID"]},\tName: {recordRow["Name"]},\t\tCountry: {recordRow["Country"]}");
        //    }

        //    Console.WriteLine("\nCount of Employees: " + resultCount);
        //    Console.WriteLine("Total Employees Salaries: " + totalSalaries);
        //    Console.WriteLine("Average Employees Salaries: " + avgSalaries);
        //    Console.WriteLine("Minimum Salary: " + minSalary);
        //    Console.WriteLine("Maximum Salary: " + maxSalary);


        //    // Sort Data
        //    employeeDT.DefaultView.Sort = "ID desc";
        //    employeeDT = employeeDT.DefaultView.ToTable();

        //    Console.WriteLine("\n\n------- Sorted by ID desc -------");

        //    foreach (DataRow recordRow in employeeDT.Rows)
        //    {
        //        Console.WriteLine($"ID: {recordRow["ID"]},\tName: {recordRow["Name"]},\t\tCountry: {recordRow["Country"]}");
        //    }


        //    // Delete Row
        //    filter = "ID=4";
        //    resultRows = employeeDT.Select(filter);

        //    foreach (DataRow recordRow in resultRows)
        //    {
        //        recordRow.Delete();
        //    }

        //    // This for sync with the database after delete, but we offline so we don't need it.
        //    // employeeDT.AcceptChanges();

        //    Console.WriteLine("\n\n------- After delete row with ID = 4 -------");

        //    foreach (DataRow recordRow in employeeDT.Rows)
        //    {
        //        Console.WriteLine($"ID: {recordRow["ID"]},\tName: {recordRow["Name"]},\t\tCountry: {recordRow["Country"]}");
        //    }


        //    // Update Row
        //    filter = "ID=3";
        //    resultRows = employeeDT.Select(filter);

        //    foreach (DataRow recordRow in resultRows)
        //    {
        //        recordRow["Name"] = "Yarob";
        //        recordRow["Salary"] = 9000;
        //    }

        //    // This for sync with the database after delete, but we offline so we don't need it.
        //    // employeeDT.AcceptChanges();

        //    Console.WriteLine("\n\n------- After update row with ID = 3 -------");

        //    foreach (DataRow recordRow in employeeDT.Rows)
        //    {
        //        Console.WriteLine($"ID: {recordRow["ID"]},\tName: {recordRow["Name"]},\t\tCountry: {recordRow["Country"]},\t\tSalary: {recordRow["Salary"]}");
        //    }


        //    // Clear Data
        //    // employeeDT.Clear();



        //}
    }
}
