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
using TECAPI.Models;

namespace TECAPI.Controllers
{
    public class LaboratoriesController : ApiController
    {
        private easypharmadbEntities db = new easypharmadbEntities();

        // GET: api/Laboratories
        public IQueryable<Laboratories> GetLaboratories()
        {
            return db.Laboratories;
        }

        // GET: api/Laboratories/5
        [ResponseType(typeof(Laboratories))]
        public IHttpActionResult GetLaboratories(int id)
        {
            Laboratories laboratories = db.Laboratories.Find(id);
            if (laboratories == null)
            {
                return NotFound();
            }

            return Ok(laboratories);
        }

        // PUT: api/Laboratories/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLaboratories(int id, Laboratories laboratories)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != laboratories.Id)
            {
                return BadRequest();
            }

            db.Entry(laboratories).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LaboratoriesExists(id))
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

        // POST: api/Laboratories
        [ResponseType(typeof(Laboratories))]
        public IHttpActionResult PostLaboratories(Laboratories laboratories)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Laboratories.Add(laboratories);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = laboratories.Id }, laboratories);
        }

        // DELETE: api/Laboratories/5
        [ResponseType(typeof(Laboratories))]
        public IHttpActionResult DeleteLaboratories(int id)
        {
            Laboratories laboratories = db.Laboratories.Find(id);
            if (laboratories == null)
            {
                return NotFound();
            }

            db.Laboratories.Remove(laboratories);
            db.SaveChanges();

            return Ok(laboratories);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LaboratoriesExists(int id)
        {
            return db.Laboratories.Count(e => e.Id == id) > 0;
        }
    }
}