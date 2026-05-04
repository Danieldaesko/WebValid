using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI.WebControls;

namespace WebValid
{
    public partial class gestao_utilizadores : System.Web.UI.Page
    {
        string conn => WebConfigurationManager.ConnectionStrings["dbConn"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
                Response.Redirect("login.aspx");

            if (!IsPostBack)
                BindGrid();
        }

        void BindGrid()
        {
            using (SqlConnection c = new SqlConnection(conn))
            {
                c.Open();
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT Id, Utilizador, Email FROM Utilizadores", c);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvUsers.DataSource = dt;
                gvUsers.DataBind();
            }
        }

        protected void gvUsers_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvUsers.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        protected void gvUsers_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvUsers.EditIndex = -1;
            BindGrid();
        }

        protected void gvUsers_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = (int)gvUsers.DataKeys[e.RowIndex].Value;
            string u = ((TextBox)gvUsers.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
            string em = ((TextBox)gvUsers.Rows[e.RowIndex].Cells[2].Controls[0]).Text;

            using (SqlConnection c = new SqlConnection(conn))
            {
                c.Open();
                SqlCommand cmd = new SqlCommand(
                    "UPDATE Utilizadores SET Utilizador=@u, Email=@e WHERE Id=@id", c);
                cmd.Parameters.AddWithValue("@u", u);
                cmd.Parameters.AddWithValue("@e", em);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            gvUsers.EditIndex = -1;
            BindGrid();
        }

        protected void gvUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = (int)gvUsers.DataKeys[e.RowIndex].Value;

            using (SqlConnection c = new SqlConnection(conn))
            {
                c.Open();
                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM Utilizadores WHERE Id=@id", c);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            BindGrid();
        }
    }
}