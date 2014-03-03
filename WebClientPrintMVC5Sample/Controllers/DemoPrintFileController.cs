using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Neodynamic.SDK.Web;

namespace WebClientPrintMVC5Sample.Controllers
{
    public class DemoPrintFileController : Controller
    {
        //
        // GET: /DemoPrintFile/
        public ActionResult Index()
        {
            return View();
        }

        public void PrintFile(string useDefaultPrinter, string printerName, string fileType)
        {
            string fileName = Guid.NewGuid().ToString("N") + "." + fileType;
            string filePath = null;
            switch (fileType)
            {
                case "PDF":
                    filePath = "~/files/LoremIpsum.pdf";
                    break;
                case "TXT":
                    filePath = "~/files/LoremIpsum.txt";
                    break;
                case "DOC":
                    filePath = "~/files/LoremIpsum.doc";
                    break;
                case "XLS":
                    filePath = "~/files/SampleSheet.xls";
                    break;
                case "JPG":
                    filePath = "~/files/penguins300dpi.jpg";
                    break;
                case "PNG":
                    filePath = "~/files/SamplePngImage.png";
                    break;
                case "TIF":
                    filePath = "~/files/patent2pages.tif";
                    break;
            }

            if (filePath != null)
            {
                PrintFile file = new PrintFile(System.Web.HttpContext.Current.Server.MapPath(filePath), fileName);
                ClientPrintJob cpj = new ClientPrintJob();
                cpj.PrintFile = file;
                if (useDefaultPrinter == "checked" || printerName == "null")
                    cpj.ClientPrinter = new DefaultPrinter();
                else
                    cpj.ClientPrinter = new InstalledPrinter(System.Web.HttpUtility.UrlDecode(printerName));
                cpj.SendToClient(System.Web.HttpContext.Current.Response);
            }
        }
	}
}