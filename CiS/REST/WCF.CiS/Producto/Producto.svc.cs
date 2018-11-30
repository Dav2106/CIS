using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF.CiS.Producto
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Producto" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Producto.svc o Producto.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Producto : IProducto
    {
        public void DoWork()
        {
        }
    }
}
