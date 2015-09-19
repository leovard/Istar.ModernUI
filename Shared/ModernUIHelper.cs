﻿using Istar.ModernUI.Win32;
using System;
using System.ComponentModel;
using System.Windows;

namespace Istar.ModernUI
{
    /// <summary>
    /// Provides various common helper methods.
    /// </summary>
    public static class ModernUiHelper
    {
        private static bool? _isInDesignMode;

        /// <summary>
        /// Determines whether the current code is executed in a design time environment such as Visual Studio or Blend.
        /// </summary>
        public static bool IsInDesignMode
        {
            get
            {
                if (!_isInDesignMode.HasValue) {
                    _isInDesignMode = DesignerProperties.GetIsInDesignMode(new DependencyObject());
                }
                return _isInDesignMode.Value;
            }
        }

        /// <summary>
        /// Gets the DPI awareness of the current process.
        /// </summary>
        /// <returns>
        /// The DPI awareness of the current process
        /// </returns>
        /// <exception cref="System.ComponentModel.Win32Exception"></exception>
        public static ProcessDpiAwareness GetDpiAwareness()
        {
            if (OsVersionHelper.IsWindows8Point1OrGreater) {
                ProcessDpiAwareness value;
                var result = NativeMethods.GetProcessDpiAwareness(IntPtr.Zero, out value);
                if (result != NativeMethods.SOk) {
                    throw new Win32Exception(result);
                }

                return value;
            }
            if (OsVersionHelper.IsWindowsVistaOrGreater) {
                // use older Win32 API to query system DPI awareness
                return NativeMethods.IsProcessDPIAware() ? ProcessDpiAwareness.SystemDpiAware : ProcessDpiAwareness.DpiUnaware;
            }

            // assume WPF default
            return ProcessDpiAwareness.SystemDpiAware;
        }

        /// <summary>
        /// Attempts to set the DPI awareness of this process to PerMonitorDpiAware
        /// </summary>
        /// <returns>A value indicating whether the DPI awareness has been set to PerMonitorDpiAware.</returns>
        /// <remarks>
        /// <para>
        /// For this operation to succeed the host OS must be Windows 8.1 or greater, and the initial
        /// DPI awareness must be set to DpiUnaware (apply [assembly:DisableDpiAwareness] to application assembly).
        /// </para>
        /// <para>
        /// When the host OS is Windows 8 or lower, an attempt is made to set the DPI awareness to SystemDpiAware (= WPF default). This
        /// effectively revokes the [assembly:DisableDpiAwareness] attribute if set.
        /// </para>
        /// </remarks>
        public static bool TrySetPerMonitorDpiAware()
        {
            var awareness = GetDpiAwareness();

            // initial awareness must be DpiUnaware
            if (awareness != ProcessDpiAwareness.DpiUnaware) return awareness == ProcessDpiAwareness.PerMonitorDpiAware;
            if (OsVersionHelper.IsWindows8Point1OrGreater) {
                return NativeMethods.SetProcessDpiAwareness(ProcessDpiAwareness.PerMonitorDpiAware) == NativeMethods.SOk;
            }

            // use older Win32 API to set the awareness to SystemDpiAware
            return NativeMethods.SetProcessDPIAware() == NativeMethods.SOk;

            // return true if per monitor was already enabled
        }
    }
}
