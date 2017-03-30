
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace AisInfoService
{
    /// <summary>
    /// Контракт запросов к спискам соц центра.
    /// </summary>
    [ServiceContract]
    public interface IServList
    {
        // Список - Информация по ДОУ
        // Данные: Фамилия, Имя, Отчество, Дата рождения, №ДОУ, % выплаты
        // Поиск: Фамилия, Имя, Отчество, Дата рождения, №ДОУ
        // Дополнительно: Поиск по списку ДОУ.

        [OperationContract]
        [WebInvoke(Method = "GET"
            , UriTemplate = "ListKinder?lname={lname}&fname={fname}&mname={mname}&brdate={brdate}&ndou={ndou}"
            , BodyStyle = WebMessageBodyStyle.Wrapped)]
        KinderItem[] GetListKinder(string lname = "", string fname = "", string mname = "", string brdate = "", string ndou = "");

        [OperationContract]
        [WebInvoke(Method = "GET"
            , UriTemplate = "ListDou"
            , BodyStyle = WebMessageBodyStyle.Bare)]
        string[] GetListDou();

        // Список - Информация по ЕДВ
        //Данные: Фамилия, Имя, Отчество, Дата рождения, Категория
        //Поиск: Фамилия, Имя, Отчество, Дата рождения


        [OperationContract]
        [WebInvoke(Method = "GET"
            , UriTemplate = "ListEDV?lname={lname}&fname={fname}&mname={mname}&brdate={brdate}"
            , BodyStyle = WebMessageBodyStyle.Wrapped)]
        ItemEDV[] GetListEDV(string lname = "", string fname = "", string mname = "", string brdate = "");

        // Список - Информация по Старожилам
        // Данные: Фамилия, Имя, Отчество, Дата рождения, Категория
        // Поиск: Фамилия, Имя, Отчество, Дата рождения


        [OperationContract]
        [WebInvoke(Method = "GET"
            , UriTemplate = "ListOldLive?lname={lname}&fname={fname}&mname={mname}&brdate={brdate}"
            , BodyStyle = WebMessageBodyStyle.Wrapped)]
        ItemOldLive[] GetListOldLive(string lname = "", string fname = "", string mname = "", string brdate = "");





        // Список - Информация по Ежемесячному пособую на ребенка
        // Данные: Фамилия, Имя, Отчество, Дата рождения, Дата подачи заявления, Дата действия, Название выплаты, Основание
        // Поиск: Фамилия, Имя, Отчество, Дата рождения


        [OperationContract]
        [WebInvoke(Method = "GET"
            , UriTemplate = "ListPayKinder?lname={lname}&fname={fname}&mname={mname}&brdate={brdate}"
            , BodyStyle = WebMessageBodyStyle.Wrapped)]
        ItemPayKinder[] GetListPayKinder(string lname = "", string fname = "", string mname = "", string brdate = "");





    }
}
