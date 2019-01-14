using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Actividad3.Models;

namespace Actividad3.Controllers
{
    public class medicamentoesController : ApiController
    {
        private Modelo db = new Modelo();

        // GET: api/medicamentoes
        public IQueryable<medicamento> Getmedicamento()
        {
            return db.medicamento;
        }

        // GET: api/medicamentoes/5
        [ResponseType(typeof(medicamento))]
        public IHttpActionResult Getmedicamento(int id)
        {
            medicamento medicamento = db.medicamento.Find(id);
            if (medicamento == null)
            {
                return NotFound();
            }

            return Ok(medicamento);
        }

        // PUT: api/medicamentoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putmedicamento(int id, medicamento medicamento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != medicamento.id)
            {
                return BadRequest();
            }

            db.Entry(medicamento).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!medicamentoExists(id))
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

        // POST: api/medicamentoes
        [ResponseType(typeof(medicamento))]
        public IHttpActionResult Postmedicamento(medicamento medicamento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.medicamento.Add(medicamento);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = medicamento.id }, medicamento);
        }

        // DELETE: api/medicamentoes/5
        [ResponseType(typeof(medicamento))]
        public IHttpActionResult Deletemedicamento(int id)
        {
            medicamento medicamento = db.medicamento.Find(id);
            if (medicamento == null)
            {
                return NotFound();
            }

            db.medicamento.Remove(medicamento);
            db.SaveChanges();

            return Ok(medicamento);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool medicamentoExists(int id)
        {
            return db.medicamento.Count(e => e.id == id) > 0;
        }
    }
}