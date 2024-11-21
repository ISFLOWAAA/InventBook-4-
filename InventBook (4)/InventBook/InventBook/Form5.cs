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
    public partial class Form5 : Form
    {
        static string conexionstring = "server = LAPTOP-R3ALFIDD\\SQLEXPRESS ; database = InventBook ; integrated security= true";
        SqlConnection conexion = new SqlConnection(conexionstring);
        public Form5()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            string consulta = "select * from libros";
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataTable dataTable = new DataTable();
            adaptador.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            conexion.Open();

            SqlCommand comando = conexion.CreateCommand();
     
            comando.CommandType = CommandType.Text;
            comando.CommandText = "select * from libros where titulo like ('%"+ textBox1.Text +"%')";
            comando.ExecuteNonQuery();

            DataTable dataTable = new DataTable();
            SqlDataAdapter adaptador = new SqlDataAdapter(comando);
            adaptador.Fill(dataTable);
            dataGridView1.DataSource = dataTable;

            conexion.Close();
        }
    }
}
