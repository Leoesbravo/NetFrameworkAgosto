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
    }
}