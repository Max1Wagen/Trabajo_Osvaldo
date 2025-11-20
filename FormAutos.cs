using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trabajo_SQL_C_
{
    public partial class FormAutos : Form
    {
        public FormAutos()
        {
            InitializeComponent();
        }

        string connectionString = @"Data Source=.\sqlexpress;Initial Catalog=Concesionario;User ID=sa;Password=alumnos";
        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dS_Auto.Auto' Puede moverla o quitarla según sea necesario.
            this.auto1TableAdapter.Fill(this.dS_Auto.Auto1);
        }


        private void button3_Click(object sender, EventArgs e)
        {
            string Patente = textBox1.Text;
            string Marca = textBox2.Text;
            string Modelo = textBox3.Text;
            int año = int.Parse(textBox4.Text);
            string NumeroChasis = textBox5.Text;
            string Estado = textBox6.Text;

            this.auto1TableAdapter.Insert(Patente,Marca,Modelo,año,NumeroChasis,Estado);
            this.auto1TableAdapter.Fill(this.dS_Auto.Auto1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
            try
            {
                DataGridViewRow fila = dataGridView1.CurrentRow;
                string patente = fila.Cells["patenteDataGridViewTextBoxColumn"].Value.ToString();

                var confirmar = MessageBox.Show($"¿Está seguro de eliminar el registro con Patente '{patente}'?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmar == DialogResult.Yes)
                {
                    this.auto1TableAdapter.Delete_2(patente);
                    MessageBox.Show("Registro eliminado correctamente.");
                    this.auto1TableAdapter.Fill(this.dS_Auto.Auto1);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el registro: " + ex.Message);
            }
            


        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            try
            {
                DataGridViewRow fila = dataGridView1.CurrentRow;
                string Estado_deventa = fila.Cells["estadoDataGridViewTextBoxColumn"].Value.ToString();
                var confirmar = MessageBox.Show($"¿Está seguro de editar la venta del coche?", "Confirmar edición", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmar == DialogResult.Yes)
                {
                    
                    this.auto1TableAdapter.Actualizar(Estado_deventa);
                    this.auto1TableAdapter.Fill(this.dS_Auto.Auto1);

                }

                MessageBox.Show("Registro editado correctamente.");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el registro: " + ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();

        }
    }
}
