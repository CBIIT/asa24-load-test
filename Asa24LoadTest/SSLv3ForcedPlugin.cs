﻿using System;

using System.ComponentModel;

using System.Net;

using System.Net.Security;

using System.Security.Cryptography.X509Certificates;

using Microsoft.VisualStudio.TestTools.WebTesting;

namespace ExperimentalTesting
{
    [Description("This plugin will force the underlying System.Net ServicePointManager to negotiate downlevel SSLv3 instead of TLS. WARNING: The servers X509 Certificate will be ignored as part of this process, so verify that you are testing the correct system.")]

    public class SSLv3ForcedPlugin : WebTestPlugin
    {
        [Description("Enable or Disable the plugin functionality")]
        [DefaultValue(true)]
        public bool Enabled { get; set; }

        public override void PreWebTest(object sender, PreWebTestEventArgs e)
        {
            base.PreWebTest(sender, e);

            // We're using SSL3 here and not TLS. Without this line, nothing works.
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            //we wire up the callback so we can override  behavior and force it to accept the cert
            ServicePointManager.ServerCertificateValidationCallback = RemoteCertificateValidationCB;

            //let them know we made changes to the service point manager
            e.WebTest.AddCommentToResult(this.ToString() + " has made the following modification-> ServicePointManager.SecurityProtocol set to use SSLv3 in WebTest Plugin.");
        }

        public static bool RemoteCertificateValidationCB(Object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            //If it is really important, validate the certificate issuer here.
            //this will accept any certificate

            return true;
        }
    }
}

