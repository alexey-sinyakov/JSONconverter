using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data;
using System.Diagnostics;
public class DataIntoList
{
    public static Tuple<List<RowObj>, List<RowObj>> IntoList(DataSet dataSet)
    {
        List<RowObj> RowObjInfoListAll = new List<RowObj>();
        //List<RowObj> RowObjInfoListNotValidDate = new List<RowObj>();
        Stopwatch stopWatch = new Stopwatch();
        
        var MyData = dataSet.Tables[0].AsEnumerable().Select(s => new RowObj(Convert.ToString(s[0]),
             Convert.ToString(s[1]), Convert.ToString(s[2]), Convert.ToString(s[3]), Convert.ToString(s[4]),
             Convert.ToString(s[5]), Convert.ToString(s[6]), Convert.ToString(s[7]), Convert.ToString(s[8])));

        var MyDataAll = MyData.AsEnumerable();//.Where(RowObj => RowObj.Validtype == 0);
        //var MyDataNotValidDate = MyData.AsEnumerable().Where(RowObj => RowObj.Validtype == 2);

        //var MyDataValid = MyData.AsEnumerable().Where(RowObj => RowObj.IsValid(RowObj.stringDate, RowObj.IN) == true);
        //var MyDataNotValid = MyData.AsEnumerable().Where(RowObj => RowObj.IsValid(RowObj.stringDate, RowObj.IN) == false);
        stopWatch.Start();
        RowObjInfoListAll = MyDataAll.AsEnumerable().ToList();

            /*List<RowObj> list = new List<RowObj>();

            foreach (var row in MyDataAll)
            {
            //RowObj obj = new RowObj();
            RowObjInfoListAll.Add(row);
            }*/


        stopWatch.Stop();
        //RowObjInfoListNotValidDate = MyDataNotValidDate.AsEnumerable().ToList();
        TimeSpan ts = stopWatch.Elapsed;
        // Format and display the TimeSpan value.

        string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
        Console.WriteLine("RunTime " + elapsedTime);

        List<RowObj> RowObjInfoList = new List<RowObj>();
        List<RowObj> RowObjInfoListAllNotValid = new List<RowObj>();
        foreach (RowObj tRowObj in RowObjInfoListAll)
        {
            if (tRowObj.Validtype[9] == true)
            {
                var obj = tRowObj;
                RowObjInfoList.Add(obj);
            }
            else
            {
                var obj = tRowObj;
                RowObjInfoListAllNotValid.Add(obj);
            }
        }
        //var mas = IntoDifLists(RowObjInfoListAllNotValid);
        //Array Mylist = new Array() { RowObjInfoListNotValidIN, RowObjInfoListNotValidFN, RowObjInfoListNotValidSN, RowObjInfoListNotValidPatr, RowObjInfoListNotValidDate, RowObjInfoListNotValidDistr, RowObjInfoListNotValidEi, RowObjInfoListNotValidAdress };
        return Tuple.Create(RowObjInfoList, RowObjInfoListAllNotValid);
    }
    public static List<RowObjJ> IntoJList(List<RowObj> list)
    {
        List<RowObjJ> RowObjInfoListJSON = new List<RowObjJ>();
        foreach (RowObj tRowObj in list)
        {
            var obj = new RowObjJ(tRowObj.IN, tRowObj.FirstName, tRowObj.SecondName, tRowObj.Patronymic, tRowObj.stringDate, tRowObj.District, tRowObj.EducationalInstitution, tRowObj.AdressOfEI, tRowObj.Group, tRowObj.codeSOATO);
            RowObjInfoListJSON.Add(obj);
        }
        return RowObjInfoListJSON;
    }

    public static List<RowObj>[] IntoDifLists(List<RowObj> RowObjInfoListAllNotValid)
    {
        List<RowObj> RowObjInfoListNotValidIN = new List<RowObj>();
        List<RowObj> RowObjInfoListNotValidFN = new List<RowObj>();
        List<RowObj> RowObjInfoListNotValidSN = new List<RowObj>();
        List<RowObj> RowObjInfoListNotValidPatr = new List<RowObj>();
        List<RowObj> RowObjInfoListNotValidDate = new List<RowObj>();
        List<RowObj> RowObjInfoListNotValidDistr = new List<RowObj>();
        List<RowObj> RowObjInfoListNotValidEi = new List<RowObj>();
        List<RowObj> RowObjInfoListNotValidAdress = new List<RowObj>();
        List<RowObj> RowObjInfoListNotValidGroup = new List<RowObj>();

        foreach (RowObj tRowObj in RowObjInfoListAllNotValid)
        {
            if (tRowObj.Validtype[10] == false || tRowObj.Validtype[4] == false) //
            {
                var obj = tRowObj;
                RowObjInfoListNotValidDate.Add(obj);
            }

            if (tRowObj.Validtype[0] == false)
            {
                var obj = tRowObj;
                RowObjInfoListNotValidIN.Add(obj);
            }

            if (tRowObj.Validtype[1] == false)
            {
                var obj = tRowObj;
                RowObjInfoListNotValidFN.Add(obj);
            }

            if (tRowObj.Validtype[2] == false)
            {
                var obj = tRowObj;
                RowObjInfoListNotValidSN.Add(obj);
            }

            if (tRowObj.Validtype[3] == false)
            {
                var obj = tRowObj;
                RowObjInfoListNotValidPatr.Add(obj);
            }

            if (tRowObj.Validtype[5] == false)
            {
                var obj = tRowObj;
                RowObjInfoListNotValidDistr.Add(obj);
            }

            if (tRowObj.Validtype[6] == false)
            {
                var obj = tRowObj;
                RowObjInfoListNotValidEi.Add(obj);
            }

            if (tRowObj.Validtype[7] == false)
            {
                var obj = tRowObj;
                RowObjInfoListNotValidAdress.Add(obj);
            }

            if (tRowObj.Validtype[8] == false)
            {
                var obj = tRowObj;
                RowObjInfoListNotValidGroup.Add(obj);
            }
        }
        List<RowObj>[] mas = new List<RowObj>[9];
        mas[0] = RowObjInfoListNotValidIN;
        mas[1] = RowObjInfoListNotValidFN;
        mas[2] = RowObjInfoListNotValidSN;
        mas[3] = RowObjInfoListNotValidPatr;
        mas[4] = RowObjInfoListNotValidDate;
        mas[5] = RowObjInfoListNotValidDistr;
        mas[6] = RowObjInfoListNotValidEi;
        mas[7] = RowObjInfoListNotValidAdress;
        mas[8] = RowObjInfoListNotValidGroup;
        return mas;
    }
    public static List<RowObj>[] IntoTwoLists(List<RowObj> RowObjInfoListAllNotValid)
    {
        List<RowObj> RowObjInfoListNotValidDate = new List<RowObj>();
        List<RowObj> RowObjInfoListNotValidOther = new List<RowObj>();
        foreach (RowObj tRowObj in RowObjInfoListAllNotValid)
        {
            if (tRowObj.Validtype[10] == false) //
            {
                var obj = tRowObj;
                RowObjInfoListNotValidDate.Add(obj);
            }
            else
            {
                var obj = tRowObj;
                RowObjInfoListNotValidOther.Add(obj);
            }
        }
        List<RowObj>[] mas = new List<RowObj>[2];
        mas[0] = RowObjInfoListNotValidDate;
        mas[1] = RowObjInfoListNotValidOther;
        return mas;
    }
}
