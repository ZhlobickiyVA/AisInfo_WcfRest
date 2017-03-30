using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel.Web;

namespace AisInfoService
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
    }



}
