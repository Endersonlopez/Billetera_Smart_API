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
               
        #region ListarEstados

        public List<CE_ClsEstados> ListarEstados (CE_ClsEstados obj)
        {
            List<CE_ClsEstados> lts_Estados = new List<CE_ClsEstados>();
            cmd.Connection = _conexion.AbrirConexion();
            cmd.CommandText = "SP_Estados";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Accion", SqlDbType.Int).Value = 3;
            da.SelectCommand = cmd;
            try
            {
                da.Fill(tabla);
                if (tabla.Rows.Count < 0)
                {
                    foreach (DataRow dr in tabla.Rows)
                    {
                        CE_ClsEstados fila = new CE_ClsEstados();
                        fila.Id_Estado = dr["Id_Estado"] is DBNull ? 0 : Convert.ToInt32(dr["Id_Producto"]);
                        fila.Estado = dr["Estado"] is DBNull ? string.Empty : Convert.ToString(dr["Estado"]);
                        fila.Fecha_Creacion = dr["Fecha_Creacion"] is DBNull ? DateTime.MinValue : Convert.ToDateTime(dr["Fecha_Creacion"]);
                        fila.Fecha_Modificacion = dr["Fecha_Modificacion"] is DBNull ? DateTime.MinValue : Convert.ToDateTime(dr["Fecha_Modificacion"]);
                        fila.Activo = dr["Activo"] is DBNull ? 0 : Convert.ToInt32(dr["Activo"]);
                        lts_Estados.Add(fila);
                    }
                }
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

            return lts_Estados;
        }

        #endregion ListarEstados

    }
}
