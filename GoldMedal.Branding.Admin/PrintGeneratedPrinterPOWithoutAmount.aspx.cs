using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using DevExpress.XtraPrinting;
using GoldMedal.Branding.Data.JobRequest;

namespace GoldMedal.Branding.Admin
{
    public partial class PrintGeneratedPrinterPOWithoutAmount : System.Web.UI.Page
    {
        DataTable dttax = new DataTable();
        DataTable dt = new DataTable();

        JobRequestDataAccess da = new JobRequestDataAccess();

        protected void Page_Load(object sender, EventArgs e)
        {
            GeneratedPrinterPOWithoutAmount reportGST = new GeneratedPrinterPOWithoutAmount();

            if (!IsPostBack)
            {
                string chkId = Request.QueryString["id"].ToString();
                //long.TryParse(Request.QueryString["id"], out chkId);

                if (!string.IsNullOrEmpty(chkId))
                {
                    dttax = da.PrintGeneratedPrinterPOWithoutAmountHead(Request.QueryString["id"].ToString());
                    reportGST.Parameters["parameter1"].Value = Request.QueryString["id"].ToString();

                    dt = da.PrintGeneratedPrinterPOWithoutAmountChild(Request.QueryString["id"]);
                    if (dt.Rows.Count > 0)

                    {
                        // reportGST.Parameters["parameter3"].Value = "Job Description - Summary";
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            //allstring += dt.Rows[i]["AmountWords"].ToString();
                        }

                    }
                    reportGST.Parameters["parameter1"].Value = chkId;
                    reportGST.Parameters["parameter2"].Value = chkId;

                    using (MemoryStream ms = new MemoryStream())
                    {

                        reportGST.CreateDocument();
                        PdfExportOptions opts = new PdfExportOptions();
                        opts.ShowPrintDialogOnOpen = true;
                        reportGST.ExportToPdf(ms, opts);
                        ms.Seek(0, SeekOrigin.Begin);
                        byte[] report1 = ms.ToArray();
                        Page.Response.ContentType = "application/pdf";
                        Page.Response.Clear();
                        Page.Response.OutputStream.Write(report1, 0, report1.Length);
                        Page.Response.End();
                    }
                }

            }
        }
    }
}