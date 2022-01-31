using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdaUnoVazquezValdez.Models;
using AdaUnoVazquezValdez.Models.Response;
using AdaUnoVazquezValdez.Models.Request;

namespace AdaUnoVazquezValdez.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculasController : ControllerBase
    {

        [HttpGet] //Creamos el métodod para traer datos JSON

        public IActionResult Get()
        {
            Respuesta oRespuesta = new Respuesta(); //Llamamos a la clase Respuesta

            try
            {
                using (CinemaContext db = new CinemaContext())
                {
                    var lst = db.Peliculas.ToList();
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = lst;
                }

            }
            catch(Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);


        }


    [HttpPost]
        //Creamos el método para traer los datos parainsertar datos
        public IActionResult Add(PeliculasRequest model)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                using (CinemaContext db = new CinemaContext())
                {
                    Pelicula oPro = new Pelicula();
                    oPro.Id = model.Id;
                    oPro.Titulo = model.Titulo;
                    oPro.Director = model.Director;
                    oPro.Puntuacion = model.Puntuacion;
                    oPro.Rating = model.Rating;
                    oPro.AñoDePublicacion = model.AñoDePublicacion;
                    db.Peliculas.Add(oPro);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }
        [HttpPut]
        //Creamos el método para traer los datos para el update
        public IActionResult Editar(PeliculasRequest model)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                using (CinemaContext db = new CinemaContext())
                {
                    Pelicula oPro = db.Peliculas.Find(model.Id);  //Instanciamos el objeto para indicar cuál llave primaria se modifica
                    oPro.Id = model.Id;
                    oPro.Titulo = model.Titulo;
                    oPro.Director = model.Director;
                    oPro.Puntuacion = model.Puntuacion;
                    oPro.Rating = model.Rating;
                    oPro.AñoDePublicacion = model.AñoDePublicacion;
                    db.Entry(oPro).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }
        [HttpDelete("{id}")]
        //Creamos el método para traer los datos para borrar datos
        public IActionResult Eliminar(int id)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                using (CinemaContext db = new CinemaContext())
                {
                    Pelicula oPro = db.Peliculas.Find(id);
                    db.Remove(oPro);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpGet("{id}")]
        //Creamos el método para traer los datos para borrar datos
        public IActionResult Get(int id)
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                using (CinemaContext db = new CinemaContext())
                {

                    var lst = db.Peliculas.Find(id);
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = lst;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }
    }
}
