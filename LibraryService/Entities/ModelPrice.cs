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

namespace LibraryService.Price
{
  /// <summary>
  /// Орган власти по которому можно произвести платеж
  /// </summary>
  public class AuthoryPrice
  {
    public int Id { get; set; }
    public string NameOgv { get; set; }
    public string PayeeInn { get; set; }
    public string PersonalAcc { get; set; }
    public string Bic { get; set; }
    public string BankName { get; set; }
    public string Oktmo { get; set; }
    public string Kpp { get; set; }
    public string CorrespAcc { get; set; }

    public List<Purpose> Purposes { get; set; }

  }

  /// <summary>
  /// Вид платежа по органу власти.
  /// </summary>
  public class Purpose
  {
    public int Id { get; set; } 
    public string Name { get; set; }
    public string Kbk { get; set; }
    public string Sum { get; set; }

    public int AuthoryPriceId { get; set; }
  }
  /// <summary>
  /// Список документов ГИС ГМП
  /// </summary>
  public class Document
  {
    public int Id { get; set; }
    public string Key { get; set; }
    public string Name { get; set; }
  }



  
    







}

