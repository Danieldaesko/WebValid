using System;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Web.Configuration;

namespace WebValid
{
    public partial class recuperar : System.Web.UI.Page
    {
        string conn => WebConfigurationManager.ConnectionStrings["dbConn"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnRecuperar_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();

            using (SqlConnection c = new SqlConnection(conn))
            {
                c.Open();

                // Verificar se email existe
                SqlCommand cmdChk = new SqlCommand(
                    "SELECT COUNT(*) FROM Utilizadores WHERE Email=@e", c);
                cmdChk.Parameters.AddWithValue("@e", email);
                int existe = (int)cmdChk.ExecuteScalar();

                if (existe == 0)
                {
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = "O email introduzido não está registado no sistema.";
                    return;
                }

                // Gerar nova palavra-passe aleatória
                string novaPass = Guid.NewGuid().ToString("N").Substring(0, 8);

                // Hash da nova palavra-passe
                string hash;
                using (var md5 = System.Security.Cryptography.MD5.Create())
                {
                    byte[] bytes = md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(novaPass));
                    hash = BitConverter.ToString(bytes).Replace("-", "").ToLower();
                }

                // Atualizar na base de dados
                SqlCommand cmdUpd = new SqlCommand(
                    "UPDATE Utilizadores SET PalavraPasse=@p WHERE Email=@e", c);
                cmdUpd.Parameters.AddWithValue("@p", hash);
                cmdUpd.Parameters.AddWithValue("@e", email);
                cmdUpd.ExecuteNonQuery();

                // Enviar email
                try
                {
                    MailMessage msg = new MailMessage();
                    msg.To.Add(email);
                    msg.Subject = "Recuperação de Palavra-Passe";
                    msg.Body = "A sua nova palavra-passe é: " + novaPass +
                               "\n\nPor favor altere-a após o login.";
                    SmtpClient smtp = new SmtpClient();
                    smtp.Send(msg);

                    lblMsg.ForeColor = System.Drawing.Color.Green;
                    lblMsg.Text = "Nova palavra-passe enviada para o seu email!";
                }
                catch
                {
                    lblMsg.ForeColor = System.Drawing.Color.Orange;
                    lblMsg.Text = "Palavra-passe atualizada mas erro ao enviar email.";
                }
            }
        }
    }
}

