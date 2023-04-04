namespace courses_shop.Server.Datos
{
    public class AccessoDatos
    {
        private string cadenaConexinSql;

        public string CadenaConexionSQL { get => cadenaConexinSql; }

        public AccessoDatos(string cadenaConexinSql)
        {
            cadenaConexinSql = cadenaConexinSql;
        }
    }
}
