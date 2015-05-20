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
    public partial class menuFunc : Form
    {
        public menuFunc()
        {
            InitializeComponent();
        }

        private void sairToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void carroToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CadastrarCliente cli = new CadastrarCliente();
            cli.ShowDialog();
        }

        private void carroDoFornecedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadastrarCarroCliente carcli = new CadastrarCarroCliente();
            carcli.ShowDialog();
        }

        private void carroDoFornecedorToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            CadastrarCarroFornecedor carforn = new CadastrarCarroFornecedor();
            carforn.ShowDialog();
        }

        private void alterarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InfCliente icli = new InfCliente();
            icli.ShowDialog();
        }

        private void alterarToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            InfCarroCliente icarcli = new InfCarroCliente();
            icarcli.ShowDialog();
        }

        private void alterarToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            InfCarroFornecedor icarforn = new InfCarroFornecedor();
            icarforn.ShowDialog();
        }

        private void realizarVendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Escolher esc = new Escolher();
            esc.ShowDialog();
        }

        private void menuFunc_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime hora;

            hora = DateTime.Now;
            label1.Text = hora.ToShortTimeString();

        }

        private void logoffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 tela = new Form1();
            this.Hide();
            tela.Show();  
        }
    }
}
