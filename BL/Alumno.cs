using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Alumno
    {
        public static ML.Result Add(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "INSERT INTO [Alumno]([Nombre],[ApellidoPaterno],[ApellidoMaterno],[FechaNacimiento],[Sexo]) VALUES(@Nombre, @ApellidoPaterno, @ApellidoMaterno, @FechaNacimiento, @Sexo)";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;

                        SqlParameter[] collection = new SqlParameter[5];

                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = alumno.Nombre;

                        collection[1] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                        collection[1].Value = alumno.ApellidoPaterno;

                        collection[2] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                        collection[2].Value = alumno.ApellidoMaterno;

                        collection[3] = new SqlParameter("FechaNacimiento", SqlDbType.DateTime);
                        collection[3].Value = alumno.FechaNacimiento;

                        collection[4] = new SqlParameter("Sexo", SqlDbType.Char);
                        collection[4].Value = alumno.Sexo;


                        cmd.Parameters.AddRange(collection);

                        cmd.Connection.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Ocurrió un error al insertar el registro en la tabla Producto";
                        }

                    }
                }

            }
            catch (Exception Ex)
            {
                result.Ex = Ex;
                throw;
            }

            return result;
        }


    }
}
