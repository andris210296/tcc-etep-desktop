using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace TCC
{
    public partial class Menu : Form
    {
        acessoFuncionario func = new acessoFuncionario();

        public Menu()
        {
            InitializeComponent();
        }

        private void carroToolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }

        private void carroDoCLienteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            CadastrarCliente telacli = new CadastrarCliente();
            telacli.ShowDialog();
        }

        private void fornecedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void funcionárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadastrarFuncionario telacadfun = new CadastrarFuncionario();
            telacadfun.ShowDialog();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void alterarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            InfFornecedor telaPesqForn = new InfFornecedor();
            telaPesqForn.ShowDialog();
        }

        private void alterarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InfCliente telaCli = new InfCliente();
            telaCli.ShowDialog();
        }

        private void alterarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            InfFuncionario func = new InfFuncionario();
            func.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime hora;

            hora = DateTime.Now;
            label1.Text = hora.ToShortTimeString();

        }

        private void carroDoFornecedorToolStripMenuItem_Click(object sender, EventArgs e)
        {

            CadastrarFornecedor telaforn = new CadastrarFornecedor();
            telaforn.ShowDialog(); 
        }

        private void sairToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void alteraçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dados dado = new Dados();
            dado.ShowDialog();
        }

        private void carroDoClienteToolStripMenuItem2_Click(object sender, EventArgs e)
        {

            CadastrarCarroCliente telacarrocli = new CadastrarCarroCliente();
            telacarrocli.ShowDialog();
        }

        private void carroDoFornecedorToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            CadastrarCarroFornecedor cadcforn = new CadastrarCarroFornecedor();
            cadcforn.ShowDialog();
        }


        private void Menu_Load(object sender, EventArgs e)
        {
            label2.Text = "Seja Bem Vindo(a), ";


        }

        private void alterarToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            InfCarroCliente carc = new InfCarroCliente();
            carc.ShowDialog();
        }

        private void alterarToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            InfCarroFornecedor carf = new InfCarroFornecedor();
            carf.ShowDialog();
        }

        private void realizarVendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Escolher esc = new Escolher();
            esc.ShowDialog();
        }

        private void logoffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 tela = new Form1();
            this.Hide();
            tela.Show();   
        }

        private void relatórioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormRelatorio formRelatorio = new FormRelatorio();
            formRelatorio.ShowDialog();
        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Backup backup = new Backup();
            backup.ShowDialog();
        }


    }
}
