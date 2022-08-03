
using Newtonsoft.Json;
using StockMarket.Interfaces.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace StockMarket.Core.Logging
{
    public class LoggingManager<T> : ILoggingManager<T>
    {
        private readonly ILogger _logger;
      //  private readonly string apiVersion;
      //  private readonly string module;

        public LoggingManager(ILogger<T> logger)
        {
            this._logger = logger;            
        } 


      
        public async Task LogError(Exception exception,
            string label, string message, Dictionary<string, string> properties = null,
            Dictionary<string, double> metrics = null,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string memberFilePath = "",
            [CallerLineNumber] int memberLineNumber = 0,
            params object[] dataObjects)
        {
            await Log(LogLevel.Error, label, message, exception,
                properties, metrics,
                memberName, memberFilePath, memberLineNumber,
                dataObjects
                );
        }

        public async Task LogWarning( string label, string message,
            Dictionary<string, string> properties = null, Dictionary<string, double> metrics = null,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string memberFilePath = "",
            [CallerLineNumber] int memberLineNumber = 0,
            params object[] dataObjects)
        {
            await Log(LogLevel.Warning,
                label, message, null,
                properties, metrics,
                memberName, memberFilePath, memberLineNumber,
                dataObjects
                );
        }

        public async Task LogInformation(string label, string message,
            Dictionary<string, string> properties = null, Dictionary<string, double> metrics = null,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string memberFilePath = "",
            [CallerLineNumber] int memberLineNumber = 0,
            params object[] dataObjects)
        {
            await Log(LogLevel.Information,  label, message, null,
                properties, metrics,
                memberName, memberFilePath, memberLineNumber,
                dataObjects
                );
        }


        // TODO: Adding Types , can we do it with dependency injection on the class.
        // private async Task Log(LogLevel logLevel,
        private async Task Log(LogLevel logLevel,string label, string message, Exception exception = null,
            Dictionary<string, string> properties = null, Dictionary<string, double> metrics = null,
            string memberName = "",
            string memberFilePath = "",
            int memberLineNumber = 0,
            params object[] dataObjects)
        {
            try
            {
                _logger.Log(logLevel, exception, message, label, memberName, dataObjects);
            }
            catch (Exception ex)
            {
                if (exception != null)
                    Console.WriteLine($"Error writing to logs. Logger. Exception:{ex.ToString()}");
                else
                    throw;
            }

            try
            {
                await Task.Run(() =>
                {
                      // log to app database
                });

            }
            catch (Exception ex)
            {
                //if (exception != null)
                    Console.WriteLine($"Error writing to logs. Logger. Exception:{ex.ToString()}");
                //else
                //    throw;
            }
        }

    }
}
