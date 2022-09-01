using PdfSharp;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TheArtOfDev.HtmlRenderer.PdfSharp;

namespace Service.Helper {
    public class PDFHelper {

        public void GeneratePDF(string content, Guid id, string name, string tableHeader, string tableFooter) {
            
            string htmlHeader    = "<!DOCTYPE html><html lang='en'><head><title>Build & Dox</title>";
            htmlHeader           += "<link href='https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i' rel='stylesheet'>";
            htmlHeader           += "<style>p { page-break-inside: avoid; } td { page-break-inside: avoid; } table { page-break-inside: avoid; }";
            htmlHeader           += ".header { position: fixed; left: 20px; top: 20px; }";
            htmlHeader           += ".footer{ position: fixed; left: 20px; top: 850px; }</style>";
            htmlHeader           += "</head><body>";
            htmlHeader           += "<div class='header'>" + tableHeader + "</div><div class='footer'>" + tableFooter + "</div>";
            string htmlFooter    = "</body></html>";
            string htmlCode      = htmlHeader + content + htmlFooter;

            PdfGenerateConfig conf  = new PdfGenerateConfig();
            conf.PageOrientation    = PageOrientation.Portrait;
            conf.PageSize           = PageSize.A4;
            conf.MarginBottom       = 70;
            conf.MarginLeft         = 20;
            conf.MarginRight        = 20;
            conf.MarginTop          = 70;

            PdfDocument pdf = PdfGenerator.GeneratePdf(htmlCode, conf);

            var appSettings     = ConfigurationManager.AppSettings;
            var serverDirectory = appSettings["FilePath"];
            var unique          = id.ToString("N").Substring(0, 5);

            pdf.Save(string.Format("{0}{1}-{2}.pdf", serverDirectory, name , unique));


        }


    }
}
