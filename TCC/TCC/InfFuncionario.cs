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
    public partial class InfFuncionario : Form
    {
        acessoFuncionario func = new acessoFuncionario();
        Cep cep = new Cep();
        Validacao validar = new Validacao();
        int linha, qtd_linha;

        public InfFuncionario()
        {
            InitializeComponent();
        }

  /*      private void carregarComboFunc()
        {
            cmbEncontrados.DataSource = func.listarTudo();
            cmbEncontrados.DisplayMember = "sobrenome_fun";
            cmbEncontrados.ValueMember = "id_fun";
        }

        */

        private void btnPesquisar_Click(object sender, EventArgs e)
        {

            if (func.pesquisarFunc(Cripto.cripto(txtNomePesq.Text)) == true)
            {



                txtId.Text = func.Id_fun.ToString();
                txtNome.Text = func.Nome_fun.ToString();
                mskCpf.Text = func.Cpf_fun.ToString();
                mskRg.Text = func.Rg_fun.ToString();
                txtEstCivil.Text = func.Estciv_fun.ToString();
                mskDatanasc.Text = func.Dtnasc_fun.ToString("dd/MM/yyyy");
                txtSexo.Text = func.Sexo_fun.ToString();
                txtEndereco.Text = func.Endereco_fun.ToString();
                txtNumCasa.Text = func.Num_fun.ToString();
                txtCidade.Text = func.Cidade_fun.ToString();
                txtBairro.Text = func.Bairro_fun.ToString();
  
                mskTel.Text = func.Tel_fun.ToString();
                mskCel.Text = func.Cel_fun.ToString();
                mskCep.Text = func.Id_cep.ToString();
                txtSalario.Text = func.Salario_fun.ToString();
                txtDepartamento.Text = func.Departamento_fun.ToString();
                txtTurno.Text = func.Turno_fun.ToString();
                txtSenha.Text = func.Senha.ToString();
                txtLogin.Text = func.Login.ToString();
                txtcomplemento.Text = func.Complemento.ToString();
                txtEmail.Text = func.Email_fun.ToString();
                mskRg.Text = func.Rg_fun.ToString();


                btnAlterar.Enabled = true;
                btnExcluir.Enabled = true;
               

            }
            else
            {
                MessageBox.Show("Nome não cadastrado");
                limpar();
          
            }
        }




        public void limpar()
        {
            
            txtId.Clear();
            txtNome.Clear();
            mskCpf.Clear();
            txtEstCivil.Text = "";
            mskDatanasc.Clear();
            txtSexo.Text = "";
            txtEndereco.Clear();
            txtNumCasa.Clear();
            txtCidade.Clear();
            txtBairro.Clear();
            mskCep.Clear();
            mskTel.Clear();
            mskCel.Clear();
            txtSalario.Clear();
            txtDepartamento.Clear();
            txtTurno.Text = "";
            txtLogin.Clear();
            txtSenha.Clear();
            txtcomplemento.Clear();
            txtEmail.Clear();
            mskRg.Clear();
            txtSenha.Clear();
            txtNovaSenha.Clear();
            txtConfirmarSenha.Clear();

        }
            
            
           /* if (func.pesquisarFunc(txtNomePesq.Text) == true)
            {
                carregarComboFunc();
                cmbEncontrados.Enabled = true;
            }
            else
            {
                MessageBox.Show("Funcionário não cadastrado, tente novamente", "Funcionário inexistente", MessageBoxButtons.OK);
            }
        }

        private void cmbEncontrados_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEncontrados.Text == func.Sobrenome_fun.ToString())
            {
                txtId.Text = func.Id_fun.ToString();
                txtNome.Text = func.Nome_fun.ToString();
                txtSobrenome.Text = func.Sobrenome_fun.ToString();
                mskCpf.Text = func.Cpf_fun.ToString();
                txtEstCivil.Text = func.Estciv_fun.ToString();
                mskDatanasc.Text = func.Dtnasc_fun.ToString();
                txtSexo.Text = func.Sexo_fun.ToString();
                txtEndereco.Text = func.Endereco_fun.ToString();
                txtNumCasa.Text = func.Num_fun.ToString();
                txtCidade.Text = func.Cidade_fun.ToString();
                txtBairro.Text = func.Bairro_fun.ToString();
                txtUf.Text = func.Uf_fun.ToString();
                mskCep.Text = func.Cep_fun.ToString();
                mskTel.Text = func.Tel_fun.ToString();
                mskCel.Text = func.Cel_fun.ToString();
                txtSalario.Text = func.Salario_fun.ToString();
                txtDepartamento.Text = func.Departamento_fun.ToString();
                txtTurno.Text = func.Turno_fun.ToString();
            }
        
        }*/


        private void listBox1_DoubleClick(object sender, EventArgs e)
        {

            txtNomePesq.Text = listBox1.Text;
           listBox1.Visible = false;
            this.btnPesquisar_Click(sender, e);
        

         }


        private void txtNomePesq_TextChanged(object sender, EventArgs e)
        {

            listBox1.Visible = true;
            listBox1.DataSource = func.filtro(txtNomePesq.Text);
            listBox1.DisplayMember = "nome_fun";


        }


        public void exibir()
        {

            txtId.Text = func.Lista_funcionario.Rows[linha]["id_fun"].ToString();
            txtNome.Text = func.Lista_funcionario.Rows[linha]["nome_fun"].ToString();
            mskCpf.Text = func.Lista_funcionario.Rows[linha]["cpf_fun"].ToString();
            txtEstCivil.Text = func.Lista_funcionario.Rows[linha]["estciv_fun"].ToString();
            mskDatanasc.Text = func.Lista_funcionario.Rows[linha]["dtnasc_fun"].ToString();
            txtSexo.Text = func.Lista_funcionario.Rows[linha]["sexo_fun"].ToString();
            txtEndereco.Text = func.Lista_funcionario.Rows[linha]["endereco_fun"].ToString();
            txtNumCasa.Text = func.Lista_funcionario.Rows[linha]["num_fun"].ToString();
            txtCidade.Text = func.Lista_funcionario.Rows[linha]["cidade_fun"].ToString();
            txtBairro.Text = func.Lista_funcionario.Rows[linha]["bairro_fun"].ToString();
            mskCep.Text = func.Lista_funcionario.Rows[linha]["cep_fun"].ToString();
            mskTel.Text = func.Lista_funcionario.Rows[linha]["tel_fun"].ToString();
            mskCel.Text = func.Lista_funcionario.Rows[linha]["cel_fun"].ToString();
            txtSalario.Text = func.Lista_funcionario.Rows[linha]["salario_fun"].ToString();
            txtDepartamento.Text = func.Lista_funcionario.Rows[linha]["departamento_fun"].ToString();
            txtTurno.Text = func.Lista_funcionario.Rows[linha]["turno_fun"].ToString();

            txtLogin.Text = func.Lista_funcionario.Rows[linha]["login"].ToString();
            txtSenha.Text = func.Lista_funcionario.Rows[linha]["senha"].ToString();
            txtcomplemento.Text = func.Lista_funcionario.Rows[linha]["complemento_fun"].ToString();
            txtEmail.Text = func.Lista_funcionario.Rows[linha]["email_fun"].ToString();
            mskRg.Text = func.Lista_funcionario.Rows[linha]["rg_fun"].ToString();


        }



        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult resp;
            resp = MessageBox.Show("Deseja realmente excluir?", "Excluir?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resp == DialogResult.Yes)
            {
                func.excluir(txtId.Text); 
                btnExcluir.Enabled = false;
                btnAlterar.Enabled = false;
                limpar();
                MessageBox.Show("Funcionário excluído com sucesso.");
            }
            else
            {
                btnAlterar.Enabled = false;
                btnExcluir.Enabled = false;
                limpar();
                MessageBox.Show("Exclusão cancelada.");
            }
        }

        private void btnAlterar_Click_1(object sender, EventArgs e)
        {
            DialogResult resp;
            resp = MessageBox.Show("Deseja realmente alterar estes dados ?", "Alterar ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resp == DialogResult.Yes)
            {
                if (txtDepartamento.Text == string.Empty || txtTurno.Text == string.Empty || txtNome.Text == string.Empty
                || mskDatanasc.MaskFull == false || mskCpf.MaskFull == false || txtSexo.Text == string.Empty
                || txtSalario.Text == string.Empty || txtLogin.Text == string.Empty
                || txtEndereco.Text == string.Empty || txtNumCasa.Text == string.Empty || txtCidade.Text == string.Empty
                || txtBairro.Text == string.Empty || mskCep.MaskFull == false
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
                }
                else
                {
                    if (txtNovaSenha.TextLength == 0)
                    {
                        txtNovaSenha.Text = txtSenha.Text;

                        DateTime dataNasc = new DateTime();
                        int anoAtual, verificacao;

                        dataNasc = DateTime.Parse(mskDatanasc.Text);
                        anoAtual = DateTime.Now.Year;

                        verificacao = anoAtual - Convert.ToInt32(dataNasc.Year);

                        if (verificacao >= 18)
                        {

                            // Validando CPF
                            string cpfV = mskCpf.Text;

                            CpfValida.Text = cpfV;

                            string substring1 = cpfV.Substring(0, 3);
                            string substring2 = cpfV.Substring(4, 3);
                            string substring3 = cpfV.Substring(8, 3);
                            string substring4 = cpfV.Substring(12, 2);

                            CpfValida.Text = substring1 + substring2 + substring3 + substring4;

                            if (validar.ValidarCPF(CpfValida.Text) == true)
                            {

                                if (func.Alterar_funcionario(txtNome.Text, mskCpf.Text, txtEstCivil.Text, mskDatanasc.Text, txtSexo.Text, txtEndereco.Text, txtNumCasa.Text, txtCidade.Text, txtBairro.Text, mskCep.Text, mskTel.Text, mskCel.Text, txtSalario.Text, txtDepartamento.Text, txtTurno.Text, txtcomplemento.Text, txtEmail.Text, mskRg.Text, txtLogin.Text, txtNovaSenha.Text, txtcartao.Text , txtId.Text) == true)
                                {
                                    limpar();
                                    btnAlterar.Enabled = false;
                                    btnExcluir.Enabled = false;
                                    MessageBox.Show("Dados Alterados com sucesso!!");
                                }
                                else
                                {
                                    txtNovaSenha.Clear();
                                    txtSenha.Clear();
                                    MessageBox.Show("Verificar campos");
                                }
                            }
                            else
                            {
                                txtNovaSenha.Clear();
                                MessageBox.Show("CPF Inválido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                        else
                        {
                            txtNovaSenha.Clear();
                            MessageBox.Show("Funcionário deve ser maior de idade!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        if (txtNovaSenha.TextLength >= 6)
                        {
                            if (txtNovaSenha.Text == txtConfirmarSenha.Text)
                            {
                                DateTime dataNasc = new DateTime();
                                int anoAtual, verificacao;

                                dataNasc = DateTime.Parse(mskDatanasc.Text);
                                anoAtual = DateTime.Now.Year;

                                verificacao = anoAtual - Convert.ToInt32(dataNasc.Year);

                                if (verificacao >= 18)
                                {

                                    // Validando CPF
                                    string cpfV = mskCpf.Text;

                                    CpfValida.Text = cpfV;

                                    string substring1 = cpfV.Substring(0, 3);
                                    string substring2 = cpfV.Substring(4, 3);
                                    string substring3 = cpfV.Substring(8, 3);
                                    string substring4 = cpfV.Substring(12, 2);

                                    CpfValida.Text = substring1 + substring2 + substring3 + substring4;

                                    if (validar.ValidarCPF(CpfValida.Text) == true)
                                    {

                                        if (func.Alterar_funcionario(txtNome.Text, mskCpf.Text, txtEstCivil.Text, mskDatanasc.Text, txtSexo.Text, txtEndereco.Text, txtNumCasa.Text, txtCidade.Text, txtBairro.Text, mskCep.Text, mskTel.Text, mskCel.Text, txtSalario.Text, txtDepartamento.Text, txtTurno.Text, txtcomplemento.Text, txtEmail.Text, mskRg.Text, txtLogin.Text, txtNovaSenha.Text,txtcartao.Text, txtId.Text) == true)
                                        {
                                            limpar();
                                            btnAlterar.Enabled = false;
                                            btnExcluir.Enabled = false;
                                          
                                            MessageBox.Show("Dados Alterados com sucesso!!");
                                        }
                                        else
                                        {
                                            MessageBox.Show("Verificar campos");
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("CPF Inválido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Cliente menor de idade!", "Erro", MessageBoxButtons.OK);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Sua senha não é compativel, favor verificar", "Erro", MessageBoxButtons.OK);
                            }
                        }
                        else
                        {
                            MessageBox.Show("A senha deve ter no mínimo 6 digitos!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void txtSalario_KeyPress_1(object sender, KeyPressEventArgs e)
        {

        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            txtNome.BackColor = Color.Empty;
        }

        private void mskRg_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            mskRg.BackColor = Color.Empty;
        }

        private void mskCpf_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            mskCpf.BackColor = Color.Empty;
        }

        private void mskDatanasc_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            mskDatanasc.BackColor = Color.Empty;
        }

        private void mskTel_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            mskTel.BackColor = Color.Empty;
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            txtEmail.BackColor = Color.Empty;
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

        private void txtCidade_TextChanged(object sender, EventArgs e)
        {
            txtCidade.BackColor = Color.Empty;
        }

        private void txtNumCasa_TextChanged(object sender, EventArgs e)
        {
            txtNumCasa.BackColor = Color.Empty;
        }

        private void txtLogin_TextChanged(object sender, EventArgs e)
        {
            txtLogin.BackColor = Color.Empty;
        }

        private void txtSalario_TextChanged(object sender, EventArgs e)
        {
            txtSalario.BackColor = Color.Empty;
        }

        private void txtDepartamento_TextChanged(object sender, EventArgs e)
        {
            txtDepartamento.BackColor = Color.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cep.PesquisarCep(mskCep.Text) == true)
            {
                txtBairro.Text = cep.Bairro.ToString();
                txtCidade.Text = cep.Cidade.ToString();
                txtEndereco.Text = cep.Logradouro.ToString();
                //textBox1.Text = cep.Tp_logradouro.ToString();


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
            //textBox1.Clear();
            txtEndereco.Clear();
            txtBairro.Clear();
            txtCidade.Clear();
        }



    }
}
