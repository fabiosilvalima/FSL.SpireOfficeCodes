using Spire.Pdf;
using Spire.Xls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace FSL.SpireOffice.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Workbook workbook = new Workbook();
            workbook.LoadFromFile(Server.MapPath("~/App_Data/excel_file_to_import.xlsx"), true);
            Worksheet sheet = workbook.Worksheets[0];

            DataTable dtt = sheet.ExportDataTable();
            
            return View();
        }

        public ActionResult FromDataTableToFile()
        {
            Workbook workbook = new Workbook();
            workbook.LoadFromFile(Server.MapPath("~/App_Data/excel_file_to_import.xlsx"), true);
            Worksheet sheet = workbook.Worksheets[0];

            DataTable dtt = sheet.ExportDataTable();

            dtt.Rows[0]["Name"] = "Foo name";

            workbook.Worksheets.Clear();
            sheet.ClearData();
            sheet.InsertDataTable(dtt, true, 2, 1, -1, -1);
            workbook.Worksheets.Add(sheet);


            return View();
        }

        public ActionResult FromHtmlToPDF()
        {
            PdfDocument doc = new PdfDocument();
            var url = "https://fabiosilvalima.net/en/start-here";

            Thread thread = new Thread(() =>
            {
                doc.LoadFromHTML(url, false, true, true);
            });

            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
            doc.SaveToFile(Server.MapPath("~/App_Data/fabiosilvalima.pdf"));
            doc.Close();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}