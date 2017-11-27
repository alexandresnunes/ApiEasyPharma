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
    public class TherapeuticClassesController : ApiController
    {
        private easypharmadbEntities db = new easypharmadbEntities();

        // GET: api/TherapeuticClasses
        public IQueryable<TherapeuticClasses> GetTherapeuticClasses()
        {
            return db.TherapeuticClasses;
        }

        // GET: api/TherapeuticClasses/5
        [ResponseType(typeof(TherapeuticClasses))]
        public IHttpActionResult GetTherapeuticClasses(int id)
        {
            TherapeuticClasses therapeuticClasses = db.TherapeuticClasses.Find(id);
            if (therapeuticClasses == null)
            {
                return NotFound();
            }

            return Ok(therapeuticClasses);
        }

        // PUT: api/TherapeuticClasses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTherapeuticClasses(int id, TherapeuticClasses therapeuticClasses)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != therapeuticClasses.Id)
            {
                return BadRequest();
            }

            db.Entry(therapeuticClasses).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TherapeuticClassesExists(id))
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

        // POST: api/TherapeuticClasses
        [ResponseType(typeof(TherapeuticClasses))]
        public IHttpActionResult PostTherapeuticClasses(TherapeuticClasses therapeuticClasses)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TherapeuticClasses.Add(therapeuticClasses);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = therapeuticClasses.Id }, therapeuticClasses);
        }

        // DELETE: api/TherapeuticClasses/5
        [ResponseType(typeof(TherapeuticClasses))]
        public IHttpActionResult DeleteTherapeuticClasses(int id)
        {
            TherapeuticClasses therapeuticClasses = db.TherapeuticClasses.Find(id);
            if (therapeuticClasses == null)
            {
                return NotFound();
            }

            db.TherapeuticClasses.Remove(therapeuticClasses);
            db.SaveChanges();

            return Ok(therapeuticClasses);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TherapeuticClassesExists(int id)
        {
            return db.TherapeuticClasses.Count(e => e.Id == id) > 0;
        }
    }
}