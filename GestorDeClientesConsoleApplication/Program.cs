using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeClientesConsoleApplication
{
    internal class Program
    {
        [Serializable]
        struct Cliente
        {
            public string nome;
            public string email;
            public string cpf;
        }

        static List<Cliente> clientes = new List<Cliente>();

        enum Menu { Listagem = 1, Adicionar, Remover, Sair }
        static void Main(string[] args)
        {
            Carregar();
            bool escolheuSair = false;
            while (!escolheuSair)
            {
                Console.WriteLine("Sistema de Clientes - Bem vindo!");
                Console.WriteLine("1-Listar\n2-Adicionar\n3-Remover\n4-Sair");
                int intOp = int.Parse(Console.ReadLine());
                Menu opcao = (Menu)intOp;

                switch (opcao)
                {
                    case Menu.Listagem:
                        Listagem();
                        break;
                    case Menu.Adicionar:
                        Adicionar();
                        break;
                    case Menu.Remover:
                        Remover();
                        break;
                    case Menu.Sair:
                        escolheuSair = true;
                        break;
                    default:
                        break;
                }
                //Limpando o console
                Console.Clear();
            }
        }

        static void Adicionar()
        {
            Cliente cliente = new Cliente();
            Console.WriteLine("Cadastro de Cliente: ");
            Console.WriteLine("Nome do cliente: ");
            cliente.nome = Console.ReadLine();
            Console.WriteLine("Email do cliente: ");
            cliente.email = Console.ReadLine();
            Console.WriteLine("CPF do Cliente: ");
            cliente.cpf = Console.ReadLine();

            clientes.Add(cliente);
            //Salva automaticamente os elementos na lista
            Salvar();
            Console.WriteLine("Cadastro concluído, aperte ENTER para sair.");
            Console.ReadLine();
        }

        static void Listagem()
        {

            if (clientes.Count > 0) // SE tem pelo menos um cliente cadastrado, exibirá a lógica abaixo
            {
                Console.WriteLine("Lista de Clientes: ");
                int i = 0;
                foreach (var cliente in clientes)
                {
                    Console.WriteLine($"ID: {i}");
                    Console.WriteLine($"Nome: {cliente.nome}");
                    Console.WriteLine($"E-mail: {cliente.email}");
                    Console.WriteLine($"CPF: {cliente.cpf}");
                    i++;
                    Console.WriteLine("=================================");
                }
            }
            else
            {
                Console.WriteLine("Nenhum cliente cadastrado!");
            }
            Console.WriteLine("Aperte ENTER para sair.");
            Console.ReadLine();
        }

        static void Remover()
        {
            Listagem();
            Console.WriteLine("Digite o ID do cliente que você quer remover:");
            int id = int.Parse(Console.ReadLine());
            if (id >= 0 && id < clientes.Count)
            {
                clientes.RemoveAt(id);
                Salvar();
            }
            else
            {
                Console.WriteLine("Id digitado inválido, tente novamente!");
                Console.ReadLine();
            }
        }

        static void Salvar()
        {
            //Tenta abrir o arquivo, se o arquivo não existir ele cria um novo
            FileStream stream = new FileStream("clientes.dat", FileMode.OpenOrCreate);
            //Salvando os dados em formato binário no arquivo
            BinaryFormatter encoder = new BinaryFormatter();

            //Passando a variavel que eu quero salvar dentro do arquivo
            encoder.Serialize(stream, clientes);

            //Fechando a stream
            stream.Close();
        }

        static void Carregar()
        {
            FileStream stream = new FileStream("clientes.dat", FileMode.OpenOrCreate);

            try
            {
                BinaryFormatter encoder = new BinaryFormatter();

                clientes = (List<Cliente>)encoder.Deserialize(stream);

                if (clientes == null)
                {
                    clientes = new List<Cliente>();
                }

            }
            catch (Exception e)
            {
                clientes = new List<Cliente>();
            }
            stream.Close();
        }
    }
}