using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3A1RUAN50
{
    public partial class Form1 : Form
    {
        Conexao conexao = new Conexao();
        public Form1()
        {
            InitializeComponent();
        }

        private void inserirButton_Click(object sender, EventArgs e)
        {
            string nome = inputNomeProduto.Text;
            string descricao = inputDescricaoProduto.Text;
            string quantidade = inputQuantidadeProduto.Text;
            string valor_unitario = inputValorUnitario.Text;
            string data_fabricado = inputDataFabricacao.Text;
            string data_validade = inputDataValidade.Text;
            conexao.inserirProdutos(nome, descricao, quantidade, valor_unitario, data_fabricado, data_validade);
            MessageBox.Show("Produto registrado!");
        }

        private void listarButton_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = conexao.ListarProdutosDoBanco();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 Check = new Form2();
            Check.Show();
            Hide();
        }
    }
}
