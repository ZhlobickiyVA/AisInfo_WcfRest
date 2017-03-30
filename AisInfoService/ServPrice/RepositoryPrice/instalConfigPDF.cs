using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace AisInfoService
{
  public class InstalConfigPDF
  {



    public static void SerialiseData()
    {

      OrganGV[] data = new OrganGV[2];

      Purpose[] purpose = new Purpose[5];

      purpose[0] = new Purpose()
      {
        Id = "0",
        Name = "МФЦ Внесение изм-ний в загранпаспорт 500руб.",
        Kbk = "18810806000018007110",
        Sum = "50000"
      };
      purpose[1] = new Purpose()
      {
        Id = "1",
        Name = "МФЦ Загранпаспорт 2000руб.",
        Kbk = "18810806000018003110",
        Sum = "200000"
      };
      purpose[2] = new Purpose()
      {
        Id = "2",
        Name = "МФЦ Внесение изм-ний в загранпаспорт 500руб.",
        Kbk = "18810806000018005110",
        Sum = "100000"
      };
      purpose[3] = new Purpose()
      {
        Id = "3",
        Name = "МФЦ Паспорт рф в замен утрач 1500руб.",
        Kbk = "8810807100018035110",
        Sum = "150000"
      };
      purpose[4] = new Purpose()
      {
        Id = "4",
        Name = "МФЦ Паспорт рф выдача 300руб.",
        Kbk = "18810807100018034110",
        Sum = "30000"
      };
      data[0] = new OrganGV()
      {
        Id = "0",
        NameOgv = "УФК  по Магаданской области (УМВД России по Магаданской обл.,л/сч 04471246420)",
        PayeeInn = "4909045951",
        PersonalAcc = "40101810300000010001",
        Bic = "044442001",
        BankName = "ОТДЕЛЕНИЕ МАГАДАН",
        Oktmo = "44701000",
        Kpp = "490901001",
        CorrespAcc = "00000000000000000000",
        Purpose = purpose
      };
      purpose = new Purpose[3];

      purpose[0] = new Purpose()
      {
        Id = "0",
        Name = "ТЕСТ 1 МФЦ Внесение изм-ний в загранпаспорт 500руб.",
        Kbk = "18810806000018007110",
        Sum = "50000"
      };
      purpose[1] = new Purpose()
      {
        Id = "1",
        Name = "ТЕСТ 2 МФЦ Загранпаспорт 2000руб.",
        Kbk = "18810806000018003110",
        Sum = "200000"
      };
      purpose[2] = new Purpose()
      {
        Id = "2",
        Name = "ТЕСТ 3 МФЦ Внесение изм-ний в загранпаспорт 500руб.",
        Kbk = "18810806000018005110",
        Sum = "100000"
      };
      data[1] = new OrganGV()
      {
        Id = "1",
        NameOgv = "ЗАГС ТЕСТ",
        PayeeInn = "4909045951",
        PersonalAcc = "40101810300000010001",
        Bic = "044442001",
        BankName = "ОТДЕЛЕНИЕ МАГАДАН",
        Oktmo = "44701000",
        Kpp = "490901001",
        CorrespAcc = "00000000000000000000",
        Purpose = purpose
      };
      string Path = ConfigurationManager.AppSettings["CountSelect"];
      using (FileStream fs = new FileStream(HttpContext.Current.Server.MapPath(Path), FileMode.Create))
      {
        XmlSerializer formatter = new XmlSerializer(typeof(OrganGV[]));
        formatter.Serialize(fs, data);

      }




    }

    public static void Desiarilise()
    {
      string Path = ConfigurationManager.AppSettings["CountSelect"];
      using (FileStream fs = new FileStream(HttpContext.Current.Server.MapPath(Path), FileMode.Open))
      {
        XmlSerializer formatter = new XmlSerializer(typeof(OrganGV[]));
        OrganGV[] data = (OrganGV[])formatter.Deserialize(fs);


        int i = 0;

      }
    }


    public static void SerListDul()
    {
      ItemDul[] data = new ItemDul[18];

      data[0] = new ItemDul()
      {
        Id = "01",
        Name = "ПАСПОРТ РФ"
      };
      data[1] = new ItemDul()
      {
        Id = "02",
        Name = "СВИД О РОЖДЕНИИ"
      };
      data[2] = new ItemDul()
      {
        Id = "03",
        Name = "ПАСПОРТ МОРЯКАС"
      };
      data[3] = new ItemDul()
      {
        Id = "04",
        Name = "УДОСТОВЕР ВОЕНСЛУЖ"
      };
      data[4] = new ItemDul()
      {
        Id = "05",
        Name = "ВОЕННЫЙ БИЛЕТ"
      };
      data[5] = new ItemDul()
      {
        Id = "06",
        Name = "ВРЕМЕН УДОСТОВЕР"
      };
      data[6] = new ItemDul()
      {
        Id = "07",
        Name = "СПРАВКА ОБ ОСВОБ"
      };
      data[7] = new ItemDul()
      {
        Id = "08",
        Name = "ПАСПОРТ ИН ГРАЖД"
      };
      data[8] = new ItemDul()
      {
        Id = "09",
        Name = "ВИД НА ЖИТЕЛЬСТВО"
      };
      data[9] = new ItemDul()
      {
        Id = "10",
        Name = "РАЗРЕШ ВРЕМ ПРОЖИВ"
      };
      data[10] = new ItemDul()
      {
        Id = "11",
        Name = "УДОСТОВЕР БЕЖЕНЦА"
      };
      data[11] = new ItemDul()
      {
        Id = "12",
        Name = "МИГРАЦИОННАЯ КАРТА"
      };
      data[12] = new ItemDul()
      {
        Id = "13",
        Name = "ПАСПОРТ СССР"
      };
      data[13] = new ItemDul()
      {
        Id = "14",
        Name = "СНИЛС"
      };
      data[14] = new ItemDul()
      {
        Id = "15",
        Name = "УДОСТОВ ЛИЧН ГРАЖД РФ"
      };
      data[15] = new ItemDul()
      {
        Id = "21",
        Name = "ИНН"
      };
      data[16] = new ItemDul()
      {
        Id = "22",
        Name = "ВОДИТ УДОСТОВЕРЕНИЕ"
      };
      data[17] = new ItemDul()
      {
        Id = "24",
        Name = "СВИД_РЕГ_ТС"
      };
      string Path = ConfigurationManager.AppSettings["PathPriceListDul"];
      using (FileStream fs = new FileStream(HttpContext.Current.Server.MapPath(Path), FileMode.Create))
      {
        XmlSerializer formatter = new XmlSerializer(typeof(ItemDul[]));
        formatter.Serialize(fs, data);

      }



    }
    public static void DesListDul()
    {
      string Path = ConfigurationManager.AppSettings["PathPriceListDul"];
      using (FileStream fs = new FileStream(HttpContext.Current.Server.MapPath(Path), FileMode.Open))
      {
        XmlSerializer formatter = new XmlSerializer(typeof(ItemDul[]));
        ItemDul[] data = (ItemDul[])formatter.Deserialize(fs);


        int i = 0;

      }
    }


  }
}