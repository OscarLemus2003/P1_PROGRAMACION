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

namespace P1_PROGRAMACION
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Conexion.Conectar();
            MessageBox.Show("Conexion exitosa compa");

            dataGridView1.DataSource = llenar_grid();
        }
        public DataTable llenar_grid()
        {
            Conexion.Conectar();
            DataTable dt = new DataTable();
            string consulta = "select * from tb_Musica";
            SqlCommand cmd = new SqlCommand(consulta,Conexion.Conectar());  

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string insertar = "INSERT INTO tb_Musica (Titulo,Artista,Genero,Album,Duracion,Disquera,Año)values(@Titulo,@Artista,@Genero,@Album,@Duracion,@Disquera,@Año)";
            SqlCommand cmd1 = new SqlCommand(insertar,Conexion.Conectar());
            cmd1.Parameters.AddWithValue("@Titulo",txtTitulo.Text);
            cmd1.Parameters.AddWithValue("@Artista",txtArtista.Text);
            cmd1.Parameters.AddWithValue("@Genero",txtGenero.Text);
            cmd1.Parameters.AddWithValue("@Album",txtAlbum.Text);
            cmd1.Parameters.AddWithValue("@Duracion",txtDuracion.Text);
            cmd1.Parameters.AddWithValue("@Disquera",txtDisquera.Text);
            cmd1.Parameters.AddWithValue("@Año",txtAño.Text);

            cmd1.ExecuteNonQuery();
            MessageBox.Show("Los datos fueron agreagados correctamente que proooo");

            dataGridView1.DataSource = llenar_grid();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try {

                txtTitulo.Text=dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtArtista.Text=dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtGenero.Text=dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtAlbum.Text=dataGridView1.CurrentRow.Cells[3].Value.ToString();
                txtDuracion.Text=dataGridView1.CurrentRow.Cells[4].Value.ToString();
                txtDisquera.Text=dataGridView1.CurrentRow.Cells[5].Value.ToString();
                txtAño.Text=dataGridView1.CurrentRow.Cells[6].Value.ToString();
            
            }

            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string actualizar = "UPDATE tb_Musica SET Titulo=@Titulo,Artista=@Artista,Genero=@Genero,Album=@Album,Duracion=@Duracion,Disquera=@Disquera,Año=@Año where Titulo=@Titulo";
            SqlCommand cmd2 = new SqlCommand(actualizar, Conexion.Conectar());

            cmd2.Parameters.AddWithValue("@Titulo",txtTitulo.Text);
            cmd2.Parameters.AddWithValue("@Artista",txtArtista.Text);
            cmd2.Parameters.AddWithValue("@Genero",txtGenero.Text);
            cmd2.Parameters.AddWithValue("@Album",txtAlbum.Text);
            cmd2.Parameters.AddWithValue("@Duracion",txtDuracion.Text);
            cmd2.Parameters.AddWithValue("@Disquera",txtDisquera.Text);
            cmd2.Parameters.AddWithValue("@Año",txtAño.Text);

            cmd2.ExecuteNonQuery();
            MessageBox.Show("Los datos han sido actualizados bro");
            dataGridView1.DataSource = llenar_grid();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string eliminar = "DELETE FROM tb_Musica where Titulo=@Titulo";
            SqlCommand cmd3 = new SqlCommand(eliminar, Conexion.Conectar());
            cmd3.Parameters.AddWithValue("@Titulo", txtTitulo.Text);

            cmd3.ExecuteNonQuery();
            MessageBox.Show("Los datos fueron borrados del mapa mi hermano");

            dataGridView1.DataSource = llenar_grid();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtTitulo.Clear();
            txtArtista.Clear();
            txtGenero.Clear();
            txtAlbum.Clear();   
            txtDuracion.Clear();
            txtDisquera.Clear();
            txtAño.Clear();
            txtTitulo.Focus();
           
         
        }
    }
}
