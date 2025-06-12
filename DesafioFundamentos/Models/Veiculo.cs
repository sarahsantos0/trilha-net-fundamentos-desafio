namespace DesafioFundamentos.models
{
    public class Veiculo
    {
        public string Placa { get; set; }
        public DateTime HoraEntrada { get; set; }

        public Veiculo(string placa)
        {
            Placa = placa.ToUpper();
            HoraEntrada = DateTime.Now;
        }

        public TimeSpan TempoEstacionado => DateTime.Now - HoraEntrada;
    }
}
