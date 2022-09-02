using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class AlumnoController : Controller
    {
        [HttpGet]//Action Verb
        public ActionResult GetAll() //Action Method
        {
            ML.Result result = BL.Alumno.GetAllLINQ();
            ML.Alumno alumno = new ML.Alumno();
            if (result.Correct)
            {    //lista vacia     //lista de alumnos
                alumno.Alumnos = result.Objects; // estoy pasando de result.objects a alumno.Alumnos

                return View(alumno);
            }
            else
            {
                return View(alumno);
            }

        }

        [HttpGet]
        public ActionResult Form(int? IdAlumno)
        {
            ML.Alumno alumno = new ML.Alumno();
            ML.Result result = BL.Plantel.GetAll();

            alumno.Horario = new ML.Horario();
            alumno.Horario.Grupo = new ML.Grupo();
            alumno.Horario.Grupo.Plantel = new ML.Plantel();

            alumno.Horario.Grupo.Plantel.Planteles = result.Objects;

            return View(alumno);
        }

        [HttpPost]
        public ActionResult Form(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();
            if (alumno.IdAlumno == 0)
            {
                result = BL.Alumno.AddEF(alumno);
            }
            else
            {
                result = BL.Alumno.Update(alumno);
                
            }
            return View();
        }

    }
}