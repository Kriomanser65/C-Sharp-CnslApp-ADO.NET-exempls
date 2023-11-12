using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            DataSet shopDB = new DataSet("ShopDB");
            DataTable salesTable = new DataTable("Sales");
            DataColumn idColumn = salesTable.Columns.Add("Id", typeof(int));
            DataColumn customerIdColumn = salesTable.Columns.Add("CustomerId", typeof(int));
            DataTable customersTable = new DataTable("Customers");
            DataColumn custIdColumn = customersTable.Columns.Add("Id", typeof(int));
            DataTable sellersTable = new DataTable("Sellers");
            DataColumn sellIdColumn = sellersTable.Columns.Add("Id", typeof(int));
            shopDB.Tables.Add(salesTable);
            shopDB.Tables.Add(customersTable);
            shopDB.Tables.Add(sellersTable);
            DataColumn[] pkColumns = new DataColumn[1];
            pkColumns[0] = idColumn;
            salesTable.PrimaryKey = pkColumns;
            pkColumns = new DataColumn[1];
            pkColumns[0] = custIdColumn;
            customersTable.PrimaryKey = pkColumns;
            pkColumns = new DataColumn[1];
            pkColumns[0] = sellIdColumn;
            sellersTable.PrimaryKey = pkColumns;
            DataColumn[] fkColumns = new DataColumn[1];
            fkColumns[0] = customerIdColumn;
            salesTable.ForeignKey = fkColumns;
            salesTable.ForeignKey.ParentTable = customersTable;
            string connString = "Data Source=DESKTOP-4SK39GD;Initial Catalog=DaTaBaSe;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
        }
    }
}