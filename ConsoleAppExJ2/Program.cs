using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data;
using System.Diagnostics;
using Newtonsoft.Json;

namespace ConsoleAppExJ2
{
    class Program
    {       
        static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();
            String file = @"C:\Users\Uther\Desktop\РАФ\УССО_30_01.xlsx"; 
            String path2 = @"C:\Users\Uther\Desktop\РАФ\NotValid.xlsx";
            bool InDiffLists = false;           

            var dataSet = ReadExcel.GetDataSetFromExcelFile(file);

            Console.WriteLine(string.Format("reading file: {0}", file));
            Console.WriteLine(string.Format("coloums: {0}", dataSet.Tables[0].Columns.Count));
            Console.WriteLine(string.Format("rows: {0}", dataSet.Tables[0].Rows.Count));

            var lists = DataIntoList.IntoList(dataSet);           

            var NotValidList = lists.Item2;
            
            FileStream objFileStrm = File.Create(path2);
            objFileStrm.Close();

            WriteExcel.SetDataSetFromExcelFile(InDiffLists,NotValidList, path2);//NotValid into Excel 

            var RowObjInfoListJSON = DataIntoList.IntoJList(lists.Item1);
            //var json = JsonConvert.SerializeObject(RowObjInfoListJSON, Formatting.Indented);
            int count = lists.Item1.Count;
            JSON.ToJSON(count, RowObjInfoListJSON);
            stopWatch.Stop();

            TimeSpan ts = stopWatch.Elapsed;
            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);

            Console.WriteLine(lists.Item1.Count);

            Console.ReadKey();
        }       
       
    }
}
