using CRUD_API_REST.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace CRUD_API_REST.Controllers
{
    /// <summary>
    /// Habilita las políticas CORS para el cliente web específico.
    /// </summary>
    [EnableCors(origins: "http://127.0.0.1:5500", headers: "*", methods: "*")]

    public class DonacionController : ApiController
    {
        /// <summary>
        /// Objeto que se conecta al modelo de la base de datos.
        /// </summary>
        private ModelDonaciones db = new ModelDonaciones();

        /// <summary>
        /// Método GET para OBTENER la lista de Donaciones. 
        /// </summary>
        /// <returns>Una lista usando el objeto conexión y el tipo de dato Donación que almacena la colección.</returns>

        // GET: api/Donacion
        public IQueryable<Donacion> GetDonacion()
        {
            return db.Donacion;
        }

        /// <summary>
        /// Método GET que OBTIENE un elemento específico de Donaciones.
        /// </summary>
        /// <param name="id">Identificador de tipo entero.</param>
        /// <returns>Entidad del modelo de la BBDD con código 200.<</returns>

        // GET: api/Donacion/5
        [ResponseType(typeof(Donacion))]
        public IHttpActionResult GetDonacion(int id)
        {
            Donacion donacion = db.Donacion.Find(id);
            if (donacion == null)
            {
                return NotFound();
            }

            return Ok(donacion);
        }

        /// <summary>
        /// Método PUT para ACTUALIZAR elementos de la BBDD.
        /// </summary>
        /// <param name="id">Identificador de tipo entero.</param>
        /// <param name="donacion">Entidad del modelo de la BBDD.</param>
        /// <returns>Valor de códigos de estados ya definidos para HTTP.</returns>

        // PUT: api/Donacion/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDonacion(int id, Donacion donacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != donacion.id)
            {
                return BadRequest();
            }

            db.Entry(donacion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DonacionExists(id))
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

        /// <summary>
        /// Método POST para CREAR elementos de la BBDD.
        /// </summary>
        /// <param name="donacion">Entidad del modelo de la BBDD.</param>
        /// <returns>El elemento creado de la entidad Donación</returns>

        // POST: api/Donacion
        [ResponseType(typeof(Donacion))]
        public IHttpActionResult PostDonacion(Donacion donacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Donacion.Add(donacion);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = donacion.id }, donacion);
        }

        /// <summary>
        /// Método DELETE para ELIMINAR elementos de la BBBDD.
        /// </summary>
        /// <param name="id">Identificador de tipo entero</param>
        /// <returns>Entidad del modelo de la BBDD con código 200.</returns>

        // DELETE: api/Donacion/5
        [ResponseType(typeof(Donacion))]
        public IHttpActionResult DeleteDonacion(int id)
        {
            Donacion donacion = db.Donacion.Find(id);
            if (donacion == null)
            {
                return NotFound();
            }

            db.Donacion.Remove(donacion);
            db.SaveChanges();

            return Ok(donacion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DonacionExists(int id)
        {
            return db.Donacion.Count(e => e.id == id) > 0;
        }
    }
}