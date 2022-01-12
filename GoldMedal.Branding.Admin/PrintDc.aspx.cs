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

    public partial class PrintDc : System.Web.UI.Page
    {
        DataTable dttax = new DataTable();
        DataTable dt = new DataTable();
        JobRequestDataAccess da = new JobRequestDataAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            XtraReport2 reportGST = new XtraReport2();
            if (!IsPostBack)
            {
                string chkId = Request.QueryString["id"].ToString();
                //long.TryParse(Request.QueryString["id"], out chkId);


                if (!string.IsNullOrEmpty(chkId))
                {
                    dttax = da.GetPrintDCReport(Request.QueryString["id"].ToString());
                    reportGST.Parameters["parameter1"].Value = Request.QueryString["id"].ToString();
                    reportGST.Parameters["parameter3"].Value = "";
                    reportGST.Parameters["parameter4"].Value = "";
                    string allstring = string.Empty;
                    string Totalsummury = string.Empty;
                    string TotalQty = string.Empty;

                    dt = da.GetPrintSubCReport(Request.QueryString["id"]);
                    if (dt.Rows.Count > 0)
                    {
                        reportGST.Parameters["parameter3"].Value = "Job Description - Summary";
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            //allstring += dt.Rows[i]["JobDescription"].ToString() + "        " + dt.Rows[i]["TotalAreaInFeet"].ToString() + Environment.NewLine;

                            allstring += dt.Rows[i]["JobDescription"].ToString() + "\n";
                            Totalsummury += dt.Rows[i]["TotalAreaInFeet"].ToString() + "\n";
                            TotalQty += dt.Rows[i]["Qty"].ToString() + "\n";

                        }
                        //reportGST.Parameters["parameter4"].Value = allstring;

                        reportGST.Parameters["parameter4"].Value = allstring;
                        reportGST.Parameters["TotalSummury"].Value = Totalsummury;
                        reportGST.Parameters["SummuryQty"].Value = TotalQty;

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

        public static string ConvertNumbertoWords(int number)
        {
            if (number == 0)
                return "ZERO";
            if (number < 0)
                return "minus " + ConvertNumbertoWords(Math.Abs(number));
            string words = "";
            if ((number / 10000000) > 0)
            {
                words += ConvertNumbertoWords(number / 1000000) + " CRORE ";
                number %= 10000000;
            }
            if ((number / 100000) > 0)
            {
                words += ConvertNumbertoWords(number / 100000) + " LAKH ";
                number %= 100000;
            }
            if ((number / 1000) > 0)
            {
                words += ConvertNumbertoWords(number / 1000) + " THOUSAND ";
                number %= 1000;
            }
            if ((number / 100) > 0)
            {
                words += ConvertNumbertoWords(number / 100) + " HUNDRED ";
                number %= 100;
            }
            if (number > 0)
            {
                if (words != "")
                    words += "AND ";
                var unitsMap = new[] { "ZERO", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE", "TEN", "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN" };
                var tensMap = new[] { "ZERO", "TEN", "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += " " + unitsMap[number % 10];
                }
            }
            return words;
        }
    }
}