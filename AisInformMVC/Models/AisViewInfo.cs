using LibraryService;
using LibraryService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AisInformMVC.Models
{
  public class AisViewInfo
  {
    public IEnumerable<Ad> Ads { get; set; }

    public IEnumerable<Employee> Employees { get; set; }
    public IEnumerable<Holiday> Holiday { get; set; }

    public RootObject Weather { get; set; }
     

    public PagingInfo PagingInfo { get; set; }

  }
}