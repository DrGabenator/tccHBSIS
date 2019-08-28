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
    public class TermoDeUsoesController : ApiController
    {
        private ContextDB db = new ContextDB();

        // GET: api/TermoDeUsoes
        public IQueryable<TermoDeUso> GetTermoDeUsoes()
        {
            return db.TermoDeUsoes;
        }

        // GET: api/TermoDeUsoes/5
        [ResponseType(typeof(TermoDeUso))]
        public async Task<IHttpActionResult> GetTermoDeUso(int id)
        {
            TermoDeUso termoDeUso = await db.TermoDeUsoes.FindAsync(id);
            if (termoDeUso == null)
            {
                return NotFound();
            }

            return Ok(termoDeUso);
        }

        // PUT: api/TermoDeUsoes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTermoDeUso(int id, TermoDeUso termoDeUso)
        {
            if (termoDeUso.usuario.Gestor == true)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id != termoDeUso.Codigo)
                {
                    return BadRequest();
                }

                db.Entry(termoDeUso).State = EntityState.Modified;

                try
                {
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TermoDeUsoExists(id))
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
            else
            {
                var respostaErro = ("É necessário ser um gestor para adicionar um Termo de Uso.");

                return BadRequest(respostaErro);
            }
        }

        // POST: api/TermoDeUsoes
        [ResponseType(typeof(TermoDeUso))]
        public async Task<IHttpActionResult> PostTermoDeUso(TermoDeUso termoDeUso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TermoDeUsoes.Add(termoDeUso);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = termoDeUso.Codigo }, termoDeUso);
        }

        // DELETE: api/TermoDeUsoes/5
        [ResponseType(typeof(TermoDeUso))]
        public async Task<IHttpActionResult> DeleteTermoDeUso(int id)
        {
            TermoDeUso termoDeUso = await db.TermoDeUsoes.FindAsync(id);
            if (termoDeUso == null)
            {
                return NotFound();
            }

            db.TermoDeUsoes.Remove(termoDeUso);
            await db.SaveChangesAsync();

            return Ok(termoDeUso);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TermoDeUsoExists(int id)
        {
            return db.TermoDeUsoes.Count(e => e.Codigo == id) > 0;
        }
    }
}