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
    public partial class Dados : Form
    {
        acessoAdministrador ad = new acessoAdministrador();

     
        public Dados()
        {
            InitializeComponent();
        }

        private void btnalterar_Click(object sender, EventArgs e)
        {
            if ((txtsenha.Text == txtconfirmar.Text) == true)
            {
                ad.Alterar_adm(txtlogin.Text, txtsenha.Text, txtid.Text);
                MessageBox.Show("Cadastro alterado com sucesso !!");
            }
            else
            {

                MessageBox.Show("Sua senha não é compativel, favor verificar");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}
