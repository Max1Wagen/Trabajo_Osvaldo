using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Trabajo_SQL_C_
{
    public partial class FormUsuarios : Form
    {
        public FormUsuarios()
        {
            InitializeComponent();
            
            
        }

        string connectionString = @"Data Source=.\sqlexpress;Initial Catalog=Concesionario;User ID=sa;Password=alumnos";

        
        public void actualizar()
        {
            string sql = "SELECT * FROM USUARIO";
            dataGridView1.Rows.Clear();
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                try
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, cnn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataGridView1.Rows.Add(reader[0], reader[1], reader[2], reader[3], reader[4]);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
           
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "INSERT INTO USUARIO (Rut, Nombre, Apellido, Correo, Ciudad) VALUES (@Rut, @Nombre, @Apellido, @Correo, @Ciudad)";
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    cmd.Parameters.AddWithValue("@Rut", textBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@Nombre", textBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@Apellido", textBox3.Text.Trim());
                    cmd.Parameters.AddWithValue("@Correo", textBox4.Text.Trim());
                    cmd.Parameters.AddWithValue("@Ciudad", textBox5.Text.Trim());
                    cmd.ExecuteNonQuery();
                }

            }
            actualizar();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql = "DELETE FROM USUARIO WHERE RUT = " + dataGridView1.CurrentRow.Cells[0].Value;
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                try
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, cnn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            actualizar();

        }

        private void FormClientes_Load(object sender, EventArgs e)
        {
            actualizar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE USUARIO SET CIUDAD = @Ciudad, CORREO = @Correo, APELLIDO = @Apellido, NOMBRE = @Nombre WHERE RUT = @Rut";
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                try
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, cnn))
                    {
                        cmd.Parameters.AddWithValue("@Ciudad", textBox5.Text.Trim());
                        cmd.Parameters.AddWithValue("@Correo", textBox4.Text.Trim());
                        cmd.Parameters.AddWithValue("@Apellido", textBox3.Text.Trim());
                        cmd.Parameters.AddWithValue("@Nombre", textBox2.Text.Trim());
                        cmd.Parameters.AddWithValue("@Rut", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
            actualizar();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }
    }
}
