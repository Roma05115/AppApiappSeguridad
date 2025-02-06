using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppNotificaciones.Models;

namespace AppNotificaciones.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly AlertasBd1Context _context;

        public PostsController(AlertasBd1Context context)
        {
            _context = context;
        }

        // GET: api/Platos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contacto>>> GetContacto()
        {
            return await _context.Contactos
                .Select(p => new Contacto
                {
                    IdContacto = p.IdContacto,
                    Nombre = p.Nombre,
                    Numero = p.Numero,
                    Descripcion = p.Descripcion,
                    Imagen = $"http://AlertasApp.somee.com/Imagenes/{p.Imagen}"
                })
                .ToListAsync();
        }

        // GET: api/Platos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contacto>> GetPlato(int id)
        {
            var contacto = await _context.Contactos.FindAsync(id);

            if (contacto == null)
            {
                return NotFound();
            }

            var ContactoDto = new Contacto
            {
                IdContacto = contacto.IdContacto,
                Nombre = contacto.Nombre,
                Numero = contacto.Numero,
                Descripcion = contacto.Descripcion,
                Imagen = $"http://AlertasApp.somee.com/Imagenes/{contacto.Imagen}"
            };

            return ContactoDto;
        }

        // PUT: api/Posts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPost(int id, Post post)
        {
            if (id != post.IdPost)
            {
                return BadRequest();
            }

            _context.Entry(post).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Posts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Post>> PostPost(Post post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPost", new { id = post.IdPost }, post);
        }

        // DELETE: api/Posts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PostExists(int id)
        {
            return _context.Posts.Any(e => e.IdPost == id);
        }
    }
}
