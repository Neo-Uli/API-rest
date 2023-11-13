using Biblioteca.Models;
using Biblioteca.Operaciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private AutorDAO autorDAO = new AutorDAO();

        /**
         * EndPoint para obtener todos los autores
         */
        [HttpGet("autor")]

        public Autor getAutor(int id)
        {
            return autorDAO.seleccionar(id);
        }

        /**
         * EndPoint para obtener autor por ID
         */
        [HttpGet("autores")]
        public List<Autor> getAutores()
        {
            return autorDAO.seleccionarTodos(); 
        }

        /**
          * EndPoint para agregar nuevo libro
          */
        [HttpPost("autor")]
        public bool insertar([FromBody] Autor autor)
        {
            return autorDAO.agregar(autor.Id, autor.Name);
        }
    }
}
