using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _3A1RUAN50
{
    class Conexao
    {
        MySqlConnection conexao = new MySqlConnection("server=localhost; uid=root; pwd=; database=3a1ruan50");
        MySqlCommand comandoSql;
        MySqlDataAdapter da;
        MySqlDataReader dr;
        string strSql;

        public void conexaoComMysql()
        {
            try
            {
                conexao.Open();
            }
            catch (MySqlException e)
            {
                throw new Exception("Não foi possível conectar à base de dados.\n" + e.Message);
            }
        }

        public void inserirProdutos(string nome, string descricao, string quantidade, string valor_unitario, string data_fabricacao, string data_validade)
        {
            conexaoComMysql();

            strSql = "INSERT INTO produtos(nome, descricao, quantidade, valor_unitario, data_fabricado, data_validade) VALUES(@NOME, @DESCRICAO, @QUANTIDADE, @VALOR_UNITARIO, @DATA_FABRICADO, @DATA_VALIDADE)";
            comandoSql = new MySqlCommand(strSql, conexao);
            comandoSql.Parameters.AddWithValue("@NOME", nome);
            comandoSql.Parameters.AddWithValue("@DESCRICAO", descricao);
            comandoSql.Parameters.AddWithValue("@QUANTIDADE", quantidade);
            comandoSql.Parameters.AddWithValue("@VALOR_UNITARIO", valor_unitario);
            comandoSql.Parameters.AddWithValue("@DATA_FABRICADO", data_fabricacao);
            comandoSql.Parameters.AddWithValue("@DATA_VALIDADE", data_validade);

            comandoSql.ExecuteNonQuery();

            conexao.Close();
        }

        public DataTable ListarProdutosDoBanco()
        {
            conexaoComMysql();

            DataTable dataTable = new DataTable();

            strSql = "SELECT * FROM produtos";

            MySqlDataAdapter dados = new MySqlDataAdapter(strSql, conexao);

            dados.Fill(dataTable);
            conexao.Close();

            return dataTable;
        }

    }
}
