using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Tamir.IPLib;


namespace PacketMap {
    public partial class SelectAdapterForm : Form {
        PcapDeviceList devices;
        int deviceId = -1;

        public SelectAdapterForm() {
            InitializeComponent();
        }

        public int getDeviceId() {
            return deviceId;
        }

        private void SelectAdapterForm_Load(object sender, EventArgs e) {
            // grab the list of adapters from pcap
            devices = SharpPcap.GetAllDevices();

            /*if (devices.Count < 1) {
                // should probably do something here ... exit ?
                return;
            }*/
            
            // add each device to the listbox
            lstAdapters.BeginUpdate();
            foreach (PcapDevice dev in devices) {
                lstAdapters.Items.Add(dev.PcapDescription);
            }
            lstAdapters.EndUpdate();
        }

        private void lstAdapters_SelectedIndexChanged(object sender, EventArgs e) {
            string crlf = "\013\010";
            PcapDevice device = devices[lstAdapters.SelectedIndex];
            if (device is NetworkDevice) {//Then..
                NetworkDevice netDev = (NetworkDevice) device;
                lblAdapterData1.Text = netDev.IpAddress + "\n" + netDev.SubnetMask + "\n" +
                    netDev.DefaultGateway + "\n" + netDev.WinsServerPrimary + "\n" +
                    netDev.WinsServerSecondary;
                lblAdapterData2.Text = device.PcapLoopback + "\n" + netDev.MacAddress + "\n" +
                    netDev.DhcpEnabled + "\n" + netDev.DhcpServer + "\n" +
                    netDev.DhcpLeaseObtained + "\n" + netDev.DhcpLeaseExpires;
            } else {
                lblAdapterData1.Text = "N/A";
                lblAdapterData2.Text = device.PcapLoopback + crlf + "N/A";
            }
            deviceId = lstAdapters.SelectedIndex;
        }
    }
}