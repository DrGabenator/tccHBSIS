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
    public class ModeloesController : ApiController
    {
        private ContextDB db = new ContextDB();

        //[Route("Api/Modelos/Marcas")]
        //[HttpGet]
        //public IQueryable<Marca> Getmodelosmarcas()
        //{
        //    return db.modelos.Where(x => x.Marca == Marca.Codigo);
        //}
       

        // GET: api/Modeloes
        public IQueryable<Modelo> Getmodelos()
        {
            return db.modelos.Where(x => x.Ativo == true);
        }

        // GET: api/Modeloes/5
        [ResponseType(typeof(Modelo))]
        public async Task<IHttpActionResult> GetModelo(int id)
        {
            Modelo modelo = await db.modelos.FindAsync(id);
            if (modelo == null)
            {
                return NotFound();
            }

            return Ok(modelo);
        }

        // PUT: api/Modeloes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutModelo(int id, Modelo modelo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != modelo.Codigo)
            {
                return BadRequest();
            }

            db.Entry(modelo).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModeloExists(id))
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

        // POST: api/Modeloes
        [ResponseType(typeof(Modelo))]
        public async Task<IHttpActionResult> PostModelo(Modelo modelo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.modelos.Add(modelo);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = modelo.Codigo }, modelo);
        }

        // DELETE: api/Modeloes/5
        [ResponseType(typeof(Modelo))]
        public async Task<IHttpActionResult> DeleteModelo(int id)
        {
            Modelo modelo = await db.modelos.FindAsync(id);
            if (modelo == null)
            {
                return NotFound();
            }

            db.modelos.Remove(modelo);
            await db.SaveChangesAsync();

            return Ok(modelo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ModeloExists(int id)
        {
            return db.modelos.Count(e => e.Codigo == id) > 0;
        }
    }
}