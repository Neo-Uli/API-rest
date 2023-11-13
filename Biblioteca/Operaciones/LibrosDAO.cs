using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Context;
using Biblioteca.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;

namespace Biblioteca.Operaciones
{
    public class LibrosDAO
    {
        //Creamos un obj de contexto de BD
        public LibreriaContext contexto = new LibreriaContext();

        //2.Metodo para seleccionar todos los libros 
        public List<Libro> seleccionarTodos()
        {
            var libros = contexto.Libros.ToList<Libro>();
            return libros;
        }
        //3.Metodo para consultar un libro por id
        public Libro seleccionar(int id)
        {
            var libro = contexto.Libros.Where(a => a.Id == id).FirstOrDefault();
            return libro;
        }

        //1.Metodo para agregar nuevo libro
        public bool agregar(int id, string title, int chapters, int pages, int price, int authorid)
        {
            try
            {
                Libro libro = new Libro();
                libro.Id = id;
                libro.Title = title;
                libro.Chapters = chapters;
                libro.Pages = pages;
                libro.Price = price;
                libro.AuthorId = authorid;

                contexto.Libros.Add(libro);
                contexto.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        //4. Metodo para obtener libro con su autor

        public List<LibroAutor> ObtenerLibrosConAutor()
        {
            var query = from libro in contexto.Libros
                        join autor in contexto.Autors on libro.AuthorId equals autor.Id
                        select new LibroAutor
                        {
                            Title = libro.Title,
                            Chapters = libro.Chapters,
                            Pages = libro.Pages,
                            Price = libro.Price,
                            AuthorName = autor.Name
                        };
            return query.ToList();
        }









    }
}
