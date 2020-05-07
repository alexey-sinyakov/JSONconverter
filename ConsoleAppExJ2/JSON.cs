using System;
using System.Collections.Generic;
using System.Collections;
using Newtonsoft.Json;

public class JSON
{
    class JS
    {
        public string org_name { get; set; }
        public string rec_date { get; set; }
        public int rec_year { get; set; }
        public int rec_half { get; set; }
        public int rec_count { get; set; }
        public List <RowObjJ> list { get; set; }
    }

    public static void ToJSON(int count, List<RowObjJ> list)
    {
        JS fileJSON = new JS();
        fileJSON.org_name = "Министерство образования";
        var date = DateUse.GetDate();
        fileJSON.rec_date = date.ToString();
        fileJSON.rec_year = date.Year;
        var month = date.Month;
        if (month <= 6)
        {
            fileJSON.rec_half = 1;
        }
        else
        {
            fileJSON.rec_half = 2;
        }
        fileJSON.rec_count = count;
        fileJSON.list = list;

        string json = JsonConvert.SerializeObject(fileJSON, Formatting.Indented);
        Console.WriteLine(json);
    }
}
