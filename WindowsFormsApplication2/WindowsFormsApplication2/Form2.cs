using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public cliente clienteseleccionado { get; set; }
        private void button3_Click(object sender, EventArgs e)
        {
            int a;
            if (textBox1.Text.Length == 0) 
            { a = 1; }
            else
            {
                a = Convert.ToInt32(textBox1.Text);
            }
            dataGridView1.DataSource = clientesDAL.Buscar(a, textBox2.Text);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                clienteseleccionado = clientesDAL.obtenercliente(id);
                this.Close();

            }
            else
                MessageBox.Show("debe seleccionar ua fila");
        }
    }
}
