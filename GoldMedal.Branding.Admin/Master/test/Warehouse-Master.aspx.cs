using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Data.OleDb;

using System.Text;
using DevExpress.Web;
using System.Drawing;

using System.Collections;
using System.Drawing;
using System.Xml.Linq;
using System.Xml;

public partial class Warehouse_Master : System.Web.UI.Page
{
    General g1 = new General();
    DataTable dt = new DataTable();
    DataTable dt10 = new DataTable();

    #region Edit Block - Variable

    string html = string.Empty;
    string overwriteStr = string.Empty;
    string TableNm = "WarehouseMast";
    string Node = "Master";

    #endregion

    int rows = 0;
    string checkseq = string.Empty, checkdata = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lbid.Text = "0";
            txtloccode.Focus();
            ASPxPageControl1.ActiveTabIndex = 0;
            FillBranch();
        }

        txtstatename.Attributes.Add("readonly", "readonly");
        txtcountryname.Attributes.Add("readonly", "readonly");
        txtcityname.Attributes.Add("readonly", "readonly");
        cbozone.Attributes.Add("readonly", "readonly");
    }

    protected void txtlocname_TextChanged(object sender, EventArgs e)
    {
        txtprintname.Text = txtlocname.Text;
    }

    protected void FillBranch()
    {
        dt = g1.return_dt("exec SelectBranchMastre");

        if (dt.Rows.Count > 0)
        {
            cboBranch.DataSource = dt;
            cboBranch.DataBind();
        }
    }

    public void ASPxGridLookup1_ValueChanged(object sender, EventArgs e)
    {
        string countrynm2 = string.Empty, state2 = string.Empty, citynm2 = string.Empty, zonenm2 = string.Empty;
        DataTable dt8 = new DataTable();
        dt8 = g1.return_dt("exec areashow1 '" + ASPxGridLookup1.Value + "'");

        if (dt8.Rows.Count > 0)
        {
            countrynm2 = Convert.ToString(dt8.Rows[0]["countrynm"]);
            state2 = Convert.ToString(dt8.Rows[0]["statenm"]);
            citynm2 = Convert.ToString(dt8.Rows[0]["citynm"]);
            zonenm2 = g1.reterive_val("exec stateshow2 '" + state2 + "'");

            ASPxGridLookup1.GridView.JSProperties["cpSelectedCountry"] = Convert.ToString(countrynm2);
            ASPxGridLookup1.GridView.JSProperties["cpSelectedCountry1"] = Convert.ToString(state2);
            ASPxGridLookup1.GridView.JSProperties["cpSelectedCountry2"] = Convert.ToString(citynm2);
            ASPxGridLookup1.GridView.JSProperties["cpSelectedzonenm2"] = Convert.ToString(zonenm2);
        }
    }

    protected void ASPxCallbackPanel1_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
    {
        string[] parts = e.Parameter.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
    }

    protected void CmdSubmit_Click(object sender, EventArgs e)
    {
        addneew();
    }

    protected void checkmandetoey()
    {
        if (cboBranch.Value == null)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Please select Branch.','warning',2);", true);
            cboBranch.BorderColor = Color.Red;
            cboBranch.Focus();
        }

        if (txtloccode.Text.Trim() == string.Empty)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Please enter Warehouse Code.','warning',2);", true);
            txtloccode.BorderColor = Color.Red;
            txtloccode.Focus();
        }

        else if (txtlocname.Text.Trim() == string.Empty)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Please enter Warehouse Name.','warning',2);", true);
            txtlocname.BorderColor = Color.Red;
            txtlocname.Focus();
            txtloccode.BorderColor = System.Drawing.Color.Empty;
            cboBranch.BorderColor = System.Drawing.Color.Empty;
        }

        else if (txtmobile.Text.Trim() == string.Empty)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Please enter Mobile.','warning',2);", true);
            txtmobile.BorderColor = Color.Red;
            txtmobile.Focus();
            txtlocname.BorderColor = System.Drawing.Color.Empty;
            txtloccode.BorderColor = System.Drawing.Color.Empty;
            cboBranch.BorderColor = System.Drawing.Color.Empty;
        }

        else if (txtpfficeph1.Text.Trim() == string.Empty)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Please enter Office Phone 1.','warning',2);", true);
            txtpfficeph1.BorderColor = Color.Red;
            txtpfficeph1.Focus();
            txtlocname.BorderColor = System.Drawing.Color.Empty;
            txtloccode.BorderColor = System.Drawing.Color.Empty;
            txtmobile.BorderColor = System.Drawing.Color.Empty;
            cboBranch.BorderColor = System.Drawing.Color.Empty;
        }

        else if (txtadd1.Text.Trim() == string.Empty)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Please enter Address line 1.','warning',2);", true);
            txtadd1.BorderColor = Color.Red;
            txtadd1.Focus();
            txtlocname.BorderColor = System.Drawing.Color.Empty;
            txtloccode.BorderColor = System.Drawing.Color.Empty;
            txtmobile.BorderColor = System.Drawing.Color.Empty;
            txtpfficeph1.BorderColor = System.Drawing.Color.Empty;
            cboBranch.BorderColor = System.Drawing.Color.Empty;
        }

        else if (ASPxGridLookup1.Value == null)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Please enter Area Name.','warning',2);", true);
            ASPxGridLookup1.BorderColor = Color.Red;
            ASPxGridLookup1.Focus();
            txtlocname.BorderColor = System.Drawing.Color.Empty;
            txtloccode.BorderColor = System.Drawing.Color.Empty;
            txtmobile.BorderColor = System.Drawing.Color.Empty;
            txtpfficeph1.BorderColor = System.Drawing.Color.Empty;
            txtadd1.BorderColor = System.Drawing.Color.Empty;
            cboBranch.BorderColor = System.Drawing.Color.Empty;

        }

    }

    protected void addneew()
    {
        object value5 = ASPxGridLookup1.Value;
        ASPxGridView grid5 = ASPxGridLookup1.GridView;
        object values5 = grid5.GetRowValuesByKeyValue(value5, "areanm");

        if (values5 != null)
        {
            txtareaname.Text = values5.ToString();
        }
        else
        {
            txtareaname.Text = string.Empty;
        }

        if (txtareaname.Text != "" && txtcityname.Text != "" && txtstatename.Text != "" && txtcountryname.Text != "" && txtpfficeph1.Text != "" && txtmobile.Text != ""
            && txtloccode.Text != string.Empty && txtlocname.Text != string.Empty && cbozone.Text != "" && cboBranch.Value != null)
        {

            checkdata = g1.reterive_val("exec warehousecheck '" + txtlocname.Text + "','" + txtloccode.Text + "'," + lbid.Text);

            if (checkdata == string.Empty)
            {
                if (lbid.Text == "0")
                {
                    rows = g1.ExecDB("exec warehouseadd '" + txtlocname.Text.Trim() + "','" + txtloccode.Text.Trim() + "'," + cboBranch.Value + ",'" + txtprintname.Text.Trim() + "','" + txtadd1.Text.Trim() + "','"
                        + txtadd2.Text.Trim() + "','" + txtadd3.Text.Trim() + "','" + txtpincode.Text.Trim() + "','" + txtpfficeph1.Text.Trim() + "','" + txtpfficeph2.Text.Trim() + "','" + txtmobile.Text.Trim() + "','"
                        + txtemail.Text.Trim() + "','" + txtremarks.Text.Trim() + "','" + txtdcnopreffix.Text.Trim() + "','" + txtdcnosuffix.Text.Trim() + "','" + txtinvoicenopreffix.Text.Trim() + "','"
                        + txtdcnosuffix.Text.Trim() + "'," + Request.Cookies["uid"].Value + "," + Request.Cookies["logno"].Value + ",0,'Insert','" + txtareaname.Text.Trim() + "'");
                }
                else
                {
                    rows = g1.ExecDB("exec warehouseadd '" + txtlocname.Text.Trim() + "','" + txtloccode.Text.Trim() + "'," + cboBranch.Value + ",'" + txtprintname.Text.Trim() + "','" + txtadd1.Text.Trim() + "','"
                        + txtadd2.Text.Trim() + "','" + txtadd3.Text.Trim() + "','" + txtpincode.Text.Trim() + "','" + txtpfficeph1.Text.Trim() + "','" + txtpfficeph2.Text.Trim() + "','" + txtmobile.Text.Trim() + "','"
                        + txtemail.Text.Trim() + "','" + txtremarks.Text.Trim() + "','" + txtdcnopreffix.Text.Trim() + "','" + txtdcnosuffix.Text.Trim() + "','" + txtinvoicenopreffix.Text.Trim() + "','"
                        + txtdcnosuffix.Text.Trim() + "'," + Request.Cookies["uid"].Value + "," + Request.Cookies["logno"].Value + "," + lbid.Text + ",'Edit','" + txtareaname.Text.Trim() + "'");
                }

                if (rows > 0)
                {
                    clean();
                    ASPxGridView1.DataBind();
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Successful.','success',2);", true);
                }

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Location Name or location code already present.','warning',2);", true);
            }

        }
        else
        {
            checkmandetoey();
        }
    }

    #region Common Function

    protected void columnhide()
    {
        ASPxGridView1.Columns[0].Visible = false;
        ASPxGridView1.Columns[1].Visible = false;
        ASPxGridView1.Columns[2].Visible = false;
    }

    protected void columnshow()
    {
        ASPxGridView1.Columns[0].Visible = true;
        ASPxGridView1.Columns[1].Visible = true;
        ASPxGridView1.Columns[2].Visible = true;
    }

    protected void btnPdfExport_Click(object sender, EventArgs e)
    {
        //ASPxGridView1.WritePdfToResponse();
        columnhide();
        ASPxGridViewExporter1.WritePdfToResponse();
        columnshow();
    }
    protected void btnXlsExport_Click(object sender, EventArgs e)
    {
        // ASPxGridView1.WriteXlsToResponse(new XlsExportOptionsEx { ExportType = ExportType.WYSIWYG });
        columnhide();
        ASPxGridViewExporter1.WriteXlsToResponse();
        columnshow();

    }
    protected void btnXlsxExport_Click(object sender, EventArgs e)
    {
        // ASPxGridView1.WriteXlsxToResponse(new XlsxExportOptionsEx { ExportType = ExportType.WYSIWYG });
        columnhide();
        ASPxGridViewExporter1.WriteXlsxToResponse();
        columnshow();
    }
    protected void btnRtfExport_Click(object sender, EventArgs e)
    {
        //  ASPxGridView1.WriteRtfToResponse();
        columnhide();
        ASPxGridViewExporter1.WriteRtfToResponse();
        columnshow();
    }
    protected void btnCsvExport_Click(object sender, EventArgs e)
    {
        // ASPxGridView1.WriteCsvToResponse(new CsvExportOptionsEx() { ExportType = ExportType.WYSIWYG });

        columnhide();
        ASPxGridViewExporter1.WriteCsvToResponse();
        columnshow();

    }

    #endregion


    protected void clean()
    {
        #region Edit Block - Code

        ResetFunc();

        #endregion

        lbid.Text = "0";
        cboBranch.Value = null;
        txtmobile.Text = string.Empty;
        cbozone.Text = string.Empty;
        txtcityname.Text = string.Empty;
        txtlocname.Text = string.Empty;
        txtloccode.Text = string.Empty;
        txtcountryname.Text = string.Empty;
        txtprintname.Text = string.Empty;
        txtstatename.Text = string.Empty;
        txtremarks.Text = string.Empty;

        txtloccode.Text = string.Empty;
        txtlocname.Text = string.Empty;
        txtadd1.Text = string.Empty;
        txtadd2.Text = string.Empty;
        txtadd3.Text = string.Empty;
        txtareaname.Text = string.Empty;
        txtpfficeph1.Text = string.Empty;
        txtpfficeph2.Text = string.Empty;
        txtpincode.Text = string.Empty;
        txtdcnopreffix.Text = string.Empty;
        txtloccode.Focus();
        ASPxGridLookup1.Value = null;
        txtemail.Text = string.Empty;
        txtdcnopreffix.Text = string.Empty;
        txtdcnosuffix.Text = string.Empty;
        txtinvoicenopreffix.Text = string.Empty;
        txtinvoicenosuffix.Text = string.Empty;
        txtloccode.BorderColor = System.Drawing.Color.Empty;
        txtlocname.BorderColor = System.Drawing.Color.Empty;
        txtmobile.BorderColor = System.Drawing.Color.Empty;
        txtpfficeph1.BorderColor = System.Drawing.Color.Empty;
        txtadd1.BorderColor = System.Drawing.Color.Empty;
        txtareaname.BorderColor = System.Drawing.Color.Empty;
        ASPxGridLookup1.BorderColor = System.Drawing.Color.Empty;
        cboBranch.BorderColor = System.Drawing.Color.Empty;
    }

    protected void CmdReset_Click(object sender, EventArgs e)
    {
        clean();
    }

    protected void CmdEdit_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
    {
        int FieldTripID = Convert.ToInt32(e.CommandArgument);
        lbid.Text = FieldTripID.ToString();

        #region Edit Block - Code

        CheckEditBlock("Edit", Convert.ToInt32(lbid.Text));

        #endregion
    }

    protected void CmdDelete_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
    {
        int FieldTripID = Convert.ToInt32(e.CommandArgument);

        #region Edit Block - Code

        CheckEditBlock("Delete", FieldTripID);

        #endregion
    }

    protected void show(string rcid)
    {

        lbmsg.Text = string.Empty;

        DataTable dtshow = new DataTable();
        dtshow = g1.return_dt("exec warehouseshow " + rcid);
        if (dtshow.Rows.Count > 0)
        {

            txtloccode.Text = Convert.ToString(dtshow.Rows[0]["loccode"]);
            txtlocname.Text = Convert.ToString(dtshow.Rows[0]["locnm"]);
            txtprintname.Text = Convert.ToString(dtshow.Rows[0]["printnm"]);
            txtremarks.Text = Convert.ToString(dtshow.Rows[0]["remarks"]);
            txtpincode.Text = Convert.ToString(dtshow.Rows[0]["pincode"]);
            txtadd1.Text = Convert.ToString(dtshow.Rows[0]["add1"]);
            txtadd2.Text = Convert.ToString(dtshow.Rows[0]["add2"]);
            txtadd3.Text = Convert.ToString(dtshow.Rows[0]["add3"]);
            txtareaname.Text = Convert.ToString(dtshow.Rows[0]["areanm"]);
            txtpfficeph1.Text = Convert.ToString(dtshow.Rows[0]["offphone1"]);
            txtpfficeph2.Text = Convert.ToString(dtshow.Rows[0]["offphone2"]);
            txtpincode.Text = Convert.ToString(dtshow.Rows[0]["pincode"]);
            txtmobile.Text = Convert.ToString(dtshow.Rows[0]["mobile"]);
            txtemail.Text = Convert.ToString(dtshow.Rows[0]["email"]);
            ASPxGridLookup1.Value = Convert.ToString(dtshow.Rows[0]["areanm"]);
            txtinvoicenopreffix.Text = Convert.ToString(dtshow.Rows[0]["invoicenoprefix"]);
            txtinvoicenosuffix.Text = Convert.ToString(dtshow.Rows[0]["invoicenosuffix"]);
            txtdcnopreffix.Text = Convert.ToString(dtshow.Rows[0]["dcnoprefix"]);
            txtdcnosuffix.Text = Convert.ToString(dtshow.Rows[0]["dcnosuffix"]);
            cbozone.Text = Convert.ToString(dtshow.Rows[0]["zonenm"]);
            txtcountryname.Text = Convert.ToString(dtshow.Rows[0]["countrynm"]);
            txtstatename.Text = Convert.ToString(dtshow.Rows[0]["statenm"]);
            txtcityname.Text = Convert.ToString(dtshow.Rows[0]["citynm"]);
            cboBranch.Value = Convert.ToString(dtshow.Rows[0]["BranchID"]);

            txtloccode.Focus();

        }
        else
        {
            #region Edit Block - Code

            ResetFunc();

            #endregion

            lbid.Text = "0";
            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','No record found.','error',2);", true);
        }

    }

    protected void cboBranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cboBranch.Value != null)
        {
            GetBranchDtl(cboBranch.Value.ToString());
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','No data found for this branch, please select valid branch.','warning',2);", true);
        }
    }

    protected void GetBranchDtl(string rcid)
    {

        lbmsg.Text = string.Empty;

        DataTable dtshow = new DataTable();
        dtshow = g1.return_dt("exec branchshow " + rcid);
        if (dtshow.Rows.Count > 0)
        {
            txtloccode.Text = Convert.ToString(dtshow.Rows[0]["loccode"]);
            txtlocname.Text = Convert.ToString(dtshow.Rows[0]["locnm"]);
            txtprintname.Text = Convert.ToString(dtshow.Rows[0]["printnm"]);
            txtremarks.Text = Convert.ToString(dtshow.Rows[0]["remarks"]);
            txtpincode.Text = Convert.ToString(dtshow.Rows[0]["pincode"]);
            txtadd1.Text = Convert.ToString(dtshow.Rows[0]["add1"]);
            txtadd2.Text = Convert.ToString(dtshow.Rows[0]["add2"]);
            txtadd3.Text = Convert.ToString(dtshow.Rows[0]["add3"]);
            txtareaname.Text = Convert.ToString(dtshow.Rows[0]["areanm"]);
            txtpfficeph1.Text = Convert.ToString(dtshow.Rows[0]["offphone1"]);
            txtpfficeph2.Text = Convert.ToString(dtshow.Rows[0]["offphone2"]);
            txtpincode.Text = Convert.ToString(dtshow.Rows[0]["pincode"]);
            txtmobile.Text = Convert.ToString(dtshow.Rows[0]["mobile"]);
            txtemail.Text = Convert.ToString(dtshow.Rows[0]["email"]);
            ASPxGridLookup1.Value = Convert.ToString(dtshow.Rows[0]["areanm"]);
            txtinvoicenopreffix.Text = Convert.ToString(dtshow.Rows[0]["invoicenoprefix"]);
            txtinvoicenosuffix.Text = Convert.ToString(dtshow.Rows[0]["invoicenosuffix"]);
            txtdcnopreffix.Text = Convert.ToString(dtshow.Rows[0]["dcnoprefix"]);
            txtdcnosuffix.Text = Convert.ToString(dtshow.Rows[0]["dcnosuffix"]);
            cbozone.Text = Convert.ToString(dtshow.Rows[0]["zonenm"]);
            txtcountryname.Text = Convert.ToString(dtshow.Rows[0]["countrynm"]);
            txtstatename.Text = Convert.ToString(dtshow.Rows[0]["statenm"]);
            txtcityname.Text = Convert.ToString(dtshow.Rows[0]["citynm"]);

            txtloccode.Focus();

        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','No data found for this branch, please select valid branch.','warning',2);", true);
        }

    }

    #region Edit Block - Function

    protected void ResetFunc()
    {
        if (lbid.Text != "0")
        {
            string resetSts = CheckEdit.ResetEditStatus(Convert.ToInt32(lbid.Text), TableNm, Node);
        }
    }

    protected void CheckEditBlock(string param, int id)
    {
        string str = string.Empty;
        overwriteStr = string.Empty;
        DataTable dtEditChk = new DataTable();

        dtEditChk = CheckEdit.IsEditable(id, TableNm, Request.Cookies["uid"].Value, Request.Cookies["usercat"].Value, HttpContext.Current.Request.Url.ToString(), Node);
        if (dtEditChk.Rows.Count > 0)
        {
            if (dtEditChk.Rows[0]["PStatus"] != null && (dtEditChk.Rows[0]["PStatus"].ToString() == "InActive" || dtEditChk.Rows[0]["PStatus"].ToString() == "Unchecked"))
            {
                if (param == "Delete")
                {
                    #region Delete Block

                    rows = g1.ExecDB("exec warehousuedel  " + Request.Cookies["uid"].Value + "," + Request.Cookies["logno"].Value + "," + id);
                    if (rows > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Success','Delete Successfull.','success',2);", true);
                        ASPxGridView1.DataBind();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','Data present delete not permit.','warning',2);", true);
                    }

                    #endregion
                }
                else
                {
                    #region Edit Block

                    show(lbid.Text);
                    ASPxPageControl1.ActiveTabIndex = 0;

                    #endregion
                }

            }
            else if (dtEditChk.Rows[0]["PStatus"] != null && dtEditChk.Rows[0]["PStatus"].ToString() == "Active")
            {
                #region Build HTML
                if (dtEditChk.Rows[0]["usercat"] != null && dtEditChk.Rows[0]["usercat"].ToString() != "")
                {
                    html += "<div>Name : " + dtEditChk.Rows[0]["usercat"].ToString() + "</div>";
                }
                if (dtEditChk.Rows[0]["BranchNm"] != null && dtEditChk.Rows[0]["BranchNm"].ToString() != "")
                {
                    html += "<div>Branch : " + dtEditChk.Rows[0]["BranchNm"].ToString() + "</div>";
                }
                if (dtEditChk.Rows[0]["Designation"] != null && dtEditChk.Rows[0]["Designation"].ToString() != "")
                {
                    html += "<div>Designation : " + dtEditChk.Rows[0]["Designation"].ToString() + "</div>";
                }

                if (dtEditChk.Rows[0]["offContactNo"] != null && dtEditChk.Rows[0]["offContactNo"].ToString() != "")
                {
                    html += "<div>Contact No : " + dtEditChk.Rows[0]["offContactNo"].ToString() + "</div>";
                }
                else if (dtEditChk.Rows[0]["offphone1"] != null && dtEditChk.Rows[0]["offphone1"].ToString() != "")
                {
                    html += "<div>Contact No : " + dtEditChk.Rows[0]["offphone1"].ToString() + "</div>";
                }
                #endregion

                if (dtEditChk.Rows[0]["viewoverwrite"] != null && dtEditChk.Rows[0]["viewoverwrite"].ToString() == "No")
                {
                    lbid.Text = "0";
                    str = @"<div><div>Another user is already working on the page.</div></br>" + html + "</div>";
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','" + str + "','warning');", true);
                }
                else if (dtEditChk.Rows[0]["viewoverwrite"] != null && dtEditChk.Rows[0]["viewoverwrite"].ToString() == "Yes")
                {
                    if (param != "Delete")
                    {
                        overwriteStr = @"<br><div ow-lf>Do you wish to overwrite current session ?</div><div ow-css ow-yes>Yes</div><div ow-css ow-no>No</div></div>";
                    }


                    str = @"<div><div>Another user is already working on the page.</div></br><div>" + html + "" + overwriteStr + "</div>";
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','" + str + "','warning');", true);
                }
                else
                {
                    lbid.Text = "0";
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','No data found, please refresh and try again.','warning',2);", true);
                }

            }
            else if (dtEditChk.Rows[0]["PStatus"] != null && dtEditChk.Rows[0]["PStatus"].ToString() == "Error")
            {
                lbid.Text = "0";
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Error','Error occurred, please refresh and try again.','error',3);", true);
            }
        }
        else
        {
            lbid.Text = "0";
            ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "showDialog('Warning','No data found, please refresh and try again.','warning',2);", true);
        }
    }

    protected void btnOverWrite_Click(object sender, EventArgs e)
    {
        string status = CheckEdit.UpdateEditStatus(Convert.ToInt32(lbid.Text), TableNm, Request.Cookies["uid"].Value, Request.Cookies["usercat"].Value, HttpContext.Current.Request.Url.ToString());

        #region Edit Block - Code

        show(lbid.Text);
        ASPxPageControl1.ActiveTabIndex = 0;

        #endregion
    }

    #endregion



}