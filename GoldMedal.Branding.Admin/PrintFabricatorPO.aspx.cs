using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.XtraPrinting;
using GoldMedal.Branding.Admin;
using GoldMedal.Branding.Data.JobRequest;



namespace GoldMedal.Branding.Admin
{


    public partial class PrintFabricatorPO : System.Web.UI.Page
    {
        DataTable dttax = new DataTable();
        DataTable dt = new DataTable();
        JobRequestDataAccess da = new JobRequestDataAccess();

        string AmountWords;
        protected void Page_Load(object sender, EventArgs e)
        {
            FabricatorPO reportGST = new FabricatorPO();
            Common.CommonHelper ch = new Common.CommonHelper();

            if (!IsPostBack)
            {
                string chkId = Request.QueryString["id"].ToString();
                //long.TryParse(Request.QueryString["id"], out chkId);


                if (!string.IsNullOrEmpty(chkId))
                {
                    dttax = da.GetPrintFabricationPO(Request.QueryString["id"].ToString());


                    if (dttax.Rows.Count > 0)

                    {
                        for (int i = 0; i < dttax.Rows.Count; i++)
                        {
                            //reportGST.Parameters["AmountWords"].Value = ConvertNumbertoWords(Convert.ToInt32(dttax.Rows[0]["PCTotalAmount"]));
                            AmountWords = ch.Converts(dttax.Rows[0]["PCTotalAmount"].ToString());
                            reportGST.Parameters["AmountWords"].Value = AmountWords.ToString();
                        }
                    }

                    reportGST.Parameters["parameter1"].Value = Request.QueryString["id"].ToString();

                    string allstring = string.Empty;
                    string ItemName = string.Empty;
                    string taxpercent = string.Empty;
                    string width = string.Empty;
                    string TotalQty = string.Empty;
                    dt = da.GetPrintSubFabricationPO(Request.QueryString["id"]);
                    if (dt.Rows.Count > 0)

                    {
                        // reportGST.Parameters["parameter3"].Value = "Job Description - Summary";
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {

                        }

                    }
                    reportGST.Parameters["parameter1"].Value = chkId;
                    reportGST.Parameters["parameter2"].Value = chkId;


                    // reportGST.Parameters["parameter3"].Value = Request.QueryString["id"];
                    if (dttax.Rows.Count > 0)
                    {
                        // reportGST.Parameters["parameter1"].Value = ConvertNumbertoWords(Convert.ToInt32(dttax.Rows[0]["amount"]));
                    }
                    else
                    {
                        // reportGST.Parameters["parameter1"].Value = "";
                    }

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