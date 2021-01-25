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
using PryAnezNatalia.Models;

namespace PryAnezNatalia.Controllers
{
    public class TestsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Tests
        public IQueryable<Test> GetTests()
        {
            return db.Tests;
        }

        // GET: api/Tests/5
        [ResponseType(typeof(Test))]
        public IHttpActionResult GetTest(string id)
        {
            Test test = db.Tests.Find(id);
            if (test == null)
            {
                return NotFound();
            }

            return Ok(test);
        }

        // PUT: api/Tests/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTest(string id, Test test)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != test.name)
            {
                return BadRequest();
            }

            db.Entry(test).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestExists(id))
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

        // POST: api/Tests
        [ResponseType(typeof(Test))]
        public IHttpActionResult PostTest(Test test)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tests.Add(test);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TestExists(test.name))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = test.name }, test);
        }

        // DELETE: api/Tests/5
        [ResponseType(typeof(Test))]
        public IHttpActionResult DeleteTest(string id)
        {
            Test test = db.Tests.Find(id);
            if (test == null)
            {
                return NotFound();
            }

            db.Tests.Remove(test);
            db.SaveChanges();

            return Ok(test);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TestExists(string id)
        {
            return db.Tests.Count(e => e.name == id) > 0;
        }
    }
}