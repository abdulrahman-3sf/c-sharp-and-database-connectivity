using System;
using System.Data;
using System.Linq;

namespace database_datatable_dataview_dataset
{
    internal class Dataview
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

            foreach (DataRow recordRow in employeeDT.Rows)
            {
                Console.WriteLine($"ID: {recordRow["ID"]},\tName: {recordRow["Name"]},\t\tCountry: {recordRow["Country"]}");
            }


            // DataView
            DataView employeeDV = employeeDT.DefaultView;

            Console.WriteLine("\n\n------- Print Rows Using DataView -------");
            for (int i = 0; i < employeeDV.Count; i++)
            {
                Console.WriteLine($"ID: {employeeDV[i][0]},\tName: {employeeDV[i][1]},\t\tCountry: {employeeDV[i][2]}");
            }


            // Filter on DataView
            employeeDV.RowFilter = "Country = 'Saudi Arabia'";

            Console.WriteLine("\n\n------- Filter by Country on DataView -------");
            for (int i = 0; i < employeeDV.Count; i++)
            {
                Console.WriteLine($"ID: {employeeDV[i][0]},\tName: {employeeDV[i][1]},\t\tCountry: {employeeDV[i][2]}");
            }
        }
    }
}
