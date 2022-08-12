using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Globalization;

namespace BL
{
    public class Usuario
    {
        ///////////////////////////////Añadir
        public static ML.Result Add(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    string query = "INSERT INTO [Usuario] ([Nombre],[ApellidoPaterno],[ApellidoMaterno],[Edad],[Telefono]) VALUES (@Nombre, @ApellidoPaterno, @ApellidoMaterno, @Edad, @Telefono)";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;

                        SqlParameter[] collection = new SqlParameter[5];

                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = usuario.Nombre;

                        collection[1] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                        collection[1].Value = usuario.ApellidoPaterno;

                        collection[2] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                        collection[2].Value = usuario.ApellidoMaterno;

                        collection[4] = new SqlParameter("Telefono", SqlDbType.VarChar);
                        collection[4].Value = usuario.Telefono;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }

                    }

                }
            }
            catch (Exception Ex)
            {
                result.Correct = false;
                result.ErrorMessage = Ex.Message;
            }
            return result;
        }

        //////////////////////////////Actualizar
        public static ML.Result Update(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    string query = "UPDATE [Usuario] SET [Nombre]= @Nombre , [ApellidoPaterno]= @ApellidoPaterno, [ApellidoMaterno]=@ApellidoMaterno, [Edad]=@Edad, [Telefono]=@Telefono WHERE IdUsuario = @IdUsuario";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;

                        SqlParameter[] collection = new SqlParameter[6];

                        collection[0] = new SqlParameter("IdUsuario", SqlDbType.Int);
                        collection[0].Value = usuario.IdUsuario;

                        collection[1] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[1].Value = usuario.Nombre;

                        collection[2] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                        collection[2].Value = usuario.ApellidoPaterno;

                        collection[3] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                        collection[3].Value = usuario.ApellidoMaterno;

                        /* collection[4] = new SqlParameter("Edad", SqlDbType.Int);
                         collection[4].Value = usuario.Edad;*/

                        collection[5] = new SqlParameter("Telefono", SqlDbType.VarChar);
                        collection[5].Value = usuario.Telefono;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();
                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }


                    }
                }
            }
            catch (Exception Ex)
            {
                result.Correct = false;
                result.ErrorMessage = Ex.Message;
            }
            return result;

        }

        //////////////////////////////Borrar
        public static ML.Result Delete(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    string query = "DELETE FROM [Usuario] WHERE IdUsuario = @IdUsuario";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdUsuario", SqlDbType.Int);
                        collection[0].Value = usuario.IdUsuario;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                result.Correct = false;
                result.ErrorMessage = Ex.Message;
            }
            return result;
        }

        ///////////////////////////////AñadirSP
        public static ML.Result AddSP(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    string query = "UsuarioAdd";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[6];

                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = usuario.Nombre;

                        collection[1] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                        collection[1].Value = usuario.ApellidoPaterno;

                        collection[2] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                        collection[2].Value = usuario.ApellidoMaterno;

                        /*collection[3] = new SqlParameter("Edad", SqlDbType.Int);
                        collection[3].Value = usuario.Edad;*/

                        collection[4] = new SqlParameter("Telefono", SqlDbType.VarChar);
                        collection[4].Value = usuario.Telefono;

                        collection[5] = new SqlParameter("IdRol", SqlDbType.Int);
                        collection[5].Value = usuario.Rol.IdRol;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
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

        ///////////////////////////////BorrarSP
        public static ML.Result DeleteSP(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    string query = "UsuarioDelete";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdUsuario", SqlDbType.Int);
                        collection[0].Value = usuario.IdUsuario;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                result.Correct = false;
                result.ErrorMessage = Ex.Message;
            }
            return result;

        }

        ///////////////////////////////ActualizarSP
        public static ML.Result UpdateSP(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    string query = "UsuarioUpdate";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[7];

                        collection[0] = new SqlParameter("IdUsuario", SqlDbType.Int);
                        collection[0].Value = usuario.IdUsuario;

                        collection[1] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[1].Value = usuario.Nombre;

                        collection[2] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                        collection[2].Value = usuario.ApellidoPaterno;

                        collection[3] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                        collection[3].Value = usuario.ApellidoMaterno;

                        /*collection[4] = new SqlParameter("Edad", SqlDbType.Int);
                        collection[4].Value = usuario.Edad;*/

                        collection[5] = new SqlParameter("Telefono", SqlDbType.VarChar);
                        collection[5].Value = usuario.Telefono;

                        collection[6] = new SqlParameter("IdRol", SqlDbType.Int);
                        collection[6].Value = usuario.Rol.IdRol;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                result.Correct = false;
                result.ErrorMessage = Ex.Message;
            }
            return result;
        }

        ///////////////////////////////ConsultarSP
        public static ML.Result GetAllSP()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    string query = "UsuarioGetALL";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        DataTable TableUsuario = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        da.Fill(TableUsuario);

                        if (TableUsuario.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();

                            foreach (DataRow row in TableUsuario.Rows)
                            {
                                ML.Usuario usuario = new ML.Usuario();

                                usuario.IdUsuario = int.Parse(row[0].ToString());
                                usuario.Nombre = row[1].ToString();
                                usuario.ApellidoPaterno = row[2].ToString();
                                usuario.ApellidoMaterno = row[3].ToString();
                                //usuario.Edad            = int.Parse(row[4].ToString());
                                usuario.Telefono = row[5].ToString();

                                usuario.Rol = new ML.Rol();
                                usuario.Rol.IdRol = (byte)int.Parse(row[6].ToString());

                                result.Objects.Add(usuario);
                            }

                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
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

        ///////////////////////////////ConsultarUnoSP
        public static ML.Result GetByIdSP(int IdUsuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    string query = "UsuarioGetById";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdUsuario", SqlDbType.Int);
                        collection[0].Value = IdUsuario;

                        cmd.Parameters.AddRange(collection);

                        DataTable tableUsuario = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(tableUsuario);

                        if (tableUsuario.Rows.Count > 0)
                        {

                            DataRow row = tableUsuario.Rows[0];


                            ML.Usuario usuario = new ML.Usuario();
                            usuario.IdUsuario = int.Parse(row[0].ToString());
                            usuario.Nombre = row[1].ToString();
                            usuario.ApellidoPaterno = row[2].ToString();
                            usuario.ApellidoMaterno = row[3].ToString();
                            usuario.Telefono = row[5].ToString();

                            usuario.Rol = new ML.Rol();

                            usuario.Rol.IdRol = (byte)int.Parse(row[6].ToString());

                            result.Object = usuario;
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }

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

        ///////////////////////////////AñadirEF
        public static ML.Result AddEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.APozosProgramacionNCapasEntities context = new DL_EF.APozosProgramacionNCapasEntities())
                {

                    var query = context.UsuarioAdd(usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno,
                    usuario.Telefono, usuario.Rol.IdRol, usuario.UserName, usuario.Email, usuario.Password,
                    usuario.FechaNacimiento, usuario.Sexo, usuario.Celular, usuario.CURP, null, usuario.Status = true, usuario.Direccion.Calle,
                    usuario.Direccion.NumeroInterior, usuario.Direccion.NumeroExterior,usuario.Direccion.Colonia.IdColonia);

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

        ///////////////////////////////ActualizarEF
        public static ML.Result UpdateEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.APozosProgramacionNCapasEntities context = new DL_EF.APozosProgramacionNCapasEntities())
                {
                    var query = context.UsuarioUpdate(usuario.IdUsuario, usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno,
                    usuario.Telefono, usuario.Rol.IdRol, usuario.UserName, usuario.Email, usuario.Password,
                    usuario.FechaNacimiento, usuario.Sexo, usuario.Celular, usuario.CURP, null,usuario.Status, usuario.Direccion.IdDireccion, usuario.Direccion.Calle,
                    usuario.Direccion.NumeroInterior, usuario.Direccion.NumeroExterior,usuario.Direccion.Colonia.IdColonia);

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

        ///////////////////////////////BorrarEF
        public static ML.Result DeleteEF(int IdUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.APozosProgramacionNCapasEntities context = new DL_EF.APozosProgramacionNCapasEntities())
                {
                    var query = context.UsuarioDelete(IdUsuario);
                    
                    if(query > 0)
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

        ///////////////////////////////ConsultarEF

        public static ML.Result GetAllEF(ML.Usuario usuarioBusqueda)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.APozosProgramacionNCapasEntities context = new DL_EF.APozosProgramacionNCapasEntities())
                {
                    var query = context.UsuarioGetAll(usuarioBusqueda.Nombre, usuarioBusqueda.ApellidoPaterno, usuarioBusqueda.ApellidoMaterno).ToList();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.Usuario usuario = new ML.Usuario();

                            usuario.IdUsuario       = obj.IdUsuario;
                            usuario.Nombre          = obj.Nombre;
                            usuario.ApellidoPaterno = obj.ApellidoPaterno;
                            usuario.ApellidoMaterno = obj.ApellidoMaterno;
                            usuario.Telefono        = obj.Telefono;

                            usuario.Rol             = new ML.Rol();
                            usuario.Rol.IdRol       = obj.IdRol.Value;

                            usuario.UserName        = obj.UserName;
                            usuario.Email           = obj.Email;
                            usuario.Password        = obj.Password;
                            usuario.FechaNacimiento = obj.FechaNacimiento.ToString();
                            usuario.Sexo            = obj.Sexo;
                            usuario.Celular         = obj.Celular;
                            usuario.CURP            = obj.CURP;
                            usuario.Imagen          = obj.Imagen;
                            usuario.Rol.Nombre      = obj.NombreRol;
                            usuario.Status          = obj.Status;

                            usuario.Direccion                = new ML.Direccion();
                            usuario.Direccion.IdDireccion    = obj.IdDireccion;
                            usuario.Direccion.Calle          = obj.Calle;
                            usuario.Direccion.NumeroInterior = obj.NumeroInterior;
                            usuario.Direccion.NumeroExterior = obj.NumeroExterior;

                            usuario.Direccion.Colonia              = new ML.Colonia();
                            usuario.Direccion.Colonia.IdColonia    = obj.IdColonia;
                            usuario.Direccion.Colonia.Nombre       = obj.NombreColonia;
                            usuario.Direccion.Colonia.CodigoPostal = obj.CodigoPostal;

                            usuario.Direccion.Colonia.Municipio             = new ML.Municipio();
                            usuario.Direccion.Colonia.Municipio.IdMunicipio = obj.IdMunicipio.Value;
                            usuario.Direccion.Colonia.Municipio.Nombre      = obj.NombreMunicipio;

                            usuario.Direccion.Colonia.Municipio.Estado          = new ML.Estado();
                            usuario.Direccion.Colonia.Municipio.Estado.IdEstado = obj.IdEstado.Value;
                            usuario.Direccion.Colonia.Municipio.Estado.Nombre   = obj.NombreEstado;

                            usuario.Direccion.Colonia.Municipio.Estado.Pais        = new ML.Pais();
                            usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais = obj.IdPais.Value;
                            usuario.Direccion.Colonia.Municipio.Estado.Pais.Nombre = obj.NombrePais;

                            result.Objects.Add(usuario);
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

        ///////////////////////////////ConsultarUnoEF
        public static ML.Result GetByIdEF(int IdUsuario)

        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.APozosProgramacionNCapasEntities context = new DL_EF.APozosProgramacionNCapasEntities())
                {
                    var obj = context.UsuarioGetById(IdUsuario).FirstOrDefault();

                    if (obj != null)
                    {
                        ML.Usuario usuario = new ML.Usuario();
                        usuario.IdUsuario = obj.IdUsuario;
                        usuario.Nombre = obj.Nombre;
                        usuario.ApellidoPaterno = obj.ApellidoPaterno;
                        usuario.ApellidoMaterno = obj.ApellidoMaterno;
                        usuario.Telefono        = obj.Telefono;

                        usuario.Rol             = new ML.Rol();
                        usuario.Rol.IdRol       = obj.IdRol.Value;

                        usuario.UserName        = obj.UserName;
                        usuario.Email           = obj.Email;
                        usuario.Password        = obj.Password;
                        usuario.FechaNacimiento = obj.FechaNacimiento.ToString();
                        usuario.Sexo            = obj.Sexo;
                        usuario.Celular         = obj.Celular;
                        usuario.CURP            = obj.CURP;
                        usuario.Imagen          = obj.Imagen;

                        usuario.Direccion                = new ML.Direccion();
                        usuario.Direccion.IdDireccion    = obj.IdDireccion;
                        usuario.Direccion.Calle          = obj.Calle;
                        usuario.Direccion.NumeroInterior = obj.NumeroInterior;
                        usuario.Direccion.NumeroExterior = obj.NumeroExterior;

                        usuario.Direccion.Colonia              = new ML.Colonia();
                        usuario.Direccion.Colonia.IdColonia    = obj.IdColonia;
                        usuario.Direccion.Colonia.Nombre       = obj.NombreColonia;
                        usuario.Direccion.Colonia.CodigoPostal = obj.CodigoPostal;

                        usuario.Direccion.Colonia.Municipio             = new ML.Municipio();
                        usuario.Direccion.Colonia.Municipio.IdMunicipio = obj.IdMunicipio.Value;
                        usuario.Direccion.Colonia.Municipio.Nombre      = obj.NombreMunicipio;

                        usuario.Direccion.Colonia.Municipio.Estado          = new ML.Estado();
                        usuario.Direccion.Colonia.Municipio.Estado.IdEstado = obj.IdEstado.Value;
                        usuario.Direccion.Colonia.Municipio.Estado.Nombre   = obj.NombreEstado;

                        usuario.Direccion.Colonia.Municipio.Estado.Pais        = new ML.Pais();
                        usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais = obj.IdPais.Value;
                        usuario.Direccion.Colonia.Municipio.Estado.Pais.Nombre = obj.NombrePais;

                        result.Object = usuario;
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

        ///////////////////////////////AñadirLINQ
        
        public static ML.Result AddLINQ(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            
            try
            {
                using (DL_EF.APozosProgramacionNCapasEntities context = new DL_EF.APozosProgramacionNCapasEntities())
                {
                    DL_EF.Usuario usuarioLinq = new DL_EF.Usuario();

                    usuarioLinq.Nombre          = usuario.Nombre;
                    usuarioLinq.ApellidoPaterno = usuario.ApellidoPaterno;
                    usuarioLinq.ApellidoMaterno = usuario.ApellidoMaterno;
                    usuarioLinq.Telefono        = usuario.Telefono;
                    usuarioLinq.IdRol           = usuario.Rol.IdRol;
                    usuarioLinq.UserName        = usuario.UserName;
                    usuarioLinq.Email           = usuario.Email;
                    usuarioLinq.Password        = usuario.Password;
                    usuarioLinq.FechaNacimiento = DateTime.ParseExact(usuario.FechaNacimiento, "dd-mm-yyyy",CultureInfo.InvariantCulture);
                    usuarioLinq.Sexo            = usuario.Sexo;
                    usuarioLinq.Celular         = usuario.Celular;
                    usuarioLinq.CURP            = usuario.CURP;
                   // usuarioLinq.Imagen          = usuario.Imagen;

                    if (usuarioLinq != null)
                    {
                        context.Usuarios.Add(usuarioLinq);
                        context.SaveChanges();
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

        ///////////////////////////////ActualizarLINQ

        public static ML.Result UpdateLINQ(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.APozosProgramacionNCapasEntities context = new DL_EF.APozosProgramacionNCapasEntities())
                {
                    var usuarioLinq = (from a in context.Usuarios
                                       where a.IdUsuario == usuario.IdUsuario
                                       select a).SingleOrDefault();
                    if (usuarioLinq != null)
                    {
                        usuarioLinq.IdUsuario = usuario.IdUsuario;
                        usuarioLinq.Nombre = usuario.Nombre;
                        usuarioLinq.ApellidoPaterno = usuario.ApellidoPaterno;
                        usuarioLinq.ApellidoMaterno = usuario.ApellidoMaterno;
                        usuarioLinq.Telefono = usuario.Telefono;
                        usuarioLinq.IdRol = usuario.Rol.IdRol;
                        usuarioLinq.UserName = usuario.UserName;
                        usuarioLinq.Email = usuario.Email;
                        usuarioLinq.Password = usuario.Password;
                        usuarioLinq.FechaNacimiento = DateTime.ParseExact(usuario.FechaNacimiento, "dd-mm-yyyy", CultureInfo.InvariantCulture);
                        usuarioLinq.Sexo = usuario.Sexo;
                        usuarioLinq.Celular = usuario.Celular;
                        usuario.CURP = usuario.CURP;
                        usuario.Imagen = usuario.Imagen;

                        context.SaveChanges();
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

        ///////////////////////////////EliminarLINQ
        public static ML.Result DeleteLINQ(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.APozosProgramacionNCapasEntities context = new DL_EF.APozosProgramacionNCapasEntities())
                {
                    var usuarioLinq = (from a in context.Usuarios
                                       where a.IdUsuario == usuario.IdUsuario
                                       select a).First();

                    context.Usuarios.Remove(usuarioLinq);
                    context.SaveChanges();
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        ///////////////////////////////GetAllLINQ
        
        public static ML.Result GetAllLINQ()
        {
            ML.Result result = new ML.Result();
            
            try
            {
                using (DL_EF.APozosProgramacionNCapasEntities context = new DL_EF.APozosProgramacionNCapasEntities())
                {
                    var usuarioLinq = (from usuario in context.Usuarios
                                       where usuario.IdUsuario == usuario.IdUsuario
                                       select new
                                       {
                                           IdUsuario       = usuario.IdUsuario,
                                           Nombre          = usuario.Nombre,
                                           ApellidoPaterno = usuario.ApellidoPaterno,
                                           ApellidoMaterno = usuario.ApellidoMaterno,
                                           Telefono        = usuario.Telefono,
                                           IdRol           = usuario.Rol.IdRol,
                                           UserName        = usuario.UserName,
                                           Email           = usuario.Email,
                                           Password        = usuario.Password,
                                           FechaNacimiento = usuario.FechaNacimiento,
                                           Sexo            = usuario.Sexo,
                                           Celular         = usuario.Celular,
                                           CURP            = usuario.CURP,
                                           Imagen          = usuario.Imagen
                                       });
                    result.Objects = new List<object>();
                    if (usuarioLinq != null && usuarioLinq.ToList().Count > 0)
                    {
                        foreach (var obj in usuarioLinq)
                        {
                            ML.Usuario usuario = new ML.Usuario();

                            usuario.IdUsuario       = obj.IdUsuario;
                            usuario.Nombre          = obj.Nombre;
                            usuario.ApellidoPaterno = obj.ApellidoPaterno;
                            usuario.ApellidoMaterno = obj.ApellidoMaterno;
                            usuario.Telefono        = obj.Telefono;

                            usuario.Rol             = new ML.Rol();
                            usuario.Rol.IdRol       = obj.IdRol;
                            usuario.UserName        = obj.UserName;
                            usuario.Email           = obj.Email;
                            usuario.Password        = obj.Password;
                            usuario.FechaNacimiento = obj.FechaNacimiento.ToString();
                            usuario.Sexo            = obj.Sexo;
                            usuario.Celular         = obj.Celular;
                            usuario.CURP            = obj.CURP;
                          //  usuario.Imagen          = obj.Imagen;

                            result.Objects.Add(usuario);
                        }
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
            return result;
        }

        ///////////////////////////////GetAllLINQ
        
        public static ML.Result GetByIdLINQ(int IdUsuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.APozosProgramacionNCapasEntities context = new DL_EF.APozosProgramacionNCapasEntities())
                {
                    var obj = context.UsuarioGetById(IdUsuario).FirstOrDefault();
                    if (obj != null)
                    {
                        ML.Usuario usuario = new ML.Usuario();

                        usuario.IdUsuario       = obj.IdUsuario;
                        usuario.Nombre          = obj.Nombre;
                        usuario.ApellidoPaterno = obj.ApellidoPaterno;
                        usuario.ApellidoMaterno = obj.ApellidoMaterno;
                        usuario.Telefono        = obj.Telefono;

                        usuario.Rol             = new ML.Rol();
                        usuario.Rol.IdRol       = obj.IdRol.Value;
                        usuario.UserName        = obj.UserName;
                        usuario.Email           = obj.Email;
                        usuario.Password        = obj.Password;
                        usuario.FechaNacimiento = obj.FechaNacimiento.ToString();
                        usuario.Sexo            = obj.Sexo;
                        usuario.Celular         = obj.Celular;
                        usuario.CURP            = obj.CURP;
                        usuario.Imagen          = obj.Imagen;

                        result.Object = usuario;
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
