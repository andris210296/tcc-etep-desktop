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
    public partial class VendaCF : Form
    {
        acessoCliente cli = new acessoCliente();
        acessoFuncionario func = new acessoFuncionario();
        acessoCarroFornecedor carf = new acessoCarroFornecedor();
        acessoVenda ven = new acessoVenda();
        int linha, qtd_linha;

        // Usados para fazer as contas!
        double preco, total;
        int qtdDisponivel, qtdDesejada;

        private void carregarCli()
        {
            cmbCliente.DataSource = cli.listarTudo();
            cmbCliente.DisplayMember = "nome_cli";
            cmbCliente.ValueMember = "id_cli";
        }


        public VendaCF()
        {
            InitializeComponent();
        }

        private void Venda_Load(object sender, EventArgs e)
        {
            DateTime data;

            data = DateTime.Now;
            mskData_venda.Text = data.ToString("dd/MM/yyyy");
            
            carregarCli();
            txtFunc.Text = Cripto.descripto(Form1.nome_func);
        }

        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cli.pesquisarClienteParaVenda(cmbCliente.Text);
                if (cli.pesquisarClienteParaVenda(cmbCliente.Text) == true)
                {
                    txtIdCli.Text = cli.Id_cli.ToString();
                }
            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (carf.pesquisarCarroFornecedor(Cripto.cripto(txtNomePesq.Text)) == true)
            {
                txtId.Text = carf.Id_cf.ToString();
                txtQtdDisponivel.Text = carf.Qtd_cf.ToString();

                preco = carf.Valor_cf;
                qtdDisponivel = carf.Qtd_cf;

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
                MessageBox.Show("Carro não encontrado");
                btnProximo.Enabled = false;
                btnAnterior.Enabled = false;
            }
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
                txtId.Text = carf.Lista_carf.Rows[linha]["id_cf"].ToString();
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
                txtId.Text = carf.Lista_carf.Rows[linha]["id_cf"].ToString();
                btnAnterior.Enabled = true;

            }
            if (linha == (qtd_linha - 1))
            {
                btnAnterior.Enabled = true;
                btnProximo.Enabled = false;

            }
        }

        private void txtQtdDesejada_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtQtdDesejada.BackColor = Color.Empty;

                qtdDesejada = Convert.ToInt32(txtQtdDesejada.Text);

                if (qtdDesejada <= qtdDisponivel)
                {
                    total = preco * qtdDesejada;

                    txtTotal.Text = total.ToString();
                }
                else
                {
                    MessageBox.Show("Quantidade insuficiente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtQtdDesejada.Clear();
                    txtTotal.Clear();
                }
            }

            catch { }
        }

        private void txtQtdDesejada_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '\b')
            {
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == ',' || e.KeyChar == '.')
            {
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == ',' || e.KeyChar == '.')
            {
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '\b')
            {
            }
            else
            {
                e.Handled = true;
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (txtValorFin.Text == string.Empty || txtQtdDesejada.Text == string.Empty || txtValorEnt.Text == string.Empty ||
                txtParcelas.Text == string.Empty || txtIdCli.Text == string.Empty || mskData_venda.MaskFull == false || txtTotal.Text == string.Empty ||
                cmbPag.Text == string.Empty || txtFunc.Text == string.Empty || txtId.Text == string.Empty)
            {
                if (txtValorFin.Text == string.Empty)
                    txtValorFin.BackColor = Color.Red;
                if (txtValorEnt.Text == string.Empty)
                    txtValorEnt.BackColor = Color.Red;
                if (txtQtdDesejada.Text == string.Empty)
                    txtQtdDesejada.BackColor = Color.Red;
                if (txtParcelas.Text == string.Empty)
                    txtParcelas.BackColor = Color.Red;
                if (txtIdCli.Text == string.Empty)
                    txtIdCli.BackColor = Color.Red;
                if (mskData_venda.MaskFull == false)
                    mskData_venda.BackColor = Color.Red;
                if (txtTotal.Text == string.Empty)
                    txtTotal.BackColor = Color.Red;
                if (cmbPag.Text == string.Empty)
                    cmbPag.BackColor = Color.Red;
                if (txtFunc.Text == string.Empty)
                    txtFunc.BackColor = Color.Red;
                if (txtId.Text == string.Empty)
                    txtId.BackColor = Color.Red;

                MessageBox.Show("Favor preencher os campos em vermelho!!");
            }
            else
            {
                if (Convert.ToInt32(txtValorEnt.Text) >= Convert.ToDouble(total.ToString()) || Convert.ToInt32(txtValorFin.Text) >= Convert.ToDouble(total.ToString()))
                {
                    MessageBox.Show("Verificar campos de valores", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    if (ven.inserirCF(txtIdCli.Text, txtId.Text, "NULL", Form1.id_func, cmbPag.Text, qtdDesejada.ToString(), txtTotal.Text.Replace(',', '.'), mskData_venda.Text, txtValorEnt.Text.Replace(',', '.'), txtValorFin.Text.Replace(',', '.'), txtParcelas.Text) == true)
                    {
                        // alterar a qtd do carro
                        carf.atualizarQtd(qtdDesejada.ToString(), txtId.Text, txtQtdDisponivel.ToString());

                        // cadastrar contrato para crystal report

                        MessageBox.Show("Venda Realizada");
                    }
                    else
                    {
                        MessageBox.Show("Verificar campos!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }




        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
