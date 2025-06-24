using System.Collections.Concurrent;

namespace APICatalogo.Logging
{
    public class CustomLoggerProvider : ILoggerProvider // interface ultilizada para criar instancias de loggs personalizadas
    {
        readonly CustomLoggerProviderConfiguration loggerConfig; 
        readonly ConcurrentDictionary<string, CustomerLogger> loggers =
                                     new ConcurrentDictionary<string, CustomerLogger>(); // dicionario de logs

        public CustomLoggerProvider(CustomLoggerProviderConfiguration config) // 
        {
            loggerConfig = config;
        }
        public ILogger CreateLogger(string categoryName) // cria log para um acategoria especifica
        {
            return loggers.GetOrAdd(categoryName, nameof => new CustomerLogger(nameof, loggerConfig));
        }

        public void Dispose() // libera recursos quando o provedor for descartado
        {
            loggers.Clear();
        }
    }
}
