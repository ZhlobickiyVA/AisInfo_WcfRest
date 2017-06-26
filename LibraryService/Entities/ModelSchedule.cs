using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Entities
{
  // ---- График работы ---- //

  class ModelSchedule //  График работы
  {
    // Месяц
    // Год
    // Название
    // Зона действия - из справочника зон.
    // МФЦ - место применения графика среди МФЦ
    // Комментарий
  }
  class ModelSheduledWorkPlace
  {
    // Ид Графика
    // ИД Рабочего места
    // ИД Сотрудника
  }

  class ModelWorkCalendar // Календарь работы
  {
    // Ид Графика работы
    // Дата
    // Кол-во часов
    // Вид часов - Работа/Совмещение
  }

  // ----- Справочники ---- ///

  class ModelCoverage // Зона охвата графика
  {
    // Список рабочих мест
  }

  class ModelWorkPlace // Рабочее место
  {
    // Название
    // Комментарий
  }


  // ---------------- Перенести в отдельные файлы --------------------- //




  class ModelVacationShedule // График отпусков сотрудников
  {
    // Сотрудник
    // Дата начала отпускного периода
    // Дата окончания отпускного периода
  }

}
