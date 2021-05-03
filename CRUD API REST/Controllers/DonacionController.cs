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
using CRUD_API_REST.Models;

namespace CRUD_API_REST.Controllers
{
    public class DonacionController : ApiController
    {
        private ModelDonaciones db = new ModelDonaciones();

        // GET: api/Donacion
        public IQueryable<Donacion> GetDonacion()
        {
            return db.Donacion;
        }

        // GET: api/Donacion/5
        [ResponseType(typeof(Donacion))]
        public IHttpActionResult GetDonacion(int id)
        {
            Donacion donacion = db.Donacion.Find(id);
            if (donacion == null)
            {
                return NotFound();
            }

            return Ok(donacion);
        }

        // PUT: api/Donacion/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDonacion(int id, Donacion donacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != donacion.id)
            {
                return BadRequest();
            }

            db.Entry(donacion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DonacionExists(id))
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

        // POST: api/Donacion
        [ResponseType(typeof(Donacion))]
        public IHttpActionResult PostDonacion(Donacion donacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Donacion.Add(donacion);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = donacion.id }, donacion);
        }

        // DELETE: api/Donacion/5
        [ResponseType(typeof(Donacion))]
        public IHttpActionResult DeleteDonacion(int id)
        {
            Donacion donacion = db.Donacion.Find(id);
            if (donacion == null)
            {
                return NotFound();
            }

            db.Donacion.Remove(donacion);
            db.SaveChanges();

            return Ok(donacion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DonacionExists(int id)
        {
            return db.Donacion.Count(e => e.id == id) > 0;
        }
    }
}