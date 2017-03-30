using AisInfo_Rest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace AisInfo_Rest
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IService" в коде и файле конфигурации.
    [ServiceContract(Namespace = "AisInfo.mfc4900.ru")]
    public interface IService
    {
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "xml/{id}")]
        String XMLData(string id);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "json/{id}")]
        string JSONData(string id);

        [OperationContract]
        [WebInvoke(Method = "GET"
            , ResponseFormat = WebMessageFormat.Xml
            , BodyStyle = WebMessageBodyStyle.Wrapped
            , UriTemplate = "xml/List?LastName={LastName}&FirstName={FirstName}")]
        List<Dou> XMLList(string LastName, string FirstName);

        [OperationContract]
        [WebInvoke(Method = "GET"
    , ResponseFormat = WebMessageFormat.Json
    , BodyStyle = WebMessageBodyStyle.Wrapped
    , UriTemplate = "json/List?LastName={LastName}&FirstName={FirstName}&MiddleName={MiddleName}&BrDate={BrDate}&idDou={idDou}")]
        List<Dou> JSONList(string LastName, string FirstName, string MiddleName,string BrDate,string idDou);
        
          [OperationContract]
        [WebInvoke(Method = "GET"
, ResponseFormat = WebMessageFormat.Json
, BodyStyle = WebMessageBodyStyle.Wrapped
, UriTemplate = "json/ListDou")]
        List<string> JSONListDou();
    }
}
