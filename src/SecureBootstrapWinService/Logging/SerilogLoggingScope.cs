using SecureBootstrapWinService.Configuration;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using System;
using System.Collections.Generic;

namespace SecureBootstrapWinService.Logging
{
    public class SerilogLoggingScope : IGenericLoggingScope
    {
        private IConfiguration _cfg;
        private string scopeName;
        private Type typeDef;
        private System.Diagnostics.Stopwatch _stopwatch;
        private readonly LoggingLevelSwitch _levelSwitch = new LoggingLevelSwitch();
        private ILogger _logger;
        private List<ILogEventEnricher> _defaultEnrichers;
        private Dictionary<string, object> defaultProps = new Dictionary<string, object>();


        public TimeSpan ElapsedTime
        {
            get { return _stopwatch != null ? _stopwatch.Elapsed : new TimeSpan(); }
        }

        public string ScopeName
        {
            get;
            protected set;
        }
        public LogEventLevel? MinimumLogLevel { get; set; }

        public SerilogLoggingScope(IConfiguration cfg, string scopeName, Type typeDef)
        {
            this._cfg = cfg;
            this.ScopeName = scopeName;
            this.typeDef = typeDef;
            this._stopwatch = new System.Diagnostics.Stopwatch();
            _stopwatch.Start();
            bool useEventLog = false;
            var eventLogSource = _cfg.ApplicationName;
            bool useConsole = true;

            // Some defaults
            try
            {
                defaultProps.Add("Scope", scopeName);
                defaultProps.Add("Type", typeDef);

                // Parse from scopeData object?
            }
            catch (Exception)
            {
                // Swallow
            }
            this._defaultEnrichers = new List<ILogEventEnricher>
                {
                    new SecureBootstrapConfigurationEnricher(this._cfg),
                    //new PropsDictionaryEnricher(defaultProps),
                };

            this._levelSwitch.MinimumLevel = Serilog.Events.LogEventLevel.Debug;

            var loggerCfg = new Serilog.LoggerConfiguration()
                .ReadFrom.AppSettings()
                .Destructure.ToMaximumDepth(3)
                .MinimumLevel.ControlledBy(_levelSwitch)
                .Enrich.FromLogContext()
                .Enrich.WithMachineName()
                //.Enrich.WithEnvironment("")
                //.Enrich.With<SourceSystemEnricher<SerilogLoggingScope>>()
                //.Enrich.With<SourceSystemInformationalVersionEnricher<SerilogLoggingScope>>()
                .Enrich.With(_defaultEnrichers.ToArray())
                //.Enrich.WithProcessId()
                //.Enrich.WithProcessName()
                ;

            //if (!string.IsNullOrEmpty(_cfg.LoggingServerConnectionString))
            //{
            //    loggerCfg.WriteTo.Seq(_cfg.LoggingServerConnectionString, compact: true, controlLevelSwitch: _levelSwitch);
            //}
            //if (useEventLog)
            //{
            //    loggerCfg.WriteTo.EventLog(eventLogSource,
            //            outputTemplate: "C:{AXCompanyCode}-{User}{NewLine}{Message}{NewLine}{SessionId} - {CorrelationId} - {SourceContext}{NewLine}{Exception}",
            //            restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Warning);
            //}
            if (useConsole)
            {
                loggerCfg.WriteTo.Console();
            }

            _logger = loggerCfg
                .CreateLogger();
        }

        public SerilogLoggingScope(IConfiguration cfg, string scopeName, Type typeDef, object scopeData) : this(cfg, scopeName, typeDef)
        {
        }

        public void WriteError(string messageTemplate)
        {
            if (_logger != null)
                _logger.Error(messageTemplate);
        }

        public void WriteException(string messageTemplate, Exception exception)
        {
            if (_logger != null)
                _logger.Fatal(exception, messageTemplate);
        }

        public void WriteInfo(string messageTemplate)
        {
            if (_logger != null)
                _logger.Information(messageTemplate);
        }

        public void WriteObject(object obj)
        {
            if (_logger != null)
                _logger.Verbose("Object: {obj}", new[] { obj });
        }

        public void WriteTrace(string messageTemplate)
        {
            if (_logger != null)
                _logger.Debug(messageTemplate);
        }

        public void WriteWarning(string messageTemplate)
        {
            if (_logger != null)
                _logger.Warning(messageTemplate);
        }

        public void Debug(Exception exception, string messageTemplate, params object[] propertyValues)
        {
            if (_logger != null)
                _logger.Debug(exception, messageTemplate, propertyValues);
        }

        public void Debug(Exception exception, string messageTemplate)
        {
            if (_logger != null)
                _logger.Debug(exception, messageTemplate);
        }

        public void Debug(string messageTemplate, params object[] propertyValues)
        {
            if (_logger != null)
                _logger.Debug(messageTemplate, propertyValues);
        }

        public void Debug(string messageTemplate)
        {
            if (_logger != null)
                _logger.Debug(messageTemplate);
        }

        public void Error(string messageTemplate, params object[] propertyValues)
        {
            if (_logger != null)
                _logger.Error(messageTemplate, propertyValues);
        }

        public void Error(string messageTemplate)
        {
            if (_logger != null)
                _logger.Error(messageTemplate);
        }

        public void Error(Exception exception, string messageTemplate, params object[] propertyValues)
        {
            if (_logger != null)
                _logger.Debug(exception, messageTemplate, propertyValues);
        }

        public void Error(Exception exception, string messageTemplate)
        {
            if (_logger != null)
                _logger.Debug(exception, messageTemplate);
        }

        public void Fatal(string messageTemplate, params object[] propertyValues)
        {
            if (_logger != null)
                _logger.Fatal(messageTemplate, propertyValues);
        }

        public void Fatal(Exception exception, string messageTemplate, params object[] propertyValues)
        {
            if (_logger != null)
                _logger.Fatal(exception, messageTemplate, propertyValues);
        }

        public void Fatal(Exception exception, string messageTemplate)
        {
            if (_logger != null)
                _logger.Fatal(exception, messageTemplate);
        }

        public void Fatal(string messageTemplate)
        {
            if (_logger != null)
                _logger.Fatal(messageTemplate);
        }

        public void Information(string messageTemplate)
        {
            if (_logger != null)
                _logger.Information(messageTemplate);
        }

        public void Information(Exception exception, string messageTemplate, params object[] propertyValues)
        {
            //propertyValues = ExpandPropertyValues(propertyValues);
            if (_logger != null)
                _logger.Information(exception, messageTemplate, propertyValues);
        }

        public void Information(Exception exception, string messageTemplate)
        {
            if (_logger != null)
                _logger.Debug(exception, messageTemplate);
        }

        public void Information(string messageTemplate, params object[] propertyValues)
        {
            //propertyValues = ExpandPropertyValues(propertyValues);
            if (_logger != null)
                _logger.Information(messageTemplate, propertyValues);
        }

        public IGenericLoggingScope NewScope(string scopeName, Type type = null, object scopeData = null)
        {
            return new SerilogLoggingScope(_cfg, scopeName, type, scopeData);
        }

        public void Verbose(string messageTemplate, params object[] propertyValues)
        {
            if (_logger != null)
                _logger.Verbose(messageTemplate, propertyValues);
        }

        public void Verbose(Exception exception, string messageTemplate)
        {
            if (_logger != null)
                _logger.Verbose(exception, messageTemplate);
        }

        public void Verbose(Exception exception, string messageTemplate, params object[] propertyValues)
        {
            if (_logger != null)
                _logger.Verbose(exception, messageTemplate, propertyValues);
        }

        public void Verbose(string messageTemplate)
        {
            if (_logger != null)
                _logger.Verbose(messageTemplate);
        }

        public void Warning(string messageTemplate)
        {
            if (_logger != null)
                _logger.Warning(messageTemplate);
        }

        public void Warning(Exception exception, string messageTemplate, params object[] propertyValues)
        {
            if (_logger != null)
                _logger.Warning(exception, messageTemplate, propertyValues);
        }

        public void Warning(string messageTemplate, params object[] propertyValues)
        {
            if (_logger != null)
                _logger.Warning(messageTemplate, propertyValues);
        }

        public void Warning(Exception exception, string messageTemplate)
        {
            if (_logger != null)
                _logger.Warning(exception, messageTemplate);
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                _logger.Verbose("Scope for type {FullName} {ScopeName} complete, consumed {Elapsed:c}", this.typeDef != null ? this.typeDef.FullName : "Unknown", ScopeName, ElapsedTime);
                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~SerilogLoggingScope() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
