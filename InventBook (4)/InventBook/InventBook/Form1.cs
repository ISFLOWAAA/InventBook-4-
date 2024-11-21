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
    public partial class Form1 : Form
    {
        static string conexionstring = "server = LAPTOP-R3ALFIDD\\SQLEXPRESS ; database = InventBook ; integrated security= true";
        SqlConnection conexion = new SqlConnection(conexionstring);

        bool existe = false;
        private void LimpiarCampos()
        {
            campoNombre.Text = string.Empty;
            campoCedula.Text = string.Empty;
            campoRol.Text = string.Empty;
            campoApellido.Text = string.Empty;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 ventana = new Form2();
            ventana.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            conexion.Open();

            string verificarSumatoria = @"
        SELECT SUM(CASE 
                    WHEN tipoTransaccion = '1' THEN 1 
                    WHEN tipoTransaccion = '2' THEN -1 
                    ELSE 0 
                   END) AS BalancePrestamos
        FROM historialLibros
        WHERE cedulaUsuario = @cedula";
            SqlCommand comandoVerificar = new SqlCommand(verificarSumatoria, conexion);
            comandoVerificar.Parameters.AddWithValue("@cedula", campoCedula.Text);

            int balancePrestamos = (int)comandoVerificar.ExecuteScalar();

            if (balancePrestamos > 0)
            {
                MessageBox.Show("El usuario no puede ser eliminado porque tiene préstamos activos.");
            }
            else
            {
                string eliminar = "DELETE FROM usuario WHERE cedula = @cedula";
                SqlCommand comandoEliminar = new SqlCommand(eliminar, conexion);
                comandoEliminar.Parameters.AddWithValue("@cedula", campoCedula.Text);
                comandoEliminar.ExecuteNonQuery();

                MessageBox.Show("El registro ha sido ELIMINADO exitosamente.");
            }

            conexion.Close();
            LimpiarCampos();

            /*conexion.Open();
            string eliminar = "delete from usuario where cedula = "+campoCedula.Text+"";
            SqlCommand comando = new SqlCommand(eliminar, conexion);
            comando.ExecuteNonQuery();
            MessageBox.Show("El Registro ha sido ELIMINADO exitosamente");
            conexion.Close();
            LimpiarCampos();*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
                      
            if (campoNombre.Text.Length > 1 && campoApellido.Text.Length > 1 && campoRol.Text.Length > 1 && campoCedula.Text.Length > 1) {
                try
                {
                    conexion.Open();

                    string verificar = "SELECT COUNT(*) FROM usuario WHERE cedula = @Campo1 AND nombre = @Campo2 AND apellido = @Campo3 AND rol = @Campo4";
                    SqlCommand comandoVerificar = new SqlCommand(verificar, conexion);

                    comandoVerificar.Parameters.AddWithValue("@Campo1", campoCedula.Text);
                    comandoVerificar.Parameters.AddWithValue("@Campo2", campoNombre.Text);
                    comandoVerificar.Parameters.AddWithValue("@Campo3", campoApellido.Text);
                    comandoVerificar.Parameters.AddWithValue("@Campo4", campoRol.Text);

                    int count = (int)comandoVerificar.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("El registro ya EXISTE en la base de datos.");
                    }
                    else
                    {

                        string agregar = "INSERT INTO usuario (cedula, nombre, apellido, rol) VALUES (@Campo1, @Campo2, @Campo3, @Campo4)";
                        SqlCommand comandoInsertar = new SqlCommand(agregar, conexion);

                        comandoInsertar.Parameters.AddWithValue("@Campo1", campoCedula.Text);
                        comandoInsertar.Parameters.AddWithValue("@Campo2", campoNombre.Text);
                        comandoInsertar.Parameters.AddWithValue("@Campo3", campoApellido.Text);
                        comandoInsertar.Parameters.AddWithValue("@Campo4", campoRol.Text);

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
                MessageBox.Show("Todos los campos deben contener más de un carácter.");
            }

            /*
            conexion.Open();
            string agregar = "insert into usuario values("+textBox2.Text+",'"+textBox1.Text+"','"+textBox4.Text+"','"+textBox3.Text+"')";
            SqlCommand comando = new SqlCommand(agregar,conexion);
            comando.ExecuteNonQuery();
            MessageBox.Show("Registro agregado exitosamente");
            conexion.Close();
            LimpiarCampos();*/
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

                    MessageBox.Show("El usuario ya EXISTE en nuestro sistema");
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

            /*try
            {
                conexion.Open();

                string verificar = "SELECT COUNT(*) FROM usuario WHERE cedula = @Campo1 AND nombre = @Campo2 AND apellido = @Campo3 AND rol = @Campo4";
                SqlCommand comandoVerificar = new SqlCommand(verificar, conexion);

                comandoVerificar.Parameters.AddWithValue("@Campo1", campoCedula.Text);
                comandoVerificar.Parameters.AddWithValue("@Campo2", campoNombre.Text);
                comandoVerificar.Parameters.AddWithValue("@Campo3", campoApellido.Text);
                comandoVerificar.Parameters.AddWithValue("@Campo4", campoRol.Text);

                int count = (int)comandoVerificar.ExecuteScalar();

                if (count > 0)
                {

                    MessageBox.Show("El registro ya EXISTE en la base de datos.");
                }
                else
                {
                    
                    MessageBox.Show("El usuario NO existe en la base de datos");
                  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }*/
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conexion.Open();

            string modificar = "UPDATE usuario SET nombre = @Campo2, apellido = @Campo3, rol = @Campo4 WHERE cedula = @Campo1";

            SqlCommand comandoVerificar = new SqlCommand(modificar, conexion);

            comandoVerificar.Parameters.AddWithValue("@Campo1", campoCedula.Text);
            comandoVerificar.Parameters.AddWithValue("@Campo2", campoNombre.Text);
            comandoVerificar.Parameters.AddWithValue("@Campo3", campoApellido.Text);
            comandoVerificar.Parameters.AddWithValue("@Campo4", campoRol.Text);

            comandoVerificar.ExecuteNonQuery();
            MessageBox.Show("Registro MODIFICADO exitosamente");

            conexion.Close();
            LimpiarCampos();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            conexion.Open();
            MessageBox.Show("La conexion a " + conexion.Database + " es exitosa");
            conexion.Close();
        }

        private void campoCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void campoNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void campoNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void campoApellido_TextChanged(object sender, EventArgs e)
        {

        }

        private void campoApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void campoRol_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void campoRol_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {

                campoRol.Text = "Estudiante";
            }           
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                campoRol.Text = "Profesor";
            }
            
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                campoRol.Text = "Administrativo";
            }
        }
    }
}
