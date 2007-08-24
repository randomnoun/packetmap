using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bdev.Net.Dns;
using Microsoft.Win32;
using System.Text.RegularExpressions;

namespace PacketMap {
    public partial class DnsLookup : Form {
        #region locals
        public static string
            lblDnsServerText = "DNS Server:",
            lblHostnameText = "IP/Hostname:",
            cmdOKText = "Lookup",
            cmdCancelText = "Cancel",
            lblResultText = "Result:",
            thisText = "DnsLookup",
            // messages
            MReverseIP = "Reverse IP",
            MQueryingDNSRecordsForDomain = "Querying DNS records for domain: ",
            MNoAnswer = "No answer\n",
            MAuthoritativeanswer = "Authoritative answer\n",
            MNotAuthoritativeanswer = "Non-authoritative answer\n";

        void ApplyLocals() {
            lblDnsServer.Text = lblDnsServerText;
            lblHostname.Text = lblHostnameText;
            cmdOK.Text = cmdOKText;
            cmdCancel.Text = cmdCancelText;
            lblResult.Text = lblResultText;
            this.Text = thisText;
        }
        #endregion

        public DnsLookup() {
            InitializeComponent();
            ApplyLocals();
        }

        public String getDnsServer() {
            return txtDnsServer.Text;
        }


        private void DnsLookup_Load(object sender, EventArgs e) {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Randomnoun\Packetmap");
            if (key == null) {
                key = Registry.CurrentUser.CreateSubKey(@"Software\Randomnoun\Packetmap");
            }
            string deviceName = (string)key.GetValue("DnsServer", "");
            key.Close();
        }

        private void cmdOK_Click(object sender, EventArgs e) {
            // Information
            txtResult.Clear();
            System.Net.IPAddress dnsServer = System.Net.IPAddress.Parse(txtDnsServer.Text);

            String domain = txtHostname.Text;

            // see if hostname is a dotted IP address
            // if (Regex.Matches(txtHostname.Text, @"^([0-9]+)\.([0-9]+)\.([0-9]+)\.([0-9]+)$") 
            Match m = Regex.Match(domain, @"^([0-9]+)\.([0-9]+)\.([0-9]+)\.([0-9]+)$");
            if (m.Success) {
                txtResult.AppendText(MReverseIP);
                domain = m.Groups[4] + "." + m.Groups[3] + "." + m.Groups[2] + "." + m.Groups[1] + ".in-addr.arpa";
            }

            txtResult.AppendText(MQueryingDNSRecordsForDomain + domain + "\n");
            // query AName, MX, NS, SOA
            Query(dnsServer, domain, DnsType.ANAME);
            Query(dnsServer, domain, DnsType.MX);
            Query(dnsServer, domain, DnsType.NS);
            Query(dnsServer, domain, DnsType.SOA);
        }

        private void Query(System.Net.IPAddress dnsServer, string domain, DnsType type) {
            try {
                // create a DNS request
                Request request = new Request();

                // create a question for this domain and DNS CLASS
                request.AddQuestion(new Question(domain, type, DnsClass.IN));

                // send it to the DNS server and get the response
                Response response = Resolver.Lookup(request, dnsServer);

                // check we have a response
                if (response == null) {
                    txtResult.AppendText(MNoAnswer);
                    return;

                }
                // display each RR returned
                txtResult.AppendText("------------------------------\n");

                // display whether this is an authoritative answer or not
                if (response.AuthoritativeAnswer) {
                    txtResult.AppendText(MAuthoritativeanswer);
                } else {
                    txtResult.AppendText(MNotAuthoritativeanswer);
                }

                // Dump all the records - answers/name servers/additional records
                foreach (Answer answer in response.Answers) {
                    txtResult.AppendText(String.Format("{0} ({1}) : {2}\n", answer.Type.ToString(), answer.Domain, answer.Record.ToString()));
                }

                foreach (NameServer nameServer in response.NameServers) {
                    txtResult.AppendText(String.Format("{0} ({1}) : {2}\n", nameServer.Type.ToString(), nameServer.Domain, nameServer.Record.ToString()));
                }

                foreach (AdditionalRecord additionalRecord in response.AdditionalRecords) {
                    txtResult.AppendText(String.Format("{0} ({1}) : {2}\n", additionalRecord.Type.ToString(), additionalRecord.Domain, additionalRecord.Record.ToString()));
                }
            } catch (Exception ex) {
                txtResult.AppendText(ex.Message + "\n");
            }
        }


    }
}
