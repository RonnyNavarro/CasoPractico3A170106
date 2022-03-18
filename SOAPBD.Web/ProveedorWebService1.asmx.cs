using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using SOAPBD.Web.Model;

namespace SOAPBD.Web
{
    /// <summary>
    /// Descripción breve de ProveedorWebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class ProveedorWebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }

        [WebMethod(Description = "Devuelve la lista de Proveedor")]
        public List<proveedor> GetProveedor()
        {
            BDSOAPEntities conexion = new BDSOAPEntities();
            var consulta = (from c in conexion.proveedores select c).ToList();
            return consulta;
        }
    }
}
