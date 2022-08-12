using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUsuario" in both code and config file together.
    [ServiceContract]
    public interface IUsuario
    {
        [OperationContract]
        SL_WCF.Result AddEF(ML.Usuario usuario);

        [OperationContract]
        SL_WCF.Result UpdateEF(ML.Usuario usuario);

        [OperationContract]
        SL_WCF.Result DeleteEF(int IdUsuario);

        [OperationContract]
        [ServiceKnownType(typeof(ML.Usuario))]
        SL_WCF.Result GetAllEF(ML.Usuario usuario);

        [OperationContract]
        [ServiceKnownType(typeof(ML.Usuario))]
        SL_WCF.Result GetByIdEF(int IdUsuario);
    }

    [DataContract]
    public class Result
    {
        [DataMember]
        public bool Correct { get; set; }

        [DataMember]
        public string ErrorMessage { get; set; }

        [DataMember]
        public Exception Ex { get; set; }

        [DataMember]
        public List<object> Objects { get; set; }

        [DataMember]
        public object Object { get; set; }

    }
}
