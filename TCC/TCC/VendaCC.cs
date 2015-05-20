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
    public partial class VendaCC : Form
    {
        acessoCliente cli = new acessoCliente();
        acessoFuncionario func = new acessoFuncionario();
        acessoCarroCliente carc = new acessoCarroCliente();
        acessoVenda ven = new acessoVenda();
        acessoContrato cont = new acessoContrato();
        int linha, qtd_linha;


        public VendaCC()
        {
            InitializeComponent();
        }

        private void carregarCli()
        {
            cmbCliente.DataSource = cli.listarTudo();
            cmbCliente.DisplayMember = "nome_cli";
            cmbCliente.ValueMember = "id_cli";
        }
        
        
        
        private void VendaCC_Load(object sender, EventArgs e)
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
            
            if (carc.pesquisarCarroCliente(Cripto.cripto(txtNomePesq.Text)) == true)
            {
                txtId.Text = carc.Id_cc.ToString();
                txtfinalplaca_cc.Text = carc.Finalplaca_cc.ToString();
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
            listBox1.DataSource = carc.filtro(txtNomePesq.Text);
            listBox1.DisplayMember = "nome_cc";
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (linha > 0)
            {
                linha--;
                txtId.Text = carc.Lista_carc.Rows[linha]["id_cc"].ToString();
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
                txtId.Text = carc.Lista_carc.Rows[linha]["id_cc"].ToString();
                btnAnterior.Enabled = true;

            }
            if (linha == (qtd_linha - 1))
            {
                btnAnterior.Enabled = true;
                btnProximo.Enabled = false;

            }
        }

        private void txtValorFin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == ',' || e.KeyChar == '.')
            {
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtValorEnt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == ',' || e.KeyChar == '.')
            {
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtParcelas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '\b')
            {
            }
            else
            {
                e.Handled = true;
            }
        }

        double total, vFin, vEnt;
        int numparc;

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (txtValorFin.Text == string.Empty || txtValorEnt.Text == string.Empty ||
    txtParcelas.Text == string.Empty || txtIdCli.Text == string.Empty || mskData_venda.MaskFull == false || txtTotal.Text == string.Empty ||
    cmbPag.Text == string.Empty || txtFunc.Text == string.Empty || txtId.Text == string.Empty)
            {
                if (txtValorFin.Text == string.Empty)
                    txtValorFin.BackColor = Color.Red;
                if (txtValorEnt.Text == string.Empty)
                    txtValorEnt.BackColor = Color.Red;
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
                    if (ven.inserirCC(txtIdCli.Text, "NULL", txtId.Text, Form1.id_func, cmbPag.Text, "NULL", txtTotal.Text.Replace(',', '.'), mskData_venda.Text, txtValorEnt.Text.Replace(',', '.'), txtValorFin.Text.Replace(',', '.'), txtParcelas.Text) == true)
                    {
                        // atualizar qtd
                        carc.atualizarQtd(txtId.Text);

                        // cadastrar contrato para crystal report
                        //cont.inserirCont(txtIdCli.Text, Form1.id_func, cmbPag.SelectedValue.ToString(), mskData_venda.Text, txtTotal.Text);

                        MessageBox.Show("Venda Realizada com Sucesso");
                    }
                    else
                    {
                        MessageBox.Show("Verificar campos!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
            }
        }

        private void txtValorFin_TextChanged(object sender, EventArgs e)
        {
            if (txtValorEnt.TextLength != 0 && txtValorEnt.TextLength != 0 && txtParcelas.TextLength != 0)
            {
                vFin = Convert.ToDouble(txtValorFin.Text);
                vEnt = Convert.ToDouble(txtValorEnt.Text);
                numparc = Convert.ToInt32(txtParcelas.Text);

                total = vFin * numparc + vEnt;
                txtTotal.Text = total.ToString();
            }
            else
            {
                txtTotal.Clear();
            }
        }

        private void txtValorEnt_TextChanged(object sender, EventArgs e)
        {
            if (txtValorEnt.TextLength != 0 && txtValorEnt.TextLength != 0 && txtParcelas.TextLength != 0)
            {
                vFin = Convert.ToDouble(txtValorFin.Text);
                vEnt = Convert.ToDouble(txtValorEnt.Text);
                numparc = Convert.ToInt32(txtParcelas.Text);

                total = vFin * numparc + vEnt;
                txtTotal.Text = total.ToString();
            }
            else
            {
                txtTotal.Clear();
            }
        }

        private void txtParcelas_TextChanged(object sender, EventArgs e)
        {
            if (txtValorEnt.TextLength != 0 && txtValorEnt.TextLength != 0 && txtParcelas.TextLength != 0)
            {
                vFin = Convert.ToDouble(txtValorFin.Text);
                vEnt = Convert.ToDouble(txtValorEnt.Text);
                numparc = Convert.ToInt32(txtParcelas.Text);

                total = vFin * numparc + vEnt;
                txtTotal.Text = total.ToString();
            }
            else
            {
                txtTotal.Clear();
            }
        }

        private void txtFunc_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }



    }
}
