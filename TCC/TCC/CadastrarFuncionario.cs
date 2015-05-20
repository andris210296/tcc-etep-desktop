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
    public partial class CadastrarFuncionario : Form
    {
        acessoFuncionario func = new acessoFuncionario();
        Cep cep = new Cep();
        Validacao validar = new Validacao();

        public CadastrarFuncionario()
        {
            InitializeComponent();
        }

        private void txtSalario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == ',' || e.KeyChar == '.')
            {
            }
            else
            {
                e.Handled = true;
            }
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
            txtEstCivil.Text = "";
            txtSexo.Text = "";
            mskCep.Clear();
            txtEndereco.Clear();
            txtNumCasa.Clear();
            txtBairro.Clear();
            txtcomplemento.Clear();
            txtCidade.Clear();
            txtcartao.Clear();
      
            mskCel.Clear();
            mskTel.Clear();
            txtLogin.Clear();
            txtConfirmarSenha.Clear();
            txtTurno.Text = "";
            txtSalario.Clear();
            txtDepartamento.Clear();
        }

        private void btnCadstrar_Click(object sender, EventArgs e)
        {
            if (txtDepartamento.Text == string.Empty || txtTurno.Text == string.Empty || txtNome.Text == string.Empty
                || mskDatanasc.MaskFull == false || mskCpf.MaskFull == false || txtSexo.Text == string.Empty
                || txtSalario.Text == string.Empty || txtLogin.Text == string.Empty
                || txtSenha.Text == string.Empty || txtConfirmarSenha.Text == string.Empty
                || txtEndereco.Text == string.Empty || txtNumCasa.Text == string.Empty || txtCidade.Text == string.Empty
                || txtBairro.Text == string.Empty ||  mskCep.MaskFull == false
                || mskTel.MaskFull == false || txtEmail.Text == string.Empty || mskRg.MaskFull == false)
            {
                MessageBox.Show("favor preencher o(s) campo(s) em vermelho");
                if (txtEndereco.Text == string.Empty)
                    txtEndereco.BackColor = Color.Red;
                if (txtNumCasa.Text == string.Empty)
                    txtNumCasa.BackColor = Color.Red;
                if (txtCidade.Text == string.Empty)
                    txtCidade.BackColor = Color.Red;
                if (txtBairro.Text == string.Empty)
                    txtBairro.BackColor = Color.Red;

                if (mskCep.MaskFull == false)
                    mskCep.BackColor = Color.Red;
                if (mskTel.MaskFull == false)
                    mskTel.BackColor = Color.Red;
                if (txtEmail.Text == string.Empty)
                    txtEmail.BackColor = Color.Red;
                if (mskRg.MaskFull == false)
                    mskRg.BackColor = Color.Red;


                if (txtDepartamento.Text == string.Empty)
                    txtDepartamento.BackColor = Color.Red;
                if (txtTurno.Text == string.Empty)
                    txtTurno.BackColor = Color.Red;
                if (txtNome.Text == string.Empty)
                    txtNome.BackColor = Color.Red;
                if (mskDatanasc.MaskFull == false)
                    mskDatanasc.BackColor = Color.Red;
                if (mskCpf.MaskFull == false)
                    mskCpf.BackColor = Color.Red;
                if (txtSexo.Text == string.Empty)
                    txtSexo.BackColor = Color.Red;
                if (txtSalario.Text == string.Empty)
                    txtSalario.BackColor = Color.Red;
                if (txtLogin.Text == string.Empty)
                    txtLogin.BackColor = Color.Red;
                if (txtSenha.Text == string.Empty)
                    txtSenha.BackColor = Color.Red;
                if (txtConfirmarSenha.Text == string.Empty)
                    txtConfirmarSenha.BackColor = Color.Red;
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

                            textBox2.Text = cpfV;

                            string substring1 = cpfV.Substring(0, 3);
                            string substring2 = cpfV.Substring(4, 3);
                            string substring3 = cpfV.Substring(8, 3);
                            string substring4 = cpfV.Substring(12, 2);

                            textBox2.Text = substring1 + substring2 + substring3 + substring4;

                            if (validar.ValidarCPF(textBox2.Text) == true)
                            {

                                if (func.inserir(txtNome.Text, mskCpf.Text, txtEstCivil.Text, mskDatanasc.Text,
                                    txtSexo.Text, endereco.ToString(), txtNumCasa.Text, txtCidade.Text, txtBairro.Text
                                , mskCep.Text, mskTel.Text, mskCel.Text, txtSalario.Text, txtDepartamento.Text,
                                    txtTurno.Text, txtcomplemento.Text, txtEmail.Text, mskRg.Text, txtLogin.Text, txtSenha.Text, txtcartao.Text) == true)
                                {
                                    limpar();
                                    MessageBox.Show("Cadastrado com sucesso!");
                                }
                                else
                                {
                                    MessageBox.Show("Favor verificar dados preenchidos");
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
                    MessageBox.Show("Funcionario deve ser maior de 18 anos!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            txtNome.BackColor = Color.Empty;
        }


        private void txtSexo_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSexo.BackColor = Color.Empty;
        }

        private void mskDatanasc_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            mskDatanasc.BackColor = Color.Empty;
        }

        private void mskCpf_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            mskCpf.BackColor = Color.Empty;
        }

        private void txtEstCivil_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtEstCivil.BackColor = Color.Empty;
        }

        private void txtSalario_TextChanged(object sender, EventArgs e)
        {
            txtSalario.BackColor = Color.Empty;
        }

        private void txtDepartamento_TextChanged(object sender, EventArgs e)
        {
            txtDepartamento.BackColor = Color.Empty;
        }

        private void txtTurno_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTurno.BackColor = Color.Empty;
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

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtNumCasa_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '\b')
            {
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtLogin_TextChanged(object sender, EventArgs e)
        {
            txtLogin.BackColor = Color.Empty;
        }

        private void txtSenha_TextChanged(object sender, EventArgs e)
        {
            txtSenha.BackColor = Color.Empty;
        }

        private void txtConfirmarSenha_TextChanged(object sender, EventArgs e)
        {
            txtConfirmarSenha.BackColor = Color.Empty;
        }

        private void mskCpf_MaskInputRejected_1(object sender, MaskInputRejectedEventArgs e)
        {
            mskCpf.BackColor = Color.Empty;
        }

        private void txtEndereco_TextChanged(object sender, EventArgs e)
        {
            txtEndereco.BackColor = Color.Empty;
        }

        private void mskCep_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            mskCep.BackColor = Color.Empty;
        }

        private void txtBairro_TextChanged(object sender, EventArgs e)
        {
            txtBairro.BackColor = Color.Empty;
        }

        private void txtNumCasa_TextChanged(object sender, EventArgs e)
        {
            txtNumCasa.BackColor = Color.Empty;
        }

        private void txtcomplemento_TextChanged(object sender, EventArgs e)
        {
            txtcomplemento.BackColor = Color.Empty;
        }

        private void txtCidade_TextChanged(object sender, EventArgs e)
        {
            txtCidade.BackColor = Color.Empty;
        }

        private void txtNome_TextChanged_1(object sender, EventArgs e)
        {
            txtNome.BackColor = Color.Empty;
        }

        private void mskRg_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            mskRg.BackColor = Color.Empty;
        }

        private void mskDatanasc_MaskInputRejected_1(object sender, MaskInputRejectedEventArgs e)
        {
            mskDatanasc.BackColor = Color.Empty;
        }

        private void txtSexo_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            txtSexo.BackColor = Color.Empty;
        }

        private void mskTel_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            mskTel.BackColor = Color.Empty;
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            txtEmail.BackColor = Color.Empty;
        }

        private void mskTel_MaskInputRejected_1(object sender, MaskInputRejectedEventArgs e)
        {
            mskTel.BackColor = Color.Empty;
        }

        private void mskCel_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            mskCel.BackColor = Color.Empty;
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

        private void txtSalario_KeyPress_1(object sender, KeyPressEventArgs e)
        {

        }


    }
}
