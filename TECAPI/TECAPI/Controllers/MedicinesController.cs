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
    public class MedicinesController : ApiController
    {
        private easypharmadbEntities db = new easypharmadbEntities();

        // GET: api/Medicines
        public IQueryable<Medicines> GetMedicines()
        {
            return db.Medicines;
        }

        // GET: api/Medicines/5
        [ResponseType(typeof(Medicines))]
        public IHttpActionResult GetMedicines(int id)
        {
            Medicines medicines = db.Medicines.Find(id);
            if (medicines == null)
            {
                return NotFound();
            }

            return Ok(medicines);
        }

        // PUT: api/Medicines/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMedicines(int id, Medicines medicines)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != medicines.Id)
            {
                return BadRequest();
            }

            db.Entry(medicines).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicinesExists(id))
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

        // POST: api/Medicines
        [ResponseType(typeof(Medicines))]
        public IHttpActionResult PostMedicines(Medicines medicines)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Medicines.Add(medicines);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = medicines.Id }, medicines);
        }

        // DELETE: api/Medicines/5
        [ResponseType(typeof(Medicines))]
        public IHttpActionResult DeleteMedicines(int id)
        {
            Medicines medicines = db.Medicines.Find(id);
            if (medicines == null)
            {
                return NotFound();
            }

            db.Medicines.Remove(medicines);
            db.SaveChanges();

            return Ok(medicines);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MedicinesExists(int id)
        {
            return db.Medicines.Count(e => e.Id == id) > 0;
        }
    }
}