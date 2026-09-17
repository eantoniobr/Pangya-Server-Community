using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace PangyaSuiteFiles.My
{
    internal sealed class MySettings : ApplicationSettingsBase
    {
        private static MySettings defaultInstance = ((MySettings) Synchronized(new MySettings()));
        private static bool addedHandler;
        private static object addedHandlerLockObject = RuntimeHelpers.GetObjectValue(new object());

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        private static void AutoSaveSettings(object sender, EventArgs e)
        {
            if (MyProject.Application.SaveMySettingsOnExit)
            {
                MySettingsProperty.Settings.Save();
            }
        }

        public static MySettings Default
        {
            get
            {
                if (!addedHandler)
                {
                    object addedHandlerLockObject = MySettings.addedHandlerLockObject;
                    ObjectFlowControl.CheckForSyncLockOnValueType(addedHandlerLockObject);
                    lock (addedHandlerLockObject)
                    {
                        if (!addedHandler)
                        {
                            MyProject.Application.Shutdown += new ShutdownEventHandler(MySettings.AutoSaveSettings);
                            addedHandler = true;
                        }
                    }
                }
                return defaultInstance;
            }
        }

        [UserScopedSetting, DefaultSettingValue("luismk"), DebuggerNonUserCode]
        public string login
        {
            get => 
                Conversions.ToString(this["login"]);
            set => 
                this["login"] = value;
        }

        [UserScopedSetting, DefaultSettingValue("")]
        public string firstUse
        {
            get => 
                Conversions.ToString(this["firstUse"]);
            set => 
                this["firstUse"] = value;
        }

        [UserScopedSetting, DefaultSettingValue("true")]
        public bool AutoLoadIFF
        {
            get =>
                Conversions.ToBoolean(this["AutoLoadIFF"]);
            set =>
                this["AutoLoadIFF"] = value;
        }

        [ UserScopedSetting, DefaultSettingValue("update")]
        public string senha
        {
            get => 
                Conversions.ToString(this["senha"]);
            set => 
                this["senha"] = value;
        }

        [ UserScopedSetting, DefaultSettingValue("192.99.15.65")]
        public string ip
        {
            get => 
                Conversions.ToString(this["ip"]);
            set => 
                this["ip"] = value;
        }

        [ DefaultSettingValue("sa"), UserScopedSetting]
        public string sa
        {
            get => 
                Conversions.ToString(this["sa"]);
            set => 
                this["sa"] = value;
        }

        [DefaultSettingValue("123456"), UserScopedSetting, DebuggerNonUserCode]
        public string sasenha
        {
            get => 
                Conversions.ToString(this["sasenha"]);
            set => 
                this["sasenha"] = value;
        }

        [DefaultSettingValue("1433"),  UserScopedSetting]
        public string porta
        {
            get => 
                Conversions.ToString(this["porta"]);
            set => 
                this["porta"] = value;
        }
    }
}

