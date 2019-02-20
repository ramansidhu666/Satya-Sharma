using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Property_cls;
using System.Xml.Linq;


namespace Property
{
    public class GoogleDistanceDuration
    {
        public double StartLatitude { get; set; }
        public double StartLongitude { get; set; }
        public double EndLongitude { get; set; }
        public double EndLatitude { get; set; }
        public string StartAddress { get; set; }
        public string EndAddress { get; set; }
        public int Duration { get; set; }
        public decimal Distance { get; set; }
        public string Language { get; set; }
    }
    public partial class Search : System.Web.UI.Page
    {
        #region Global

        cls_Property clsobj = new cls_Property();

        int findex, lindex;
        public int CurrentPage
        {
            get
            {
                if (ViewState["CurrentPage"] != null)
                {
                    return Convert.ToInt32(ViewState["CurrentPage"]);
                }
                else
                {
                    return 0;
                }
            }
            set { ViewState["CurrentPage"] = value; }
        }

        #endregion Global

        #region PageLoad

        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["Municipality"] = Request.QueryString["Municipality"];
            //Session["QueryString"] = Request.QueryString["PropertyType"];
            //if (Session["SearchType"] == "Residential" || Convert.ToString(Session["QueryString"]) == "Residential")
            //    SearchResidentialProperties();
            //else if (Session["SearchType"] == "Commercial" || Convert.ToString(Session["QueryString"]) == "Commercial")
            //    SearchCommercialProperties();
            //else if (Session["SearchType"] == "Condo" || Convert.ToString(Session["QueryString"]) == "Condo")
            //    SearchCondoProperties();
            //else
            //{

            //}
        }
        #endregion PageLoad
      

        //public static GoogleDistanceDuration GetDirectionByAddress(GoogleDistanceDuration googleDistanceDuration)
        //{
        //    string requesturl = "http://maps.googleapis.com/maps/api/directions/json?origin=" + googleDistanceDuration.StartAddress + "&destination=" + googleDistanceDuration.EndAddress + "&sensor=false&language=" + googleDistanceDuration.Language;
        //    string content = FileGetContents(requesturl);
        //    JObject json = JObject.Parse(content);
        //    try
        //    {
        //        googleDistanceDuration.Distance = (json.SelectToken("routes[0].legs[0].distance.value") != null ? (int)json.SelectToken("routes[0].legs[0].distance.value") : 0);
        //        googleDistanceDuration.Duration = (json.SelectToken("routes[0].legs[1].duration.value") != null ? (int)json.SelectToken("routes[0].legs[1].duration.value") : 0);

        //        googleDistanceDuration.StartLatitude = (json.SelectToken("routes[0].legs[0].start_location.lat") != null ? (double)json.SelectToken("routes[0].legs[0].start_location.lat") : 0);
        //        googleDistanceDuration.StartLongitude = (json.SelectToken("routes[0].legs[0].start_location.lng") != null ? (double)json.SelectToken("routes[0].legs[0].start_location.lng") : 0);

        //        googleDistanceDuration.EndLatitude = (json.SelectToken("routes[0].legs[0].end_location.lat") != null ? (int)json.SelectToken("routes[0].legs[0].end_location.lat") : 0);
        //        googleDistanceDuration.EndLongitude = (json.SelectToken("routes[0].legs[0].end_location.lng") != null ? (int)json.SelectToken("routes[0].legs[0].end_location.lng") : 0);

        //        return googleDistanceDuration;
        //    }
        //    catch
        //    {
        //        return googleDistanceDuration;
        //    }
        //}
        //public static string FileGetContents(string fileName)
        //{
        //    string sContents = string.Empty;
        //    string me = string.Empty;
        //    try
        //    {
        //        if (fileName.ToLower().IndexOf("http:") > -1)
        //        {
        //            System.Net.WebClient wc = new System.Net.WebClient();
        //            byte[] response = wc.DownloadData(fileName);
        //            sContents = System.Text.Encoding.ASCII.GetString(response);

        //        }
        //        else
        //        {
        //            System.IO.StreamReader sr = new System.IO.StreamReader(fileName);
        //            sContents = sr.ReadToEnd();
        //            sr.Close();
        //        }
        //    }
        //    catch { sContents = "unable to connect to server "; }
        //    return sContents;
        //}

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static String[] GetAutoCompleteData(string prefixText, int count, string contextKey)
        {
            List<String> itemNames = new List<String>();
            Property1.MLSDataWebServiceSoapClient ml = new Property1.MLSDataWebServiceSoapClient();
            DataTable dt = ml.GetAutoCompleteData(prefixText);
            foreach (DataRow dr in dt.Rows)
            {
                String item = dr["Province"].ToString();

                itemNames.Add(item);
            }
            string[] prefixTextArray = itemNames.ToArray();
            return prefixTextArray;
        }

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static String[] GetAutoCompleteData_Comm(string prefixText, int count, string contextKey)
        {
            List<String> itemNames = new List<String>();
            Property1.MLSDataWebServiceSoapClient ml = new Property1.MLSDataWebServiceSoapClient();
            DataTable dt = ml.GetAutoCompleteData_Comm(prefixText);
            foreach (DataRow dr in dt.Rows)
            {
                String item = dr["Province"].ToString();

                itemNames.Add(item);
            }
            string[] prefixTextArray = itemNames.ToArray();
            return prefixTextArray;
        }

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static String[] GetAutoCompleteData_Condo(string prefixText, int count, string contextKey)
        {
            List<String> itemNames = new List<String>();
            Property1.MLSDataWebServiceSoapClient ml = new Property1.MLSDataWebServiceSoapClient();
            DataTable dt = ml.GetAutoCompleteData_Condo(prefixText);
            foreach (DataRow dr in dt.Rows)
            {
                String item = dr["Province"].ToString();

                itemNames.Add(item);
            }
            string[] prefixTextArray = itemNames.ToArray();
            return prefixTextArray;
        }

        #region Pagination Repeater Events

        #endregion Pagination Repeater Events

        


    }

}

