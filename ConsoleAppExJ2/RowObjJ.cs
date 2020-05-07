using System;

public class RowObjJ //serialize object 
{
	public string identif { get; set; }
	public string fio { get; set; }
	public string date_birth { get; set; }
	public string school_name { get; set; }
	public string school_address { get; set; }
	public string school_class { get; set; }
	//public string District { get; set; }
	public string soato { get; set; }
	public RowObjJ(string tIN, string tFirstName, string tSecondName, string tPatronymic, string tstringDate, string tDistrict, string tEducationalInstitution, string tAdressOfEI, string tGroup, string code)
	{
		identif = tIN;
        fio = tFirstName + " " + tSecondName + " " + tPatronymic;
		date_birth = tstringDate;
		school_name = tEducationalInstitution;
		school_address = tAdressOfEI;
		school_class = tGroup;
		//District = tDistrict;
		soato = code;
	}
}
