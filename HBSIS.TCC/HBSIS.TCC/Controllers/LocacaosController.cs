﻿using System;
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
    public class LocacaosController : ApiController
    {
        private ContextDB db = new ContextDB();

        // GET: api/Locacaos
        public IQueryable<Locacao> Getlocacoes()
        {
            return db.locacoes.Where(x => x.Ativo == true);
        }

        // GET: api/Locacaos/5
        [ResponseType(typeof(Locacao))]
        public async Task<IHttpActionResult> GetLocacao(int id)
        {
            Locacao locacao = await db.locacoes.FindAsync(id);
            if (locacao == null)
            {
                return NotFound();
            }

            return Ok(locacao);
        }

        // PUT: api/Locacaos/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutLocacao(int id, Locacao locacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != locacao.Codigo)
            {
                return BadRequest();
            }

            db.Entry(locacao).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocacaoExists(id))
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

        // POST: api/Locacaos
        [ResponseType(typeof(Locacao))]
        public async Task<IHttpActionResult> PostLocacao(Locacao locacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (locacao.AceiteTermoDeUso == false)
            {
                return BadRequest("Para realizar a locação, você deve aceitar os termos de uso.");
            }

            var verificadorPlaca = db.locacoes.Select(x => x.Placa).ToList();

            foreach (var item in verificadorPlaca)
            {
                if (item == locacao.Placa)
                {
                    return BadRequest("Placa já está cadastrada no sistema.");
                }

                db.locacoes.Add(locacao);
                await db.SaveChangesAsync();
            }

            
            return CreatedAtRoute("DefaultApi", new { id = locacao.Codigo }, locacao);
        }

        // DELETE: api/Locacaos/5
        [ResponseType(typeof(Locacao))]
        public async Task<IHttpActionResult> DeleteLocacao(int id)
        {
            Locacao locacao = await db.locacoes.FindAsync(id);
            if (locacao == null)
            {
                return NotFound();
            }

            db.locacoes.Remove(locacao);
            await db.SaveChangesAsync();

            return Ok(locacao);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LocacaoExists(int id)
        {
            return db.locacoes.Count(e => e.Codigo == id) > 0;
        }
    }
}