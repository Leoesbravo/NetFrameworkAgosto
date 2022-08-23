using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Alumno //Pedir datos para el CRUD
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

            Console.WriteLine("Inserte el Fecha de nacimiento del Alumno");
            alumno.FechaNacimiento = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Inserte el genero");
            alumno.Sexo = Console.ReadLine();

            ML.Result result = BL.Alumno.Add(alumno);

            if (result.Correct)
            {
                Console.WriteLine("Alumno registrado con exito");
            }
            else
            {
                Console.WriteLine("Ocurrio un error al registrar al alumno" + result.ErrorMessage);
            }


        }

        public static void Update()
        {
            ML.Alumno alumno = new ML.Alumno();//instancia de una clase || Crear un objeto para acceder a atributos y metodos

            Console.WriteLine("Inserte el Id del Alumno");
            alumno.IdAlumno = int.Parse(Console.ReadLine());

            Console.WriteLine("Inserte el nombre del Alumno");
            alumno.Nombre = Console.ReadLine();
            //string nombre = Console.ReadLine();

            Console.WriteLine("Inserte el apellido paterno del Alumno");
            alumno.ApellidoPaterno = Console.ReadLine();

            Console.WriteLine("Inserte el apellido materno del Alumno");
            alumno.ApellidoMaterno = Console.ReadLine();

            

        public static void GetAll()
        {
            ML.Result result = BL.Alumno.GetAllSP();
        }
    }
}
