using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Plantel
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.LEscogidoProgramacionNCapasAgostoEntities context = new DL_EF.LEscogidoProgramacionNCapasAgostoEntities())
                {
                    var query = context.PlantelGetAll().ToList();
                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var item in query)
                        {
                            ML.Plantel plantel = new ML.Plantel();
                            plantel.IdPlantel = item.IdPlantel;
                            plantel.Nombre = item.Nombre;

                            result.Objects.Add(plantel);
                        }
                        result.Correct = true;
                    }
                }
               
            }
            catch (Exception ex)
            {

            }
            return result;
        }
    }
}
