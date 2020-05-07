using System;
using System.Collections;
using System.Text;
public class Translit
{
    public static string TranslitIN(string s)
    {
        StringBuilder ret = new StringBuilder();
        bool var = false;
        //ret = s;
        string[] rus = { "А", "В", "С", "К", "Е", "М", "Н", "Р"};
        string[] eng = { "A", "B", "C", "K", "E", "M", "H", "P"};

        for (int j = 0; j < s.Length; j++)
        {
            var = false;
            for (int i = 0; i < rus.Length; i++)
            {
                if (s.Substring(j, 1) == rus[i]) { ret.Append(eng[i]); var = true; } 
            }
            if (var == false) { ret.Append(s.Substring(j, 1)); }
        }
        return ret.ToString();
    }
    public static string TranslitSOATO(string s)
    {
        StringBuilder ret = new StringBuilder();
        bool var = false;
        //ret = s;
        string[] rus = { "ё" };
        string[] rus2 = { "е" };

        for (int j = 0; j < s.Length; j++)
        {
            var = false;
            for (int i = 0; i < rus.Length; i++)
            {
                if (s.Substring(j, 1) == rus[i]) { ret.Append(rus2[i]); var = true; }
            }
            if (var == false) { ret.Append(s.Substring(j, 1)); }
        }
        return ret.ToString();
    }
}
