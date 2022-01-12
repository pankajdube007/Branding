using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

//using System.Data.SqlClient;

/// <summary>
/// Summary description for BusinessLogic
/// </summary>
public class BusinessLogic
{
    public SqlConnection sql;

    public BusinessLogic()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public void open_connection()
    {
        string str1 = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
        //ConnectionString1
        sql = new SqlConnection(str1);
        sql.Open();
    }

    public void close_connection()
    {
        sql.Close();
    }

    public void City(System.Web.UI.WebControls.DropDownList ctrlCity)
    {
        try
        {
            SqlCommand cmd = new SqlCommand("select City from city", sql);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ctrlCity.Items.Add(dr.GetValue(0).ToString());
            }
            //ctrlCity.DataSource = dr;
            //ctrlCity.DataTextField = "City";
            //ctrlCity.DataValueField = "City";
            //ctrlCity.DataBind();
            dr.Close();
        }
        catch
        {
            //this.Label2.Text = "There was an error while accessing the database.Please try agian later.";
        }
    }
    public void State(System.Web.UI.WebControls.DropDownList ctrlState)
    {
        try
        {
            //string str1 = ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
            //SqlConnection sql = new SqlConnection(str1);
            //sql.Open();
            SqlCommand cmd1 = new SqlCommand("select State from state", sql);
            SqlDataReader dr;
            dr = cmd1.ExecuteReader();
            while (dr.Read())
            {
                ctrlState.Items.Add(dr.GetValue(0).ToString());
            }
            //ctrlState.DataSource = dr;
            //ctrlState.DataTextField = "state";
            //ctrlState.DataValueField = "state";
            //ctrlState.DataBind();
            dr.Close();
        }
        catch
        {
            //this.Label2.Text = "There was an error while accessing the database.Please try agian later.";
        }
    }
    public void Country(System.Web.UI.WebControls.DropDownList ctrlCountry)
    {
        try
        {
            //string str1 = ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
            //SqlConnection sql = new SqlConnection(str1);
            //sql.Open();
            SqlCommand cmd1 = new SqlCommand("select * from country", sql);
            SqlDataReader dr;
            dr = cmd1.ExecuteReader();
            while (dr.Read())
            {
                ctrlCountry.Items.Add(dr.GetValue(0).ToString());
            }
            //ctrlCountry.DataSource = dr;
            //ctrlCountry.DataTextField = "country";
            //ctrlCountry.DataValueField = "country";
            //ctrlCountry.DataBind();
            dr.Close();
        }
        catch
        {
            //this.Label2.Text = "There was an error while accessing the database.Please try agian later.";
        }
    }
    public System.Data.SqlClient.SqlDataAdapter Return_Record(string s1)
    {
        SqlCommand cmd = new SqlCommand(s1, sql);
        SqlDataAdapter da = new SqlDataAdapter(cmd);

        return da;
    }
}