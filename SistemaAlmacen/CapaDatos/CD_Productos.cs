using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using System.Data;

namespace CapaDatos
{
    public class CD_Productos
    {
        private CD_Conexion conexion = new CD_Conexion();
        MySqlDataReader leer;
        DataTable tabla = new DataTable();
        MySqlCommand comando = new MySqlCommand();

        public DataTable ObteneCategoriProductos()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "Mostrar_Categorias";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

        public void Update_Categorias(int IdCatProd, string NombreCatProd)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "Update_Categorias";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("_IdCatProd", IdCatProd);
            comando.Parameters.AddWithValue("_NombreCatProd", NombreCatProd);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }

        public void Insert_Categorias(string NombreCatProd)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "Insert_Categorias";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("_NombreCatProd", NombreCatProd);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }

        public DataTable MostrarProductos()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "Mostrar_Productos";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }
        public DataTable ObteneDescripcionCategoria()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "Mostrar_Categorias_Descripcion";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }
        public void Update_Productos(int CodProd, string NombreCatProd, string DescripcionProd, string MarcaProd, double PrecioProd, int StockProd)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "Update_Productos";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("_CodProd", CodProd);
            comando.Parameters.AddWithValue("_NombreCatProd", NombreCatProd);
            comando.Parameters.AddWithValue("_DescripcionProd", DescripcionProd);
            comando.Parameters.AddWithValue("_MarcaProd", MarcaProd);
            comando.Parameters.AddWithValue("_PrecioProd", PrecioProd);
            comando.Parameters.AddWithValue("_StockProd", StockProd);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }

        public void Insert_Productos(string NombreCatProd, string DescripcionProd, string MarcaProd, double PrecioProd, int StockProd)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "Insert_Productos";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("_NombreCatProd", NombreCatProd);
            comando.Parameters.AddWithValue("_DescripcionProd", DescripcionProd);
            comando.Parameters.AddWithValue("_MarcaProd", MarcaProd);
            comando.Parameters.AddWithValue("_PrecioProd", PrecioProd);
            comando.Parameters.AddWithValue("_StockProd", StockProd);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }
    }
}
