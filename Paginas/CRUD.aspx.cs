using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PCRUD.Paginas
{
    public partial class CRUD : System.Web.UI.Page
    {
        //Crear cadena de conexión
        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        
        public static string sID = "-1";
        public static string sOpc = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            //obtener el id
            if (!Page.IsPostBack)
            {
                //validar petición
                if (Request.QueryString["id"] != null)
                {
                    sID = Request.QueryString["id"].ToString();
                    CargarDatos();
                    tbdate.TextMode = TextBoxMode.DateTime;
                }

                //validar opción
                if (Request.QueryString["op"] != null)
                {
                    sOpc = Request.QueryString["op"].ToString();

                    switch (sOpc)
                    {
                        case "C":
                            this.lbltitulo.Text = "Ingresar nuevo usuario";
                            this.BtnCreate.Visible = true;
                            break;
                        case "R":
                            this.lbltitulo.Text = "Consulta de usuario";
                            break;
                        case "U":
                            this.lbltitulo.Text = "Modificar usuario";
                            this.BtnUpdate.Visible = true;
                            break;
                        case "D":
                            this.lbltitulo.Text = "Eliminar usuario";
                            this.BtnDelete.Visible = true;
                            break;
                    }
                }
            }
        }

        //Mostrar datos
        void CargarDatos()
        {
            //Abrir conexión
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("sp_read", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            //Envio param Id
            da.SelectCommand.Parameters.Add("@Id", SqlDbType.Int).Value = sID;
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            //Crear tabla
            DataTable dt = ds.Tables[0];
            //Carga de elementos
            DataRow row = dt.Rows[0];
            tbnombre.Text = row[1].ToString();
            tbedad.Text = row[2].ToString();
            tbemail.Text = row[3].ToString();
            DateTime d = (DateTime)row[4];
            tbdate.Text = d.ToString("dd/MM/yyyy");
            //Cierra conexión
            con.Close();
        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_create", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = tbnombre.Text;
            cmd.Parameters.Add("@Edad", SqlDbType.Int).Value = tbedad.Text;
            cmd.Parameters.Add("@Correo", SqlDbType.VarChar).Value = tbemail.Text;
            cmd.Parameters.Add("@Fecha", SqlDbType.Date).Value = tbdate.Text;
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("Inicio.aspx");
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_update", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = sID;
            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = tbnombre.Text;
            cmd.Parameters.Add("@Edad", SqlDbType.Int).Value = tbedad.Text;
            cmd.Parameters.Add("@Correo", SqlDbType.VarChar).Value = tbemail.Text;
            cmd.Parameters.Add("@Fecha", SqlDbType.Date).Value = tbdate.Text;
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("Inicio.aspx");
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_delete", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = sID;
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("Inicio.aspx");
        }

        protected void BtnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inicio.aspx");
        }
    }
}