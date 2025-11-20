using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Trabajo_SQL_C_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string connectionString = @"Data Source=.\sqlexpress;Initial Catalog=Concesionario;User ID=sa;Password=alumnos";
        DataTable  Tabla;

        private void Form1_Load(object sender, EventArgs e)
        {
            Reporte();
        }

        private void Reporte()
        {
            string sql = @"
                SELECT
                    v.ID_Venta AS [Código de venta],
                    u.Nombre AS [Cliente],
                    a.Marca AS [Auto],
                    v.Fecha_De_Compra AS [Fecha de venta],
                    v.[Metodo de pago] AS [Metodo de pago]
                FROM Venta v
                INNER JOIN Usuario u ON v.Rut = u.Rut
                INNER JOIN Auto a ON v.Patente = a.Patente
                ORDER BY v.Fecha_De_Compra DESC;
            ";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlDataAdapter da = new SqlDataAdapter(sql, con))
            {
                Tabla = new DataTable();
                da.Fill(Tabla);
                dataGridView1.DataSource = Tabla;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }

        }

        private void CapturarDatos()
        {
            Datos = new Bitmap(dataGridView1.Width, dataGridView1.Height);
            dataGridView1.DrawToBitmap(Datos, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Tabla == null || Tabla.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.");
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Archivo CSV|*.csv";
                sfd.FileName = "Reporte_De_Ventas.csv";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(sfd.FileName))
                    {

                        for (int i = 0; i < Tabla.Columns.Count; i++)
                        {
                            string col = Tabla.Columns[i].ColumnName
                                            .Trim()
                                            .Replace("\r", "")
                                            .Replace("\n", "")
                                            .Replace(";", ",");

                            sw.Write(col);
                            if (i < Tabla.Columns.Count - 1) sw.Write(";");
                        }
                        sw.WriteLine();


                        foreach (DataRow row in Tabla.Rows)
                        {
                            for (int i = 0; i < Tabla.Columns.Count; i++)
                            {
                                string valor = row[i]?.ToString()
                                                    .Trim()
                                                    .Replace("\r", "")
                                                    .Replace("\n", "")
                                                    .Replace(";", ",");

                                sw.Write(valor);
                                if (i < Tabla.Columns.Count - 1) sw.Write(";");
                            }
                            sw.WriteLine();
                        }
                    }

                    MessageBox.Show("Reporte exportado correctamente.");
                }
            }


        }
        Bitmap Datos;

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count ==0)
            {
                MessageBox.Show("No hay datos para exportar");
                return;
            }

            CapturarDatos();

            PrintDocument pd = new PrintDocument();
            pd.DefaultPageSettings.Landscape = true;

            pd.PrintPage += (s, ev) =>
            {
                ev.Graphics.DrawImage(Datos, 0, 0);
                ev.HasMorePages = false;
            };

            PrintDialog dlg = new PrintDialog();
            dlg.Document = pd;

            MessageBox.Show("Selecciona Print to PDF y guarda el archivo");
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                pd.Print();
            }

        }
    }
}
