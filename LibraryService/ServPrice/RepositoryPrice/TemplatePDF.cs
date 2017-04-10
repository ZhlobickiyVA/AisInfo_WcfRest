using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.qrcode;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace LibraryService
{
  public class TemplatePDF
  {
    InfoPdf Info;
    ModelPrice modelPrice;
    OrganGV organ;
    Purpose purpose;


    // Толшина рамки по умолчанию.
    float DefBoard = 0.5F;
    // Включаем поддержку русского языка.
    static string fg = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "times.ttf");
    static BaseFont fgBaseFont = BaseFont.CreateFont(fg, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
    static Font fgFont = new Font(fgBaseFont, 8, Font.NORMAL, BaseColor.BLACK);
    static Font fgFontSmall = new Font(fgBaseFont, 6, Font.NORMAL, BaseColor.BLACK);


    string StrSumma = "";

    public TemplatePDF(InfoPdf info, ModelPrice modelprice,bool isData = true)
    {
      if (isData) this.Info = info;
      else
      {
        this.Info.IndexOrgan = info.IndexOrgan;
        this.Info.IndexPurpose = info.IndexPurpose;

      }

      this.modelPrice = modelprice;
      this.organ = this.modelPrice.Listdata[Convert.ToInt32(info.IndexOrgan)];
      this.purpose = this.organ.Purpose[Convert.ToInt32(info.IndexPurpose)];

    }

    /// <summary>
    /// Формируем один сегмент платежного документа
    /// </summary>
    /// <param name="Name">Заголовок квитанции</param>
    /// <param name="QrCode">Отображать Qr code на элементе</param>
    /// <returns>Сегмент квитанции</returns>
    public PdfPTable GetTable(string Name, bool QrCode = false)
    {

      string Rub = "";
      string Kop = "";
      purpose.Sum = purpose.Sum.Trim();
      Rub = purpose.Sum.Substring(0, purpose.Sum.Length - 2);
      Kop = purpose.Sum.Substring(purpose.Sum.Length - 2, 2);
      StrSumma = String.Format("Сумма: {0} руб. {1} коп.", Rub, Kop);


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
      Cell = new PdfPCell(new Phrase(organ.NameOgv, fgFont))
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
      Cell = new PdfPCell(new Phrase(organ.PayeeInn, fgFont))
      {
        HorizontalAlignment = PdfPCell.ALIGN_CENTER,
        BorderWidthBottom = DefBoard,
        BorderWidth = 0
      };
      table.AddCell(Cell);
      Cell = new PdfPCell(new Phrase(organ.PersonalAcc, fgFont))
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
      Cell = new PdfPCell(new Phrase(String.Format("БИК {0} ( {1} )", organ.Bic, organ.BankName), fgFont))
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

      if (Info.LastName != "" && Info.LastName != null)
        NamePrice = String.Format("ФИО: {3} {4} {5}; Адрес: {6}; Назначение: {0}; КБК:{1};      ОКТМО: {2};", purpose.Name, purpose.Kbk, organ.Oktmo, Info.LastName
        , Info.FirstName, Info.MiddleName, Info.PayerAdress);
      else
        NamePrice = String.Format("Назначение: {0}; КБК:{1};    \n  ОКТМО: {2};", purpose.Name, purpose.Kbk, organ.Oktmo);


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


    public iTextSharp.text.Image GetQrCodeImage()
    {
      Dictionary<EncodeHintType, object> hints = new Dictionary<EncodeHintType, object>
      {
        { EncodeHintType.CHARACTER_SET, "utf-8" }   //добавление в коллекцию кодировки utf-8
      };
      //создание матрицы QR

      BarcodeQRCode qrMatrix = new BarcodeQRCode(
          GetStringSetting(),                 //кодируемая строка
          100,                    //ширина
          100,                    //высота
          hints);

      return qrMatrix.GetImage();
    }

    public string GetStringSetting()
    {
      string strRUS = "";

      strRUS =
          "ST00012|"
          + "Name=" + this.organ.NameOgv
          + "|PersonalAcc=" + organ.PersonalAcc
          + "|BankName=" + organ.BankName
          + "|BIC=" + organ.Bic
          + "|CorrespAcc=" + organ.CorrespAcc
          + "|Sum=" + purpose.Sum
          + "|PayeeINN=" + organ.PayeeInn
          + "|KPP=" + organ.Kpp
          + "|CBC=" + purpose.Kbk
          + "|OKTMO=" + organ.Oktmo
          + "|Purpose=" + purpose.Name;

      if (Info.LastName != "" && Info.LastName != null)
      {
        strRUS = strRUS + "|LASTNAME=" + Info.LastName + " " + Info.FirstName + " " + Info.MiddleName
         + "|PayerAddress=" + Info.PayerAdress
         + "|Nationality=" + Info.Nationaly
         + "|PayerIdType=" + Info.PayerIdType
         + "|PayerIdNum=" + Info.PayerIdNum;
      }

      return strRUS;

    }

  }
}