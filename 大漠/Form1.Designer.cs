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
            this.button2 = new System.Windows.Forms.Button();
            this.messageInfoBox = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.isAtkUseSkillCheckBox);
            this.groupBox1.Controls.Add(this.atkSkillInput);
            this.groupBox1.Location = new System.Drawing.Point(11, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(149, 47);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "战斗信息按键设置";
            // 
            // isAtkUseSkillCheckBox
            // 
            this.isAtkUseSkillCheckBox.AutoSize = true;
            this.isAtkUseSkillCheckBox.Location = new System.Drawing.Point(96, 20);
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
            this.atkSkillInput.Size = new System.Drawing.Size(67, 20);
            this.atkSkillInput.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.isHpUseSkillCheckBox);
            this.groupBox2.Controls.Add(this.hpSkillInput);
            this.groupBox2.Location = new System.Drawing.Point(165, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(148, 47);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Hp回复按键设置";
            // 
            // isHpUseSkillCheckBox
            // 
            this.isHpUseSkillCheckBox.AutoSize = true;
            this.isHpUseSkillCheckBox.Location = new System.Drawing.Point(94, 22);
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
            this.hpSkillInput.Size = new System.Drawing.Size(67, 20);
            this.hpSkillInput.TabIndex = 5;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.isTeleUseSkillCheckBox);
            this.groupBox3.Controls.Add(this.teleSkillInput);
            this.groupBox3.Location = new System.Drawing.Point(320, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(144, 47);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "瞬移动按键设置";
            // 
            // isTeleUseSkillCheckBox
            // 
            this.isTeleUseSkillCheckBox.AutoSize = true;
            this.isTeleUseSkillCheckBox.Location = new System.Drawing.Point(94, 24);
            this.isTeleUseSkillCheckBox.Name = "isTeleUseSkillCheckBox";
            this.isTeleUseSkillCheckBox.Size = new System.Drawing.Size(48, 16);
            this.isTeleUseSkillCheckBox.TabIndex = 7;
            this.isTeleUseSkillCheckBox.Text = "技能";
            this.isTeleUseSkillCheckBox.UseVisualStyleBackColor = true;
            // 
            // teleSkillInput
            // 
            this.teleSkillInput.FormattingEnabled = true;
            this.teleSkillInput.Location = new System.Drawing.Point(17, 22);
            this.teleSkillInput.Name = "teleSkillInput";
            this.teleSkillInput.Size = new System.Drawing.Size(67, 20);
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
            this.groupBox5.Controls.Add(this.flowLayoutPanel1);
            this.groupBox5.Controls.Add(this.button1);
            this.groupBox5.Location = new System.Drawing.Point(9, 64);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(625, 183);
            this.groupBox5.TabIndex = 9;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "物品与辅助技能设置";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(558, 18);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(43, 40);
            this.button2.TabIndex = 10;
            this.button2.Text = "开始打怪";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // messageInfoBox
            // 
            this.messageInfoBox.Location = new System.Drawing.Point(9, 254);
            this.messageInfoBox.Name = "messageInfoBox";
            this.messageInfoBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.messageInfoBox.Size = new System.Drawing.Size(611, 87);
            this.messageInfoBox.TabIndex = 11;
            this.messageInfoBox.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(632, 353);
            this.Controls.Add(this.messageInfoBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "看看";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

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
    }
}

