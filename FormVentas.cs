using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trabajo_SQL_C_
{
    public partial class FormVentas : Form
    {
        public FormVentas()
        {
            InitializeComponent();
        }

        string connectionString = @"Data Source=.\sqlexpress;Initial Catalog=Concesionario;User ID=sa;Password=alumnos";


        private void FormVentas_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dataSet1.Venta' Puede moverla o quitarla según sea necesario.
            this.ventaTableAdapter.Fill(this.dataSet1.Venta);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int ID_Venta = int.Parse(textBox1.Text);
            DateTime Fecha = dateTimePicker1.Value;
            string metodo_Pago = textBox3.Text;
            string Patente_Auto = textBox4.Text;
            int Rut_Cliente = int.Parse(textBox5.Text);
            this.ventaTableAdapter.Insert(ID_Venta, Fecha, metodo_Pago, Patente_Auto, Rut_Cliente);
            this.ventaTableAdapter.Fill(this.dataSet1.Venta);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow fila = dataGridView1.CurrentRow;    
                int ID_Venta = int.Parse(fila.Cells["iDVentaDataGridViewTextBoxColumn"].Value.ToString());
                var confirmar = MessageBox.Show($"¿Está seguro de eliminar el registro con ID_Venta '{ID_Venta}'?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmar == DialogResult.Yes)
                {
                    this.ventaTableAdapter.Borrar(ID_Venta);
                    MessageBox.Show("La venta se ha eliminado");
                    this.ventaTableAdapter.Fill(this.dataSet1.Venta);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar la venta: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow fila = dataGridView1.CurrentRow;
                int ID_Venta = int.Parse(fila.Cells["iDVentaDataGridViewTextBoxColumn"].Value.ToString());
                var confirmar = MessageBox.Show($"¿Está seguro de actualizar el registro con ID_Venta '{ID_Venta}'?", "Confirmar actualización", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmar == DialogResult.Yes)
                {
                    DateTime Fecha = dateTimePicker1.Value;
                    string metodo_Pago = textBox3.Text;
                    string Patente_Auto = textBox4.Text;
                    int Rut_Cliente = int.Parse(textBox5.Text);
                    this.ventaTableAdapter.Actualizar(ID_Venta);
                    MessageBox.Show("La venta se ha actualizado");
                    this.ventaTableAdapter.Fill(this.dataSet1.Venta);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la venta: " + ex.Message);
            }
        }




















        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

       
    }
}
