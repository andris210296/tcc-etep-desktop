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
    public partial class CadastrarFornecedor : Form
    {
        acessoFornecedor forn = new acessoFornecedor();
        Validacao validar = new Validacao();

        public CadastrarFornecedor()
        {
            InitializeComponent();
        }

        public void limpar()
        {
            txtEmail.Clear();
            txtNome.Clear();
            txtCidade.Clear();
            txtUf.Text = "";
            mskCNPJ.Clear();
            txtPais.Clear();
            mskFone.Clear();
            txtSite.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == string.Empty || mskCNPJ.MaskFull == false || txtPais.Text == string.Empty || txtCidade.Text == string.Empty || mskFone.MaskFull == false || txtEmail.Text == string.Empty || txtUf.Text == string.Empty)
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
                // ValidandO CNPJ
                string cnpjV = mskCNPJ.Text;

                txtCNPJverificado.Text = cnpjV;

                string substring1 = cnpjV.Substring(0, 2);
                string substring2 = cnpjV.Substring(3, 3);
                string substring3 = cnpjV.Substring(7, 3);
                string substring4 = cnpjV.Substring(11, 4);
                string substring5 = cnpjV.Substring(16, 2);


                txtCNPJverificado.Text = substring1 + substring2 + substring3 + substring4 + substring5;

                if (validar.ValidarCNPJ(txtCNPJverificado.Text) == true)
                {
                    if (forn.inserir(txtNome.Text, mskCNPJ.Text, txtPais.Text, txtCidade.Text, mskFone.Text, txtEmail.Text, txtSite.Text, txtUf.Text) == true)
                    {
                        limpar();
                        MessageBox.Show("Cadastrado com sucesso!");
                    }
                    else
                    {
                        MessageBox.Show("Favor verificar os dados preenchidos");
                    }
                }
                else
                {
                    MessageBox.Show("CNPJ Inválido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }


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

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtUf_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtUf.BackColor = Color.Empty;
        }

        private void txtPais_TextChanged_1(object sender, EventArgs e)
        {
            txtPais.BackColor = Color.Empty;
        }

        private void txtCidade_TextChanged_1(object sender, EventArgs e)
        {
            txtCidade.BackColor = Color.Empty;
        }

        private void txtEmail_TextChanged_1(object sender, EventArgs e)
        {
            txtEmail.BackColor = Color.Empty;
        }

        private void mskCNPJ_MaskInputRejected_1(object sender, MaskInputRejectedEventArgs e)
        {
            mskCNPJ.BackColor = Color.Empty;
        }

        private void mskFone_MaskInputRejected_1(object sender, MaskInputRejectedEventArgs e)
        {
            mskFone.BackColor = Color.Empty;
        }

        private void CadastrarFornecedor_Load(object sender, EventArgs e)
        {

        }
    }
}
