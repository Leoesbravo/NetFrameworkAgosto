using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Alumno
    {
        public static ML.Result AddEF(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.LEscogidoProgramacionNCapasAgostoEntities context = new DL_EF.LEscogidoProgramacionNCapasAgostoEntities())
                {
                    var query = context.AlumnoAdd(alumno.Nombre, alumno.ApellidoPaterno, alumno.ApellidoMaterno, alumno.FechaNacimiento, alumno.Sexo);

                    if(query > 0)
                    {
                        result.Correct = true; 
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct=false;
                result.Ex = ex;
            }
            return result;
        }
    }
}
