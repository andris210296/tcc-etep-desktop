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
    public partial class InfFornecedor : Form
    {
        acessoFornecedor forn = new acessoFornecedor();
        int linha, qtd_linha;

        public InfFornecedor()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = forn.listarTudo();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            
            if (forn.pesquisarFornecedor(Cripto.cripto(txtNomePesq.Text)) == true)
            {
                txtId.Text = forn.Id_forn.ToString();
                txtNome.Text = forn.Nome_forn.ToString();
                mskCNPJ.Text = forn.Cnpj_forn.ToString();
                txtCidade.Text = forn.Cidade_forn.ToString();
                txtEmail.Text = forn.Email_forn.ToString();
                txtPais.Text = forn.Pais_forn.ToString();
                mskFone.Text = forn.Fone_forn.ToString();
                txtSite.Text = forn.Site_forn.ToString();
                txtUf.Text = forn.Uf_forn.ToString();

                btnAlterar.Enabled = true;
                btnExcluir.Enabled = true;
                btnProximo.Enabled = false;
                btnAnterior.Enabled = false;

                if (forn.Lista_fornecedor != null)
                {
                   btnProximo.Enabled = true;
                    qtd_linha = forn.Lista_fornecedor.Rows.Count;
                }
                else
                {
                    btnProximo.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Nome não cadastrado");
                limpar();
                btnProximo.Enabled = false;
                btnAnterior.Enabled = false;
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult resp;
            resp = MessageBox.Show("Deseja realmente excluir?", "Excluir?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resp == DialogResult.Yes)
            {
                forn.excluir(txtId.Text);
                btnExcluir.Enabled = false;
                btnAlterar.Enabled = false;
                limpar();
                MessageBox.Show("Fornecedor excluído com sucesso.");
            }
            else
            {
                btnAlterar.Enabled = false;
                btnExcluir.Enabled = false;
                limpar();
                MessageBox.Show("Exclusão cancelada.");
            }
        }


        public void limpar()
        {
            txtId.Clear();
            txtNome.Clear();
            mskCNPJ.Clear();
            txtCidade.Clear();
            txtEmail.Clear();
            txtPais.Clear();
            mskFone.Clear();
            txtSite.Clear();
            txtUf.Text = "";
            txtUf.SelectedValue = "";
 
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            DialogResult resp;
            resp = MessageBox.Show("Deseja realmente alterar estes dados ?", "Alterar ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resp == DialogResult.Yes)
            {
                if (txtNome.Text == string.Empty || mskCNPJ.MaskFull == false || txtPais.Text == string.Empty || txtCidade.Text == string.Empty || mskFone.MaskFull == false || txtEmail.Text == string.Empty)
                {
                    MessageBox.Show("favor preencher o(s) campo(s) em vermelho");
                    if (txtNome.Text == string.Empty)
                        txtNome.BackColor = Color.Red;
                    if (mskCNPJ.MaskFull == false)
                        mskCNPJ.BackColor = Color.Red;
                    if (txtPais.Text == string.Empty)
                        txtPais.BackColor = Color.Red;
                    if (txtCidade.Text == string.Empty)
                        txtCidade.BackColor = Color.Red;
                    if (mskFone.MaskFull == false)
                        mskFone.BackColor = Color.Red;
                    if (txtEmail.Text == string.Empty)
                        txtEmail.BackColor = Color.Red;
                    if (txtUf.Text == string.Empty)
                        txtUf.BackColor = Color.Red;
                                 }
                else
                {
                    if (forn.alterar(txtNome.Text, mskCNPJ.Text, txtPais.Text, txtCidade.Text, mskFone.Text, txtEmail.Text, txtSite.Text, txtUf.Text, txtId.Text) == true)
                    {
                        limpar();
                        btnAlterar.Enabled = false;
                        btnExcluir.Enabled = false;
                        MessageBox.Show("Dados Alterados com sucesso!!");
                    }
                    else
                    {
                        MessageBox.Show("CNPJ já cadastrato!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        public void exibir()
        {
            txtId.Text = forn.Lista_fornecedor.Rows[linha]["id_forn"].ToString();
            txtNome.Text = forn.Lista_fornecedor.Rows[linha]["nome_forn"].ToString();
            mskCNPJ.Text = forn.Lista_fornecedor.Rows[linha]["cnpj_forn"].ToString();
            txtCidade.Text = forn.Lista_fornecedor.Rows[linha]["cidade_forn"].ToString();
            txtEmail.Text = forn.Lista_fornecedor.Rows[linha]["email_forn"].ToString();
            txtPais.Text = forn.Lista_fornecedor.Rows[linha]["pais_forn"].ToString();
            mskFone.Text = forn.Lista_fornecedor.Rows[linha]["fone_forn"].ToString();
            txtSite.Text = forn.Lista_fornecedor.Rows[linha]["site_forn"].ToString();
            txtUf.Text = forn.Lista_fornecedor.Rows[linha]["uf_forn"].ToString();
           
        
        }


        private void listBox1_DoubleClick(object sender, EventArgs e)
        {

            txtNomePesq.Text = listBox1.Text;
            listBox1.Visible = false;
            this.button1_Click(sender, e);

        }

        private void txtNomePesq_TextChanged(object sender, EventArgs e)
        {
            listBox1.Visible = true;
            listBox1.DataSource = forn.filtro(txtNomePesq.Text);
            listBox1.DisplayMember = "nome_forn";
        }




        private void button1_Click_1(object sender, EventArgs e)
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

        private void button2_Click_1(object sender, EventArgs e)
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

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            txtNome.BackColor = Color.Empty;
        }

        private void mskCNPJ_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            mskCNPJ.BackColor = Color.Empty;
        }

        private void txtPais_TextChanged(object sender, EventArgs e)
        {
            txtPais.BackColor = Color.Empty;
        }

        private void txtCidade_TextChanged(object sender, EventArgs e)
        {
            txtCidade.BackColor = Color.Empty;
        }

        private void mskFone_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            mskFone.BackColor = Color.Empty;
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            txtEmail.BackColor = Color.Empty;
        }



    }
}  
