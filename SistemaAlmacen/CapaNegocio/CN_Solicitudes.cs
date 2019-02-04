using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_Solicitudes
    {
        CD_Solicitudes solicitudes = new CD_Solicitudes();

        public List<string> Btn_Solicitudes_Ultimo()
        {
            List<string> datos = new List<string>();
            datos = solicitudes.Btn_Solicitudes_Ultimo();
            return datos;
        }
        public List<string> Btn_Solicitudes_Primero()
        {
            List<string> datos = new List<string>();
            datos = solicitudes.Btn_Solicitudes_Primero();
            return datos;
        }
        public List<string> Btn_PU_Anterior(string CodSolicitud)
        {
            List<string> datos = new List<string>();
            datos = solicitudes.Btn_Solicitudes_Anterior(Convert.ToInt32(CodSolicitud));
            return datos;
        }
        public List<string> Btn_Solicitudes_Siguiente(string CodSolicitud)
        {
            List<string> datos = new List<string>();
            datos = solicitudes.Btn_Solicitudes_Siguiente(Convert.ToInt32(CodSolicitud));
            return datos;
        }
        public DataTable Read_Solicitud_Detalle(string CodSolicitud)
        {
            DataTable tabla = new DataTable();
            tabla = solicitudes.Read_Solicitud_Detalle(Convert.ToInt32(CodSolicitud));
            return tabla;
        }
    }
}
