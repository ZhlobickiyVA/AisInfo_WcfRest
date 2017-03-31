using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Xml.Serialization;

namespace AisInfoService
{

  /// <summary>
  /// Описывает параметры необходимые для формирования платежного документа.
  /// </summary>
  public class InfoPdf
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public string PayerAdress { get; set; }
    public string Nationaly { get; set; }
    public string PayerIdType { get; set; }
    public string PayerIdNum { get; set; }
    public string IndexOrgan { get; set; }
    public string IndexPurpose { get; set; }
  }

  /// <summary>
  /// Дата контракт для передачи списка огранов власти клиенту.
  /// </summary>
  [DataContract]
  public class ItemOgv
  {
    [DataMember(Order = 0)]
    public string Id { get; set; }
    [DataMember(Order = 1)]
    public string Name { get; set; }
    [DataMember(Order = 2)]
    public ItemPurpose[] Purpose { get; set; }
  }
  /// <summary>
  /// Дата контракт для передачи пользователя 
  /// списка возможных видов платежей.
  /// </summary>
  [DataContract]
  public class ItemPurpose
  {
    [DataMember(Order = 0)]
    public string Id { get; set; }
    [DataMember(Order = 1)]
    public string Name { get; set; }
  }

  [DataContract]
  public class ItemDul
  {
    [DataMember(Order = 0)]
    public string Id { get; set; }
    [DataMember(Order = 1)]
    public string Name { get; set; }
  }


  /// <summary>
  /// Описывает формат хранения информации о Органах власти, 
  /// по которым можно формировать платежный документ
  /// </summary>
  [DataContract]
  public class OrganGV
  {
    [DataMember(Order = 0)]
    public string Id { get; set; }
    [DataMember(Order = 1)]
    public string NameOgv { get; set; }
    [DataMember(Order = 2)]
    public string PayeeInn { get; set; }
    [DataMember(Order = 3)]
    public string PersonalAcc { get; set; }
    [DataMember(Order = 4)]
    public string Bic { get; set; }
    [DataMember(Order = 5)]
    public string BankName { get; set; }
    [DataMember(Order = 6)]
    public string Oktmo { get; set; }
    [DataMember(Order = 7)]
    public string Kpp { get; set; }
    [DataMember(Order = 8)]
    public string CorrespAcc { get; set; }
    [DataMember(Order = 9)]
    public Purpose[] Purpose { get; set; }


  }
  /// <summary>
  /// Описывает возможные варианты платежей по ограну власти
  /// </summary>
  [DataContract]
  public class Purpose
  {
    [DataMember(Order = 0)]
    public string Id { get; set; }
    [DataMember(Order = 1)]
    public string Name { get; set; }
    [DataMember(Order = 2)]
    public string Kbk { get; set; }
    [DataMember(Order = 3)]
    public string Sum { get; set; }
  }






  public class ModelPrice
  {
    public OrganGV[] Listdata { get; set; }
    Object thisLock = new object();


    public ModelPrice()
    {
      Listdata = GetDataPrice();
    }

    /// <summary>
    /// Выборки из параметров [Список органов власти]
    /// </summary>
    /// <returns></returns>
    public ItemOgv[] GetListOgv()
    {

      ItemOgv[] dataRes = new ItemOgv[Listdata.Length];
      for (int i = 0; i < Listdata.Length; i++)
      {
        dataRes[i] = new ItemOgv()
        {
          Id = Listdata[i].Id,
          Name = Listdata[i].NameOgv,
          Purpose = new ItemPurpose[Listdata[i].Purpose.Length]
        };
        for (int j = 0; j < Listdata[i].Purpose.Length; j++)
        {
          dataRes[i].Purpose[j] = new ItemPurpose()
          {
            Id = Listdata[i].Purpose[j].Id,
            Name = Listdata[i].Purpose[j].Name
          };
        }
      }
    
      return dataRes;
    }

  /// <summary>
  /// Получить список ДУЛ для платежного документа
  /// </summary>
  /// <returns></returns>
  public ItemDul[] GetListDul()
  {
      string SQL = "SELECT TOP (1000) [id],[Name] FROM [AisInfo].[dbo].[ListDul]";
      string Connect = ConfigurationManager.ConnectionStrings["ConnectAisInfo"].ConnectionString;
      SqlConnection connection = new SqlConnection(Connect);
      SqlCommand Command = new SqlCommand()
      {
        Connection = connection,
        CommandType = CommandType.Text,
        CommandText = SQL
      };
      SqlDataAdapter data = new SqlDataAdapter()
      {
        SelectCommand = Command
      };
      DataSet ds = new DataSet();
      data.Fill(ds);
      connection.Close();

      List<ItemDul> dul = new List<ItemDul>();

      for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
      {
        ItemDul itDul = new ItemDul()
        {
          Id = ds.Tables[0].Rows[i].ItemArray[0].ToString(),
          Name = ds.Tables[0].Rows[i].ItemArray[1].ToString()
        };
        dul.Add(itDul);
      }

      return dul.ToArray();
    }


  /// <summary>
  /// Получение обьекта содержащий информацию необходимую для формирования Печатной формы
  /// </summary>
  /// <returns>Заполненый массив параметров</returns>
  /// 
  private OrganGV[] GetDataPrice()
  {
      string SQL = "select id,Name,PayeeInn,PersonalAcc,Bic,BankName,Oktmo,Kpp,CorrespAcc from AisInfo..ListOgvPrice select id, Name, Kbk, Sum, idOgvPrice from AisInfo..PurposeOgvPrice; ";
      string Connect = ConfigurationManager.ConnectionStrings["ConnectAisInfo"].ConnectionString;
      SqlConnection connection = new SqlConnection(Connect);
      SqlCommand Command = new SqlCommand()
      {
        Connection = connection,
        CommandType = CommandType.Text,
        CommandText = SQL
      };
      SqlDataAdapter data = new SqlDataAdapter()
      {
        SelectCommand = Command
      };
      DataSet ds = new DataSet();
      data.Fill(ds);
      connection.Close();

      DataTable listOgv = new DataTable();
      listOgv = ds.Tables[0];
      DataTable listpurpose = new DataTable();
      listpurpose = ds.Tables[1];

      OrganGV[] datares = new OrganGV[listOgv.Rows.Count];

      for (int i = 0; i < listOgv.Rows.Count; i++)
      {
        datares[i] = new OrganGV()
        {
          Id = listOgv.Rows[i].ItemArray[0].ToString().Trim(),
          NameOgv = listOgv.Rows[i].ItemArray[1].ToString().Trim(),
          PayeeInn = listOgv.Rows[i].ItemArray[2].ToString().Trim(),
          PersonalAcc = listOgv.Rows[i].ItemArray[3].ToString().Trim(),
          Bic = listOgv.Rows[i].ItemArray[4].ToString().Trim(),
          BankName = listOgv.Rows[i].ItemArray[5].ToString().Trim(),
          Oktmo = listOgv.Rows[i].ItemArray[6].ToString().Trim(),
          Kpp = listOgv.Rows[i].ItemArray[7].ToString().Trim(),
          CorrespAcc = listOgv.Rows[i].ItemArray[8].ToString().Trim()
        };
        List<Purpose> purpose = new List<Purpose>();

        for (int j = 0; j < listpurpose.Rows.Count; j++)
        {
          if (listpurpose.Rows[j].ItemArray[4].ToString().Trim() == datares[i].Id)
          {
            Purpose itPurpose = new Purpose()
            {
              Id = listpurpose.Rows[j].ItemArray[0].ToString().Trim(),
              Name = listpurpose.Rows[j].ItemArray[1].ToString().Trim(),
              Kbk = listpurpose.Rows[j].ItemArray[2].ToString().Trim(),
              Sum = listpurpose.Rows[j].ItemArray[3].ToString().Trim()
            };
            purpose.Add(itPurpose);
          }
        }

        datares[i].Purpose = purpose.ToArray();
        
        


      }




      return datares;

  }

  /// <summary>
  /// Формируем платежный документ
  /// </summary>
  /// <param name="info">Параметры формирования</param>
  /// <returns>Платежный документ в бинарном формате</returns>
  public byte[] GetDocumentPrice(InfoPdf info)
  {
    byte[] bPDF = null;
    MemoryStream ms = new MemoryStream();

    Document document = new Document(PageSize.A4, 27, 30, 15, 10);
    PdfWriter.GetInstance(document, ms);
    document.Open();


      // Вставить таблицу
      TemplatePDF temp = new TemplatePDF(info, this);

      document.Add(temp.GetTable(@"И з в е щ е н и е"));
      document.Add(temp.GetTable(@"К в и т а н ц и я", true));
      document.Add(new Phrase(" "));
      document.Add(new Phrase(" "));
      document.Add(temp.GetTable(@"И з в е щ е н и е"));
      document.Add(temp.GetTable(@"К в и т а н ц и я", true));

      document.Close();

    bPDF = ms.ToArray();

    return bPDF;
  }





}
}