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
    public partial class InfCarroCliente : Form
    {
        acessoCarroCliente carc = new acessoCarroCliente();
        acessoCliente cli = new acessoCliente();
        int linha, qtd_linha;


        public InfCarroCliente()
        {
            InitializeComponent();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (carc.pesquisarCarroCliente(Cripto.cripto(txtNomePesq.Text)) == true)
            {
                txtId.Text = carc.Id_cc.ToString();
                txtCliAtual.Text = carc.Nome_cli;
                txtnome_cc.Text = carc.Nome_cc.ToString();
                txtModelo.Text = carc.Modelo_cc.ToString();
                txtMarca.Text = carc.Marca_cc.ToString();
                txtAno_Fab.Text = carc.Anofab_cc.ToString();
                txtCor.Text = carc.Cor_cc.ToString();
                txtCombustivel.Text = carc.Combustivel_cc.ToString();
                txtNum_Portas.Text = carc.Portas_cc.ToString();
                txtKm.Text = carc.Km_cc.ToString();
                txtfinalplaca_cc.Text = carc.Finalplaca_cc.ToString();
                txtopcionais_cc.Text = carc.Opcionais_cc.ToString();
                txtdesc_cc.Text = carc.Desc_cc.ToString();
                txtvalor_cc.Text = carc.Valor_cc.ToString();
                txtFotoAtual.Text = carc.Foto_cc.ToString();

                if (carc.Foto_cc.ToString() == "CarroSemFoto.jpg")
                {
                    Bitmap bmp = new Bitmap(pictureBox1.ImageLocation = ("D:\\TCC-SITE\\FotoCarroCliente\\" + "CarroSemFoto.jpg"));

                    Bitmap bmp2 = new Bitmap(bmp, pictureBox1.Size);

                    pictureBox1.Image = bmp2;


                }
                else
                {
                    Bitmap bmp = new Bitmap(pictureBox1.ImageLocation = ("D:\\TCC-SITE\\FotoCarroCliente\\" + carc.Foto_cc.ToString()));

                    Bitmap bmp2 = new Bitmap(bmp, pictureBox1.Size);

                    pictureBox1.Image = bmp2;
                }



                btnAlterar.Enabled = true;
                btnExcluir.Enabled = true;
                btnProximo.Enabled = false;
                btnAnterior.Enabled = false;

                if (carc.Lista_carc != null)
                {
                    btnProximo.Enabled = true;
                    qtd_linha = carc.Lista_carc.Rows.Count;
                }
                else
                {
                    btnProximo.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Carro não cadastrado");
                limpar();
                btnProximo.Enabled = false;
                btnAnterior.Enabled = false;
            }
        }


        public void limpar()
        {
            txtId.Clear();
            txtAno_Fab.Clear();
            txtNum_Portas.Clear();
            txtnome_cc.Clear();
            txtMarca.Clear();
            txtModelo.Clear();
            txtCor.Clear();
            txtCombustivel.Clear();
            txtopcionais_cc.Clear();
            txtdesc_cc.Clear();
            txtKm.Clear();
            txtvalor_cc.Clear();
            txtfinalplaca_cc.Clear();
            txtCliAtual.Clear();
            cmbCliente.Text = "";
            txtUrlImage.Clear();
            pictureBox1.Image = null;
            
        }

        public void exibir()
        {
            txtId.Text = carc.Lista_carc.Rows[linha]["id_cc"].ToString();
            txtCliAtual.Text = carc.Lista_carc.Rows[linha]["nome_cli"].ToString();
            txtAno_Fab.Text = carc.Lista_carc.Rows[linha]["anofab_cc"].ToString();
            txtNum_Portas.Text = carc.Lista_carc.Rows[linha]["portas_cc"].ToString();
            txtnome_cc.Text = carc.Lista_carc.Rows[linha]["nome_cc"].ToString();
            txtMarca.Text = carc.Lista_carc.Rows[linha]["marca_cc"].ToString();
            txtModelo.Text = carc.Lista_carc.Rows[linha]["modelo_cc"].ToString();
            txtCor.Text = carc.Lista_carc.Rows[linha]["cor_cc"].ToString();
            txtCombustivel.Text = carc.Lista_carc.Rows[linha]["combustivel_cc"].ToString();
            txtopcionais_cc.Text = carc.Lista_carc.Rows[linha]["opcionais_cc"].ToString();
            txtdesc_cc.Text = carc.Lista_carc.Rows[linha]["desc_cc"].ToString();
            txtKm.Text = carc.Lista_carc.Rows[linha]["km_cc"].ToString();
            txtvalor_cc.Text = carc.Lista_carc.Rows[linha]["valor_cc"].ToString();
            txtfinalplaca_cc.Text = carc.Lista_carc.Rows[linha]["finalplaca_cc"].ToString();
            txtFotoAtual.Text = carc.Lista_carc.Rows[linha]["foto_cc"].ToString();


            Bitmap bmp = new Bitmap(carc.Foto_cc.ToString());

            Bitmap bmp2 = new Bitmap(bmp, pictureBox1.Size);

            pictureBox1.Image = bmp2;
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            txtNomePesq.Text = listBox1.Text;
            listBox1.Visible = false;
            this.btnPesquisar_Click(sender, e);
        }

        private void txtNomePesq_TextChanged(object sender, EventArgs e)
        {
            listBox1.Visible = true;
            listBox1.DataSource = carc.filtro(txtNomePesq.Text);
            listBox1.DisplayMember = "nome_cc";
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (linha > 0)
            {
                linha--;
                exibir();
                btnProximo.Enabled = true;
            }
            if (linha == 0)
            {
                btnAnterior.Enabled = false;
                btnProximo.Enabled = true;
            }
        }

        private void btnProximo_Click(object sender, EventArgs e)
        {
            if (linha < (qtd_linha - 1))
            {
                linha++;
                exibir();
                btnAnterior.Enabled = true;

            }
            if (linha == (qtd_linha - 1))
            {
                btnAnterior.Enabled = true;
                btnProximo.Enabled = false;

            }
        }

        private void carregarCli()
        {
            cmbCliente.DataSource = cli.listarTudo();
            cmbCliente.DisplayMember = "nome_cli";
            cmbCliente.ValueMember = "id_cli";
        }

        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cli.pesquisarCliente(cmbCliente.SelectedValue.ToString());
            }
            catch { }
        }

        private void InfCarroCliente_Load(object sender, EventArgs e)
        {
            carregarCli();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            string nomeFoto;
            if (openFileDialog1.FileName == null)
                nomeFoto = txtFotoAtual.Text;
            else
                nomeFoto = openFileDialog1.SafeFileName.ToString();
            
            
            
            
            DialogResult resp;
            resp = MessageBox.Show("Deseja realmente alterar estes dados ?", "Alterar ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resp == DialogResult.Yes)
            {
                if (cmbCliente.Text == string.Empty || txtMarca.Text == string.Empty ||
                txtCor.Text == string.Empty || txtnome_cc.Text == string.Empty || txtAno_Fab.Text == string.Empty ||
                txtCombustivel.Text == string.Empty || txtNum_Portas.Text == string.Empty || txtvalor_cc.Text == string.Empty ||
                txtKm.Text == string.Empty || txtfinalplaca_cc.Text == string.Empty || txtvalor_cc.Text == string.Empty)
                {
                    MessageBox.Show("Favor preencher os campos em vermelho");

                    if (cmbCliente.Text == string.Empty)
                        cmbCliente.BackColor = Color.Red;
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
                            if (0 >= Convert.ToInt32(txtvalor_cc.Text))
                            {
                                MessageBox.Show("Verificar campos de valores", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else
                            {
                                if (carc.alterar(cmbCliente.SelectedValue.ToString(), txtnome_cc.Text, txtModelo.Text, txtMarca.Text, txtAno_Fab.Text, txtCor.Text, txtCombustivel.Text, txtNum_Portas.Text, txtKm.Text.Replace(',', '.'), txtfinalplaca_cc.Text, txtopcionais_cc.Text, txtdesc_cc.Text, txtvalor_cc.Text.Replace(',', '.'),nomeFoto, txtId.Text) == true)
                                {
                                    MessageBox.Show("Dados Alterados com sucesso!!");
                                    limpar();
                                    btnAlterar.Enabled = false;
                                    btnExcluir.Enabled = false;
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
            else
            {
                btnAlterar.Enabled = false;
                btnExcluir.Enabled = false;
                limpar();
                MessageBox.Show("Os dados não foram alterados.");
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult resp;
            resp = MessageBox.Show("Deseja realmente excluir?", "Excluir?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resp == DialogResult.Yes)
            {
                carc.excluir(txtId.Text);
                btnExcluir.Enabled = false;
                btnAlterar.Enabled = false;
                limpar();
                MessageBox.Show("Carro Cliente foi excluído com sucesso.");
            }
            else
            {
                btnAlterar.Enabled = false;
                btnExcluir.Enabled = false;
                limpar();
                MessageBox.Show("Exclusão cancelada.");
            }
        }

        private void txtMarca_TextChanged(object sender, EventArgs e)
        {
            txtMarca.BackColor = Color.Empty;
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

        private void txtvalor_cc_TextChanged(object sender, EventArgs e)
        {
            txtvalor_cc.BackColor = Color.Empty;
        }

        private void txtvalorfin_cc_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtvalorent_cc_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNumParc_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
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
    }
}
