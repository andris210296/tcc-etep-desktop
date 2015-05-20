using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TCC
{
    public partial class CadastrarCarroCliente : Form
    {
        acessoCarroCliente carc = new acessoCarroCliente();
        acessoCliente cli = new acessoCliente();
        int linha, qtd_linha;

        public CadastrarCarroCliente()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtKm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == ',' || e.KeyChar == '.')
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

        private void txtvalor_cc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == ',' || e.KeyChar == '.')
            {
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtvalorfin_cc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == ',' || e.KeyChar == '.')
            {
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtvalorent_cc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == ',' || e.KeyChar == '.')
            {
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtNumParc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '\b')
            {
            }
            else
            {
                e.Handled = true;
            }
        }

        private void CadastrarCarroCliente_Load(object sender, EventArgs e)
        {

        }

        public void limpar()
        {
            txtMarca.Clear();
            txtModelo.Clear();
            txtCor.Clear();
            txtKm.Clear();
            txtCombustivel.Clear();
            txtfinalplaca_cc.Clear();
            txtNum_Portas.Clear();
            txtdesc_cc.Clear();
            txtnome_cc.Clear();
            txtAno_Fab.Clear();
            txtopcionais_cc.Clear();
            txtvalor_cc.Clear();
            pictureBox1.Image = null;
            txtUrlImage.Clear();
           
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {


            string nomeFoto;
            if (txtUrlImage.Text == "")
                nomeFoto = "CarroSemFoto.jpg";
            else
                nomeFoto = openFileDialog1.SafeFileName.ToString();



            if (txtCliente.Text == string.Empty || txtMarca.Text == string.Empty ||
                txtCor.Text == string.Empty || txtnome_cc.Text == string.Empty || txtAno_Fab.Text == string.Empty ||
                txtCombustivel.Text == string.Empty || txtNum_Portas.Text == string.Empty || txtvalor_cc.Text == string.Empty ||
                txtKm.Text == string.Empty || txtfinalplaca_cc.Text == string.Empty ||
                txtvalor_cc.Text == string.Empty)
            {
                MessageBox.Show("Favor preencher os campos em vermelho");

                if (txtCliente.Text == string.Empty)
                    txtCliente.BackColor = Color.Red;
                if (txtMarca.Text == string.Empty)
                    txtMarca.BackColor = Color.Red;
                if (txtCor.Text == string.Empty)
                    txtCor.BackColor = Color.Red;
                if (txtnome_cc.Text == string.Empty)
                    txtnome_cc.BackColor = Color.Red;
                if (txtAno_Fab.Text == string.Empty)
                    txtAno_Fab.BackColor = Color.Red;
                if (txtCombustivel.Text == string.Empty)
                    txtCombustivel.BackColor = Color.Red;
                if (txtNum_Portas.Text == string.Empty)
                    txtNum_Portas.BackColor = Color.Red;
                if (txtKm.Text == string.Empty)
                    txtKm.BackColor = Color.Red;
                if (txtfinalplaca_cc.Text == string.Empty)
                    txtfinalplaca_cc.BackColor = Color.Red;
                if (txtvalor_cc.Text == string.Empty)
                    txtvalor_cc.BackColor = Color.Red;
            }
            else
            {
                if (txtfinalplaca_cc.TextLength != 4)
                {
                    MessageBox.Show("Final da Placa está faltando dígitos!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    if (txtAno_Fab.TextLength != 4)
                    {
                        MessageBox.Show("Ano de fabricação faltando dígitos!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        if (0 >= Convert.ToInt32(txtvalor_cc.Text.Replace(',', '.')))
                        {
                            MessageBox.Show("Verificar valor do carro", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {


                            

                            if (carc.inserir(txtId.Text, txtnome_cc.Text, txtModelo.Text, txtMarca.Text,
                                    txtAno_Fab.Text, txtCor.Text, txtCombustivel.Text, txtNum_Portas.Text, txtKm.Text,
                                    txtfinalplaca_cc.Text, txtopcionais_cc.Text, txtdesc_cc.Text, txtvalor_cc.Text.Replace(',', '.'), nomeFoto) == true)
                            {
                                limpar();
                                MessageBox.Show("Carro cadastrado com sucesso");
                            }
                            else
                            {
                                MessageBox.Show("Esse final da placa ja foi cadastrado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                    }
                }


            }
        }

        private void txtdesc_cc_TextChanged(object sender, EventArgs e)
        {
            txtdesc_cc.BackColor = Color.Empty;
        }

        private void txtMarca_TextChanged(object sender, EventArgs e)
        {
            txtMarca.BackColor = Color.Empty;
        }

        private void txtModelo_TextChanged(object sender, EventArgs e)
        {
            txtModelo.BackColor = Color.Empty;
        }

        private void txtCor_TextChanged(object sender, EventArgs e)
        {
            txtCor.BackColor = Color.Empty;
        }

        private void txtKm_TextChanged(object sender, EventArgs e)
        {
            txtKm.BackColor = Color.Empty;
        }

        private void txtCombustivel_TextChanged(object sender, EventArgs e)
        {
            txtCombustivel.BackColor = Color.Empty;
        }

        private void txtfinalplaca_cc_TextChanged(object sender, EventArgs e)
        {
            txtfinalplaca_cc.BackColor = Color.Empty;
        }

        private void txtNum_Portas_TextChanged(object sender, EventArgs e)
        {
            txtNum_Portas.BackColor = Color.Empty;
        }

        private void txtnome_cc_TextChanged(object sender, EventArgs e)
        {
            txtnome_cc.BackColor = Color.Empty;
        }

        private void txtAno_Fab_TextChanged(object sender, EventArgs e)
        {
            txtAno_Fab.BackColor = Color.Empty;
        }

        private void txtopcionais_cc_TextChanged(object sender, EventArgs e)
        {
            txtopcionais_cc.BackColor = Color.Empty;
        }

        private void txtvalor_cc_TextChanged(object sender, EventArgs e)
        {
            txtvalor_cc.BackColor = Color.Empty;
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (cli.pesquisarCliente(Cripto.cripto(txtCliente.Text)) == true)
            {
                txtId.Text = cli.Id_cli.ToString();

             

                MessageBox.Show("Cliente Encontrado");

            }
            else
            {
                MessageBox.Show("Nome não cadastrado");
                limpar();
               
            }
        }

        private void txtCliente_TextChanged(object sender, EventArgs e)
        {
            listBox1.Visible = true;
            listBox1.DataSource = cli.filtro(txtCliente.Text);
            listBox1.DisplayMember = "nome_cli";
        }

   

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            txtCliente.Text = listBox1.Text;
            listBox1.Visible = false;
            this.btnPesquisar_Click(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
           openFileDialog1.ShowDialog();
            openFileDialog1.RestoreDirectory = true;


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                openFileDialog1.Filter = "Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF|" + "All files (*.*)|*.*";


                Bitmap bmp = new Bitmap(openFileDialog1.FileName);

                Bitmap bmp2 = new Bitmap(bmp, pictureBox1.Size);

                pictureBox1.Image = bmp2;


                string nomeFoto = openFileDialog1.SafeFileName.ToString();



                pictureBox1.Image.Save("D:\\TCC-SITE\\FotoCarroCliente\\" + nomeFoto);
                txtUrlImage.Text = "D:\\TCC-SITE\\FotoCarroCliente\\" + nomeFoto;

            }


        }

        private void txtUrlImage_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}