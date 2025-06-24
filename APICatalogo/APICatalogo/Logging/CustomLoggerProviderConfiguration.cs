namespace APICatalogo.Logging
{
    public class CustomLoggerProviderConfiguration
    {
        public LogLevel LogLevel { get; set; } = LogLevel.Warning; //define o mível mínimo de log a ser registrado, com o padrão LogLevel.Warining.
        public int EventId { get; set; } = 0; // Define o Id do evento de log, com o padrão sendo zero
    }
}
