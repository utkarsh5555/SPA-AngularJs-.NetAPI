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
using SPA_AngularJs_API;

namespace SPA_AngularJs_API.Controllers
{
    public class MusicsController : ApiController
    {
        private AngularSPADBEntities db = new AngularSPADBEntities();

        // GET: api/Musics
        public IQueryable<Music> GetMusics()
        {
            return db.Musics;
        }

        // GET: api/Musics/5
        [ResponseType(typeof(Music))]
        public IHttpActionResult GetMusic(long id)
        {
            Music music = db.Musics.Find(id);
            if (music == null)
            {
                return NotFound();
            }

            return Ok(music);
        }

        // PUT: api/Musics/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMusic(long Id, Music music)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (Id != music.Id)
            {
                return BadRequest();
            }

            db.Entry(music).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MusicExists(Id))
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

        // POST: api/Musics
        [ResponseType(typeof(Music))]
        public IHttpActionResult PostMusic(Music music)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Musics.Add(music);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = music.Id }, music);
        }

        // DELETE: api/Musics/5
        [ResponseType(typeof(Music))]
        public IHttpActionResult DeleteMusic(long id)
        {
            Music music = db.Musics.Find(id);
            if (music == null)
            {
                return NotFound();
            }

            db.Musics.Remove(music);
            db.SaveChanges();

            return Ok(music);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MusicExists(long id)
        {
            return db.Musics.Count(e => e.Id == id) > 0;
        }
    }
}