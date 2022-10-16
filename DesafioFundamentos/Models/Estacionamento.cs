namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            veiculos.Add(Console.ReadLine());
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = "";
            placa = Console.ReadLine();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                decimal valorTotal = 0;

                valorTotal = ConfereECalculaHoras();

                veiculos.Remove(placa);
                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        //Executa loops para conferir a validade do valor digitado em horas.
        public decimal ConfereECalculaHoras()
        {
            int horas = 0;
            Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
            int.TryParse(Console.ReadLine(), out horas);
            if (horas < 0)
            {
                Console.WriteLine("Valor de horas inválido! O valor tem que ser maior ou igual a zero.");
                return ConfereECalculaHoras();
            }
            Console.WriteLine($"O numero de horas digitado é {horas}, confirma? digite S para continuar ou qualquer letra para repetir");
            string sn = Console.ReadLine();
            if (sn == "S" || sn == "s")
            {
                return precoInicial + precoPorHora * horas;
            }
            else
            {
                return ConfereECalculaHoras();
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (string item in veiculos)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
