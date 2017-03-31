
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace AisInfoService
{
    /// <summary>
    /// Контракт получения платежной квитанции.
    /// </summary>
    [ServiceContract]
    interface IServPrice
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Connect")]
        string Connect();


        [OperationContract]
        [WebInvoke(Method = "GET"
            , UriTemplate = "ListOgv"
            , BodyStyle = WebMessageBodyStyle.Bare)]
        ItemOgv[] GetListOgv();

        [OperationContract]
        [WebInvoke(Method = "GET"
            , UriTemplate = "ListDul"
            , BodyStyle = WebMessageBodyStyle.Bare)]
        ItemDul[] GetListDul();

        /*
         Входные Данные: 
         - Орган назначения платежа
         - Фамилия
         - Имя
         - Отчество
         - Адрес
         - Вид документа
         - Номер документа
         - Назначение платежа
         */
        [OperationContract]
        [WebInvoke(Method = "GET"
        , UriTemplate = "PriceDocument?idOgv={idOgv}&idPur={idPur}&lname={lname}&fname={fname}&mname={mname}&adress={adress}&idType={idtype}&NumDul={numdul}")]
        void GetPriceDocument(string idOgv, string idPur, string lname="", string fname="", string mname="", string adress="", string idtype="", string numdul="");
        


    }
}
