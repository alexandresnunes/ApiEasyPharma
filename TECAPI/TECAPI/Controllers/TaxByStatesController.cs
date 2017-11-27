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
    public class TaxByStatesController : ApiController
    {
        private easypharmadbEntities db = new easypharmadbEntities();

        // GET: api/TaxByStates
        public IQueryable<TaxByStates> GetTaxByStates()
        {
            return db.TaxByStates;
        }

        // GET: api/TaxByStates/5
        [ResponseType(typeof(TaxByStates))]
        public IHttpActionResult GetTaxByStates(int id)
        {
            TaxByStates taxByStates = db.TaxByStates.Find(id);
            if (taxByStates == null)
            {
                return NotFound();
            }

            return Ok(taxByStates);
        }

        // PUT: api/TaxByStates/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTaxByStates(int id, TaxByStates taxByStates)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != taxByStates.Id)
            {
                return BadRequest();
            }

            db.Entry(taxByStates).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaxByStatesExists(id))
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

        // POST: api/TaxByStates
        [ResponseType(typeof(TaxByStates))]
        public IHttpActionResult PostTaxByStates(TaxByStates taxByStates)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TaxByStates.Add(taxByStates);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = taxByStates.Id }, taxByStates);
        }

        // DELETE: api/TaxByStates/5
        [ResponseType(typeof(TaxByStates))]
        public IHttpActionResult DeleteTaxByStates(int id)
        {
            TaxByStates taxByStates = db.TaxByStates.Find(id);
            if (taxByStates == null)
            {
                return NotFound();
            }

            db.TaxByStates.Remove(taxByStates);
            db.SaveChanges();

            return Ok(taxByStates);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TaxByStatesExists(int id)
        {
            return db.TaxByStates.Count(e => e.Id == id) > 0;
        }
    }
}