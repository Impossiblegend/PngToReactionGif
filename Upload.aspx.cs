using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace PngToReactionGif
{
    public partial class Upload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PngUpload.Attributes.Add("accept", ".png,.jpg,.jpeg");
        }

        protected void ConvertButton_Click(object sender, EventArgs e)
        {
            if (PngUpload.HasFile)
            {
                if (!string.IsNullOrEmpty(NameTB.Text))
                {
                    string filePath = Server.MapPath("~/assets/" + NameTB.Text + ".gif");
                    PngUpload.SaveAs(filePath);
                    System.Web.UI.WebControls.Image newImg = new System.Web.UI.WebControls.Image();
                    newImg.ImageUrl = "assets/" + NameTB.Text + ".gif";
                    newImg.Width = 1500;
                    newImg.Height = 1500;
                    newImg.CssClass = "background-image";
                    imgDiv.Controls.Add(newImg);
                    System.Web.UI.WebControls.Image bubble = new System.Web.UI.WebControls.Image();
                    bubble.ImageUrl = "assets/bubble.png";
                    bubble.Width = 1500;
                    bubble.Height = 1500;
                    bubble.CssClass = "overlay-image";
                    imgDiv.Controls.Add(bubble);
                    PngUpload.Visible = false; 
                    NameTB.Visible = false; 
                    ConvertButton.Visible = false; 
                    ErrorLabel.Visible = false; 
                    Point SourcePoint = new Point(0, 100);
                    Point DestinationPoint = new Point(0, 0);
                    Bitmap bt = new Bitmap(1150, 600);
                    //bt.MakeTransparent();
                    Graphics gr = Graphics.FromImage(bt);
                    gr.CopyFromScreen(SourcePoint, DestinationPoint, new Size(1150, 600));
                    bt.Save(filePath, ImageFormat.Gif);
                    gr.Dispose();
                    bt.Dispose();
                }
                else ErrorLabel.Text = "No name was chosen.";
            }
            else ErrorLabel.Text = "No file was chosen.";
        }
    }
}