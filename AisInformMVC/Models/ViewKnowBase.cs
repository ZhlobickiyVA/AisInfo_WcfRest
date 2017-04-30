using LibraryService.KhowBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AisInformMVC.Models
{
  public class ViewKnowBase
  {
    public IEnumerable<Authority> Authoritys { get; set; }
    public IEnumerable<Service> Services { get; set; }
    public IEnumerable<ViewAuthority> ViewAuthoritys { get; set; }
  }
}