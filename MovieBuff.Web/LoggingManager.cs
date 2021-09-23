using log4net;
using log4net.Config;
using MovieBuff.Core.Services.LoggingService;
using System;
using System.IO;
using System.Reflection;
using System.Xml;

namespace MovieBuff.Web
{
    public class LoggingManager : ILoggingManager
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(LoggingManager));

        public LoggingManager()
        {
            try
            {
                XmlDocument log4netConfig = new XmlDocument();

                using (var fs = File.OpenRead("log4net.config"))
                {
                    log4netConfig.Load(fs);
                    var repo = LogManager.CreateRepository(Assembly.GetEntryAssembly(), typeof(log4net.Repository.Hierarchy.Hierarchy));
                    XmlConfigurator.Configure(repo, log4netConfig["log4net"]);
                    _logger.Info("Initialized Log System");
                }
            }
            catch (Exception ex)
            {
                _logger.Error("An error occured while initializing Log System", ex);
            }
        }

        public void LogInfo(string message)
        {
            _logger.Info(message);
        }
    }
}
