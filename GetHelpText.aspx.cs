using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ajax_page_load_aspx_54
{
    public partial class GetHelpText : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string helpTextKey = Request["HelpTextKey"];
            divResult.InnerText = GetHelpTextByKey(helpTextKey);
        }
        private string GetHelpTextByKey(string key)
        {
            string helpText = string.Empty;

            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetHelpTextByKey", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter parameter = new SqlParameter("@HelpTextKey", key);
                cmd.Parameters.Add(parameter);
                con.Open();
                helpText = cmd.ExecuteScalar().ToString();
            }

            return helpText;
        }
    }
}
