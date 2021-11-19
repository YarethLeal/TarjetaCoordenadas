using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AUTCoordenadasEntities.Entities;

namespace AUTCoordenadasAccesoDatos.Data
{
    public class DataMensaje
    {
        private SqlConnection sqlConnection;
        private SqlCommand sqlCommand;

        public DataMensaje()
        {
            sqlConnection = new SqlConnection("Data Source=163.178.107.10;Initial Catalog=Sistema_DobleAutenticacion;Persist Security Info=True;User ID=laboratorios;Password=KmZpo.2796;Pooling=False");
            sqlCommand = new SqlCommand();
        }

        public string obtenerMensajes(Usuario datosUsuario)
        {
            string salida = "";
            List<Mensaje> mensajes = new List<Mensaje>();
            sqlCommand = new SqlCommand("SP_ObtenerMensajes", sqlConnection);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlConnection.Open();
            using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Mensaje mensaje = new Mensaje();

                    DataRow dr = dt.Rows[i];
                    string[] allColumns = dr.ItemArray.Select(obj => obj.ToString()).ToArray();
                    ArrayList itm = new ArrayList(allColumns);

                    mensaje.accion = itm[2].ToString();
                    mensaje.fecha = itm[3].ToString();
                    mensaje.usuario = itm[4].ToString();

                    //usuario.usuario = itm[0].ToString();
                    // p.nombre = itm[0].ToString();

                    //salida += "/";
                    salida += mensaje.accion;
                    salida += "-";
                    salida += mensaje.fecha;
                    salida += "-";
                    salida += mensaje.usuario;
                    salida += ".";

                    mensajes.Add(mensaje);

                }

            };
            sqlConnection.Close();

            return salida;
        }// obtenerMensajes

        public string rechazarSolicitud(Mensaje datosMensaje)
        {
            string salida = "Solicitud tarjeta";
            if (String.Equals(datosMensaje.accion, salida))
            {
                salida = rechazarSolicitudTarjeta(datosMensaje);
            }
            else
            {
                salida = rechazarSolicitudDesbloqueo(datosMensaje);
            }//else

            return salida;
        }// rechazarSolicitud

        public string aceptarSolicitud(Mensaje datosMensaje)
        {
            string salida = "Solicitud tarjeta";
            if (String.Equals(datosMensaje.accion, salida))
            {
                salida = aceptarSolicitudTarjeta(datosMensaje);
            }
            else
            {
                salida = aceptarSolicitudDesbloqueo(datosMensaje);
            }//else

            return salida;
        }// aceptarSolicitud

        public string rechazarSolicitudTarjeta(Mensaje datosMensaje)
        {
            string salida = "Enviado";
            sqlConnection.Open();
            sqlCommand = new SqlCommand("SP_RechazarSolicitudTarjeta", sqlConnection);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            //  @idUsuario int, @idAdministrador int, @motivo varchar(255)
            sqlCommand.Parameters.AddWithValue("@idUsuario", datosMensaje.usuario);
            sqlCommand.Parameters.AddWithValue("@idAdministrador", datosMensaje.administrador);
            sqlCommand.Parameters.AddWithValue("@motivo ", datosMensaje.motivo);

            sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return salida;
        }// rechazarSolicitudTarjeta

        public string rechazarSolicitudDesbloqueo(Mensaje datosMensaje)
        {
            string salida = "Enviado";
            sqlConnection.Open();
            sqlCommand = new SqlCommand("SP_RechazarSolicitudDesbloqueo", sqlConnection);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            //  @idUsuario int, @idAdministrador int, @motivo varchar(255)
            sqlCommand.Parameters.AddWithValue("@idUsuario", datosMensaje.usuario);
            sqlCommand.Parameters.AddWithValue("@idAdministrador", datosMensaje.administrador);
            sqlCommand.Parameters.AddWithValue("@motivo ", datosMensaje.motivo);

            sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return salida;
        }// rechazarSolicitudDesbloqueo

        public string aceptarSolicitudTarjeta(Mensaje datosMensaje)
        {
            string salida = "Enviado";
            sqlConnection.Open();
            sqlCommand = new SqlCommand("SP_AceptarSolicitudTarjeta", sqlConnection);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            //  @idUsuario int, @idAdministrador int, @motivo varchar(255)
            sqlCommand.Parameters.AddWithValue("@idUsuario", datosMensaje.usuario);
            sqlCommand.Parameters.AddWithValue("@idAdministrador", datosMensaje.administrador);
            sqlCommand.Parameters.AddWithValue("@motivo ", datosMensaje.motivo);

            sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return salida;
        }// aceptarSolicitudTarjeta

        public string aceptarSolicitudDesbloqueo(Mensaje datosMensaje)
        {
            string salida = "Enviado";
            sqlConnection.Open();
            sqlCommand = new SqlCommand("SP_AceptarSolicitudDesbloqueo", sqlConnection);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            //  @idUsuario int, @idAdministrador int, @motivo varchar(255)
            sqlCommand.Parameters.AddWithValue("@idUsuario", datosMensaje.usuario);
            sqlCommand.Parameters.AddWithValue("@idAdministrador", datosMensaje.administrador);
            sqlCommand.Parameters.AddWithValue("@motivo ", datosMensaje.motivo);

            sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return salida;
        }// aceptarSolicitudDesbloqueo


    }
}