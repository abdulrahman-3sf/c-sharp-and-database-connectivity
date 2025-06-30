using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace database_datatable_dataview_dataset
{
    internal class Dataset
    {
        static void Main(string[] args)
        {
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

            DataTable departmentDT = new DataTable();
            departmentDT.Columns.Add("DepartmentID", typeof(int));
            departmentDT.Columns.Add("DepratmentName", typeof(string));

            departmentDT.Rows.Add(1, "IT");
            departmentDT.Rows.Add(2, "HR");
            departmentDT.Rows.Add(3, "Markiting");

            foreach (DataRow recordRow in employeeDT.Rows)
            {
                Console.WriteLine($"ID: {recordRow["ID"]},\tName: {recordRow["Name"]},\t\tCountry: {recordRow["Country"]}");
            }

            foreach (DataRow recordRow in departmentDT.Rows)
            {
                Console.WriteLine($"ID: {recordRow["DepartmentID"]},\tName: {recordRow["DepratmentName"]}");
            }


            DataSet dataSet1 = new DataSet();

            dataSet1.Tables.Add(employeeDT);
            dataSet1.Tables.Add(departmentDT);

            Console.WriteLine("\n\n------- Print Employees Data from DataSet -------");

            foreach (DataRow recordRow in dataSet1.Tables[0].Rows)
            {
                Console.WriteLine($"ID: {recordRow["ID"]},\tName: {recordRow["Name"]},\t\tCountry: {recordRow["Country"]}");
            }

            Console.WriteLine("\n\n------- Print Departments Data from DataSet -------");

            foreach (DataRow recordRow in dataSet1.Tables[1].Rows)
            {
                Console.WriteLine($"ID: {recordRow["DepartmentID"]},\tName: {recordRow["DepratmentName"]}");
            }
        }
    }
}
