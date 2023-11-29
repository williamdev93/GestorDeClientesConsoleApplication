using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}