using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServicesLibrary
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IWebRest" в коде и файле конфигурации.
    [ServiceContract]
    public interface IWebRest
    {
        [OperationContract]
        void DoWork();
    }
}
