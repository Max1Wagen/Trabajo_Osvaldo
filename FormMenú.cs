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
    public partial class FormMenú : Form
    {
        public FormMenú()
        {
            InitializeComponent();
        }














        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormUsuarios f = new FormUsuarios();
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormAutos f = new FormAutos();
            f.ShowDialog();
        }











        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show(
               "¿Desea salir del sistema?",
               "Confirmación",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);

            if (r == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
