using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AisInfoService
{
  public class ServList : IServList
  {
    public string[] GetListDou()
    {
      return new ModelList().KinderList.GetListDou();
    }
    public KinderItem[] GetListKinder(string lname = "", string fname = "", string mname = "", string brdate = "", string ndou = "")
    {
      KinderItem item = new KinderItem()
      {
        LastName = lname,
        FirstName = fname,
        MiddleName = mname,
        BrDate = brdate,
        NumDou = ndou
      };
      return new ModelList().KinderList.GetListKinder(item);
    }

    public ItemEDV[] GetListEDV(string lname = "", string fname = "", string mname = "", string brdate = "")
    {
      ItemEDV item = new ItemEDV()
      {
        LastName = lname,
        FirstName = fname,
        MiddleName = mname,
        BrDate = brdate
      };
      return new ModelList().Listedv.GetListEDV(item);
    }
    public ItemOldLive[] GetListOldLive(string lname = "", string fname = "", string mname = "", string brdate = "")
    {
      ItemOldLive item = new ItemOldLive()
      {
        LastName = lname,
        FirstName = fname,
        MiddleName = mname,
        BrDate = brdate
      };
      return new ModelList().Listoldlive.GetListOldLive(item);
    }

    public ItemPayKinder[] GetListPayKinder(string lname = "", string fname = "", string mname = "", string brdate = "")
    {
      ItemPayKinder item = new ItemPayKinder()
      {
        LastName = lname,
        FirstName = fname,
        MiddleName = mname,
        BrDate = brdate
      };
      return new ModelList().Listpaykinder.GetListPayKinder(item);
    }
  }
}