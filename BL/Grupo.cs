using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Grupo
    {
        public static ML.Result GetByIdPlantel(int IdPlantel)//todos los planteles de determinado plantel
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.LEscogidoProgramacionNCapasAgostoEntities context = new DL_EF.LEscogidoProgramacionNCapasAgostoEntities())
                {
                    var query = context.GrupoGetByIdPlantel(IdPlantel).ToList();
                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var item in query)
                        {
                            ML.Grupo grupo = new ML.Grupo();
                            grupo.IdGrupo = item.IdGrupo;
                            grupo.Nombre = item.Nombre;
                            grupo.Plantel = new ML.Plantel();
                            grupo.Plantel.IdPlantel = item.IdPlantel.Value;

                            result.Objects.Add(grupo);
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
