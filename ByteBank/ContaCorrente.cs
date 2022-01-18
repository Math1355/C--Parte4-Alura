// using _05_ByteBank;

namespace ByteBank
{
    public class ContaCorrente
    {
        public static double TaxaOperacao { get; private set; }

        public Cliente Titular { get; set; }

        public int ContadorSaquesNãoPermitidos { get; private set; }
        public int ContadorTransferenciasNaoPermitidas { get; private set; }

        public static int TotalDeContasCriadas { get; private set; }


        public int Agencia{ get; }

        public int Numero { get; }

        private double _saldo = 100;

        public double Saldo
        {
            get
            {
                return _saldo;
            }
            set
            {
                if (value < 0)
                {
                    return;
                }

                _saldo = value;
            }
        }


        public ContaCorrente(int agencia, int conta)
        {
            if (agencia <= 0)
            {
                throw new System.ArgumentException("O argumento agencia deve ser maior que 0.", nameof(agencia));
            }

            if (conta <= 0)
            {
                throw new System.ArgumentException("O argumento numero deve ser maior que 0.", nameof(conta));
            }

            Agencia = agencia;
            Numero = conta;

            TotalDeContasCriadas++;
            TaxaOperacao = 30 / TotalDeContasCriadas;
        }


        public void Sacar(double valor)
        {
            if (valor < 0)
            {
                throw new System.ArgumentException("Valor inválido para o saque.", nameof(valor));
            }

            if (_saldo < valor)
            {
                ContadorSaquesNãoPermitidos++;
                throw new SaldoInsuficienteException(Saldo, valor);
            }

            _saldo -= valor;
        }

        public void Depositar(double valor)
        {
            _saldo += valor;
        }


        public void Transferir(double valor, ContaCorrente contaDestino)
        {
            if (valor < 0)
            {
                throw new System.ArgumentException("Valor inválido para a tranferencia.", nameof(valor));
            }

            try
            {
                Sacar(valor);
            }
            catch (SaldoInsuficienteException ex)
            {
                ContadorTransferenciasNaoPermitidas++;
                throw new OperacaoFinanceiraException("Operação não realizda.", ex);
            }
            
            contaDestino.Depositar(valor);
        }
    }
}
