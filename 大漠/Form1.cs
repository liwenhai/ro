using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Soap;
using Dm;
using System.Xml.Serialization;


namespace 大漠
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            for (int i = 1; i < 13; i++)
            {
                atkSkillInput.Items.Add("F" + i);
                teleSkillInput.Items.Add("F" + i);
                hpSkillInput.Items.Add("F" + i);
            }
            Init();
        }

        public void Init(){
            try
            {
                var config = DeSerialize();
                setAssInfo(config.assistItemAndSkillInfo);
                atkSkillInput.Text = config.atkSkillKey.ToString();
                isAtkUseSkillCheckBox.Checked = config.atkUseSkill;
                teleSkillInput.Text = config.teleSkillKey.ToString();
                isTeleUseSkillCheckBox.Checked = config.teleUseSkill;
                hpSkillInput.Text = config.hpKey.ToString();
                isHpUseSkillCheckBox.Checked = config.hpUseSkill;
                isPickUpCheckBox.Checked = config.isPickUpItem;

            }
            catch (Exception)
            {
                SkillAndItem skillAndItem = new SkillAndItem();
                flowLayoutPanel1.Controls.Add(skillAndItem);

                atkSkillInput.SelectedIndex = 0;
                teleSkillInput.SelectedIndex = 0;
                hpSkillInput.SelectedIndex = 0;
            }    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dmsoft dm = new dmsoft();
            var xx = dm.FindPicEx(0, 0, 800, 800, "D:\\2.bmp", "000000", 1.0, 1).Split('|')[1].Split(',')[1];
            var yy = dm.FindPicEx(0, 0, 800, 800, "D:\\2.bmp", "000000", 1.0, 1).Split('|')[1].Split(',')[2];
            dm.MoveTo(int.Parse(xx), int.Parse(yy));
            //dm.RightClick();
            dm.LeftClick();
            //SendKeys.Send(13);
            //dm.delay(2000);
            //dm.LeftClick();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SkillAndItem skillAndItem = new SkillAndItem();
            flowLayoutPanel1.Controls.Add(skillAndItem);
            flowLayoutPanel1.Refresh();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ConfigInfo config = new ConfigInfo();
            config.assistItemAndSkillInfo = getAssInfo();
            config.atkSkillKey = getKeyEnumFromString(atkSkillInput.Text);
            config.atkUseSkill = isAtkUseSkillCheckBox.Checked;
            config.teleSkillKey = getKeyEnumFromString(teleSkillInput.Text);
            config.teleUseSkill = isTeleUseSkillCheckBox.Checked;
            config.hpKey = getKeyEnumFromString(hpSkillInput.Text);
            config.hpUseSkill = isHpUseSkillCheckBox.Checked;
            config.isPickUpItem = isPickUpCheckBox.Checked;
            Serialize(config);

            var files = Directory.GetFiles(System.Windows.Forms.Application.StartupPath+"\\Pic");
            foreach (var item in files)
            {
                if (item.IndexOf("atk") >= 0)
                {
                    config.monsPic += item + "|";
                    
                }

                if (item.IndexOf("pickup") >= 0)
                {
                    config.itemsPic += item + "|";
                }
            }
            config.monsPic = config.monsPic.Substring(0, config.monsPic.Length - 1);
            config.itemsPic = config.itemsPic.Substring(0, config.itemsPic.Length - 1);
            try
            {
                BaseAction action = new BaseAction("仙境传说");
                action.configInfo = config;
                action.mssageBox = messageInfoBox;
                action.processStep();
            }
            catch (Exception h)
            {
                MessageBox.Show(h.Message);                
            }
        }

        public List<AssistItemAndSkillInfo> getAssInfo() {
            List<AssistItemAndSkillInfo> asList = new List<AssistItemAndSkillInfo>();
            foreach (var item in flowLayoutPanel1.Controls)
            {
                var one = (SkillAndItem)item;
                AssistItemAndSkillInfo ais = new AssistItemAndSkillInfo();
                for (int i = 0; i < one.Controls.Count; i++)
                {
                    if (one.Controls[i].Name == "skillNameBox")
                    {
                        ais.skillName = one.Controls[i].Text;
                    }
                    if (one.Controls[i].Name == "skillCDTimeNum")
                    {
                        ais.skillDCTime = int.Parse(one.Controls[i].Text);
                    }
                    if (one.Controls[i].Name == "skillLastTimeNum")
                    {
                        ais.skillLastTime = int.Parse(one.Controls[i].Text);
                    }
                    if (one.Controls[i].Name == "keyInput")
                    {
                        ais.key = getKeyEnumFromString(one.Controls[i].Text);
                    }
                    if (one.Controls[i].Name == "checkBox5")
                    {
                        ais.isUseForMe = ((CheckBox)one.Controls[i]).Checked;
                    }
                    if (one.Controls[i].Name == "checkBox1")
                    {
                        ais.isUse = ((CheckBox)one.Controls[i]).Checked;
                    } 
                }
                asList.Add(ais);
            }
            return asList;
        }

        public void setAssInfo(List<AssistItemAndSkillInfo> list)
        {
            foreach (var item in list)
            {
                SkillAndItem one = new SkillAndItem();
                for (int i = 0; i < one.Controls.Count; i++)
                {
                    if (one.Controls[i].Name == "skillNameBox")
                    {
                        one.Controls[i].Text = item.skillName;
                    }
                    if (one.Controls[i].Name == "skillCDTimeNum")
                    {
                        one.Controls[i].Text = item.skillDCTime.ToString();
                    }
                    if (one.Controls[i].Name == "skillLastTimeNum")
                    {
                        one.Controls[i].Text = item.skillLastTime.ToString();
                    }
                    if (one.Controls[i].Name == "keyInput")
                    {
                        one.Controls[i].Text = item.key.ToString();
                    }
                    if (one.Controls[i].Name == "checkBox5")
                    {
                        ((CheckBox)one.Controls[i]).Checked = item.isUseForMe;
                    }
                    if (one.Controls[i].Name == "checkBox1")
                    {
                        ((CheckBox)one.Controls[i]).Checked = item.isUse;
                    }
                    flowLayoutPanel1.Controls.Add(one);
                }
            }
        }

        public KeyEnum getKeyEnumFromString(string key) {
            return (KeyEnum)Enum.Parse(typeof(KeyEnum), key);
        }


        public void Serialize(ConfigInfo config)
        {
            using (FileStream fs = new FileStream(System.Windows.Forms.Application.StartupPath+"\\atkConfig.xml", FileMode.Create))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(ConfigInfo));
                formatter.Serialize(fs, config);
            }
        }

        public ConfigInfo DeSerialize()
        {
            ConfigInfo configInfo;
            using (FileStream fs = new FileStream(System.Windows.Forms.Application.StartupPath + "\\atkConfig.xml", FileMode.Open))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(ConfigInfo));
                configInfo = (ConfigInfo)formatter.Deserialize(fs);
            }
            return configInfo;
        }
        
                      
    }
}
