using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Entities
{
  public class DepartmentMFC
  {
    public int Id { get; set; }
    [DisplayName("МФЦ")]
    public BranchMFC BranchMFC { get; set; }
    [DisplayName("Название")]
    public string Name { get; set; }
  }





}
