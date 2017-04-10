using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel.Web;
using System.Web;

namespace LibraryService
{
  /// <summary>
  /// Полный дата контракт списка ОГВ
  /// </summary>
  [DataContract]
  public class ItemOgvKB
  {
    [DataMember(Order = 0)]
    public string Id { get; set; }
    [DataMember(Order = 1)]
    public string Name { get; set; }
    [DataMember(Order = 2)]
    public string SlName { get; set; }
    [DataMember(Order = 3)]
    public string VidDepartament { get; set; }
    [DataMember(Order = 4)]
    public string IdFrgu { get; set; }
    [DataMember(Order = 5)]
    public string Territory { get; set; }
    [DataMember(Order = 6)]
    public string Ogrn { get; set; }
    [DataMember(Order = 7)]
    public string Inn { get; set; }
    [DataMember(Order = 8)]
    public string Adress { get; set; }
    [DataMember(Order = 9)]
    public string FIORuk { get; set; }
    [DataMember(Order = 10)]
    public string ParentOgv { get; set; }
    [DataMember(Order = 11)]
    public string Phone { get; set; }
    [DataMember(Order = 12)]
    public string Note { get; set; }
    [DataMember(Order = 13)]
    public string Map { get; set; }
    [DataMember(Order = 14)]
    public ItemService[] Services { get; set; }

  }
  /// <summary>
  /// Полный дата контракт списка услуг
  /// </summary>
  [DataContract]
  public class ItemService
  {
    [DataMember(Order = 0)]
    public string Id { get; set; }
    [DataMember(Order = 1)]
    public string IdFrgu { get; set; }
    [DataMember(Order = 2)]
    public string Name { get; set; }
    [DataMember(Order = 4)]
    public string SlName { get; set; }
    [DataMember(Order = 5)]
    public string Category { get; set; }
    [DataMember(Order = 6)]
    public bool FlPeople { get; set; }
    [DataMember(Order = 7)]
    public bool UnPeople { get; set; }
    [DataMember(Order = 8)]
    public bool IpPeople { get; set; }
    [DataMember(Order = 9)]
    public bool ParentPeople { get; set; }
    [DataMember(Order = 10)]
    public bool NoNationaly { get; set; }
    [DataMember(Order = 11)]
    public string Text { get; set; }
    [DataMember(Order = 12)]
    public bool InAis { get; set; }
    [DataMember(Order = 13)]
    public string DataAccess { get; set; }
  }

  [DataContract]






//Основные таблицы
//      Ogv - Список ОГВ
//          id - Идентификатор
//          Name - Название
//          Slname - Сокрашенное название
//          VidDepartment - Федеральный
//		            - Муниципальный
//		            - Региональный
//          IdFrgu - Идентификатор ФРГУ
//          Territory - Территориальное направленность
//          Ogrn - ОГРН
//          Inn - ИНН
//          Adress - Адрес
//          FIORuk - ФИО Руководителя
//          ParentOgv - id родительского ОГВ
//          Phone - Телефон
//          Note - Примечания
//          Map    - Картинка с картой отображающее нахождения ОГВ

//      Services - Список услуг
//          Id - Идентификатор
//          IdFrgu - Идентификатор ФРГУ
//          IdDepartment - Идентификатор ОГВ
//          Name - Название
//          SlName - Сокр.название
//          idCategory - Категория услуги
//          FlPeople - Доступно физическим лицам
//          UnPeople - Достпуна юридическим лицам
//          IpPeople - Доступна ИП
//          ParentPeople - Доступно по представителя
//          NoNationaly - Доступна лицам без гражданства
//          Text[html] - Информация по услуги в формате HTML
//          InAis - НАписана в АИС
//          DataAccess - Дата открытия в продуктив.


public class ModelKnowBase
{




    public Stream GetImageOgv(string id)
    {
      string Connect = ConfigurationManager.ConnectionStrings["ConnectAisInfo"].ConnectionString;
      SqlConnection conn = new SqlConnection(Connect);
      SqlCommand Command = new SqlCommand()
      {
        Connection = conn,
        CommandType = CommandType.StoredProcedure,
        CommandText = "[GetImageOgv]",

    };
      Command.Parameters.Add("@id", SqlDbType.Int);
      Command.Parameters["@id"].Value = Convert.ToInt32(id);

      SqlDataAdapter data = new SqlDataAdapter()
      {
        SelectCommand = Command
      };
      DataSet ds = new DataSet();
      data.Fill(ds);
      conn.Close();

      MemoryStream ms = new MemoryStream((byte[])ds.Tables[0].Rows[0].ItemArray[0]);

      //Bitmap bitmap = new Bitmap(pathname);
      //MemoryStream ms = new MemoryStream();
      //bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
      WebOperationContext.Current.OutgoingResponse.ContentType = "image/jpeg";
      return ms;


    }



    public ItemOgvKB[] GetData()
    {
      string Connect = ConfigurationManager.ConnectionStrings["ConnectAisInfo"].ConnectionString;
      SqlConnection conn = new SqlConnection(Connect);
      SqlCommand Command = new SqlCommand()
      {
        Connection = conn,
        CommandType = CommandType.StoredProcedure,
        CommandText = "[GetData]"
      };
      SqlDataAdapter data = new SqlDataAdapter()
      {
        SelectCommand = Command
      };
      DataSet ds = new DataSet();
      data.Fill(ds);
      conn.Close();
      ds.Relations.Add("OgvServices", ds.Tables[0].Columns["Id"], ds.Tables[1].Columns["idOgv"]);
      DataTable Ogv = ds.Tables[0];
      DataTable Services = ds.Tables[1];
      int count = Ogv.Rows.Count;
      ItemOgvKB[] dataOgv = new ItemOgvKB[count];
      for (int i = 0;  i < count; i++)
      {
        dataOgv[i] = new ItemOgvKB()
        {
          Id = Ogv.Rows[i].ItemArray[0].ToString(),
          Name = Ogv.Rows[i].ItemArray[1].ToString(),
          SlName = Ogv.Rows[i].ItemArray[2].ToString(),
          VidDepartament = Ogv.Rows[i].ItemArray[3].ToString(),
          IdFrgu = Ogv.Rows[i].ItemArray[4].ToString(),
          Ogrn = Ogv.Rows[i].ItemArray[5].ToString(),
          Inn = Ogv.Rows[i].ItemArray[6].ToString(),
          Adress = Ogv.Rows[i].ItemArray[7].ToString(),
          FIORuk = Ogv.Rows[i].ItemArray[8].ToString(),
          Phone = Ogv.Rows[i].ItemArray[9].ToString(),
          Note = Ogv.Rows[i].ItemArray[10].ToString(),
        };
        var result = from row in Services.AsEnumerable()
                     where row.Field<int>("idOGV") == Convert.ToInt32(dataOgv[i].Id)
                     select row;
        dataOgv[i].Services = new ItemService[result.Count()];
        int j = 0;
        foreach (var item in result)
        {
          dataOgv[i].Services[j] = new ItemService()
          {
            Id = Services.Rows[j].ItemArray[0].ToString(),
            Name = Services.Rows[j].ItemArray[2].ToString(),
            SlName = Services.Rows[j].ItemArray[3].ToString(),
            IdFrgu = Services.Rows[j].ItemArray[4].ToString(),
            Category = Services.Rows[j].ItemArray[5].ToString(),
            FlPeople = Convert.ToBoolean(Services.Rows[j].ItemArray[6].ToString()),
            UnPeople = Convert.ToBoolean(Services.Rows[j].ItemArray[7].ToString()),
            IpPeople = Convert.ToBoolean(Services.Rows[j].ItemArray[8].ToString()),
            ParentPeople = Convert.ToBoolean(Services.Rows[j].ItemArray[9].ToString()),
            NoNationaly = Convert.ToBoolean(Services.Rows[j].ItemArray[10].ToString()),
            Text = Services.Rows[j].ItemArray[11].ToString(),
            InAis = Convert.ToBoolean(Services.Rows[j].ItemArray[12].ToString()),
            DataAccess = Convert.ToDateTime(Services.Rows[j].ItemArray[13].ToString()).ToShortDateString()
          };
          j++;
        }
      }
      return dataOgv;
    }
}
}