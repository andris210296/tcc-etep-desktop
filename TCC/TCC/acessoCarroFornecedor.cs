using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace TCC
{
    class acessoCarroFornecedor
    {
        int id_cf, id_forn, anofab_cf, qtd_cf, portas_cf;
        String nome_cf, modelo_cf, marca_cf, cor_cf, combustivel_cf, opcionais_cf, desc_cf, foto_cf;

        public String Foto_cf
        {
            get { return foto_cf; }
            set { foto_cf = value; }
        }
        double valor_cf;

        // variavel para FK
        String nome_forn;

        public String Nome_forn
        {
            get { return nome_forn; }
            set { nome_forn = value; }
        }

        #region Variavéis Encapsuladas
        public double Valor_cf
        {
            get { return valor_cf; }
            set { valor_cf = value; }
        }
        public String Desc_cf
        {
            get { return desc_cf; }
            set { desc_cf = value; }
        }

        public String Opcionais_cf
        {
            get { return opcionais_cf; }
            set { opcionais_cf = value; }
        }

        public String Combustivel_cf
        {
            get { return combustivel_cf; }
            set { combustivel_cf = value; }
        }

        public String Cor_cf
        {
            get { return cor_cf; }
            set { cor_cf = value; }
        }

        public String Marca_cf
        {
            get { return marca_cf; }
            set { marca_cf = value; }
        }

        public String Modelo_cf
        {
            get { return modelo_cf; }
            set { modelo_cf = value; }
        }

        public String Nome_cf
        {
            get { return nome_cf; }
            set { nome_cf = value; }
        }
        public int Portas_cf
        {
            get { return portas_cf; }
            set { portas_cf = value; }
        }

        public int Qtd_cf
        {
            get { return qtd_cf; }
            set { qtd_cf = value; }
        }

        public int Anofab_cf
        {
            get { return anofab_cf; }
            set { anofab_cf = value; }
        }

        public int Id_forn
        {
            get { return id_forn; }
            set { id_forn = value; }
        }

        public int Id_cf
        {
            get { return id_cf; }
            set { id_cf = value; }
        }
        #endregion
        
        DataTable tabela_memoria;
        MySqlDataAdapter comando_sql;
        MySqlCommandBuilder executar_comando;
        private DataTable lista_carf;

        public DataTable Lista_carf
        {
            get { return lista_carf; }
            set { lista_carf = value; }
        }


        private void carregar_tabela(string comando)
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



        public bool inserir(String id_for, String nome, String modelo, String marca, String ano, String cor, String combustivel, String portas, String opcionais, String descricao, String valor, String qtd,String foto)
        {
            try
            {
                // Verificar Campos que estao NULLS
                if (modelo == string.Empty)
                    modelo = "NULL";
                if (opcionais == string.Empty)
                    opcionais = "NULL";
                if (descricao == string.Empty)
                    descricao = "NULL";

                carregar_tabela("insert into carrofornecedor values(0," + id_for + " ,'" +  Cripto.cripto(nome) + "','" +  Cripto.cripto(modelo) + "','" +  Cripto.cripto(marca) + "','" +  Cripto.cripto(ano) + "','" +  Cripto.cripto(cor) + "','" +  Cripto.cripto(combustivel) + "','" +  Cripto.cripto(portas) + "', '" +  Cripto.cripto(opcionais) + "','" +  Cripto.cripto(descricao) + "','" +  Cripto.cripto(valor.Replace(',', '.')) + "', '" +  Cripto.cripto(qtd) + "', '" + Cripto.cripto(foto) + "')");

                return true;
            }
            catch
            {
                return false;
            }
        }


        public DataTable listar_td()
        {
            carregar_tabela("select * from carrofornecedor");
            return tabela_memoria;
        }


        public bool pesquisarCarroFornecedor(String nome)
        {
            carregar_tabela("select * from carrofornecedor cf inner join fornecedor f on cf.id_forn = f.id_forn where cf.nome_cf='" + nome + "'");

            try
            {
                Id_cf = Convert.ToInt32(tabela_memoria.Rows[0]["id_cf"].ToString());
                Id_forn = Convert.ToInt32(tabela_memoria.Rows[0]["id_forn"].ToString());
                Nome_cf = tabela_memoria.Rows[0]["nome_cf"].ToString();
                Modelo_cf = tabela_memoria.Rows[0]["modelo_cf"].ToString();
                Marca_cf = tabela_memoria.Rows[0]["marca_cf"].ToString();
                Anofab_cf = Convert.ToInt32(tabela_memoria.Rows[0]["anofab_cf"].ToString());
                Cor_cf = tabela_memoria.Rows[0]["cor_cf"].ToString();
                Combustivel_cf = tabela_memoria.Rows[0]["combustivel_cf"].ToString();
                Portas_cf = Convert.ToInt32(tabela_memoria.Rows[0]["portas_cf"].ToString());
                Opcionais_cf = tabela_memoria.Rows[0]["opcionais_cf"].ToString();
                Desc_cf = tabela_memoria.Rows[0]["desc_cf"].ToString();
                Valor_cf = Convert.ToDouble(tabela_memoria.Rows[0]["valor_cf"].ToString());
                Qtd_cf = Convert.ToInt32(tabela_memoria.Rows[0]["qtd_cf"].ToString());
                Nome_forn = tabela_memoria.Rows[0]["nome_forn"].ToString();
                Foto_cf = tabela_memoria.Rows[0]["foto_cf"].ToString();


                if (tabela_memoria.Rows.Count > 1)
                {
                    lista_carf = tabela_memoria;
                }
                else
                {
                    lista_carf = null;
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
            carregar_tabela("delete from carrofornecedor where id_cf=" + id);
        }


        public bool alterar(String nIdForn, String nNome, String nModelo, String nMarca, String nAno, String nCor, String nCombustivel, String nPortas, String nOpcionais, String nDesc, String nValor, String nQtd, String nfoto, String id)
        {
            try
            {
            // Verificar Campos que estao NULLS
            if (nModelo == string.Empty)
                nModelo = "NULL";
            if (nOpcionais == string.Empty)
                nOpcionais = "NULL";
            if (nDesc == string.Empty)
                nDesc = "NULL";

            carregar_tabela("update carrofornecedor set id_forn='" + nIdForn + "', nome_cf='" +  Cripto.cripto(nNome) + "', modelo_cf='" +  Cripto.cripto(nModelo)
                + "', marca_cf='" +  Cripto.cripto(nMarca) + "', anofab_cf='" +  Cripto.cripto(nAno) + "', cor_cf='" +  Cripto.cripto(nCor) + "', combustivel_cf='" +  Cripto.cripto(nCombustivel)
                + "', portas_cf='" + Cripto.cripto(nPortas) + "', opcionais_cf='" + Cripto.cripto(nOpcionais) + "', desc_cf='" + Cripto.cripto(nDesc) + "', valor_cf='" + Cripto.cripto(nValor) + "', qtd_cf='" + Cripto.cripto(nQtd) + "', foto_cf='" + Cripto.cripto(nfoto) + "' where id_cf=" + id + "");
            
                return true;
            }
            catch
            {
                return false;
            }

        }


        public DataTable filtro(String nomec)
        {
            carregar_tabela("select * from carrofornecedor where nome_cf like '" +  Cripto.cripto(nomec) + "%'");
            return tabela_memoria;
        }

        public bool atualizarQtd(String qtdVendida, String idCf, String qtdAtual)
        {
            try
            {
                carregar_tabela("update carrofornecedor set qtd_cf = " +qtdAtual +" - "+ qtdVendida + " where id_cf=" + idCf + "");

                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
