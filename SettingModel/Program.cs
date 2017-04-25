using LibraryService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace SettingModel
{











  class Program
  {
    static void Main(string[] args)
    {
      //KnowBaseContext db = new KnowBaseContext();

      //ViewAuthority view1 = new ViewAuthority { Name = "Федеральные органы власти" };
      //ViewAuthority view2 = new ViewAuthority { Name = "Миниципальные органы власти" };
      //ViewAuthority view3 = new ViewAuthority { Name = "Региональные органы власти" };
      //db.ViewAuthoritys.Add(view1);
      //db.ViewAuthoritys.Add(view2);
      //db.ViewAuthoritys.Add(view3);

      //Territory terr1 = new Territory() { Name = "Город Магадан" };
      //Territory terr2 = new Territory() { Name = "Ольский район" };
      //Territory terr3 = new Territory() { Name = "Среднеканский район" };
      //Territory terr4 = new Territory() { Name = "Хасынский район" };
      //Territory terr5 = new Territory() { Name = "Омсукчанский район" };
      //Territory terr6 = new Territory() { Name = "Сусуманский район" };
      //Territory terr7 = new Territory() { Name = "Ягодный район" };
      //Territory terr8 = new Territory() { Name = "Северо-Эвенский район" };
      //Territory terr9 = new Territory() { Name = "Тенькинский район" };

      //db.Territorys.Add(terr1);
      //db.Territorys.Add(terr2);
      //db.Territorys.Add(terr3);
      //db.Territorys.Add(terr4);
      //db.Territorys.Add(terr5);
      //db.Territorys.Add(terr6);
      //db.Territorys.Add(terr7);
      //db.Territorys.Add(terr8);
      //db.Territorys.Add(terr9);

      //db.SaveChanges();

      //Category cat1 = new Category() { Name = "Гражданско-правовой статус заявителя" };
      //Category cat2 = new Category() { Name = "Земельно-имущественные отношения" };

      //Category cat3 = new Category() { Name = "Налоги и сборы" };
      //Category cat4 = new Category() { Name = "Образование" };
      //Category cat5 = new Category() { Name = "Пенсионное обеспечение" };
      //Category cat6 = new Category() { Name = "Предпринимательство" };
      //Category cat7 = new Category() { Name = "Социальное обеспечение" };
      //Category cat8 = new Category() { Name = "Социальное страхование" };
      //Category cat9 = new Category() { Name = "Труд и занятость" };

      //db.Category.Add(cat1);
      //db.Category.Add(cat2);
      //db.Category.Add(cat3);
      //db.Category.Add(cat4);
      //db.Category.Add(cat5);
      //db.Category.Add(cat6);
      //db.Category.Add(cat7);
      //db.Category.Add(cat8);
      //db.Category.Add(cat9);
      //db.SaveChanges();

      //var type = db.ViewAuthoritys.Where(c => c.Name.StartsWith("Федеральные")).FirstOrDefault();
      //var area = db.Territorys.Where(c => c.Name.StartsWith("Город Магадан")).FirstOrDefault();

      //Authority aut = new Authority();

      //aut.Name = "Государственная инспекция труда в Магаданской области";
      //aut.ViewAuth = type;
      //aut.Terr = area;


      //db.Authoritys.Add(aut);

      //db.SaveChanges();



      //var list = db.Authoritys.Join(db.Territorys, // второй набор
      //  p => p.TerritoryId, // свойство-селектор объекта из первого набора
      //  c => c.Id, // свойство-селектор объекта из второго набора
      //  (p, c) => new // результат
      //  {
      //    Name = p.Name,
      //    NameTerritory = c.Name,
      //  });


      //foreach (var item in list)
      //{
      //  Console.WriteLine(item.Name + "" + item.NameTerritory);
      //}


      //var list2 = db.Territorys.ToList();
      //var aut2 = db.Authoritys.ToList();
      //foreach (var item in list2)
      //{
      //  Console.WriteLine(item.Name);

      //  var it = aut2.Where(c => c.TerritoryId == item.Id);

      //  foreach (var i in it)
      //  {
      //    Console.WriteLine(i.Name);
      //  }
      //}



      //EmployeeContext db2 = new EmployeeContext();

      //Employee emp = new Employee()
      //{
      //  LastName = "Жлобицкий",
      //  FirstName = "Владимир",
      //  MiddleName = "Александрович",
      //  DateOfBirth = DateTime.Parse("30.08.1990"),
      //  Post = "Инженер-программист"
      //};

      //db2.Staff.Add(emp);
      //db2.SaveChanges();


      //foreach (Employee item in db2.Staff)
      //{
      //  Console.WriteLine(item.LastName);
      //}




      //AdContext db = new AdContext();

      //Ad ad = new Ad();
      //ad.Header = "Обьявления";
      //ad.Text = "Текск";
      //ad.TheValidity = DateTime.Parse("01.01.2018");

      //db.Ads.Add(ad);

      //db.SaveChanges();


      //foreach (var item in db.Ads)
      //{
      //  Console.WriteLine(item.Header);
      //}


      HolidayContext con = new HolidayContext();
      Holiday ho = new Holiday() { Name = "Праздник 1", Date = DateTime.Parse("18.04.2017") };
      Holiday ho2 = new Holiday() { Name = "Праздник 2", Date = DateTime.Parse("18.04.2017") };
      Holiday ho3 = new Holiday() { Name = "Праздник 3", Date = DateTime.Parse("18.04.2017") };
      Holiday ho4 = new Holiday() { Name = "Праздник 4", Date = DateTime.Parse("18.04.2017") };
      Holiday ho5 = new Holiday() { Name = "Праздник 5", Date = DateTime.Parse("18.04.2017") };

      con.Holidays.Add(ho);
      con.Holidays.Add(ho2);
      con.Holidays.Add(ho3);
      con.Holidays.Add(ho4);
      con.Holidays.Add(ho5);

      con.SaveChanges();

      Console.WriteLine("Работа завершена");
      Console.ReadLine();
    }


  }
}

