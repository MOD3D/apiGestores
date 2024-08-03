using apiGestores.Context;
using apiGestores.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apiGestores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GestoresController : ControllerBase
    {
        private readonly AppDbContext context;

        public GestoresController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/gestores
        [HttpGet]
        public ActionResult<IEnumerable<Gestores_Bd>> Get()
        {
            try
            {
                return Ok(context.GESTORES_BD.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/gestores/5
        [HttpGet("{id}", Name = "GetGestor")]
        public ActionResult<Gestores_Bd> Get(int id)
        {
            try
            {
                var gestor = context.GESTORES_BD.FirstOrDefault(g => g.id == id);
                if (gestor == null)
                {
                    return NotFound();
                }
                return Ok(gestor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/gestores
        [HttpPost]
        public ActionResult<Gestores_Bd> Post([FromBody] Gestores_Bd gestor)
        {
            try
            {
                context.GESTORES_BD.Add(gestor);
                context.SaveChanges();
                return CreatedAtRoute("GetGestor", new { id = gestor.id }, gestor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/gestores/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Gestores_Bd gestor)
        {
            try
            {
                if (gestor.id == id)
                {
                    context.Entry(gestor).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetGestor", new { id = gestor.id }, gestor);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/gestores/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var gestor = context.GESTORES_BD.FirstOrDefault(g => g.id == id);
                if (gestor != null)
                {
                    context.GESTORES_BD.Remove(gestor);
                    context.SaveChanges();
                    return Ok(id);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
