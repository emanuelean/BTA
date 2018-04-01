using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BTA_CS.Entities;
using System.Web.Http;
using System.Web.Http.Description;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System;

namespace BTA_CS.Controllers
{
    public class BusController : ApiController
    {
        static string myConnectionString = "server=localhost;database=bus-transportation-app;uid=root;password=123456789;MultipleActiveResultSets=True";
        //connectionString="server=localhost;port=3306;database=mycontext;uid=root;password=********"/>
        //"server=localhost;port=3305;database=parking;uid=root";
        private BTAContext db = new BTAContext(myConnectionString);

        public BusController()
        {

        }
        // GET: api/Bus
        public IQueryable<Bus> GetBuses()
        {
            return db.Bus;
        }

        // GET: api/Buses/5
        [ResponseType(typeof(Bus))]
        public async Task<IHttpActionResult> GetBus(int id)
        {
            Console.WriteLine("EnteredGetBus");
            Bus bus = await db.Bus.FindAsync(id);
            Console.WriteLine("gotBus!");
            if (bus == null)
            {
                Console.WriteLine("ExitGetBusForced");
                return NotFound();
            }
            Console.WriteLine("ExitGetBus");
            return Ok(bus);
        }

        // PUT: api/Buses/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBus(int id, Bus bus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bus.ID)
            {
                return BadRequest();
            }

            db.Entry(bus).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusExists(id))
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

        // POST: api/Buses
        [ResponseType(typeof(Bus))]
        public async Task<IHttpActionResult> PostBus(Bus bus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Bus.Add(bus);
            await db.SaveChangesAsync();
            Console.WriteLine(db.GetType());

            return CreatedAtRoute("DefaultApi", new { id = bus.ID }, bus);
        }

        // DELETE: api/Buses/5
        [ResponseType(typeof(Bus))]
        public async Task<IHttpActionResult> DeleteBus(int id)
        {
            Bus bus = await db.Bus.FindAsync(id);
            if (bus == null)
            {
                return NotFound();
            }

            db.Bus.Remove(bus);
            await db.SaveChangesAsync();

            return Ok(bus);
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public bool BusExists(int id)
        {
            return db.Bus.Count(e => e.ID == id) > 0;
        }
    }
}