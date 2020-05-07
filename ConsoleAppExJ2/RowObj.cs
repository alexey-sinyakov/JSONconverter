using System;
using System.Text.RegularExpressions;
public class RowObj
{
	public string IN { get; set; }
	public string FirstName { get; set; }
	public string SecondName { get; set; }
	public string Patronymic { get; set; }
	public string stringDate { get; set; }
	public string District { get; set; }
	public string EducationalInstitution { get; set; }
	public string AdressOfEI { get; set; }
	public string Group { get; set; }
	public string codeSOATO { get; set; }
	public bool[] Validtype { get; set; }

	public RowObj(string tIN, string tFirstName, string tSecondName, string tPatronymic, string tstringDate, string tDistrict, string tEducationalInstitution, string tAdressOfEI, string tGroup)
	{
			tstringDate = tstringDate.Trim();
			tDistrict = tDistrict.Trim();
			tIN = tIN.Trim();
			tSecondName = tSecondName.Trim();
			tFirstName = tFirstName.Trim();
			tPatronymic = tPatronymic.Trim();
			tEducationalInstitution = tEducationalInstitution.Trim();
			tAdressOfEI = tAdressOfEI.Trim();
			tGroup = tGroup.Trim();
			tIN = Translit.TranslitIN(tIN);
			tDistrict = Translit.TranslitSOATO(tDistrict);
			IN = tIN;
			FirstName = tFirstName;
			SecondName = tSecondName;
			Patronymic = tPatronymic;
			stringDate = tstringDate;
			District = tDistrict;
			EducationalInstitution = tEducationalInstitution;
			AdressOfEI = tAdressOfEI;
			Group = tGroup;
			codeSOATO = SOATOnew.GetSOATO(tDistrict);
			Validtype = Validation.IsValid(tIN, tFirstName,tSecondName,tPatronymic,tstringDate,tDistrict,tEducationalInstitution,tAdressOfEI,tGroup, codeSOATO);

	}


}
