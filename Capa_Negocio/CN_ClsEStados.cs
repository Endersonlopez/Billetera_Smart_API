using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Capa_Entidad;

namespace Capa_Negocio
{
    public class CN_ClsEStados
    {
        private readonly CD_ClsEstados _CD_ClsEstados;
        public CN_ClsEStados(IConfiguration configuration) 
        {
            _CD_ClsEstados = new CD_ClsEstados(configuration);
        }

        public void CN_Insertar_Estados(CE_ClsEstados obj)
        {
            _CD_ClsEstados.InsertarEstados(obj);
        }

        public void CN_Actualizar_Estados(CE_ClsEstados obj)
        {
            _CD_ClsEstados.ActualizarEstados(obj);
        }

        public List<CE_ClsEstados> CN_Listar_Estados(CE_ClsEstados obj)
        {
            return _CD_ClsEstados.ListarEstados(obj);
        }
    }
}
