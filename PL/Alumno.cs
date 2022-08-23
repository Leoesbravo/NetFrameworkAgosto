using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Alumno
    {
        public static void Add()
        {
            ML.Alumno alumno = new ML.Alumno();//instancia de una clase || Crear un objeto para acceder a atributos y metodos

            Console.WriteLine("Inserte el nombre del Alumno");
            alumno.Nombre = Console.ReadLine();
            //string nombre = Console.ReadLine();

            Console.WriteLine("Inserte el apellido paterno del Alumno");
            alumno.ApellidoPaterno = Console.ReadLine();

            Console.WriteLine("Inserte el apellido materno del Alumno");
            alumno.ApellidoMaterno = Console.ReadLine();

            // ML.Result result = BL.Alumno.AddSP
            ML.Result result = BL.Alumno.AddEF(alumno);

        }
    }
}
