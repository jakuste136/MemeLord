﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MemeLord.Configuration.Settings {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.6.0.0")]
    internal sealed partial class AuthorizationSettings : global::System.Configuration.ApplicationSettingsBase {
        
        private static AuthorizationSettings defaultInstance = ((AuthorizationSettings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new AuthorizationSettings())));
        
        public static AuthorizationSettings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("00:30:00")]
        public global::System.TimeSpan TokenLifeTime {
            get {
                return ((global::System.TimeSpan)(this["TokenLifeTime"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("kAqpK8Ah2BJ9uQGU")]
        public string Audience {
            get {
                return ((string)(this["Audience"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("3dNfaHaFtvtzdnww")]
        public string Issuer {
            get {
                return ((string)(this["Issuer"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("3Xk46MxtFcah7VDCQPphSmCg")]
        public string Secret {
            get {
                return ((string)(this["Secret"]));
            }
        }
    }
}
