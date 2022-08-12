using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Usuario
    {
        //////////////////////////////////AÑADIR
        public static void Add()
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("Ingresa tu nombre");
            usuario.Nombre = Console.ReadLine();

            Console.WriteLine("Ingresa tu apellido paterno");
            usuario.ApellidoPaterno = Console.ReadLine();

            Console.WriteLine("Ingresa tu apellido materno");
            usuario.ApellidoMaterno = Console.ReadLine();

            Console.WriteLine("Ingresa tu numero de telefono");
            usuario.Telefono = Console.ReadLine();

            usuario.Rol = new ML.Rol();

            Console.WriteLine("Ingresa el id del rol");
            usuario.Rol.IdRol = (byte)int.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa tu UserName");
            usuario.UserName = Console.ReadLine();

            Console.WriteLine("Ingresa tu email");
            usuario.Email = Console.ReadLine();

            Console.WriteLine("Ingresa tu password");
            usuario.Password = Console.ReadLine();

            Console.WriteLine("Ingresa tu fecha de nacimiento");
            usuario.FechaNacimiento = Console.ReadLine();

            Console.WriteLine("Ingresa tu tipo de sexo (M)Masculino/(F)Femenino");
            usuario.Sexo = Console.ReadLine();

            Console.WriteLine("Ingresa tu numero de celular");
            usuario.Celular = Console.ReadLine();

            Console.WriteLine("Ingresa tu CURP");
            usuario.CURP = Console.ReadLine();

            usuario.Direccion = new ML.Direccion();

            Console.WriteLine("Ingresa el nombre de la calle");
            usuario.Direccion.Calle = Console.ReadLine();

            Console.WriteLine("Ingresa el numero interior");
            usuario.Direccion.NumeroInterior = Console.ReadLine();

            Console.WriteLine("Ingresa el numero exterior");
            usuario.Direccion.NumeroExterior = Console.ReadLine();

            usuario.Direccion.Colonia = new ML.Colonia();
            Console.WriteLine("Ingresa el IdColonia");
            usuario.Direccion.Colonia.IdColonia = int.Parse(Console.ReadLine());

            //ML.Result result = BL.Usuario.Add(usuario);
            //ML.Result result = BL.Usuario.AddSP(usuario);
            //ML.Result result = BL.Usuario.AddEF(usuario);
            //ML.Result result = BL.Usuario.AddLINQ(usuario);
            UsuarioReference1.UsuarioClient obj =  new UsuarioReference1.UsuarioClient();
            var result = obj.AddEF(usuario);

            if (result.Correct)
            {
                Console.WriteLine("Registrado exitosamente");
            }
            else
            {
                Console.WriteLine("Error al registrarse");
            }
        }

        //////////////////////////////////ACTUALIZAR
        public static void Update()
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("Ingresa el Id para modificar el registro");
            usuario.IdUsuario = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa el nuevo nombre");
            usuario.Nombre = Console.ReadLine();

            Console.WriteLine("Ingresa el nuevo apellido paterno");
            usuario.ApellidoPaterno = Console.ReadLine();

            Console.WriteLine("Ingresa el nuevo apellido materno");
            usuario.ApellidoMaterno = Console.ReadLine();

            Console.WriteLine("Ingresa el nuevo numero de telefono");
            usuario.Telefono = Console.ReadLine();

            usuario.Rol = new ML.Rol();

            Console.WriteLine("Ingresa el nuevo id del rol");
            usuario.Rol.IdRol = (byte)int.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa el nuevo UserName");
            usuario.UserName = Console.ReadLine();

            Console.WriteLine("Ingresa el nuevo email");
            usuario.Email = Console.ReadLine();

            Console.WriteLine("Ingresa el nuevo password");
            usuario.Password = Console.ReadLine();

            Console.WriteLine("Actualiza tu fecha de nacimiento");
            usuario.FechaNacimiento = Console.ReadLine();

            Console.WriteLine("Actualiza tu tipo de sexo (M)Masculino/(F)Femenino");
            usuario.Sexo = Console.ReadLine();

            Console.WriteLine("Ingresa tu nuevo numero de celular");
            usuario.Celular = Console.ReadLine();

            Console.WriteLine("Actualiza tu CURP");
            usuario.CURP = Console.ReadLine();

            usuario.Direccion = new ML.Direccion();

            Console.WriteLine("Ingresa el IdDireccion");
            usuario.Direccion.IdDireccion = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa el nombre de la calle");
            usuario.Direccion.Calle = Console.ReadLine();

            Console.WriteLine("Ingresa el numero interior");
            usuario.Direccion.NumeroInterior = Console.ReadLine();

            Console.WriteLine("Ingresa el numero exterior");
            usuario.Direccion.NumeroExterior = Console.ReadLine();

            usuario.Direccion.Colonia = new ML.Colonia();
            Console.WriteLine("Ingresa el IdColonia");
            usuario.Direccion.Colonia.IdColonia = int.Parse(Console.ReadLine());

            // ML.Result result = BL.Usuario.Update(usuario);
            //ML.Result result = BL.Usuario.UpdateSP(usuario);
            //ML.Result result = BL.Usuario.UpdateEF(usuario);
            //ML.Result result = BL.Usuario.UpdateLINQ(usuario);
            UsuarioReference1.UsuarioClient obj = new UsuarioReference1.UsuarioClient();
            var result = obj.UpdateEF(usuario);

            if (result.Correct)
            {
                Console.WriteLine("Registro actualizado exitosamente");
            }
            else
            {
                Console.WriteLine("No fue posible actualizar el registro");
            }
        }

        //////////////////////////////////BORRAR
        public static void Delete()
        {
            ML.Usuario usuario = new ML.Usuario();
            Console.WriteLine("Ingresa el ID para borrar el registro");
            usuario.IdUsuario = int.Parse(Console.ReadLine());

            //ML.Result result = BL.Usuario.Delete(usuario);
            //ML.Result result = BL.Usuario.DeleteSP(usuario);
            //ML.Result result = BL.Usuario.DeleteEF(usuario.IdUsuario);
            //ML.Result result = BL.Usuario.DeleteLINQ(usuario);
            UsuarioReference1.UsuarioClient obj = new UsuarioReference1.UsuarioClient();
            var result = obj.DeleteEF(usuario.IdUsuario);

            if (result.Correct)
            {
                Console.WriteLine("Registro borrado exitosamente");
            }
            else
            {
                Console.WriteLine("No fue posible borrar el registro");
            }
        }

        //////////////////////////////////CONSULTAR
        public static void GetAll()
        {
            ML.Usuario usuarioBusqueda = new ML.Usuario();

            Console.WriteLine("Ingresa Nombre");
            usuarioBusqueda.Nombre = Console.ReadLine();
            Console.WriteLine("Ingresa apellido paterno");
            usuarioBusqueda.ApellidoPaterno = Console.ReadLine();
            Console.WriteLine("Ingresa apellido materno");
            usuarioBusqueda.ApellidoMaterno = Console.ReadLine();
            //ML.Result result = BL.Usuario.GetAllSP();
            //ML.Result result = BL.Usuario.GetAllEF();
            //ML.Result result = BL.Usuario.GetAllLINQ();
            UsuarioReference1.UsuarioClient obj = new UsuarioReference1.UsuarioClient();
            var result = obj.GetAllEF(usuarioBusqueda);

            if (result.Correct)
            {
                foreach (ML.Usuario usuario in result.Objects)
                {
                    Console.WriteLine("IdUsuario: "       + usuario.IdUsuario);
                    Console.WriteLine("Nombre: "          + usuario.Nombre);
                    Console.WriteLine("ApellidoPaterno: " + usuario.ApellidoPaterno);
                    Console.WriteLine("ApellidoMaterno: " + usuario.ApellidoMaterno);
                    Console.WriteLine("Telefono: "        + usuario.Telefono);
                    Console.WriteLine("IdRol: "           + usuario.Rol.IdRol);
                    Console.WriteLine("UserName: "        + usuario.UserName);
                    Console.WriteLine("Email: "           + usuario.Email);
                    Console.WriteLine("Password: "        + usuario.Password);
                    Console.WriteLine("FechaNacimiento: " + usuario.FechaNacimiento);
                    Console.WriteLine("Sexo: "            + usuario.Sexo);
                    Console.WriteLine("Celular: "         + usuario.Celular);
                    Console.WriteLine("CURP: "            + usuario.CURP);
                    Console.WriteLine("---------------------------------------------");
                    
                }
            }
            else
            {
                Console.WriteLine("Error al consultar los datos");
            }
        }

        //////////////////////////////////CONSULTAR UNO
        
        public static void GetById()
        {

            Console.WriteLine("Ingresa el Id que deseas consultar");
            

            //ML.Result result = BL.Usuario.GetByIdSP(int.Parse(Console.ReadLine()));
            //ML.Result result = BL.Usuario.GetByIdEF(int.Parse(Console.ReadLine()));
            //ML.Result result = BL.Usuario.GetByIdLINQ(int.Parse(Console.ReadLine()));
            UsuarioReference1.UsuarioClient obj = new UsuarioReference1.UsuarioClient();
            var result = obj.GetByIdEF(int.Parse(Console.ReadLine()));
            if (result.Correct)
            {
                ML.Usuario usuario = ((ML.Usuario)result.Object);

                Console.WriteLine("IdUsuario: " + usuario.IdUsuario);
                Console.WriteLine("Nombre: " + usuario.Nombre);
                Console.WriteLine("ApellidoPaterno: " + usuario.ApellidoPaterno);
                Console.WriteLine("Apellido Materno: " + usuario.ApellidoMaterno);
                Console.WriteLine("Telefono: " + usuario.Telefono);
                Console.WriteLine("IdRol: " + usuario.Rol.IdRol);
                Console.WriteLine("UserName: " + usuario.UserName);
                Console.WriteLine("Email: " + usuario.Email);
                Console.WriteLine("Password: " + usuario.Password);
                Console.WriteLine("FechaNacimiento: " + usuario.FechaNacimiento);
                Console.WriteLine("Sexo: " + usuario.Sexo);
                Console.WriteLine("Celular: " + usuario.Celular);
                Console.WriteLine("CURP: " + usuario.CURP);
            }
            else
            {
                Console.WriteLine("Error al realizar la consulta" + result.ErrorMessage);
            }
        }
    }
}
