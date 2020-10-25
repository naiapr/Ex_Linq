using System;
using System.Collections.Generic;
using Ex_Linq.Entities;
using System.IO;
using System.Globalization;
using System.Linq;

namespace Ex_Linq
{
    class Program

    {
        
        static void Main(string[] args)
        {
            Console.Write("Entre com o caminho: ");
            string caminho = Console.ReadLine();

            List<Funcionario> list = new List<Funcionario>();

            using (StreamReader sr = File.OpenText(caminho))
            {
                while (!sr.EndOfStream)
                {
                    string[] campos = sr.ReadLine().Split(',');
                    string nome = campos[0];
                    string email = campos[1];
                    double salario = double.Parse(campos[2], CultureInfo.InvariantCulture);
                    list.Add(new Funcionario(nome, email, salario));
                }
            }
            Console.Write("Digite o salário: ");
            double sal = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            var p1 = list
                .Where(f => f.Salario > sal)
                .OrderBy(f => f.Email);
            foreach (var item in p1)
            {
                Console.WriteLine(item.Email);
            }
           

            var p2 = list
                .Where(f => f.Nome[0] == 'M')
                .Sum(f => f.Salario);
            Console.WriteLine("Soma dos salários dos funcionarios que iniciam o nome com 'M': "
                +p2.ToString("F2", CultureInfo.InvariantCulture));
            


        }
    }
}
