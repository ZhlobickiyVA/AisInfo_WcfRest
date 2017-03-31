using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Xml.Serialization;

namespace AisInfoService
{
  /* 
   Участки ГорЖилСервис - справочник

       itemArea - Участок 
          Name - Название
          Phone - Адрес
          Adress - Адресс участка
          itemStreet[] - Массив улиц

      itemStreet
          Name - Название улицы
          string[] House - Массив домов 



      Основные операции:
      - Отобразить список.



       */







  [DataContract]
  public class ItemArea
  {
    [DataMember(Order = 0)]
    public string Id { get; set; }
    [DataMember(Order = 1)]
    public string Name { get; set; }
    [DataMember(Order = 2)]
    public string Phone { get; set; }
    [DataMember(Order = 3)]
    public string Adress { get; set; }
    [DataMember(Order = 4)]
    public ItemStreet[] Street { get; set; }
  }

  [DataContract]
  public class ItemStreet
  {
    [DataMember]
    public string Name { get; set; }
    [DataMember]
    public string[] House { get; set; }
  }

  [DataContract]
  public class ItemAreaList
  {
    [DataMember]
    public string Id { get; set; }
    [DataMember]
    public string Name { get; set; }
  }






  /// <summary>
  /// Класс предоставляющий информацию об участках ГорЖилсервиса и привязки по адресам.
  /// </summary>
  public class ListAreaGorZhilService
  {
    public ItemArea[] ListGorZhil { get; set; }

    public ListAreaGorZhilService()
    {
      ListGorZhil = GetData();
    }
    /// <summary>
    /// Десериализация файла с данными об участках горжилсервиса.
    /// </summary>
    /// <returns></returns>
    private ItemArea[] GetData()
    {
      try
      {
        string Path = ConfigurationManager.AppSettings["PathAreaGorZhilServic"];

        //FileStream fs = new FileStream(HttpContext.Current.Server.MapPath(Path), FileMode.Open
        //    , FileAccess.Read, FileShare.Read, bufferSize: 4096, useAsync: true);

        FileStream fs = new FileStream(HttpContext.Current.Server.MapPath(Path), FileMode.Open);

        XmlSerializer formatter = new XmlSerializer(typeof(ItemArea[]));

        ItemArea[] data = (ItemArea[])formatter.Deserialize(fs);
        fs.Close();
        return data;
      }
      catch (Exception e)
      {
        HttpContext.Current.Response.Write(e.ToString());
        return null;
      }

    }









    /// <summary>
    /// Создание файла данных.
    /// </summary>
    //  public static void Serrial()
    //  {
    //      ItemArea[] data = new ItemArea[7];

    //data[0] = new ItemArea()
    //{
    //  Id = "1",
    //  Name = "УЧАСТОК № 1",
    //  Adress = "(тел. 62-86-83)",
    //  Phone = "г. Магадан, 2-ой проезд Горького, д. 5а (каб. № 1,2)",

    //  Street = new ItemStreet[14]
    //};
    //data[0].Street[0] = new ItemStreet()
    //{
    //  Name = "Болдырева	ул.",
    //  House = new string[] { "2а", "3", "4", "5а", "5б", "6", "6а", "10" }
    //};
    //data[0].Street[1] = new ItemStreet()
    //{
    //  Name = "Вострецова ул.",
    //  House = new string[] { "2/25", "3", "4", "5", "6", "8", "10" }
    //};
    //data[0].Street[2] = new ItemStreet();
    //      data[0].Street[2].Name = "Гагарина	ул.";
    //      data[0].Street[2].House = new string[] { "5а", "5б", "7а", "7б", "9 - расс", "9а", "9б", "13/61", "17а - расселен", "19 - расс", "19а - расселен", "21", "21а", "23", "23а", "23б", "25а", "25б", "27" };

    //      data[0].Street[3] = new ItemStreet();
    //      data[0].Street[3].Name = "Горького	ул.";
    //      data[0].Street[3].House = new string[] { "7", "8", "11", "15", "15а", "16-б - рас", "17 - расс", "17а - расс", "19", "19а" };

    //      data[0].Street[4] = new ItemStreet();
    //      data[0].Street[4].Name = "Горького	пл.";
    //      data[0].Street[4].House = new string[] { "2", "3", "3а", "3б", "4", "6", "7", "7а" };

    //      data[0].Street[5] = new ItemStreet();
    //      data[0].Street[5].Name = "Горького	проезд 2-ой	";
    //      data[0].Street[5].House = new string[] { "5", "5/1 - расселен", "5а" };

    //      data[0].Street[6] = new ItemStreet();
    //      data[0].Street[6].Name = "Горького	пл.	2";
    //      data[0].Street[6].House = new string[] { "3", "3а", "3б", "4", "6", "7", "7а" };

    //      data[0].Street[7] = new ItemStreet();
    //      data[0].Street[7].Name = "Дзержинского	ул.";
    //      data[0].Street[7].House = new string[] { "3", "3а", "5", "10", "12", "12а", "14", "14а", "20", "20а - рас", "21", "22", "22а - расселен" };

    //      data[0].Street[8] = new ItemStreet();
    //      data[0].Street[8].Name = "К.Маркса	пр.";
    //      data[0].Street[8].House = new string[] { "4", "6-а - расселен", "8", "11а", "13", "14", "14 кор.1", "16", "18", "20", "20 кор.1", "22", "23", "25", "27", "31/18", "32", "33/15", "34", "36/20", "37", "38", "39", "40", "41", "43", "44", "47", "47-а - расселен", "47-в - расселен", "47-г - расселен", "49", "50", "51", "54", "54а", "56", "57", "59", "61/1", "62", "62а", "62б", "63/1", "64", "65", "65а", "65б", "65в", "67", "67а", "67б", "71", "72/2", "72а", "73", "74", "74а", "76-общ", "76а", "78", "78а", "80", "80а", "82", "82а", "84" };

    //      data[0].Street[9] = new ItemStreet();
    //      data[0].Street[9].Name = "Космонавтов	пл.";
    //      data[0].Street[9].House = new string[] { "1/27", "3/2", "72" };

    //      data[0].Street[10] = new ItemStreet();
    //      data[0].Street[10].Name = "Пролетарская	ул.";
    //      data[0].Street[10].House = new string[] { "16", "18", "20а", "22а", "24", "24а", "26/2", "26а", "30", "32", "34", "34 кор. 1", "36", "38", "40" };

    //      data[0].Street[11] = new ItemStreet();
    //      data[0].Street[11].Name = "Пушкина	ул.";
    //      data[0].Street[11].House = new string[] { "9" };

    //      data[0].Street[12] = new ItemStreet();
    //      data[0].Street[12].Name = "Транспортная	ул.";
    //      data[0].Street[12].House = new string[] { "10", "11", "12", "14", "17", "19", "21", "25", "27-общ", "29" };

    //      data[0].Street[13] = new ItemStreet();
    //      data[0].Street[13].Name = "Школьный	пер.";
    //      data[0].Street[13].House = new string[] { "1", "5-б - зарегистр. н", "10" };

    //      data[1] = new ItemArea();
    //      data[1].Id = "2";
    //      data[1].Name = "УЧАСТОК № 2";
    //      data[1].Adress = "(тел. 62-86-70)";
    //      data[1].Phone = "г. Магадан, 2-ой проезд Горького, д. 5а (каб. № 1,2)";


    //      data[1].Street = new ItemStreet[29];

    //      data[1].Street[0] = new ItemStreet();
    //      data[1].Street[0].Name = "2-ая Сибирская ул.";
    //      data[1].Street[0].House = new string[] { "7 - ветхи", "18б - расселен" };

    //      data[1].Street[1] = new ItemStreet();
    //      data[1].Street[1].Name = "2-ой Транспортный	переулок";
    //      data[1].Street[1].House = new string[] { "6" };

    //      data[1].Street[2] = new ItemStreet();
    //      data[1].Street[2].Name = "Арманская	ул.";
    //      data[1].Street[2].House = new string[] { "22", "29а", "37/1", "39 - ветхий", "40", "41", "41а - вет", "45/2", "45/4", "45а - вет", "45в - зарегистр.", "49", "49а", "51", "51/1" };

    //      data[1].Street[3] = new ItemStreet();
    //      data[1].Street[3].Name = "Брусничная ул.";
    //      data[1].Street[3].House = new string[] { "28-б - зарегистр. нет" };

    //      data[1].Street[4] = new ItemStreet();
    //      data[1].Street[4].Name = "Верхняя ул.";
    //      data[1].Street[4].House = new string[] { "21", "25 - ветхий" };

    //      data[1].Street[5] = new ItemStreet();
    //      data[1].Street[5].Name = "Железнодорожный 2-ой пер.";
    //      data[1].Street[5].House = new string[] { "9а - расселен" };

    //      data[1].Street[6] = new ItemStreet();
    //      data[1].Street[6].Name = "Железнодорожный 3-й пер.";
    //      data[1].Street[6].House = new string[] { "11 - расс", "14", "23а" };

    //      data[1].Street[7] = new ItemStreet();
    //      data[1].Street[7].Name = "Зайцева ул.";
    //      data[1].Street[7].House = new string[] { "1а - ветх", "9 - расселен", "22 - ветхий", "24 - ветхий", "25", "25/1", "25а", "27", "27/2 - с 1-30, с 61-76 27/3	29" };

    //      data[1].Street[8] = new ItemStreet();
    //      data[1].Street[8].Name = "Западная	ул.";
    //      data[1].Street[8].House = new string[] { "2", "14 - ветхий", "19 - расселен" };

    //      data[1].Street[9] = new ItemStreet();
    //      data[1].Street[9].Name = "Иультинская ул.";
    //      data[1].Street[9].House = new string[] { "49" };

    //      data[1].Street[10] = new ItemStreet();
    //      data[1].Street[10].Name = "Колымское	ш.";
    //      data[1].Street[10].House = new string[] { "9", "9а", "9б", "11", "11а", "11б" };

    //      data[1].Street[11] = new ItemStreet();
    //      data[1].Street[11].Name = "Космонавтов	пл.";
    //      data[1].Street[11].House = new string[] { "5", "5а", "7" };

    //      data[1].Street[12] = new ItemStreet();
    //      data[1].Street[12].Name = "Кузнечная	ул.";
    //      data[1].Street[12].House = new string[] { "14а", "16а" };

    //      data[1].Street[13] = new ItemStreet();
    //      data[1].Street[13].Name = "Левонабережная	ул.";
    //      data[1].Street[13].House = new string[] { "19", "23", "25" };

    //      data[1].Street[14] = new ItemStreet();
    //      data[1].Street[14].Name = "Ленина	ул.";
    //      data[1].Street[14].House = new string[] { "5", "6", "7", "8", "10", "11", "12", "14", "16а", "18а", "22/2", "26", "28", "30", "32" };

    //      data[1].Street[15] = new ItemStreet();
    //      data[1].Street[15].Name = "Литейная	ул.";
    //      data[1].Street[15].House = new string[] { "27" };

    //      data[1].Street[16] = new ItemStreet();
    //      data[1].Street[16].Name = "Метеостанция	ул.";
    //      data[1].Street[16].House = new string[] { "5а - расс", "5б - расселен", "5в - расселен", "7в" };

    //      data[1].Street[17] = new ItemStreet();
    //      data[1].Street[17].Name = "Морская	ул.";
    //      data[1].Street[17].House = new string[] { "19/18-о", "19/20", "22/18" };

    //      data[1].Street[18] = new ItemStreet();
    //      data[1].Street[18].Name = "Парковая	ул.";
    //      data[1].Street[18].House = new string[] { "1", "2", "3", "10", "21", "21/1", "21/2", "21/3", "24", "27", "27а", "27б", "31/10" };

    //      data[1].Street[19] = new ItemStreet();
    //      data[1].Street[19].Name = "Пушкина	ул.";
    //      data[1].Street[19].House = new string[] { "4а", "7" };

    //      data[1].Street[20] = new ItemStreet();
    //      data[1].Street[20].Name = "Речная	ул.";
    //      data[1].Street[20].House = new string[] { "8а-общ", "12", "12а", "12б", "14", "14а", "14б", "16 - зарег", "57-общ", "59", "59/3", "61/2", "61/3", "61/4", "63", "63/1", "63/2", "63/3", "63/4", "65", "65/1" };

    //      data[1].Street[21] = new ItemStreet();
    //      data[1].Street[21].Name = "Скуридина	ул.";
    //      data[1].Street[21].House = new string[] { "1/23", "3", "4", "6", "6а", "10" };

    //      data[1].Street[22] = new ItemStreet();
    //      data[1].Street[22].Name = "Советская	ул.";
    //      data[1].Street[22].House = new string[] { "5", "7", "19/1", "20 - кондомин", "21", "23", "23 к.1", "28" };

    //      data[1].Street[23] = new ItemStreet();
    //      data[1].Street[23].Name = "Солдатенко	ул.";
    //      data[1].Street[23].House = new string[] { "4а", "6 - ветхий", "6а - ветхий", "8а" };

    //      data[1].Street[24] = new ItemStreet();
    //      data[1].Street[24].Name = "Чубарова	ул.";
    //      data[1].Street[24].House = new string[] { "3 - доля", "4", "4а", "6", "6а", "8 - рассел", "8а", "10" };

    //      data[1].Street[25] = new ItemStreet();
    //      data[1].Street[25].Name = "Ш.Шимича	ул.";
    //      data[1].Street[25].House = new string[] { "3", "3/1", "3/2", "3/3", "7/3", "8 - ветхий", "9", "9/2", "10 - ветхий", "11", "11/1", "11/3", "12 - ветхий", "13 - вет", "14", "15", "16", "16б", "17", "17а", "20" };

    //      data[1].Street[26] = new ItemStreet();
    //      data[1].Street[26].Name = "Швейников	пер.";
    //      data[1].Street[26].House = new string[] { "15", "17", "17а" };

    //      data[1].Street[27] = new ItemStreet();
    //      data[1].Street[27].Name = "Энергостроителей	ул.";
    //      data[1].Street[27].House = new string[] { "3 - ветхи", "3/1 - ветхий", "3г", "3д - ветхий", "3е", "4 - ветхий", "5б", "6 - ветхий", "6/1 - ветхий", "6/2", "7", "7 к.1", "7а - ветхий", "7б - вет", "8 - ветхий", "8/1 - вет", "8 к.2", "9", "9/1", "9/2" };

    //      data[1].Street[28] = new ItemStreet();
    //      data[1].Street[28].Name = "Южная	ул.";
    //      data[1].Street[28].House = new string[] { "1а", "3а - расселен" };





    //      data[2] = new ItemArea();
    //      data[2].Id = "3";
    //      data[2].Name = "УЧАСТОК № 3";
    //      data[2].Adress = "г. Магадан, ул. Горького, д. 16 (каб. № 103)";
    //      data[2].Phone = "(тел. 65-35-62)";
    //      data[2].Street = new ItemStreet[6];

    //      data[2].Street[0] = new ItemStreet();
    //      data[2].Street[0].Name = "Гагарина	ул.";
    //      data[2].Street[0].House = new string[] { "10/31", "14а", "14б", "14в", "14г", "15", "16", "16а", "22", "28б", "28в", "30б", "30в", "32б", "32в", "33", "35", "36", "38", "40", "44/1", "46", "46а", "46б", "46в", "48", "50", "52", "54" };

    //      data[2].Street[1] = new ItemStreet();
    //      data[2].Street[1].Name = "Заводской	пер. ";
    //      data[2].Street[1].House = new string[] { "5", "5а" };

    //      data[2].Street[2] = new ItemStreet();
    //      data[2].Street[2].Name = "Лукса	ул.";
    //      data[2].Street[2].House = new string[] { "1", "2", "3", "4", "4а", "4б", "5", "6", "8", "9", "10", "10а ", "11", "12", "13", "14", "15", "15а ", "17а" };

    //      data[2].Street[3] = new ItemStreet();
    //      data[2].Street[3].Name = "Н.р.Магаданки	ул.";
    //      data[2].Street[3].House = new string[] { "13", "15 к.1", "43/2", "57/1", "59", "61", "65/1" };

    //      data[2].Street[4] = new ItemStreet();
    //      data[2].Street[4].Name = "Наровчатова	ул.";
    //      data[2].Street[4].House = new string[] { "3", "3/1", "4", "4а", "5", "5/1", "6", "6а", "7", "7а", "8", " 9а", " 9в", " 11/69", " 16", " 17", " 19", " 20", " 21" };

    //      data[2].Street[5] = new ItemStreet();
    //      data[2].Street[5].Name = "Якутская	ул.";
    //      data[2].Street[5].House = new string[] { "3", "4", "4а", "5", "5/1", "6", "6а", "7", "9", "10", "14", "39", "41", "41а", "43", "43а", "45", "48", "51", "51б", "51в", "51 к.1 ", "54", "55", "58/18", "59", "60", "64а", "66а", "67", "68", "69б" };

    //      data[3] = new ItemArea();
    //      data[3].Id = "3";
    //      data[3].Name = "УЧАСТОК № 3";
    //      data[3].Adress = "г. Магадан, ул. Горького, д. 16 (каб. № 108)";
    //      data[3].Phone = "(тел. 62-94-56)";

    //      data[3].Street = new ItemStreet[4];

    //      data[3].Street[0] = new ItemStreet();
    //      data[3].Street[0].Name = "Кольцевая	ул.";
    //      data[3].Street[0].House = new string[] { "8 - рассе", "10", "14", "22", "26", "28", "28а", "30а", "34б", "34в", "34г", "36", "36/1", "36а", "38", "38а", "38б", "40", "44", "46", "48", "48а", "50", "52", "52а", "56", "58", "64а" };

    //      data[3].Street[1] = new ItemStreet();
    //      data[3].Street[1].Name = "Марчеканская	ул. ";
    //      data[3].Street[1].House = new string[] { "2", "2а", "2 к.1", "2/1", "4", "6", "15", "16", "17" };

    //      data[3].Street[2] = new ItemStreet();
    //      data[3].Street[2].Name = "Марчеканский	пер.";
    //      data[3].Street[2].House = new string[] { "5", "7", "7а", "7а-общ", "9", "11-общ", "13", "15", "15/1", "15в", "15г", "17", "17-общ", "17б", "17в", "19", "19а", "37" };

    //      data[3].Street[3] = new ItemStreet();
    //      data[3].Street[3].Name = "Марчеканское	ш.";
    //      data[3].Street[3].House = new string[] { "5", "7", "8 - расселен", "9", "10", "10 к.1", "11", "12 - рассе", "13", "15", "16", "17", "18", "20", "22/2", "24", "26", "28", "28а", "34/1", "36", "38", "38а", "38а к.3" };


    //      data[4] = new ItemArea();
    //      data[4].Id = "4";
    //      data[4].Name = "УЧАСТОК № 4";
    //      data[4].Adress = "г. Магадан, ул. Горького, д. 16 (каб. № 102)";
    //      data[4].Phone = "(тел. 65-35-62)";

    //      data[4].Street = new ItemStreet[21];

    //      data[4].Street[0] = new ItemStreet();
    //      data[4].Street[0].Name = "Билибина	ул. ";
    //      data[4].Street[0].House = new string[] { "2", "3", "5", "6", "6а", "11", "13", "14", "15", "16", "18", "22", "24", "26", "29" };

    //      data[4].Street[1] = new ItemStreet();
    //      data[4].Street[1].Name = "Гагарина	ул.";
    //      data[4].Street[1].House = new string[] { "2", "2а", "4", "4а", "6", "6а" };

    //      data[4].Street[2] = new ItemStreet();
    //      data[4].Street[2].Name = "Загородная 2-ая	ул.";
    //      data[4].Street[2].House = new string[] { "9", "10" };

    //      data[4].Street[3] = new ItemStreet();
    //      data[4].Street[3].Name = "Загородный	пр.";
    //      data[4].Street[3].House = new string[] { "3", "8", "10" };

    //      data[4].Street[4] = new ItemStreet();
    //      data[4].Street[4].Name = "Загородный 1-й	пер.";
    //      data[4].Street[4].House = new string[] { "1" };

    //      data[4].Street[5] = new ItemStreet();
    //      data[4].Street[5].Name = "Зеленая	ул.";
    //      data[4].Street[5].House = new string[] { "4б" };

    //      data[4].Street[6] = new ItemStreet();
    //      data[4].Street[6].Name = "Клубная	ул.";
    //      data[4].Street[6].House = new string[] { "20а", "30", "40/40" };

    //      data[4].Street[7] = new ItemStreet();
    //      data[4].Street[7].Name = "Коммуны	ул.";
    //      data[4].Street[7].House = new string[] { "2", "3", "5", "7", "9", "10", "11", "12", "13", "13а", "15", "17" };

    //      data[4].Street[8] = new ItemStreet();
    //      data[4].Street[8].Name = "Комсомольская	пл.";
    //      data[4].Street[8].House = new string[] { "2", "4" };

    //      data[4].Street[9] = new ItemStreet();
    //      data[4].Street[9].Name = "Комсомольская	ул.";
    //      data[4].Street[9].House = new string[] { "33б", "35б", "37б" };

    //      data[4].Street[10] = new ItemStreet();
    //      data[4].Street[10].Name = "Нагаевская	ул. ";
    //      data[4].Street[10].House = new string[] { "46", "51", "51б", "53", "55", "57" };

    //      data[4].Street[11] = new ItemStreet();
    //      data[4].Street[11].Name = "Новая	ул.";
    //      data[4].Street[11].House = new string[] { "17", "23", "27а", "27б", "29б", "29в", "34а", "36", "38" };

    //      data[4].Street[12] = new ItemStreet();
    //      data[4].Street[12].Name = "Ново-Нагаевская	ул. ";
    //      data[4].Street[12].House = new string[] { "6", "8", "19", "20" };

    //      data[4].Street[13] = new ItemStreet();
    //      data[4].Street[13].Name = "Октябрьская	ул.";
    //      data[4].Street[13].House = new string[] { "6", "9", "10 - не наше кв 43-98", "20", "20/1" };

    //      data[4].Street[14] = new ItemStreet();
    //      data[4].Street[14].Name = "Полярная	ул.";
    //      data[4].Street[14].House = new string[] { "1", "2/1", "3", "4/1", "4/20", "5", "6/17", "7", "8", "9", "11", "15", "21", "23", "23-общ" };

    //      data[4].Street[15] = new ItemStreet();
    //      data[4].Street[15].Name = "Портовая	ул.";
    //      data[4].Street[15].House = new string[] { "1", "3", "3а", "4", "5", "5а", "5б", "5в", "5г", "5д", "5е", "7", "7а", "7б", "7б-общ ", "9", "11/2", "13а", "23-б", "25/21", "26 к.1 ", "27", "27/1", "29", "31/12", "33", "38", "15", "15а", "17", "19", "19б", "21", "21а", "23", "23-а", "38 к.2", "38 к.3" };

    //      data[4].Street[16] = new ItemStreet();
    //      data[4].Street[16].Name = "Потапова	ул.";
    //      data[4].Street[16].House = new string[] { "9" };

    //      data[4].Street[17] = new ItemStreet();
    //      data[4].Street[17].Name = "Приморская	ул.";
    //      data[4].Street[17].House = new string[] { "1", "1а", "7", "7 к.1	", "7 к.2" };

    //      data[4].Street[18] = new ItemStreet();
    //      data[4].Street[18].Name = "Флотская	ул.";
    //      data[4].Street[18].House = new string[] { "4", "6", "6 к.1", "6 к.1-общ", "6 к.2", "7", "8", "20/8", "22" };

    //      data[4].Street[19] = new ItemStreet();
    //      data[4].Street[19].Name = "Широкая	ул.";
    //      data[4].Street[19].House = new string[] { "3", "5", "21 - расселен", "44" };

    //      data[4].Street[20] = new ItemStreet();
    //      data[4].Street[20].Name = "Ясная	ул. ";
    //      data[4].Street[20].House = new string[] { "3", "5а (арх)", "8", "9", "12", "14" };




    //      data[5] = new ItemArea();
    //      data[5].Id = "5";
    //      data[5].Name = "УЧАСТОК № 5";
    //      data[5].Adress = "г. Магадан, Набережная реки Магаданки, д. 55";
    //      data[5].Phone = "(тел. 60-44-50)";

    //      data[5].Street = new ItemStreet[20];

    //      data[5].Street[0] = new ItemStreet();
    //      data[5].Street[0].Name = "Бассейновый	пер. ";
    //      data[5].Street[0].House = new string[] { "10", "10а", "10б" };

    //      data[5].Street[1] = new ItemStreet();
    //      data[5].Street[1].Name = "Веселый	пр.";
    //      data[5].Street[1].House = new string[] { "4-общ" };

    //      data[5].Street[2] = new ItemStreet();
    //      data[5].Street[2].Name = "Веселый ключ	ул.";
    //      data[5].Street[2].House = new string[] { "4 - рассе", "6", "10 - расселен" };

    //      data[5].Street[3] = new ItemStreet();
    //      data[5].Street[3].Name = "Гертнера	ул.";
    //      data[5].Street[3].House = new string[] { "6-б -кв 6", "12а" };

    //      data[5].Street[4] = new ItemStreet();
    //      data[5].Street[4].Name = "Дальняя	ул. ";
    //      data[5].Street[4].House = new string[] { "7" };

    //      data[5].Street[5] = new ItemStreet();
    //      data[5].Street[5].Name = "Дачная	ул.";
    //      data[5].Street[5].House = new string[] { "11/4" };

    //      data[5].Street[6] = new ItemStreet();
    //      data[5].Street[6].Name = "Лесная	ул.";
    //      data[5].Street[6].House = new string[] { "3" };

    //      data[5].Street[7] = new ItemStreet();
    //      data[5].Street[7].Name = "Магаданская	ул.";
    //      data[5].Street[7].House = new string[] { "6" };

    //      data[5].Street[8] = new ItemStreet();
    //      data[5].Street[8].Name = "Н.р.Магаданки	ул.";
    //      data[5].Street[8].House = new string[] { "1", "3", "5", "12", "13/1", "15", "15 к.2", "15 к.3", "15 к.4", "43 к.1", "45", "45 к.1", "47", "49", "49 к.1", "51", "51 к.2", "53", "55", "55 к.1", "55 к.2", "55 к.3", "55 к.4", "57", "57 к.2", "57 к.3", "59 к.1", "63", "65", "65 к.2", "65 к.3", "67", "69", "71", "71 к.2", "71 к.3", "71 к.4", "73", "73 к.2", "73 к.3", "73 к.4", "75 к.2", "79", "81", "83", "85", "87" };

    //      data[5].Street[9] = new ItemStreet();
    //      data[5].Street[9].Name = "Первомайская	ул.";
    //      data[5].Street[9].House = new string[] { "13", "14", "15", "16", "18 - рас", "19", "20", "23", "24", "25", "26", "27", "28", "46 - расселен" };

    //      data[5].Street[10] = new ItemStreet();
    //      data[5].Street[10].Name = "Подгорная	ул. ";
    //      data[5].Street[10].House = new string[] { "8 - рассе", "11  - кв 2 ком 1+2", "12 - расселен", "12/1", "13", "15 - расс", "15/1", "17 - расселен", "19" };

    //      data[5].Street[11] = new ItemStreet();
    //      data[5].Street[11].Name = "Пролетарская	ул.";
    //      data[5].Street[11].House = new string[] { "1", "1а", "2", "3а", "3/1", "3/2", "3/3", "4", "25 к.4", "42/1", "44", "46", "46/1", "46/2", "50/1", "50/2", "55", "55/1", "57", "59", "59/1", "61", "61/1", "61/2", "61/3", "61/4", "61/4а", "61/5", "63 к.1", "65 к.1", "65 к.2", "65 к.3", "68а", "70", "70а    ", "71 к.1 ", "71 к.2 ", "72     ", "74     ", "75     ", "76     ", "78     ", "79     ", "79 к.1 ", "79 к.2", "80", "80а", "81 - с 1 по 165 кв", "81 к.1 ", "81 к.2 ", "82", "84", "86", "88", "90/2", "108/6", "108 к.1", "112", "112 к.1", "114 к.1", "114 к.2", "116", "116 к.1", "118 к.2" };

    //      data[5].Street[12] = new ItemStreet();
    //      data[5].Street[12].Name = "Пролетарский 2-ой	пер.";
    //      data[5].Street[12].House = new string[] { "6а" };

    //      data[5].Street[13] = new ItemStreet();
    //      data[5].Street[13].Name = "Промышленный	проезд";
    //      data[5].Street[13].House = new string[] { "7" };

    //      data[5].Street[14] = new ItemStreet();
    //      data[5].Street[14].Name = "Репина	ул.";
    //      data[5].Street[14].House = new string[] { "1", "3", "5", "9", "12", "13", "14", "16", "19", "21" };

    //      data[5].Street[15] = new ItemStreet();
    //      data[5].Street[15].Name = "Рыбозаводская	ул.";
    //      data[5].Street[15].House = new string[] { "1б", "1/4", "1/4а", "2в", "2г", "6 - рассел", "8а", "14", "15 - расселен", "16", "19а", "21а" };

    //      data[5].Street[16] = new ItemStreet();
    //      data[5].Street[16].Name = "Рыбозаводской	пер.";
    //      data[5].Street[16].House = new string[] { "4", "5 - расселен" };

    //      data[5].Street[17] = new ItemStreet();
    //      data[5].Street[17].Name = "Санаторная	ул.";
    //      data[5].Street[17].House = new string[] { "15" };


    //      data[5].Street[18] = new ItemStreet();
    //      data[5].Street[18].Name = "Совхозная 1-ая	ул. ";
    //      data[5].Street[18].House = new string[] { "2 к.1" };

    //      data[5].Street[19] = new ItemStreet();
    //      data[5].Street[19].Name = "Совхозная 2-ая	ул.";
    //      data[5].Street[19].House = new string[] { "6 - 1 лиц. счет" };

    //      data[6] = new ItemArea();
    //      data[6].Id = "6";
    //      data[6].Name = "УЧАСТОК № 6";
    //      data[6].Adress = "г. Магадан, ул. Попова, д. 7, корп. 4";
    //      data[6].Phone = "(тел. 64-29-31)";

    //      data[6].Street = new ItemStreet[19];

    //      data[6].Street[0] = new ItemStreet();
    //      data[6].Street[0].Name = "14/3- км. Основной трассы-об";
    //      data[6].Street[0].House = new string[] { "" };

    //      data[6].Street[1] = new ItemStreet();
    //      data[6].Street[1].Name = "2-ая Транспортная	ул.";
    //      data[6].Street[1].House = new string[] { "16", "23" };

    //      data[6].Street[2] = new ItemStreet();
    //      data[6].Street[2].Name = "Авиационная	ул.";
    //      data[6].Street[2].House = new string[] { "3", "10", "11", "11а", "14" };

    //      data[6].Street[3] = new ItemStreet();
    //      data[6].Street[3].Name = "Аммональная	ул.";
    //      data[6].Street[3].House = new string[] { "17" };

    //      data[6].Street[4] = new ItemStreet();
    //      data[6].Street[4].Name = "Береговая	ул.";
    //      data[6].Street[4].House = new string[] { "10" };

    //      data[6].Street[5] = new ItemStreet();
    //      data[6].Street[5].Name = "Берзина	ул.";
    //      data[6].Street[5].House = new string[] { "2", "3", "3а", "3б", "3в", "4", "4/1", "4/2", "5", "5а", "5б", "5в", "6", "7", "7а", "7в", "8", "9", "9а", "9в", "11", "11а", "11б", "11в", "13", "13а", "13б", "17", "17а", "17б", "19", "19а", "19б", "21", "21а", "21б", "23", "27", "29", "31", "33" };

    //      data[6].Street[6] = new ItemStreet();
    //      data[6].Street[6].Name = "ДОС-1";
    //      data[6].Street[6].House = new string[] { "" };

    //      data[6].Street[7] = new ItemStreet();
    //      data[6].Street[7].Name = "Колымская	ул.";
    //      data[6].Street[7].House = new string[] { "1б", "5", "6", "6 к.1", "6 к.2", "6 к.3", "7 к.1", "8 к.1", "9", "9а", "9б", "10/1", "10/2", "10а", "10б", "10в", "11", "11а", "12", "12 к.1", "12а", "14", "14а", "15", "15а", "16", "16а", "17а/1", "17а/2", "17в", "18", "18а", "20", "20-а", "22", "24", "26" };

    //      data[6].Street[8] = new ItemStreet();
    //      data[6].Street[8].Name = "Колымское	ш.";
    //      data[6].Street[8].House = new string[] { "4", "4 к.1", "4 к.2", "4 к.3", "6", "6а", "8а", "8/2", "8 к.3", "10в", "11 к.1", "12", "13", "14", "14 к.1", "14 к.2", "14 к.3" };

    //      data[6].Street[9] = new ItemStreet();
    //      data[6].Street[9].Name = "ЛОС";
    //      data[6].Street[9].House = new string[] { "1", "2" };

    //      data[6].Street[10] = new ItemStreet();
    //      data[6].Street[10].Name = "Майская	ул.";
    //      data[6].Street[10].House = new string[] { "5", "8а", "10а", "12а" };

    //      data[6].Street[11] = new ItemStreet();
    //      data[6].Street[11].Name = "Пионерская	ул.";
    //      data[6].Street[11].House = new string[] { "1", "2а", "3", "3 к.1", "6", "13" };

    //      data[6].Street[12] = new ItemStreet();
    //      data[6].Street[12].Name = "Попова	ул.";
    //      data[6].Street[12].House = new string[] { "2", "2 к.1", "2а", "2в", "2г", "3", "3 к.1", "3 к.2", "3 к.3", "4", "4а", "5", "5 к.1", "5 к.2", "5 к.3", "6", "6а", "7", "7 к.1", "7 к.2", "7 к.3", "7 к.4", "7 к.5" };

    //      data[6].Street[13] = new ItemStreet();
    //      data[6].Street[13].Name = "Радистов	ул.";
    //      data[6].Street[13].House = new string[] { "2", "3", "6", "7", "8", "9", "11", "13" };

    //      data[6].Street[14] = new ItemStreet();
    //      data[6].Street[14].Name = "Раздольная	ул.";
    //      data[6].Street[14].House = new string[] { "2" };

    //      data[6].Street[15] = new ItemStreet();
    //      data[6].Street[15].Name = "Садовая	ул.";
    //      data[6].Street[15].House = new string[] { "3", "9", "11", "13", "15", "25а", "27", "27а", "27б", "29", "31" };

    //      data[6].Street[16] = new ItemStreet();
    //      data[6].Street[16].Name = "Снежная	ул.";
    //      data[6].Street[16].House = new string[] { "51", "52", "54" };

    //      data[6].Street[17] = new ItemStreet();
    //      data[6].Street[17].Name = "Шмелева	ул. ";
    //      data[6].Street[17].House = new string[] { "1", "2", "3", "10/а", "11/а", "13", "19", "22" };

    //      data[6].Street[18] = new ItemStreet();
    //      data[6].Street[18].Name = "Ямская	ул.";
    //      data[6].Street[18].House = new string[] { "2", "4", "6", "8", "10" };


    //      string Path = ConfigurationManager.AppSettings["PathAreaGorZhilServic"];
    //      using (FileStream fs = new FileStream(HttpContext.Current.Server.MapPath(Path), FileMode.Create))
    //      {
    //          XmlSerializer formatter = new XmlSerializer(typeof(ItemArea[]));
    //          formatter.Serialize(fs, data);

    //      }


    //  }







  }




}