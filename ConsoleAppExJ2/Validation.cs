using System;
using System.Text.RegularExpressions;

public class Validation
{
	static string pattern = @"[0-9]{7}[A-Z,А-Я]{1}[0-9]{3}[A-Z,А-Я]{2}[0-9]";
	
	public static bool[] IsValid(string IN, string FN, string SN, string Patr, string stringDate, string District, string EI, string Adress, string Group, string code)
	{
		Regex regex = new Regex(pattern);
		DateTime result;
		DateTime date = DateUse.GetDate(); 
		bool[] mas = new bool[11] {true, true, true, true, true, true, true, true, true, true, true}; 		
		try
		{
			if (stringDate != null)
			{
				result = DateTime.ParseExact(stringDate, "dd.MM.yyyy", null);
				var age = date.Year - result.Year;
				if (date.DayOfYear <= result.DayOfYear)
					age--;

				if (age >= 18)
				{
					mas[10] = false;
					mas[9] = false;
				}
			}
			else { mas[4] = false; mas[9] = false; }
		}
		
		catch { mas[4] = false; mas[9] = false; }

			if (regex.IsMatch(IN) == false && IN != "" )
			{
				mas[0] = false;
				mas[9] = false;
			}
			if (FN == "")
			{
				mas[1] = false;
				mas[9] = false;
			}
			if (code == "")
			{
				mas[5] = false;
				mas[9] = false;
			}
			if (SN == "")
			{
				mas[2] = false;
				mas[9] = false;
			}
			if (Patr == "")
			{
				mas[3] = false;
				mas[9] = true;
			}
			if (District == "")
			{
				mas[5] = false;
				mas[9] = false;
			}
			if (EI == "")
			{
				mas[6] = false;
				mas[9] = false;
			}
			if (Adress == "")
			{
				mas[7] = false;
				mas[9] = false;
			}
			if (Group == "")
			{
				mas[8] = false;
				mas[9] = false;
			}
		return mas;
	}
}
