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
    public class PBMProgramMedicinesController : ApiController
    {
        private easypharmadbEntities db = new easypharmadbEntities();

        // GET: api/PBMProgramMedicines
        public IQueryable<PBMProgramMedicines> GetPBMProgramMedicines()
        {
            return db.PBMProgramMedicines;
        }

        // GET: api/PBMProgramMedicines/5
        [ResponseType(typeof(PBMProgramMedicines))]
        public IHttpActionResult GetPBMProgramMedicines(int id)
        {
            PBMProgramMedicines pBMProgramMedicines = db.PBMProgramMedicines.Find(id);
            if (pBMProgramMedicines == null)
            {
                return NotFound();
            }

            return Ok(pBMProgramMedicines);
        }

        // PUT: api/PBMProgramMedicines/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPBMProgramMedicines(int id, PBMProgramMedicines pBMProgramMedicines)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pBMProgramMedicines.Id)
            {
                return BadRequest();
            }

            db.Entry(pBMProgramMedicines).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PBMProgramMedicinesExists(id))
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

        // POST: api/PBMProgramMedicines
        [ResponseType(typeof(PBMProgramMedicines))]
        public IHttpActionResult PostPBMProgramMedicines(PBMProgramMedicines pBMProgramMedicines)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PBMProgramMedicines.Add(pBMProgramMedicines);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pBMProgramMedicines.Id }, pBMProgramMedicines);
        }

        // DELETE: api/PBMProgramMedicines/5
        [ResponseType(typeof(PBMProgramMedicines))]
        public IHttpActionResult DeletePBMProgramMedicines(int id)
        {
            PBMProgramMedicines pBMProgramMedicines = db.PBMProgramMedicines.Find(id);
            if (pBMProgramMedicines == null)
            {
                return NotFound();
            }

            db.PBMProgramMedicines.Remove(pBMProgramMedicines);
            db.SaveChanges();

            return Ok(pBMProgramMedicines);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PBMProgramMedicinesExists(int id)
        {
            return db.PBMProgramMedicines.Count(e => e.Id == id) > 0;
        }
    }
}