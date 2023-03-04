using L01_2020PM608_BLOG.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace L01_2020PM608_BLOG.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class comentariosController : ControllerBase {
        private readonly blogContext _blogContexto;

        public comentariosController(blogContext comentariosContexto) {
            _blogContexto = comentariosContexto;
        }

        //CREATE 
        [HttpPost]
        [Route("add")]
        public IActionResult Crear([FromBody] comentarios comentarioNuevo) {

            try {
                _blogContexto.comentarios.Add(comentarioNuevo);
                _blogContexto.SaveChanges();

                return Ok(comentarioNuevo);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);

            }
        }
        //READ
        [HttpGet]
        [Route("getall")]
        public IActionResult ObtenerComentarios() {
            List<comentarios> listadoComentarios = (from db in _blogContexto.comentarios
                                                        select db).ToList();

            if (listadoComentarios.Count == 0) { return NotFound(); }

            return Ok(listadoComentarios);
        }
        //UPDATE
        [HttpPut]
        [Route("actualizar/{id}")]
        public IActionResult actualizarComentarios(int id, [FromBody] comentarios comentariosModificar) {
            comentarios? comentariosExiste = (from e in _blogContexto.comentarios
                                                 where e.cometarioId == id
                                                 select e).FirstOrDefault();
            if (comentariosExiste == null)
                return NotFound();

            comentariosExiste.publicacionId= comentariosModificar.publicacionId;
            comentariosExiste.comentario = comentariosModificar.comentario;
            comentariosExiste.usuarioId = comentariosModificar.usuarioId;

            _blogContexto.Entry(comentariosExiste).State = EntityState.Modified;
            _blogContexto.SaveChanges();

            return Ok(comentariosExiste);
        }
        //DELETE
        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult eliminarComentario(int id) {
            comentarios? comentarioExiste = (from e in _blogContexto.comentarios
                                                where e.cometarioId == id
                                                select e).FirstOrDefault();
            if (comentarioExiste == null)
                return NotFound();

            _blogContexto.Remove(comentarioExiste);
            _blogContexto.SaveChanges();

            return Ok(comentarioExiste);
        }

        //Método filtrado por una publicacion especifica
        [HttpGet]
        [Route("findbyuser/{publicacionid}")]
        public IActionResult buscar(int publicacionid) {

            List<comentarios> comentariosList = (from e in _blogContexto.comentarios
                                                     where e.publicacionId.Equals(publicacionid)
                                                     select e).ToList();

            if (comentariosList.Any()) {
                return Ok(comentariosList);
            }
            return NotFound();
        }
        

    }
}
