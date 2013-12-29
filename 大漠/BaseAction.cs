using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dm;
using System.Xml.Serialization;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using QMDISPATCHLib;
using System.Drawing;
using System.Diagnostics;

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
        public int atkLastTimeNum = 4;
        public bool isCheckMonsterCountAndFly = false;
        public int monsterFlyCount;
        public double teleDelayTime = 2;
        public string monsterColorSimile = "505050";
        public double monsterSharpSimiler = 0.7;
        public bool atkSkillFinishFly = false;
        public int atkFlyTimes = 4;
        public string pickupFlagPic;
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
        int winCenterX;
        int winCenterY;
        dmsoft opTool;
        public ConfigInfo configInfo;
        public RichTextBox mssageBox;
        Thread mainThread;
        Thread hpThread;
        
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
            winCenterX = winLeftTopX + 400;
            winCenterY = winLeftTopY + 300;
        }

        

        /// <summary>
        /// 瞬间移动技能
        /// </summary>
        /// teleType=0 使用苍蝇翅膀瞬间移动 teleType=1 使用技能瞬间移动
        public void teleport()
        {
            addLog("瞬间移动", 0);
            //Thread.Sleep(1000);
            opTool.KeyPress((int)configInfo.teleSkillKey);    
            if(configInfo.teleUseSkill){
                Thread.Sleep((int)configInfo.teleDelayTime*1000);
                keyPress(KeyEnum.Enter); 
            }
            Thread.Sleep((int)configInfo.teleDelayTime * 1000);
        }
        
        /// <summary>
        /// 打怪 物理攻击使用ctrl锁定打怪 技能攻击使用技能打怪
        /// </summary>
        /// <param name="useSkill">是否使用技能</param>
        public bool atkMonster(int monsterPostion_X, int monsterPostion_Y, bool useSkill,KeyEnum skillKey,string monsterName)
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
            addLog("打怪-" + Path.GetFileName(monsterName), 0);
            if (configInfo.atkLastTimeNum > 2)
            {
                //检查是否卡屏
                int islag = opTool.IsDisplayDead(winLeftTopX + 300, winLeftTopY + 30, winLeftTopX + 300 + 10, winLeftTopY + 30 + 10, 2);
                //卡屏就直接返回
                //判断怪物是否在身边
                bool isMonsterNeedByMe = false;

                if (((winCenterX + 70) > monsterPostion_X)
                   && ((winCenterX - 70) < monsterPostion_X)
                   && ((winCenterY + 70) > monsterPostion_Y)
                   && ((winCenterY - 70) < monsterPostion_Y))
                {
                       isMonsterNeedByMe = true;   
                }

                if (islag == 1 && isMonsterNeedByMe==false)
                {
                    addLog("检查到卡屏重新战斗", 0);
                    return false;
                }

                for (int i = 0; i < (configInfo.atkLastTimeNum - 2)/2; i++)
                {
                    if(checkItemAroundMe()){
                        checkItemAroundMe();
                        return false;
                    }    
                }
                //Thread.Sleep( * 1000);
            }
            else {
                Thread.Sleep(configInfo.atkLastTimeNum * 1000);
                checkItemAroundMe();
            }

            return true;
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
            opTool.MoveTo(winCenterX, winCenterY);    
        }

        /// <summary>
        /// 查找指定坐标的是否有给定的颜色
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public bool findColor(int x,int y,string color) {
            var tt = opTool.GetColor(x, y);
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
            return findColor(winLeftTopX + 158 - 20, winLeftTopY + 84, "f7f7f7");
        }

        /// <summary>
        /// 检查SP是否过低
        /// </summary>
        /// <returns></returns>
        public bool isSpLow()
        {
            return findColor(winLeftTopX + 65, winLeftTopY + 99, "f7f7f7");
        }

        /// <summary>
        /// 寻找指定的图片信息
        /// </summary>
        /// <param name="pics"></param>
        /// <returns></returns>
        public List<PicInfo> FindPicList(string pics,string colorSimiler,double photoSimiler)
        {
            List<PicInfo> list = new List<PicInfo>();
            List<Point> pointList = new List<Point>();
            string res = opTool.FindPicEx(winLeftTopX, winLeftTopY, winRightDownX, winRightDownY, pics, colorSimiler, photoSimiler, 0);
            if (res.Trim() == "") 
            {
                return list;
            }
            var strList = res.Split('|');
            var picsArray = pics.Split('|');
            for (int i = 0; i < strList.Length; i++)
            {
                PicInfo oneMonster = new PicInfo();
                if (int.Parse(strList[i].Split(',')[1]) + winLeftTopX < 250 && int.Parse(strList[i].Split(',')[2]) + winLeftTopY < 250)
                {
                    continue;
                }
                else {
                    
                    oneMonster.positionX = int.Parse(strList[i].Split(',')[1]);
                    oneMonster.positionY = int.Parse(strList[i].Split(',')[2]);
                    Point po = new Point();
                    po.X = oneMonster.positionX;
                    po.Y = oneMonster.positionY;
                    if (!checkPointIsExit(pointList, po)) {
                        oneMonster.picName = picsArray[int.Parse(strList[i].Split(',')[0])];
                        list.Add(oneMonster);
                        pointList.Add(po);
                    }
                }
            }
            //var picsarray = pics.Split('|');
            //for (int i = 0; i < picsarray.Length; i++)
            //{
            //    object x;
            //    object y;
            //    var isfind = opTool.FindPic(winLeftTopX, winLeftTopY, winRightDownX, winRightDownY, pics, "707070", 0.6, 0, out x, out y);
            //    int xx = (int)x;
            //    int yy = (int)y;
            //    if (xx > 0 && yy > 0)
            //    {
            //        PicInfo oneMonster = new PicInfo();
            //        oneMonster.positionX = xx;
            //        oneMonster.positionY = yy;
            //        oneMonster.picName = picsarray[i];
            //        list.Add(oneMonster);
            //        break;
            //    }
            //}

            //QMFunctionClass ff = new QMFunctionClass();
            //var picsarray = pics.Split('|');
            //for (int i = 0; i < picsarray.Length; i++)
            //{
            //    //object x;
            //    //object y;
            //    //var isfind = opTool.FindPic(winLeftTopX, winLeftTopY, winRightDownX, winRightDownY, pics, "000000", 0.6, 0, out x, out y);
            //    int d = ff.FindPic(0, 0, 1280, 800, pics, 0.5f);

            //    int xx = d / 8192;
            //    int yy = d % 8192;
            //    if (xx > 0 && yy > 0)
            //    {
            //        PicInfo oneMonster = new PicInfo();
            //        oneMonster.positionX = xx;
            //        oneMonster.positionY = yy;
            //        oneMonster.picName = picsarray[i];
            //        list.Add(oneMonster);
            //        break;
            //    }
            //}


            //var picsarray = pics.Split('|');
            //for (int i = 0; i < picsarray.Length; i++)
            //{
            //    //Bitmap bmp = BmpColor.CopyScreen(new Rectangle() { Y = winLeftTopY, X = winLeftTopX, Width = winRightDownX, Height = winRightDownY });

            //    //Bitmap bmp1 = new Bitmap(picsarray[i]);

            //    Bitmap bmp = BmpColor.CopyScreen(new Rectangle() { Y = 0, X = 0, Width = 1280, Height = 800 });

            //    Bitmap bmp1 = new Bitmap(picsarray[i]);
            //    var tt = BmpColor.FindPic(0, 0, 1280, 800, bmp, bmp1, 1);
                
            //    //var tt = BmpColor.FindPic(0, 0, 1280, 800, bmp, bmp1, 1);
            //    for (int j = 0; j < tt.Count; j++)
            //    {
            //        PicInfo oneMonster = new PicInfo();
            //        oneMonster.positionX = tt[j].X;
            //        oneMonster.positionY = tt[j].X;
            //        oneMonster.picName = picsarray[i];
            //        list.Add(oneMonster);    
            //    }
            //    bmp.Dispose();
            //    bmp1.Dispose();
            //}


            
            
            return list;
        }

        public bool checkPointIsExit(List<Point> list, Point point)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].X + 15 > point.X
                    && list[i].Y + 15 > point.Y
                    && list[i].X - 15 < point.X
                    && list[i].X - 15 < point.Y)
                {
                    return true;
                }
            }

            return false;
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
                    while (true)
                    {
                        var itemList = FindPicList(configInfo.monsPic, configInfo.monsterColorSimile, configInfo.monsterSharpSimiler);
                        if (itemList.Count > 1)
                        {
                            addLog("使用辅助技能时发现怪物飞", 0);
                            teleport();
                        }
                        else
                        {
                            break;
                        }
                    }
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
                Thread.Sleep(500);
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
                var itemList = FindPicList(itemPics, "000000", 0.8);
                addLog("检查地上掉落的物品数量" + itemList.Count, -1);
                if (itemList.Count < 1) {
                    break;
                }
                for (int i = 0; i < itemList.Count; i++)
                {
                    addLog("捡物-" + Path.GetFileName(itemList[i].picName), 0);
                    opTool.MoveTo(itemList[i].positionX, itemList[i].positionY);
                    opTool.LeftClick();
                    Thread.Sleep(1500);
                    break;
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
                if (outTimes >=configInfo.atkFlyTimes)
                {
                    addLog("跳出循环", -1);
                    break;
                }
                addLog("3", -1);
                Stopwatch sw = new Stopwatch();
                sw.Start(); //计时开始
                var itemList = FindPicList(monPics, configInfo.monsterColorSimile, configInfo.monsterSharpSimiler);
                sw.Stop();   //计时结束
                addLog("时间:"+(sw.ElapsedMilliseconds).ToString(),0);
                //addLog("发现怪物：" + itemList.Count,0);
                if (itemList.Count < 1)
                {
                    break;
                }
                else { 
                    //如果启用了怪物数量超标飞就飞
                    if (configInfo.isCheckMonsterCountAndFly && itemList.Count >= configInfo.monsterFlyCount)
                    {
                        addLog("怪物数量超过" + configInfo.monsterFlyCount + "使用瞬间移动", 0);
                        teleport();
                        continue;
                    }
                }
                bool isAtkSucess = true;
                for (int i = 0; i < 1; i++)
                {
                    isAtkSucess = atkMonster(itemList[i].positionX, itemList[i].positionY, useSkill, key, itemList[i].picName);
                    //打完怪物后向右移动100像素 以免挡住捡物
                    if (configInfo.isPickUpItem) {
                        opTool.MoveTo(winLeftTopX + 400 + 100, winLeftTopY + 300);
                        opTool.LeftClick();
                        Thread.Sleep(800);
                    }
                    if (isHpLow())
                    {
                        addLog("血量过低", -1);
                        addHp(configInfo.hpUseSkill, configInfo.hpKey);
                        teleport();
                    }
                }
                if (isAtkSucess) {
                    outTimes++;
                }
                
            }

        }

        public void start() {
            addLog("开始挂机", 0);
            mainThread = new Thread(new ThreadStart(processStep));
            mainThread.Start();
            hpThread = new Thread(new ThreadStart(checkHp));
            hpThread.Start();
        }

        public void stop()
        {
            addLog("停止挂机", 0);
            mainThread.Abort();
            hpThread.Abort();
        }

        public void checkHp() {
            try
            {
                while (true) {
                    if (isHpLow())
                    {
                        try
                        {
                            //mainThread.Abort();
                        }
                        catch (Exception)
                        {
                        }
                        addHp(configInfo.hpUseSkill, configInfo.hpKey);
                        addHp(configInfo.hpUseSkill, configInfo.hpKey);
                        addHp(configInfo.hpUseSkill, configInfo.hpKey);
                        addHp(configInfo.hpUseSkill, configInfo.hpKey);
                        teleport();
                        //addHp(configInfo.hpUseSkill, configInfo.hpKey);
                    }
                    Thread.Sleep(2000);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public bool checkItemAroundMe() {
            int stepHeight = 30;
            int stepWidth = 30;

            //包围距离
            int leftMeDistance = 1;
            int startX = winCenterX - stepWidth * leftMeDistance;
            int startY = winCenterY - stepWidth * leftMeDistance;

            for (int x = 0; x < leftMeDistance*2+1; x++)
            {
                for (int y = 0; y < leftMeDistance * 2 + 1; y++)
                {
                    opTool.MoveTo(startX + x * stepWidth, startY + y * stepHeight);
                    Thread.Sleep(200);
                    var pints = FindPicList(configInfo.pickupFlagPic, "101010", 1);
                    if (pints.Count > 0) {
                        opTool.LeftClick();
                        Thread.Sleep(500);
                        return true;
                    }
                    
                }    
            }
            return false;
        }

        /// <summary>
        /// 挂机流程
        /// </summary>
        public void processStep() {
            try
            {
                while (true)
                {
                    //检查并使用辅助技能
                    checkAndUesAssist(configInfo.assistItemAndSkillInfo);
                    //Hp过低时开始补血
                    addLog("开始检查血量是否过低", -1);
                    if (isHpLow())
                    {
                        addLog("血量过低", -1);
                        addHp(configInfo.hpUseSkill, configInfo.hpKey);
                        addHp(configInfo.hpUseSkill, configInfo.hpKey);
                    }
                    addLog("开始寻怪打怪", -1);
                    //寻找怪物并打怪 最多连续打四次防止卡图
                    findAndAtkMonster(configInfo.monsPic, configInfo.atkUseSkill, configInfo.atkSkillKey);
                    //有捡物设定时开始捡物
                    if (configInfo.isPickUpItem)
                    {
                        addLog("开始捡物", -1);
                        pickUpItem(configInfo.itemsPic);
                    }
                    //瞬间移动
                    teleport();
                    //addLog("step结束", -1);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void keyPress(KeyEnum key)
        {
            opTool.KeyPress((int)key);    
        }

        int logTime = 0;
        
        /// <summary>
        /// 增加日志
        /// </summary>
        /// <param name="msg">日志内容</param>
        /// <param name="logType">日志类型 0:普通 -1:调试</param>
        public void addLog(string msg,int logType) { 
            //messageInfoBox
            if (logType == -1)
            {
                return;
            }

            if (logTime == 50) {
                logTime = 0;
                mssageBox.Clear();
            }
            mssageBox.AppendText(DateTime.Now.ToString("HH:mm:ss") + " - " + msg + "\r\n");
            mssageBox.SelectionStart = mssageBox.Text.Length;
            mssageBox.ScrollToCaret();
            logTime++;
        }


    }
}
