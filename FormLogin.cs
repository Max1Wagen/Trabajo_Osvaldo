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

namespace Trabajo_SQL_C_
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        string connectionString = @"Data Source=.\sqlexpress;Initial Catalog=Concesionario;User ID=sa;Password=alumnos";

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM Usuario WHERE Nombre = '" + textBox1.Text + "' AND Rut = '" + textBox2.Text + "'";

            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                try
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, cnn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                MessageBox.Show("Bienvenido " + reader["Nombre"].ToString());

                                FormMenú f = new FormMenú();
                                f.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Usuario o contraseña incorrectos");
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
    }
}
