using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace TCC
{
    class acessoFornecedor
    {
        int id_forn;
        string nome_forn, pais_forn, cidade_forn, email_forn, cnpj_forn, fone_forn, site_forn, uf_forn;

        #region Variaveis Encapsuladas

        public string Site_forn
        {
            get { return site_forn; }
            set { site_forn = value; }
        }

        public string Uf_forn
        {
            get { return uf_forn; }
            set { uf_forn = value; }
        }

        public int Id_forn
    {
        get { return id_forn; }
        set { id_forn = value; }
    }
        public string Nome_forn
    {
        get { return nome_forn; }
        set { nome_forn = value; }
    }
        public string Cnpj_forn
    {
        get { return cnpj_forn; }
        set { cnpj_forn = value; }
    }
    public string Email_forn
    {
        get { return email_forn; }
        set { email_forn = value; }
    }

    public string Cidade_forn
    {
        get { return cidade_forn; }
        set { cidade_forn = value; }
    }

    public string Pais_forn
    {
        get { return pais_forn; }
        set { pais_forn = value; }
    }
    public string Fone_forn
    {
        get { return fone_forn; }
        set { fone_forn = value; }
    }
        #endregion

    // criar as variáveis para acessar o MYSQL
    MySqlDataAdapter comando_sql;
    MySqlCommandBuilder executar_comando;
    DataTable tabela_memoria;
    private DataTable lista_fornecedor;

    public DataTable Lista_fornecedor
    {
        get { return lista_fornecedor; }
        set { lista_fornecedor = value; }
    }



    // método de acesso ao BD
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

    public bool inserir(String nome, String cnpj, String pais, String cidade, String fone, String email, String site, String uf)
    {
        try
        {
            // Verificar Campos que estao NULLS
            if (site == string.Empty)
                site = "NULL";

            carregar_tabela("insert into fornecedor values(0,'" + Cripto.cripto(nome) + "','" + Cripto.cripto(cnpj) + "','" + Cripto.cripto(pais) + "','" + Cripto.cripto(cidade) + "','" + Cripto.cripto(fone) + "','" + Cripto.cripto(email) + "','" + Cripto.cripto(site) + "','" + Cripto.cripto(uf) + "')");
            return true;
        }
        catch
        {
            return false;
        }
    }

    public DataTable listarTudo()
    {
        carregar_tabela("select * from fornecedor");

        return tabela_memoria;
    }

    public bool pesquisarFornecedor(String nome)
    {
        carregar_tabela("select * from fornecedor where nome_forn='" + nome + "'");

        try
        {
            Id_forn = Convert.ToInt32(tabela_memoria.Rows[0]["id_forn"].ToString());
            Nome_forn = tabela_memoria.Rows[0]["nome_forn"].ToString();
            Cnpj_forn = tabela_memoria.Rows[0]["cnpj_forn"].ToString();
            Pais_forn = tabela_memoria.Rows[0]["pais_forn"].ToString();
            Cidade_forn = tabela_memoria.Rows[0]["cidade_forn"].ToString();
            Fone_forn = tabela_memoria.Rows[0]["fone_forn"].ToString();
            Email_forn = tabela_memoria.Rows[0]["email_forn"].ToString();
            Site_forn = tabela_memoria.Rows[0]["site_forn"].ToString();
            Uf_forn = tabela_memoria.Rows[0]["uf_forn"].ToString();


            if (tabela_memoria.Rows.Count > 1)
            {
                lista_fornecedor = tabela_memoria;
            }
            else
            {
                lista_fornecedor = null;
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
        carregar_tabela("delete from fornecedor where id_forn=" + id);
    }

    public bool alterar(String nNome, String nCnpj, String nPais, String nCidade, String nFone, String nEmail, String nSite, String nUf, String id)
    {
        try
        {
            // Verificar Campos que estao NULLS
            if (nSite == string.Empty)
                nSite = "NULL";

            carregar_tabela("update fornecedor set nome_forn='" + Cripto.cripto(nNome) + "', cnpj_forn='" + Cripto.cripto(nCnpj) + "', pais_forn='" + Cripto.cripto(nPais)
                + "', cidade_forn='" + Cripto.cripto(nCidade) + "', fone_forn='" + Cripto.cripto(nFone) + "', email_forn='" + Cripto.cripto(nEmail) + "', site_forn='" + Cripto.cripto(nSite) + "', uf_forn='" + Cripto.cripto(nUf) + "' where id_forn=" + id + "");
            return true;
        }
        catch
        {
            return false;
        }
    }


    public DataTable filtro(String nomep)
    {
        carregar_tabela("select * from fornecedor where nome_forn like '" + Cripto.cripto(nomep) + "%'");
        return tabela_memoria;
    }



    }
}
