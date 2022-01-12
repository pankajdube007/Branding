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

using System.Net.Sockets;
using System.Collections;
using System.Net.Mail;
using System.Net;

/// <summary>
/// Summary description for General
/// </summary>
public class General
{
    public SqlConnection con;
    public SqlCommand comm;
    public SqlDataReader dr;
    public SqlCommand objCmd;
    public BusinessLogic b1;

    BusinessLogic b2 = new BusinessLogic();

    public General()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public void sendmail(string toeamilid, string emailbody, string emailsubject, string displayname, string file_name)
    {
        //MailMessage msgMail = new MailMessage();

        ////msgMail.To = "info@happysarees.com";

        //msgMail.To = toeamilid;

        //msgMail.From = "info@goldmedalindia.com";

        //msgMail.Subject = emailsubject;
        //msgMail.Body = emailbody;

        //msgMail.BodyFormat = MailFormat.Html;
        //SmtpMail.Send(msgMail);
        SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

        //smtpClient.Credentials = new System.Net.NetworkCredential("it@goldmedalindia.com", "Gold1979Medal");
        smtpClient.Credentials = new System.Net.NetworkCredential("arun.g@goldmedalindia.com", "Arun@it231015");

        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
        smtpClient.EnableSsl = true;
        MailMessage mail = new MailMessage();
        mail.From = new MailAddress("it@goldmedalindia.com", displayname);

        mail.To.Add(new MailAddress(toeamilid));
        mail.IsBodyHtml = true;
        mail.Priority = MailPriority.High;
        mail.Body = emailbody;
        mail.Subject = emailsubject;

        smtpClient.Send(mail);
    }
    public SqlDataAdapter return_da(string s1)
    {
        b1 = new BusinessLogic();
        b1.open_connection();
        SqlCommand cmd1 = new SqlCommand(s1, b1.sql);
        cmd1.CommandType = CommandType.Text;
        SqlDataAdapter da = new SqlDataAdapter(cmd1);

        b1.close_connection();
        return da;
    }
    public int delete_val(String strSql)
    {
        int delval = 0;

        objCmd = new SqlCommand();
        b1 = new BusinessLogic();
        b1.open_connection();
        objCmd.Connection = b1.sql;
        objCmd.CommandType = CommandType.Text;
        objCmd.CommandText = strSql;
        //try
        //{
        delval = objCmd.ExecuteNonQuery();
        b1.close_connection();
        //}
        //catch (Exception e)
        //{
        //    Console.WriteLine("Insertion Problem" + e);
        //}
        //finally{
        //    objCmd.Dispose();
        //        }
        if (delval > 0)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }

    public DataTable return_dt(string s1)
    {
        b1 = new BusinessLogic();
        b1.open_connection();
        SqlCommand cmd1 = new SqlCommand(s1, b1.sql);
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd1);
        da.Fill(dt);
        b1.close_connection();
        return dt;
    }

    public int ExecDB(String strSql)
    {
        int retVal = 0;

        objCmd = new SqlCommand();
        b1 = new BusinessLogic();
        b1.open_connection();
        objCmd.Connection = b1.sql;
        objCmd.CommandType = CommandType.Text;
        objCmd.CommandText = strSql;
        //try
        //{
        retVal = objCmd.ExecuteNonQuery();
        b1.close_connection();
        //}
        //catch (Exception e)
        //{
        //    Console.WriteLine("Insertion Problem" + e);
        //}
        //finally{
        //    objCmd.Dispose();
        //        }
        if (retVal > 0)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }

    //public string ExecDB(String strSql)
    //{
    //    int retVal=0;

    //    objCmd = new SqlCommand();
    //    b1=new BusinessLogic();
    //    objCmd.Parameters.Add(new SqlParameter("@t_return", SqlDbType.VarChar, 255)); objCmd.Parameters["@t_return"].Direction = ParameterDirection.Output;

    //    b1.open_connection();
    //    objCmd.Connection = b1.sql ;
    //    objCmd.CommandType = CommandType.Text;
    //    objCmd.CommandText = strSql;
    //    //try
    //    //{
    //        objCmd.ExecuteNonQuery();
    //        b1.close_connection();
    //    //}
    //    //catch (Exception e)
    //    //{
    //    //    Console.WriteLine("Insertion Problem" + e);
    //    //}
    //    //finally{
    //    //    objCmd.Dispose();
    //    //        }

    //       // return retVal;
    //        string t_return = objCmd.Parameters["@t_return"].Value.ToString();
    //        return t_return;

    //    //if (retVal >0)
    //    //{
    //    //    return  1;
    //    //}
    //    //else
    //    //{
    //    //    return 0;
    //    //}

    //}

    public int delete_test(String strSql)
    {
        int delval = 0;

        objCmd = new SqlCommand();
        b1 = new BusinessLogic();
        b1.open_connection();
        objCmd.Connection = b1.sql;
        objCmd.CommandType = CommandType.Text;
        objCmd.CommandText = strSql;
        //try
        //{
        delval = objCmd.ExecuteNonQuery();
        b1.close_connection();
        //}
        //catch (Exception e)
        //{
        //    Console.WriteLine("Insertion Problem" + e);
        //}
        //finally{
        //    objCmd.Dispose();
        //        }
        if (delval > 0)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }

    /* public void populate_combo_test(String strsql, System.Web.UI.WebControls.DropDownList cmb1)
     {
         try
         {
             b1 = new BusinessLogic();
             b1.open_connection();
             SqlCommand cmd1 = new SqlCommand(s1, b1.sql);
             DataTable dt = new DataTable();
             SqlDataAdapter da = new SqlDataAdapter(cmd1);
             da.Fill(dt);

             b1.close_connection();
             return dt;
         }
         catch { }
     }*/

    public void populate_combo(String strsql, System.Web.UI.WebControls.DropDownList cmb1)
    {
        try
        {
            b2.open_connection();
            SqlCommand cmd = new SqlCommand(strsql, b2.sql);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                cmb1.Items.Add(dr.GetValue(0).ToString());
            }
            b2.close_connection();
        }
        catch { }
    }
    public string reterive_val(string s1)
    {
        string sSelect = s1;
        b1 = new BusinessLogic();
        b1.open_connection();
        SqlCommand cmd = new SqlCommand(sSelect, b1.sql);
        string genValue = Convert.ToString(cmd.ExecuteScalar());
        b1.close_connection();
        if (genValue == "")
        {
            return "";
        }
        else
        {
            //int id = Convert.ToInt32(genValue.PadRight(  genValue.Substring(4, genValue.Length - 4));
            return genValue;
        }
    }

    public int generate_max_id(string strsql)
    {
        //String  s2;
        int id;
        General g1;
        //BusinessLogic b1;

        b1 = new BusinessLogic();
        g1 = new General();

        b1.open_connection();
        string sSelect = strsql;
        SqlCommand cmd = new SqlCommand(sSelect, b1.sql);
        string genValue = Convert.ToString(cmd.ExecuteScalar());
        b1.close_connection();

        if (genValue == "")
        {
            id = 1;
        }
        else
        {
            //int id = Convert.ToInt32(genValue.PadRight(  genValue.Substring(4, genValue.Length - 4));
            id = Convert.ToInt32(genValue) + 1;
        }

        return id;
    }
    public int generate_max_id_reg(string strsql)
    {
        //String  s2;
        int id;
        General g1;

        b1 = new BusinessLogic();
        g1 = new General();

        b1.open_connection();
        string sSelect = strsql;
        SqlCommand cmd = new SqlCommand(sSelect, b1.sql);
        string genValue = Convert.ToString(cmd.ExecuteScalar());
        b1.close_connection();

        if (genValue == "")
        {
            id = 1001;
        }
        else
        {
            //int id = Convert.ToInt32(genValue.PadRight(  genValue.Substring(4, genValue.Length - 4));
            id = Convert.ToInt32(genValue) + 1;
        }

        return id;
    }
}