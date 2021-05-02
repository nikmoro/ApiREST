using ApiRest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiRest.Controllers
{
    public class EjemploController : ApiController
    {

        [HttpGet]
        public List<Donacion> GetLista()
        {
            using (var conexion = new ReforestacionEntities())
            {
                var result = (from re in conexion.Donaciones select re);
                return result.ToList();
            }
        }

        [HttpPost]
        public bool Insertar(Donacion entidad)
        {
            using (var conexion = new ReforestacionEntities())
            {
                try
                {
                    conexion.Donaciones.Add(new Donacion()
                    {
                        nombre_mpio = entidad.nombre_mpio,
                        nombre_arbol = entidad.nombre_arbol,
                        cantidad = entidad.cantidad
                    });
                    conexion.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
                
            }
        }
    }
}
