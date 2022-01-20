using Comun;
using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
     public class CategoriaNegocio
    {
        //Listar
        public List<Categoria> ListarCategoria(bool estado)
        {
            return CategoriaData.ListarCategoria(estado);
        }
        
        //Actualizar
        public int ActualizarCategoria(Categoria objCat)
        {
            return CategoriaData.ActualizarCategoria(objCat);
        }

        //Registrar
        public int RegistrarCategoria(Categoria objCat)
        {
            return CategoriaData.RegistrarCategoria(objCat);
        }

        //Eliminar
        public int EliminarActivarCategoria(Categoria objCat)
        {
            return CategoriaData.EliminarActivarCategoria(objCat);
        }
    }
}