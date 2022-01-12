using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;


namespace GoldMedal.Branding.Admin.Download
{
    public partial class Download : System.Web.UI.Page
    {
        private readonly IGoldMedia _goldMedia;
        public Download()
        {
            _goldMedia = new GoldMedia();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Request.QueryString["path"] != "" && Request.QueryString["contentDispositionType"] != "" && Request.QueryString["filename"] != "")
            {
                try
                {
                    string filepath = Request.QueryString["path"];
                    ContentDispositionType contentDispositionType;
                    if (!Enum.TryParse(Request.QueryString["contentDispositionType"], out contentDispositionType))
                    {
                        contentDispositionType = ContentDispositionType.Attachement;
                    }
                    string filename = Request.QueryString["filename"];

                    FireDownload(filepath, contentDispositionType, filename);
                }
                catch (Exception ex)
                {
                    Response.Redirect("~/main.aspx");
                }
            }
            else
            {
                Response.Redirect("~/main.aspx");
            }
        }

        private void FireDownload(string filepath, ContentDispositionType contentDispositionType, string filename)
        {
            var _stream = _goldMedia.GoldMediaDownload(filepath);
            var contentType = GoldMimeType.GetMimeType(filepath.Split('.').Last());
            string dispositionType = string.Empty;

            switch (contentDispositionType)
            {
                case ContentDispositionType.Attachement:
                    dispositionType = "attachment";
                    break;
                default:
                    dispositionType = "inline";
                    break;
            }

            using (var ms = new MemoryStream())
            {
                byte[] fileBytes = null;
                byte[] buffer = new byte[4096];
                int chunkSize = 0;
                Response.ContentType = contentType;
                Response.AddHeader("content-disposition", string.Format("{0}; filename={1}", dispositionType, filename));

                do
                {
                    chunkSize = _stream.Read(buffer, 0, buffer.Length);
                    ms.Write(buffer, 0, chunkSize);
                } while (chunkSize != 0);

                _stream.Close();
                fileBytes = ms.ToArray();
                Response.BinaryWrite(fileBytes);

                Response.Flush();
                Response.Close();
            }
        }
    }
}