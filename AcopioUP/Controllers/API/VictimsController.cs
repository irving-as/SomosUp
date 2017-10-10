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
        public IEnumerable<Victim> GetVictims()
        {
            return _context.Victims.ToList();
        }

        // GET /api/victims/{id}
        public Victim GetVictim(int id)
        {
            var victim = _context.Victims.SingleOrDefault(v => v.Id == id);
            if(victim == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return victim;
        }

        // POST api/victims
        [HttpPost]
        public Victim CreateVictim(Victim victim) //TODO: Create DTO  
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Victims.Add(victim);
            _context.SaveChanges();
            return victim;
        }

        //PUT api/victims/{id}
        [HttpPut]
        public void UpdateVictim(int id, Victim victim) //TODO: Create DTO and use automapper
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var victimInDb = _context.Victims.SingleOrDefault(v => v.Id == id);

            if (victimInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            victimInDb.FirstName = victim.FirstName;
            victimInDb.LastName = victim.LastName;
            victimInDb.Email = victim.Email;

            _context.SaveChanges();
        }

        // DELETE /api/victim/{id}
        [HttpDelete]
        public void DeleteVictim(int id)
        {
            var victimInDb = _context.Victims.SingleOrDefault(v => v.Id == id);

            if(victimInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Victims.Remove(victimInDb);
            _context.SaveChanges();
        }

    }
}
