using System;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace WebValid
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string conn = WebConfigurationManager.ConnectionStrings["dbConn"].ConnectionString;

            // Hash da palavra-passe introduzida (igual ao usado no registo)
            string hash;
            using (var md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] bytes = md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(txtPass.Text));
                hash = BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }

            using (SqlConnection c = new SqlConnection(conn))
            {
                c.Open();
                string sql = "SELECT COUNT(*) FROM Utilizadores WHERE Utilizador=@u AND PalavraPasse=@p";
                SqlCommand cmd = new SqlCommand(sql, c);
                cmd.Parameters.AddWithValue("@u", txtUser.Text.Trim());
                cmd.Parameters.AddWithValue("@p", hash);
                int ok = (int)cmd.ExecuteScalar();

                if (ok > 0)
                {
                    Session["user"] = txtUser.Text.Trim();
                    Response.Redirect("app.aspx");
                }
                else
                {
                    lblMsg.Text = "Utilizador ou palavra-passe incorretos.";
                }
            }
        }
    }
}