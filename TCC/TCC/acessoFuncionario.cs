using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace TCC
{
    class acessoFuncionario
    {
        int id_fun, num_fun;
        String id_cep;

        public String Id_cep
        {
            get { return id_cep; }
            set { id_cep = value; }
        }
        String nome_fun, cpf_fun, estciv_fun, sexo_fun, cidade_fun, bairro_fun,
             tel_fun, cel_fun, departamento_fun, turno_fun, endereco_fun, complemento_fun, login, senha, email_fun, rg_fun, cartao;

        public String Cartao
        {
            get { return cartao; }
            set { cartao = value; }
        }
        DateTime dtnasc_fun;
        double salario_fun;

        #region Variáveis Encapsuladas
        public String Rg_fun
        {
            get { return rg_fun; }
            set { rg_fun = value; }
        }
        public String Email_fun
        {
            get { return email_fun; }
            set { email_fun = value; }
        }
        public String Endereco_fun
        {
            get { return endereco_fun; }
            set { endereco_fun = value; }
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

        public String Complemento
        {
            get { return complemento_fun; }
            set { complemento_fun = value; }
        }

        public String Turno_fun
        {
            get { return turno_fun; }
            set { turno_fun = value; }
        }

        public String Departamento_fun
        {
            get { return departamento_fun; }
            set { departamento_fun = value; }
        }

        public String Cel_fun
        {
            get { return cel_fun; }
            set { cel_fun = value; }
        }

        public String Tel_fun
        {
            get { return tel_fun; }
            set { tel_fun = value; }
        }





        public String Bairro_fun
        {
            get { return bairro_fun; }
            set { bairro_fun = value; }
        }

        public String Cidade_fun
        {
            get { return cidade_fun; }
            set { cidade_fun = value; }
        }
        public String Sexo_fun
        {
            get { return sexo_fun; }
            set { sexo_fun = value; }
        }

        public String Estciv_fun
        {
            get { return estciv_fun; }
            set { estciv_fun = value; }
        }



        public String Cpf_fun
        {
            get { return cpf_fun; }
            set { cpf_fun = value; }
        }

        public String Nome_fun
        {
            get { return nome_fun; }
            set { nome_fun = value; }
        }
        public double Salario_fun
        {
            get { return salario_fun; }
            set { salario_fun = value; }
        }
        public DateTime Dtnasc_fun
        {
            get { return dtnasc_fun; }
            set { dtnasc_fun = value; }
        }
        public int Num_fun
        {
            get { return num_fun; }
            set { num_fun = value; }
        }

        public int Id_fun
        {
            get { return id_fun; }
            set { id_fun = value; }
        }





        #endregion

        MySqlDataAdapter comando_sql;
        MySqlCommandBuilder executar_comando;
        DataTable tabela_memoria;
        private DataTable lista_funcionario;

        public DataTable Lista_funcionario
        {
            get { return lista_funcionario; }
            set { lista_funcionario = value; }
        }



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




        public bool inserir(String nome, String cpf, String estciv, String dtnasc, String sexo, String endereco, String numero, String cidade, String bairro, String id_cep, String tel, String cel, String salario, String departamento, String turno, String complemento, String email, String rg, String login, String senha, String cartao)
        {
            try
            {
                Dtnasc_fun = Convert.ToDateTime(dtnasc);
                String data_nasc = Dtnasc_fun.ToString("yyyy/MM/dd");

                // Verificar Campos que estao NULLS
                if (estciv == string.Empty)
                    estciv = "NULL";
                if (complemento == string.Empty)
                    complemento = "NULL";
                if (cel == string.Empty)
                    cel = "NULL";


             




                carregar_tabela("insert into funcionario values(0,'" + Cripto.cripto(nome) + "','" + Cripto.cripto(cpf) + "','" 
                    + Cripto.cripto(estciv) + "','" + Cripto.cripto(data_nasc) + "','" + Cripto.cripto(sexo) + "','" + Cripto.cripto(endereco) + "','" + Cripto.cripto(numero) + "','" 
                    + Cripto.cripto(cidade) + "','" + Cripto.cripto(bairro) + "','" + Cripto.cripto(id_cep) + "','" + Cripto.cripto(tel) + "','" + Cripto.cripto(cel) + "','"
                    + Cripto.cripto(salario.Replace(',', '.')) + "','" + Cripto.cripto(departamento) + "','" + Cripto.cripto(turno) + "','"
                    + Cripto.cripto(complemento) + "','" + Cripto.cripto(email) + "','" + Cripto.cripto(rg) + "','" + Cripto.cripto(login) + "','" + Cripto.cripto(senha) + "','" + Cripto.cripto(cartao) + "')");

                return true;
            }
            catch
            {
                return false;
            }
        }

        public DataTable listarTudo()
        {
            carregar_tabela("select * from funcionario");

            return tabela_memoria;
        }

        public bool pesquisarFunc(String nome)
        {
            


            carregar_tabela("select * from funcionario where nome_fun='" + nome + "'");

            try
            {
                Id_fun = Convert.ToInt32(tabela_memoria.Rows[0]["id_fun"].ToString());
                Nome_fun = tabela_memoria.Rows[0]["nome_fun"].ToString();
                Cpf_fun = tabela_memoria.Rows[0]["cpf_fun"].ToString();
                Estciv_fun = tabela_memoria.Rows[0]["estciv_fun"].ToString();
                Dtnasc_fun = Convert.ToDateTime(tabela_memoria.Rows[0]["dtnasc_fun"].ToString());
                Sexo_fun = tabela_memoria.Rows[0]["sexo_fun"].ToString();
                Endereco_fun = tabela_memoria.Rows[0]["endereco_fun"].ToString();
                Num_fun = Convert.ToInt32(tabela_memoria.Rows[0]["num_fun"].ToString());
                Cidade_fun = tabela_memoria.Rows[0]["cidade_fun"].ToString();
                Bairro_fun = tabela_memoria.Rows[0]["bairro_fun"].ToString();
           

                Tel_fun = tabela_memoria.Rows[0]["tel_fun"].ToString();
                Cel_fun = tabela_memoria.Rows[0]["cel_fun"].ToString();
                Salario_fun = Convert.ToDouble(tabela_memoria.Rows[0]["salario_fun"].ToString());
                Departamento_fun = tabela_memoria.Rows[0]["departamento_fun"].ToString();
                Turno_fun = tabela_memoria.Rows[0]["turno_fun"].ToString();
                Complemento = tabela_memoria.Rows[0]["complemento_fun"].ToString();
                Email_fun = tabela_memoria.Rows[0]["email_fun"].ToString();
                Rg_fun = tabela_memoria.Rows[0]["rg_fun"].ToString();
                Login = tabela_memoria.Rows[0]["login"].ToString();
                Senha = tabela_memoria.Rows[0]["senha"].ToString();
                cartao = tabela_memoria.Rows[0]["cartao"].ToString();

                Id_cep = tabela_memoria.Rows[0]["CEP_fun"].ToString();
                    



                if (tabela_memoria.Rows.Count > 1)
                {
                    lista_funcionario = tabela_memoria;
                }
                else
                {
                    lista_funcionario = null;
                }


                return true;
            }
            catch
            {
                return false;
            }
        }

        public void excluir(String id)
        {
            carregar_tabela("delete from funcionario where id_fun=" + id);
        }

        public bool Alterar_funcionario(String nome_fun,  String cpf_fun, String estciv_fun, String DATA, String sexo_fun, String endereco_fun, String num_fun, String cidade_fun, String bairro_fun, String id_cep, String tel_fun, String cel_fun, String salario_fun, String departamento_fun, String turno_fun, String complemento, String email, String rg, String login, String senha, String cartao, String id_fun)
        {
            try
            {
                Dtnasc_fun = Convert.ToDateTime(DATA);
                String dtNasc_Correta = Dtnasc_fun.ToString("yyyy/MM/dd");

                // Verificar Campos que estao NULLS
                if (estciv_fun == string.Empty)
                    estciv_fun = "NULL";
                if (complemento == string.Empty)
                    complemento = "NULL";
                if (cel_fun == string.Empty)
                    cel_fun = "NULL";



                carregar_tabela("update funcionario set nome_fun='" + Cripto.cripto(nome_fun) + "', cpf_fun='" +
                    Cripto.cripto(cpf_fun) + "', estciv_fun='" + Cripto.cripto(estciv_fun) + "', dtnasc_fun='" + Cripto.cripto(dtNasc_Correta) + "',sexo_fun='" +
                    Cripto.cripto(sexo_fun) + "',endereco_fun='" + Cripto.cripto(endereco_fun) + "',num_fun='" + Cripto.cripto(num_fun) + "',cidade_fun='" +
                    Cripto.cripto(cidade_fun) + "',bairro_fun='" + Cripto.cripto(bairro_fun) + "',CEP_fun='" + id_cep + "',tel_fun='" + 
                    Cripto.cripto(tel_fun) + "',cel_fun='" + Cripto.cripto(cel_fun) + "',salario_fun='" + Cripto.cripto(salario_fun.Replace(',', '.')) 
                    + "',departamento_fun='" + Cripto.cripto(departamento_fun) + "',turno_fun='" + Cripto.cripto(turno_fun) + "',complemento_fun='" 
                    + Cripto.cripto(complemento) + "',email_fun='" + Cripto.cripto(email) + "',rg_fun='" + Cripto.cripto(rg) + "',login='" + Cripto.cripto(login) + "',senha='"
                    + Cripto.cripto(senha) + "',cartao='" + Cripto.cripto(cartao) + "' where id_fun=" + id_fun + " ");
                
                return true;
            }
            catch
            {
                return false;
            }
        }

        public DataTable filtro(String nomep)
        {
            carregar_tabela("select * from funcionario where nome_fun like '" + Cripto.cripto(nomep) + "%'");

            return tabela_memoria;
        }

        public bool logar(String usuario, String senha)
        {
            carregar_tabela("Select * from funcionario where login = '" + Cripto.cripto(usuario) + "' and senha = '" + Cripto.cripto(senha) + "'");
            if (tabela_memoria.Rows.Count == 1)
                return true;
            else
                return false;
        }

        public bool logar_cartao(String cartao, String senha)
        {
            carregar_tabela("Select * from funcionario where cartao = '" + Cripto.cripto(cartao) + "' and senha = '" + Cripto.cripto(senha) + "'");
            if (tabela_memoria.Rows.Count == 1)
                return true;
            else
                return false;
        }

        public bool selecionarNome(String login)
        {
            carregar_tabela("select nome_fun from funcionario where login ='" + Cripto.cripto(login) + "'");

            try
            {
                Nome_fun = tabela_memoria.Rows[0]["nome_fun"].ToString();

                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool selecionarNomeCartao(String cartao)
        {
            carregar_tabela("select nome_fun from funcionario where cartao ='" + Cripto.cripto(cartao) + "'");

            try
            {
                Nome_fun = tabela_memoria.Rows[0]["nome_fun"].ToString();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool selecionarId(String login)
        {
            carregar_tabela("select id_fun from funcionario where login ='" + Cripto.cripto(login) + "'");

            try
            {
                Id_fun = Convert.ToInt32(tabela_memoria.Rows[0]["id_fun"].ToString());

                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool selecionarIdCartao(String cartao)
        {
            carregar_tabela("select id_fun from funcionario where cartao ='" + Cripto.cripto(cartao) + "'");

            try
            {
                Id_fun = Convert.ToInt32(tabela_memoria.Rows[0]["id_fun"].ToString());

                return true;
            }
            catch
            {
                return false;
            }
        }


    }
}

