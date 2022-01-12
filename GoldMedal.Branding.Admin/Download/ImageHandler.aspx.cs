using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;

namespace GoldMedal.Branding.Admin.Download
{
    public partial class ImageHandler : System.Web.UI.Page
    {
        private readonly IGoldMedia _goldMedia;

        public ImageHandler()
        {
            _goldMedia = new GoldMedia();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Params["PictureID"]))
            {

                var imgurl= GetImageDataNew(Request.Params["PictureID"]);

                
                if (imgurl != null && imgurl.Length > 0)
                {
                    Response.Redirect(imgurl);
                }
                else
                {
                    PostImage(Server.MapPath("~/img/avatar5.png"), HttpContext.Current);
                }



                //var _stream = GetImageData(Request.Params["PictureID"]);
                //if (_stream != null && _stream.Length > 0)
                //{
                //    WriteBinaryImage(_stream, HttpContext.Current);
                //}
                //else
                //{
                //    PostImage(Server.MapPath("~/img/avatar5.png"), HttpContext.Current);
                //}
            }
            else if (!string.IsNullOrEmpty(Request.Params["FileId"]))
            {
                try
                {

                    Download(Request.Params["FileId"], "", ContentDispositionType.Inline);
                }
                catch (Exception)
                {

                    PostImage(Server.MapPath("~/img/avatar5.png"), HttpContext.Current);
                }
            }


            else
            {
                PostImage(Server.MapPath("~/img/avatar5.png"), HttpContext.Current);
            }
        }

        private void PostImage(string id, HttpContext context)
        {
            byte[] image = FindImage(id);
            WriteBinaryImage(image, context);
        }

        private void WriteBinaryImage(Stream _stream, HttpContext context)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                byte[] fileBytes = null;
                byte[] buffer = new byte[4096];
                int chunkSize = 0;

                do
                {
                    chunkSize = _stream.Read(buffer, 0, buffer.Length);
                    ms.Write(buffer, 0, chunkSize);
                } while (chunkSize != 0);

                _stream.Close();
                fileBytes = ms.ToArray();

                using (System.Drawing.Image b = System.Drawing.Image.FromStream(ms))
                {
                    using (Bitmap bmp = new Bitmap(b, b.Width, b.Height))
                    {
                        using (Graphics g = Graphics.FromImage(bmp))
                        {
                            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                            g.SmoothingMode = SmoothingMode.HighQuality;
                            g.CompositingQuality = CompositingQuality.HighQuality;
                            g.DrawImage(bmp, 0, 0, b.Width, b.Height);
                            context.Response.ContentType = "image/jpeg";
                            bmp.Save(context.Response.OutputStream, ImageFormat.Jpeg);
                        }
                    }
                }
            }
            context.Response.End();
        }



        private void WriteBinaryImage(byte[] image, HttpContext context)
        {
            if (image != null)
            {
                context.Response.ContentType = "image/jpeg";
                using (MemoryStream ms = new MemoryStream(image))
                {
                    using (Bitmap bmp = (Bitmap)Bitmap.FromStream(ms))
                    {
                        bmp.Save(context.Response.OutputStream, ImageFormat.Jpeg);
                    }
                }
            }
            else
            {
                context.Response.ContentType = "image/gif";
            }
            context.Response.End();
        }

        private byte[] FindImage(string id)
        {
            try
            {
                if (!string.IsNullOrEmpty(id))
                    return File.ReadAllBytes(id);
                else
                    return new byte[] { 0 };
            }
            catch (Exception ex)
            {
                return new byte[] { 0 };
            }
        }

        private Stream GetImageData(string path)
        {
            try
            {
                if (!string.IsNullOrEmpty(path))
                {
                    return _goldMedia.GoldMediaDownload(path);
                }
            }
            catch (Exception)
            {

            }
            return null;
        }

        private string GetImageDataNew(string path)
        {
            try
            {
                if (!string.IsNullOrEmpty(path))
                {
                    return _goldMedia.MapPathToPublicUrl(path);
                }
            }
            catch (Exception)
            {

            }
            return null;
        }
        private void Download(string path, string fileName = "", ContentDispositionType _contentDispositionType = ContentDispositionType.Attachement)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                fileName = path.Split('/').Last();
            }
            var dispositionType = "";
            switch (_contentDispositionType)
            {
                case ContentDispositionType.Attachement:
                    dispositionType = "1";
                    break;
                default:
                    dispositionType = "0";
                    break;
            }
            string url = string.Format("Download.aspx?path={0}&contentDispositionType={1}&filename={2}", path, dispositionType, fileName);

            Response.Redirect(url);
        }
    }
}