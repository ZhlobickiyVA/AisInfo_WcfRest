
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService
{
  /// <summary>
  /// Контракт дополнительной справочной информации.
  /// </summary>
  [ServiceContract]
  interface IServInfo
  {
    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "Connect")]
    string Connect();

    /// <summary>
    /// Список участков ГорЖилСервиса
    /// </summary>
    /// <returns></returns>
    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "GetListArea")]
    ItemArea[] GetListArea();


    // 

    /// <summary>
    /// Перечень МДОУ
    /// </summary>
    /// <returns></returns>
    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "GetLisMdou")]
    ItemMdou[] GetListMdou();


    // Перечень Льготных категорий граждан, ... первоочередное зачисление в ДОУ.




  }
}
