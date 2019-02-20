using Property_cls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Property
{
    public partial class landing_master : System.Web.UI.MasterPage
    {
        #region Global

        cls_Property clsobj = new cls_Property();

        #endregion Global
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SiteSetting();
                SetValuesMetatags();
            }


        }


        private void SetValuesMetatags()
        {
            ProprtyDes.Content = "";
            siteTitle.Text = "";
            var PageTitle = Convert.ToString(Request.QueryString["PageTitle"]);
            if (PageTitle == "LandingPage")
            {
                
                fbProprtyImage.Content = "https://www.sharmarealtor.ca/Images/canada.jpg";
                fbProprtyTitle.Content = "Find Your Dream Home.";
                fbProprtyUrl.Content = "https://www.sharmarealtor.ca/landing_page.aspx?PageTitle=LandingPage";
                fbProprtyShareType.Content = "Property";

                ProprtyDes.Content = "Get know what your neighbors are selling at sharmarealtor.ca. We offer the complete information for real estate properties for sale. ";
                siteTitle.Text = "Get Know What Your Neighbours Are Selling - sharmarealtor.ca";
            }
            else if (PageTitle == "HomeWorth")
            {
               
                fbProprtyImage.Content = "https://www.sharmarealtor.ca/Images/canada.jpg";
                fbProprtyTitle.Content = "What Is your House Really Worth ?";
                fbProprtyUrl.Content = "https://www.sharmarealtor.ca/Home_Worth.aspx?PageTitle=HomeWorth";
                fbProprtyShareType.Content = "Property";

                ProprtyDes.Content = "Read latest and unique information about selling your house, renovating for resale and common selling mistakes. Selling your home is one of the most important decisions you will make in your life. Visit our website today!";
                siteTitle.Text = "Get Your Home Market Value Estimate Online - sharmarealtor.ca";
            }

        }
        protected void SiteSetting()
        {
            try
            {
                DataTable dt = clsobj.GetSiteSettings();
                DataTable dt1 = clsobj.GetUserInfo();
                if (dt.Rows.Count > 0)
                {
                    siteTitle.Text = Convert.ToString(dt.Rows[0]["Title"]);
                    byte[] favimage = (byte[])dt.Rows[0]["Favicon.ico"];
                    if (favimage.Length > 0)
                    {
                        Session["MyFavicon"] = favimage;
                        favicon.Visible = true;
                        favicon.Href = "~/ShowFavicon.aspx";
                    }
                    else
                    {
                        favicon.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}