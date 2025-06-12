using System.Globalization;

namespace DesafioFundamentos.models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private int vagasTotais = 0;
        private List<Veiculo> veiculos = new();

        public Estacionamento(decimal precoInicial, decimal precoPorHora, int vagasTotais)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
            this.vagasTotais = vagasTotais;
        }

        public void AdicionarVeiculo(string? placa)
        {
            if (string.IsNullOrWhiteSpace(placa))
            {
                Console.WriteLine("Placa inválida.");
                return;
            }

            if (veiculos.Count >= vagasTotais)
            {
                Console.WriteLine("Estacionamento cheio! Não há vagas disponíveis.");
                return;
            }

            placa = placa.ToUpper();

            if (veiculos.Any(v => v.Placa == placa))
            {
                Console.WriteLine("Esse veículo já está estacionado.");
                return;
            }

            veiculos.Add(new Veiculo(placa));
            Console.WriteLine($"Veículo {placa} cadastrado com sucesso em {DateTime.Now.ToString("HH:mm:ss")}");
        }

        public void RemoverVeiculo(string? placa)
        {
            if (string.IsNullOrWhiteSpace(placa))
            {
                Console.WriteLine("Placa inválida.");
                return;
            }

            placa = placa.ToUpper();
            Veiculo? veiculo = veiculos.FirstOrDefault(v => v.Placa == placa);

            if (veiculo == null)
            {
                Console.WriteLine("Esse veículo não está no estacionamento.");
                return;
            }

            TimeSpan tempo = veiculo.TempoEstacionado;
            int horas = (int)tempo.TotalHours;
            decimal valorTotal = precoInicial;
            if (horas >= 1)
            {
                valorTotal += precoPorHora * (horas); // Calcula o valor total com base nas horas estacionadas
            }

            Console.WriteLine($"\nVeículo {placa} permaneceu por {horas} hora(s).");
            Console.WriteLine($"Valor total a pagar: R$ {valorTotal:F2}");

            Console.Write("Confirmar remoção? (S/N): ");
            string? confirmar = Console.ReadLine();
            if (confirmar?.Trim().ToUpper() == "S")
            {
                veiculos.Remove(veiculo);
                Console.WriteLine("Veículo removido com sucesso!");
            }
            else
            {
                Console.WriteLine("Operação cancelada.");
            }
        }

        public void ListarVeiculos()
        {
            if (!veiculos.Any())
            {
                Console.WriteLine("Não há veículos estacionados.");
                return;
            }

            Console.WriteLine("Veículos estacionados:");
            foreach (var v in veiculos)
            {
                TimeSpan tempo = v.TempoEstacionado;
                int horas = (int)tempo.TotalHours;
                decimal valorAtual = precoInicial;
                if (horas >= 1)
                {
                    valorAtual += precoPorHora * (horas); // Calcula o valor atual com base nas horas estacionadas
                }

                Console.WriteLine($"Placa: {v.Placa} | Entrada: {v.HoraEntrada:HH:mm:ss} | Tempo: {horas}h | Valor atual: R$ {valorAtual:F2}");
            }
        }
    }
}
