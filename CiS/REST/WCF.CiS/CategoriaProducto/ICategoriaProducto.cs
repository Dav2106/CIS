using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF.CiS.CategoriaProducto
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "ICategoriaProducto" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface ICategoriaProducto
    {
        [OperationContract]
        bool InsertCategoriaProducto();
        [OperationContract]
        bool UpdateCategoriaProducto();
        [OperationContract]
        bool dow();
        [OperationContract]
        bool dor();
    }
}
