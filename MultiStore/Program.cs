using MultiStore.Data;
using System;

namespace MultiStore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***************************************");
            Console.WriteLine("*                                     *");
            Console.WriteLine("*         Bem-vindo à MultiStore      *");
            Console.WriteLine("*                                     *");
            Console.WriteLine("***************************************");
            Console.WriteLine();

            Console.WriteLine("Digite o caminho completo do arquivo Excel:");
            string filePath = Console.ReadLine();

            if (!File.Exists(filePath))
            {
                Console.WriteLine("O arquivo não foi encontrado. Certifique-se de inserir o caminho correto.");
                return;
            }

            // Inicializa o processo de leitura do Excel
            var excelReader = new ExcelReader();
            var multiStoreData = excelReader.ReadExcel(filePath);

            Console.WriteLine("Dados do Excel lidos com sucesso e processados!");

            Console.WriteLine("Pressione qualquer tecla para sair...");
            Console.ReadKey();
        }
    }
}
