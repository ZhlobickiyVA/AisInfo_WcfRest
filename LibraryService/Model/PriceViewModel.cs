using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryService.Price
{
  public class PriceViewModel
  {
    public string IndexOgv { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string PayerAdress { get; set; }
    public string Nationaly { get; set; }
    public string PayerIdType { get; set; }
    public string PayerIdNum { get; set; }
    public string[] IndexPurpose { get; set; }
    public string IsDoubleDoc { get; set; }
    
  }
}