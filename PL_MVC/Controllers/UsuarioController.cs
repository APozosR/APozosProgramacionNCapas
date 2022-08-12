using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class UsuarioController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Usuario usuario = new ML.Usuario();

            usuario.Nombre = (usuario.Nombre == null) ? "" : usuario.Nombre;
            usuario.ApellidoPaterno = (usuario.ApellidoPaterno == null) ? "" : usuario.ApellidoPaterno;
            usuario.ApellidoMaterno = (usuario.ApellidoMaterno == null) ? "" : usuario.ApellidoMaterno;
            ML.Result result = BL.Usuario.GetAllEF(usuario);
            UsuarioReference1.UsuarioClient obj = new UsuarioReference1.UsuarioClient();
            var resultado = obj.GetAllEF(usuario);
           
            if (result.Correct)
            {
                usuario.Usuarios = result.Objects;
            }
            else
            {
                result.Correct = false;
            }
            return View(usuario);
        }

        [HttpPost]
        public ActionResult GetAll(ML.Usuario usuario)
        {
          
            usuario.Nombre = (usuario.Nombre == null) ? "" : usuario.Nombre;
            usuario.ApellidoPaterno = (usuario.ApellidoPaterno == null) ? "" : usuario.ApellidoPaterno; 
            usuario.ApellidoMaterno = (usuario.ApellidoMaterno == null) ? "" : usuario.ApellidoMaterno;

            ML.Result result = BL.Usuario.GetAllEF(usuario);
            if (result.Correct)
            {
                usuario.Usuarios = result.Objects;
            }
            else
            {
                result.Correct = false;
            }
            return View(usuario);
        }

        [HttpGet]
        public ActionResult Form(int? IdUsuario)
        {
            ML.Usuario usuario = new ML.Usuario();

            usuario.Direccion = new ML.Direccion();
            usuario.Direccion.Colonia = new ML.Colonia();
            usuario.Direccion.Colonia.Municipio = new ML.Municipio();
            usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
            usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();

            usuario.Rol = new ML.Rol();
            ML.Result resultRol = BL.Rol.RolGetAllEF();
            usuario.Pais = new ML.Pais();
            ML.Result resultPais = BL.Pais.GetAll();

            if (resultRol.Correct && resultPais.Correct)
            {
                if (IdUsuario == null)
                {
                    usuario.Rol = new ML.Rol();
                    usuario.Rol.Roles = resultRol.Objects;
                    usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPais.Objects;

                    return View(usuario);
                }
                else //UPDATE
                {
                ML.Result result = BL.Usuario.GetByIdEF(IdUsuario.Value);
                   if (result.Correct)
                   {
                        usuario = (ML.Usuario)result.Object; //Unboxing
                        usuario.Rol = new ML.Rol();
                        ML.Result resultRoles = BL.Rol.RolGetAllEF();
                        ML.Result resultEstado = BL.Estado.GetByIdPais(usuario.Direccion.Colonia.Municipio.Estado.IdEstado);
                        ML.Result resultMunicipio = BL.Municipio.GetByIdEstado(usuario.Direccion.Colonia.Municipio.IdMunicipio);
                        ML.Result resultColonia = BL.Colonia.GetByIdMunicipio(usuario.Direccion.Colonia.IdColonia);
                        usuario.Rol.Roles = resultRoles.Objects;
                        usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPais.Objects;
                        usuario.Direccion.Colonia.Municipio.Estado.Estados = resultEstado.Objects;
                        usuario.Direccion.Colonia.Municipio.Municipios = resultMunicipio.Objects;
                        usuario.Direccion.Colonia.Colonias = resultColonia.Objects;
                    }
                   else
                   {
                       ViewBag.Mensaje = "Error al mostrar los datos";
                       return View("modal");
                   }
                }
            }
            return View(usuario);
        }

        [HttpPost]
        public ActionResult Form(ML.Usuario usuario)
        {
            if (usuario.IdUsuario == 0)
            {
                ML.Result result = BL.Usuario.AddEF(usuario);


                if (result.Correct)
                {
                    ViewBag.Mensaje = "Registrado exitosamente";
                }
                else
                {
                    ViewBag.Mensaje = "Error al realizar el registro";
                }
                return View("Modal");
            }
            else
            {
                ML.Result result = BL.Usuario.UpdateEF(usuario);

                if (result.Correct)
                {
                    ViewBag.Mensaje = "Registro actualizado correctamente";
                }
                else
                {
                    ViewBag.Mensaje = "No se pudo actualzar el registro";
                }
                return View("modal");
            }
           
        }

        [HttpGet]
        public ActionResult Delete(int IdUsuario)
        {
            ML.Result result = BL.Usuario.DeleteEF(IdUsuario);

            if (result.Correct)
            {
                ViewBag.Mensaje = "Usuario borrado correctamente";
            }
            else
            {
                ViewBag.Mensaje = "Error al eliminar el usuario";
            }
            return View("modal");
        }
        
        public JsonResult EstadoGetByIdPais(int IdPais)
        {
            ML.Result result = BL.Estado.GetByIdPais(IdPais);
            return Json(result.Objects,JsonRequestBehavior.AllowGet);
        }

        public JsonResult MunicipioGetByIdEstado(int IdEstado)
        {
            ML.Result result = BL.Municipio.GetByIdEstado(IdEstado);
            return Json(result.Objects,JsonRequestBehavior.AllowGet);
        }

        public JsonResult ColoniaGetByIdMunicipio(int IdMunicipio)
        {
            ML.Result result = BL.Colonia.GetByIdMunicipio(IdMunicipio);
            return Json(result.Objects,JsonRequestBehavior.AllowGet);
        }
    }
}