using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Capa_Datos
{
    public class CD_Conexion
    {
        private readonly string _ConexionString;
        private SqlConnection _Connection;

        public CD_Conexion(IConfiguration configuration)
        {
            _ConexionString = configuration.GetConnectionString("CnxSql");
            _Connection = new SqlConnection(_ConexionString);
        }

        public SqlConnection AbrirConexion()
        {
            if (_Connection.State == ConnectionState.Closed)
                _Connection.Open();
            return _Connection;
        }

        public SqlConnection CerrarConexion()
        {
            if (_Connection.State == ConnectionState.Open)
                _Connection.Close();
            return _Connection;
        }
    }
}
