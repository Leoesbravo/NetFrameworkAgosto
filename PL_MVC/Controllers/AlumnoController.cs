using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class AlumnoController : Controller
    {
        [HttpGet]//Action Verb
        public ActionResult GetAll() //Action Method
        {
            ML.Result result = BL.Alumno.GetAllEF();
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
            ML.Alumno alumno = new ML.Alumno();//instancia de objeto
            alumno.Semestre = new ML.Semestre();//instancia de FK

            ML.Result result = BL.Semestre.GetAllEF();

            if (IdAlumno == null)
            {
                alumno.Semestre.Semestres = result.Objects;
                return View(alumno);
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Form(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();
            if (alumno.IdAlumno == 0)
            {
                result = BL.Alumno.AddEF(alumno);

                if (result.Correct)
                {
                    ViewBag.Message = "Alumno agregado correctamente";
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al agregar al alumno" + result.ErrorMessage;
                }
            
            }
            else
            {
                result = BL.Alumno.Update(alumno);

                if (result.Correct)
                {
                    ViewBag.Message = "Alumno actualizado correctamente";
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al actualizar al alumno" + result.ErrorMessage;
                }

            }
            return View("Modal");
        }


        //delete

    }
}
































































































































































































































































