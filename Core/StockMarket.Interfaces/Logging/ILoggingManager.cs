using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Interfaces.Logging
{
    public interface ILoggingManager<T>
    {
        public Task LogError( Exception exception, string label, string message,
            Dictionary<string, string> properties = null, Dictionary<string, double> metrics = null,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string memberFilePath = "",
            [CallerLineNumber] int memberLineNumber = 0,
            params object[] dataObjects);

        public Task LogWarning(string label, string message,
            Dictionary<string, string> properties = null, Dictionary<string, double> metrics = null,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string memberFilePath = "",
            [CallerLineNumber] int memberLineNumber = 0,
            params object[] dataObjects);

        public Task LogInformation( string label, string message,
            Dictionary<string, string> properties = null, Dictionary<string, double> metrics = null,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string memberFilePath = "",
            [CallerLineNumber] int memberLineNumber = 0,
            params object[] dataObjects);
    }
}
