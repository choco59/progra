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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public cliente clienteactual { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            bdcomun.Obtenerconexion();
            MessageBox.Show("conectado");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cliente pcliente = new cliente();
            pcliente.ci = int.Parse(textBox1.Text);
            pcliente.nombre = textBox2.Text.Trim();
            int resultado = clientesDAL.Agregar(pcliente);
            if (resultado > 0)
            {
                MessageBox.Show("client guardao", "guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("no se spuede", "fallo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); 
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 buscar = new Form2();
            buscar.ShowDialog();
            if (buscar.clienteseleccionado != null)
            {
                clienteactual = buscar.clienteseleccionado;
                textBox1.Text = Convert.ToString(buscar.clienteseleccionado.ci);
                textBox2.Text = buscar.clienteseleccionado.nombre;
 
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            cliente pcliente= new cliente();
            pcliente.nombre = textBox2.Text.Trim();
            pcliente.ci = clienteactual.ci;
            if (clientesDAL.actualizar(pcliente) > 0)
            {
                MessageBox.Show("dtos actuali", "actulzados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("no se actualiz", "error al actualizar", MessageBoxButtons.OK, MessageBoxIcon.Information); 
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("esta seguro de elimanr ", "stas seguro", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (clientesDAL.eliminar(clienteactual.ci) > 0)
                {
                    MessageBox.Show("cliente elmiminado correctamente", "cliente eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("no se pudo elmiminar al clien", "cliente no elminiando", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
                MessageBox.Show("se cancelo l eliminacion", "cancelada la eliminacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
    }
}
