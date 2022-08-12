using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Producto
    {
        public static void Add()
        {
            ML.Producto producto = new ML.Producto();

            Console.WriteLine("Escribe el nombre del producto");
            producto.Nombre = Console.ReadLine();

            Console.WriteLine("Ingresa el precio unitario");
            producto.PrecioUnitario = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa el stock");
            producto.Stock = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa la descripcion");
            producto.Descripcion = Console.ReadLine();

            producto.Proveedor = new ML.Proveedor();
            Console.WriteLine("Ingresa el Id del proveedor");
            producto.Proveedor.IdProveedor = int.Parse(Console.ReadLine());

            producto.Departamento = new ML.Departamento();
            Console.WriteLine("Ingresa el Id del departamento");
            producto.Departamento.IdDepartamento = int.Parse(Console.ReadLine());

            ML.Result result = BL.Producto.Add(producto);

            if (result.Correct)
            {
                Console.WriteLine("Registro exitoso");
            }
            else
            {
                Console.WriteLine("Error al registrar producto");
            }
        }

        public static void Update()
        {
            ML.Producto producto = new ML.Producto();

            Console.WriteLine("Ingresa un Id para modificar el registro");
            producto.IdProducto = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa el nuevo producto");
            producto.Nombre = Console.ReadLine();

            Console.WriteLine("Ingresa el nuevo precio");
            producto.PrecioUnitario = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa el nuevo stock");
            producto.Stock = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa la nueva descripcion");
            producto.Descripcion = Console.ReadLine();

            producto.Proveedor = new ML.Proveedor();
            Console.WriteLine("Ingresa el nuevo Id del proveeedor");
            producto.Proveedor.IdProveedor = int.Parse(Console.ReadLine());

            producto.Departamento = new ML.Departamento();
            Console.WriteLine("Ingresa el nuevo id del departamento");
            producto.Departamento.IdDepartamento = int.Parse(Console.ReadLine());

            ML.Result result = BL.Producto.Update(producto);

            if (result.Correct)
            {
                Console.WriteLine("Registro actualizado con exito");
            }
            else
            {
                Console.WriteLine("Error al actualizar el registro");
            }
        }

        public static void Delete()
        {
            ML.Producto producto = new ML.Producto();

            Console.WriteLine("Ingresa el ID que deseas eliminar");
            producto.IdProducto = int.Parse(Console.ReadLine());

            ML.Result result = BL.Producto.Delete(producto);

            if (result.Correct)
            {
                Console.WriteLine("Registro eliminado exitosamente");
            }
            else
            {
                Console.WriteLine("Error al eliminar el registro");
            }
        }

        public static void GetAll(ML.Producto productoBusqueda)
        {
            ML.Result result = BL.Producto.GetAll(productoBusqueda);

            if (result.Correct)
            {
                foreach (ML.Producto producto in result.Objects)
                {
                    Console.WriteLine("Id producto:"     + producto.IdProducto);
                    Console.WriteLine("Nombre:"          + producto.Nombre);
                    Console.WriteLine("PrecioUnitario:"  + producto.PrecioUnitario);
                    Console.WriteLine("Stock:"           + producto.Stock);
                    Console.WriteLine("Descripcion:"     + producto.Descripcion);
                    Console.WriteLine("Id proveedor:"    + producto.Proveedor.IdProveedor);
                    Console.WriteLine("Id departamento:" + producto.Departamento.IdDepartamento);
                    Console.WriteLine("-------------------------------------------------------");
                }
            }
            else
            {
                Console.WriteLine("Error al consultar los datos");
            }
        }
        public static void GetById()
        {
            Console.WriteLine("Ingresa el id que deseas consultar");
            
            ML.Result result = BL.Producto.GetById(int.Parse(Console.ReadLine()));

            if (result.Correct)
            {
                ML.Producto producto = ((ML.Producto)result.Object);

                Console.WriteLine("IdProducto:"     + producto.IdProducto);
                Console.WriteLine("Nombre:"         + producto.Nombre);
                Console.WriteLine("PrecioUnitario:" + producto.PrecioUnitario);
                Console.WriteLine("Stock:"          + producto.Stock);
                Console.WriteLine("Descripcion:"    + producto.Descripcion);
                Console.WriteLine("IdProveedor:"    + producto.Proveedor.IdProveedor);
                Console.WriteLine("IdDepartamento:" + producto.Departamento.IdDepartamento);
            }
            else
            {
                Console.WriteLine("Eror al realizar la consulta" + result.ErrorMessage);
            }
        }
    }
}
