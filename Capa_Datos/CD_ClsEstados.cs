using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Capa_Entidad;

namespace Capa_Datos
{
    public class CD_ClsEstados
    {
        private readonly CD_Conexion _conexion;
        DataTable tabla = new DataTable();
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();

        public CD_ClsEstados(IConfiguration configuration)
        {
            _conexion = new CD_Conexion(configuration);
        }

        #region InsertarEstados
        public void InsertarEstados(CE_ClsEstados obj)
        {
            cmd.Connection = _conexion.AbrirConexion();
            cmd.CommandText = "SP_Estados";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Accion", SqlDbType.Int, 1).Value = "Crear";
            cmd.Parameters.Add("Id_Estado", SqlDbType.Int).Value = obj.Id_Estado;
            cmd.Parameters.Add("Estado", SqlDbType.VarChar, 80).Value = obj.Estado;
            cmd.Parameters.Add("Activo", SqlDbType.Bit).Value = obj.Activo;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            { 
                string msg = ex.Message;
            }
            finally
            {
                cmd.Parameters.Clear();
                cmd.Connection = _conexion.CerrarConexion();
            }
        }

        #endregion InsertarEstados

        #region ActualizarEstados
        public void ActualizarEstados(CE_ClsEstados obj)
        {
            cmd.Connection = _conexion.AbrirConexion();
            cmd.CommandText = "SP_Estados";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Accion", SqlDbType.Int, 2).Value = "Actualizar";
            cmd.Parameters.Add("Id_Estado", SqlDbType.Int).Value = obj.Id_Estado;
            cmd.Parameters.Add("Estado", SqlDbType.VarChar, 80).Value = obj.Estado;
            cmd.Parameters.Add("Activo", SqlDbType.Bit).Value = obj.Activo;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            finally
            {
                cmd.Parameters.Clear();
                cmd.Connection = _conexion.CerrarConexion();
            }
        }

        #endregion ActualizarEstados

        #region LeerEstados
        public void LeerEstados(CE_ClsEstados obj)
        {
            cmd.Connection = _conexion.AbrirConexion();
            cmd.CommandText = "SP_Estados";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Accion", SqlDbType.Int, 3).Value = "Leer";
            cmd.Parameters.Add("Id_Estado", SqlDbType.Int).Value = obj.Id_Estado;
            cmd.Parameters.Add("Estado", SqlDbType.VarChar, 80).Value = obj.Estado;
            cmd.Parameters.Add("Activo", SqlDbType.Bit).Value = obj.Activo;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            finally
            {
                cmd.Parameters.Clear();
                cmd.Connection = _conexion.CerrarConexion();
            }
        }

        #endregion LeerEstados
    }
}
