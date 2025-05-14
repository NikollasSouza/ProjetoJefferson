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
                Console.WriteLine("[3] Deletar Usuário");
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
                        DeletarUsuario();
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

        // MÉTODO PARA DELETAR USUÁRIO
        static void DeletarUsuario()
        {
            Console.Clear();
            Console.WriteLine("=== DELETAR USUÁRIO ===\n");

            Console.Write("Digite o email do usuário que deseja deletar: ");
            string email = Console.ReadLine();

            string queryCheck = "SELECT COUNT(*) FROM usuarios WHERE email = @email";
            string queryDelete = "DELETE FROM usuarios WHERE email = @email";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Verifica se o usuário existe
                    using (MySqlCommand cmdCheck = new MySqlCommand(queryCheck, conn))
                    {
                        cmdCheck.Parameters.AddWithValue("@email", email);
                        int count = Convert.ToInt32(cmdCheck.ExecuteScalar());

                        if (count == 0)
                        {
                            Console.WriteLine("\n❌ Nenhum usuário encontrado com esse email.");
                            return;
                        }
                    }

                    // Confirmação antes de deletar
                    Console.Write("Tem certeza que deseja deletar este usuário? (s/n): ");
                    string confirmacao = Console.ReadLine();

                    if (confirmacao.ToLower() != "s")
                    {
                        Console.WriteLine("\n❌ Operação cancelada.");
                        return;
                    }

                    // Deleta o usuário
                    using (MySqlCommand cmdDelete = new MySqlCommand(queryDelete, conn))
                    {
                        cmdDelete.Parameters.AddWithValue("@email", email);

                        int rowsAffected = cmdDelete.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("\n✅ Usuário deletado com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("\n❌ Erro ao deletar usuário.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n⚠️ Erro ao conectar ao banco: " + ex.Message);
            }
        }
    }
}