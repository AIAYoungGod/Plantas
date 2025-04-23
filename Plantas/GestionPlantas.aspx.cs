
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoPlantas
{
    public partial class GestionPlantas : Page
    {
        string conexion = "Data Source=DESKTOP-JJES9PC\\SQLEXPRESS;Initial Catalog=Plantas;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCategorias();
                CargarPlantas();
            }
        }

        private void CargarCategorias()
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("SELECT Id, NombreCategoria FROM Categorias", conn);
                conn.Open();
                ddlCategoria.DataSource = cmd.ExecuteReader();
                ddlCategoria.DataTextField = "NombreCategoria";
                ddlCategoria.DataValueField = "Id";
                ddlCategoria.DataBind();
            }
        }

        private void CargarPlantas()
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand(@"
            SELECT 
                p.Id,
                p.NombrePlanta,
                p.Descripcion,
                c.NombreCategoria
            FROM Plantas p
            INNER JOIN Categorias c ON p.CategoriaId = c.Id", conn);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvPlantas.DataSource = dt;
                gvPlantas.DataBind();
            }
        }



        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Plantas (NombrePlanta, Descripcion, CategoriaId) VALUES (@Nombre, @Descripcion, @CategoriaId)", conn);
                cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@Descripcion", txtDescripcion.Text);
                cmd.Parameters.AddWithValue("@CategoriaId", ddlCategoria.SelectedValue);
                conn.Open();
                cmd.ExecuteNonQuery();
                lblMensaje.Text = "✅ Planta agregada correctamente.";
                CargarPlantas();
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(hfId.Value))
            {
                lblMensaje.Text = "🖉 (Falta ID para modificar).";
                return;
            }
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("UPDATE Plantas SET NombrePlanta=@Nombre, Descripcion=@Descripcion, CategoriaId=@CategoriaId WHERE Id=@Id", conn);
                cmd.Parameters.AddWithValue("@Id", hfId.Value);
                cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@Descripcion", txtDescripcion.Text);
                cmd.Parameters.AddWithValue("@CategoriaId", ddlCategoria.SelectedValue);
                conn.Open();
                cmd.ExecuteNonQuery();
                lblMensaje.Text = "🖉 Planta modificada correctamente.";
                CargarPlantas();
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(hfId.Value))
            {
                lblMensaje.Text = "🗑️ (Falta ID para eliminar).";
                return;
            }
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Plantas WHERE Id=@Id", conn);
                cmd.Parameters.AddWithValue("@Id", hfId.Value);
                conn.Open();
                cmd.ExecuteNonQuery();
                lblMensaje.Text = "🗑️ Planta eliminada correctamente.";
                CargarPlantas();
            }
        }

        protected void gvPlantas_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvPlantas.SelectedRow;
            hfId.Value = row.Cells[1].Text;
            txtNombre.Text = row.Cells[2].Text;
            txtDescripcion.Text = row.Cells[3].Text;
        }
    }
}
