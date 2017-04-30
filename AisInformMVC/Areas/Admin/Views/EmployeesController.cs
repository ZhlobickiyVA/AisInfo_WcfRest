using LibraryService;
using LibraryService.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AisInformMVC.Areas.Admin.Views
{
    public class EmployeesController : Controller
    {
    IEmployeesRepository emplrepository;

    public EmployeesController(IEmployeesRepository emprepo)
    {
      emplrepository = emprepo;
    }



    // GET: Admin/Employees
    public ActionResult Index()
        {
            return View();
        }


    ///  Сотрудники

    public ViewResult ListEmployees()
    {
      return View(emplrepository.Staff.OrderBy(s => s.LastName));
    }

    public ViewResult EditEmployees(int Id)
    {

      Employee empl = emplrepository.Staff.FirstOrDefault(a => a.Id == Id);
      ViewBag.Head = "Редактирование/Создание сотрудника";
      return View(empl);
    }

    [HttpPost]
    public ActionResult EditEmployees(Employee Empl)
    {

      if (ModelState.IsValid)
      {
        emplrepository.SaveEmpl(Empl);
        TempData["message"] = string.Format("Изменения в сотруднике \"{0}\" были сохранены", Empl.GetShortName());
        ViewBag.Head = "Редактирование";
        return RedirectToAction("ListEmployees");
      }
      else
      {
        return View(Empl);
      }
    }
    public ViewResult CreateEmployees()
    {
      ViewBag.Head = "Новый сотрудник";
      return View("EditEmployees", new Employee());
    }

    public ActionResult DeleteEmployees(int Id)
    {
      Employee deleteEmpl = emplrepository.DeleteEmpl(Id);
      if (deleteEmpl != null)
      {
        TempData["message"] = string.Format("Сотрудник : {0} был удалено", deleteEmpl.GetShortName());
      }
      return RedirectToAction("ListEmployees");
    }
  }
}