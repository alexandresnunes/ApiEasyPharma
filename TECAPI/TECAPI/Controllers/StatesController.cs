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
    public class StatesController : ApiController
    {
        private easypharmadbEntities db = new easypharmadbEntities();

        // GET: api/States
        public IQueryable<States> GetStates()
        {
            return db.States;
        }

        // GET: api/States/5
        [ResponseType(typeof(States))]
        public IHttpActionResult GetStates(int id)
        {
            States states = db.States.Find(id);
            if (states == null)
            {
                return NotFound();
            }

            return Ok(states);
        }

        // PUT: api/States/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStates(int id, States states)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != states.Id)
            {
                return BadRequest();
            }

            db.Entry(states).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatesExists(id))
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

        // POST: api/States
        [ResponseType(typeof(States))]
        public IHttpActionResult PostStates(States states)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.States.Add(states);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = states.Id }, states);
        }

        // DELETE: api/States/5
        [ResponseType(typeof(States))]
        public IHttpActionResult DeleteStates(int id)
        {
            States states = db.States.Find(id);
            if (states == null)
            {
                return NotFound();
            }

            db.States.Remove(states);
            db.SaveChanges();

            return Ok(states);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StatesExists(int id)
        {
            return db.States.Count(e => e.Id == id) > 0;
        }
    }
}