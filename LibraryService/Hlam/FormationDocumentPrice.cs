using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.qrcode;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryService.Price;

namespace LibraryService
{
  public class FormationDocumentPrice
  {
    private AuthoryPrice Aut;
    private Purpose purpose;
    private List<Purpose> ListPurpose;
    PriceViewModel Mod;
    bool FlagQrCode = false;

    // Толшина рамки по умолчанию.
    float DefBoard = 0.5F;
    // Включаем поддержку русского языка.
    static string fg = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "times.ttf");
    static BaseFont fgBaseFont = BaseFont.CreateFont(fg, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
    static Font fgFont = new Font(fgBaseFont, 8, Font.NORMAL, BaseColor.BLACK);
    static Font fgFontSmall = new Font(fgBaseFont, 6, Font.NORMAL, BaseColor.BLACK);





    public FormationDocumentPrice(PriceViewModel model)
    {
      this.Mod = model;
      PriceDocContext context = new PriceDocContext();
      this.Aut = context.AuthoryPrice.Find(Convert.ToInt32(model.IndexOgv));
      if (model.QrCodeForEachPart != null) FlagQrCode = true;

      ListPurpose = new List<Purpose>();
      for (int i = 0; i < model.IndexPurpose.Length; i++)
      {
        ListPurpose.Add(context.Purposes.Find(Convert.ToInt32(model.IndexPurpose[i])));
      }
      
    }



    public byte[] GetDocumentPrice()
    {
      byte[] PDF = null;
      MemoryStream ms = new MemoryStream();
      iTextSharp.text.Document document = new iTextSharp.text.Document(PageSize.A4, 27, 30, 15, 10);
      PdfWriter.GetInstance(document, ms);
      document.Open();


      for (int i = 0; i < ListPurpose.Count; i++)
      {
        this.purpose = ListPurpose[i];
        
        GetTable(ref document, Mod);
        if (this.Mod.IsDoubleDoc != null)
        {
          document.Add(new Phrase(" "));
          document.Add(new Phrase(" "));
          GetTable(ref document);
          
        }
        if (i > 0 && this.Mod.IsDoubleDoc != null) document.NewPage();
        else
        {
          document.Add(new Phrase(" "));
          document.Add(new Phrase(" "));
        }
      }
      
      
      document.Close();
      PDF = ms.ToArray();
      return PDF;
    }


    void GetTable(ref iTextSharp.text.Document Document, PriceViewModel Model=null)
    {
      Document.Add(GetTable(@"И з в е щ е н и е", FlagQrCode, Model));
      Document.Add(GetTable(@"К в и т а н ц и я", true,Model));
    }


    
    #region Формирование табличного элемента квитанции 

    PdfPTable GetTable(string Name, bool QrCode = false, PriceViewModel Model = null)
    {
      if (Model == null) Model = new PriceViewModel();
      string Rub = "";
      string Kop = "";
      purpose.Sum = purpose.Sum.Trim();
      Rub = purpose.Sum.Substring(0, purpose.Sum.Length - 2);
      Kop = purpose.Sum.Substring(purpose.Sum.Length - 2, 2);
      string StrSumma = String.Format("Сумма: {0} руб. {1} коп.", Rub, Kop);


      string NamePrice = "";
      PdfPTable table = new PdfPTable(4);
      PdfPCell Cell = null;
      PdfPTable ta = new PdfPTable(1);
      PdfPCell ce = new PdfPCell(new Phrase(Name, fgFont))
      {
        HorizontalAlignment = PdfPCell.ALIGN_CENTER,
        BorderWidth = 0
      };
      ta.AddCell(ce);

      if (QrCode) ce = new PdfPCell(GetQrCodeImage());
      else ce = new PdfPCell();

      ce.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
      ce.VerticalAlignment = PdfPCell.ALIGN_CENTER;
      ce.PaddingTop = 20;
      ce.BorderWidth = 0;
      ta.AddCell(ce);

      Cell = new PdfPCell(ta)
      {
        HorizontalAlignment = PdfPCell.ALIGN_CENTER,
        PaddingTop = 10,
        Rowspan = 14,
        BorderWidth = DefBoard
      };
      table.AddCell(Cell);


      Cell = new PdfPCell()
      {
        BorderWidth = 0,
        BorderWidthTop = DefBoard
      };
      table.AddCell(Cell);
      Cell = new PdfPCell()
      {
        BorderWidth = 0,
        BorderWidthTop = DefBoard
      };
      table.AddCell(Cell);

      Cell = new PdfPCell(new Phrase("Форма № ПД-4", fgFont))
      {
        HorizontalAlignment = PdfPCell.ALIGN_RIGHT,
        VerticalAlignment = PdfPCell.ALIGN_TOP,
        PaddingRight = 5,
        BorderWidth = DefBoard,
        BorderWidthRight = DefBoard
      };
      table.AddCell(Cell);

      Cell = new PdfPCell(new Phrase(" ", fgFont))
      {
        Colspan = 3,
        BorderWidth = 0,
        BorderWidthRight = DefBoard
      };
      table.AddCell(Cell);
      Cell = new PdfPCell(new Phrase(Aut.NameOgv, fgFont))
      {
        BorderWidthRight = DefBoard,
        BorderWidthBottom = DefBoard,
        BorderWidth = 0,
        PaddingTop = 5,
        PaddingBottom = 5,
        Colspan = 3
      };
      table.AddCell(Cell);
      Cell = new PdfPCell(new Phrase("(наименование получателя платежа)", fgFontSmall))
      {
        HorizontalAlignment = PdfPCell.ALIGN_CENTER,
        VerticalAlignment = PdfPCell.ALIGN_TOP,
        Colspan = 3,
        BorderWidthRight = DefBoard,
        BorderWidth = 0
      };
      table.AddCell(Cell);
      Cell = new PdfPCell(new Phrase(Aut.PayeeInn, fgFont))
      {
        HorizontalAlignment = PdfPCell.ALIGN_CENTER,
        BorderWidthBottom = DefBoard,
        BorderWidth = 0
      };
      table.AddCell(Cell);
      Cell = new PdfPCell(new Phrase(Aut.PersonalAcc, fgFont))
      {
        HorizontalAlignment = PdfPCell.ALIGN_CENTER,
        Colspan = 2,
        BorderWidth = 0,
        BorderWidthTop = 0,
        BorderWidthBottom = DefBoard,
        BorderWidthRight = DefBoard
      };
      table.AddCell(Cell);
      Cell = new PdfPCell(new Phrase("(ИНН получателя платежа)", fgFontSmall))
      {
        HorizontalAlignment = PdfPCell.ALIGN_CENTER,
        VerticalAlignment = PdfPCell.ALIGN_TOP,
        BorderWidth = 0,
        PaddingTop = 0
      };
      table.AddCell(Cell);
      Cell = new PdfPCell(new Phrase("(номер счёта получателя платежа)", fgFontSmall))
      {
        HorizontalAlignment = PdfPCell.ALIGN_CENTER,
        VerticalAlignment = PdfPCell.ALIGN_TOP,
        Colspan = 2,
        BorderWidth = 0,
        BorderWidthRight = DefBoard,
        PaddingTop = 0
      };
      table.AddCell(Cell);
      Cell = new PdfPCell(new Phrase(String.Format("БИК {0} ( {1} )", Aut.Bic, Aut.BankName), fgFont))
      {
        HorizontalAlignment = PdfPCell.ALIGN_CENTER,
        VerticalAlignment = PdfPCell.ALIGN_CENTER,
        Colspan = 3,
        BorderWidth = 0,
        PaddingTop = 5,
        PaddingBottom = 5,
        BorderWidthRight = DefBoard
      };
      table.AddCell(Cell);
      Cell = new PdfPCell(new Phrase("(наименование банка получателя платежа)", fgFontSmall))
      {
        HorizontalAlignment = PdfPCell.ALIGN_CENTER,
        VerticalAlignment = PdfPCell.ALIGN_TOP,
        Colspan = 3,
        BorderWidth = 0,
        BorderWidthRight = DefBoard,
        BorderWidthTop = DefBoard,
        PaddingTop = 0
      };
      table.AddCell(Cell);

      if (Model.LastName != "" && Model.LastName != null)
        NamePrice = String.Format("ФИО: {3} {4} {5}; Адрес: {6}; Назначение: {0}; КБК:{1};      ОКТМО: {2};", purpose.Name, purpose.Kbk, Aut.Oktmo, Model.LastName
        , Model.FirstName, Model.MiddleName, Model.PayerAdress);
      else
        NamePrice = String.Format("Назначение: {0}; КБК:{1};    \n  ОКТМО: {2};", purpose.Name, purpose.Kbk, Aut.Oktmo);


      Cell = new PdfPCell(new Phrase(NamePrice, fgFont))
      {
        HorizontalAlignment = PdfPCell.ALIGN_CENTER,
        VerticalAlignment = PdfPCell.ALIGN_CENTER,
        Colspan = 3,
        BorderWidth = 0,
        PaddingTop = 5,
        PaddingBottom = 5,
        BorderWidthRight = DefBoard
      };
      table.AddCell(Cell);
      Cell = new PdfPCell(new Phrase("(назначение платежа)", fgFontSmall))
      {
        HorizontalAlignment = PdfPCell.ALIGN_CENTER,
        VerticalAlignment = PdfPCell.ALIGN_TOP,
        Colspan = 3,
        BorderWidth = 0,
        BorderWidthRight = DefBoard,
        BorderWidthTop = DefBoard,
        BorderWidthBottom = 0,
        PaddingTop = 0
      };
      table.AddCell(Cell);
      Cell = new PdfPCell(new Phrase(StrSumma, fgFont))
      {
        HorizontalAlignment = PdfPCell.ALIGN_CENTER,
        VerticalAlignment = PdfPCell.ALIGN_CENTER,
        Colspan = 3,
        BorderWidth = 0,
        BorderWidthRight = DefBoard,
        BorderWidthTop = 0,
        PaddingTop = 10,
        PaddingBottom = 10
      };
      table.AddCell(Cell);
      Cell = new PdfPCell(new Phrase("(сумма)", fgFontSmall))
      {
        HorizontalAlignment = PdfPCell.ALIGN_CENTER,
        VerticalAlignment = PdfPCell.ALIGN_TOP,
        Colspan = 3,
        BorderWidth = 0,
        BorderWidthRight = DefBoard,
        BorderWidthTop = DefBoard,
        BorderWidthBottom = 0,
        PaddingTop = 0
      };
      table.AddCell(Cell);
      Cell = new PdfPCell(new Phrase(@"С условиями приёма указанной в платёжном документе суммы, в т.ч. с суммой взимаемой платы за услуги банка, ознакомлен и согласен.                                     Подпись плательщика _________________", fgFontSmall))
      {
        HorizontalAlignment = PdfPCell.ALIGN_LEFT,
        VerticalAlignment = PdfPCell.ALIGN_CENTER,
        Colspan = 3,
        BorderWidth = 0,
        BorderWidthRight = DefBoard,
        BorderWidthTop = 0,
        BorderWidthBottom = DefBoard,
        PaddingBottom = 5
      };
      table.AddCell(Cell);

      return table;

    }
    #endregion

    #region Формирование Qr Code


    iTextSharp.text.Image GetQrCodeImage()
    {
      Dictionary<EncodeHintType, object> hints = new Dictionary<EncodeHintType, object>
      {
        { EncodeHintType.CHARACTER_SET, "utf-8" }   //добавление в коллекцию кодировки utf-8
      };

      // Формируем строку для QRcode


      string strRUS = "";

      strRUS =
          "ST00012|"
          + "Name=" + Aut.NameOgv
          + "|PersonalAcc=" + Aut.PersonalAcc
          + "|BankName=" + Aut.BankName
          + "|BIC=" + Aut.Bic
          + "|CorrespAcc=" + Aut.CorrespAcc
          + "|Sum=" + purpose.Sum
          + "|PayeeINN=" + Aut.PayeeInn
          + "|KPP=" + Aut.Kpp
          + "|CBC=" + purpose.Kbk
          + "|OKTMO=" + Aut.Oktmo
          + "|Purpose=" + purpose.Name;

      if (Mod.LastName != "" && Mod.LastName != null)
      {
        strRUS = strRUS + "|LASTNAME=" + Mod.LastName + " " + Mod.FirstName + " " + Mod.MiddleName
         + "|PayerAddress=" + Mod.PayerAdress
         + "|Nationality=" + Mod.Nationaly
         + "|PayerIdType=" + Mod.PayerIdType
         + "|PayerIdNum=" + Mod.PayerIdNum;
      }


      //создание матрицы QR
      BarcodeQRCode qrMatrix = new BarcodeQRCode(
          strRUS,                 //кодируемая строка
          100,                    //ширина
          100,                    //высота
          hints);

      return qrMatrix.GetImage();
    }

    #endregion 



  }

}
