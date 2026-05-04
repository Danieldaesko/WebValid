using System;
using System.Data.SqlClient;
using System.Security.Policy;
using System.Web.Configuration;
using System.Web.Security;

namespace WebValid
{
    public partial class registo_utilizador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        

        protected void btnRegistar_Click(object sender, EventArgs e)
        {
            string conn = WebConfigurationManager.ConnectionStrings["dbConn"].ConnectionString;

            using (SqlConnection c = new SqlConnection(conn))
            {
                c.Open();

                // Verificar se utilizador ou email já existem
                string chk = "SELECT COUNT(*) FROM Utilizadores WHERE Utilizador=@u OR Email=@e";
                SqlCommand cmdChk = new SqlCommand(chk, c);
                cmdChk.Parameters.AddWithValue("@u", txtUser.Text.Trim());
                cmdChk.Parameters.AddWithValue("@e", txtEmail.Text.Trim());
                int existe = (int)cmdChk.ExecuteScalar();

                if (existe > 0)
                {
                    lblMsg.Text = "Utilizador ou email já existem!";
                    return;
                }

                string hash;
                using (var md5 = System.Security.Cryptography.MD5.Create())
                {
                    byte[] bytes = md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(txtPass.Text));
                    hash = BitConverter.ToString(bytes).Replace("-", "").ToLower();
                }

                // Inserir na base de dados
                string ins = "INSERT INTO Utilizadores(Utilizador,PalavraPasse,Email) VALUES(@u,@p,@e)";
                SqlCommand cmdIns = new SqlCommand(ins, c);
                cmdIns.Parameters.AddWithValue("@u", txtUser.Text.Trim());
                cmdIns.Parameters.AddWithValue("@p", hash);
                cmdIns.Parameters.AddWithValue("@e", txtEmail.Text.Trim());
                cmdIns.ExecuteNonQuery();

                Response.Redirect("login.aspx");
            }
        }
    }
}