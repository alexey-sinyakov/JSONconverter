using System;

public class DateUse
{
    static bool Today = true;
    public static DateTime GetDate()
    {
        DateTime result;
        if (Today == false)
        {
            
            string stringDate = "01.01.2020";
            result = DateTime.ParseExact(stringDate, "dd.MM.yyyy", null);
            
        }
        else
        {
            result = DateTime.Now;
        }
        return result;
    }
}
