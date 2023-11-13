using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Biblioteca.Operaciones;
using Biblioteca.Models;
using System.Security.Cryptography.Xml;

namespace WebApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        private LibrosDAO librosDAO = new LibrosDAO();

        /**
         * EndPoint para obtener todos los libros
         */
        [HttpGet("libro")]

        public Libro getLibro(int id)
        {
            return librosDAO.seleccionar(id);
        }

        /**
         * EndPoint para obtener libro por ID
         */
        [HttpGet("libros")]
        public List<Libro> getLibros()
        {
            return librosDAO.seleccionarTodos();
        }


        [HttpGet("librosAutor")]
        public List<LibroAutor> getLibrosA()
        {
            return librosDAO.ObtenerLibrosConAutor();
        }



        /**
          * EndPoint para agregar nuevo libro
          */
        [HttpPost("libros")]
        public bool insertar([FromBody] Libro libro)
        {
            return librosDAO.agregar(libro.Id, libro.Title, libro.Chapters, libro.Pages, libro.Price, libro.AuthorId);
        }
    }
}
