using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAlumno" in both code and config file together.
    [ServiceContract]
    public interface IAlumno
    {
        [OperationContract]
        Result Add(ML.Alumno usuario);

        //[OperationContract]
        //Result Update(ML.Alumno usuario);

        //[OperationContract]
        //Result Delete(ML.Alumno usuario);

        //[OperationContract]
        //[ServiceKnownType(typeof(ML.Alumno))]
        //Result GetById(int IdUsuario);

        //[OperationContract]
        //[ServiceKnownType(typeof(ML.Alumno))]
        //Result GetAll();
    }
}
