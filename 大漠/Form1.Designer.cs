namespace 大漠
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.atkLastTimeNum = new System.Windows.Forms.NumericUpDown();
            this.isAtkUseSkillCheckBox = new System.Windows.Forms.CheckBox();
            this.atkSkillInput = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.isHpUseSkillCheckBox = new System.Windows.Forms.CheckBox();
            this.hpSkillInput = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.isTeleUseSkillCheckBox = new System.Windows.Forms.CheckBox();
            this.teleSkillInput = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.isPickUpCheckBox = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.messageInfoBox = new System.Windows.Forms.RichTextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.monsterFlyCountNum = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.isCheckMonsterCountAndFlyBox = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.teleDelayTimeNum = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.monsterColorSimileNum = new System.Windows.Forms.TextBox();
            this.monsterSharpSimilerNum = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.atkLastTimeNum)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.monsterFlyCountNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teleDelayTimeNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.monsterSharpSimilerNum)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.atkLastTimeNum);
            this.groupBox1.Controls.Add(this.isAtkUseSkillCheckBox);
            this.groupBox1.Controls.Add(this.atkSkillInput);
            this.groupBox1.Location = new System.Drawing.Point(11, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(228, 47);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "战斗信息按键设置";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(151, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "持续时间";
            // 
            // atkLastTimeNum
            // 
            this.atkLastTimeNum.Location = new System.Drawing.Point(117, 16);
            this.atkLastTimeNum.Name = "atkLastTimeNum";
            this.atkLastTimeNum.Size = new System.Drawing.Size(28, 21);
            this.atkLastTimeNum.TabIndex = 8;
            this.atkLastTimeNum.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // isAtkUseSkillCheckBox
            // 
            this.isAtkUseSkillCheckBox.AutoSize = true;
            this.isAtkUseSkillCheckBox.Location = new System.Drawing.Point(63, 20);
            this.isAtkUseSkillCheckBox.Name = "isAtkUseSkillCheckBox";
            this.isAtkUseSkillCheckBox.Size = new System.Drawing.Size(48, 16);
            this.isAtkUseSkillCheckBox.TabIndex = 7;
            this.isAtkUseSkillCheckBox.Text = "技能";
            this.isAtkUseSkillCheckBox.UseVisualStyleBackColor = true;
            // 
            // atkSkillInput
            // 
            this.atkSkillInput.FormattingEnabled = true;
            this.atkSkillInput.Location = new System.Drawing.Point(19, 18);
            this.atkSkillInput.Name = "atkSkillInput";
            this.atkSkillInput.Size = new System.Drawing.Size(38, 20);
            this.atkSkillInput.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.isHpUseSkillCheckBox);
            this.groupBox2.Controls.Add(this.hpSkillInput);
            this.groupBox2.Location = new System.Drawing.Point(245, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(108, 47);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Hp回复按键设置";
            // 
            // isHpUseSkillCheckBox
            // 
            this.isHpUseSkillCheckBox.AutoSize = true;
            this.isHpUseSkillCheckBox.Location = new System.Drawing.Point(56, 22);
            this.isHpUseSkillCheckBox.Name = "isHpUseSkillCheckBox";
            this.isHpUseSkillCheckBox.Size = new System.Drawing.Size(48, 16);
            this.isHpUseSkillCheckBox.TabIndex = 6;
            this.isHpUseSkillCheckBox.Text = "技能";
            this.isHpUseSkillCheckBox.UseVisualStyleBackColor = true;
            // 
            // hpSkillInput
            // 
            this.hpSkillInput.FormattingEnabled = true;
            this.hpSkillInput.Location = new System.Drawing.Point(17, 20);
            this.hpSkillInput.Name = "hpSkillInput";
            this.hpSkillInput.Size = new System.Drawing.Size(33, 20);
            this.hpSkillInput.TabIndex = 5;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.isTeleUseSkillCheckBox);
            this.groupBox3.Controls.Add(this.teleSkillInput);
            this.groupBox3.Location = new System.Drawing.Point(359, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(104, 47);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "瞬移动按键设置";
            // 
            // isTeleUseSkillCheckBox
            // 
            this.isTeleUseSkillCheckBox.AutoSize = true;
            this.isTeleUseSkillCheckBox.Location = new System.Drawing.Point(56, 24);
            this.isTeleUseSkillCheckBox.Name = "isTeleUseSkillCheckBox";
            this.isTeleUseSkillCheckBox.Size = new System.Drawing.Size(48, 16);
            this.isTeleUseSkillCheckBox.TabIndex = 7;
            this.isTeleUseSkillCheckBox.Text = "技能";
            this.isTeleUseSkillCheckBox.UseVisualStyleBackColor = true;
            // 
            // teleSkillInput
            // 
            this.teleSkillInput.FormattingEnabled = true;
            this.teleSkillInput.Location = new System.Drawing.Point(15, 20);
            this.teleSkillInput.Name = "teleSkillInput";
            this.teleSkillInput.Size = new System.Drawing.Size(35, 20);
            this.teleSkillInput.TabIndex = 5;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.isPickUpCheckBox);
            this.groupBox4.Location = new System.Drawing.Point(469, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(69, 47);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "捡物设置";
            // 
            // isPickUpCheckBox
            // 
            this.isPickUpCheckBox.AutoSize = true;
            this.isPickUpCheckBox.Location = new System.Drawing.Point(17, 22);
            this.isPickUpCheckBox.Name = "isPickUpCheckBox";
            this.isPickUpCheckBox.Size = new System.Drawing.Size(48, 16);
            this.isPickUpCheckBox.TabIndex = 8;
            this.isPickUpCheckBox.Text = "捡物";
            this.isPickUpCheckBox.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(4, 20);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(619, 130);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(536, 154);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "新增";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.textBox1);
            this.groupBox5.Controls.Add(this.button4);
            this.groupBox5.Controls.Add(this.flowLayoutPanel1);
            this.groupBox5.Controls.Add(this.button1);
            this.groupBox5.Location = new System.Drawing.Point(9, 64);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(625, 183);
            this.groupBox5.TabIndex = 9;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "物品与辅助技能设置";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(311, 157);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 10;
            this.textBox1.Text = "0.8";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(437, 154);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 9;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(542, 24);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(41, 24);
            this.button2.TabIndex = 10;
            this.button2.Text = "开始";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // messageInfoBox
            // 
            this.messageInfoBox.Location = new System.Drawing.Point(9, 254);
            this.messageInfoBox.Name = "messageInfoBox";
            this.messageInfoBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.messageInfoBox.Size = new System.Drawing.Size(248, 87);
            this.messageInfoBox.TabIndex = 11;
            this.messageInfoBox.Text = "";
            this.messageInfoBox.TextChanged += new System.EventHandler(this.messageInfoBox_TextChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(588, 24);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(41, 24);
            this.button3.TabIndex = 12;
            this.button3.Text = "停止";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(263, 254);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "出现";
            // 
            // monsterFlyCountNum
            // 
            this.monsterFlyCountNum.Location = new System.Drawing.Point(294, 249);
            this.monsterFlyCountNum.Name = "monsterFlyCountNum";
            this.monsterFlyCountNum.Size = new System.Drawing.Size(28, 21);
            this.monsterFlyCountNum.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(324, 254);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 15;
            this.label3.Text = "个怪物就飞走";
            // 
            // isCheckMonsterCountAndFlyBox
            // 
            this.isCheckMonsterCountAndFlyBox.AutoSize = true;
            this.isCheckMonsterCountAndFlyBox.Location = new System.Drawing.Point(404, 252);
            this.isCheckMonsterCountAndFlyBox.Name = "isCheckMonsterCountAndFlyBox";
            this.isCheckMonsterCountAndFlyBox.Size = new System.Drawing.Size(48, 16);
            this.isCheckMonsterCountAndFlyBox.TabIndex = 16;
            this.isCheckMonsterCountAndFlyBox.Text = "启用";
            this.isCheckMonsterCountAndFlyBox.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(263, 279);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 17;
            this.label4.Text = "瞬移延迟时间";
            // 
            // teleDelayTimeNum
            // 
            this.teleDelayTimeNum.DecimalPlaces = 1;
            this.teleDelayTimeNum.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.teleDelayTimeNum.Location = new System.Drawing.Point(340, 274);
            this.teleDelayTimeNum.Name = "teleDelayTimeNum";
            this.teleDelayTimeNum.Size = new System.Drawing.Size(39, 21);
            this.teleDelayTimeNum.TabIndex = 18;
            this.teleDelayTimeNum.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(380, 278);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 19;
            this.label5.Text = "秒";
            // 
            // monsterColorSimileNum
            // 
            this.monsterColorSimileNum.Location = new System.Drawing.Point(265, 301);
            this.monsterColorSimileNum.Name = "monsterColorSimileNum";
            this.monsterColorSimileNum.Size = new System.Drawing.Size(59, 21);
            this.monsterColorSimileNum.TabIndex = 20;
            this.monsterColorSimileNum.Text = "505050";
            // 
            // monsterSharpSimilerNum
            // 
            this.monsterSharpSimilerNum.DecimalPlaces = 1;
            this.monsterSharpSimilerNum.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.monsterSharpSimilerNum.Location = new System.Drawing.Point(340, 301);
            this.monsterSharpSimilerNum.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.monsterSharpSimilerNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.monsterSharpSimilerNum.Name = "monsterSharpSimilerNum";
            this.monsterSharpSimilerNum.Size = new System.Drawing.Size(39, 21);
            this.monsterSharpSimilerNum.TabIndex = 21;
            this.monsterSharpSimilerNum.Value = new decimal(new int[] {
            7,
            0,
            0,
            65536});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(632, 358);
            this.Controls.Add(this.monsterSharpSimilerNum);
            this.Controls.Add(this.monsterColorSimileNum);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.teleDelayTimeNum);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.isCheckMonsterCountAndFlyBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.monsterFlyCountNum);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.messageInfoBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "看看";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.atkLastTimeNum)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.monsterFlyCountNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teleDelayTimeNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.monsterSharpSimilerNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox atkSkillInput;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox isHpUseSkillCheckBox;
        private System.Windows.Forms.ComboBox hpSkillInput;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox teleSkillInput;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox isAtkUseSkillCheckBox;
        private System.Windows.Forms.CheckBox isTeleUseSkillCheckBox;
        private System.Windows.Forms.CheckBox isPickUpCheckBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RichTextBox messageInfoBox;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown atkLastTimeNum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown monsterFlyCountNum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox isCheckMonsterCountAndFlyBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown teleDelayTimeNum;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox monsterColorSimileNum;
        private System.Windows.Forms.NumericUpDown monsterSharpSimilerNum;
    }
}

