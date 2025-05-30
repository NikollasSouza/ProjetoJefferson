using System;
using System.Drawing;
using System.Windows.Forms;

namespace LoginCadastroApp.WinForms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent(); // Chama o método gerado automaticamente

            // Configurações adicionais após o InitializeComponent()
            this.Text = "Loja Esportiva";
            this.Size = new System.Drawing.Size(400, 300);

            // Cria e configura os botões
            Button btnLogin = new Button() { Text = "Fazer Login", Location = new Point(100, 30), Width = 200 };
            Button btnCadastro = new Button() { Text = "Cadastrar Usuário", Location = new Point(100, 80), Width = 200 };
            Button btnProdutos = new Button() { Text = "Ver Produtos", Location = new Point(100, 130), Width = 200 };
            Button btnSair = new Button() { Text = "Sair", Location = new Point(100, 180), Width = 200 };

            // Adiciona eventos aos botões
            btnLogin.Click += (s, e) => new LoginForm().ShowDialog();
            btnCadastro.Click += (s, e) => new CadastroForm().ShowDialog();
            btnProdutos.Click += (s, e) => new ProdutosForm().ShowDialog();
            btnSair.Click += (s, e) => Application.Exit();

            // Adiciona os botões ao formulário
            this.Controls.Add(btnLogin);
            this.Controls.Add(btnCadastro);
            this.Controls.Add(btnProdutos);
            this.Controls.Add(btnSair);
        }
    }
}