using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF.CiS.CategoriaProveedor
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "ICategoriaProveedor" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface ICategoriaProveedor
    {
        [OperationContract]
        void DoWork();
    }
}
