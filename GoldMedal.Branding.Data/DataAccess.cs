using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using context = System.Web.HttpContext;

namespace GoldMedal.Branding.Data
{
    public class DataAccess
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;
        public SqlCommand objCommand;
        public SqlConnection objSqlConnection = null;

        /// <summary>
        /// Open_Connection method will open the current instance of the connection object if the object is in closed state
        /// </summary>
        public void Open_Connection()
        {
            try
            {
                if (objSqlConnection.State == ConnectionState.Closed)
                {
                    objSqlConnection.Open();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Close_Connection method will close and dispose the connection object that was created earlier.
        /// </summary>
        public void Close_Connection()
        {
            try
            {
                if (objSqlConnection.State != ConnectionState.Closed)
                {
                    this.objSqlConnection.Close();
                    this.objSqlConnection.Dispose();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        ///Executes the query, and returns the first column of the first row in the result set returned by the query. Additional columns or rows are ignored.
        /// </summary>
        /// <param name="procedureName">Store procedure Name</param>
        /// <returns></returns>
        public object ExecuteScalar(string procedureName)
        {
            objSqlConnection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(procedureName, objSqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            object ReturnValue;
            Open_Connection();
            using (SqlTransaction Transaction = objSqlConnection.BeginTransaction())
            {
                try
                {
                    command.Transaction = Transaction;
                    ReturnValue = command.ExecuteScalar();
                    Transaction.Commit();
                }
                catch
                {
                    Transaction.Rollback();
                    throw;
                }
                finally
                {
                    Close_Connection();
                    command.Dispose();
                }
            }
            return ReturnValue;
        }

        /// <summary>
        /// Executes the query, and returns the first column of the first row in the result set returned by the query. Additional columns or rows are ignored.
        /// </summary>
        /// <param name="procedureName">Store Procedure Name</param>
        /// <param name="parameters">Parameters List</param>
        /// <returns></returns>
        public object ExecuteScalarWithParameters(string procedureName, SqlParameter[] parameters)
        {
            objSqlConnection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(procedureName, objSqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            object ReturnValue;
            Open_Connection();
            using (SqlTransaction Transaction = objSqlConnection.BeginTransaction())
            {
                try
                {
                    if (parameters != null)
                        command.Parameters.AddRange(parameters);

                    command.Transaction = Transaction;
                    ReturnValue = command.ExecuteScalar();
                    Transaction.Commit();
                }
                catch
                {
                    Transaction.Rollback();
                    throw;
                }
                finally
                {
                    Close_Connection();
                    command.Dispose();
                }
            }
            return ReturnValue;
        }

        /// <summary>
        /// Executes a Transact-SQL statement against the connection and returns the number of rows affected.
        /// </summary>
        /// <param name="procedureName">Store Procedure Name</param>
        /// <returns></returns>
        public object ExecuteNonQuery(string procedureName)
        {
            objSqlConnection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(procedureName, objSqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            object ReturnValue;
            Open_Connection();
            using (SqlTransaction Transaction = objSqlConnection.BeginTransaction())
            {
                try
                {
                    command.Transaction = Transaction;
                    ReturnValue = command.ExecuteNonQuery();
                    Transaction.Commit();
                }
                catch
                {
                    Transaction.Rollback();
                    throw;
                }
                finally
                {
                    Close_Connection();
                    command.Dispose();
                }
            }
            return ReturnValue;
        }

        /// <summary>
        /// Executes a Transact-SQL statement against the connection and returns the number of rows affected.
        /// </summary>
        /// <param name="procedureName">Store Procedure Name</param>
        /// <param name="parameters">Parameters</param>
        /// <returns></returns>
        public object ExecuteNonQueryWithParameters(string procedureName, SqlParameter[] parameters)
        {
            objSqlConnection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(procedureName, objSqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            object ReturnValue;
            Open_Connection();
            using (SqlTransaction Transaction = objSqlConnection.BeginTransaction())
            {
                try
                {
                    if (parameters != null)
                        command.Parameters.AddRange(parameters);

                    command.Transaction = Transaction;
                    ReturnValue = command.ExecuteNonQuery();
                    Transaction.Commit();
                }
                //catch
                //{
                //    Transaction.Rollback();
                //    throw;
                //}
                catch (Exception ex)
                {
                    Transaction.Rollback();
                    SendErrorToText(ex);
                    return -1;
                }
                finally
                {
                    Close_Connection();
                    command.Dispose();
                }
            }
            return ReturnValue;
        }

        /// <summary>
        /// Executes a Transact-SQL statement against the connection and returns the result of output parameter
        /// </summary>
        /// <param name="procedureName">Store Procedure Name</param>
        /// <param name="parameters">Parameters</param>
        /// <returns></returns>
        public object ExecuteNonQueryWithOutputParameters(string procedureName, SqlParameter[] parameters)
        {
            objSqlConnection = new SqlConnection(connectionString);
            object ReturnValue;
            SqlCommand command = new SqlCommand(procedureName, objSqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            Open_Connection();
            using (SqlTransaction Transaction = objSqlConnection.BeginTransaction())
            {
                try
                {
                    if (parameters != null)
                        command.Parameters.AddRange(parameters);

                    command.Transaction = Transaction;
                    command.ExecuteNonQuery();
                    ReturnValue = command.Parameters[parameters.Length - 1].Value;
                    Transaction.Commit();
                }
                //catch
                //{
                //    Transaction.Rollback();
                //   return 10;
                //    throw;
                //}
                catch (Exception ex)
                {
                    Transaction.Rollback();
                    SendErrorToText(ex);
                    return -1;
                }
                finally
                {
                    Close_Connection();
                    command.Dispose();
                }
            }
            return ReturnValue;
        }

        private static String ErrorlineNo, Errormsg, extype, exurl, hostIp, ErrorLocation, HostAdd;

        public static void SendErrorToText(Exception ex)
        {
            var line = Environment.NewLine + Environment.NewLine;

            ErrorlineNo = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);
            Errormsg = ex.GetType().Name.ToString();
            extype = ex.GetType().ToString();
            exurl = context.Current.Request.Url.ToString();
            ErrorLocation = ex.Message.ToString();

            try
            {
                string filepath = context.Current.Server.MapPath("~/Error/error.txt");  //Text File Path

                //if (!Directory.Exists(filepath))
                //{
                //    Directory.CreateDirectory(filepath);

                //}
                // filepath = filepath + DateTime.Today.ToString("dd-MM-yy") + ".txt";
                //if (!File.Exists(filepath))
                //{
                //    File.Create(filepath).Dispose();

                //}
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    string error = "Log Written Date:" + " " + DateTime.Now.ToString() + line + "Error Line No :" + " " + ErrorlineNo + line + "Error Message:" + " " + Errormsg + line + "Exception Type:" + " " + extype + line + "Error Location :" + " " + ErrorLocation + line + " Error Page Url:" + " " + exurl + line + "User Host IP:" + " " + hostIp + line;
                    sw.WriteLine("-----------Exception Details on " + " " + DateTime.Now.ToString() + "-----------------");
                    sw.WriteLine("-------------------------------------------------------------------------------------");
                    sw.WriteLine(line);
                    sw.WriteLine(error);
                    sw.WriteLine("--------------------------------*End*------------------------------------------");
                    sw.WriteLine(line);
                    sw.Flush();
                    sw.Close();
                }
            }
            catch (Exception e)
            {
                e.ToString();
            }
        }

        /// <summary>
        /// Executes a Transact-SQL statement against the connection and returns the result in table format
        /// Used only when we have to return records in multiple table format
        /// </summary>
        /// <param name="procedureName">Store Procedure Name</param>
        /// <returns></returns>
        public DataSet ReturnDataset(string procedureName)
        {
            objSqlConnection = new SqlConnection(connectionString);
            DataSet dataSet = new DataSet();
            SqlCommand command = new SqlCommand(procedureName, objSqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter DataAdapter = new SqlDataAdapter();
            DataAdapter.SelectCommand = command;
            Open_Connection();
            using (SqlTransaction Transaction = objSqlConnection.BeginTransaction())
            {
                try
                {
                    DataAdapter.SelectCommand.Transaction = Transaction;
                    DataAdapter.Fill(dataSet);
                    Transaction.Commit();
                }
                catch
                {
                    Transaction.Rollback();
                    throw;
                }
                finally
                {
                    Close_Connection();
                    command.Dispose();
                }
            }
            return dataSet;
        }

        /// <summary>
        /// Executes a Transact-SQL statement against the connection and returns the result in table format
        /// Used only when we have to return records in multiple table format
        /// </summary>
        /// <param name="procedureName">Store Procedure Name</param>
        /// <param name="parameters">Parameters</param>
        /// <returns></returns>
        public DataSet ReturnDatasetWithParameters(string procedureName, SqlParameter[] parameters)
        {
            objSqlConnection = new SqlConnection(connectionString);
            DataSet dataSet = new DataSet();
            SqlCommand command = new SqlCommand(procedureName, objSqlConnection);
            command.CommandType = CommandType.StoredProcedure;

            if (parameters != null)
                command.Parameters.AddRange(parameters);

            SqlDataAdapter DataAdapter = new SqlDataAdapter();
            DataAdapter.SelectCommand = command;
            Open_Connection();

            using (SqlTransaction oTransaction = objSqlConnection.BeginTransaction())
            {
                try
                {
                    DataAdapter.SelectCommand.Transaction = oTransaction;
                    DataAdapter.Fill(dataSet);
                    oTransaction.Commit();
                }
                catch
                {
                    oTransaction.Rollback();
                    throw;
                }
                finally
                {
                    Close_Connection();
                    command.Dispose();
                }
            }
            return dataSet;
        }

        /// <summary>
        /// Executes a Transact-SQL statement against the connection and returns the result in table format
        /// Used only when we have to return records in single table format
        /// </summary>
        /// <param name="procedureName">Store Procedure Name</param>
        /// <returns></returns>
        public DataTable ReturnDataTable(string procedureName)
        {
            objSqlConnection = new SqlConnection(connectionString);
            DataTable dataTable = new DataTable();
            SqlCommand command = new SqlCommand(procedureName, objSqlConnection);
            command.CommandTimeout = 90;
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter DataAdapter = new SqlDataAdapter();
            DataAdapter.SelectCommand = command;
            Open_Connection();
            using (SqlTransaction Transaction = objSqlConnection.BeginTransaction())
            {
                try
                {
                    DataAdapter.SelectCommand.Transaction = Transaction;
                    DataAdapter.Fill(dataTable);
                    Transaction.Commit();
                }
                catch
                {
                    Transaction.Rollback();
                    throw;
                }
                finally
                {
                    Close_Connection();
                    command.Dispose();
                }
            }
            return dataTable;
        }

        /// <summary>
        /// Executes a Transact-SQL statement against the connection and returns the result in table format
        /// Used only when we have to return records in single table format
        /// </summary>
        /// <param name="procedureName">Store Procedure Name</param>
        /// <param name="parameters">Parameters</param>
        /// <returns></returns>
        public DataTable ReturnDataTableWithParameters(string procedureName, SqlParameter[] parameters)
        {
            objSqlConnection = new SqlConnection(connectionString);
            DataTable dataTable = new DataTable();
            SqlCommand command = new SqlCommand(procedureName, objSqlConnection);
            command.CommandTimeout = 90;
            command.CommandType = CommandType.StoredProcedure;

            if (parameters != null)
                command.Parameters.AddRange(parameters);

            SqlDataAdapter DataAdapter = new SqlDataAdapter();
            DataAdapter.SelectCommand = command;
            Open_Connection();

            using (SqlTransaction Transaction = objSqlConnection.BeginTransaction())
            {
                try
                {
                    DataAdapter.SelectCommand.Transaction = Transaction;
                    DataAdapter.Fill(dataTable);
                    Transaction.Commit();
                }
                catch (Exception ex)
                {
                    Transaction.Rollback();
                    throw;
                }
                finally
                {
                    Close_Connection();
                    command.Dispose();
                }
            }
            return dataTable;
        }

        public string getip()
        {
            string VisitorsIPAddr = string.Empty;

            if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
            {
                VisitorsIPAddr = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
            }
            else if (HttpContext.Current.Request.UserHostAddress.Length != 0)
            {
                VisitorsIPAddr = HttpContext.Current.Request.UserHostAddress;
            }
            return VisitorsIPAddr;
        }

        public System.Data.SqlClient.SqlDataAdapter Return_Record(string s1)
        {
            SqlCommand cmd = new SqlCommand(s1, objSqlConnection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            return da;
        }

        public SqlDataAdapter return_da(string s1)
        {
            Open_Connection();
            SqlCommand cmd1 = new SqlCommand(s1, objSqlConnection);
            cmd1.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            Close_Connection();
            return da;
        }

        public int delete_val(String strSql)
        {
            int delval = 0;

            objCommand = new SqlCommand();

            Open_Connection();
            objCommand.Connection = objSqlConnection;
            objCommand.CommandType = CommandType.Text;
            objCommand.CommandText = strSql;
            //try
            //{
            delval = objCommand.ExecuteNonQuery();
            Close_Connection();
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
            Open_Connection();
            SqlCommand cmd1 = new SqlCommand(s1, objSqlConnection);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            da.Fill(dt);
            Close_Connection();
            return dt;
        }

        public int ExecDB(String strSql)
        {
            int retVal = 0;

            objCommand = new SqlCommand();
            Open_Connection();
            objCommand.Connection = objSqlConnection;
            objCommand.CommandType = CommandType.Text;
            objCommand.CommandText = strSql;
            //try
            //{
            retVal = objCommand.ExecuteNonQuery();
            Close_Connection();
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
    }
}