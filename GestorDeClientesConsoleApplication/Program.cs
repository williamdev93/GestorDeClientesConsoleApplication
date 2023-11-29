﻿using System;
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
                        break;
                    case Menu.Adicionar:
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
    }
}