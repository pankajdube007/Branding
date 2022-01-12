using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Net;
using System.Text;

/// <summary>
/// Summary description for UserManagement
/// </summary>
public partial class UserManagement : IUserManagement
{
    private readonly List<UserInfo> _uinfo;
    private bool IsExportable = false;
   
    DataTable dt = new DataTable();
    DataTable dtlockdate = new DataTable();
    DataTable dtstateid = new DataTable();
    /// <summary>
    /// Ctor
    /// </summary>
    public UserManagement()
    {
        _uinfo = new List<UserInfo>();
    }

    private string GetUserString(UserEnum.UserInfoEnum uifo)
    {
        string _info = CommonHelper.GetCookieString("FacGoldPage", true);
        dynamic _infoData = JsonConvert.DeserializeObject(_info);
        dynamic str11 = _infoData[0][uifo.ToString()];
        return Convert.ToString(str11.Value);
    }
    private string StoreUserData(string info)
    {
        string _returnString = string.Empty;
        dynamic _uDatas = JsonConvert.DeserializeObject(info);
        //put all the cookies data here
        _uinfo.Add(new UserInfo
        {
            UserLogID = Convert.ToString(_uDatas[0].data["userlogid"].ToString()),
            UserLogNameOrEmail = Convert.ToString(_uDatas[0].data["userlognm"].ToString()),
            UserName = Convert.ToString(_uDatas[0].data["usernm"].ToString()),
            StateID = Convert.ToString(_uDatas[0].data["stateid"].ToString()),
            Status = Convert.ToString(_uDatas[0].data["status"].ToString()),
            IsSuccess = Convert.ToString(_uDatas[0].data["issuccess"].ToString()),
            IsBlock = Convert.ToString(_uDatas[0].data["isblock"].ToString()),
            UniqueKey = Convert.ToString(_uDatas[0].data["uniquekey"].ToString()),
        });
        try
        {
            CommonHelper.SetUserInCookie(_uDatas[0].data["userlognm"].ToString(), JsonConvert.SerializeObject(_uinfo), true);
        }
        catch (Exception)
        {
            _returnString = "Unable To Store Data! Try Again";
        }
        return _returnString;
    }
    /// <summary>
    /// Validate User Data Which we get from API Response
    /// </summary>
    /// <param name="responseString"></param>
    /// <returns>if empty then everything fine</returns>
    public string AuthUser(string responseString)
    {
        string _returnString = string.Empty;
        dynamic _uData = JsonConvert.DeserializeObject(responseString);
        string resultstatus = _uData[0]["result"];
        string message = _uData[0]["message"];
        if (resultstatus.Trim() == "False")
        {
            _returnString = Convert.ToString(_uData[0]["message"]);
        }
        else
        {
            bool isblock = _uData[0].data["isblock"];
            bool issuccess = _uData[0].data["issuccess"];
            if (isblock)
            {
                _returnString = "Oops!! Your A/C has been blocked";
            }
            else
            {
                var result = StoreUserData(responseString);
                if (!string.IsNullOrEmpty(result))
                    _returnString = result;
            }
        }
        return _returnString;
    }
    public void FakeUserStore(int uid)
    {
        //implement it here
    }
    /// <summary>
    /// Get Authenticate User Info
    /// </summary>
    /// <param name="_httpContext"></param>
    /// <returns>List User else null</returns>
    public List<UserInfo> GetAuthenticatedCustomer(HttpContext _httpContext)
    {
        if (_httpContext == null || _httpContext.Request == null || !_httpContext.Request.IsAuthenticated || !(_httpContext.User.Identity is FormsIdentity))
            return null;
        var formsIdentity = (FormsIdentity)_httpContext.User.Identity;
        var customer = CommonHelper.GetAuthenticatedCustomerFromTicket(formsIdentity.Ticket);
        if (customer == null || customer.Length == 0)
            return null;
        var _uinfo = JsonConvert.DeserializeObject<List<UserInfo>>(customer);
        if (_uinfo != null && _uinfo.Count > 0)
            //_cachedCustomer = customer;
            //return _cachedCustomer;
            return _uinfo;
        return null;
    }
    public bool GetUserInfoBool(UserEnum.UserInfoEnum uifo)
    {
        var str1 = GetUserInfoString(uifo).ToUpperInvariant();
        return (str1 == "TRUE" || str1 == "YES" || str1 == "1");
    }
    public int GetUserInfoInt(UserEnum.UserInfoEnum uifo)
    {
        var str1 = CommonHelper.EnsureNumericOnly(GetUserInfoString(uifo));
        if (!String.IsNullOrEmpty(str1))
            return Convert.ToInt32(str1);
        else
            return 0;
    }
    public long GetUserInfoLong(UserEnum.UserInfoEnum uifo)
    {
        var str1 = CommonHelper.EnsureNumericOnly(GetUserInfoString(uifo));
        if (!String.IsNullOrEmpty(str1))
            return Convert.ToInt64(str1);
        else
            return 0;
    }
    public string GetUserInfoString(UserEnum.UserInfoEnum uifo)
    {
        return GetUserString(uifo);
    }
    
    /// <summary>
    /// Logout customer
    /// </summary>
    public void Logout()
    {
        if (HttpContext.Current != null)
        {
            HttpContext.Current.Session.Clear();
        }
        if (HttpContext.Current != null && HttpContext.Current.Session != null)
        {
            HttpContext.Current.Session.Abandon();
        }
        string[] myCookie = HttpContext.Current.Request.Cookies.AllKeys;
        foreach (string cookie in myCookie)
        {
            if (!string.Equals(cookie, "__AntiXsrfToken"))
            {
                HttpContext.Current.Response.Cookies[cookie].Expires = DateTime.Now.AddDays(-1);
            }
        }
        FormsAuthentication.SignOut();
        HttpContext.Current.Response.Redirect("~/Default.aspx");
    }

    
}
