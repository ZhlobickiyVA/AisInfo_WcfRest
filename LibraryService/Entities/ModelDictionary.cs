using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Entities
{
  public enum TypeDictionary { Weather, ProductionCalendar };


  public class ModelDictionary
  {
    public int Id { get; set; }
    public TypeDictionary Type { get; set; }
    public string Value { get; set; }


  }
}
