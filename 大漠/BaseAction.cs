using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dm;
using System.Xml.Serialization;
using System.Windows.Forms;
using System.Threading;

namespace 大漠
{
    [Serializable]
    public class ConfigInfo {
        //辅助技能信息
        public List<AssistItemAndSkillInfo> assistItemAndSkillInfo;
        //是否捡物
        public bool isPickUpItem;
        public bool hpUseSkill;
        public KeyEnum hpKey;
        public bool atkUseSkill;
        public KeyEnum atkSkillKey;
        public bool teleUseSkill;
        public KeyEnum teleSkillKey;
        public string itemsPic;
        public string monsPic;
    }

    class PicInfo{
        public int positionX = -1;
        public  int positionY = -1;
        public  string picName;
        public  bool isFly = false;
        public  bool isAtk = true;
        public  bool isPicUp = true;
    }

    [Serializable]
    public class AssistItemAndSkillInfo
    { 
        public string skillName = "";
        //技能持续使用时间
        public int skillLastTime = 100;
        //技能冷却时间
        public int skillDCTime = 5;
        //对应按键
        public KeyEnum key;
        //是否启用
        public bool isUse;
        //是否向自己使用
        public bool isUseForMe;
        //上一次使用时间
        public DateTime lastUseTime;
    }

    [Serializable]
    public enum KeyEnum
    {
        F1 = 112,F2 = 113,F3 = 114,F4 = 115,F5 = 116,
        F6 = 117,F7 = 118,F8 = 119,F9 = 120,F10 = 121,
        F11 = 122,F12 = 123,Ctrl = 17,Enter = 13,
    };

    class BaseAction
    {
        int winLeftTopX;
        int winLeftTopY;
        int winRightDownX;
        int winRightDownY;
        dmsoft opTool;
        public ConfigInfo configInfo;
        public RichTextBox mssageBox;
        Thread thread;
        
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="processName"></param>
        public BaseAction(string processName){
            configInfo = new ConfigInfo();
            opTool = new dmsoft();
            int hwnd = opTool.FindWindow("", processName);
            if (hwnd <= 0) {
                throw new Exception("无法获取指定窗口");
            }
            //激活窗口
            opTool.SetWindowState(hwnd, 1);
            opTool.MoveWindow(hwnd, 15, 15);

            object x1 = new object();
            object y1 = new object();
            object x2 = new object();
            object y2 = new object();
            opTool.GetWindowRect(hwnd, out x1, out y1, out x2, out y2);
            winLeftTopX = (int)x1;
            winLeftTopY = (int)y1;
            winRightDownX = (int)x2; 
            winRightDownY = (int)y2; 
        }

        

        /// <summary>
        /// 瞬间移动技能
        /// </summary>
        /// teleType=0 使用苍蝇翅膀瞬间移动 teleType=1 使用技能瞬间移动
        public void teleport(bool useSkill,KeyEnum teleKey)
        {
            addLog("瞬间移动", 0);
            Thread.Sleep(1000);
            opTool.KeyPress((int)teleKey);    
            if(useSkill){
                Thread.Sleep(1000);
                keyPress(KeyEnum.Enter); 
            }
        }
        
        /// <summary>
        /// 打怪 物理攻击使用ctrl锁定打怪 技能攻击使用技能打怪
        /// </summary>
        /// <param name="useSkill">是否使用技能</param>
        public void atkMonster(int monsterPostion_X, int monsterPostion_Y, bool useSkill,KeyEnum skillKey)
        { 
            if(useSkill){
                keyPress(skillKey);     
            }
            opTool.MoveTo(monsterPostion_X,monsterPostion_Y);
            if(useSkill){
                opTool.LeftClick();
            }else{
                opTool.KeyDown((int)KeyEnum.Ctrl); 
                opTool.LeftClick();
                opTool.KeyUp((int)KeyEnum.Ctrl); 
            }  
        }

        /// <summary>
        /// 对自己使用指定的技能
        /// </summary>
        /// <param name="skillKey"></param>
        public void useSkillForMe(KeyEnum skillKey){
            keyPress(skillKey);
            Thread.Sleep(100);
            mouseMoveToCenter();
            opTool.LeftClick();
        }

        //鼠标移动到屏幕中央(自己角色所在位置)
        public void mouseMoveToCenter(){
            opTool.MoveTo(winLeftTopX+400,winLeftTopY+300);    
        }

        /// <summary>
        /// 查找指定坐标的是否有给定的颜色
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public bool findColor(int x,int y,string color) { 
            if (opTool.GetColor(x, y) == color) {
                return true; 
            }
            return false;
        }

        /// <summary>
        /// 检查HP是否过低
        /// </summary>
        /// <returns></returns>
        public bool isHpLow() {
            return findColor(winLeftTopX + 158 - 20, winLeftTopY + 59, "f7f7f7");
        }

        /// <summary>
        /// 检查SP是否过低
        /// </summary>
        /// <returns></returns>
        public bool isSpLow()
        {
            return findColor(winLeftTopX + 65, winLeftTopY + 74, "f7f7f7");
        }

        /// <summary>
        /// 寻找指定的图片信息
        /// </summary>
        /// <param name="pics"></param>
        /// <returns></returns>
        public List<PicInfo> FindPicList(string pics)
        {
            List<PicInfo> list = new List<PicInfo>();
            string res = opTool.FindPicEx(winLeftTopX, winLeftTopY, winRightDownX, winRightDownY, pics, "000000", 0.7, 0);
            if (res.Trim() == "") {
                return list;
            }
            var strList = res.Split('|');
            var picsArray = pics.Split('|');
            for (int i = 0; i < strList.Length; i++)
            {
                PicInfo oneMonster = new PicInfo();
                oneMonster.positionX = int.Parse(strList[i].Split(',')[1]);
                oneMonster.positionY = int.Parse(strList[i].Split(',')[2]);
                oneMonster.picName = picsArray[int.Parse(strList[i].Split(',')[0])];
            }
            return list;
        }

        /// <summary>
        /// 检查并使用辅助技能
        /// </summary>
        public void checkAndUesAssist(List<AssistItemAndSkillInfo> isInfo) {
            addLog("isInfo.Count" + isInfo.Count, -1);
            for (int i = 0; i < isInfo.Count; i++)
            {
                TimeSpan timeSpan = DateTime.Now - isInfo[i].lastUseTime;
                addLog("timeSpan" + timeSpan, -1);
                if (timeSpan.TotalSeconds > isInfo[i].skillLastTime && isInfo[i].isUse)
                {
                    addLog("使用技能" + isInfo[i].skillName, 0);
                    if (isInfo[i].isUseForMe)
                    {
                        //向自己使用技能
                        useSkillForMe(isInfo[i].key);
                    }
                    else { 
                        //直接使用技能
                        keyPress(isInfo[i].key);
                    }
                    isInfo[i].lastUseTime = DateTime.Now;
                    //按照CD时间延迟
                    addLog("opTool.delay_start",-1);
                    Thread.Sleep(isInfo[i].skillDCTime * 1000);
                    addLog("opTool.delay_end",-1);
                }     
            }                
        }

        /// <summary>
        /// 加血
        /// </summary>
        /// <param name="useSkill"></param>
        /// <param name="hpKey"></param>
        public void addHp(bool useSkill,KeyEnum hpKey) {
            
            if (useSkill)
            {
                addLog("Hp过低使用治愈术", 0);
                useSkillForMe(hpKey);
            }
            else {
                addLog("Hp过低使用HP药物", 0);
                keyPress(hpKey);
            }    
        }


        public void pickUpItem(string itemPics) {
            int outTimes = 0;
            while (true) {
                if (outTimes >= 4) {
                    break;
                }
                var itemList = FindPicList(itemPics);
                addLog("检查地上掉落的物品数量" + itemList.Count, -1);
                if (itemList.Count < 1) {
                    break;
                }
               
                for (int i = 0; i < itemList.Count; i++)
                {
                    addLog("发现物品开始捡物" + itemList[i].picName, 0);
                    opTool.MoveTo(itemList[i].positionX, itemList[i].positionY);
                    Thread.Sleep(3000);
                    //opTool.delay(3000);
                    opTool.LeftClick();
                }
                outTimes++;
            }
        }

        public void findAndAtkMonster(string monPics,bool useSkill,KeyEnum key) {
            int outTimes = 0;
            addLog("1", -1);
            while (true)
            {
                addLog("2", -1);
                if (outTimes >= 4)
                {
                    break;
                }
                addLog("3", -1);
                var itemList = FindPicList(monPics);
                addLog("检查怪物数量" + itemList.Count, -1);
                if (itemList.Count < 1) {
                    break;
                }
                for (int i = 0; i < itemList.Count; i++)
                {
                    addLog("发现怪物打怪" + itemList[i].picName, 0);
                    atkMonster(itemList[i].positionX, itemList[i].positionY, useSkill, key);
                }
                outTimes++;
            }
        }

        public void start() {
            addLog("开始挂机", 0);
            thread = new Thread(new ThreadStart(processStep));
            thread.Start();
        }

        public void stop()
        {
            addLog("停止挂机", 0);
            thread.Abort();
        }

        /// <summary>
        /// 挂机流程
        /// </summary>
        public void processStep() {
            while (true) {
                //检查并使用辅助技能
                checkAndUesAssist(configInfo.assistItemAndSkillInfo);
                //Hp过低时开始补血
                addLog("开始检查血量是否过低", -1);
                if (isHpLow())
                {
                    addLog("血量过低", -1);
                    addHp(configInfo.hpUseSkill, configInfo.hpKey);
                }
                addLog("开始检查捡物设置", -1);
                //有捡物设定时开始捡物
                if (configInfo.isPickUpItem)
                {
                    addLog("开始捡物", -1);
                    pickUpItem(configInfo.itemsPic);
                }
                addLog("开始寻怪打怪", -1);
                //寻找怪物并打怪 最多连续打四次防止卡图
                findAndAtkMonster(configInfo.monsPic, configInfo.atkUseSkill, configInfo.atkSkillKey);
                //瞬间移动
                teleport(configInfo.teleUseSkill, configInfo.teleSkillKey);
                //addLog("step结束", -1);
            }
        }

        public void keyPress(KeyEnum key)
        {
            opTool.KeyPress((int)key);    
        }
        
        /// <summary>
        /// 增加日志
        /// </summary>
        /// <param name="msg">日志内容</param>
        /// <param name="logType">日志类型 0:普通 -1:调试</param>
        public void addLog(string msg,int logType) { 
            //messageInfoBox
            mssageBox.AppendText(DateTime.Now.ToString("HH:mm:ss") + " - " + msg + "\r\n");
            mssageBox.SelectionStart = mssageBox.Text.Length;
            mssageBox.ScrollToCaret(); 
        }


    }
}
