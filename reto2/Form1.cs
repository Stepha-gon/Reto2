using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Capaentidad;
using Capanegocio;
namespace reto2
{
    public partial class Form1 : Form
    {
        Classentidad objent = new Classentidad();
        Classnegocio objneg = new Classnegocio();
        public Form1()
        {
            InitializeComponent();
        }

        void insertar (String accion)
        {
            objent.code = Code.Text;
            objent.nombre = nombre.Text;
            objent.autor = autor.Text;
            objent.editor = editor.Text;
            objent.price = Convert.ToDouble(price.Text);
            objent.cant = Convert.ToInt32(cant.Text);
            objent.accion = accion;
            String message = objneg.n_insertar_libros(objent);
            MessageBox.Show(message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        void limpiar()
        {
            Code.Text="";
            nombre.Text = "";
            autor.Text = "";
            editor.Text = "";
            price.Text = "";
            cant.Text = "";
            buscarv.Text = "";
            dataGridView1.DataSource = objneg.n_listar_libros();


        }
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = objneg.n_listar_libros();

        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiar();
        }
        private void insertarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Code.Text == "")
            {
                if (MessageBox.Show("¿Registrar Dato?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    insertar("1");
                    limpiar();
                }
            }
                

        }
        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Code.Text != "")
            {
                if (MessageBox.Show("¿editar Dato?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    insertar("2");
                    limpiar();
                }
            }
        }
        private void eliminarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Code.Text != "")
            {
                if (MessageBox.Show("¿Eliminar Dato?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    insertar("3");
                    limpiar();
                }
            }

        }
        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void buscarv_TextChanged(object sender, EventArgs e)
        {

            if (buscarv.Text!="")
            {
                objent.nombre = nombre.Text;
                DataTable dt = new DataTable();
                dt = objneg.n_buscar_libros(objent);
                dataGridView1.DataSource = dt;
            }
            else
            {
                dataGridView1.DataSource = objneg.n_listar_libros();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dataGridView1.CurrentCell.RowIndex;
            Code.Text = dataGridView1[0,fila].Value.ToString();
            nombre.Text = dataGridView1[1, fila].Value.ToString();
            autor.Text = dataGridView1[2, fila].Value.ToString();
            editor.Text = dataGridView1[3, fila].Value.ToString();
            price.Text = dataGridView1[4, fila].Value.ToString();
            cant.Text = dataGridView1[5, fila].Value.ToString();
        }
    }
}
