using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using AisInfo_Rest.Model;

namespace AisInfo_Rest
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы Service.svc или Service.svc.cs в обозревателе решений и начните отладку.
    public class Service : IService
    {

        public string JSONData(string id)
        {
            return "Данные " + id;
        }

        public List<Dou> JSONList(string LastName, string FirstName, string MiddleName,string BrDate,string idDou)
        {
            return new ModelDou(LastName,FirstName,MiddleName,BrDate,idDou).item;
        }

        public List<string> JSONListDou()
        {
            return ModelDou.ListDouNumber();
        }

        public string XMLData(string id)
        {
            return "Строка " + id;
        }

        public List<Dou> XMLList(string LastName, string FirstName)
        {
            return new ModelDou().item;
        }

    }
}
