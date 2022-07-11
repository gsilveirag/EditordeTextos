using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditordeTexto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu();
            Console.ReadLine();
            
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("------------------------");
            Console.WriteLine("O que voce deseja fazer?");
            Console.WriteLine("0 - Sair");
            Console.WriteLine("1 - Abrir Arquivo");
            Console.WriteLine("2 - Criar novo arquivo");
            Console.WriteLine("------------------------");

            byte opcao = byte.Parse(Console.ReadLine());

            switch(opcao)
            {
                case 0: System.Environment.Exit(0);break;
                case 1: Abrir();break;
                case 2: Editar();break;
                default: Menu(); break;

            }

        }

        static void Abrir()
        {
            Console.Clear();
            Console.WriteLine("Qual caminho para abir o arquivo?");
            var caminho = Console.ReadLine();

            using (var arquivo = new StreamReader(caminho))
            {
                Console.Clear();
                string texto = arquivo.ReadToEnd();
                Console.WriteLine(texto);
            }

            Console.WriteLine("");
            Console.ReadLine();
            Menu();
        }

        static void Editar()
        {
            Console.Clear();
            Console.WriteLine("Digite seu texto abaixo: ( ESC para sair. )");
            Console.WriteLine("-------------------------------------------");
            string texto = "";

            do
            {
                texto += Console.ReadLine();
                texto += Environment.NewLine;
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);
           
            Salvar(texto);
        }

        static void Salvar(string texto)
        {
            Console.Clear();
            Console.WriteLine("Qual caminho para salvar o arquivo?");
            var caminho = Console.ReadLine();

            using (var arquivo = new StreamWriter(caminho))
            {
                arquivo.Write(texto);
            }

            Console.WriteLine("Arquivo salvo com Sucesso! Caminho: " + caminho);
            Console.ReadLine();
            Menu();
        }
    }
}
