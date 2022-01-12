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
    public partial class PrintFabricatorDC_WithAmount : System.Web.UI.Page
    {

        DataTable dttax = new DataTable();
        DataTable dt = new DataTable();
        JobRequestDataAccess da = new JobRequestDataAccess();

        float finaltotalsum;

        protected void Page_Load(object sender, EventArgs e)
        {
            FabricatorDC_WithAmount reportGST = new FabricatorDC_WithAmount();
            Common.CommonHelper ch = new Common.CommonHelper();

            if (!IsPostBack)
            {
                string chkId = Request.QueryString["id"].ToString();
                //long.TryParse(Request.QueryString["id"], out chkId);


                if (!string.IsNullOrEmpty(chkId))
                {
                    dttax = da.GetFabricatorDC_WithAmount(Request.QueryString["id"].ToString());
                    reportGST.Parameters["DcNumber"].Value = Request.QueryString["id"].ToString();
                    reportGST.Parameters["parameter3"].Value = "";
                    reportGST.Parameters["parameter4"].Value = "";
                    string allstring = string.Empty;
                    string Totalsummury = string.Empty;
                    string TotalQty = string.Empty;
                    decimal amt = 0;
                    string AmountWords = string.Empty;
                    dt = da.GetFabricatorDC_JobDescriptionSummary_WithAmount(Request.QueryString["id"]);
                    if (dt.Rows.Count > 0)

                    {
                        reportGST.Parameters["parameter3"].Value = "Job Description - Summary";
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            allstring += dt.Rows[i]["JobDescription"].ToString() + "\n";
                            Totalsummury += dt.Rows[i]["TotalAreaInFeet"].ToString() + "\n";
                            TotalQty += dt.Rows[i]["Qty"].ToString() + "\n";
                        }
                        reportGST.Parameters["parameter4"].Value = allstring;
                        reportGST.Parameters["TotalSummury"].Value = Totalsummury;
                        reportGST.Parameters["SummuryQty"].Value = TotalQty;
                    }
                    reportGST.Parameters["parameter1"].Value = chkId;
                    reportGST.Parameters["parameter2"].Value = chkId;


                    // reportGST.Parameters["parameter3"].Value = Request.QueryString["id"];
                    if (dttax.Rows.Count > 0)
                    {
                        for (int i = 0; i < dttax.Rows.Count; i++)
                        {
                            amt += Convert.ToDecimal( dttax.Rows[i]["Amount"].ToString());

                            //float finaltotal2 = Convert.ToSingle(Convert.ToString(dt.Rows[i]["Amount"]));
                            //finaltotalsum += finaltotal2;

                        }

                        //AmountWords = ch.ConvertNumbertoWords(Convert.ToInt32(amt));
                        //reportGST.Parameters["AmountWords"].Value = AmountWords.ToString();

                        string amountword = ch.Converts(Convert.ToDecimal(amt).ToString());
                        reportGST.Parameters["AmountWords"].Value = amountword;

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