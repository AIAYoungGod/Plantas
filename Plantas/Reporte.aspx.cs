using System;
using System.Data;
using System.Data.SqlClient;

namespace ProyectoPlantas
{
    public partial class Reporte : System.Web.UI.Page
    {
        string conexion = "Data Source=DESKTOP-JJES9PC\\SQLEXPRESS;Initial Catalog=Plantas;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarReporte();
            }
        }

        private void CargarReporte()
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                string consulta = @"
                    SELECT 
                        c.NombreCategoria, 
                        COUNT(p.Id) AS CantidadPlantas
                    FROM Categorias c
                    LEFT JOIN Plantas p ON c.Id = p.CategoriaId
                    GROUP BY c.NombreCategoria";

                SqlCommand cmd = new SqlCommand(consulta, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvReporte.DataSource = dt;
                gvReporte.DataBind();
            }
        }
    }
}
