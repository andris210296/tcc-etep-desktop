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
    public partial class InfCarroFornecedor : Form
    {
        acessoCarroFornecedor carf = new acessoCarroFornecedor();
        acessoFornecedor forn = new acessoFornecedor();
        int linha, qtd_linha;

        public InfCarroFornecedor()
        {
            InitializeComponent();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (carf.pesquisarCarroFornecedor( Cripto.cripto(txtNomePesq.Text)) == true)
            {
                txtId.Text = carf.Id_cf.ToString();
                txtFornAtual.Text = carf.Nome_forn;
                txtAno_Fab.Text = carf.Anofab_cf.ToString();
                txtqtd.Text = carf.Qtd_cf.ToString();
                txtNum_Portas.Text = carf.Portas_cf.ToString();
                txtnome_cc.Text = carf.Nome_cf.ToString();
                txtmodelo_cc.Text = carf.Modelo_cf.ToString();
                txtmarca_cc.Text = carf.Marca_cf.ToString();
                txtcor_cc.Text = carf.Cor_cf.ToString();
                txtCombustivel.Text = carf.Combustivel_cf.ToString();
                txtopcionais_cc.Text = carf.Opcionais_cf.ToString();
                txtdesc_cc.Text = carf.Desc_cf.ToString();
                txtpreco.Text = carf.Valor_cf.ToString();
                txtFornAtual.Text = carf.Foto_cf.ToString();

                if (carf.Foto_cf.ToString() == "CarroSemFoto.jpg")
                {
                    Bitmap bmp = new Bitmap(pictureBox1.ImageLocation = ("D:\\TCC-SITE\\FotoCarroFornecedor\\" + "CarroSemFoto.jpg"));

                    Bitmap bmp2 = new Bitmap(bmp, pictureBox1.Size);

                    pictureBox1.Image = bmp2;

                    
                }
                else
                {
                    Bitmap bmp = new Bitmap(pictureBox1.ImageLocation = ("D:\\TCC-SITE\\FotoCarroFornecedor\\" + carf.Foto_cf.ToString()));

                    Bitmap bmp2 = new Bitmap(bmp, pictureBox1.Size);

                    pictureBox1.Image = bmp2;
                }

                
                btnAlterar.Enabled = true;
                btnExcluir.Enabled = true;
                btnProximo.Enabled = false;
                btnAnterior.Enabled = false;

                if (carf.Lista_carf != null)
                {
                    btnProximo.Enabled = true;
                    qtd_linha = carf.Lista_carf.Rows.Count;
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
            txtqtd.Clear();
            txtNum_Portas.Clear();
            txtnome_cc.Clear();
            txtmarca_cc.Clear();
            txtmodelo_cc.Clear();
            txtcor_cc.Clear();
            txtCombustivel.Clear();
            txtopcionais_cc.Clear();
            txtdesc_cc.Clear();
            txtpreco.Clear();
            txtFornAtual.Clear();
            cmbFornecedor.Text = "";
            txtUrlImage.Clear();
            pictureBox1.Image = null;

        }

        public void exibir()
        {
            txtId.Text = carf.Lista_carf.Rows[linha]["id_cf"].ToString();
            txtFornAtual.Text = carf.Lista_carf.Rows[linha]["nome_forn"].ToString();
            txtAno_Fab.Text = carf.Lista_carf.Rows[linha]["anofab_cf"].ToString();
            txtqtd.Text = carf.Lista_carf.Rows[linha]["qtd_cf"].ToString();
            txtNum_Portas.Text = carf.Lista_carf.Rows[linha]["portas_cf"].ToString();
            txtnome_cc.Text = carf.Lista_carf.Rows[linha]["nome_cf"].ToString();
            txtmarca_cc.Text = carf.Lista_carf.Rows[linha]["marca_cf"].ToString();
            txtmodelo_cc.Text = carf.Lista_carf.Rows[linha]["modelo_cf"].ToString();
            txtcor_cc.Text = carf.Lista_carf.Rows[linha]["cor_cf"].ToString();
            txtCombustivel.Text = carf.Lista_carf.Rows[linha]["combustivel_cf"].ToString();
            txtopcionais_cc.Text = carf.Lista_carf.Rows[linha]["opcionais_cf"].ToString();
            txtdesc_cc.Text = carf.Lista_carf.Rows[linha]["desc_cf"].ToString();
            txtpreco.Text = carf.Lista_carf.Rows[linha]["valor_cf"].ToString();
            txtFotoAtual.Text = carf.Lista_carf.Rows[linha]["foto_cf"].ToString();
            
            Bitmap bmp = new Bitmap(carf.Foto_cf.ToString());

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
            listBox1.DataSource = carf.filtro(txtNomePesq.Text);
            listBox1.DisplayMember = "nome_cf";
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

        private void carregarForn()
        {
            cmbFornecedor.DataSource = forn.listarTudo();
            cmbFornecedor.DisplayMember = "nome_forn";
            cmbFornecedor.ValueMember = "id_forn";
        }

        private void cmbFornecedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                forn.pesquisarFornecedor(cmbFornecedor.SelectedValue.ToString());
            }
            catch { }
        }

        private void InfCarroFornecedor_Load(object sender, EventArgs e)
        {
            carregarForn();
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
                    if (carf.alterar(cmbFornecedor.SelectedValue.ToString(), txtnome_cc.Text, txtmodelo_cc.Text, txtmarca_cc.Text, txtAno_Fab.Text, txtcor_cc.Text, txtCombustivel.Text, txtNum_Portas.Text, txtopcionais_cc.Text, txtdesc_cc.Text, txtpreco.Text.Replace(',', '.'), txtqtd.Text, nomeFoto,txtId.Text) == true)
                    {
                        limpar();
                        btnAlterar.Enabled = false;
                        btnExcluir.Enabled = false;
                        btnProximo.Enabled = false;
                        btnAnterior.Enabled = false;
                        MessageBox.Show("Dados Alterados com sucesso!!");
                    }
                    else
                    {
                        MessageBox.Show("Verificar Campos");
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
                carf.excluir(txtId.Text);
                btnExcluir.Enabled = false;
                btnAlterar.Enabled = false;
                btnProximo.Enabled = false;
                btnAnterior.Enabled = false;
                limpar();
                MessageBox.Show("Carro Fornecedor foi excluído com sucesso.");
            }
            else
            {
                btnAlterar.Enabled = false;
                btnExcluir.Enabled = false;
                limpar();
                MessageBox.Show("Exclusão cancelada.");
            }
        }

        private void txtmarca_cc_TextChanged(object sender, EventArgs e)
        {
            txtmarca_cc.BackColor = Color.Empty;
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

        private void txtpreco_TextChanged(object sender, EventArgs e)
        {
            txtpreco.BackColor = Color.Empty;
        }

        private void txtCombustivel_TextChanged(object sender, EventArgs e)
        {
            txtCombustivel.BackColor = Color.Empty;
        }

        private void txtAno_Fab_TextChanged(object sender, EventArgs e)
        {
            txtAno_Fab.BackColor = Color.Empty;
        }

        private void txtnome_cc_TextChanged(object sender, EventArgs e)
        {
            txtnome_cc.BackColor = Color.Empty;
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



                pictureBox1.Image.Save("D:\\TCC-SITE\\FotoCarroFornecedor\\" + nomeFoto);
                txtUrlImage.Text = "D:\\TCC-SITE\\FotoCarroFornecedor \\" + nomeFoto;
            }
        }

        private void txtUrlImage_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

    }
}
