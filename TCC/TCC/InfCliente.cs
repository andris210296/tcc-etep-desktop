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
    public partial class InfCliente : Form
    {
        acessoCliente cli = new acessoCliente();
        Cep cep = new Cep();
        Validacao validar = new Validacao();
        int linha, qtd_linha;

        public InfCliente()
        {
            InitializeComponent();
        }

   /*   private void carregarComboCli()
        {
            cmbEncontrados.DataSource = cli.listarTudo();
            cmbEncontrados.DisplayMember = "sobrenome_cli";
            cmbEncontrados.ValueMember = "id_cli";
        }

        private void txtNomePesq_TextChanged(object sender, EventArgs e)
        {
            if (txtNomePesq.TextLength != 0)
            {
                btnPesquisar.Enabled = true;
            }
            else
            {
                btnPesquisar.Enabled = false;
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (cli.pesquisarCliente(txtNomePesq.Text) == true)
            {
                cmbEncontrados.Enabled = true;
                carregarComboCli();
            }
            else
            {
                MessageBox.Show("Cliente não cadastrado, tente novamente", "Cliente inexistente", MessageBoxButtons.OK);
            }
        }

        private void cmbEncontrados_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEncontrados.Text == cli.Sobrenome_cli.ToString())
            {
                txtId.Text = cli.Id_cli.ToString();
                txtEmail.Text = cli.Email_cli.ToString();
                txtSenha.Text = cli.Senha_cli.ToString();
                txtNome.Text = cli.Nome_cli.ToString();
                txtSobrenome.Text = cli.Sobrenome_cli.ToString();
                mskDatanasc.Text = cli.Datanasc_cli.ToString();
                mskRg.Text = cli.Rg_cli.ToString();
                mskCpf.Text = cli.Cpf_cli.ToString();
                txtSexo.Text = cli.Sexo_cli.ToString();
                txtEstatoCivil.Text = cli.Estciv_cli.ToString();
                mskCep.Text = cli.Cep_cli.ToString();
                txtUf.Text = cli.Uf_cli.ToString();
                txtCidade.Text = cli.Cidade_cli.ToString();
                txtBairro.Text = cli.Bairro_cli.ToString();
                txtNumCasa.Text = cli.Numcasa_cli.ToString();
                mskTel.Text = cli.Tel_cli.ToString();
                mskCel.Text = cli.Cel_cli.ToString();
                cmbTipoPessoa.Text = cli.Tipopessoa_cli.ToString();
                txtNumDependentes.Text = cli.Numdependentes_cli.ToString();
                txtEmpresaCliente.Text = cli.Empresa_cli.ToString();
                txtEndEmpresa.Text = cli.Enderecoempresa_cli.ToString();
                txtProfissao.Text = cli.Profissao_cli.ToString();
                txtCidadeEmpresa.Text = cli.Cidadeemp_cli.ToString();
                txtUfEmpresa.Text = cli.Ufempresa_cli.ToString();
                mskTelCom.Text = cli.Telcom_cli.ToString();
                txtBanco.Text = cli.Banco_cli.ToString();
                txtTipoConta.Text = cli.Tipoconta_cli.ToString();
                txtAgencia.Text = cli.Agencia_cli.ToString();
                txtNumConta.Text = cli.Numconta_cli.ToString();
                txtRenda.Text = cli.Renda_cli.ToString();
           } }*/

        private void btnPesquisar_Click_1(object sender, EventArgs e)
        {
            if (cli.pesquisarCliente(Cripto.cripto (txtNomePesq.Text)) == true)
            {


                txtId.Text = cli.Id_cli.ToString();
                txtEmail.Text = cli.Email_cli.ToString();
                txtSenha.Text = cli.Senha_cli.ToString();
                txtNome.Text = cli.Nome_cli.ToString();
                mskDatanasc.Text = cli.Datanasc_cli.ToString("dd/MM/yyyy");
                mskRg.Text = cli.Rg_cli.ToString();
                mskCpf.Text = cli.Cpf_cli.ToString();
                txtSexo.Text = cli.Sexo_cli.ToString();
                txtEstatoCivil.Text = cli.Estciv_cli.ToString();
                mskCep.Text = cli.Cep_cli.ToString();
                txtendereco.Text = cli.Endereco_cli.ToString();
                txtCasa.Text = cli.Numcasa_cli.ToString();
                txtcomplemento.Text = cli.Complemento_cli.ToString();
                txtCidade.Text = cli.Cidade_cli.ToString();
                txtBairro.Text = cli.Bairro_cli.ToString();
                mskTel.Text = cli.Tel_cli.ToString();
                mskCel.Text = cli.Cel_cli.ToString();
                cmbTipoPessoa.Text = cli.Tipopessoa_cli.ToString();
                txtNumDependentes.Text = cli.Numdependentes_cli.ToString();
                txtEmpresaCliente.Text = cli.Empresa_cli.ToString();
                mskCepEmp.Text = cli.CepEmpresa_cli.ToString();
                txtBairroEmp.Text = cli.BairroEmpresa_cli.ToString();
                txtEndEmpresa.Text = cli.EnderecoEmpresa_cli.ToString();
                txtProfissao.Text = cli.Profissao_cli.ToString();
                txtCidadeEmpresa.Text = cli.Cidadeemp_cli.ToString();
                mskTelCom.Text = cli.Telcom_cli.ToString();
                txtBanco.Text = cli.Banco_cli.ToString();
                txtTipoConta.Text = cli.Tipoconta_cli.ToString();
                txtAgencia.Text = cli.Agencia_cli.ToString();
                txtNumConta.Text = cli.Numconta_cli.ToString();
                txtRenda.Text = cli.Renda_cli.ToString();

                if (cli.Foto_cli.ToString() == "ClienteSemFoto.jpg")
                {
                    Bitmap bmp = new Bitmap(pictureBox1.ImageLocation = ("D:\\TCC-SITE\\FotoCliente\\" + "ClienteSemFoto.jpg"));

                    Bitmap bmp2 = new Bitmap(bmp, pictureBox1.Size);

                    pictureBox1.Image = bmp2;


                }
                else
                {
                    Bitmap bmp = new Bitmap(pictureBox1.ImageLocation = ("D:\\TCC-SITE\\FotoCliente\\" + cli.Foto_cli.ToString()));

                    Bitmap bmp2 = new Bitmap(bmp, pictureBox1.Size);

                    pictureBox1.Image = bmp2;
                                                          
                }




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
            txtEmail.Clear();
            txtNovaSenha.Clear();
            txtNome.Clear();
            mskDatanasc.Clear();
            mskRg.Clear();
            mskCpf.Clear();
            txtSexo.Text = "";
            txtEstatoCivil.Text = "";
            mskCep.Clear();
            txtCidade.Clear();
            txtBairro.Clear();
            mskTel.Clear();
            mskCel.Clear();
            cmbTipoPessoa.Text = "";
            txtNumDependentes.Clear();
            txtEmpresaCliente.Clear();
            txtEndEmpresa.Clear();
            txtProfissao.Clear();
            txtCidadeEmpresa.Clear();
            mskTelCom.Clear();
            txtBanco.Clear();
            txtTipoConta.Clear();
            txtAgencia.Clear();
            txtNumConta.Clear();
            txtRenda.Clear();
            pictureBox1.Hide();
            txtSenha.Clear();
            txtendereco.Clear();
            txtCasa.Clear();
            txtcomplemento.Clear();
            mskCepEmp.Clear();
            txtBairroEmp.Clear();
            txtNovaSenha.Clear();
            txtConfirmarSenha.Clear();

        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {

            txtNomePesq.Text = listBox1.Text;
            listBox1.Visible = false;
            this.btnPesquisar_Click_1(sender, e);
        }

        private void txtNomePesq_TextChanged_1(object sender, EventArgs e)
        {
            listBox1.Visible = true;
            listBox1.DataSource = cli.filtro(txtNomePesq.Text);
            listBox1.DisplayMember = "nome_cli";
        }


        public void exibir()
        {

            txtId.Text = cli.Lista_cliente.Rows[linha]["id_cli"].ToString();
            txtEmail.Text = cli.Lista_cliente.Rows[linha]["email_cli"].ToString();
            txtSenha.Text = cli.Lista_cliente.Rows[linha]["senha_cli"].ToString();
            txtNome.Text = cli.Lista_cliente.Rows[linha]["nome_cli"].ToString();
            mskDatanasc.Text = cli.Lista_cliente.Rows[linha]["datanasc_cli"].ToString();
            mskRg.Text = cli.Lista_cliente.Rows[linha]["rg_cli"].ToString();
            mskCpf.Text = cli.Lista_cliente.Rows[linha]["cpf_cli"].ToString();
            txtSexo.Text = cli.Lista_cliente.Rows[linha]["sexo_cli"].ToString();
            txtEstatoCivil.Text = cli.Lista_cliente.Rows[linha]["estciv_cli"].ToString();
            mskCep.Text = cli.Lista_cliente.Rows[linha]["cep_cli"].ToString();
            txtendereco.Text = cli.Lista_cliente.Rows[linha]["endereco_cli"].ToString();
            txtCasa.Text = cli.Lista_cliente.Rows[linha]["numcasa_cli"].ToString();
            txtcomplemento.Text = cli.Lista_cliente.Rows[linha]["complemento_cli"].ToString();
            txtCidade.Text = cli.Lista_cliente.Rows[linha]["cidade_cli"].ToString();
            txtBairro.Text = cli.Lista_cliente.Rows[linha]["bairro_cli"].ToString();
            mskTel.Text = cli.Lista_cliente.Rows[linha]["tel_cli"].ToString();
            mskCel.Text = cli.Lista_cliente.Rows[linha]["cel_cli"].ToString();
            cmbTipoPessoa.Text = cli.Lista_cliente.Rows[linha]["tipopessoa_cli"].ToString();
            txtNumDependentes.Text = cli.Lista_cliente.Rows[linha]["numdependentes_cli"].ToString();
            txtEmpresaCliente.Text = cli.Lista_cliente.Rows[linha]["empresa_cli"].ToString();
            txtEndEmpresa.Text = cli.Lista_cliente.Rows[linha]["enderecoEmpresa_cli"].ToString();
            txtProfissao.Text = cli.Lista_cliente.Rows[linha]["profissao_cli"].ToString();
            txtCidadeEmpresa.Text = cli.Lista_cliente.Rows[linha]["cidadeEmp_cli"].ToString();
            mskCepEmp.Text = cli.Lista_cliente.Rows[linha]["cepEmpresa_cli"].ToString();
            txtBairroEmp.Text = cli.Lista_cliente.Rows[linha]["bairroEmpresa_cli"].ToString();
            mskTelCom.Text = cli.Lista_cliente.Rows[linha]["telcom_cli"].ToString();
            txtBanco.Text = cli.Lista_cliente.Rows[linha]["banco_cli"].ToString();
            txtTipoConta.Text = cli.Lista_cliente.Rows[linha]["tipoconta_cli"].ToString();
            txtAgencia.Text = cli.Lista_cliente.Rows[linha]["agencia_cli"].ToString();
            txtNumConta.Text = cli.Lista_cliente.Rows[linha]["numconta_cli"].ToString();
            txtRenda.Text = cli.Lista_cliente.Rows[linha]["renda_cli"].ToString();


            if (cli.Foto_cli.ToString() == "ClienteSemFoto.jpg")
            {
                Bitmap bmp = new Bitmap(pictureBox1.ImageLocation = ("D:\\TCC-SITE\\FotoCliente\\" + "ClienteSemFoto.jpg"));

                Bitmap bmp2 = new Bitmap(bmp, pictureBox1.Size);

                pictureBox1.Image = bmp2;


            }
            else
            {
                Bitmap bmp = new Bitmap(pictureBox1.ImageLocation = ("D:\\TCC-SITE\\FotoCliente\\" + cli.Foto_cli.ToString()));

                Bitmap bmp2 = new Bitmap(bmp, pictureBox1.Size);

                pictureBox1.Image = bmp2;

            }

        }




        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult resp;
            resp = MessageBox.Show("Deseja realmente excluir?", "Excluir?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resp == DialogResult.Yes)
            {
                cli.excluir(txtId.Text);
                btnExcluir.Enabled = false;
                btnAlterar.Enabled = false;
                limpar();
                MessageBox.Show("Cliente excluído com sucesso.");
               
                }
            
            else
            {
                btnAlterar.Enabled = false;
                btnExcluir.Enabled = false;
                limpar();
                MessageBox.Show("Exclusão cancelada.");
            }


             
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void InfCliente_Load(object sender, EventArgs e)
        {

        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            DialogResult resp;
            resp = MessageBox.Show("Deseja realmente alterar estes dados ?", "Alterar ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resp == DialogResult.Yes)
            {
                if (txtEmail.Text == string.Empty || txtNome.Text == string.Empty
                 || mskDatanasc.MaskFull == false || mskRg.MaskFull == false || mskCpf.MaskFull == false
                 || txtSexo.Text == string.Empty || mskCep.MaskFull == false || txtendereco.Text == string.Empty
                 || txtBairro.Text == string.Empty || txtCasa.Text == string.Empty || txtcomplemento.Text == string.Empty
                 || txtCidade.Text == string.Empty || mskTel.MaskFull == false
                 || cmbTipoPessoa.Text == string.Empty)
                {
                    MessageBox.Show("favor preencher o(s) campo(s) em vermelho");
                    if (txtEmail.Text == string.Empty)
                        txtEmail.BackColor = Color.Red;
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
                    if (txtendereco.Text == string.Empty)
                        txtendereco.BackColor = Color.Red;
                    if (txtBairro.Text == string.Empty)
                        txtBairro.BackColor = Color.Red;
                    if (txtCasa.Text == string.Empty)
                        txtCasa.BackColor = Color.Red;
                    if (txtcomplemento.Text == string.Empty)
                        txtcomplemento.BackColor = Color.Red;
                    if (txtCidade.Text == string.Empty)
                        txtCidade.BackColor = Color.Red;
                    if (mskTel.MaskFull == false)
                        mskTel.BackColor = Color.Red;
                    if (cmbTipoPessoa.Text == string.Empty)
                        cmbTipoPessoa.BackColor = Color.Red;
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

                                string nomeFoto = cli.Foto_cli.ToString();                             
                                if (cli.alterar(txtEmail.Text, txtNovaSenha.Text, txtNome.Text, mskDatanasc.Text, mskRg.Text, mskCpf.Text, txtSexo.Text,nomeFoto,txtEstatoCivil.Text, mskCep.Text, txtendereco.Text, txtBairro.Text, txtCasa.Text, txtcomplemento.Text, txtCidade.Text, mskTel.Text, mskCel.Text, cmbTipoPessoa.Text, txtNumDependentes.Text, txtProfissao.Text, txtEmpresaCliente.Text, mskCepEmp.Text, txtEndEmpresa.Text, txtBairroEmp.Text, txtCidadeEmpresa.Text, mskTelCom.Text, txtBanco.Text, txtTipoConta.Text, txtAgencia.Text, txtNumConta.Text, txtRenda.Text, txtId.Text) == true)
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
                            MessageBox.Show("Cliente menor de idade!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

                                        string nomeFoto = cli.Foto_cli.ToString();
                                        if (cli.alterar(txtEmail.Text, txtNovaSenha.Text, txtNome.Text, mskDatanasc.Text, mskRg.Text, mskCpf.Text, txtSexo.Text,nomeFoto ,txtEstatoCivil.Text, mskCep.Text, txtendereco.Text, txtBairro.Text, txtCasa.Text, txtcomplemento.Text, txtCidade.Text, mskTel.Text, mskCel.Text, cmbTipoPessoa.Text, txtNumDependentes.Text, txtProfissao.Text, txtEmpresaCliente.Text, mskCepEmp.Text, txtEndEmpresa.Text, txtBairroEmp.Text, txtCidadeEmpresa.Text, mskTelCom.Text, txtBanco.Text, txtTipoConta.Text, txtAgencia.Text, txtNumConta.Text, txtRenda.Text, txtId.Text) == true)
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

        private void txtRenda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == ',' || e.KeyChar == '.')
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

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            txtEmail.BackColor = Color.Empty;
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            txtNome.BackColor = Color.Empty;
        }

        private void mskDatanasc_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            mskDatanasc.BackColor = Color.Empty;
        }

        private void mskRg_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            mskRg.BackColor = Color.Empty;
        }

        private void mskCpf_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            mskCpf.BackColor = Color.Empty;
        }

        private void mskCep_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            mskCep.BackColor = Color.Empty;
        }

        private void txtendereco_TextChanged(object sender, EventArgs e)
        {
            txtendereco.BackColor = Color.Empty;
        }

        private void txtBairro_TextChanged(object sender, EventArgs e)
        {
            txtBairro.BackColor = Color.Empty;
        }

        private void txtCidade_TextChanged(object sender, EventArgs e)
        {
            txtCidade.BackColor = Color.Empty;
        }

        private void mskTel_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            mskTel.BackColor = Color.Empty;
        }

        private void txtCasa_TextChanged(object sender, EventArgs e)
        {
            txtCasa.BackColor = Color.Empty;
        }

        private void txtcomplemento_TextChanged(object sender, EventArgs e)
        {
            txtcomplemento.BackColor = Color.Empty;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cep.PesquisarCep(mskCep.Text) == true)
            {
                txtBairro.Text = cep.Bairro.ToString();
                txtCidade.Text = cep.Cidade.ToString();
                txtendereco.Text = cep.Logradouro.ToString();

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
            txtendereco.Clear();
            txtBairro.Clear();
            txtCidade.Clear();
        }

       
        private void mskRg_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        




                
        }
    }

