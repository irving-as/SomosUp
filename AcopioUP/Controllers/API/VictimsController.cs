using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AcopioUP.Models;

namespace AcopioUP.Controllers.API
{
    public class VictimsController : ApiController
    {

        private readonly ApplicationDbContext _context;

        public VictimsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/victims
        public IHttpActionResult GetVictims()
        {
            return Ok(_context.Victims.ToList());
        }

        // GET /api/victims/{id}
        public IHttpActionResult GetVictim(int id)
        {
            var victim = _context.Victims.SingleOrDefault(v => v.Id == id);
            if (victim == null)
                return NotFound();

            return Ok(victim);
        }

        // POST api/victims
        [HttpPost]
        public IHttpActionResult CreateVictim(Victim victim) //TODO: Create DTO  
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _context.Victims.Add(victim);
            _context.SaveChanges();
            return Created(new Uri($"{Request.RequestUri}/{victim.Id}"), victim);
        }

        //PUT api/victims/{id}
        [HttpPut]
        public IHttpActionResult UpdateVictim(int id, Victim victim) //TODO: Create DTO and use automapper
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var victimInDb = _context.Victims.SingleOrDefault(v => v.Id == id);

            if (victimInDb == null)
                return NotFound();

            victimInDb.FirstName = victim.FirstName;
            victimInDb.LastName = victim.LastName;
            victimInDb.Email = victim.Email;

            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/victim/{id}
        [HttpDelete]
        public IHttpActionResult DeleteVictim(int id)
        {
            var victimInDb = _context.Victims.SingleOrDefault(v => v.Id == id);

            if (victimInDb == null)
                return NotFound();

            _context.Victims.Remove(victimInDb);
            _context.SaveChanges();

            return Ok();
        }

    }
}
