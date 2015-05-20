using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace TCC
{
    class acessoRelatorio
    {
        int id_ad;
        String login, senha;

        #region variaveis
        public int Id_ad
        {
            get { return id_ad; }
            set { id_ad = value; }
        }

        public String Senha
        {
            get { return senha; }
            set { senha = value; }
        }

        public String Login
        {
            get { return login; }
            set { login = value; }
        }
        #endregion

        MySqlDataAdapter comando_sql;
        MySqlCommandBuilder executar_comando;
        DataTable tabela_memoria;



        private void carregar_tabela(String comando)
        {
            tabela_memoria = new DataTable();
            comando_sql = new MySqlDataAdapter(comando, Conexao.Conectar);
            executar_comando = new MySqlCommandBuilder(comando_sql);
            comando_sql.Fill(tabela_memoria);

            for (int linha = 0; tabela_memoria.Rows.Count > linha; linha++)
            {
                for (int coluna = 1; tabela_memoria.Columns.Count > coluna; coluna++)
                {
                    tabela_memoria.Rows[linha][coluna] = Cripto.descripto(tabela_memoria.Rows[linha][coluna].ToString());
                }
            }


        }



        public bool inserir(String nome, String login, String senha)
        {
            try
            {
                carregar_tabela("insert into administrador values(0,'" + nome + "','" + login + "','" + senha + "')");

                return true;
            }
            catch
            {
                return false;
            }
        }

        public DataTable listarTudo()
        {
            carregar_tabela("select * from administrador");

            return tabela_memoria;
        }

        public bool pesquisarAdm(String login)
        {
            carregar_tabela("select * from administrador where login='" + login + "'");

            try
            {

                Login = tabela_memoria.Rows[0]["login_adm"].ToString();
                Senha = tabela_memoria.Rows[0]["senha_adm"].ToString();



                return true;
            }
            catch
            {
                return false;
            }
        }


        public void Alterar_adm(String login, String senha, String id_ad)
        {
            carregar_tabela("update administrador set login_adm='" + login + "',senha_adm='" + senha + "' where id_adm=" + id_ad + " ");

        }

        public bool logar(String usuario, String senha)
        {
            carregar_tabela("Select * from administrador where login_adm = '" + usuario + "' and senha_adm = '" + senha + "'");
            if (tabela_memoria.Rows.Count == 1)
                return true;
            else
                return false;
        }



        public DataTable listarteste()
        {
            carregar_tabela("select * from relatorio");

            return tabela_memoria;
        }

    }
}
