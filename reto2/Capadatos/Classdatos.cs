using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Capaentidad;

namespace Capadatos
{
    public class Classdatos
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);
        public DataTable d_listar_libros()
        {
            SqlCommand cmd = new SqlCommand("sp_listar_libros", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable d_buscar_libros(Classentidad obje)
        {
            SqlCommand cmd = new SqlCommand("sp_buscar_libros", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@titulo", obje.nombre);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public String d_insertar_libros(Classentidad obje)
        {
            String accion = "";
            SqlCommand cmd = new SqlCommand("sp_insertar_libros", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@codigo", obje.code);
            cmd.Parameters.AddWithValue("@titulo", obje.nombre);
            cmd.Parameters.AddWithValue("@autor", obje.autor);
            cmd.Parameters.AddWithValue("@editorial", obje.editor);
            cmd.Parameters.AddWithValue("@precio", obje.price);
            cmd.Parameters.AddWithValue("@cantidad", obje.cant);
            cmd.Parameters.Add("@accion", SqlDbType.VarChar,50).Value=obje.accion;
            cmd.Parameters["@accion"].Direction = ParameterDirection.InputOutput;
            if (cn.State == ConnectionState.Open) cn.Close();
            cn.Open();
            cmd.ExecuteNonQuery();
            accion = cmd.Parameters["@accion"].Value.ToString();
            cn.Close();
            return accion ;


        }

    }
}
