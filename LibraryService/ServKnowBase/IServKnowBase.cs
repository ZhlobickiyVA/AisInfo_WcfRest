using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel.Web;
using System.IO;
using System.Web;
using System.Net.Http;

namespace LibraryService
{
  /// <summary>
  /// Контракт предоставляющий информацию из базы знаний.
  /// </summary>
  [ServiceContract]
  interface IServKnowBase
  {
    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "Connect")]
    string Connect();


    [OperationContract]
    [WebInvoke(Method = "POST", UriTemplate = "posttest")]
    void Posttest(Stream body);

    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "image")]
    Stream TestImage();

    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "GetListData")]
    ItemOgvKB[] GetDataBaseKnow();

    [OperationContract]
    [WebInvoke(Method = "GET", UriTemplate = "GetImage?id={id}")]
    Stream GetImageOgv(string id);

    //[OperationContract]
    //[WebInvoke(Method = "POST", UriTemplate = "posttest2")]
    //void PostTest2(HttpContext context);

    /*
     Структура базы знаний

      Справочники:
        Вид территории - Territory
          id - Key
          Name - Название

        Вид категории услуги - Category
          id - Key
          Name - Название

        Вид органа власти - VidOgv
          id - Key
          Name - Название

      Основные таблицы
        Ogv - Список ОГВ 
          	id - Идентификатор
	          Name - Название
	          Slname - Сокрашенное название
	          VidDepartment - Федеральный
				            - Муниципальный
				            - Региональный
	          IdFrgu - Идентификатор ФРГУ
	          Territory - Территориальное направленность
	          Ogrn - ОГРН
	          Inn - ИНН
	          Adress - Адрес
	          FIORuk - ФИО Руководителя
	          ParentOgv - id родительского ОГВ
	          Phone - Телефон
	          Note - Примечания
	          Map    - Картинка с картой отображающее нахождения ОГВ
    
        Services - Список услуг
      	    Id - Идентификатор
	          IdFrgu - Идентификатор ФРГУ
	          IdDepartment - Идентификатор ОГВ
	          Name - Название
	          SlName - Сокр. название
	          idCategory - Категория услуги
	          FlPeople - Доступно физическим лицам
	          UnPeople - Достпуна юридическим лицам
	          IpPeople - Доступна ИП
	          ParentPeople - Доступно по представителя
	          NoNationaly - Доступна лицам без гражданства
	          Text [html] - Информация по услуги в формате HTML
	          InAis - НАписана в АИС
	          DataAccess - Дата открытия в продуктив.





        Отсновные операции
          - Получить структру Базы знаний - 
              Полные сведения по ОГВ + Список Услуг
              Получить карту ОГВ
              Получить Информацию по выбранной услуге
              
     */














  }



}
