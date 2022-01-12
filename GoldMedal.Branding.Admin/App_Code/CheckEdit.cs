using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Xml;
using GoldMedal.Branding.Admin;

/// <summary>
/// Summary description for CheckEdit
/// </summary>
namespace GoldMedal.Branding.Admin.App_code
{
    public static class CheckEdit
    {
        public static DataTable IsEditable(int slno, string TableNm, string uid, string ucat, string PageNm, string Node)
        {
            string overtime = string.Empty, maxtime = string.Empty, check = string.Empty;
            General g = new General();
            DataTable dt = new DataTable();

            XmlDocument xmlCountryDocument = new XmlDocument();
            xmlCountryDocument.Load(HttpContext.Current.Server.MapPath("App_Data/EditAccessLevel.xml"));
            if (!(xmlCountryDocument == null))
            {
                XmlNodeList countryList = xmlCountryDocument.SelectNodes("root/" + Node);

                foreach (XmlNode countryNode in countryList)
                {
                    maxtime = countryNode.SelectNodes("maxtime").Item(0).InnerText;
                    overtime = countryNode.SelectNodes("overwrite").Item(0).InnerText;
                    check = countryNode.SelectNodes("check").Item(0).InnerText;
                }
            }

            if (check == "Yes")
            {
                dt = g.return_dt("exec ChckePageEditStatus " + slno + ",'" + TableNm + "'," + uid + ",'" + ucat + "','" + PageNm + "'," + overtime + "," + maxtime + ",'" + check + "'");
            }
            else
            {
                dt.Columns.Add("PStatus");
                dt.Columns.Add("showpopup");
                dt.Columns.Add("viewoverwrite");

                DataRow dr = dt.NewRow();

                dr["PStatus"] = "Unchecked";
                dr["showpopup"] = "No";
                dr["viewoverwrite"] = "No";
                dt.Rows.Add(dr);
            }

            return dt;
        }

        public static string ResetEditStatus(int slno, string TableNm, string Node)
        {
            string overtime = string.Empty, maxtime = string.Empty, check = string.Empty, sts = string.Empty;
            General g = new General();
            XmlDocument xmlCountryDocument = new XmlDocument();
            xmlCountryDocument.Load(HttpContext.Current.Server.MapPath("App_Data/EditAccessLevel.xml"));
            if (!(xmlCountryDocument == null))
            {
                XmlNodeList countryList = xmlCountryDocument.SelectNodes("root/" + Node);

                foreach (XmlNode countryNode in countryList)
                {
                    maxtime = countryNode.SelectNodes("maxtime").Item(0).InnerText;
                    overtime = countryNode.SelectNodes("overwrite").Item(0).InnerText;
                    check = countryNode.SelectNodes("check").Item(0).InnerText;
                }
            }

            if (check == "Yes")
            {
                sts = g.reterive_val("exec ResetPageEditStatus " + slno + ",'" + TableNm + "'");
            }

            return sts;
        }

        public static string UpdateEditStatus(int slno, string TableNm, string adminid, string usercat, string pageNm)
        {
            string sts = string.Empty;
            General g = new General();

            sts = g.reterive_val("exec UpdatePageEditStatus " + slno + ",'" + TableNm + "'," + adminid + ",'" + usercat + "','" + pageNm + "'");

            return sts;
        }
    }
}