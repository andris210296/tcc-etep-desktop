using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace TCC
{
    class acessoCarroCliente
    {
        int id_cc, id_cli, anofab_cc, portas_cc, parc_cc, qtd;
        String marca_cc, nome_cc, modelo_cc, cor_cc, combustivel_cc, finalplaca_cc, opcionais_cc, desc_cc, foto_cc;

        public String Foto_cc
        {
            get { return foto_cc; }
            set { foto_cc = value; }
        }
        double km_cc, valor_cc, valorent_cc, valorfin_cc;

        // variavel para FK
        String nome_cli;

        public String Nome_cli
        {
            get { return nome_cli; }
            set { nome_cli = value; }
        }

        #region Variaveis Encapsuladas
        public int Qtd
        {
            get { return qtd; }
            set { qtd = value; }
        }
        public double Valorfin_cc
        {
            get { return valorfin_cc; }
            set { valorfin_cc = value; }
        }

        public double Valorent_cc
        {
            get { return valorent_cc; }
            set { valorent_cc = value; }
        }

        public double Valor_cc
        {
            get { return valor_cc; }
            set { valor_cc = value; }
        }

        public double Km_cc
        {
            get { return km_cc; }
            set { km_cc = value; }
        }

        public String Desc_cc
        {
            get { return desc_cc; }
            set { desc_cc = value; }
        }

        public String Opcionais_cc
        {
            get { return opcionais_cc; }
            set { opcionais_cc = value; }
        }

        public String Finalplaca_cc
        {
            get { return finalplaca_cc; }
            set { finalplaca_cc = value; }
        }

        public String Combustivel_cc
        {
            get { return combustivel_cc; }
            set { combustivel_cc = value; }
        }

        public String Cor_cc
        {
            get { return cor_cc; }
            set { cor_cc = value; }
        }

        public String Modelo_cc
        {
            get { return modelo_cc; }
            set { modelo_cc = value; }
        }

        public String Nome_cc
        {
            get { return nome_cc; }
            set { nome_cc = value; }
        }

        public String Marca_cc
        {
            get { return marca_cc; }
            set { marca_cc = value; }
        }
        public int Parc_cc
        {
            get { return parc_cc; }
            set { parc_cc = value; }
        }

        public int Portas_cc
        {
            get { return portas_cc; }
            set { portas_cc = value; }
        }

        public int Anofab_cc
        {
            get { return anofab_cc; }
            set { anofab_cc = value; }
        }

        public int Id_cli
        {
            get { return id_cli; }
            set { id_cli = value; }
        }

        public int Id_cc
        {
            get { return id_cc; }
            set { id_cc = value; }
        }
        #endregion

        MySqlDataAdapter comando_sql;
        MySqlCommandBuilder executar_comando;
        DataTable tabela_memoria;
        private DataTable lista_carc;

        public DataTable Lista_carc
        {
            get { return lista_carc; }
            set { lista_carc = value; }
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

        public bool inserir(String id_cli, String nome, String modelo, String marca, String ano, String cor, String combustivel, String portas, String km, String final_placa, String opcionais, String descricao, String valor,String foto)
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


                carregar_tabela("insert into carrocliente values(0," + id_cli + " ,'" + Cripto.cripto(nome) + "','" + Cripto.cripto(modelo) + 
                    "','" + Cripto.cripto(marca) + "','" + Cripto.cripto(ano) + "','" + Cripto.cripto(cor) + "','" + Cripto.cripto(combustivel) + "','" + Cripto.cripto(portas) + "','"
                    + Cripto.cripto(km) + "','" + Cripto.cripto(final_placa) + "','" + Cripto.cripto(opcionais) + "','" + Cripto.cripto(descricao) + "','"
                    + Cripto.cripto(valor.Replace(',', '.')) + "','" + Cripto.cripto(foto) + "')");

                return true;
            }
            catch
            {
                return false;
            }
        }

        public DataTable listar_td()
        {
            carregar_tabela("select * from carrocliente");

            return tabela_memoria;
        }


        public bool pesquisarCarroCliente(String nome)
        {
            carregar_tabela("select * from carrocliente cc inner join cliente c on cc.id_cli = c.id_cli where cc.nome_cc='" + nome + "'");

            try
            {
                Id_cc = Convert.ToInt32(tabela_memoria.Rows[0]["id_cc"].ToString());
                Id_cli = Convert.ToInt32(tabela_memoria.Rows[0]["id_cli"].ToString());
                Nome_cc = tabela_memoria.Rows[0]["nome_cc"].ToString();
                Modelo_cc = tabela_memoria.Rows[0]["modelo_cc"].ToString();
                Marca_cc = tabela_memoria.Rows[0]["marca_cc"].ToString();
                Anofab_cc = Convert.ToInt32(tabela_memoria.Rows[0]["anofab_cc"].ToString());
                Cor_cc = tabela_memoria.Rows[0]["cor_cc"].ToString();
                Combustivel_cc = tabela_memoria.Rows[0]["combustivel_cc"].ToString();
                Portas_cc = Convert.ToInt32(tabela_memoria.Rows[0]["portas_cc"].ToString());
                Km_cc = Convert.ToDouble(tabela_memoria.Rows[0]["km_cc"].ToString());
                Finalplaca_cc = tabela_memoria.Rows[0]["finalplaca_cc"].ToString();
                Opcionais_cc = tabela_memoria.Rows[0]["opcionais_cc"].ToString();
                Desc_cc = tabela_memoria.Rows[0]["desc_cc"].ToString();
                Valor_cc = Convert.ToDouble(tabela_memoria.Rows[0]["valor_cc"].ToString());
                Foto_cc = tabela_memoria.Rows[0]["foto_cc"].ToString();


                if (tabela_memoria.Rows.Count > 1)
                {
                    lista_carc = tabela_memoria;
                }
                else
                {
                    lista_carc = null;
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
            carregar_tabela("delete from carrocliente where id_cc=" + id);
        }

        public bool alterar(String nIdCli, String nNome, String nModelo, String nMarca, String nAno, String nCor, String nCombustivel, String nPortas, String nKm, String nFinal_placa, String nOpcionais, String nDesc, String nValor,String nfoto, String id)
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

                carregar_tabela("update carrocliente set id_cli =" + nIdCli + ", nome_cc='" + Cripto.cripto(nNome) + "', modelo_cc='" + Cripto.cripto(nModelo)
                    + "', marca_cc='" + Cripto.cripto(nMarca) + "', anofab_cc='" + Cripto.cripto(nAno) + "', cor_cc='" + Cripto.cripto(nCor) + "', combustivel_cc='" + Cripto.cripto(nCombustivel)
                    + "', portas_cc='" + Cripto.cripto(nPortas) + "', km_cc='" + Cripto.cripto(nKm) + "', finalplaca_cc='" + Cripto.cripto(nFinal_placa) + "', opcionais_cc='" + Cripto.cripto(nOpcionais)
                    + "', desc_cc='" + Cripto.cripto(nDesc) + "', valor_cc='" + Cripto.cripto(nValor) + "', foto_cc='" + Cripto.cripto(nfoto) + "' where id_cc=" + id + "");

                return true;
            }
            catch
            {
                return false;
            }
        }

        public DataTable filtro(String nomec)
        {
            carregar_tabela("select * from carrocliente where nome_cc like '" + Cripto.cripto(nomec) + "%'");
            return tabela_memoria;
        }

        public bool atualizarQtd(String idCc)
        {
            try
            {
                carregar_tabela("update carrocliente set qtd = qtd - 1 where id_cc=" + idCc + "");

                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
