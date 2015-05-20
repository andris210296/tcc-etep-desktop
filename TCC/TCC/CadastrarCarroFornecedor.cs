using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace TCC
{
    public partial class CadastrarCarroFornecedor : Form
    {

        acessoCarroFornecedor carf = new acessoCarroFornecedor();
        acessoFornecedor forn = new acessoFornecedor();


        public CadastrarCarroFornecedor()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void carregarForn()
        {
            cmbFornecedor.DataSource = forn.listarTudo();
            cmbFornecedor.DisplayMember = "nome_forn";
            cmbFornecedor.ValueMember = "id_forn";
        }

        public void limpar()
        {
            txtmarca_cc.Clear();
            txtmodelo_cc.Clear();
            txtcor_cc.Clear();
            txtqtd.Clear();
            txtNum_Portas.Clear();
            txtopcionais_cc.Clear();
            txtdesc_cc.Clear();
            txtnome_cc.Clear();
            txtAno_Fab.Clear();
            txtCombustivel.Clear();
            txtopcionais_cc.Clear();
            txtpreco.Clear();
            pictureBox1.Image = null;
            txtUrlImage.Clear();

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {

           string nomeFoto;
            if (txtUrlImage.Text =="")
                nomeFoto = "CarroSemFoto.jpg";
            else
                nomeFoto = openFileDialog1.SafeFileName.ToString();



            if (cmbFornecedor.Text == string.Empty || txtmarca_cc.Text == string.Empty ||
                txtcor_cc.Text == string.Empty || txtnome_cc.Text == string.Empty || txtAno_Fab.Text == string.Empty ||
                txtCombustivel.Text == string.Empty || txtNum_Portas.Text == string.Empty || txtpreco.Text == string.Empty || txtqtd.Text == string.Empty)
            {
                MessageBox.Show("Favor preencher os campos em vermelho");

                if (cmbFornecedor.Text == string.Empty)
                    cmbFornecedor.BackColor = Color.Red;
                if (txtmarca_cc.Text == string.Empty)
                    txtmarca_cc.BackColor = Color.Red;
                if (txtcor_cc.Text == string.Empty)
                    txtcor_cc.BackColor = Color.Red;
                if (txtnome_cc.Text == string.Empty)
                    txtnome_cc.BackColor = Color.Red;
                if (txtAno_Fab.Text == string.Empty)
                    txtAno_Fab.BackColor = Color.Red;
                if (txtCombustivel.Text == string.Empty)
                    txtCombustivel.BackColor = Color.Red;
                if (txtNum_Portas.Text == string.Empty)
                    txtNum_Portas.BackColor = Color.Red;
                if (txtpreco.Text == string.Empty)
                    txtpreco.BackColor = Color.Red;
                if (txtqtd.Text == string.Empty)
                    txtqtd.BackColor = Color.Red;

            }
            else
            {
                if (carf.inserir(cmbFornecedor.SelectedValue.ToString(), txtnome_cc.Text, txtmodelo_cc.Text, txtmarca_cc.Text, txtAno_Fab.Text, txtcor_cc.Text, txtCombustivel.Text, txtNum_Portas.Text, txtopcionais_cc.Text, txtdesc_cc.Text, txtpreco.Text.Replace(',', '.'), txtqtd.Text,nomeFoto) == true)
                {
                    limpar();
                    MessageBox.Show("Carro cadastrado com sucesso");
                }
                else
                {
                    MessageBox.Show("Verificar Campos");
                }
            }
        }

        private void CadastrarCarroFornecedor_Load(object sender, EventArgs e)
        {
            carregarForn();
        }

        private void cmbFornecedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbFornecedor.Text = "";
            cmbFornecedor.BackColor = Color.Empty;
            try
            {
                forn.pesquisarFornecedor(cmbFornecedor.SelectedValue.ToString());
            }
            catch { }
        }

        private void txtAno_Fab_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '\b')
            {
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtNum_Portas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '\b')
            {
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtqtd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '\b')
            {
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtpreco_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == ',' || e.KeyChar == '.')
            {
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtkm_cc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == ',' || e.KeyChar == '.')
            {
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtmarca_cc_TextChanged(object sender, EventArgs e)
        {
            txtmarca_cc.BackColor = Color.Empty;
        }

        private void txtmodelo_cc_TextChanged(object sender, EventArgs e)
        {
            txtmodelo_cc.BackColor = Color.Empty;
        }

        private void txtcor_cc_TextChanged(object sender, EventArgs e)
        {
            txtcor_cc.BackColor = Color.Empty;
        }

        private void txtqtd_TextChanged(object sender, EventArgs e)
        {
            txtqtd.BackColor = Color.Empty;
        }

        private void txtNum_Portas_TextChanged(object sender, EventArgs e)
        {
            txtNum_Portas.BackColor = Color.Empty;
        }

        private void txtopcionais_cc_TextChanged(object sender, EventArgs e)
        {
            txtopcionais_cc.BackColor = Color.Empty;
        }

        private void txtnome_cc_TextChanged(object sender, EventArgs e)
        {
            txtnome_cc.BackColor = Color.Empty;
        }

        private void txtAno_Fab_TextChanged(object sender, EventArgs e)
        {
            txtAno_Fab.BackColor = Color.Empty;
        }

        private void txtCombustivel_TextChanged(object sender, EventArgs e)
        {
            txtCombustivel.BackColor = Color.Empty;
        }

        private void txtpreco_TextChanged(object sender, EventArgs e)
        {
            txtpreco.BackColor = Color.Empty;
        }

        private void txtdesc_cc_TextChanged(object sender, EventArgs e)
        {
            txtdesc_cc.BackColor = Color.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            openFileDialog1.ShowDialog();
            openFileDialog1.RestoreDirectory = true;


           
                openFileDialog1.Filter = "Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF|" + "All files (*.*)|*.*";
          
                Bitmap bmp = new Bitmap(openFileDialog1.FileName);

                Bitmap bmp2 = new Bitmap(bmp, pictureBox1.Size);

                pictureBox1.Image = bmp2;


                string nomeFoto = openFileDialog1.SafeFileName.ToString();



                pictureBox1.Image.Save("D:\\TCC-SITE\\FotoCarroFornecedor\\" + nomeFoto);
                txtUrlImage.Text = "D:\\TCC-SITE\\FotoCarroFornecedor\\" + nomeFoto;

      

           
        }


    }
}
