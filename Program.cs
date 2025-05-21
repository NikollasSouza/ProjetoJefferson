using System;
using MySql.Data.MySqlClient;

namespace LoginCadastroApp
{
    class Program
    {
        // Substitua pela sua string de conexão
        static string connectionString = "server=localhost;database=login_db;uid=root;password=root;";

        static void Main(string[] args)
        {
            bool sair = false;

            while (!sair)
            {
                Console.Clear();
                Console.WriteLine("=== MENU PRINCIPAL ===");
                Console.WriteLine("[1] Fazer Login");
                Console.WriteLine("[2] Cadastrar Usuário");
                Console.WriteLine("[3] Ver Produtos");
                Console.WriteLine("[4] Sair");
                Console.Write("Escolha uma opção: ");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        FazerLogin();
                        break;
                    case "2":
                        CadastrarUsuario();
                        break;
                    case "3":
                        VerProdutos();
                        break;
                    case "4":
                        sair = true;
                        Console.WriteLine("\nSaindo...");
                        break;
                    default:
                        Console.WriteLine("\nOpção inválida!");
                        break;
                }

                if (!sair)
                {
                    Console.WriteLine("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }

        // MÉTODO DE LOGIN
        static void FazerLogin()
        {
            Console.Clear();
            Console.WriteLine("=== FAZER LOGIN ===\n");

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("Senha: ");
            string senha = Console.ReadLine();

            string query = "SELECT COUNT(*) FROM usuarios WHERE email = @email AND senha = @senha";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        conn.Open();

                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@senha", senha);

                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        if (count > 0)
                        {
                            Console.WriteLine("\n✅ Login realizado com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("\n❌ Email ou senha incorretos.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n⚠️ Erro ao conectar ao banco: " + ex.Message);
            }
        }

        // MÉTODO DE CADASTRO
        static void CadastrarUsuario()
        {
            Console.Clear();
            Console.WriteLine("=== CADASTRAR USUÁRIO ===\n");

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("Senha: ");
            string senha = Console.ReadLine();

            string query = "INSERT INTO usuarios (email, senha) VALUES (@email, @senha)";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        conn.Open();

                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@senha", senha);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("\n✅ Cadastro realizado com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("\n❌ Erro ao cadastrar.");
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("Duplicate entry"))
                {
                    Console.WriteLine("\n❌ Esse email já está cadastrado.");
                }
                else
                {
                    Console.WriteLine("\n⚠️ Erro ao conectar ao banco: " + ex.Message);
                }
            }
        }

        // Método para visualizar os produtos da loja
        static void VerProdutos()
        {
            Console.Clear();
            Console.WriteLine("=== Produtos em nossa loja ===\n");

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Query para selecionar todos os produtos
                    string query = "SELECT id, nome, descricao, valor, categoria, estoque, peso, largura, altura, profundidade FROM Produtos";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Exibe os cabeçalhos das colunas
                            Console.WriteLine("{0,-5} | {1,-32} | {2,-11} | {3,-10} | {4,-10} | {5,-10} | {6,-10} | {7,-10} | {8,-8} | {9,-12}",
                                "ID", "Nome", "Valor", "Categoria", "Estoque", "Peso", "Largura", "Altura", "Profundidade", "Descrição");

                            Console.WriteLine(new string('-', 150)); // Linha separadora

                            // Lê cada linha do resultado
                            while (reader.Read())
                            {
                                Console.WriteLine("{0,-5} | {1,-30} | {2,-11:C} | {3,-10} | {4,-10} | {5,-10} | {6,-10} | {7,-10} | {8,-12} | {9,-12}",
                                    reader["id"],
                                    reader["nome"],
                                    Convert.ToDecimal(reader["valor"]),
                                    reader["categoria"],
                                    reader["estoque"],
                                    reader["peso"],
                                    reader["largura"],
                                    reader["altura"],
                                    reader["profundidade"],
                                    reader["descricao"]);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao listar produtos: {ex.Message}");
            }
        }
    }
}