using iTextSharp.text;
using iTextSharp.text.pdf;
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
          Name = Listdata[i].NameOgv
        };
      }
      return dataRes;
    }
    /// <summary>
    /// Выборки из параметров [Список вариантов платежей по органам власти]
    /// </summary>
    /// <param name="id">Идентификатор ОГВ</param>
    /// <returns></returns>
    public ItemPurpose[] GetListPurpose(int id)
    {
      ItemPurpose[] dataRes = new ItemPurpose[Listdata[id].Purpose.Length];
      for (int i = 0; i < Listdata[id].Purpose.Length; i++)
      {
        dataRes[i] = new ItemPurpose()
        {
          Id = Listdata[id].Purpose[i].Id,
          Name = Listdata[id].Purpose[i].Name
        };
      }
      return dataRes;
    }


    /// <summary>
    /// Получить список ДУЛ для платежного документа
    /// </summary>
    /// <returns></returns>
    public ItemDul[] GetListDul()
    {
      string Path = ConfigurationManager.AppSettings["PathPriceListDul"];
      using (FileStream fs = new FileStream(HttpContext.Current.Server.MapPath(Path), FileMode.Open))
      {
        XmlSerializer formatter = new XmlSerializer(typeof(ItemDul[]));
        ItemDul[] data = (ItemDul[])formatter.Deserialize(fs);
        return data;

      }

    }


    /// <summary>
    /// Получение обьекта содержащий информацию необходимую для формирования Печатной формы
    /// </summary>
    /// <returns>Заполненый массив параметров</returns>
    /// 



    private OrganGV[] GetDataPrice()
    {


      string Path = ConfigurationManager.AppSettings["PathPriceData"];
      using (FileStream fs = new FileStream(HttpContext.Current.Server.MapPath(Path), FileMode.Open
          , FileAccess.Read, FileShare.Read, bufferSize: 4096, useAsync: true))
      {

        XmlSerializer formatter = new XmlSerializer(typeof(OrganGV[]));

        OrganGV[] data = (OrganGV[])formatter.Deserialize(fs);

        return data;
      }






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
      document.Add(new Phrase());

      document.Close();

      bPDF = ms.ToArray();

      return bPDF;
    }





  }
}