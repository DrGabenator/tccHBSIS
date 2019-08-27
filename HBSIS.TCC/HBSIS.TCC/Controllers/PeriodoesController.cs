using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using HBSIS.TCC.Models;

namespace HBSIS.TCC.Controllers
{
    public class PeriodoesController : ApiController
    {
        private ContextDB db = new ContextDB();

        // GET: api/Periodoes
        public IQueryable<Periodo> Getperiodos()
        {
            return db.periodos.Where(x => x.Ativo == true);
        }

        // GET: api/Periodoes/5
        [ResponseType(typeof(Periodo))]
        public async Task<IHttpActionResult> GetPeriodo(int id)
        {
            Periodo periodo = await db.periodos.FindAsync(id);
            if (periodo == null)
            {
                return NotFound();
            }

            return Ok(periodo);
        }

        // PUT: api/Periodoes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPeriodo(int id, Periodo periodo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != periodo.Codigo)
            {
                return BadRequest();
            }

            db.Entry(periodo).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PeriodoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Periodoes
        [ResponseType(typeof(Periodo))]
        public async Task<IHttpActionResult> PostPeriodo(Periodo periodo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.periodos.Add(periodo);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = periodo.Codigo }, periodo);
        }

        // DELETE: api/Periodoes/5
        [ResponseType(typeof(Periodo))]
        public async Task<IHttpActionResult> DeletePeriodo(int id)
        {
            Periodo periodo = await db.periodos.FindAsync(id);
            if (periodo == null)
            {
                return NotFound();
            }

            db.periodos.Remove(periodo);
            await db.SaveChangesAsync();

            return Ok(periodo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PeriodoExists(int id)
        {
            return db.periodos.Count(e => e.Codigo == id) > 0;
        }
    }
}