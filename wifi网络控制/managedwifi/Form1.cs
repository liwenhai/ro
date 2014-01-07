using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Threading;
using System.Management;
namespace NativeWifi
{
    public partial class Form1 : Form
    {
        MyWifi tt = new MyWifi();
        Thread mainThread;
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tt.ScanSSID();
            foreach (var item in tt.ssids)
	        {
                comboBox1.Items.Add(item.SSID + "," + item.wlanSignalQuality);
	        }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var dd = from t in tt.ssids where t.SSID == comboBox1.Items[comboBox1.SelectedIndex].ToString().Split(',')[0].ToString() select t;

            tt.ConnectToSSID(dd.First());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (mainThread != null && mainThread.IsAlive) {
                mainThread.Abort();
            }
            mainThread = new Thread(new ThreadStart(wanlSh));
            mainThread.Start();
            label1.Text = "守护中";
        }

        bool isneedreset = true;

        public void wanlSh() { 
            while(true){
                Thread.Sleep(5000);
                
                tt.ScanSSID();
                var dd = from t in tt.ssids where t.SSID == "ChinaUnicom" && ((t.flags & NativeWifi.Wlan.WlanAvailableNetworkFlags.Connected) == NativeWifi.Wlan.WlanAvailableNetworkFlags.Connected) select t;
                if (dd != null && dd.Count() > 0)
                {
                    label1.Text = "连接到ChiaUnicom";
                    this.TopMost = false;

                    //双网卡设置内网走凡客外网走无线
                    //System.Management.Instrumentation.m
                    ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
                    ManagementObjectCollection nics = mc.GetInstances();
                    foreach (ManagementObject nic in nics)
                    {
                        if (Convert.ToBoolean(nic["ipEnabled"]) == true)
                        {

                            if (isneedreset&&nic["DefaultIPGateway"] != null && nic["Description"].ToString().IndexOf("os AR9271") > 0)
                            {
                                if (nic["DefaultIPGateway"] != null)
                                {
                                    System.Diagnostics.Process.Start("CMD.EXE", "/c route delete 0.0.0.0");
                                    System.Diagnostics.Process.Start("CMD.EXE", "/c route delete 10.0.0.0");
                                    System.Diagnostics.Process.Start("CMD.EXE", "/c route add 0.0.0.0 mask 0.0.0.0 " + (nic["DefaultIPGateway"] as string[])[0]);
                                    System.Diagnostics.Process.Start("CMD.EXE", "/c route add 10.0.0.0 mask 255.0.0.0 10.16.4.1");
                                    isneedreset = false;
                                }
                                else {
                                    connectedTochinaunicom();
                                }
                            }


                            //更多nic定义如下:
                              //boolean  ArpUseEtherSNAP;
                              //string   Caption;
                              //string   DatabasePath;
                              //boolean  DeadGWDetectEnabled;
                              //string   DefaultIPGateway[];
                              //uint8    DefaultTOS;
                              //uint8    DefaultTTL;
                              //string   Description;
                              //boolean  DHCPEnabled;
                              //datetime DHCPLeaseExpires;
                              //datetime DHCPLeaseObtained;
                              //string   DHCPServer;
                              //string   DNSDomain;
                              //string   DNSDomainSuffixSearchOrder[];
                              //boolean  DNSEnabledForWINSResolution;
                              //string   DNSHostName;
                              //string   DNSServerSearchOrder[];
                              //boolean  DomainDNSRegistrationEnabled;
                              //uint32   ForwardBufferMemory;
                              //boolean  FullDNSRegistrationEnabled;
                              //uint16   GatewayCostMetric[];
                              //uint8    IGMPLevel;
                              //uint32   Index;
                              //uint32   InterfaceIndex;
                              //string   IPAddress[];
                              //uint32   IPConnectionMetric;
                              //boolean  IPEnabled;
                              //boolean  IPFilterSecurityEnabled;
                              //boolean  IPPortSecurityEnabled;
                              //string   IPSecPermitIPProtocols[];
                              //string   IPSecPermitTCPPorts[];
                              //string   IPSecPermitUDPPorts[];
                              //string   IPSubnet[];
                              //boolean  IPUseZeroBroadcast;
                              //string   IPXAddress;
                              //boolean  IPXEnabled;
                              //uint32   IPXFrameType[];
                              //uint32   IPXMediaType;
                              //string   IPXNetworkNumber[];
                              //string   IPXVirtualNetNumber;
                              //uint32   KeepAliveInterval;
                              //uint32   KeepAliveTime;
                              //string   MACAddress;
                              //uint32   MTU;
                              //uint32   NumForwardPackets;
                              //boolean  PMTUBHDetectEnabled;
                              //boolean  PMTUDiscoveryEnabled;
                              //string   ServiceName;
                              //string   SettingID;
                              //uint32   TcpipNetbiosOptions;
                              //uint32   TcpMaxConnectRetransmissions;
                              //uint32   TcpMaxDataRetransmissions;
                              //uint32   TcpNumConnections;
                              //boolean  TcpUseRFC1122UrgentPointer;
                              //uint16   TcpWindowSize;
                              //boolean  WINSEnableLMHostsLookup;
                              //string   WINSHostLookupFile;
                              //string   WINSPrimaryServer;
                              //string   WINSScopeID;
                              //string   WINSSecondaryServer;
                        }
                    }


                }
                else {
                    this.TopMost = true;
                    connectedTochinaunicom();
                }
            }
        }

        private void connectedTochinaunicom() {
            label1.Text = "正在重制网络";
            var chinaunicom = from t in tt.ssids where t.SSID == "ChinaUnicom" select t;
            if (chinaunicom != null && chinaunicom.Count() > 0)
            {
                tt.ConnectToSSID(chinaunicom.First());
                isneedreset = true;
                Thread.Sleep(45000);
            }
            else
            {
                MessageBox.Show("未找到网络");
                mainThread.Abort();
                label1.Text = "因为未找到而终止";
            }    
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (mainThread != null && mainThread.IsAlive)
            {
                mainThread.Abort();
            }

            label1.Text = "已终止";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("CMD.EXE", "/c route delete 0.0.0.0");
            System.Diagnostics.Process.Start("CMD.EXE", "route add 0.0.0.0 mask 0.0.0.0 112.193.248.1");
            System.Diagnostics.Process.Start("CMD.EXE", "route add 10.0.0.0 mask 255.0.0.0 10.16.4.1");
        }
    }
}
