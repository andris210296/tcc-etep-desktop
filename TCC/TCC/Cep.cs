using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace TCC
{
    class Cep
    {
        int id_cep;

        public int Id_cep
        {
            get { return id_cep; }
            set { id_cep = value; }
        }

        String logradouro, tp_logradouro, bairro, cep, cidade;

        public String Cidade
        {
            get { return cidade; }
            set { cidade = value; }
        }

        public String Cep1
        {
            get { return cep; }
            set { cep = value; }
        }

        public String Bairro
        {
            get { return bairro; }
            set { bairro = value; }
        }

        public String Tp_logradouro
        {
            get { return tp_logradouro; }
            set { tp_logradouro = value; }
        }

        public String Logradouro
        {
            get { return logradouro; }
            set { logradouro = value; }
        }

        MySqlDataAdapter comando_sql;
        MySqlCommandBuilder executar_comando;
        DataTable tabela_memoria;
        private DataTable lista_funcionario;


        private void carregar_tabela(String comando)
        {
            tabela_memoria = new DataTable();
            comando_sql = new MySqlDataAdapter(comando, Conexao.Conectar);
            executar_comando = new MySqlCommandBuilder(comando_sql);
            comando_sql.Fill(tabela_memoria);
        }



    

        public bool inserir(String cidade, String logradouro, String bairro, String cep, String tp_logradouro)
        {
            try
            {
            
                carregar_tabela("insert into funcionario values(0,'" + cidade + "','" + logradouro + "','" + bairro + "','" + cep + "','" + tp_logradouro +  "')");

                return true;
            }
            catch
            {
                return false;
            }
        }



        public DataTable listarTudo()
        {
            carregar_tabela("select * from CEPS");

            return tabela_memoria;
        }

        public bool PesquisarCep(String cep)
        {
            carregar_tabela("select * from CEPS where cep='" + cep + "'");
            //select c.cep from ceps c inner join funcionario f on c.id_cep = f.id_cep where c.cep='12246-870';
            //carregar_tabela("select * from ceps c inner join funcionario f on c.id_cep = f.id_cep where c.cep='" + cep + "'");
            try
            {
                Id_cep = Convert.ToInt32(tabela_memoria.Rows[0]["ID_CEP"].ToString());
                Cidade  = tabela_memoria.Rows[0]["CIDADE"].ToString();
                Logradouro = tabela_memoria.Rows[0]["LOGRADOURO"].ToString();
                 Bairro = tabela_memoria.Rows[0]["BAIRRO"].ToString();
                Cep1 =   tabela_memoria.Rows[0]["CEP"].ToString(); 
                Tp_logradouro = tabela_memoria.Rows[0]["TP_LOGRADOURO"].ToString();

                return true;
            }
            catch
            {
                return false;
            }
        }





    }
}
