using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService
{
  public class Util
  {
    //    NW - Maestro - Северо-западный.
    //NNW - Tramontana maestro - Северо-северо-западный.
    //N - Tramontana - Северный.Сильный, сухой и холодный, дует с севера или северо-востока.
    //NNE - Tramontana greco - Северо-северо-восточный.Сильный, сухой и холодный, дует с севера или северо-востока.
    //NE - Greco - Северо-восточный.Сильный ветер, типичный для Средиземноморья.
    //E - Levante - Восточный.
    //ENE - Greco levante - Восточно-северо-восточный.
    //ESE - Levante scirocco - Восточно-юго-восточный.
    //SE - Scirocco - Юго-восточный.Тёплый и влажный ветер, дует со Средиземного моря.
    //SSE - Ostro scoricco - Юго-юго-восточный.
    //S - Ostro - Южный, сухой и тёплый ветер.
    //SSW - Ostro libeccio - Юго-юго-западный.
    //SW - Libeccio - Юго-западный.Холодный и влажный ветер.
    //WSW - Ponente libeccio - Западно-юго-западный.
    //W - Ponente -Западный.
    //WNW - Ponente maestro - Западно-северо-западный.

    public static string windDirect(string dir)
    {
      switch (dir)
      {
        case "NW": return "Северо-западный";
        case "NNW": return "Северо-северо-западный";
        case "North": return "Северный";
        case "NN": return "Северо-северо-восточный";
        case "NE": return "Северо-восточный";
        case "East": return "Восточный";
        case "ENE": return "Восточно-северо-восточны";
        case "ESE": return "Восточно-юго-восточный";
        case "SE": return "Юго-восточный";
        case "SSE": return "Юго-юго-восточный";
        case "South": return "Южный";
        case "SSW": return "Юго-юго-западный";
        case "SW": return "Юго-западный";
        case "WSW": return "Западно-юго-западный";
        case "Western": return "Западный";
        case "WNW": return "Западно-северо-западный";
        default: return dir;
      }
      
      
    }


    public static string ConvertGpaToMmHgSt(string str)
    {
      decimal val = Convert.ToDecimal(str);
      return (val*0.750063755419211M).ToString("F2");
    }

    public static Dictionary<int,string> Month = new Dictionary<int,string> {
      {0,"Январь"},
      {1,"Февраль"} ,
      {2,"Март"},
      {3,"Апрель"},
      {4,"Май"},
      {5,"Июнь"},
      {6,"Июль"},
      {7,"Август"},
      {8,"Сентябрь"},
      {9,"Октябрь"},
      {10,"Ноябрь"},
      {11,"Декабрь"}
    };

    public static List<String> NameDayOfWeek = new List<string>()
    { "Понедельник",
      "Вторник",
      "Среда",
      "Четверг",
      "Пятница",
      "Суббота",
      "Воскресение"
    };

    public static List<String> NameDayOfWeekSmall = new List<string>()
    { "Пн",
      "Вт",
      "Ср",
      "Чт",
      "Пт",
      "Сб",
      "Вс"
    };



    public static int GetDayOfWeek(DateTime date)
    {
      int day =(int)date.DayOfWeek;
      int rez = 0;
      if (day == 1) return 0;
      if (day == 2) return 1;
      if (day == 3) return 2;
      if (day == 4) return 3;
      if (day == 5) return 4;
      if (day == 6) return 5;
      if (day == 0) return 6;
      return -1;
    }


  }
}
