﻿namespace Rollbar.NetFramework
{
    using Rollbar.Telemetry;
    using System;

    /// <summary>
    /// Class AppConfigUtility.
    /// It aids in configuration of Rollbar configuration objects based on content of an app.config file (if any). 
    /// </summary>
    public static class AppConfigUtility
    {
        private static readonly string[] listValueSplitters = new [] { ", ", "; ", " " };

        #region RollbarConfig

        /// <summary>
        /// Loads the application settings.
        /// </summary>
        /// <param name="rollbarConfig">The Rollbar configuration.</param>
        /// <returns>false when the configuration was not found, otherwise true.</returns>
        public static bool LoadAppSettings(RollbarConfig rollbarConfig)
        {
            return AppConfigUtility.LoadAppSettings(rollbarConfig, RollbarConfigSection.GetConfiguration());
        }

        /// <summary>
        /// Loads the application settings.
        /// </summary>
        /// <param name="rollbarConfig">The configuration.</param>
        /// <param name="rollbarConfigSection">The application settings.</param>
        /// <returns>false when the configuration was not found, otherwise true.</returns>
        public static bool LoadAppSettings(RollbarConfig rollbarConfig, RollbarConfigSection rollbarConfigSection)
        {
            if (rollbarConfigSection == null)
            {
                return false;
            }

            if (!string.IsNullOrWhiteSpace(rollbarConfigSection.AccessToken))
            {
                rollbarConfig.AccessToken = rollbarConfigSection.AccessToken;
            }
            if (!string.IsNullOrWhiteSpace(rollbarConfigSection.Environment))
            {
                rollbarConfig.Environment = rollbarConfigSection.Environment;
            }
            if (rollbarConfigSection.Enabled.HasValue)
            {
                rollbarConfig.Enabled = rollbarConfigSection.Enabled.Value;
            }
            if (rollbarConfigSection.MaxReportsPerMinute.HasValue)
            {
                rollbarConfig.MaxReportsPerMinute = rollbarConfigSection.MaxReportsPerMinute.Value;
            }
            if (rollbarConfigSection.ReportingQueueDepth.HasValue)
            {
                rollbarConfig.ReportingQueueDepth = rollbarConfigSection.ReportingQueueDepth.Value;
            }
            if (rollbarConfigSection.MaxItems.HasValue)
            {
                rollbarConfig.MaxItems = rollbarConfigSection.MaxItems.Value;
            }
            if (rollbarConfigSection.CaptureUncaughtExceptions.HasValue)
            {
                rollbarConfig.CaptureUncaughtExceptions = rollbarConfigSection.CaptureUncaughtExceptions.Value;
            }
            if (rollbarConfigSection.LogLevel.HasValue)
            {
                rollbarConfig.LogLevel = rollbarConfigSection.LogLevel.Value;
            }
            if (rollbarConfigSection.ScrubFields != null && rollbarConfigSection.ScrubFields.Length > 0)
            {
                rollbarConfig.ScrubFields =
                    string.IsNullOrEmpty(rollbarConfigSection.ScrubFields) ? new string[0]
                    : rollbarConfigSection.ScrubFields.Split(listValueSplitters, StringSplitOptions.RemoveEmptyEntries);
            }
            if (rollbarConfigSection.ScrubWhitelistFields != null && rollbarConfigSection.ScrubWhitelistFields.Length > 0)
            {
                rollbarConfig.ScrubWhitelistFields =
                    string.IsNullOrEmpty(rollbarConfigSection.ScrubWhitelistFields) ? new string[0]
                    : rollbarConfigSection.ScrubWhitelistFields.Split(listValueSplitters, StringSplitOptions.RemoveEmptyEntries);
            }
            if (!string.IsNullOrWhiteSpace(rollbarConfigSection.EndPoint))
            {
                rollbarConfig.EndPoint = rollbarConfigSection.EndPoint;
            }
            if (!string.IsNullOrWhiteSpace(rollbarConfigSection.ProxyAddress))
            {
                rollbarConfig.ProxyAddress = rollbarConfigSection.ProxyAddress;
            }
            if (!string.IsNullOrWhiteSpace(rollbarConfigSection.ProxyUsername))
            {
                rollbarConfig.ProxyUsername = rollbarConfigSection.ProxyUsername;
            }
            if (!string.IsNullOrWhiteSpace(rollbarConfigSection.ProxyPassword))
            {
                rollbarConfig.ProxyPassword = rollbarConfigSection.ProxyPassword;
            }
            if (rollbarConfigSection.PersonDataCollectionPolicies.HasValue)
            {
                rollbarConfig.PersonDataCollectionPolicies = rollbarConfigSection.PersonDataCollectionPolicies.Value;
            }
            if (rollbarConfigSection.IpAddressCollectionPolicy.HasValue)
            {
                rollbarConfig.IpAddressCollectionPolicy = rollbarConfigSection.IpAddressCollectionPolicy.Value;
            }

            return true;
        }

        #endregion RollbarConfig

        #region TelemetryConfig

        /// <summary>
        /// Loads the application settings.
        /// </summary>
        /// <param name="telemetryConfig">The configuration.</param>
        /// <returns>false when the configuration was not found, otherwise true.</returns>
        public static bool LoadAppSettings(TelemetryConfig telemetryConfig)
        {
            return AppConfigUtility.LoadAppSettings(telemetryConfig, RollbarTelemetryConfigSection.GetConfiguration());
        }

        /// <summary>
        /// Loads the application settings.
        /// </summary>
        /// <param name="telemetryConfig">The configuration.</param>
        /// <param name="telemetryConfigSection">The application settings.</param>
        /// <returns>false when the configuration was not found, otherwise true.</returns>
        public static bool LoadAppSettings(TelemetryConfig telemetryConfig, RollbarTelemetryConfigSection telemetryConfigSection)
        {
            if (telemetryConfigSection == null)
            {
                return false;
            }

            if (telemetryConfigSection.TelemetryEnabled.HasValue)
            {
                telemetryConfig.TelemetryEnabled = telemetryConfigSection.TelemetryEnabled.Value;
            }
            if (telemetryConfigSection.TelemetryQueueDepth.HasValue)
            {
                telemetryConfig.TelemetryQueueDepth = telemetryConfigSection.TelemetryQueueDepth.Value;
            }
            if (telemetryConfigSection.TelemetryAutoCollectionTypes.HasValue)
            {
                telemetryConfig.TelemetryAutoCollectionTypes = telemetryConfigSection.TelemetryAutoCollectionTypes.Value;
            }
            if (telemetryConfigSection.TelemetryAutoCollectionInterval.HasValue)
            {
                telemetryConfig.TelemetryAutoCollectionInterval = telemetryConfigSection.TelemetryAutoCollectionInterval.Value;
            }

            return true;
        }
    }

    #endregion TelemetryConfig
}
