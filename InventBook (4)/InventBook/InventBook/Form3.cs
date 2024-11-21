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
    public partial class Form3 : Form
    {
        static string conexionstring = "server = LAPTOP-R3ALFIDD\\SQLEXPRESS ; database = InventBook ; integrated security= true";
        SqlConnection conexion = new SqlConnection(conexionstring);

        private void LimpiarCampos()
        {
            campoIdentificador.Text = string.Empty;
            campoTitulo.Text = string.Empty;
            campoRegistro.Text = string.Empty;
            campoTipo.Text = string.Empty;
            campoCI.Text = string.Empty;
            campoCA.Text = string.Empty;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            conexion.Open();
            MessageBox.Show("La conexion a " + conexion.Database + " es exitosa");
            conexion.Close();
        }

        private void campoIdentificador_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void campoCI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void campoCA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (campoIdentificador.Text.Length >= 1 && campoTitulo.Text.Length > 1 && campoRegistro.Text.Length > 1 && campoTitulo.Text.Length > 1 && campoCI.Text.Length >= 1) {
                try
                {
                    conexion.Open();

                    string verificar = "SELECT COUNT(*) FROM libros WHERE identificador = @Campo1 AND titulo = @Campo2 AND fechaRegistro = @Campo3 AND tipo = @Campo4 AND cantidadInicial = @Campo5";
                    SqlCommand comandoVerificar = new SqlCommand(verificar, conexion);

                    comandoVerificar.Parameters.AddWithValue("@Campo1", campoIdentificador.Text);
                    comandoVerificar.Parameters.AddWithValue("@Campo2", campoTitulo.Text);
                    comandoVerificar.Parameters.AddWithValue("@Campo3", campoRegistro.Text);
                    comandoVerificar.Parameters.AddWithValue("@Campo4", campoTipo.Text);
                    comandoVerificar.Parameters.AddWithValue("@Campo5", campoCI.Text);

                    int count = (int)comandoVerificar.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("El registro ya EXISTE en la base de datos.");
                    }
                    else
                    {

                        string agregar = "INSERT INTO libros (identificador, titulo, fechaRegistro, tipo, cantidadInicial) VALUES (@Campo1, @Campo2, @Campo3, @Campo4, @Campo5)";
                        SqlCommand comandoInsertar = new SqlCommand(agregar, conexion);

                        comandoInsertar.Parameters.AddWithValue("@Campo1", campoIdentificador.Text);
                        comandoInsertar.Parameters.AddWithValue("@Campo2", campoTitulo.Text);
                        comandoInsertar.Parameters.AddWithValue("@Campo3", campoRegistro.Text);
                        comandoInsertar.Parameters.AddWithValue("@Campo4", campoTipo.Text);
                        comandoInsertar.Parameters.AddWithValue("@Campo5", campoCI.Text);

                        comandoInsertar.ExecuteNonQuery();
                        MessageBox.Show("Registro agregado exitosamente");

                        LimpiarCampos();
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
                MessageBox.Show("Todos los campos deben estar llenos excepto el campo Cantidad Actual");
            }
        }

        private void campoRegistro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                conexion.Open();

                // Comando para obtener los datos del libro en base al identificador
                string consulta = "SELECT titulo, fechaRegistro, tipo, cantidadInicial FROM libros WHERE identificador = @Campo1";
                SqlCommand comandoBuscar = new SqlCommand(consulta, conexion);

                // Parámetro para el identificador
                comandoBuscar.Parameters.AddWithValue("@Campo1", campoIdentificador.Text);

                // Ejecuta la consulta y obtiene los resultados
                SqlDataReader lector = comandoBuscar.ExecuteReader();

                // Verifica si se encontró un registro
                if (lector.Read())
                {
                    // Asigna los valores de la base de datos a los campos del formulario
                    campoTitulo.Text = lector["titulo"].ToString();
                    campoRegistro.Text = lector["fechaRegistro"].ToString();
                    campoTipo.Text = lector["tipo"].ToString();
                    campoCI.Text = lector["cantidadInicial"].ToString();
                }
                else
                {
                    MessageBox.Show("El libro con el identificador especificado NO existe en la base de datos");
                }

                lector.Close(); // Cierra el lector una vez terminada la operación
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

        private void button5_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                conexion.Open();

                string actualizar = "UPDATE libros SET titulo = @Campo2, fechaRegistro = @Campo3, tipo = @Campo4, cantidadInicial = @Campo5 WHERE identificador = @Campo1";
                SqlCommand comandoActualizar = new SqlCommand(actualizar, conexion);

                comandoActualizar.Parameters.AddWithValue("@Campo1", campoIdentificador.Text);
                comandoActualizar.Parameters.AddWithValue("@Campo2", campoTitulo.Text);
                comandoActualizar.Parameters.AddWithValue("@Campo3", campoRegistro.Text);
                comandoActualizar.Parameters.AddWithValue("@Campo4", campoTipo.Text);
                comandoActualizar.Parameters.AddWithValue("@Campo5", campoCI.Text);

                int filasAfectadas = comandoActualizar.ExecuteNonQuery();

                if (filasAfectadas > 0)
                {
                    MessageBox.Show("Registro actualizado exitosamente");
                }
                else
                {
                    MessageBox.Show("No se encontró un libro con el identificador especificado");
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

        private void button6_Click(object sender, EventArgs e)
        {
            Form5 ventana = new Form5();
            ventana.Visible = true;
        }

        private void campoRegistro_TextChanged(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {            
            DateTime fechaActual = DateTime.Today;

            if (monthCalendar1.SelectionStart.Date == fechaActual)
            {
                campoRegistro.Text = fechaActual.ToShortDateString();
            }
            else
            {
                MessageBox.Show("Solo puedes seleccionar la fecha actual.", "Fecha inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                monthCalendar1.SetDate(fechaActual);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {

                campoTipo.Text = "Libro";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {

                campoTipo.Text = "Revista";
            }
        }
    }
}
