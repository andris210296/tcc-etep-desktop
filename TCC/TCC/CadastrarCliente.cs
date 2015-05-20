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
    public partial class CadastrarCliente : Form
    {
        SaveFileDialog save = new SaveFileDialog();
        acessoCliente cli = new acessoCliente();
        Cep cep = new Cep();
        Validacao validar = new Validacao();

        public CadastrarCliente()
        {
            InitializeComponent();
        }

        public void limpar()
        {
            txtEmail.Clear();
            txtSenha.Clear();
            txtConfirmarSenha.Clear();
            txtNome.Clear();
            mskDatanasc.Clear();
            mskRg.Clear();
            mskCpf.Clear();
            txtSexo.Text = "";
            txtEstatoCivil.Text = "";
            mskCep.Clear();
            txtEndereco.Clear();
            txtBairro.Clear();
            txtCasa.Clear();
            txtcomplemento.Clear();
            txtCidade.Clear();
              mskCel.Clear();
            mskTel.Clear();
            cmbTipoPessoa.Text = "";
            txtNumDependentes.Clear();
            mskCepEmp.Clear();
            txtProfissao.Clear();
            txtEmpresaCliente.Clear();
            txtCidadeEmpresa.Clear();
            mskTelCom.Clear();
            txtBanco.Clear();
            txtTipoConta.Clear();
            txtAgencia.Clear();
            txtRenda.Clear();
            txtNumConta.Clear();
            textBox1.Clear();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text == string.Empty || txtSenha.Text == string.Empty || txtNome.Text == string.Empty
                 || mskDatanasc.MaskFull == false || mskRg.MaskFull == false || mskCpf.MaskFull == false
                 || txtSexo.Text == string.Empty || mskCep.MaskFull == false || txtEndereco.Text == string.Empty
                 || txtBairro.Text == string.Empty || txtCasa.Text == string.Empty || txtcomplemento.Text == string.Empty
                 || txtCidade.Text == string.Empty || mskTel.MaskFull == false
                 || cmbTipoPessoa.Text == string.Empty)
            {
                MessageBox.Show("favor preencher o(s) campo(s) em vermelho");
                if (txtEmail.Text == string.Empty)
                    txtEmail.BackColor = Color.Red;
                if (txtSenha.Text == string.Empty)
                    txtSenha.BackColor = Color.Red;
                if (txtNome.Text == string.Empty)
                    txtNome.BackColor = Color.Red;
                if (mskDatanasc.MaskFull == false)
                    mskDatanasc.BackColor = Color.Red;
                if (mskRg.MaskFull == false)
                    mskRg.BackColor = Color.Red;
                if (mskCpf.MaskFull == false)
                    mskCpf.BackColor = Color.Red;
                if (txtSexo.Text == string.Empty)
                    txtSexo.BackColor = Color.Red;
                if (mskCep.MaskFull == false)
                    mskCep.BackColor = Color.Red;
                if (txtEndereco.Text == string.Empty)
                    txtEndereco.BackColor = Color.Red;
                if (txtBairro.Text == string.Empty)
                    txtBairro.BackColor = Color.Red;
                if (txtCasa.Text == string.Empty)
                    txtCasa.BackColor = Color.Red;
                if (txtCidade.Text == string.Empty)
                    txtCidade.BackColor = Color.Red;
                        if (mskTel.MaskFull == false)
                    mskTel.BackColor = Color.Red;
                if (cmbTipoPessoa.Text == string.Empty)
                    cmbTipoPessoa.BackColor = Color.Red;
            }
            else
            {
                DateTime dataNasc = new DateTime();
                int anoAtual, verificacao;

                dataNasc = DateTime.Parse(mskDatanasc.Text);
                anoAtual = DateTime.Now.Year;

                verificacao = anoAtual - Convert.ToInt32(dataNasc.Year);

                if (verificacao >= 18)
                {

                    if (txtSenha.TextLength >= 6)
                    {
                        if (txtSenha.Text == txtConfirmarSenha.Text)
                        {
                            string endereco;
                            endereco = textBox1.Text + " " + txtEndereco.Text;

                            // Validando CPF
                            string cpfV = mskCpf.Text;

                            CpfValida.Text = cpfV;

                            string substring1 = cpfV.Substring(0, 3);
                            string substring2 = cpfV.Substring(4, 3);
                            string substring3 = cpfV.Substring(8, 3);
                            string substring4 = cpfV.Substring(12, 2);

                            CpfValida.Text = substring1 + substring2 + substring3 + substring4;

                            string nomeFoto = "ClienteSemFoto.jpg";
                            
                            
                            if (validar.ValidarCPF(CpfValida.Text) == true)
                            {
                                if (cli.inserir(txtEmail.Text, txtSenha.Text, txtNome.Text, mskDatanasc.Text, mskRg.Text, mskCpf.Text,
                                txtSexo.Text, txtEstatoCivil.Text, mskCep.Text, endereco, txtBairro.Text, txtCasa.Text,
                                txtcomplemento.Text, txtCidade.Text, mskTel.Text, mskCel.Text, cmbTipoPessoa.Text,
                                txtNumDependentes.Text, txtProfissao.Text, txtEmpresaCliente.Text, mskCepEmp.Text, txtEndEmpresa.Text,
                                txtBairroEmp.Text, txtCidadeEmpresa.Text, mskTelCom.Text, txtBanco.Text,
                                txtTipoConta.Text, txtAgencia.Text, txtNumConta.Text, txtRenda.Text,nomeFoto) == true)
                                {
                                    limpar();
                                    MessageBox.Show("Cadastrado com sucesso!");
                                }

                                else
                                {
                                    MessageBox.Show("Favor verificar os dados");
                                }
                            }
                            else
                            {
                                MessageBox.Show("CPF Inválido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Sua senha não é compativel, favor verificar", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("A senha deve ter no mínimo 6 digitos!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("Cliente menor de idade!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            txtNome.BackColor = Color.Empty;
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            txtEmail.BackColor = Color.Empty;
        }

        private void txtSenha_TextChanged(object sender, EventArgs e)
        {
            txtSenha.BackColor = Color.Empty;
        }

        private void mskRg_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            mskRg.BackColor = Color.Empty;
        }

        private void txtSexo_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSexo.BackColor = Color.Empty;
        }

        private void mskDatanasc_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            mskDatanasc.BackColor = Color.Empty;
        }

        private void cmbTipoPessoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbTipoPessoa.BackColor = Color.Empty;
        }

        private void txtNumCasa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '\b')
            {
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtNumDependentes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '\b')
            {
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtNumConta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '\b')
            {
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtRenda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == ',')
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

        private void mskRg_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtCasa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '\b')
            {
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtCasa_TextChanged(object sender, EventArgs e)
        {
            txtCasa.BackColor = Color.Empty;
        }

        private void mskCpf_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            mskCpf.BackColor = Color.Empty;
        }

        private void mskCep_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            mskCep.BackColor = Color.Empty;
        }

        private void txtEndereco_TextChanged(object sender, EventArgs e)
        {
            txtEndereco.BackColor = Color.Empty;
        }

        private void txtBairro_TextChanged(object sender, EventArgs e)
        {
            txtBairro.BackColor = Color.Empty;
        }

        private void txtcomplemento_TextChanged(object sender, EventArgs e)
        {
            txtcomplemento.BackColor = Color.Empty;
        }

        private void txtCidade_TextChanged(object sender, EventArgs e)
        {
            txtCidade.BackColor = Color.Empty;
        }


        private void mskTel_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            mskTel.BackColor = Color.Empty;
        }

        private void txtRenda_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == ',' || e.KeyChar == '.')
            {
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtNumConta_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '\b')
            {
            }
            else
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cep.PesquisarCep(mskCep.Text) == true)
            {
                txtBairro.Text = cep.Bairro.ToString();
                txtCidade.Text = cep.Cidade.ToString();
                txtEndereco.Text = cep.Logradouro.ToString();
                textBox1.Text = cep.Tp_logradouro.ToString();


            }
            else
            {
                MessageBox.Show("Cep não encontrado");
                limpar2();
            }
        }

        public void limpar2()
        {
            mskCep.Clear();
            textBox1.Clear();
            txtEndereco.Clear();
            txtBairro.Clear();
            txtCidade.Clear();
        }

        private void btnEncontrar2_Click(object sender, EventArgs e)
        {
            if (cep.PesquisarCep(mskCepEmp.Text) == true)
            {
                txtBairroEmp.Text = cep.Bairro.ToString();
                txtCidadeEmpresa.Text = cep.Cidade.ToString();
                txtEndEmpresa.Text = cep.Logradouro.ToString();
                textBox2.Text = cep.Tp_logradouro.ToString();


            }
            else
            {
                MessageBox.Show("Cep não encontrado");
                limpar2();
            }
        }


    }
}
