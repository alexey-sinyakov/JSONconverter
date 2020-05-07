using System;
using System.IO;
using System.Collections.Generic;
using OfficeOpenXml;
using OfficeOpenXml.Style;

public class WriteExcel
{
    static public void SetDataSetFromExcelFile(bool difList,List<RowObj> NotValidList, String path2)
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        var file = new FileInfo(path2);
        if (difList == true)
        {
            var mas = DataIntoList.IntoDifLists(NotValidList);
            String[] sheet = new String[9] { "INfail", "FNfail", "SNfail", "Patrfail", "Datefail", "Distrfail", "Eifail", "Adressfail", "Groupfail" };
            //ExcelPackage excel = new ExcelPackage();
            using (ExcelPackage excel = new ExcelPackage())
            {
                //using (FileStream stream = new FileStream(path2, FileMode.Open))
                // {
                //excel.Load(stream);
                // name of the sheet 
                for (int i = 0; i <= 8; i++)
                {
                    var workSheet = excel.Workbook.Worksheets.Add(sheet[i]);
                    var MyDataNotValid = mas[i];
                    //excel.Workbook.Worksheets.Add(sheet);

                    //excel.Workbook.Worksheets.MoveToEnd(sheet);

                    //if (excel != null) { excel.Workbook.Worksheets.Delete(workSheet); }
                    //ExcelWorksheet workSheet = excel.Workbook.Worksheets[excel.Workbook.Worksheets.Count];

                    workSheet.Row(1).Height = 20;
                    workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    workSheet.Row(1).Style.Font.Bold = true;
                    // Header of the Excel sheet 
                    workSheet.Cells[1, 1].Value = "Идентификационный номер паспорта (при наличии)";
                    workSheet.Cells[1, 2].Value = "Фамилия";
                    workSheet.Cells[1, 3].Value = "Имя";
                    workSheet.Cells[1, 4].Value = "Отчество";
                    workSheet.Cells[1, 5].Value = "Дата рождения";
                    workSheet.Cells[1, 6].Value = "Район";
                    workSheet.Cells[1, 7].Value = "Наименование УО";
                    workSheet.Cells[1, 8].Value = "Адрес нахождения УО";
                    workSheet.Cells[1, 9].Value = "Группа или класс (или курс обучения)";


                    int recordIndex = 2;

                    foreach (RowObj tRowObj in MyDataNotValid)
                    {
                        workSheet.Cells[recordIndex, 1].Value = tRowObj.IN;
                        workSheet.Cells[recordIndex, 2].Value = tRowObj.FirstName;
                        workSheet.Cells[recordIndex, 3].Value = tRowObj.SecondName;
                        workSheet.Cells[recordIndex, 4].Value = tRowObj.Patronymic;
                        workSheet.Cells[recordIndex, 5].Value = tRowObj.stringDate;
                        workSheet.Cells[recordIndex, 6].Value = tRowObj.District;
                        workSheet.Cells[recordIndex, 7].Value = tRowObj.EducationalInstitution;
                        workSheet.Cells[recordIndex, 8].Value = tRowObj.AdressOfEI;
                        workSheet.Cells[recordIndex, 9].Value = tRowObj.Group;
                        recordIndex++;
                    }

                    workSheet.Column(1).AutoFit();
                    workSheet.Column(2).AutoFit();
                    workSheet.Column(3).AutoFit();
                    workSheet.Column(4).AutoFit();
                    workSheet.Column(5).AutoFit();
                    workSheet.Column(6).AutoFit();
                    workSheet.Column(7).AutoFit();
                    workSheet.Column(8).AutoFit();
                    workSheet.Column(9).AutoFit();
                }
                //excel.Save();
                //excel.SaveAs(file);

                //File.WriteAllBytes(path2, excel.GetAsByteArray());
                File.WriteAllBytesAsync(path2, excel.GetAsByteArray());


                //}
                //File.WriteAllBytesAsync(path2, excel.GetAsByteArray());
            }
        }
        else
        {
            var mas = DataIntoList.IntoTwoLists(NotValidList);
            String[] sheet = new String[2] { "Datefail", "fail"};
            using (ExcelPackage excel = new ExcelPackage())
            {
                for (int i = 0; i <= 1; i++)
                {
                    var workSheet = excel.Workbook.Worksheets.Add(sheet[i]);
                    var MyDataNotValid = mas[i];

                    workSheet.Row(1).Height = 20;
                    workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    workSheet.Row(1).Style.Font.Bold = true;
                    // Header of the Excel sheet 
                    workSheet.Cells[1, 1].Value = "Идентификационный номер паспорта (при наличии)";
                    workSheet.Cells[1, 2].Value = "Фамилия";
                    workSheet.Cells[1, 3].Value = "Имя";
                    workSheet.Cells[1, 4].Value = "Отчество";
                    workSheet.Cells[1, 5].Value = "Дата рождения";
                    workSheet.Cells[1, 6].Value = "Район";
                    workSheet.Cells[1, 7].Value = "Наименование УО";
                    workSheet.Cells[1, 8].Value = "Адрес нахождения УО";
                    workSheet.Cells[1, 9].Value = "Группа или класс (или курс обучения)";


                    int recordIndex = 2;

                    foreach (RowObj tRowObj in MyDataNotValid)
                    {
                        workSheet.Cells[recordIndex, 1].Value = tRowObj.IN;
                        workSheet.Cells[recordIndex, 2].Value = tRowObj.FirstName;
                        workSheet.Cells[recordIndex, 3].Value = tRowObj.SecondName;
                        workSheet.Cells[recordIndex, 4].Value = tRowObj.Patronymic;
                        workSheet.Cells[recordIndex, 5].Value = tRowObj.stringDate;
                        workSheet.Cells[recordIndex, 6].Value = tRowObj.District;
                        workSheet.Cells[recordIndex, 7].Value = tRowObj.EducationalInstitution;
                        workSheet.Cells[recordIndex, 8].Value = tRowObj.AdressOfEI;
                        workSheet.Cells[recordIndex, 9].Value = tRowObj.Group;
                        var fail = tRowObj.Validtype;
                        for (int ii = 0; ii <= 8; ii++)
                        {
                            if (fail[ii] == false)
                            {
                                workSheet.Cells[recordIndex, ii+1].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                                workSheet.Cells[recordIndex, ii+1].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Red);
                            }
                        }
                        recordIndex++;
                    }

                    workSheet.Column(1).AutoFit();
                    workSheet.Column(2).AutoFit();
                    workSheet.Column(3).AutoFit();
                    workSheet.Column(4).AutoFit();
                    workSheet.Column(5).AutoFit();
                    workSheet.Column(6).AutoFit();
                    workSheet.Column(7).AutoFit();
                    workSheet.Column(8).AutoFit();
                    workSheet.Column(9).AutoFit();
                }
                //excel.Save();
                //excel.SaveAs(file);

                //File.WriteAllBytes(path2, excel.GetAsByteArray());
                File.WriteAllBytesAsync(path2, excel.GetAsByteArray());
            }
        }
    }
}
