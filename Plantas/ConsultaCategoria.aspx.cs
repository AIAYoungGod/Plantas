using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace ProyectoPlantas
{
    public partial class ConsultaCategoria : System.Web.UI.Page
    {
        string conexion = "Data Source=DESKTOP-JJES9PC\\SQLEXPRESS;Initial Catalog=Plantas;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCategorias();
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
                ddlCategoria.Items.Insert(0, new ListItem("Seleccione una categoría", "0"));
            }
        }

        protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            int categoriaId = int.Parse(ddlCategoria.SelectedValue);

            using (SqlConnection conn = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand(@"
                    SELECT 
                        p.NombrePlanta,
                        p.Descripcion,
                        c.NombreCategoria
                    FROM Plantas p
                    INNER JOIN Categorias c ON p.CategoriaId = c.Id
                    WHERE p.CategoriaId = @CategoriaId", conn);

                cmd.Parameters.AddWithValue("@CategoriaId", categoriaId);
                conn.Open();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvPlantas.DataSource = dt;
                gvPlantas.DataBind();
            }
        }
    }
}
