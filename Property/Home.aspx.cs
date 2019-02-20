using Property_cls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Property
{
    public partial class Home : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (Request.Cookies["UserEmail"] != null)
            {
                Response.Cookies["UserEmail"].Expires = DateTime.Now.AddDays(-1);
                HttpContext.Current.Session["MySession"] = 0;
            }
          //  Response.Cookies["UserEmail"].Expires = DateTime.Now.AddDays(-1);
            //Session.Abandon();
            if (!IsPostBack)
            {
              int   userCount = Convert.ToInt32(HttpContext.Current.Session["MySession"]);

                if (userCount ==0 && Request.Cookies["UserEmail"] == null)
                {
                    //btnModal_Clicked(sender, e);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                }
               
            }

        }

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static String[] GetAutoCompleteData(string prefixText, int count, string contextKey)
        {
            List<String> itemNames = new List<String>();
            Property1.MLSDataWebServiceSoapClient ml = new Property1.MLSDataWebServiceSoapClient();
            DataTable dt = ml.GetAutoCompleteData(prefixText);
            foreach
                (DataRow dr in dt.Rows)
            {
                String item = dr["Province"].ToString();
                itemNames.Add(item);
            }
            string[] prefixTextArray = itemNames.ToArray();
            return prefixTextArray;
        }
    }
}