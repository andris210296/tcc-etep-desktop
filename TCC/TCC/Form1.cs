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
    
    public partial class Form1 : Form
    {

        acessoAdministrador acessoAdmin = new acessoAdministrador();
        acessoFuncionario acessoFunc = new acessoFuncionario();
        public static String nome_func;
        public static String id_func;
        Menu menu = new Menu();
        
        public Form1()
        {
            InitializeComponent();
        }

        // string usu;

        private void button1_Click(object sender, EventArgs e)
        {
               
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Conexao.criar_Conexao();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            if (acessoAdmin.logar(txtlogin.Text, txtsenha.Text))
            {
                ClasseGlobal.Adm = true;
                Menu menuAdm = new Menu();
                this.Hide();
                menuAdm.Show();
            }
            else
            {
                if (acessoFunc.logar_cartao(txtlogin.Text, txtsenha.Text) == true)
                {
                    if (acessoFunc.selecionarNomeCartao(txtlogin.Text) == true)
                    {
                        if (acessoFunc.selecionarIdCartao(txtlogin.Text) == true)
                        {
                            nome_func = acessoFunc.Nome_fun.ToString();
                            id_func = acessoFunc.Id_fun.ToString();
                            ClasseGlobal.Adm = false;
                            menuFunc menuFunc = new menuFunc();
                            this.Hide();
                            menuFunc.Show();
                        }
                        else { }
                    }
                    else { }
                }
                else
                {


                    if (acessoFunc.logar(txtlogin.Text, txtsenha.Text) == true)
                    {
                        if (acessoFunc.selecionarNome(txtlogin.Text) == true)
                        {
                            if (acessoFunc.selecionarId(txtlogin.Text) == true)
                            {
                                nome_func = acessoFunc.Nome_fun.ToString();
                                id_func = acessoFunc.Id_fun.ToString();
                                ClasseGlobal.Adm = false;
                                menuFunc menuFunc = new menuFunc();
                                this.Hide();
                                menuFunc.Show();
                            }
                            else { }
                        }
                        else { }
                    }
                    else
                    {
                        MessageBox.Show("Dados incorretos, favor verificar");
                        txtlogin.Clear();
                        txtsenha.Clear();
                    }
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            FormRelatorio o = new FormRelatorio();
            o.Show();
            this.Hide();
        }
    }
}
