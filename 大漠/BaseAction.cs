using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dm;
using System.Xml.Serialization;
using System.Windows.Forms;

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
            opTool.KeyPress((int)teleKey);    
            if(useSkill){
                opTool.delay(1000);
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
            opTool.delay(100);
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
            string res = opTool.FindPicEx(winLeftTopX, winLeftTopY, winRightDownX, winRightDownY, pics, "000000", 0.6, 0);
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
            for (int i = 0; i < isInfo.Count; i++)
            {
                TimeSpan timeSpan = DateTime.Now - isInfo[i].lastUseTime;
                if (timeSpan.TotalSeconds > isInfo[i].skillLastTime && isInfo[i].isUse)
                {
                    if (isInfo[i].isUseForMe)
                    {
                        //向自己使用技能
                        useSkillForMe(isInfo[i].key);
                    }
                    else { 
                        //直接使用技能
                        keyPress(isInfo[i].key);
                    }
                    //按照CD时间延迟
                    opTool.delay(isInfo[i].skillDCTime);
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
                useSkillForMe(hpKey);
            }
            else {
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
                for (int i = 0; i < itemList.Count; i++)
                {
                    opTool.MoveTo(itemList[i].positionX, itemList[i].positionY);
                    opTool.delay(3000);
                    opTool.LeftClick();
                }
                outTimes++;
            }
        }

        public void findAndAtkMonster(string monPics,bool useSkill,KeyEnum key) {
            int outTimes = 0;
            while (true)
            {
                if (outTimes >= 4)
                {
                    break;
                }
                var itemList = FindPicList(monPics);
                for (int i = 0; i < itemList.Count; i++)
                {
                    atkMonster(itemList[i].positionX, itemList[i].positionY, useSkill, key);
                }
                outTimes++;
            }
        }

        /// <summary>
        /// 挂机流程
        /// </summary>
        public void processStep() {
            addLog("初始化数据", 0);
            //检查并使用辅助技能
            checkAndUesAssist(configInfo.assistItemAndSkillInfo);
            //Hp过低时开始补血
            if(isHpLow()){
                addHp(configInfo.hpUseSkill,configInfo.hpKey);                    
            }
            //有捡物设定时开始捡物
            if(configInfo.isPickUpItem){
                pickUpItem(configInfo.itemsPic);
            }
            //寻找怪物并打怪 最多连续打四次防止卡图
            findAndAtkMonster(configInfo.monsPic,configInfo.atkUseSkill,configInfo.atkSkillKey);
            //瞬间移动
            teleport(configInfo.teleUseSkill, configInfo.teleSkillKey);
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
            mssageBox.Text += DateTime.Now.ToShortTimeString() + "_" + msg;
        }
    }
}
