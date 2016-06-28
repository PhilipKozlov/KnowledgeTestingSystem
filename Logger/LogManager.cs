using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    /// <summary>
    /// Creates and manages instances of ILogger objects.
    /// </summary>
    public static class LogManager
    {
        /// <summary>
        /// Gets the logger
        /// </summary>
        /// <returns> The Logger instance.</returns>
        public static ILogger GetLogger()
        {
            var assemblyName = Assembly.GetExecutingAssembly().FullName;
            var loggerName = ConfigurationManager.AppSettings["LoggerName"];
            ILogger logger;
            try
            {
                logger = (ILogger)Activator.CreateInstance(assemblyName, $"{assemblyName.Substring(0, assemblyName.IndexOf(','))}.{loggerName}").Unwrap();
            }
            catch (TypeLoadException ex)
            {
                logger = Default();
                logger.Error($"Unable to load {loggerName} from assembly {assemblyName}.", ex);
            }
            catch (MissingMethodException ex)
            {
                logger = Default();
                logger.Error($"Type {assemblyName}.{loggerName} has no matching public constructor.", ex);
            }
            catch (Exception ex)
            {
                logger = Default();
                logger.Error($"Unable to load {loggerName} from assembly {assemblyName}.", ex);
            }
            return logger;
        }

        /// <summary>
        /// Gets the default logger.
        /// </summary>
        /// <returns> The Logger instance.</returns>
        public static ILogger Default() => new NLogAdapter();
    }
}
