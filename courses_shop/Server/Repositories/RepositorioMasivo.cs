using courses_shop.Server.Datos;
using courses_shop.Shared;
using courses_shop.Shared.Modelos;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace courses_shop.Server.Repositories
{
    public class RepositorioMasivo : IRepositorioMasivo
    {
        private string CadenaConexion;

        public RepositorioMasivo(AccessoDatos cadenaConexion)
        {
            this.CadenaConexion = cadenaConexion.CadenaConexionSQL;
        }

        private SqlConnection conexion()
        {
            return new SqlConnection(CadenaConexion);
        }

        public async Task<IEnumerable<Curso>> PrimerVolcadoDatos()
        {
            List<Curso> listaCursos = new List<Curso>();
            Curso curso = null;
            SqlConnection sqlConnection = conexion();
            SqlCommand Comm = null;
            SqlDataReader reader = null;
            try
            {
                sqlConnection.Open();

                Comm = sqlConnection.CreateCommand();
                Comm.CommandText = "dbo.CargaIncialDatos";
                Comm.CommandType = CommandType.StoredProcedure;
                reader = await Comm.ExecuteReaderAsync();
                while (reader.Read())
                {
                    curso = new Curso();
                    curso.Id = Convert.ToInt32(reader["id"]);
                    curso.NombreCurso = reader["Nombre"].ToString();
                    //Console.WriteLine(reader["RutaImagen"].ToString()   );
                    curso.RutaImagen = reader["RutaImagen"].ToString();
                    curso.Descripcion = reader["Descripcion"].ToString();
                     curso.Programa = reader["Programa"].ToString();
                    curso.FechaAlta = Convert.ToDateTime(reader["FechaAlta"].ToString());
                    listaCursos.Add(curso);
                }
            }
            finally
            {
                Comm.Dispose();
                sqlConnection.Close();
                sqlConnection.Dispose();
            }

            return listaCursos;
        }

        public async Task<IEnumerable<Curso>> DameCursos()
        {
            List<Curso> listaCursos = new List<Curso>();
            Curso curso = null;
            SqlConnection sqlConnection = conexion();
            SqlCommand Comm = null;
            SqlDataReader reader = null;
            try
            {
                sqlConnection.Open();

                Comm = sqlConnection.CreateCommand();
                Comm.CommandText = "dbo.DameCursos";
                Comm.CommandType = CommandType.StoredProcedure;
                reader = await Comm.ExecuteReaderAsync();
                while (reader.Read())
                {
                    curso = new Curso();
                    curso.Id = Convert.ToInt32(reader["idCurso"]);
                    curso.NombreCurso = reader["Nombre"].ToString();
                    curso.Descripcion = reader["Descripcion"].ToString();
                     curso.Programa = reader["Programa"].ToString();
                    curso.RutaImagen = reader["RutaImagen"].ToString();
                    if (
                        reader["PrecioVenta"] != null && Convert.ToDouble(reader["PrecioVenta"]) > 0
                    )
                    {
                        curso.Precio = new Precio();
                        curso.Precio.PrecioVenta = Convert.ToDouble(reader["PrecioVenta"]);
                        curso.Precio.Id = Convert.ToInt32(reader["IdPrecio"]);
                    }
                    listaCursos.Add(curso);
                }
            }
            finally
            {
                Comm.Dispose();
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            return listaCursos;
        }
    }
}
