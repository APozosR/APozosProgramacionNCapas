using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Producto
    {
        public static ML.Result Add(ML.Producto producto)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.APozosProgramacionNCapasEntities context = new DL_EF.APozosProgramacionNCapasEntities())
                {
                    var query = context.ProductoAdd(producto.Nombre, producto.PrecioUnitario, producto.Stock, producto.Descripcion,
                        producto.Imagen, producto.Proveedor.IdProveedor, producto.Departamento.IdDepartamento);

                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static ML.Result Update(ML.Producto producto)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.APozosProgramacionNCapasEntities context = new DL_EF.APozosProgramacionNCapasEntities())
                {
                    var query = context.ProductoUpdate(producto.IdProducto,producto.Nombre,producto.PrecioUnitario,producto.Stock,
                        producto.Descripcion,producto.Imagen,producto.Proveedor.IdProveedor,producto.Departamento.IdDepartamento);

                    if (query >=1 )
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static ML.Result Delete(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.APozosProgramacionNCapasEntities context = new DL_EF.APozosProgramacionNCapasEntities())
                {
                    var query = context.ProductoDelete(producto.IdProducto);

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return (result);
        }
        public static ML.Result GetAll(ML.Producto productoBusqueda)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.APozosProgramacionNCapasEntities context = new DL_EF.APozosProgramacionNCapasEntities())
                {
                    var query = context.ProductoGetAll(productoBusqueda.Nombre).ToList();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.Producto producto = new ML.Producto();

                            producto.IdProducto                  = obj.IdProducto;
                            producto.Nombre                      = obj.Nombre;
                            producto.PrecioUnitario              = obj.PrecioUnitario;
                            producto.Stock                       = obj.Stock;
                            producto.Descripcion                 = obj.Descripcion;
                            producto.Imagen                      = obj.Imagen;

                            producto.Proveedor                   = new ML.Proveedor();
                            producto.Proveedor.IdProveedor       = obj.IdProveedor.Value;

                            producto.Departamento                = new ML.Departamento();
                            producto.Departamento.IdDepartamento = obj.IdDepartamento.Value;

                            producto.Departamento.Nombre         = obj.NombreDepartamento;
                            producto.Proveedor.Nombre            = obj.NombreProveedor;

                            result.Objects.Add(producto);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static ML.Result GetById(int IdProducto)
        {
            ML.Result result = new ML.Result();
            
            try
            {
                using (DL_EF.APozosProgramacionNCapasEntities context = new DL_EF.APozosProgramacionNCapasEntities())
                {
                    var query = context.ProductoGetById(IdProducto).FirstOrDefault();

                    if (query != null)
                    {
                        ML.Producto producto                 = new ML.Producto();
                        producto.IdProducto                  = query.IdProducto;
                        producto.Nombre                      = query.Nombre;
                        producto.PrecioUnitario              = query.PrecioUnitario;
                        producto.Stock                       = query.Stock;
                        producto.Descripcion                 = query.Descripcion;
                        producto.Imagen                      = query.Imagen;

                        producto.Proveedor                   = new ML.Proveedor();
                        producto.Proveedor.IdProveedor       = query.IdProveedor.Value;

                        producto.Departamento                = new ML.Departamento();
                        producto.Departamento.IdDepartamento = query.IdDepartamento.Value;

                        result.Object = producto;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
    }
}
