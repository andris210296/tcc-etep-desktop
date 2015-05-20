using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace TCC
{
    class acessoVenda
    {
        int id_venda, id_cli, id_cf, id_cc, id_fun, parcelas;
        double total, valor_ent, valor_fin;
        string id_pag;
        DateTime data;

        #region variaveis
        public DataTable Lista_carc
        {
            get { return lista_carc; }
            set { lista_carc = value; }
        }
        public DataTable Lista_carf
        {
            get { return lista_carf; }
            set { lista_carf = value; }
        }

        public DateTime Data
        {
            get { return data; }
            set { data = value; }
        }

        public double Valor_fin
        {
            get { return valor_fin; }
            set { valor_fin = value; }
        }

        public double Valor_ent
        {
            get { return valor_ent; }
            set { valor_ent = value; }
        }

        public double Total
        {
            get { return total; }
            set { total = value; }
        }
        public int Parcelas
        {
            get { return parcelas; }
            set { parcelas = value; }
        }

        public string Id_pag
        {
            get { return id_pag; }
            set { id_pag = value; }
        }

        public int Id_fun
        {
            get { return id_fun; }
            set { id_fun = value; }
        }

        public int Id_cc
        {
            get { return id_cc; }
            set { id_cc = value; }
        }

        public int Id_cf
        {
            get { return id_cf; }
            set { id_cf = value; }
        }
        public int Id_cli
        {
            get { return id_cli; }
            set { id_cli = value; }
        }
        public int Id_venda
        {
            get { return id_venda; }
            set { id_venda = value; }
        }
        #endregion

        MySqlDataAdapter comando_sql;
        MySqlCommandBuilder executar_comando;
        DataTable tabela_memoria;
        private DataTable lista_carc;
        private DataTable lista_carf;

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

        public bool inserirCF(String idCli, String idCf, String idCc, String idFun, String idPag, String Qtd, String total, String dataComp, String valorEnt, String valorFin, String parcelas)
        {
            try
            {
                Data = Convert.ToDateTime(dataComp);
                String dataCorreta = Data.ToString("yyyy/MM/dd");

                // Verificar Campos que estao NULLS
                if (idCf == string.Empty)
                    idCf = "NULL";
                if (idCc == string.Empty)
                    idCc = "NULL";

                carregar_tabela("insert into venda values(0, " + idCli + ", " + idCf + ", " + idCc + ", " + idFun + ", " + idPag + ", '" + Cripto.cripto(Qtd) + "', '" + Cripto.cripto(total.Replace(',', '.')) + "', '" + Cripto.cripto(dataCorreta) + "', '" + Cripto.cripto(valorEnt.Replace(',', '.')) + "', '" + Cripto.cripto(valorFin.Replace(',', '.')) + "', '" + Cripto.cripto(parcelas) + "')");
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool inserirCC(String idCli, String idCf, String idCc, String idFun, String fp, String Qtd, String total, String dataComp, String valorEnt, String valorFin, String parcelas)
        {
            try
            {
                Data = Convert.ToDateTime(dataComp);
                String dataCorreta = Data.ToString("yyyy/MM/dd");

                // Verificar Campos que estao NULLS
                if (idCf == string.Empty)
                    idCf = "NULL";
                if (idCc == string.Empty)
                    idCc = "NULL";

                carregar_tabela("insert into venda values(0, " + idCli + ", " + idCf + ", " + idCc + ", " + idFun + ", '" + Cripto.cripto(fp) + "', NULL, '" + Cripto.cripto(total.Replace(',', '.')) + "', '" + Cripto.cripto(dataCorreta) + "', '" + Cripto.cripto(valorEnt.Replace(',', '.')) + "', '" + Cripto.cripto(valorFin.Replace(',', '.')) + "', '" + Cripto.cripto(parcelas) + "')");
                return true;
            }
            catch
            {
                return false;
            }
        }

        public DataTable listar_td()
        {
            carregar_tabela("select * from venda");
            return tabela_memoria;
        }
    }
}
