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
    public class RegistroVeiculoesController : ApiController
    {
        private ContextDB db = new ContextDB();

        // GET: api/RegistroVeiculoes
        public IQueryable<RegistroVeiculo> GetregistroVeiculos()
        {
            return db.registroVeiculos.Where(x => x.Ativo == true);
        }

        // GET: api/RegistroVeiculoes/5
        [ResponseType(typeof(RegistroVeiculo))]
        public async Task<IHttpActionResult> GetRegistroVeiculo(int id)
        {
            RegistroVeiculo registroVeiculo = await db.registroVeiculos.FindAsync(id);
            if (registroVeiculo == null)
            {
                return NotFound();
            }

            return Ok(registroVeiculo);
        }

        // PUT: api/RegistroVeiculoes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRegistroVeiculo(int id, RegistroVeiculo registroVeiculo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != registroVeiculo.Codigo)
            {
                return BadRequest();
            }

            db.Entry(registroVeiculo).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegistroVeiculoExists(id))
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

        // POST: api/RegistroVeiculoes
        [ResponseType(typeof(RegistroVeiculo))]
        public async Task<IHttpActionResult> PostRegistroVeiculo(RegistroVeiculo registroVeiculo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.registroVeiculos.Add(registroVeiculo);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = registroVeiculo.Codigo }, registroVeiculo);
        }

        // DELETE: api/RegistroVeiculoes/5
        [ResponseType(typeof(RegistroVeiculo))]
        public async Task<IHttpActionResult> DeleteRegistroVeiculo(int id)
        {
            RegistroVeiculo registroVeiculo = await db.registroVeiculos.FindAsync(id);
            if (registroVeiculo == null)
            {
                return NotFound();
            }

            db.registroVeiculos.Remove(registroVeiculo);
            await db.SaveChangesAsync();

            return Ok(registroVeiculo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RegistroVeiculoExists(int id)
        {
            return db.registroVeiculos.Count(e => e.Codigo == id) > 0;
        }
    }
}