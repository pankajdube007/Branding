using GoldMedal.Branding.Data.Printer;
using Newtonsoft.Json;
using System;
using System.Data;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using GoldMedal.Branding.Data;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using GoldMedal.Branding.Admin.Common;
using GoldMedal.Branding.Admin.Security;
using GoldMedal.Branding.Core.UAParser;
using GoldMedal.Branding.Core.UAParser.Models;

namespace GoldMedal.Branding.Admin
{
    public partial class Default : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        PrinterDataAccess objdata = new PrinterDataAccess();
        private DataAccess objDataAccess = new DataAccess();

        private readonly  IUserManagement _userManagement = new UserManagement();
        int UserID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                clearusercookies();
                CheckLocationInfo();
            }
        }

        protected void clearusercookies()
        {
            string[] myCookies = Request.Cookies.AllKeys;

            foreach (string cookie in myCookies)
            {
                if (!string.Equals(cookie, "geoloc") && !string.Equals(cookie, "geoip"))
                {
                    Response.Cookies[cookie].Expires = DateTime.Now.AddDays(-1);
                }
            }
        }




        public bool PrintResult(string str)
        {
            bool rtn = false;
            if (!string.IsNullOrEmpty(str))
            {
                dynamic stuff = JsonConvert.DeserializeObject(str);
                string resultstatus = stuff[0]["result"];
                string usercategory = stuff[0].data["usercat"];
                string message = stuff[0]["message"];
                if (resultstatus.Trim() == "False")
                {
                    lbmsg.Text = Convert.ToString(stuff[0]["message"]);
                    Response.Cookies["logged"].Value = Convert.ToBase64String(MachineKey.Protect(Encoding.UTF8.GetBytes("no")));
                    Response.Cookies["logged"].Expires = DateTime.Now.AddHours(12);
                }
                else if (usercategory.Trim() == "SalesExecutive")
                {
                    lbmsg.Text = "Unauthorized user";
                    Response.Cookies["logged"].Value = Convert.ToBase64String(MachineKey.Protect(Encoding.UTF8.GetBytes("no")));
                    Response.Cookies["logged"].Expires = DateTime.Now.AddHours(12);
                }
                else
                {   //isbrandingaccess 
                    string logno = "99999";// stuff[0].data["logno"]; //Change this value in API
                    GoldMedal.Branding.Core.Common.ValidateDataType.SetCookie("logno", logno, TimeSpan.FromHours(12));
                    string usernm = stuff[0].data["usernm"];
                    GoldMedal.Branding.Core.Common.ValidateDataType.SetCookie("usernm", usernm, TimeSpan.FromHours(12));
                    string status = stuff[0].data["status"];
                    GoldMedal.Branding.Core.Common.ValidateDataType.SetCookie("status", status, TimeSpan.FromHours(12));
                    int userlogid = stuff[0].data["userlogid"];
                    UserID = userlogid;
                    GoldMedal.Branding.Core.Common.ValidateDataType.SetCookie("userlogid", userlogid.ToString(), TimeSpan.FromHours(12));
                    string userlognm = stuff[0].data["userlognm"];
                    GoldMedal.Branding.Core.Common.ValidateDataType.SetCookie("userlognm", userlognm, TimeSpan.FromHours(12));
                    string usercat = "Admin";// stuff[0].data["usercat"];//Change this value in API
                    GoldMedal.Branding.Core.Common.ValidateDataType.SetCookie("usercat", usercat, TimeSpan.FromHours(12));
                    int stateid = stuff[0].data["stateid"];
                    GoldMedal.Branding.Core.Common.ValidateDataType.SetCookie("stateid", stateid.ToString(), TimeSpan.FromHours(12));
                    int homebranchid = 1;// stuff[0].data["homebranchid"];//Change this value in API
                    GoldMedal.Branding.Core.Common.ValidateDataType.SetCookie("homebranchid", homebranchid.ToString(), TimeSpan.FromHours(12));
                    bool issuccess = stuff[0].data["issuccess"];
                    GoldMedal.Branding.Core.Common.ValidateDataType.SetCookie("issuccess", issuccess.ToString(), TimeSpan.FromHours(12));
                    bool isblock = stuff[0].data["isblock"];
                    GoldMedal.Branding.Core.Common.ValidateDataType.SetCookie("isblock", isblock.ToString(), TimeSpan.FromHours(12));
                    string uniquekey = stuff[0].data["uniquekey"];
                    GoldMedal.Branding.Core.Common.ValidateDataType.SetCookie("uniquekey", uniquekey, TimeSpan.FromHours(12));
                    string logged = "yes";
                    GoldMedal.Branding.Core.Common.ValidateDataType.SetCookie("logged", logged, TimeSpan.FromHours(12));

                    var responseString = _userManagement.AuthUser(str);

                    if (!string.IsNullOrEmpty(responseString))
                    {
                        lbmsg.Text = responseString;
                    }
                    else
                    {
                        rtn = true;
                    }

                    if (isblock)
                    {
                        lbmsg.Text = "Oops!! You A/C has been blocked";
                        Response.Cookies["logged"].Value = null;
                        Response.Cookies["logged"].Value = "no";
                        Response.Cookies["logged"].Expires = DateTime.Now.AddHours(12);
                    }
                }
            }
            else
            {
                lbmsg.Text = "Something Wrong";
                string logged = "no";
                GoldMedal.Branding.Core.Common.ValidateDataType.SetCookie("logged", logged, TimeSpan.FromHours(12));
                //Response.Cookies["logged"].Value = Convert.ToBase64String(MachineKey.Protect(Encoding.UTF8.GetBytes("no")));
                //Response.Cookies["logged"].Expires = DateTime.Now.AddHours(12);
            }
            //localLogin();
            return rtn;
        }

        public string ValidateAsync(User user)
        {
            string retstring = string.Empty;
            try
            {
                string data = JsonConvert.SerializeObject(user);
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["url"].ToString());
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsync("ValidateOtherUser", new StringContent(data, Encoding.UTF8, "application/json")).Result;
                if (response.IsSuccessStatusCode)
                {
                    using (HttpContent content = response.Content)
                    {
                        retstring = content.ReadAsStringAsync().Result;
                    }
                }
                return retstring;
            }
            catch (Exception exception)
            {
                return retstring;
            }
        }



        public void SetPrinterFabCookie(int Slno, string usernm, int Type, string name)
        {
            GoldMedal.Branding.Core.Common.ValidateDataType.SetCookie("slno", Slno.ToString(), TimeSpan.FromHours(12));

            GoldMedal.Branding.Core.Common.ValidateDataType.SetCookie("name", name, TimeSpan.FromHours(12));

            GoldMedal.Branding.Core.Common.ValidateDataType.SetCookie("usernm", usernm, TimeSpan.FromHours(12));

            GoldMedal.Branding.Core.Common.ValidateDataType.SetCookie("usertype", Type.ToString(), TimeSpan.FromHours(12));
        }


        public string ValidatePrinter(User user)
        {
            string result = "0";
            try
            {
                Core.Printer.Printer objLogin = new Core.Printer.Printer();
                GoldMedal.Branding.Data.Printer.PrinterModel.PrinterLogin plogin = new Data.Printer.PrinterModel.PrinterLogin();

                plogin.usernm = user.usernm;
                plogin.password = user.pwd;

                result = objLogin.PrinterLoginMethod(plogin);

                return result;
            }
            catch (Exception)
            {
                return result;
            }
        }


        public string ValidateDispatchTeamUser(User user)
        {
            string result = "0";
            try
            {
                Core.FinalAssembaly.FinalAssembly objLogin = new Core.FinalAssembaly.FinalAssembly();
                GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.TeamsLogin plogin = new Data.FinalAssembaly.FinalAssembly.TeamsLogin();

                plogin.usernm = user.usernm;
                plogin.password = user.pwd;

                result = objLogin.DispatchTeamLoginMethod(plogin);

                return result;
            }
            catch (Exception)
            {
                return result;
            }
        }


        public string ValidateSelfInstallationTeamUser(User user)
        {
            string result = "0";
            try
            {
                Core.FinalAssembaly.FinalAssembly objLogin = new Core.FinalAssembaly.FinalAssembly();
                GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.TeamsLogin plogin = new Data.FinalAssembaly.FinalAssembly.TeamsLogin();

                plogin.usernm = user.usernm;
                plogin.password = user.pwd;

                result = objLogin.SelfInstallationTeamLoginMethod(plogin);

                return result;
            }
            catch (Exception)
            {
                return result;
            }
        }


        public string ValidateVendorTeamUser(User user)
        {
            string result = "0";
            try
            {
                Core.FinalAssembaly.FinalAssembly objLogin = new Core.FinalAssembaly.FinalAssembly();
                GoldMedal.Branding.Data.FinalAssembaly.FinalAssembly.TeamsLogin plogin = new Data.FinalAssembaly.FinalAssembly.TeamsLogin();

                plogin.usernm = user.usernm;
                plogin.password = user.pwd;

                result = objLogin.VendorTeamLoginMethod(plogin);

                return result;
            }
            catch (Exception)
            {
                return result;
            }
        }
        public void SetUserDetails()
        {
            int UserID = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid"); ;

            dt = objdata.GetUserDetails(UserID);
            hfDesignationID.Value = Convert.ToString(dt.Rows[0]["DesignationID"]);
            GoldMedal.Branding.Core.Common.ValidateDataType.SetCookie("designationid", dt.Rows[0]["DesignationID"].ToString(), TimeSpan.FromHours(12));
        }

        public string ValidateFabricator(User user)
        {
            string result = "0";
            try
            {
                Core.Fabricator.Fabricator objLogin = new Core.Fabricator.Fabricator();
                GoldMedal.Branding.Data.Fabricator.FabricatorModel.FabricatorLogin flogin = new Data.Fabricator.FabricatorModel.FabricatorLogin();

                flogin.usernm = user.usernm;
                flogin.password = user.pwd;

                result = objLogin.FabricatorLoginMethod(flogin);

                return result;
            }
            catch (Exception)
            {
                return result;
            }
        }


        public void localLogin()
        {
            string logno = "99999";// stuff[0].data["logno"]; //Change this value in API
            GoldMedal.Branding.Core.Common.ValidateDataType.SetCookie("logno", logno, TimeSpan.FromHours(12));
            string usernm = "usernm";
            GoldMedal.Branding.Core.Common.ValidateDataType.SetCookie("usernm", usernm, TimeSpan.FromHours(12));
            string status = "usernm";
            GoldMedal.Branding.Core.Common.ValidateDataType.SetCookie("status", status, TimeSpan.FromHours(12));
            int userlogid = 1;
            GoldMedal.Branding.Core.Common.ValidateDataType.SetCookie("userlogid", userlogid.ToString(), TimeSpan.FromHours(12));
            string userlognm = "usernm";
            GoldMedal.Branding.Core.Common.ValidateDataType.SetCookie("userlognm", userlognm, TimeSpan.FromHours(12));
            string usercat = "Admin";// stuff[0].data["usercat"];//Change this value in API
            GoldMedal.Branding.Core.Common.ValidateDataType.SetCookie("usercat", usercat, TimeSpan.FromHours(12));
            int stateid = 13;
            GoldMedal.Branding.Core.Common.ValidateDataType.SetCookie("stateid", stateid.ToString(), TimeSpan.FromHours(12));
            int homebranchid = 1;// stuff[0].data["homebranchid"];//Change this value in API
            GoldMedal.Branding.Core.Common.ValidateDataType.SetCookie("homebranchid", homebranchid.ToString(), TimeSpan.FromHours(12));
            bool issuccess = true;
            GoldMedal.Branding.Core.Common.ValidateDataType.SetCookie("issuccess", issuccess.ToString(), TimeSpan.FromHours(12));
            bool isblock = false;
            GoldMedal.Branding.Core.Common.ValidateDataType.SetCookie("isblock", isblock.ToString(), TimeSpan.FromHours(12));
            string uniquekey = new Guid().ToString();
            GoldMedal.Branding.Core.Common.ValidateDataType.SetCookie("uniquekey", uniquekey, TimeSpan.FromHours(12));
            string logged = "yes";
            GoldMedal.Branding.Core.Common.ValidateDataType.SetCookie("logged", logged, TimeSpan.FromHours(12));
        }


        public class User
        {
            private string name;

            public string usernm
            {
                get
                {
                    return this.name ?? string.Empty;
                }
                set
                {
                    this.name = value;
                }
            }

            private string password;

            public string pwd
            {
                get
                {
                    return this.password ?? string.Empty;
                }
                set
                {
                    this.password = value;
                }
            }
            private string prjctname;
            public string application
            {
                get
                {
                    return this.prjctname ?? string.Empty;
                }
                set
                {
                    this.prjctname = value;
                }
            }

            private string track;

            public string ip
            {
                get
                {
                    // return this.track ?? "127.0.0.1";
                    return this.track ?? string.Empty;
                }
                set
                {
                    this.track = value;
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int lctype = 0;
            bool rslt = false;

            lbmsg.Text = string.Empty;
            string ip = CommonHelper.GetCurrentIpAddress();
            // string sysip = "";
            //sysip = gn.getip();

            if (ValidateLocationInfo())
            {
                rslt = int.TryParse(Convert.ToString(hfLcType.Value), out lctype);

                if (rslt && lctype > 0)
                {
                    if (string.IsNullOrEmpty(txtusername.Text.Trim()))
                    {
                        lbmsg.Text = "Please Input User Name";
                        return;
                    }
                    else if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
                    {
                        lbmsg.Text = "Please Input Valid Password";
                        return;
                    }
                    else if (string.IsNullOrEmpty(ip))
                    {
                        lbmsg.Text = "IP address not found";
                        return;
                    }
                    else
                    {
                        clearusercookies();

                        User user = new User
                        {
                            
                            usernm = HttpUtility.HtmlEncode(txtusername.Text.Trim()),
                            pwd = HttpUtility.HtmlEncode(txtPassword.Text.Trim()),
                            application = "GoldmedalBranding",
                            ip = ip //"127.0.125.5"
                        };

                        if (user.usernm.Contains("fab_") || user.usernm.Contains("pri_") || user.usernm.Contains("disp_") || user.usernm.Contains("self_") || user.usernm.Contains("ven_"))
                        {
                            if (user.usernm.Contains("fab_"))
                            {
                                string fabricator_res = ValidateFabricator(user);

                                if (fabricator_res != "2" && fabricator_res != "0")
                                {
                                    string[] fabresult = fabricator_res.Split('#');
                                    hfCategory.Value = "Fabricator";
                                    UserID = Convert.ToInt32(fabresult[0]);
                                    StoreUserLocationInfo();
                                    SetPrinterFabCookie(Convert.ToInt32(fabresult[0]), user.usernm, 2, Convert.ToString(fabresult[1]));
                                    Response.Redirect("~/transaction/FabricatorDesignSubmit/FabricatorDesignSubmit.aspx");
                                }
                                else
                                {
                                    clearusercookies();
                                }
                            }
                            else if (user.usernm.Contains("pri_"))
                            {
                                string printer_res = ValidatePrinter(user);

                                if (printer_res != "2" && printer_res != "0")
                                {
                                    string[] printresult = printer_res.Split('#');
                                    hfCategory.Value = "Printer";
                                    UserID = Convert.ToInt32(printresult[0]);
                                    StoreUserLocationInfo();
                                    SetPrinterFabCookie(Convert.ToInt32(printresult[0]), user.usernm, 1, Convert.ToString(printresult[1]));
                                    Response.Redirect("~/transaction/PrinterDesignSubmit/printerdesignsubmit.aspx");
                                }
                                else
                                {
                                    clearusercookies();
                                }
                            }
                            else if (user.usernm.Contains("disp_"))
                            {
                                string disp_res = ValidateDispatchTeamUser(user);

                                if (disp_res != "2" && disp_res != "0")
                                {
                                    string[] dispresult = disp_res.Split('#');
                                    hfCategory.Value = "DispatchTeam";
                                    UserID = Convert.ToInt32(dispresult[0]);
                                    StoreUserLocationInfo();
                                    SetPrinterFabCookie(Convert.ToInt32(dispresult[0]), user.usernm, 3, Convert.ToString(dispresult[1]));
                                    Response.Redirect("~/transaction/FinalAssembaly/FinalAssembalyDispatchDetails.aspx");
                                }
                                else
                                {
                                    clearusercookies();
                                }
                            }
                            else if (user.usernm.Contains("self_"))
                            {
                                string self_res = ValidateSelfInstallationTeamUser(user);

                                if (self_res != "2" && self_res != "0")
                                {
                                    string[] selfresult = self_res.Split('#');
                                    hfCategory.Value = "SelfInstallationTeam";
                                    UserID = Convert.ToInt32(selfresult[0]);
                                    StoreUserLocationInfo();
                                    SetPrinterFabCookie(Convert.ToInt32(selfresult[0]), user.usernm, 4, Convert.ToString(selfresult[1]));
                                    Response.Redirect("~/transaction/FinalAssembaly/FinalAssembalySelfInstallationModeDetails.aspx");
                                }
                                else
                                {
                                    clearusercookies();
                                }
                            }
                            else if (user.usernm.Contains("ven_"))
                            {
                                string ven_res = ValidateVendorTeamUser(user);

                                if (ven_res != "2" && ven_res != "0")
                                {
                                    string[] venresult = ven_res.Split('#');
                                    hfCategory.Value = "VendorTeam";
                                    UserID = Convert.ToInt32(venresult[0]);
                                    StoreUserLocationInfo();
                                    SetPrinterFabCookie(Convert.ToInt32(venresult[0]), user.usernm, 5, Convert.ToString(venresult[1]));
                                    Response.Redirect("~/transaction/FinalAssembaly/FinalAssembalyVendorModeDetails.aspx");
                                }
                                else
                                {
                                    clearusercookies();
                                }
                            }
                        }
                        else if (!user.usernm.Contains("pri_") && !user.usernm.Contains("fab_") && !user.usernm.Contains("disp_") && !user.usernm.Contains("self_") && !user.usernm.Contains("ven_"))
                        {
                            string result = ValidateAsync(user);
                            if (PrintResult(result))
                            {
                                if (string.Equals(GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieString("logged", Convert.ToBoolean(1)), "yes"))
                                {
                                    hfCategory.Value = "Internal User";
                                    SetUserDetails();
                                    StoreUserLocationInfo();
                                    Response.Redirect("~/master/main.aspx");
                                }
                                else
                                {
                                    clearusercookies();
                                }
                            }
                            else
                            {
                                clearusercookies();
                            }
                            
                        }
                        else
                        {
                            clearusercookies();
                        }
                    }
                }
                else
                {
                    lbmsg.Text = "Location not found.";
                }
            }
        }

        #region Location

        protected bool ValidateIP()
        {
            bool result = false;

            string IPAddress = CommonHelper.GetCurrentIpAddress();

            if (!string.IsNullOrEmpty(IPAddress))
            {
                result = true;
            }
            else
            {
                lbmsg.Text = "IP not found.";
            }

            return result;
        }

        protected bool ValidateLocationInfo()
        {
            bool result = false;

            string LocationPermission = Convert.ToString(hfPermission.Value).Trim();
            string Lat = "";
            string Long = "";
            string Location = "";
            int LocationType = Convert.ToInt16(hfLcType.Value);
            string IPAddress = CommonHelper.GetCurrentIpAddress();

            if (!string.IsNullOrEmpty(IPAddress))
            {
                if (LocationPermission != "denied")
                {
                    if (hfLcFound.Value == "1")
                    {
                        if (!GetLocationFromCookie())
                        {
                            return false;
                        }
                        else
                        {
                            result = true;
                        }
                    }
                    else
                    {
                        Lat = Convert.ToString(hfLat.Value).Trim();
                        Long = Convert.ToString(hfLon.Value).Trim();
                        Location = Convert.ToString(hfLocation.Value).Trim();

                        if (LocationPermission != "denied")
                        {
                            if (LocationType == 1)
                            {
                                if (!string.IsNullOrEmpty(Lat) && !string.IsNullOrEmpty(Long))
                                {
                                    if (!string.IsNullOrEmpty(Location))
                                    {
                                        result = true;
                                    }
                                    else
                                    {
                                        result = IPLookUp(1, IPAddress);
                                    }
                                }
                                else
                                {
                                    result = IPLookUp(2, IPAddress);
                                }
                            }
                            else if (LocationType == 2)
                            {
                                result = IPLookUp(2, IPAddress);
                            }
                        }
                        else
                        {
                            lbmsg.Text = "Invalid location information.Please refresh the page and try again.";
                        }
                    }

                    Lat = Convert.ToString(hfLat.Value).Trim();
                    Long = Convert.ToString(hfLon.Value).Trim();

                    if (!string.IsNullOrEmpty(Lat) && !string.IsNullOrEmpty(Long))
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                        lbmsg.Text = "Invalid location information.Please refresh the page and try again.";
                    }
                }
                else
                {
                    lbmsg.Text = "Please allow location permission on your browser.";
                }
            }
            else
            {
                lbmsg.Text = "IP not found.";
            }

            return result;
        }

        protected bool GetLocationFromCookie()
        {
            bool status = false;
            string locCookie = "";
            string[] cookiedata;

            if (HttpContext.Current.Request.Cookies["geoloc"] != null)
            {
                if (Convert.ToString(HttpContext.Current.Request.Cookies["geoloc"].Value) != "")
                {
                    try
                    {
                        locCookie = SecurityHelper.Decrypt(HttpContext.Current.Request.Cookies["geoloc"].Value.ToString(), Convert.ToString(ConfigurationManager.AppSettings["EncrptKey"]));
                        cookiedata = locCookie.Split('#');
                        hfLat.Value = cookiedata[0].Trim();
                        hfLon.Value = cookiedata[1].Trim();
                        hfLocation.Value = cookiedata[2].Trim();
                        hfLcType.Value = cookiedata[3].Trim();
                        status = true;
                    }
                    catch (Exception)
                    {
                        status = false;
                    }
                }
            }

            return status;
        }

        protected bool IPLookUp(int type, string IPAddress)
        {
            bool result = false;
            string response = "";
            string address = "";
            string error = "";

            response = GetLocationData(out error, IPAddress);

            if (error == "")
            {
                dynamic locdata = JsonConvert.DeserializeObject(response);
                hfLocResponse.Value = response;

                if (type == 1)
                {
                    if (Convert.ToString(locdata.status) == "success")
                    {
                        address = Convert.ToString(locdata.city) + "-" + Convert.ToString(locdata.zip) + "," + Convert.ToString(locdata.regionName) + "," + Convert.ToString(locdata.countryCode);
                        hfLocation.Value = Convert.ToString(address);
                    }
                    result = true;
                }
                else if (type == 2)
                {
                    if (Convert.ToString(locdata.status) == "success")
                    {
                        if (string.IsNullOrEmpty(hfLat.Value) && string.IsNullOrEmpty(hfLon.Value))
                        {
                            hfLat.Value = Convert.ToString(locdata.lat);
                            hfLon.Value = Convert.ToString(locdata.lon);
                        }

                        address = Convert.ToString(locdata.city) + "-" + Convert.ToString(locdata.zip) + "," + Convert.ToString(locdata.regionName) + "," + Convert.ToString(locdata.countryCode);
                        hfLocation.Value = Convert.ToString(address);
                    }

                    if (!string.IsNullOrEmpty(hfLat.Value) && !string.IsNullOrEmpty(hfLon.Value))
                    {
                        result = true;
                    }
                    else
                    {
                        lbmsg.Text = "Invalid location information.Please refresh the page and try again.";
                    }
                }
            }
            else
            {
                lbmsg.Text = "Unable to fetch location."; // error;
            }

            return result;
        }

        protected bool StoreUserBrowserInfo(string EmailID, string BrowserName)
        {
            bool result = false;

            int success = objDataAccess.ExecDB("exec UpdateUserBrowserDetails '" + EmailID + "','" + BrowserName + "'");

            if (success == 1)
            {
                result = true;
            }

            return result;
        }
        protected bool StoreUserLocationInfo()
        {
            bool result = false;
            string locCookie = "";
            string IPAddress = CommonHelper.GetCurrentIpAddress();
            string Lat = Convert.ToString(hfLat.Value).Trim();
            string Long = Convert.ToString(hfLon.Value).Trim();
            string Location = Convert.ToString(hfLocation.Value).Trim();
            int LocationType = Convert.ToInt16(hfLcType.Value);
            string LocationResponse = Convert.ToString(hfLocResponse.Value).Trim();
            string macAddress = CommonHelper.GetMacAddress();
            //int UserID = GoldMedal.Branding.Core.Common.ValidateDataType.GetCookieInt("userlogid");
            int DesignationID = Convert.ToInt32(hfDesignationID.Value);
            string userCategory = Convert.ToString(hfCategory.Value);
            string machineName = Environment.MachineName;

            string uaString = Request.UserAgent;
            //var uaParser = Parser.GetDefault();
            var uaParser = Parser.FromYamlFile(Server.MapPath("~/App_Data/regexes.yaml"));
            ClientInfo c = uaParser.Parse(uaString);

            var OSFamily = c.OS.Family; // => "iOS"
            var OSVersion = c.OS.Major + "." + c.OS.Minor;

            var BrowserFamily = c.UserAgent.Family; // => "Mobile Safari"
            var BrowserVersion = c.UserAgent.Major + "." + c.UserAgent.Minor;

            var DeviceFamily = c.Device.Family;    // => "iPhone"
            var DeviceFormFactor = c.Device.FormFactor;  // => Mobile

            var devBrand = c.Device.Brand;
            var devModel = c.Device.Model;
            var devbot = c.Device.IsSpider;

            if (!string.IsNullOrEmpty(IPAddress))
            {
                SqlParameter[] objParameter = new SqlParameter[20];
                objParameter[0] = new SqlParameter("@ipaddress", SqlDbType.VarChar);
                objParameter[0].Value = IPAddress;
                objParameter[1] = new SqlParameter("@Latitude", SqlDbType.VarChar);
                objParameter[1].Value = Lat;
                objParameter[2] = new SqlParameter("@Longitude", SqlDbType.VarChar);
                objParameter[2].Value = Long;
                objParameter[3] = new SqlParameter("@GeoLocation", SqlDbType.VarChar);
                objParameter[3].Value = Location;
                objParameter[4] = new SqlParameter("@OSFamily", SqlDbType.VarChar);
                objParameter[4].Value = OSFamily;
                objParameter[5] = new SqlParameter("@OSVersion", SqlDbType.VarChar);
                objParameter[5].Value = OSVersion;
                objParameter[6] = new SqlParameter("@BrowserFamily", SqlDbType.VarChar);
                objParameter[6].Value = BrowserFamily;
                objParameter[7] = new SqlParameter("@BrowserVersion", SqlDbType.VarChar);
                objParameter[7].Value = BrowserVersion;
                objParameter[8] = new SqlParameter("@DeviceFamily", SqlDbType.VarChar);
                objParameter[8].Value = DeviceFamily;
                objParameter[9] = new SqlParameter("@DeviceFormFactor", SqlDbType.VarChar);
                objParameter[9].Value = DeviceFormFactor;
                objParameter[10] = new SqlParameter("@devBrand", SqlDbType.VarChar);
                objParameter[10].Value = devBrand;
                objParameter[11] = new SqlParameter("@devModel", SqlDbType.VarChar);
                objParameter[11].Value = devModel;
                objParameter[12] = new SqlParameter("@devbot", SqlDbType.Bit);
                objParameter[12].Value = devbot;
                objParameter[13] = new SqlParameter("@LocationType", SqlDbType.Int);
                objParameter[13].Value = Convert.ToInt16(LocationType); ;
                objParameter[14] = new SqlParameter("@LocationResponse", SqlDbType.VarChar);
                objParameter[14].Value = LocationResponse;
                objParameter[15] = new SqlParameter("@macaddress", SqlDbType.VarChar);
                objParameter[15].Value = macAddress;
                objParameter[16] = new SqlParameter("@userid", SqlDbType.Int);
                objParameter[16].Value = UserID;
                objParameter[17] = new SqlParameter("@designationid", SqlDbType.Int);
                objParameter[17].Value = DesignationID;
                objParameter[18] = new SqlParameter("@usercat", SqlDbType.VarChar);
                objParameter[18].Value = userCategory;
                objParameter[19] = new SqlParameter("@machineName", SqlDbType.VarChar);
                objParameter[19].Value = machineName;

                int success = Convert.ToInt32(objDataAccess.ExecuteNonQueryWithParameters("InsertUserLocationDetails", objParameter));

                if (success == 1)
                {
                    locCookie = SecurityHelper.Encrypt(Lat + "#" + Long + "#" + Location + "#" + LocationType, Convert.ToString(ConfigurationManager.AppSettings["EncrptKey"]));
                    CommonHelper.SetCookie("geoloc", locCookie, DateTime.Now.AddMinutes(Convert.ToInt32(ConfigurationManager.AppSettings["LocationCookieExpiryDays"])));
                    CommonHelper.SetCookie("geoip", IPAddress, DateTime.Now.AddMinutes(Convert.ToInt32(ConfigurationManager.AppSettings["LocationCookieExpiryDays"])));
                    result = true;
                }
            }

            return result;
        }

        public class LocationInfo
        {
            public long LogNo { get; set; }
            public string IPAddress { get; set; }
            public string Latitude { get; set; }
            public string Longitude { get; set; }
            public string GeoLocation { get; set; }
            public string OSFamily { get; set; }
            public string OSVersion { get; set; }
            public string BrowserFamily { get; set; }
            public string DeviceFamily { get; set; }
            public string DeviceFormFactor { get; set; }
            public string devBrand { get; set; }
            public string devModel { get; set; }
            public bool devbot { get; set; }
            public int LocationType { get; set; }
            public string LocationResponse { get; set; }
        }

        protected bool ValidateLatLong(string Coord)
        {
            bool result = false;

            string reg = @"^-?([1-8]?[1-9]|[1-9]0)\.{1}\d{1,6}";
            Regex rg = new Regex(reg);
            result = rg.IsMatch(Coord);

            return result;
        }

        public string GetLocationData(out string error, string IP)
        {
            error = "";
            string responsestr = "";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://ip-api.com/json/" + IP);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    responsestr = reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return responsestr;
        }

        private void CheckLocationInfo()
        {
            string locCookie = "";
            string[] cookiedata;

            if (Request.Cookies["geoloc"] != null && Request.Cookies["geoip"] != null)
            {
                if (Convert.ToString(Request.Cookies["geoloc"].Value) != "" && Convert.ToString(Request.Cookies["geoip"].Value) != "")
                {
                    if (Request.Cookies["geoip"].Value.ToString() == CommonHelper.GetCurrentIpAddress())
                    {
                        try
                        {
                            locCookie = SecurityHelper.Decrypt(Request.Cookies["geoloc"].Value.ToString(), Convert.ToString(ConfigurationManager.AppSettings["EncrptKey"]));
                            hfLcFound.Value = "1";
                        }
                        catch (Exception)
                        {
                            Response.Cookies["geoloc"].Expires = DateTime.Now.AddDays(-1);
                            Response.Cookies["geoip"].Expires = DateTime.Now.AddDays(-1);
                            hfLcFound.Value = "0";
                        }
                    }
                    else
                    {
                        Response.Cookies["geoloc"].Expires = DateTime.Now.AddDays(-1);
                        Response.Cookies["geoip"].Expires = DateTime.Now.AddDays(-1);
                        hfLcFound.Value = "0";
                    }
                }
                else
                {
                    hfLcFound.Value = "0";
                }
            }
            else
            {
                hfLcFound.Value = "0";
            }
        }

        #endregion
    }
}