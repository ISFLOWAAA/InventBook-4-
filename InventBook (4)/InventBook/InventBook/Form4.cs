using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.Collections;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace InventBook
{
    public partial class Form4 : Form
    {
        int contador = 0;
        bool validacion = false;

        static string conexionstring = "server = LAPTOP-R3ALFIDD\\SQLEXPRESS ; database = InventBook ; integrated security= true";
        SqlConnection conexion = new SqlConnection(conexionstring);

        bool existe = false;
        private void LimpiarCampos()
        {
            /*campoNombre.Text = string.Empty;
            campoCedula.Text = string.Empty;
            campoRol.Text = string.Empty;
            campoApellido.Text = string.Empty;
            campoTransaccion.Text = string.Empty;
            campoFechaTransaccion.Text = string.Empty;*/
            campoIdentificador.Text = string.Empty;
            campoTitulo.Text = string.Empty;
            campoTipo.Text = string.Empty;
        }
        private void LimpiarCampoTransaccion()
        {
            campoTransaccion.Text = string.Empty;
        }
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conexion.Open();

                string consulta = "SELECT nombre, apellido, rol FROM usuario WHERE cedula = @Campo1";
                SqlCommand comandoConsulta = new SqlCommand(consulta, conexion);

                comandoConsulta.Parameters.AddWithValue("@Campo1", campoCedula.Text);

                SqlDataReader lector = comandoConsulta.ExecuteReader();

                if (lector.Read())
                {
                    campoNombre.Text = lector["nombre"].ToString();
                    campoApellido.Text = lector["apellido"].ToString();
                    campoRol.Text = lector["rol"].ToString();

                    //MessageBox.Show("El usuario ya EXISTE en nuestro sistema");
                }
                else
                {
                    MessageBox.Show("El usuario NO existe en el sistema");
                }

                lector.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }

            if (campoRol.Text == "Estudiante" || campoRol.Text == "estudiante")
            {
                contador = 5;
                validacion = true;
                labelTransaccion.Text = contador.ToString();
                button1.Enabled = false;

            }
            else if (campoRol.Text == "Profesor" || campoRol.Text == "profesor")
            {
                contador = 3;
                validacion = true;
                labelTransaccion.Text = contador.ToString();
                button1.Enabled = false;
            }
            else if (campoRol.Text == "Administrativo" || campoRol.Text == "administrativo")
            {
                contador = 1;
                validacion = true;
                labelTransaccion.Text = contador.ToString();
                button1.Enabled = false;
            }
            else
            {
                MessageBox.Show("El rol debe ser Estudiante, Profesor o Administrativo");
                validacion = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                conexion.Open();

                string consulta = "SELECT titulo, tipo FROM libros WHERE identificador = @Campo1";
                SqlCommand comandoConsulta = new SqlCommand(consulta, conexion);

                comandoConsulta.Parameters.AddWithValue("@Campo1", campoIdentificador.Text);

                SqlDataReader lector = comandoConsulta.ExecuteReader();

                if (lector.Read())
                {
                    campoTitulo.Text = lector["titulo"].ToString();
                    campoTipo.Text = lector["Tipo"].ToString();

                    //MessageBox.Show("El usuario ya EXISTE en nuestro sistema");
                }
                else
                {
                    MessageBox.Show("El libro NO existe en el sistema");
                }

                lector.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }
        }

        private void campoTransaccion_TextChanged(object sender, EventArgs e)
        {
            if (campoTransaccion.Text == "1")
            {
                MessageBox.Show("Usted hara un PRESTAMO, por favor revisar que sea la operacion correcta antes de continuar");
            } 
            else if (campoTransaccion.Text == "2")
            {
                MessageBox.Show("Usted hara una DEVOLUCION, por favor revisar que sea la operacion correcta antes de continuar");
            }
            else
            {
                MessageBox.Show("Por favor digite 1 para PRESTAMO o 2 para DEVOLUCION");
                LimpiarCampoTransaccion();
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            button3.Enabled = false;
            button4.Enabled = false;

            campoNombre.TextChanged += new EventHandler(ValidarCampos);
            campoTitulo.TextChanged += new EventHandler(ValidarCampos);
            campoTransaccion.TextChanged += new EventHandler(ValidarCampos);
            campoFechaTransaccion.TextChanged += new EventHandler(ValidarCampos);

            /*button3.Enabled = false; 

            campoNombre.TextChanged += new EventHandler(campoNombre_TextChanged);
            campoTitulo.TextChanged += new EventHandler(campoTitulo_TextChanged);*/
        }

        private void ValidarCampos(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(campoNombre.Text) &&
                !string.IsNullOrEmpty(campoTitulo.Text) &&
                !string.IsNullOrEmpty(campoTransaccion.Text) &&
                !string.IsNullOrEmpty(campoFechaTransaccion.Text) &&
                (campoTransaccion.Text=="1"))               
            {
                button3.Enabled = true;
            }
            else if (!string.IsNullOrEmpty(campoNombre.Text) &&
                !string.IsNullOrEmpty(campoTitulo.Text) &&
                !string.IsNullOrEmpty(campoTransaccion.Text) &&
                !string.IsNullOrEmpty(campoFechaTransaccion.Text) &&
                (campoTransaccion.Text == "2"))
            {
                button4.Enabled = true;
            }
            else
            {
                button3.Enabled = false;
                button4.Enabled = false;
            }
        }

        private void campoNombre_TextChanged(object sender, EventArgs e)
        {

            /*if (!string.IsNullOrEmpty(campoNombre.Text) && !string.IsNullOrEmpty(campoTitulo.Text))
            {
                button3.Enabled = true;
            }
            else
            {
                button3.Enabled = false;
            }*/
        }

        private void campoTitulo_TextChanged(object sender, EventArgs e)
        {
            /*if (!string.IsNullOrEmpty(campoNombre.Text) && !string.IsNullOrEmpty(campoTitulo.Text))
            {
                button3.Enabled = true;
            }
            else
            {
                button3.Enabled = false;
            }*/
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (labelTransaccion.Text != "0")
            {
                if (int.TryParse(campoTransaccion.Text, out int tipoTransaccion) && tipoTransaccion == 1)
                {
                    string queryInsertHistorialLibros = "INSERT INTO historialLibros (cedulaUsuario, nombreUsuario, apellidoUsuario, rolUsuario, identificadorLibro, tituloLibro, tipoLibro, tipoTransaccion, fechaTransaccion) " +
                                                        "VALUES (@cedulaUsuario, @nombreUsuario, @apellidoUsuario, @rolUsuario, @identificadorLibro, @tituloLibro, @tipoLibro, @tipoTransaccion, @fechaTransaccion)";

                    string queryUpdateHistorialPrestamos = "UPDATE historialPrestamos SET contadorPrestamo = contadorPrestamo + 1 " +
                                                           "WHERE cedulaUsuario = @cedulaUsuario AND identificadorLibro = @identificadorLibro";

                    string queryInsertHistorialPrestamos = "INSERT INTO historialPrestamos (cedulaUsuario, nombreUsuario, apellidoUsuario, identificadorLibro, tituloLibro, tipoLibro, contadorPrestamo) " +
                                                           "VALUES (@cedulaUsuario, @nombreUsuario, @apellidoUsuario, @identificadorLibro, @tituloLibro, @tipoLibro, 1)";

                    string queryCheckExistence = "SELECT COUNT(*) FROM historialPrestamos WHERE cedulaUsuario = @cedulaUsuario AND identificadorLibro = @identificadorLibro";

                    string queryUpdateLibros = "UPDATE libros SET cantidadInicial = cantidadInicial - 1 " +
                                               "WHERE identificador = @identificador AND cantidadInicial > 0";

                    try
                    {
                        conexion.Open();

                        using (SqlTransaction transaction = conexion.BeginTransaction())
                        {
                            // Insertar en la tabla historialLibros
                            using (SqlCommand commandInsertHistorialLibros = new SqlCommand(queryInsertHistorialLibros, conexion, transaction))
                            {
                                commandInsertHistorialLibros.Parameters.AddWithValue("@cedulaUsuario", campoCedula.Text);
                                commandInsertHistorialLibros.Parameters.AddWithValue("@nombreUsuario", campoNombre.Text);
                                commandInsertHistorialLibros.Parameters.AddWithValue("@apellidoUsuario", campoApellido.Text);
                                commandInsertHistorialLibros.Parameters.AddWithValue("@rolUsuario", campoRol.Text);
                                commandInsertHistorialLibros.Parameters.AddWithValue("@identificadorLibro", campoIdentificador.Text);
                                commandInsertHistorialLibros.Parameters.AddWithValue("@tituloLibro", campoTitulo.Text);
                                commandInsertHistorialLibros.Parameters.AddWithValue("@tipoLibro", campoTipo.Text);
                                commandInsertHistorialLibros.Parameters.AddWithValue("@tipoTransaccion", tipoTransaccion);
                                commandInsertHistorialLibros.Parameters.AddWithValue("@fechaTransaccion", campoFechaTransaccion.Text);

                                commandInsertHistorialLibros.ExecuteNonQuery();
                            }

                            // Verificar si ya existe un registro para el mismo usuario y libro
                            using (SqlCommand commandCheckExistence = new SqlCommand(queryCheckExistence, conexion, transaction))
                            {
                                commandCheckExistence.Parameters.AddWithValue("@cedulaUsuario", campoCedula.Text);
                                commandCheckExistence.Parameters.AddWithValue("@identificadorLibro", campoIdentificador.Text);

                                int recordExists = (int)commandCheckExistence.ExecuteScalar();

                                if (recordExists > 0)
                                {
                                    // Actualizar contadorPrestamo si ya existe un registro
                                    using (SqlCommand commandUpdateHistorialPrestamos = new SqlCommand(queryUpdateHistorialPrestamos, conexion, transaction))
                                    {
                                        commandUpdateHistorialPrestamos.Parameters.AddWithValue("@cedulaUsuario", campoCedula.Text);
                                        commandUpdateHistorialPrestamos.Parameters.AddWithValue("@identificadorLibro", campoIdentificador.Text);

                                        commandUpdateHistorialPrestamos.ExecuteNonQuery();
                                    }
                                }
                                else
                                {
                                    // Insertar un nuevo registro en historialPrestamos con contadorPrestamo = 1
                                    using (SqlCommand commandInsertHistorialPrestamos = new SqlCommand(queryInsertHistorialPrestamos, conexion, transaction))
                                    {
                                        commandInsertHistorialPrestamos.Parameters.AddWithValue("@cedulaUsuario", campoCedula.Text);
                                        commandInsertHistorialPrestamos.Parameters.AddWithValue("@nombreUsuario", campoNombre.Text);
                                        commandInsertHistorialPrestamos.Parameters.AddWithValue("@apellidoUsuario", campoApellido.Text);
                                        commandInsertHistorialPrestamos.Parameters.AddWithValue("@identificadorLibro", campoIdentificador.Text);
                                        commandInsertHistorialPrestamos.Parameters.AddWithValue("@tituloLibro", campoTitulo.Text);
                                        commandInsertHistorialPrestamos.Parameters.AddWithValue("@tipoLibro", campoTipo.Text);

                                        commandInsertHistorialPrestamos.ExecuteNonQuery();
                                    }
                                }
                            }

                            // Actualizar la cantidad en la tabla libros
                            using (SqlCommand commandUpdateLibros = new SqlCommand(queryUpdateLibros, conexion, transaction))
                            {
                                commandUpdateLibros.Parameters.AddWithValue("@identificador", campoIdentificador.Text);

                                int rowsUpdated = commandUpdateLibros.ExecuteNonQuery();

                                if (rowsUpdated > 0)
                                {
                                    transaction.Commit();
                                    MessageBox.Show("Transacción realizada exitosamente y cantidad actualizada.");
                                    LimpiarCampos();
                                    contador--;
                                    labelTransaccion.Text = contador.ToString();
                                }
                                else
                                {
                                    transaction.Rollback();
                                    MessageBox.Show("No hay suficientes libros disponibles para realizar esta transacción.");
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                    finally
                    {
                        conexion.Close();
                    }
                }
                else
                {
                    MessageBox.Show("El campo de transacción debe ser igual a 1 para realizar el préstamo.");
                }
            }
            else if (int.TryParse(labelTransaccion.Text, out int transaccion) && transaccion == 0)
            {
                MessageBox.Show("Usted no puede realizar más transacciones.");
            }
        }

        private void labelTransaccion_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void campoFechaTransaccion_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            DateTime fechaActual = DateTime.Today;

            if (monthCalendar1.SelectionStart.Date == fechaActual)
            {
                campoFechaTransaccion.Text = fechaActual.ToShortDateString();
            }
            else
            {
                MessageBox.Show("Solo puedes seleccionar la fecha actual.", "Selección no válida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                monthCalendar1.SetDate(fechaActual);
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (labelTransaccion.Text != "0")
            {
                if (int.TryParse(campoTransaccion.Text, out int tipoTransaccion) && tipoTransaccion == 2)
                {
                    ProcesarDevolucion();
                }
                else
                {
                    MessageBox.Show("El campo de transacción debe ser igual a 2 para realizar la devolución.");
                }
            }
            else if (int.TryParse(labelTransaccion.Text, out int transaccion) && transaccion == 0)
            {
                MessageBox.Show("Usted no puede realizar más transacciones.");
            }
        }

        private void ProcesarDevolucion()
        {
            string queryCheckHistorialPrestamos = @"
        SELECT contadorPrestamo 
        FROM historialPrestamos 
        WHERE cedulaUsuario = @cedulaUsuario AND identificadorLibro = @identificadorLibro";

            string queryInsertHistorialLibros = @"
        INSERT INTO historialLibros 
        (cedulaUsuario, nombreUsuario, apellidoUsuario, rolUsuario, identificadorLibro, tituloLibro, tipoLibro, tipoTransaccion, fechaTransaccion) 
        VALUES 
        (@cedulaUsuario, @nombreUsuario, @apellidoUsuario, @rolUsuario, @identificadorLibro, @tituloLibro, @tipoLibro, @tipoTransaccion, @fechaTransaccion)";

            string queryUpdateContadorPrestamo = @"
        UPDATE historialPrestamos 
        SET contadorPrestamo = contadorPrestamo - 1 
        WHERE cedulaUsuario = @cedulaUsuario AND identificadorLibro = @identificadorLibro";

            string queryUpdateCantidadInicial = @"
        UPDATE libros 
        SET cantidadInicial = cantidadInicial + 1 
        WHERE identificador = @identificador";

            try
            {
                conexion.Open();

                using (SqlCommand commandCheckHistorialPrestamos = new SqlCommand(queryCheckHistorialPrestamos, conexion))
                {
                    commandCheckHistorialPrestamos.Parameters.AddWithValue("@cedulaUsuario", campoCedula.Text);
                    commandCheckHistorialPrestamos.Parameters.AddWithValue("@identificadorLibro", campoIdentificador.Text);

                    object result = commandCheckHistorialPrestamos.ExecuteScalar();

                    if (result == null || Convert.ToInt32(result) < 1)
                    {
                        MessageBox.Show("No es una devolución válida, por favor verifique el libro o revista que está devolviendo.");
                        return;
                    }
                }

                using (SqlCommand commandInsertHistorialLibros = new SqlCommand(queryInsertHistorialLibros, conexion))
                {
                    commandInsertHistorialLibros.Parameters.AddWithValue("@cedulaUsuario", campoCedula.Text);
                    commandInsertHistorialLibros.Parameters.AddWithValue("@nombreUsuario", campoNombre.Text);
                    commandInsertHistorialLibros.Parameters.AddWithValue("@apellidoUsuario", campoApellido.Text);
                    commandInsertHistorialLibros.Parameters.AddWithValue("@rolUsuario", campoRol.Text);
                    commandInsertHistorialLibros.Parameters.AddWithValue("@identificadorLibro", campoIdentificador.Text);
                    commandInsertHistorialLibros.Parameters.AddWithValue("@tituloLibro", campoTitulo.Text);
                    commandInsertHistorialLibros.Parameters.AddWithValue("@tipoLibro", campoTipo.Text);
                    commandInsertHistorialLibros.Parameters.AddWithValue("@tipoTransaccion", 2);
                    commandInsertHistorialLibros.Parameters.AddWithValue("@fechaTransaccion",
                        string.IsNullOrEmpty(campoFechaTransaccion.Text) ? DateTime.Now.ToString("yyyy-MM-dd") : campoFechaTransaccion.Text);

                    commandInsertHistorialLibros.ExecuteNonQuery();
                }

                using (SqlCommand commandUpdateContadorPrestamo = new SqlCommand(queryUpdateContadorPrestamo, conexion))
                {
                    commandUpdateContadorPrestamo.Parameters.AddWithValue("@cedulaUsuario", campoCedula.Text);
                    commandUpdateContadorPrestamo.Parameters.AddWithValue("@identificadorLibro", campoIdentificador.Text);

                    commandUpdateContadorPrestamo.ExecuteNonQuery();
                }

                using (SqlCommand commandUpdateCantidadInicial = new SqlCommand(queryUpdateCantidadInicial, conexion))
                {
                    commandUpdateCantidadInicial.Parameters.AddWithValue("@identificador", campoIdentificador.Text);

                    commandUpdateCantidadInicial.ExecuteNonQuery();
                }

                MessageBox.Show("Devolución exitosa.");
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }
        }
    }
}
