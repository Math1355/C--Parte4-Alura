using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                CarregarContas();
            }
            catch (Exception)
            {
                Console.WriteLine("Cath no metodo main");
            }
            
            Console.ReadLine();
        }

        private static void CarregarContas()
        {
            using(LeitorDeArquivo leitor = new LeitorDeArquivo("teste.txt"))
            {
                leitor.LerProximaLinha();
            }

            // ---------------------------------------------

            //LeitorDeArquivo leitor = null;

            //try
            //{
            //    leitor = new LeitorDeArquivo("contasl.txt");

            //    leitor.LerProximaLinha();
            //    leitor.LerProximaLinha();
            //    leitor.LerProximaLinha();
            //}
            //finally
            //{
            //    Console.WriteLine("Exceutando o finally");
            //    if(leitor != null)
            //    {
            //        leitor.Fechar();
            //    }
            //}
        }

        private static void TestaInnerException()
        {
            try
            {
                ContaCorrente conta1 = new ContaCorrente(4564, 789684);
                ContaCorrente conta2 = new ContaCorrente(7891, 456794);

                //conta1.Transferir(100000, conta2);
                conta1.Sacar(10000);
            }
            catch (OperacaoFinanceiraException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);

                Console.WriteLine("Informações da Inner Exception (Exceção interna):");

                Console.WriteLine(e.InnerException.Message);
                Console.WriteLine(e.InnerException.StackTrace);
            }
            //try
            //{
            //    ContaCorrente conta = new ContaCorrente(456, 4578420);
            //    ContaCorrente conta2 = new ContaCorrente(485, 456478);

            //    conta2.Transferir(10000, conta);

            //    conta.Depositar(50);
            //    Console.WriteLine(conta.Saldo);
            //    conta.Sacar(-500);
            //}
            //catch (ArgumentException ex)
            //{
            //    if(ex.ParamName == "numero")
            //    {

            //    }

            //    Console.WriteLine("Argumento com problema: " + ex.ParamName);
            //    Console.WriteLine("Ocorreu uma exceção  do tipo ArgumentException");
            //    Console.WriteLine(ex.Message);
            //}
            //catch (SaldoInsuficienteException ex)
            //{
            //    Console.WriteLine(ex.Saldo);
            //    Console.WriteLine(ex.ValorSaque);

            //    Console.WriteLine(ex.StackTrace);

            //    Console.WriteLine(ex.Message);
            //    Console.WriteLine("Exceção do tipo SaldoInsuficienteException");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            //Metodo();
        }

        //Teste com a cadeia de chamada:
        //Metodo -> TestaDivisao -> Dividir

        private static void Metodo()
        {
            TestaDivisao(0);
        }

        private static void TestaDivisao(int divisor)
        {
            int resultado = Dividir(10, divisor);
            Console.WriteLine("Resultado da divisão de 10 por " + divisor + " é " + resultado);
        }

        private static int Dividir(int numero, int divisor)
        {
            try
            {
                return numero / divisor;
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Exceção com numero= " + numero + " e divisor= " + divisor);
                throw;
            }
        }
    }
}
