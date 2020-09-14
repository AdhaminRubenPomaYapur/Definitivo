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
using Personal.Models;

namespace Personal.Controllers
{
    public class pomasController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/pomas
        public IQueryable<poma> Getpomas()
        {
            return db.pomas;
        }

        // GET: api/pomas/5
        [ResponseType(typeof(poma))]
        public IHttpActionResult Getpoma(int id)
        {
            poma poma = db.pomas.Find(id);
            if (poma == null)
            {
                return NotFound();
            }

            return Ok(poma);
        }

        // PUT: api/pomas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putpoma(int id, poma poma)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != poma.poma_ID)
            {
                return BadRequest();
            }

            db.Entry(poma).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!pomaExists(id))
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

        // POST: api/pomas
        [ResponseType(typeof(poma))]
        public IHttpActionResult Postpoma(poma poma)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.pomas.Add(poma);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = poma.poma_ID }, poma);
        }

        // DELETE: api/pomas/5
        [ResponseType(typeof(poma))]
        public IHttpActionResult Deletepoma(int id)
        {
            poma poma = db.pomas.Find(id);
            if (poma == null)
            {
                return NotFound();
            }

            db.pomas.Remove(poma);
            db.SaveChanges();

            return Ok(poma);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool pomaExists(int id)
        {
            return db.pomas.Count(e => e.poma_ID == id) > 0;
        }
    }
}