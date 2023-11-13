using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Context;
using Biblioteca.Models;

namespace Biblioteca.Operaciones
{
    public class AutorDAO
    {
        //Creamos un obj de contexto de BD
        public LibreriaContext contexto = new LibreriaContext();

        //2.Metodo para seleccionar todos los autores 
        public List<Autor> seleccionarTodos()
        {
            var autores = contexto.Autors.ToList<Autor>();
            return autores;
        }
        //3.Metodo para consultar un autor por id
        public Autor seleccionar(int id)
        {
            var autor = contexto.Autors.Where(a => a.Id == id).FirstOrDefault();
            return autor;
        }

        //1.Metodo para agregar nuevo autor
        public bool agregar(int id, string name)
        {
            try
            {
                Autor autor = new Autor();
                autor.Id = id;
                autor.Name = name;

                contexto.Autors.Add(autor);
                contexto.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
