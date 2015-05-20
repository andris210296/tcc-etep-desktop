using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace TCC
{
    class acessoContrato
    {
        int id_cont, id_cli, id_fun, id_pag, id_venda;
        DateTime datacomp_cont;
        float valor_cont;

        // FK
        String nome_cli, nome_fun, forma_pag;

        #region variaveis
        public int Id_venda
        {
            get { return id_venda; }
            set { id_venda = value; }
        }

        public int Id_pag
        {
            get { return id_pag; }
            set { id_pag = value; }
        }

        public int Id_fun
        {
            get { return id_fun; }
            set { id_fun = value; }
        }

        public int Id_cli
        {
            get { return id_cli; }
            set { id_cli = value; }
        }

        public int Id_cont
        {
            get { return id_cont; }
            set { id_cont = value; }
        }
        public DateTime Datacomp_cont
        {
            get { return datacomp_cont; }
            set { datacomp_cont = value; }
        }
        public float Valor_cont
        {
            get { return valor_cont; }
            set { valor_cont = value; }
        }
        public String Forma_pag
        {
            get { return forma_pag; }
            set { forma_pag = value; }
        }

        public String Nome_fun
        {
            get { return nome_fun; }
            set { nome_fun = value; }
        }

        public String Nome_cli
        {
            get { return nome_cli; }
            set { nome_cli = value; }
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

        public bool inserirCont(String idCli, String id_fun, String id_pag, String datacomp_cont, String valor_cont)
        {
            try
            {
                Datacomp_cont = Convert.ToDateTime(datacomp_cont);
                String dataCorreta = Datacomp_cont.ToString("yyyy/MM/dd");

                carregar_tabela("insert into venda values(0, " + idCli + ", " + id_fun + ", " + id_pag + ", '" + Cripto.cripto(dataCorreta) + "', '" + Cripto.cripto(valor_cont.Replace(',', '.')) + "')");
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
