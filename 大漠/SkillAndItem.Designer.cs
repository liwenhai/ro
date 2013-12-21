namespace 大漠
{
    partial class SkillAndItem
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.keyInput = new System.Windows.Forms.ComboBox();
            this.skillLastTimeNum = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.skillCDTimeNum = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.skillNameBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.skillLastTimeNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.skillCDTimeNum)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(567, 6);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 24;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(532, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 23;
            this.label6.Text = "启用";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(443, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 21;
            this.label4.Text = "对自己使用";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 22;
            this.label5.Text = "名称";
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(511, 6);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(15, 14);
            this.checkBox5.TabIndex = 17;
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(315, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 18;
            this.label3.Text = "对应按键";
            // 
            // keyInput
            // 
            this.keyInput.FormattingEnabled = true;
            this.keyInput.Location = new System.Drawing.Point(369, 2);
            this.keyInput.Name = "keyInput";
            this.keyInput.Size = new System.Drawing.Size(67, 20);
            this.keyInput.TabIndex = 19;
            // 
            // skillLastTimeNum
            // 
            this.skillLastTimeNum.Location = new System.Drawing.Point(265, 1);
            this.skillLastTimeNum.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.skillLastTimeNum.Name = "skillLastTimeNum";
            this.skillLastTimeNum.Size = new System.Drawing.Size(44, 21);
            this.skillLastTimeNum.TabIndex = 20;
            this.skillLastTimeNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(211, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 16;
            this.label2.Text = "持续时间";
            // 
            // skillCDTimeNum
            // 
            this.skillCDTimeNum.Location = new System.Drawing.Point(164, 1);
            this.skillCDTimeNum.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.skillCDTimeNum.Name = "skillCDTimeNum";
            this.skillCDTimeNum.Size = new System.Drawing.Size(46, 21);
            this.skillCDTimeNum.TabIndex = 15;
            this.skillCDTimeNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(108, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 14;
            this.label1.Text = "技能延时";
            // 
            // skillNameBox
            // 
            this.skillNameBox.Location = new System.Drawing.Point(37, 1);
            this.skillNameBox.Name = "skillNameBox";
            this.skillNameBox.Size = new System.Drawing.Size(71, 21);
            this.skillNameBox.TabIndex = 13;
            // 
            // SkillAndItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.checkBox5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.keyInput);
            this.Controls.Add(this.skillLastTimeNum);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.skillCDTimeNum);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.skillNameBox);
            this.Name = "SkillAndItem";
            this.Size = new System.Drawing.Size(587, 25);
            ((System.ComponentModel.ISupportInitialize)(this.skillLastTimeNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.skillCDTimeNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox keyInput;
        private System.Windows.Forms.NumericUpDown skillLastTimeNum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown skillCDTimeNum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox skillNameBox;


    }
}
