using System;
using System.Collections.Generic;
using AUTCoordenadasEntities.Entities;
using System.Data.SqlClient;
using System.Collections;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Text.RegularExpressions;

namespace AUTCoordenadasAccesoDatos.Data
{
    public class DataTarjeta
    {
        private SqlConnection sqlConnection;
        private SqlCommand sqlCommand;

        public DataTarjeta()
        {
            sqlConnection = new SqlConnection("Data Source=163.178.107.10;Initial Catalog=Sistema_DobleAutenticacion;Persist Security Info=True;User ID=laboratorios;Password=KmZpo.2796;Pooling=False");
            sqlCommand = new SqlCommand();
        }

        public string autenticar(Tarjeta datosTarjeta)
        {
           
            string salida = "NULL";
            sqlConnection.Open();
            sqlCommand = new SqlCommand("SP_ValidarCasilla", sqlConnection);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@Id", datosTarjeta.id);
            sqlCommand.Parameters.AddWithValue("@Fila", datosTarjeta.fila);
            sqlCommand.Parameters.AddWithValue("@Columna", datosTarjeta.columna);
            sqlCommand.Parameters.AddWithValue("@Valor", datosTarjeta.valor);

            sqlCommand.ExecuteNonQuery();
            using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Tarjeta tarjeta = new Tarjeta();

                    DataRow dr = dt.Rows[i];
                    string[] allColumns = dr.ItemArray.Select(obj => obj.ToString()).ToArray();
                    ArrayList itm = new ArrayList(allColumns);

                    tarjeta.columna = itm[0].ToString();
                   
                    salida = tarjeta.columna;
               
                }

            };
            sqlConnection.Close();

            //si la salida es distinta a null significa que ese valor es valido
            return salida;
        }

        public string creacionTarjeta(Tarjeta datosTarjeta)
        {
            string salida = "NULL";
            
            List<Tarjeta> listaCasilla = new List<Tarjeta>();
           
            sqlCommand = new SqlCommand("SP_CrearTarjeta", sqlConnection);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlConnection.Open();
            using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Tarjeta tarjeta = new Tarjeta();

                    DataRow dr = dt.Rows[i];
                    string[] allColumns = dr.ItemArray.Select(obj => obj.ToString()).ToArray();
                    ArrayList itm = new ArrayList(allColumns);

                    tarjeta.id = Int32.Parse(itm[0].ToString());
                    tarjeta.fila = Int32.Parse(itm[1].ToString());
                    tarjeta.columna = itm[2].ToString();
                    tarjeta.valor = Int32.Parse(itm[3].ToString());

                    listaCasilla.Add(tarjeta);

                }

            };
            sqlConnection.Close();

            crearImagen(listaCasilla, datosTarjeta.id_usuario);

            return salida;
        }

        private void crearImagen(List<Tarjeta> listaCasilla, int idUsuario)
        {
  
            Bitmap bitMapImage = new System.Drawing.Bitmap((@"C:\\Users\\hp\\Documents\\Github\\TarjetaCoordenadas\\Imagen\\disTarjetaN.jpeg"));
            Graphics graphicImage = Graphics.FromImage(bitMapImage);

            int x = 370;
            int y = 230;
            string valorCasilla = "";
            int contadorASCII = 65;
            int contadorValoresCasilla = 0;
            int idTarjeta = 0;
            for (int fila = 0; fila < 5; fila++)
            {
                for (int columna = 0; columna < 10; columna++)
                {
                    idTarjeta = listaCasilla[contadorValoresCasilla].id;
                    // si es menor a 10 se le pone un 0 adelante
                    if (listaCasilla[contadorValoresCasilla].valor < 10)
                    {
                        valorCasilla = String.Concat("0", listaCasilla[contadorValoresCasilla].valor.ToString());
                    }
                    else
                    {
                        valorCasilla = listaCasilla[contadorValoresCasilla].valor.ToString();
                    }// else

                    graphicImage.DrawString(valorCasilla, new Font("Arial", 11, FontStyle.Bold), SystemBrushes.WindowText, new Point(x, y));

                    if (columna == 1 || columna == 2)
                    {
                        x += 90;
                    }
                    else if (columna == 8)
                    {
                        x += 75;
                    }
                    else
                    {
                        x += 85;
                    }// else 

                    contadorASCII += 1;
                    contadorValoresCasilla += 1;
                }// for columna
                x = 370;
                contadorASCII = 65;
                y += 90;
            }// for fila

            bitMapImage.Save("C:\\Users\\hp\\Documents\\Github\\TarjetaCoordenadas\\Imagen\\tarjetaUsuario"+idUsuario+ ".jpeg", ImageFormat.Jpeg);
            graphicImage.Dispose();
            bitMapImage.Dispose();

            asignarTarjeta(idUsuario, idTarjeta);
        }// crearImagen

        private void asignarTarjeta(int idUsuario, int idTarjeta)
        {
            string correo = "";
            sqlCommand = new SqlCommand("SP_AsignarTarjeta", sqlConnection);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@IdUsuario", idUsuario);
            sqlCommand.Parameters.AddWithValue("@IdTarjeta", idTarjeta);

            sqlConnection.Open();
            using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    string[] allColumns = dr.ItemArray.Select(obj => obj.ToString()).ToArray();
                    ArrayList itm = new ArrayList(allColumns);

                    correo = itm[0].ToString();
                }

            };
            sqlConnection.Close();

            enviarTarjeta(correo,idUsuario);

        }// enviarTarjeta

        private void enviarTarjeta(string correo, int idUsuario)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("correoDeAdministrador@gmail.com");
            mail.To.Add(correo);
            // estructura interna del correo
            string htmlMessage = @"<html>
                         <body>
                         <img src='cid:TarjetaCoordenadas' height=550 width=700/>
                         </body>
                         </html>";

            // Crea una vista de HTML para el correo
            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(htmlMessage, Encoding.UTF8, MediaTypeNames.Text.Html);
            // Crea un mensaje de texto sin formato para el cliente que no es compatible con HTML
            AlternateView plainView = AlternateView.CreateAlternateViewFromString(Regex.Replace(htmlMessage, "<[^>]+?>", string.Empty), Encoding.UTF8, MediaTypeNames.Text.Plain);
            // agregar imagen
            string mediaType = MediaTypeNames.Image.Jpeg;
            // carpeta local de la maquina de un administrador
            LinkedResource img = new LinkedResource("C:\\Users\\hp\\Documents\\Github\\TarjetaCoordenadas\\Imagen\\tarjetaUsuario"+idUsuario+".jpg", mediaType);

            img.ContentId = "TarjetaCoordenadas";
            img.ContentType.MediaType = mediaType;
            img.TransferEncoding = TransferEncoding.Base64;
            img.ContentType.Name = img.ContentId;
            img.ContentLink = new Uri("cid:" + img.ContentId);
            htmlView.LinkedResources.Add(img);

            mail.AlternateViews.Add(plainView);
            mail.AlternateViews.Add(htmlView);
            mail.IsBodyHtml = true;
            mail.Subject = "Envio tarjeta";

            SmtpClient smtp = new SmtpClient();
            smtp.UseDefaultCredentials = false;
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;

            NetworkCredential nc = new NetworkCredential("correoDeAdministrador@gmail.com", "contraseña");
            smtp.EnableSsl = true;
            smtp.Credentials = nc;
            smtp.Send(mail);

        }// enviarTarjeta

        public string obtenerTarjetasEntregadasPorFecha(string fechaI, string fechaF)
        {
            string cantidad = "";
            sqlCommand = new SqlCommand("SP_TarjetasEntregadasPorFecha", sqlConnection);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@FechaI", fechaI);
            sqlCommand.Parameters.AddWithValue("@fechaF", fechaF);

            sqlConnection.Open();
            using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    string[] allColumns = dr.ItemArray.Select(obj => obj.ToString()).ToArray();
                    ArrayList itm = new ArrayList(allColumns);

                    cantidad = itm[0].ToString();
                }

            };
            sqlConnection.Close();

            return cantidad;
        }

        public string obtenerTarjetasNegadasPorFecha(string fechaI, string fechaF)
        {
            string cantidad = "";
            sqlCommand = new SqlCommand("SP_TarjetasNegadasPorFecha", sqlConnection);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@FechaI", fechaI);
            sqlCommand.Parameters.AddWithValue("@fechaF", fechaF);

            sqlConnection.Open();
            using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    string[] allColumns = dr.ItemArray.Select(obj => obj.ToString()).ToArray();
                    ArrayList itm = new ArrayList(allColumns);

                    cantidad = itm[0].ToString();
                }

            };
            sqlConnection.Close();

            return cantidad;
        }

        public string obtenerTarjetasDesbloqueadasPorFecha(string fechaI, string fechaF)
        {
            string cantidad = "";
            sqlCommand = new SqlCommand("SP_TarjetasDesbloqueadasPorFecha", sqlConnection);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@FechaI", fechaI);
            sqlCommand.Parameters.AddWithValue("@fechaF", fechaF);

            sqlConnection.Open();
            using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    string[] allColumns = dr.ItemArray.Select(obj => obj.ToString()).ToArray();
                    ArrayList itm = new ArrayList(allColumns);

                    cantidad = itm[0].ToString();
                }

            };
            sqlConnection.Close();

            return cantidad;
        }

        public string obtenerTarjetasDesbloqueadasPorAdministrador(string administrador)
        {
            string cantidad = "";
            sqlCommand = new SqlCommand("SP_TarjetasDesbloqueadasPorAdministrador", sqlConnection);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@Usuario", administrador);

            sqlConnection.Open();
            using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    string[] allColumns = dr.ItemArray.Select(obj => obj.ToString()).ToArray();
                    ArrayList itm = new ArrayList(allColumns);

                    cantidad = itm[0].ToString();
                }

            };
            sqlConnection.Close();

            return cantidad;
        }

        public string obtenerTarjetasNegadasPorAdministrador(string administrador)
        {
            string cantidad = "";
            sqlCommand = new SqlCommand("SP_TarjetasNegadasPorAdministrador", sqlConnection);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@Usuario", administrador);

            sqlConnection.Open();
            using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    string[] allColumns = dr.ItemArray.Select(obj => obj.ToString()).ToArray();
                    ArrayList itm = new ArrayList(allColumns);

                    cantidad = itm[0].ToString();
                }

            };
            sqlConnection.Close();

            return cantidad;
        }

        public string obtenerTarjetasEntregadasPorAdministrador(string administrador)
        {
            string cantidad = "";
            sqlCommand = new SqlCommand("SP_TarjetasEntregadasPorAdministrador", sqlConnection);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@Usuario", administrador);

            sqlConnection.Open();
            using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    string[] allColumns = dr.ItemArray.Select(obj => obj.ToString()).ToArray();
                    ArrayList itm = new ArrayList(allColumns);

                    cantidad = itm[0].ToString();
                }

            };
            sqlConnection.Close();

            return cantidad;
        }
    }
}
