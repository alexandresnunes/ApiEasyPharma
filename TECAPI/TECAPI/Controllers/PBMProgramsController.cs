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
    public class PBMProgramsController : ApiController
    {
        private easypharmadbEntities db = new easypharmadbEntities();

        // GET: api/PBMPrograms
        public IQueryable<PBMPrograms> GetPBMPrograms()
        {
            return db.PBMPrograms;
        }

        // GET: api/PBMPrograms/5
        [ResponseType(typeof(PBMPrograms))]
        public IHttpActionResult GetPBMPrograms(int id)
        {
            PBMPrograms pBMPrograms = db.PBMPrograms.Find(id);
            if (pBMPrograms == null)
            {
                return NotFound();
            }

            return Ok(pBMPrograms);
        }

        // PUT: api/PBMPrograms/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPBMPrograms(int id, PBMPrograms pBMPrograms)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pBMPrograms.Id)
            {
                return BadRequest();
            }

            db.Entry(pBMPrograms).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PBMProgramsExists(id))
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

        // POST: api/PBMPrograms
        [ResponseType(typeof(PBMPrograms))]
        public IHttpActionResult PostPBMPrograms(PBMPrograms pBMPrograms)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PBMPrograms.Add(pBMPrograms);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pBMPrograms.Id }, pBMPrograms);
        }

        // DELETE: api/PBMPrograms/5
        [ResponseType(typeof(PBMPrograms))]
        public IHttpActionResult DeletePBMPrograms(int id)
        {
            PBMPrograms pBMPrograms = db.PBMPrograms.Find(id);
            if (pBMPrograms == null)
            {
                return NotFound();
            }

            db.PBMPrograms.Remove(pBMPrograms);
            db.SaveChanges();

            return Ok(pBMPrograms);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PBMProgramsExists(int id)
        {
            return db.PBMPrograms.Count(e => e.Id == id) > 0;
        }
    }
}