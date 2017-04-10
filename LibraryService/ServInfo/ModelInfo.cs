
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;


namespace LibraryService
{
    public class ModelInfo
    {

        public static ItemArea[] GetListGorzhilService()
        {
            return new ListAreaGorZhilService().ListGorZhil;
        }

    public static ItemMdou[] GetListMDou()
    {
      return new ListMDOU().Listmdou;
    }



    }



}

