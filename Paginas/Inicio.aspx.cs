using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PCRUD.Paginas
{
    public partial class Inicio : System.Web.UI.Page
    {
        //Crear cadena de conexión
        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            //Mostrar los registros de la tabla
            CargarTabla();
        }

        void CargarTabla()
        {
            //Proc de la bd que muestre registros
            SqlCommand cmd = new SqlCommand("sp_load", con);
            cmd.CommandType = CommandType.StoredProcedure;
            //Abrir conexión
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            //Llena la tabla
            da.Fill(dt);
            //Muestra la tb en griView
            gvpersonas.DataSource = dt;
            //Enlaza datos
            gvpersonas.DataBind();
            //Cierra conexión
            con.Close();
        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/CRUD.aspx?op=C");
        }

        protected void BtnRead_Click(object sender, EventArgs e)
        {
            string id;
            Button BtnConsultar = (Button)sender;
            GridViewRow selectedrow = (GridViewRow)BtnConsultar.NamingContainer;
            id = selectedrow.Cells[1].Text;
            Response.Redirect("~/Paginas/CRUD.aspx?id=" + id + "&op=R");
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            string id;
            Button BtnConsultar = (Button)sender;
            GridViewRow selectedrow = (GridViewRow)BtnConsultar.NamingContainer;
            id = selectedrow.Cells[1].Text;
            Response.Redirect("~/Paginas/CRUD.aspx?id=" + id + "&op=U");
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            string id;
            Button BtnConsultar = (Button)sender;
            GridViewRow selectedrow = (GridViewRow)BtnConsultar.NamingContainer;
            id = selectedrow.Cells[1].Text;
            Response.Redirect("~/Paginas/CRUD.aspx?id=" + id + "&op=D");
        }
    }
}