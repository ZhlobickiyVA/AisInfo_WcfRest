using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService
{
  class ProzCalendar
  {
    public string YearMonth { get; set; }
    public string m01 { get; set; }
    public string m02 { get; set; }
    public string m03 { get; set; }
    public string m04 { get; set; }
    public string m05 { get; set; }
    public string m06 { get; set; }
    public string m07 { get; set; }
    public string m08 { get; set; }
    public string m09 { get; set; }
    public string m10 { get; set; }
    public string m11 { get; set; }
    public string m12 { get; set; }
    public string SumWorkDay { get; set; }
    public string SumHepyDay { get; set; }
    public string SumWork40Hour { get; set; }
    public string SumWork36Hour { get; set; }
    public string SumWork24Hour { get; set; }
  }


  public class ProzCalendarData
  {
    public string YearMonth { get; set; }

    public List<string[]> ListMonth { get; set; }
    public string SumWorkDay { get; set; }
    public string SumHepyDay { get; set; }
    public string SumWork40Hour { get; set; }
    public string SumWork36Hour { get; set; }
    public string SumWork24Hour { get; set; }

    public ProzCalendarData()
    {
      ListMonth = new List<string[]>();
    }


    public static IEnumerable<ProzCalendarData> ConvertJsonToObject(string str)
    {
      string strVal = "";


      strVal = str.Replace("Год/Месяц", "YearMonth")
      .Replace("Январь", "m01")
      .Replace("Февраль", "m02")
      .Replace("Март", "m03")
      .Replace("Апрель", "m04")
      .Replace("Май", "m05")
      .Replace("Июнь", "m06")
      .Replace("Июль", "m07")
      .Replace("Август", "m08")
      .Replace("Сентябрь", "m09")
      .Replace("Октябрь", "m10")
      .Replace("Ноябрь", "m11")
      .Replace("Декабрь", "m12")
      .Replace("Всего рабочих дней", "SumWorkDay")
      .Replace("Всего праздничных и выходных дней", "SumHepyDay")
      .Replace("Количество рабочих часов при 24-часовой рабочей неделе", "SumWork24Hour")
      .Replace("Количество рабочих часов при 36-часовой рабочей неделе", "SumWork36Hour")
      .Replace("Количество рабочих часов при 40-часовой рабочей неделе", "SumWork40Hour");

      ProzCalendar[] calend = JsonConvert.DeserializeObject<ProzCalendar[]>(strVal);


      List<ProzCalendarData> data = new List<ProzCalendarData>();

      for (int i = 0; i < calend.Length; i++)
      {
        var t = new ProzCalendarData()
        {
          YearMonth = calend[i].YearMonth,
          SumHepyDay = calend[i].SumHepyDay,
          SumWork24Hour = calend[i].SumWork24Hour,
          SumWork36Hour = calend[i].SumWork36Hour,
          SumWork40Hour = calend[i].SumWork40Hour,
          SumWorkDay = calend[i].SumWorkDay,


        };

        t.ListMonth.Add(calend[i].m01.Split(','));
        t.ListMonth.Add(calend[i].m02.Split(','));
        t.ListMonth.Add(calend[i].m03.Split(','));
        t.ListMonth.Add(calend[i].m04.Split(','));
        t.ListMonth.Add(calend[i].m05.Split(','));
        t.ListMonth.Add(calend[i].m06.Split(','));
        t.ListMonth.Add(calend[i].m07.Split(','));
        t.ListMonth.Add(calend[i].m08.Split(','));
        t.ListMonth.Add(calend[i].m09.Split(','));
        t.ListMonth.Add(calend[i].m10.Split(','));
        t.ListMonth.Add(calend[i].m11.Split(','));
        t.ListMonth.Add(calend[i].m12.Split(','));


        data.Add(t);
      }


      return data;
    }


    public static List<int[,]> GetTableCalendar(ProzCalendarData data)
    {
      
      System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("ru-RU");
      List<int[,]> List = new List<int[,]>();
      int Year = Convert.ToInt32(data.YearMonth);
      for (int mon = 0; mon < 12; mon++)
      {
        int CountDay = DateTime.DaysInMonth(Year, mon + 1);
        DateTime startdate = DateTime.Parse(String.Format("{0}.{1}.{2}", "01", mon + 1, Year));
        DateTime enddate = DateTime.Parse(String.Format("{0}.{1}.{2}", CountDay, mon + 1, Year));
        
        int CountDayOfWeek = 7;
        int BeginDayOfWeek = Util.GetDayOfWeek(startdate);
        int CountDayMixing = CountDay + BeginDayOfWeek;


        int CountRow = CountDayMixing / CountDayOfWeek
          + (CountDayMixing % CountDayOfWeek != 0 ? 1 : 0);
        

        List<string> month = data.ListMonth[mon].ToList();

        int[,] mas = new int[CountRow,7];

        int day = 1;
        bool flag = false;
        
        for (int i = 0; i < CountRow; i++)
        {
          for (int j = 0; j < 7; j++)
          {
            if (!flag) {
              j = BeginDayOfWeek;
              flag = true;
            }
            int index = month.IndexOf(day.ToString());

            List<string> star = month.Where(s => s.EndsWith("*")).ToList();
            for (int k = 0; k < star.Count; k++)
            {
              star[k] = star[k].Substring(0, star[k].IndexOf('*'));
            }

          
           

            if ( index > -1)
            {
              string Sea = month[index];

              mas[i, j] = day + 100;

            }
            else
                if (star.Where(s => s == day.ToString()).Count() != 0)
            {
              mas[i, j] = day * -1;
            }
            else mas[i, j] = day;



            day++;




            if (day>CountDay) break;
          }
        }
        List.Add(mas);



      }

      return List;
    }
  }
}


