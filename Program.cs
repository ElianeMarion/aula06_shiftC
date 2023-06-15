namespace Aula06
{
	internal class Program
	{
		public static List<string> listaDeProdutos = new List<string>();
		public static string emailDoUsuario, senhaDoUsuario;
		Dictionary<string, List<int>> produtosRegistrados = new Dictionary<string, List<int>>();
		

		static void ExibirLogo()
		{
			Console.Clear();
			Console.WriteLine(@"
███████╗██╗░█████╗░██████╗░  ██████╗░░█████╗░███╗░░██╗░█████╗░████████╗██╗░█████╗░███╗░░██╗
██╔════╝██║██╔══██╗██╔══██╗  ██╔══██╗██╔══██╗████╗░██║██╔══██╗╚══██╔══╝██║██╔══██╗████╗░██║
█████╗░░██║███████║██████╔╝  ██║░░██║██║░░██║██╔██╗██║███████║░░░██║░░░██║██║░░██║██╔██╗██║
██╔══╝░░██║██╔══██║██╔═══╝░  ██║░░██║██║░░██║██║╚████║██╔══██║░░░██║░░░██║██║░░██║██║╚████║
██║░░░░░██║██║░░██║██║░░░░░  ██████╔╝╚█████╔╝██║░╚███║██║░░██║░░░██║░░░██║╚█████╔╝██║░╚███║
╚═╝░░░░░╚═╝╚═╝░░╚═╝╚═╝░░░░░  ╚═════╝░░╚════╝░╚═╝░░╚══╝╚═╝░░╚═╝░░░╚═╝░░░╚═╝░╚════╝░╚═╝░░╚══╝

░██████╗██╗░░░██╗░██████╗████████╗███████╗███╗░░░███╗
██╔════╝╚██╗░██╔╝██╔════╝╚══██╔══╝██╔════╝████╗░████║
╚█████╗░░╚████╔╝░╚█████╗░░░░██║░░░█████╗░░██╔████╔██║
░╚═══██╗░░╚██╔╝░░░╚═══██╗░░░██║░░░██╔══╝░░██║╚██╔╝██║
██████╔╝░░░██║░░░██████╔╝░░░██║░░░███████╗██║░╚═╝░██║
╚═════╝░░░░╚═╝░░░╚═════╝░░░░╚═╝░░░╚══════╝╚═╝░░░░░╚═╝");
		}

		static void SubMenu()
		{
			Console.Clear();
			Console.WriteLine("Usuário logado com sucesso!! Bem vinda(o) ");
			Console.WriteLine("\nDigite 1 para registrar um produto");
			Console.WriteLine("Digite 2 para mostrar os produtos");
			Console.WriteLine("Digite 3 para avaliar um produto");
			Console.WriteLine("Digite 4 para exibir a média de um produto");
			Console.WriteLine("Digite 0 para voltar para o menu principal");
		}
		static void RegistrarUsuario()
		{
			ExibirTituloOpcao("Registro de usuário");
			
			Console.Write("Digite o nome do usuário que deseja registrar: ");
			string nomeDoUsuario = Console.ReadLine()!;
			Console.Write("Digite o telefone do usuário: ");
			string telefoneDoUsuario = Console.ReadLine()!;
			Console.Write("Digite o e-mail do usuário: ");
			emailDoUsuario = Console.ReadLine()!;
			Console.Write("Digite a senha do usuário: ");
			senhaDoUsuario = Console.ReadLine()!;
			Console.Write("Digite o apelido do usuário: ");
			string apelidoDoUsuario = Console.ReadLine()!;
			

			Console.WriteLine($"\n\nO usuário {nomeDoUsuario} foi registrado com sucesso!");
		}
		static void RegistrarProduto()
		{
			Console.Clear();
			ExibirTituloOpcao("Registro de Produto");
			Console.Write("Digite o nome do produto que deseja registrar: ");
			string nomeDoProduto = Console.ReadLine()!;
			listaDeProdutos.Add(nomeDoProduto);
			Console.WriteLine($"\n\nO produto {nomeDoProduto} foi registrado com sucesso!");
		}

		static string MostrarProdutos()
		{
			Console.Clear();
			ExibirTituloOpcao("Exibindo todos os produtos registrados");
			string mensagem = "";
			foreach(string prod in listaDeProdutos)
			{
				Console.WriteLine($"Produto: {prod}");
				mensagem += "Produto:" + prod + "\n";
			}
			return	mensagem;

		}
		//PadLeft() => Insere caracteres à esquerda, pede 2 argumentos(qtdCaracteres, caractere/texto)
		static void ExibirTituloOpcao(string titulo)
		{
			int quantidadeDeLetras = titulo.Length;
			string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
			Console.WriteLine(asteriscos);
			Console.WriteLine(titulo);
			Console.WriteLine(asteriscos + "\n");
		}

		static void ExibirMenu()
		{
			Console.WriteLine("Boas vindas ao FIAP Donation System!");
			Thread.Sleep(2000);

			Console.WriteLine("Digite 1 para registrar um novo usuário");
			Console.WriteLine("Digite 2 para se logar");
			Console.WriteLine("Digite 3 para finalizar o sistema");
		}
		static bool ValidarLogin(string email, string senha)
		{
			if (email.Equals(emailDoUsuario) && senha.Equals(senhaDoUsuario))
				return true;
			else
				return false;
		}
		static void Main(string[] args)
		{
			int opcao;
			do
			{
				ExibirLogo();
				ExibirMenu();
				opcao = Convert.ToInt16(Console.ReadLine());

				switch (opcao)
				{

					case 1: //else if (opcao == 1)
						RegistrarUsuario();
						
						break;
					case 2://else
						Console.WriteLine("Digite o email cadastrado");
						string email = Console.ReadLine()!;
						Console.WriteLine("Digite sua senha");
						string senha = Console.ReadLine()!;
						if (email.Equals(emailDoUsuario) && senha.Equals(senhaDoUsuario))
						{
							int opcaoSubMenu = 0;
							do
							{
								SubMenu();
								opcaoSubMenu = Convert.ToInt16(Console.ReadLine());
								switch (opcaoSubMenu)
								{
									case 1:
										RegistrarProduto();
										break;
									case 2:
										Console.WriteLine(MostrarProdutos());
										//ou string texto = MostrarProdutos(); Console.WriteLine(texto);
										break;
									case 3:
										Console.WriteLine("Avaliar produto");
										break;
									case 4:
										Console.WriteLine();
										break;
								}
							} while (opcaoSubMenu != 0);

						}
						else
							Console.WriteLine("Usuário ou senha inválidos ");
						break;
					case 3: //if (opcao == 0)
						Console.WriteLine("Obrigada por usar nosso sistema!!");
						break;
					default:
						Console.WriteLine("Opção inválida");
						break;

				}
				Thread.Sleep(3000);
			} while (opcao != 3);

			Console.Clear();
		}
	}
}