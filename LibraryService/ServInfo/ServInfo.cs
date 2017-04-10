
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace LibraryService
{

  public class ServInfo : IServInfo
  {


    public string Connect()
    {
      ListMDOU.SerializMDou();
      return "Привет!!!!";

    }

    public ItemArea[] GetListArea()
    {
      return ModelInfo.GetListGorzhilService();
    }

    public ItemMdou[] GetListMdou()
    {
      return ModelInfo.GetListMDou();
    }

  }
}