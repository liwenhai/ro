using System;
using System.Collections.Generic;
using System.Text;
using NativeWifi;


namespace NativeWifi
{
    class MyWifi
    {
        public List<WIFISSID> ssids = new List<WIFISSID>();
        WlanClient client;

        public MyWifi()
        {
            ssids.Clear();
        }


        static string GetStringForSSID(Wlan.Dot11Ssid ssid)
        {
            return Encoding.UTF8.GetString(ssid.SSID, 0, (int)ssid.SSIDLength);
        }

        /// <summary>
        /// 枚举所有无线设备接收到的SSID
        /// </summary>
        public void ScanSSID()
        {
            ssids.Clear();
            if (client == null) {
                client = new WlanClient();
            }
            foreach (WlanClient.WlanInterface wlanIface in client.Interfaces)
            {
                // Lists all networks with WEP security
                Wlan.WlanAvailableNetwork[] networks = wlanIface.GetAvailableNetworkList(0);
                foreach (Wlan.WlanAvailableNetwork network in networks)
                {
                    WIFISSID targetSSID = new WIFISSID();

                    targetSSID.wlanInterface = wlanIface;
                    targetSSID.wlanSignalQuality = (int)network.wlanSignalQuality;
                    targetSSID.SSID = GetStringForSSID(network.dot11Ssid);
                    //targetSSID.SSID = Encoding.Default.GetString(network.dot11Ssid.SSID, 0, (int)network.dot11Ssid.SSIDLength);
                    targetSSID.dot11DefaultAuthAlgorithm = network.dot11DefaultAuthAlgorithm.ToString();
                    targetSSID.dot11DefaultCipherAlgorithm = network.dot11DefaultCipherAlgorithm.ToString();
                    targetSSID.flags = network.flags;
                    ssids.Add(targetSSID);

                    //if ( network.dot11DefaultCipherAlgorithm == Wlan.Dot11CipherAlgorithm.WEP )
                    //{
                    //    Console.WriteLine( "Found WEP network with SSID {0}.", GetStringForSSID(network.dot11Ssid));
                    //}
                    //Console.WriteLine("Found network with SSID {0}.", GetStringForSSID(network.dot11Ssid));
                    //Console.WriteLine("dot11BssType:{0}.", network.dot11BssType.ToString());
                    //Console.WriteLine("dot11DefaultAuthAlgorithm:{0}.", network.dot11DefaultAuthAlgorithm.ToString());
                    //Console.WriteLine("dot11DefaultCipherAlgorithm:{0}.", network.dot11DefaultCipherAlgorithm.ToString());
                    //Console.WriteLine("dot11Ssid:{0}.", network.dot11Ssid.ToString());

                    //Console.WriteLine("flags:{0}.", network.flags.ToString());
                    //Console.WriteLine("morePhyTypes:{0}.", network.morePhyTypes.ToString());
                    //Console.WriteLine("networkConnectable:{0}.", network.networkConnectable.ToString());
                    //Console.WriteLine("numberOfBssids:{0}.", network.numberOfBssids.ToString());
                    //Console.WriteLine("profileName:{0}.", network.profileName.ToString());
                    //Console.WriteLine("wlanNotConnectableReason:{0}.", network.wlanNotConnectableReason.ToString());
                    //Console.WriteLine("wlanSignalQuality:{0}.", network.wlanSignalQuality.ToString());
                    //Console.WriteLine("-----------------------------------");
                    // Console.WriteLine(network.ToString());
                }
            }
        } // EnumSSID


        /// <summary>
        /// 连接到未加密的SSID
        /// </summary>
        /// <param name="ssid"></param>
        public void ConnectToSSID(WIFISSID ssid)
        {
            // Connects to a known network with WEP security
            string profileName = ssid.SSID; // this is also the SSID

            string mac = StringToHex(profileName); // 

            //string key = "";
            //string profileXml = string.Format("<?xml version=\"1.0\"?><WLANProfile xmlns=\"http://www.microsoft.com/networking/WLAN/profile/v1\"><name>{0}</name><SSIDConfig><SSID><hex>{1}</hex><name>New{0}</name></SSID></SSIDConfig><connectionType>ESS</connectionType><MSM><security><authEncryption><authentication>open</authentication><encryption>none</encryption><useOneX>false</useOneX></authEncryption><sharedKey><keyType>networkKey</keyType><protected>false</protected><keyMaterial>{2}</keyMaterial></sharedKey><keyIndex>0</keyIndex></security></MSM></WLANProfile>", profileName, mac, key);
            //string profileXml2 = "<?xml version=\"1.0\"?><WLANProfile xmlns=\"http://www.microsoft.com/networking/WLAN/profile/v1\"><name>Hacker SSID</name><SSIDConfig><SSID><hex>54502D4C494E4B5F506F636B657441505F433844323632</hex><name>TP-LINK_PocketAP_C8D262</name></SSID>        </SSIDConfig>        <connectionType>ESS</connectionType><connectionMode>manual</connectionMode><MSM> <security><authEncryption><authentication>open</authentication><encryption>none</encryption><useOneX>false</useOneX></authEncryption></security></MSM></WLANProfile>";
            //wlanIface.SetProfile( Wlan.WlanProfileFlags.AllUser, profileXml2, true );
            //wlanIface.Connect( Wlan.WlanConnectionMode.Profile, Wlan.Dot11BssType.Any, profileName );
            string myProfileXML = string.Format("<?xml version=\"1.0\"?>"
                                                    +"<WLANProfile xmlns=\"http://www.microsoft.com/networking/WLAN/profile/v1\">"
                                                        +"<name>{0}</name>"
                                                        +"<SSIDConfig>"
                                                            +"<SSID><hex>{1}</hex><name>{0}</name></SSID>"
                                                        +"</SSIDConfig>"
                                                        +"<connectionType>ESS</connectionType>"
                                                        +"<connectionMode>manual</connectionMode>"
                                                        +"<MSM>"
                                                            +"<security>"
                                                                +"<authEncryption>"
                                                                    +"<authentication>open</authentication>"
                                                                    +"<encryption>none</encryption>"
                                                                    +"<useOneX>false</useOneX>"
                                                                +"</authEncryption>"
                                                            +"</security>"
                                                        +"</MSM>"
                                                    +"</WLANProfile>", profileName, mac);
            ssid.wlanInterface.SetProfile(Wlan.WlanProfileFlags.AllUser, myProfileXML, true);
            ssid.wlanInterface.Connect(Wlan.WlanConnectionMode.Profile, Wlan.Dot11BssType.Any, profileName);
            //Console.ReadKey();
        }

        /// <summary>
        /// 字符串转Hex
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string StringToHex(string str)
        {
            StringBuilder sb = new StringBuilder();
            byte[] byStr = System.Text.Encoding.Default.GetBytes(str); //默认是System.Text.Encoding.Default.GetBytes(str)
            for (int i = 0; i < byStr.Length; i++)
            {
                sb.Append(Convert.ToString(byStr[i], 16));
            }

            return (sb.ToString().ToUpper());
        }
    }

    class WIFISSID
    {
        public string SSID = "NONE";
        public string dot11DefaultAuthAlgorithm = "";
        public string dot11DefaultCipherAlgorithm = "";
        public bool networkConnectable = true;
        public string wlanNotConnectableReason = "";
        public int wlanSignalQuality = 0;
        public WlanClient.WlanInterface wlanInterface = null;
        public NativeWifi.Wlan.WlanAvailableNetworkFlags flags;
    }

}