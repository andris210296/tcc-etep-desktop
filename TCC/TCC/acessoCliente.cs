using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace TCC
{
    class acessoCliente
    {
        int id_cli, numcasa_cli;
        String email_cli, senha_cli, nome_cli, sexo_cli, estciv_cli, bairroEmpresa_cli,
            uf_cli, cidade_cli, bairro_cli, tipopessoa_cli, empresa_cli, cepEmpresa_cli, enderecoEmpresa_cli,
            profissao_cli, cidadeEmp_cli, ufEmpresa_cli, banco_cli, tipoconta_cli, agencia_cli,
            rg_cli, cpf_cli, cep_cli, tel_cli, cel_cli, telCom_cli, endereco_cli, complemento_cli,
            numdependentes_cli, numconta_cli, renda_cli, foto_cli;

        public String Foto_cli
        {
            get { return foto_cli; }
            set { foto_cli = value; }
        }  
        DateTime datanasc_cli;

        #region Variáveis Encapsuladas

        public String BairroEmpresa_cli
        {
            get { return bairroEmpresa_cli; }
            set { bairroEmpresa_cli = value; }
        }

        public String EnderecoEmpresa_cli
        {
            get { return enderecoEmpresa_cli; }
            set { enderecoEmpresa_cli = value; }
        }

        public String CepEmpresa_cli
        {
            get { return cepEmpresa_cli; }
            set { cepEmpresa_cli = value; }
        }

        public String Complemento_cli
        {
            get { return complemento_cli; }
            set { complemento_cli = value; }
        }

        public String Endereco_cli
        {
            get { return endereco_cli; }
            set { endereco_cli = value; }
        }
        public String Renda_cli
        {
            get { return renda_cli; }
            set { renda_cli = value; }
        }
        public DateTime Datanasc_cli
        {
            get { return datanasc_cli; }
            set { datanasc_cli = value; }
        }
        public String Agencia_cli
        {
            get { return agencia_cli; }
            set { agencia_cli = value; }
        }
        public String Tipoconta_cli
        {
            get { return tipoconta_cli; }
            set { tipoconta_cli = value; }
        }
        public String Banco_cli
        {
            get { return banco_cli; }
            set { banco_cli = value; }
        }
        public String Ufempresa_cli
        {
            get { return ufEmpresa_cli; }
            set { ufEmpresa_cli = value; }
        }
        public String Cidadeemp_cli
        {
            get { return cidadeEmp_cli; }
            set { cidadeEmp_cli = value; }
        }
        public String Profissao_cli
        {
            get { return profissao_cli; }
            set { profissao_cli = value; }
        }
        public String Empresa_cli
        {
            get { return empresa_cli; }
            set { empresa_cli = value; }
        }
        public String Tipopessoa_cli
        {
            get { return tipopessoa_cli; }
            set { tipopessoa_cli = value; }
        }
        public String Bairro_cli
        {
            get { return bairro_cli; }
            set { bairro_cli = value; }
        }
        public String Cidade_cli
        {
            get { return cidade_cli; }
            set { cidade_cli = value; }
        }
        public String Uf_cli
        {
            get { return uf_cli; }
            set { uf_cli = value; }
        }
        public String Estciv_cli
        {
            get { return estciv_cli; }
            set { estciv_cli = value; }
        }
        public String Sexo_cli
        {
            get { return sexo_cli; }
            set { sexo_cli = value; }
        }
        public String Nome_cli
        {
            get { return nome_cli; }
            set { nome_cli = value; }
        }
        public String Senha_cli
        {
            get { return senha_cli; }
            set { senha_cli = value; }
        }
        public String Email_cli
        {
            get { return email_cli; }
            set { email_cli = value; }
        }
        public String Numconta_cli
        {
            get { return numconta_cli; }
            set { numconta_cli = value; }
        }
        public String Telcom_cli
        {
            get { return telCom_cli; }
            set { telCom_cli = value; }
        }
        public String Numdependentes_cli
        {
            get { return numdependentes_cli; }
            set { numdependentes_cli = value; }
        }
        public String Cel_cli
        {
            get { return cel_cli; }
            set { cel_cli = value; }
        }
        public String Tel_cli
        {
            get { return tel_cli; }
            set { tel_cli = value; }
        }
        public int Numcasa_cli
        {
            get { return numcasa_cli; }
            set { numcasa_cli = value; }
        }
        public String Cep_cli
        {
            get { return cep_cli; }
            set { cep_cli = value; }
        }
        public String Cpf_cli
        {
            get { return cpf_cli; }
            set { cpf_cli = value; }
        }
        public String Rg_cli
        {
            get { return rg_cli; }
            set { rg_cli = value; }
        }
        public int Id_cli
        {
            get { return id_cli; }
            set { id_cli = value; }
        }


        #endregion

        MySqlDataAdapter comando_sql;
        MySqlCommandBuilder executar_comando;
        DataTable tabela_memoria;
        private DataTable lista_cliente;

        public DataTable Lista_cliente
        {
            get { return lista_cliente; }
            set { lista_cliente = value; }
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


        public bool inserir(String email, String senha, String nome, String datanasc,
            String rg, String cpf, String sexo, String estcivil, String cep, String endereco_cli, String bairro,
            String numcasa_cli, String complemento, String cidade, 
            String tel, String cel, String tipopessoa, String numpendentes, String profissao,
            String empresa, String cepEmpresa, String enderecoEmpresa, String bairroEmp, String cidadeEmpresa, 
            String telcom, String banco, String tipoconta, String agencia, String numconta, String renda,String nomeFoto)
        {
            try
            {
                Datanasc_cli = Convert.ToDateTime(datanasc);
                String data_nasc = Datanasc_cli.ToString("yyyy/MM/dd");

                // Verificar Campos que estao NULLS
                if (estcivil == string.Empty)
                    estcivil = "NULL";
                if (complemento == string.Empty)
                    complemento = "NULL";
                if (cel == string.Empty)
                    cel = "NULL";
                if (numpendentes == string.Empty)
                    numpendentes = "NULL";
                if (profissao == string.Empty)
                    profissao = "NULL";
                if (empresa == string.Empty)
                    empresa = "NULL";
                if (cepEmpresa == string.Empty)
                    cepEmpresa = "NULL";
                if (enderecoEmpresa == string.Empty)
                    enderecoEmpresa = "NULL";
                if (bairroEmp == string.Empty)
                    bairroEmp = "NULL";
                if (cidadeEmpresa == string.Empty)
                    cidadeEmpresa = "NULL";
                if (telcom == string.Empty)
                    telcom = "NULL";
                if (banco == string.Empty)
                    banco = "NULL";
                if (tipoconta == string.Empty)
                    tipoconta = "NULL";
                if (agencia == string.Empty)
                    agencia = "NULL";
                if (numconta == string.Empty)
                    numconta = "NULL";
                if (renda == string.Empty)
                    renda = "NULL";

              

                carregar_tabela("insert into cliente values(0, '" + Cripto.cripto(email) + "', '" + Cripto.cripto(senha) + "', '" + Cripto.cripto(nome)
                    + "', '" + Cripto.cripto(data_nasc) + "', '" + Cripto.cripto(rg) + "', '" + Cripto.cripto(cpf) + "', '" + Cripto.cripto(sexo) + "', '" + Cripto.cripto(nomeFoto) + "', '" + Cripto.cripto(estcivil)
                    +"', '" + Cripto.cripto(cep) + "', '" + Cripto.cripto(endereco_cli) + "', '" + Cripto.cripto(bairro) + "','" + Cripto.cripto(numcasa_cli)
                    + "', '" + Cripto.cripto(complemento) + "', '" + Cripto.cripto(cidade) + "', '" + Cripto.cripto(tel) + "', '" + Cripto.cripto(cel) + "', '" + Cripto.cripto(tipopessoa)
                    + "', '" + Cripto.cripto(numpendentes) + "', '" + Cripto.cripto(profissao) + "', '" + Cripto.cripto(empresa) + "', '" + Cripto.cripto(cepEmpresa)
                    + "', '" + Cripto.cripto(enderecoEmpresa) + "', '" + Cripto.cripto(bairroEmp) + "', '" + Cripto.cripto(cidadeEmpresa) + "', '" + Cripto.cripto(telcom) 
                    + "', '" + Cripto.cripto(banco) + "', '" + Cripto.cripto(tipoconta) + "', '" + Cripto.cripto(agencia) + "','" + Cripto.cripto(numconta) + "','" + Cripto.cripto(renda.Replace(',', '.')) + "');");

                
                return true;
            }
            catch
            {
                return false;
            }
        }
        

        public DataTable listarTudo()
        {
            carregar_tabela("select * from cliente");

            return tabela_memoria;
        }


        public bool pesquisarCliente(String nome)
        {



            carregar_tabela("select * from cliente where nome_cli='" + nome + "'");



            try
            {
                Id_cli = Convert.ToInt32(tabela_memoria.Rows[0]["id_cli"].ToString());
                Email_cli = tabela_memoria.Rows[0]["email_cli"].ToString();
                Senha_cli = tabela_memoria.Rows[0]["senha_cli"].ToString();
                Nome_cli = tabela_memoria.Rows[0]["nome_cli"].ToString();
                Datanasc_cli = Convert.ToDateTime(tabela_memoria.Rows[0]["datanasc_cli"].ToString());
                Rg_cli = tabela_memoria.Rows[0]["rg_cli"].ToString();
                Cpf_cli = tabela_memoria.Rows[0]["cpf_cli"].ToString();
                Sexo_cli = tabela_memoria.Rows[0]["sexo_cli"].ToString();
                Foto_cli = tabela_memoria.Rows[0]["foto_cli"].ToString();
                Estciv_cli = tabela_memoria.Rows[0]["estciv_cli"].ToString();
                Cep_cli = tabela_memoria.Rows[0]["cep_cli"].ToString();
                Endereco_cli = tabela_memoria.Rows[0]["endereco_cli"].ToString();
                Bairro_cli = tabela_memoria.Rows[0]["bairro_cli"].ToString();
                Numcasa_cli = Convert.ToInt32(tabela_memoria.Rows[0]["numcasa_cli"].ToString());
                Complemento_cli = tabela_memoria.Rows[0]["complemento_cli"].ToString();
                Cidade_cli = tabela_memoria.Rows[0]["cidade_cli"].ToString();
                Tel_cli = tabela_memoria.Rows[0]["tel_cli"].ToString();
                Cel_cli = tabela_memoria.Rows[0]["cel_cli"].ToString();
                Tipopessoa_cli = tabela_memoria.Rows[0]["tipopessoa_cli"].ToString();
                if (Numdependentes_cli != null)
                {
                    Numdependentes_cli = tabela_memoria.Rows[0]["numdependentes_cli"].ToString();
                }
                else
                {
                    Numdependentes_cli = "0";
                }
                Profissao_cli = tabela_memoria.Rows[0]["profissao_cli"].ToString();
                Empresa_cli = tabela_memoria.Rows[0]["empresa_cli"].ToString();
                CepEmpresa_cli = tabela_memoria.Rows[0]["cepEmpresa_cli"].ToString();
                enderecoEmpresa_cli = tabela_memoria.Rows[0]["enderecoEmpresa_cli"].ToString();
                BairroEmpresa_cli = tabela_memoria.Rows[0]["bairroEmpresa_cli"].ToString();
                Cidadeemp_cli = tabela_memoria.Rows[0]["cidadeEmp_cli"].ToString();
                Telcom_cli = tabela_memoria.Rows[0]["telcom_cli"].ToString();
                Banco_cli = tabela_memoria.Rows[0]["banco_cli"].ToString();
                Tipoconta_cli = tabela_memoria.Rows[0]["tipoconta_cli"].ToString();
                Agencia_cli = tabela_memoria.Rows[0]["agencia_cli"].ToString();
                if (Numconta_cli != null)
                {
                Numconta_cli = tabela_memoria.Rows[0]["numconta_cli"].ToString();
                }
                else
                {
                    Numconta_cli = "0";
                }

                if (Renda_cli != null)
                {
                    Renda_cli = tabela_memoria.Rows[0]["renda_cli"].ToString();
                }
                else
                {
                    Renda_cli = "0";
                }



     

                if (tabela_memoria.Rows.Count > 1)
                {
                    lista_cliente = tabela_memoria;
                }
                else
                {
                    lista_cliente = null;
                }





                return true;
            }
            catch
            {
                return false;
            }
        }



        public bool alterar(String Nemail, String Nsenha, String Nnome, String ndatanasc,
            String nrg, String ncpf, String nsexo,String nomeFoto, String nestcivil, String ncep, String nendereco_cli, String nbairro,
            String nnumcasa_cli, String ncomplemento, String ncidade, 
            String ntel, String ncel, String ntipopessoa, String nnumpendentes, String nprofissao,
            String nempresa, String ncepEmpresa, String nenderecoEmpresa, String nbairroEmp, String ncidadeEmpresa, 
            String ntelcom, String nbanco, String ntipoconta, String nagencia, String nnumconta, String nrenda, String id)
        {
            try
            {
                Datanasc_cli = Convert.ToDateTime(ndatanasc);
                String Corretodata_nasc = Datanasc_cli.ToString("yyyy/MM/dd");

                // Verificar Campos que estao NULLS
                if (nestcivil == string.Empty)
                    nestcivil = "NULL";
                if (ncomplemento == string.Empty)
                    ncomplemento = "NULL";
                if (ncel == string.Empty)
                    ncel = "NULL";
                if (nnumpendentes == string.Empty)
                    nnumpendentes = "NULL";
                if (nprofissao == string.Empty)
                    nprofissao = "NULL";
                if (nempresa == string.Empty)
                    nempresa = "NULL";
                if (ncepEmpresa == string.Empty)
                    ncepEmpresa = "NULL";
                if (nenderecoEmpresa == string.Empty)
                    nenderecoEmpresa = "NULL";
                if (nbairroEmp == string.Empty)
                    nbairroEmp = "NULL";
                if (ncidadeEmpresa == string.Empty)
                    ncidadeEmpresa = "NULL";
                if (ntelcom == string.Empty)
                    ntelcom = "NULL";
                if (nbanco == string.Empty)
                    nbanco = "NULL";
                if (ntipoconta == string.Empty)
                    ntipoconta = "NULL";
                if (nagencia == string.Empty)
                    nagencia = "NULL";
                if (nnumconta == string.Empty)
                    nnumconta = "NULL";
                if (nrenda == string.Empty)
                    nrenda = "NULL";

                
             


                carregar_tabela("update cliente set email_cli='" + Cripto.cripto(Nemail) + "', senha_cli='" + Cripto.cripto(Nsenha) + "', nome_cli='" + Cripto.cripto(Nnome) + "', datanasc_cli='" + Cripto.cripto(Corretodata_nasc)
                    + "', rg_cli='" + Cripto.cripto(nrg) + "', cpf_cli ='" + Cripto.cripto(ncpf) + "', sexo_cli ='" + Cripto.cripto(nsexo) + "', foto_cli ='" + Cripto.cripto(nomeFoto) + "', estciv_cli ='" + Cripto.cripto(nestcivil) + "', cep_cli ='" + Cripto.cripto(ncep) + "', endereco_cli ='" + Cripto.cripto(nendereco_cli) + "', bairro_cli ='" + Cripto.cripto(nbairro)
                    + "', numcasa_cli ='" + Cripto.cripto(nnumcasa_cli) + "', complemento_cli ='" + Cripto.cripto(ncomplemento) + "', cidade_cli ='" + Cripto.cripto(ncidade)
                    + "', tel_cli ='" + Cripto.cripto(ntel) + "', cel_cli ='" + Cripto.cripto(ncel) + "', tipopessoa_cli ='" + Cripto.cripto(ntipopessoa) + "', numdependentes_cli ='" + Cripto.cripto(nnumpendentes) + "', profissao_cli ='" + Cripto.cripto(nprofissao)
                    + "', empresa_cli ='" + Cripto.cripto(nempresa) + "', cepEmpresa_cli ='" + Cripto.cripto(ncepEmpresa) + "', enderecoEmpresa_cli ='" + Cripto.cripto(nenderecoEmpresa) + "', bairroEmpresa_cli ='" + Cripto.cripto(nbairroEmp) + "', cidadeEmp_cli ='" + Cripto.cripto(ncidadeEmpresa)
                    + "', telCom_cli ='" + Cripto.cripto(ntelcom) + "', banco_cli ='" + Cripto.cripto(nbanco) + "', tipoconta_cli ='" + Cripto.cripto(ntipoconta) + "', agencia_cli ='" + Cripto.cripto(nagencia) + "', numconta_cli ='" + Cripto.cripto(nnumconta) + "', renda_cli ='" + Cripto.cripto(nrenda) + "' where id_cli=" + id + "");
                return true;
            }
            catch
            {
                return false;
            }
        }

        public DataTable filtro(String nomep)
        {
            carregar_tabela("select * from cliente where nome_cli like '%" + Cripto.cripto(nomep) + "%'");
            return tabela_memoria;
        }



        public void excluir(String ID)
        {
            carregar_tabela("delete from carrocliente where id_cli="+ID);
            carregar_tabela("delete from cliente where id_cli="+ID);
        
        }





        public bool pesquisarClienteParaVenda(String nome)
        {



            carregar_tabela("select * from cliente where nome_cli='" + Cripto.cripto(nome) + "'");



            try
            {
                Id_cli = Convert.ToInt32(tabela_memoria.Rows[0]["id_cli"].ToString());
                Email_cli = tabela_memoria.Rows[0]["email_cli"].ToString();
                Senha_cli = tabela_memoria.Rows[0]["senha_cli"].ToString();
                Nome_cli = tabela_memoria.Rows[0]["nome_cli"].ToString();
                Datanasc_cli = Convert.ToDateTime(tabela_memoria.Rows[0]["datanasc_cli"].ToString());
                Rg_cli = tabela_memoria.Rows[0]["rg_cli"].ToString();
                Cpf_cli = tabela_memoria.Rows[0]["cpf_cli"].ToString();
                Sexo_cli = tabela_memoria.Rows[0]["sexo_cli"].ToString();
                Estciv_cli = tabela_memoria.Rows[0]["estciv_cli"].ToString();
                Cep_cli = tabela_memoria.Rows[0]["cep_cli"].ToString();
                Endereco_cli = tabela_memoria.Rows[0]["endereco_cli"].ToString();
                Bairro_cli = tabela_memoria.Rows[0]["bairro_cli"].ToString();
                Numcasa_cli = Convert.ToInt32(tabela_memoria.Rows[0]["numcasa_cli"].ToString());
                Complemento_cli = tabela_memoria.Rows[0]["complemento_cli"].ToString();
                Cidade_cli = tabela_memoria.Rows[0]["cidade_cli"].ToString();
                Tel_cli = tabela_memoria.Rows[0]["tel_cli"].ToString();
                Cel_cli = tabela_memoria.Rows[0]["cel_cli"].ToString();
                Tipopessoa_cli = tabela_memoria.Rows[0]["tipopessoa_cli"].ToString();
                if (Numdependentes_cli != null)
                {
                    Numdependentes_cli = tabela_memoria.Rows[0]["numdependentes_cli"].ToString();
                }
                else
                {
                    Numdependentes_cli = "0";
                }
                Profissao_cli = tabela_memoria.Rows[0]["profissao_cli"].ToString();
                Empresa_cli = tabela_memoria.Rows[0]["empresa_cli"].ToString();
                CepEmpresa_cli = tabela_memoria.Rows[0]["cepEmpresa_cli"].ToString();
                enderecoEmpresa_cli = tabela_memoria.Rows[0]["enderecoEmpresa_cli"].ToString();
                BairroEmpresa_cli = tabela_memoria.Rows[0]["bairroEmpresa_cli"].ToString();
                Cidadeemp_cli = tabela_memoria.Rows[0]["cidadeEmp_cli"].ToString();
                Telcom_cli = tabela_memoria.Rows[0]["telcom_cli"].ToString();
                Banco_cli = tabela_memoria.Rows[0]["banco_cli"].ToString();
                Tipoconta_cli = tabela_memoria.Rows[0]["tipoconta_cli"].ToString();
                Agencia_cli = tabela_memoria.Rows[0]["agencia_cli"].ToString();
                if (Numconta_cli != null)
                {
                    Numconta_cli = tabela_memoria.Rows[0]["numconta_cli"].ToString();
                }
                else
                {
                    Numconta_cli = "0";
                }

                if (Renda_cli != null)
                {
                    Renda_cli = tabela_memoria.Rows[0]["renda_cli"].ToString();
                }
                else
                {
                    Renda_cli = "0";
                }





                if (tabela_memoria.Rows.Count > 1)
                {
                    lista_cliente = tabela_memoria;
                }
                else
                {
                    lista_cliente = null;
                }





                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
