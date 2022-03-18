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

        [WebMethod(Description = "Devuelve la lista de Proveedores")]
        public List<proveedor> GetProveedor()
        {
            BDSOAPEntities conexion = new BDSOAPEntities();
            var consulta = (from c in conexion.proveedores select c).ToList();
            return consulta;
        }

        /// <summary>
        /// Método para consultar un proveedor
        /// </summary>
        /// <param name="nombre">nombre tipo string</param>
        /// <returns>clase proveedor</returns>
        [WebMethod(Description = "Devuelve la un Proveedor")]
        public proveedor ObtenerProveedor(string nombre)
        {
            BDSOAPEntities conexion = new BDSOAPEntities();
            var consulta = (from c in conexion.proveedores where c.nombre == nombre select c).FirstOrDefault();
            return consulta;
        }

        [WebMethod(Description = "Agregar un Proveedor")]
        public bool AgregarProveedor(string Nombre, string Direccion, String Telefono, String Email)
        {
            try
            {
                using (var conexion = new BDSOAPEntities())
                {
                    proveedor proveedornuevo = new proveedor();
                    proveedornuevo.nombre = Nombre;
                    proveedornuevo.direccion = Direccion;
                    proveedornuevo.telefono = Telefono;
                    proveedornuevo.email = Email;
                    conexion.proveedores.Add(proveedornuevo);
                    conexion.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        [WebMethod(Description = "Eliminar un Proveedor")]
        public bool BorrarProveedor(int id)
            {
            try
            {
                using (var conexion = new BDSOAPEntities())
                {
                    var consulta = (from c in conexion.proveedores where c.id == id select c).FirstOrDefault();
                    if(consulta != null)
                    {
                        conexion.proveedores.Remove(consulta);
                        conexion.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            catch (Exception)
            {
                return false;
            }
        }

        [WebMethod(Description = "Modificar un Proveedor")]
        public bool ActualizarProveedor(int id, string nombre, string direccion, string telefono, string email)
        {
            try
            {
                using (var conexion = new BDSOAPEntities())
                {
                    var consulta = (from c in conexion.proveedores where c.id == id select c).FirstOrDefault();
                    if (consulta != null)
                    {
                        consulta.nombre = nombre;
                        consulta.direccion = direccion;
                        consulta.telefono = telefono;
                        consulta.email = email;
                        conexion.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            catch (Exception)
            {
                return false;
            }
        }

    }
}
