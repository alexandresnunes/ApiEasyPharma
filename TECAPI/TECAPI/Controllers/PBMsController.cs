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
    public class PBMsController : ApiController
    {
        private easypharmadbEntities db = new easypharmadbEntities();

        // GET: api/PBMs
        public IQueryable<PBMs> GetPBMs()
        {
            return db.PBMs;
        }

        // GET: api/PBMs/5
        [ResponseType(typeof(PBMs))]
        public IHttpActionResult GetPBMs(int id)
        {
            PBMs pBMs = db.PBMs.Find(id);
            if (pBMs == null)
            {
                return NotFound();
            }

            return Ok(pBMs);
        }

        // PUT: api/PBMs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPBMs(int id, PBMs pBMs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pBMs.Id)
            {
                return BadRequest();
            }

            db.Entry(pBMs).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PBMsExists(id))
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

        // POST: api/PBMs
        [ResponseType(typeof(PBMs))]
        public IHttpActionResult PostPBMs(PBMs pBMs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PBMs.Add(pBMs);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pBMs.Id }, pBMs);
        }

        // DELETE: api/PBMs/5
        [ResponseType(typeof(PBMs))]
        public IHttpActionResult DeletePBMs(int id)
        {
            PBMs pBMs = db.PBMs.Find(id);
            if (pBMs == null)
            {
                return NotFound();
            }

            db.PBMs.Remove(pBMs);
            db.SaveChanges();

            return Ok(pBMs);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PBMsExists(int id)
        {
            return db.PBMs.Count(e => e.Id == id) > 0;
        }
    }
}