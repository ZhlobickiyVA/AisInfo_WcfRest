using LibraryService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AisInformMVC.Models
{
  public class SearchListSoc
  {
    public string LastName { get; set; } = "";
    public string FirstName { get; set; } = "";
    public string MiddleName { get; set; } = "";
    public string DateBr { get; set; } = "";
  }

  public class SearchListSocMdou : SearchListSoc
  {
    public string NumDou { get; set; }
  }

   

  public class ViewListMdou
  {
    public IEnumerable<KinderItem> ListMdou { get; set; }
    public SelectList SelectDou { get; set; }

  }



}