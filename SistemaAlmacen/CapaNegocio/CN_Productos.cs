using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDatos;

namespace CapaNegocio
{
     public class CN_Productos
    {
        private CD_Productos productos = new CD_Productos();

        public DataTable ObteneCategoriProductos()
        {
            DataTable tabla = new DataTable();
            tabla = productos.ObteneCategoriProductos();            
            return tabla;
        }
        public void Update_Categorias(string IdCatProd, string NombreCatProd)
        {
            productos.Update_Categorias(Convert.ToInt32(IdCatProd), NombreCatProd);
        }
        public void Insert_Categorias(string NombreCatProd)
        {
            productos.Insert_Categorias(NombreCatProd.ToUpper());            
        }
        public DataTable MostrarProductos()
        {
            DataTable tabla = new DataTable();
            tabla = productos.MostrarProductos();
            return tabla;
        }
        public DataTable ObteneDescripcionCategoria()
        {
            DataTable tabla = new DataTable();
            tabla = productos.ObteneDescripcionCategoria();
            return tabla;
        }
        public void Update_Productos(string CodProd, string NombreCatProd, string DescripcionProd, string MarcaProd,string PrecioProd, string StockProd)
        {
            productos.Update_Productos(Convert.ToInt32(CodProd), NombreCatProd, DescripcionProd, MarcaProd, Convert.ToDouble(PrecioProd.Replace(".", ",")), Convert.ToInt32(StockProd));
        }
        public void Insert_Productos(string NombreCatProd, string DescripcionProd, string MarcaProd, string PrecioProd, string StockProd)
        {
            productos.Insert_Productos(NombreCatProd, DescripcionProd, MarcaProd, Convert.ToDouble(PrecioProd.Replace(".", ",")), Convert.ToInt32(StockProd));
        }

        public DataTable Read_Productos_Buscar()
        {
            DataTable tabla = new DataTable();
            tabla = productos.Read_Productos_Buscar();
            return tabla;
        }
    }
}
