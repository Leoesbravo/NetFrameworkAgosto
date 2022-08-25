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
        public static ML.Result AddEF(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();

            try
            {
                using(DL_EF.LEscogidoProgramacionNCapasAgostoEntities context = new DL_EF.LEscogidoProgramacionNCapasAgostoEntities())
                {
                    var query = context.AlumnoAdd(alumno.Nombre, alumno.ApellidoPaterno, alumno.ApellidoMaterno, alumno.FechaNacimiento, alumno.Sexo, alumno.Semestre.IdSemestre);

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
        public static ML.Result Update(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "UPDATE [Alumno] SET [Nombre] = @Nombre,[ApellidoPaterno] = @ApellidoPaterno ,[ApellidoMaterno] = @ApellidoMaterno,[FechaNacimiento] = @FechaNacimiento,[Sexo] = @Sexo WHERE IdAlumno = @IdAlumno";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;

                        SqlParameter[] collection = new SqlParameter[6];

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

                        collection[5] = new SqlParameter("IdAlumno", SqlDbType.Int);
                        collection[5].Value = alumno.IdAlumno;


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
                            result.ErrorMessage = "Ocurrió un error al insertar el registro en la tabla Alumno";
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
        public static ML.Result GetAllSP()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string querySP = "AlumnoGetAll";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = querySP;
                        cmd.CommandType = CommandType.StoredProcedure;

                        DataTable tableAlumno = new DataTable();

                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        da.Fill(tableAlumno);

                        if (tableAlumno.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();

                            foreach (DataRow row in tableAlumno.Rows)
                            {
                                ML.Alumno alumno = new ML.Alumno();
                                alumno.IdAlumno = int.Parse(row[0].ToString());
                                alumno.Nombre = row[1].ToString();
                                alumno.ApellidoPaterno = row[2].ToString();
                                alumno.ApellidoMaterno = row[3].ToString();
                                alumno.FechaNacimiento = row[4].ToString();
                                alumno.Sexo= row[5].ToString();

                                result.Objects.Add(alumno);
                            }

                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Ocurrió un error al seleccionar los registros en la tabla Producto";
                        }
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }
        public static ML.Result GetAllLINQ()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.LEscogidoProgramacionNCapasAgostoEntities context = new DL_EF.LEscogidoProgramacionNCapasAgostoEntities())
                {
                    var query = (from alumno in context.Alumnoes              
                                 select alumno );

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.Alumno alumno = new ML.Alumno();
                            alumno.IdAlumno = obj.IdAlumno;
                            alumno.Nombre = obj.Nombre;
                            alumno.ApellidoPaterno = obj.ApellidoPaterno;
                            alumno.ApellidoMaterno = obj.ApellidoMaterno;
                            alumno.FechaNacimiento = obj.FechaNacimiento.ToString();
                            alumno.Sexo = obj.Sexo;
                            alumno.Semestre = new ML.Semestre();
                            alumno.Semestre.IdSemestre = (byte)obj.IdSemestre;                          
                            result.Objects.Add(alumno);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result AddLINQ(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.LEscogidoProgramacionNCapasAgostoEntities context = new DL_EF.LEscogidoProgramacionNCapasAgostoEntities())
                {
                    DL_EF.Alumno alumnoDL = new DL_EF.Alumno();

                    alumnoDL.Nombre = alumno.Nombre;
                    alumnoDL.ApellidoPaterno = alumno.ApellidoPaterno;
                    alumnoDL.ApellidoMaterno = alumno.ApellidoMaterno;
                    alumnoDL.FechaNacimiento = DateTime.ParseExact(alumno.FechaNacimiento, "dd-MM-yyyy", null);
                    alumnoDL.Sexo = alumno.Sexo;
                    alumnoDL.IdSemestre = alumno.Semestre.IdSemestre;

                    context.Alumnoes.Add(alumnoDL);
                    context.SaveChanges();
                }
                result.Correct = true;
            }

            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }



    }
}
