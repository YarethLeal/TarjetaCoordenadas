using AUTCoordenadasAccesoADatos.Contexts;
using AUTCoordenadasEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace AUTCoordenadasAccesoADatos.Data
{
    public class DataUsuario
    {
        private SqlConnection sqlConnection;
        private SqlCommand sqlCommand;

        public DataUsuario()
        {
            sqlConnection = new SqlConnection("Data Source=163.178.107.10;Initial Catalog=Sistema_DobleAutenticacion;Persist Security Info=True;User ID=laboratorios;Password=KmZpo.2796;Pooling=False");
            sqlCommand = new SqlCommand();
        }

        public string iniciarSesion(Usuario datosUsuario)
        {
            //  List<Tarjeta> listaValida = new List<Tarjeta>();
            string salida = "NULL";
            sqlConnection.Open();
            sqlCommand = new SqlCommand("SP_InicioSesion", sqlConnection);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@Usuario", datosUsuario.usuario);
            sqlCommand.Parameters.AddWithValue("@Contrasena", datosUsuario.Contrasena);

            sqlCommand.ExecuteNonQuery();
            using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Usuario usuario = new Usuario();

                    DataRow dr = dt.Rows[i];
                    string[] allColumns = dr.ItemArray.Select(obj => obj.ToString()).ToArray();
                    ArrayList itm = new ArrayList(allColumns);

                    usuario.usuario = itm[0].ToString();
                    // p.nombre = itm[0].ToString();

                    salida = usuario.usuario;
                    //  listaValida.Add(tarjeta);

                }

            };
            sqlConnection.Close();

            return salida;
        }

        public string estadoTarjeta(Usuario datosUsuario)
        {
            string resultado = "NULL";
            sqlConnection.Open();
            sqlCommand = new SqlCommand("SP_ValidarEstadoTarjeta", sqlConnection);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@IdUsuario", datosUsuario.Id);

            sqlCommand.ExecuteNonQuery();
            using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Usuario usuario = new Usuario();

                    DataRow dr = dt.Rows[i];
                    string[] allColumns = dr.ItemArray.Select(obj => obj.ToString()).ToArray();
                    ArrayList itm = new ArrayList(allColumns);

                    usuario.usuario = itm[0].ToString();
                    // p.nombre = itm[0].ToString();

                    resultado = usuario.usuario;
                    //  listaValida.Add(tarjeta);

                }

            };
            sqlConnection.Close();

            return resultado;
        }// tiene tarjeta

        public string contarIntento(Usuario datosUsuario)
        {
            string resultado = "NULL";
            sqlConnection.Open();
            sqlCommand = new SqlCommand("SP_SumarError", sqlConnection);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@idUsuario", datosUsuario.Id);


            sqlCommand.ExecuteNonQuery();
            using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    DataRow dr = dt.Rows[i];
                    string[] allColumns = dr.ItemArray.Select(obj => obj.ToString()).ToArray();
                    ArrayList itm = new ArrayList(allColumns);

                    resultado = itm[0].ToString();

                }

            };
            sqlConnection.Close();


            return resultado;
        }// contarIntento

        public string limpiarIntentos(Usuario datosUsuario)
        {
            string resultado = "NULL";
            sqlConnection.Open();
            sqlCommand = new SqlCommand("SP_QuitarIntentos", sqlConnection);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@idUsuario", datosUsuario.Id);

            sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return resultado;
        }// limpiarIntentos

        public string solicitudTarjeta(Usuario datosUsuario)
        {
            string resultado = "NULL";
            sqlConnection.Open();
            sqlCommand = new SqlCommand("SP_SolicitudTarjeta", sqlConnection);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            /*
            sqlCommand.Parameters.AddWithValue("@idUsuario", datosUsuario.Id);
            sqlCommand.Parameters.AddWithValue("@motivo ", datosUsuario.Observaciones);
            */
            sqlCommand.Parameters.AddWithValue("@idUsuario", datosUsuario.Id);
            sqlCommand.Parameters.AddWithValue("@motivo ", datosUsuario.Observaciones);

            sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return resultado;
        }// tiene tarjeta


        public async Task<String> Registrar(Usuario usuario)
        {

            using (var _context = new BDContexts())
            {
                try
                {
                    _context.tb_Usuario.Add(usuario);
                    await _context.SaveChangesAsync();

                }
                catch (DbUpdateException e/* ex */)
                {
                    System.Diagnostics.Debug.WriteLine(e.ToString());
                    //Log the error (uncomment ex variable name and write a log.
                    return "No se pueden guardar los cambios. " +
                       "Vuelve a intentarlo y, si el problema persiste, " +
                       "consulte con el administrador del sistema.";
                }
            }
            return "Usuario registrado";
        }
        public async Task<List<Usuario>> ListaUsuarios()
        {
            using (var _context = new BDContexts())
            {
                return await _context.tb_Usuario.Where(x => x.Eliminado == false).ToListAsync();
            }

        }

        public async Task<String> Actualizar(Usuario usuarioParam)
        {

            try
            {
                using (var _context = new BDContexts())
                {

                    var usuario = _context.tb_Usuario.First(a => a.Id == usuarioParam.Id);
                    System.Diagnostics.Debug.WriteLine("Esta es la respuesta: " + usuario.ToString());
                    usuario.usuario = usuarioParam.usuario;
                    usuario.Correo = usuarioParam.Correo;
                    usuario.OficinaID = usuarioParam.OficinaID;
                    await _context.SaveChangesAsync();
                }
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return "No se pueden guardar los cambios. " +
                    "Vuelve a intentarlo y, si el problema persiste, " +
                    "consulte con el administrador del sistema.";
            }
            return "Usuario actualizado";
        }

        public async Task<String> Eliminar(int id)
        {
            try
            {
                using (var _context = new BDContexts())
                {
                    var usuario = _context.tb_Usuario.First(a => a.Id == id);
                    System.Diagnostics.Debug.WriteLine("Esta es la respuesta elimina: " + usuario.usuario);
                    usuario.Eliminado = true;
                    await _context.SaveChangesAsync();

                }
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return "No se puede eliminar. " +
                     "Vuelve a intentarlo y, si el problema persiste, " +
                     "consulte con el administrador del sistema.";
            }
            return "Usuario eliminado con exito";
        }

        public async Task<List<Usuario>> BuscarNombre(string nombre)
        {
            using (var _context = new BDContexts())
            {
                List<Usuario> usuario = await _context.tb_Usuario.Where(x => x.usuario.StartsWith(nombre)).ToListAsync();
                System.Diagnostics.Debug.WriteLine("Lista: " + usuario.ToArray());
                if (usuario == null)
                {
                    return null;
                }
                return usuario;
            }
        }

        public async Task<Usuario> BuscarId(int id)
        {
            using (var _context = new BDContexts())
            {
                var usuario = await _context.tb_Usuario.FindAsync(id);
                if (usuario == null)
                {
                    return null;
                }
                return usuario;
            }
        }
    }
}