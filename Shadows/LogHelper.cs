using System;
using System.Collections.Generic;
using System.Text;

namespace Shadows {
    public static class LogHelper {

        private static readonly string _defaultLogDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Shadows";
        private static log4net.ILog _logger;

        public static string DefaultLogDirectory {
            get { return _defaultLogDirectory; }
        }

        public static log4net.ILog Logger {
            get { return _logger; }
        }

        public static void SetUpLogger(log4net.Core.Level logLevel, bool logActive = true) {
            log4net.Repository.Hierarchy.Hierarchy hierarchy = (log4net.Repository.Hierarchy.Hierarchy)log4net.LogManager.GetRepository();
            hierarchy.ResetConfiguration();
            hierarchy.Root.RemoveAllAppenders();

            log4net.Layout.PatternLayout patternLayout = new log4net.Layout.PatternLayout();
            patternLayout.ConversionPattern = Properties.Settings.Default.LogLayoutConversionPattern;
            patternLayout.ActivateOptions();

            log4net.Appender.RollingFileAppender rollApp = new log4net.Appender.RollingFileAppender();
            rollApp.AppendToFile = true;
            rollApp.File = (Properties.Settings.Default.LogDirectory.Equals("") ? DefaultLogDirectory : Properties.Settings.Default.LogDirectory) + "\\" + Properties.Settings.Default.LogFileName;
            rollApp.Layout = patternLayout;
            rollApp.StaticLogFileName = true;
            rollApp.MaxSizeRollBackups = Properties.Settings.Default.LogArchives;
            rollApp.MaximumFileSize = Properties.Settings.Default.LogMaxSize + "KB";
            rollApp.RollingStyle = log4net.Appender.RollingFileAppender.RollingMode.Size;
            rollApp.ActivateOptions();

            hierarchy.Root.AddAppender(rollApp);
            hierarchy.Root.Level = logActive ? logLevel : log4net.Core.Level.Off;
            hierarchy.Configured = true;

            _logger = log4net.LogManager.GetLogger("Root");
        }

        public static void SetUpLogger(byte logLevel, bool logActive = true) {
            switch(logLevel) {
                default: SetUpLogger(log4net.Core.Level.Info, logActive); break;
                case 1: SetUpLogger(log4net.Core.Level.Warn, logActive); break;
                case 2: SetUpLogger(log4net.Core.Level.Error, logActive); break;
                case 3: SetUpLogger(log4net.Core.Level.Fatal, logActive); break;
            }
        }

        public static void LogSearchStart(Main form) {
            // TODO: implement
        }
    }
}
