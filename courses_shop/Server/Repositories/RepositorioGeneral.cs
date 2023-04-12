using courses_shop.Server.Datos;
using courses_shop.Shared.Modelos;
using System.Data;
using System.Data.SqlClient;

namespace courses_shop.Server.Repositories
{
    public class RepositorioGeneral : IRepositorioGeneral
    {
        private string CadenaConexion;

        public RepositorioGeneral(AccessoDatos cadenaConexion)
        {
            this.CadenaConexion = cadenaConexion.CadenaConexionSQL;
        }

        private SqlConnection conexion()
        {
            return new SqlConnection(CadenaConexion);
        }

        public async Task<Usuario> GuardarCursos(Usuario _usuario)
        {
            Console.WriteLine("_usuario.Email");
            Console.WriteLine(_usuario.Email);
            SqlConnection sqlConnection = conexion();
            SqlCommand Comm = null;
            SqlDataReader reader = null;
            SqlTransaction transaccion = null;
            try
            {
                sqlConnection.Open();

                Comm = sqlConnection.CreateCommand();
                transaccion = sqlConnection.BeginTransaction();
                Comm.CommandText = "dbo.CursosUsuarioInscribir";
                Comm.CommandType = CommandType.StoredProcedure;
                Comm.Transaction = transaccion;
                foreach (Curso curso in _usuario.ListaCursos)
                {
                    Comm.Parameters.Clear();
                    Comm.Parameters.Add("@idCurso", SqlDbType.Int).Value = curso.Id;
                    Comm.Parameters.Add("@emailUsuario", SqlDbType.VarChar, 500).Value =
                        _usuario.Email;
                    await Comm.ExecuteNonQueryAsync();
                }
                transaccion.Commit();
            }
            catch (Exception e)
            {
                if (transaccion != null)
                {
                    transaccion.Rollback();
                }
                throw new Exception(e.ToString());
            }
            finally
            {
                Comm.Dispose();
                sqlConnection.Close();
                sqlConnection.Dispose();
            }

            return _usuario;
        }

        public async Task<Usuario> AltaUsuario(Usuario _user)
        {
            SqlConnection sqlConexion = conexion();
            SqlCommand Comm = null;
            try
            {
                sqlConexion.Open();
                Comm = sqlConexion.CreateCommand();
                Comm.CommandText = "dbo.AltaUsuario";
                Comm.CommandType = CommandType.StoredProcedure;
                Comm.Parameters.Add("@nombre", SqlDbType.VarChar, 500).Value = _user.Nombre;
                Comm.Parameters.Add("@apellidos", SqlDbType.VarChar, 500).Value = _user.Apellido;
                Comm.Parameters.Add("@email", SqlDbType.VarChar, 500).Value = _user.Email;
                Comm.Parameters.Add("@password", SqlDbType.VarChar, 500).Value = _user.Password;

                await Comm.ExecuteNonQueryAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
            finally
            {
                Comm.Dispose();
                sqlConexion.Close();
                sqlConexion.Dispose();
            }

            return _user;
        }

        public async Task<UsuarioLogin> ValidarUsuario(string Email)
        {
            UsuarioLogin usuario = null;
            SqlConnection sqlCoenxion = conexion();
            SqlCommand comm = null;
            try
            {
                sqlCoenxion.Open();
                comm = sqlCoenxion.CreateCommand();
                comm.CommandText = "dbo.DameUsuario";
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add("@email", SqlDbType.VarChar, 500).Value = Email;

                SqlDataReader reader = await comm.ExecuteReaderAsync();
                if (reader.Read())
                {
                    usuario = new UsuarioLogin();
                    usuario.Id = Convert.ToInt32(reader["Id"].ToString());
                    usuario.EmailLogin = reader["Email"].ToString();
                    usuario.Password = reader["Password"].ToString();
                }
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally {
                comm.Dispose();
                sqlCoenxion.Close();
                sqlCoenxion.Dispose();
             }
            return usuario;
        }
    }
}
