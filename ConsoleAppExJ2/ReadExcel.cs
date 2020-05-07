using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Threading;

public class ReadExcel
{
    private static string GetConnectionString(string file)
    {
        Dictionary<string, string> props = new Dictionary<string, string>();

        string extension = file.Split('.').Last();

        props["Provider"] = "Microsoft.ACE.OLEDB.12.0;";
        props["Extended Properties"] = "Excel 12.0 XML";
        props["Data Source"] = file;

        StringBuilder sb = new StringBuilder();

        foreach (KeyValuePair<string, string> prop in props)
        {
            sb.Append(prop.Key);
            sb.Append('=');
            sb.Append(prop.Value);
            sb.Append(';');
        }

        return sb.ToString();
    }
    public static DataSet GetDataSetFromExcelFile(string file)
    {
        DataSet ds = new DataSet();

        string connectionString = GetConnectionString(file);

        using (OleDbConnection conn = new OleDbConnection(connectionString))
        {
            conn.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = conn;

            // Get all Sheets in Excel File
            System.Data.DataTable dtSheet = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

            // Loop through all Sheets to get data
            foreach (DataRow dr in dtSheet.Rows)
            {
                string sheetName = dr["TABLE_NAME"].ToString();

                if (!sheetName.EndsWith("$"))
                    continue;

                // Get all rows from the Sheet
                cmd.CommandText = "SELECT * FROM [" + sheetName + "]";

                System.Data.DataTable dt = new System.Data.DataTable();
                dt.TableName = sheetName;

                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                da.Fill(dt);

                ds.Tables.Add(dt);
            }

            cmd = null;
            conn.Close();
        }

        return ds;
    }
}
