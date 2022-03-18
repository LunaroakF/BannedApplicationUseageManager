namespace BannedApplicationUseageManager
{
    partial class ControlBar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlBar));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Log = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.详细 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.PasswordBox = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.定时 = new System.Windows.Forms.TabPage();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.ScreenLockBox = new System.Windows.Forms.CheckBox();
            this.ShutDownBox = new System.Windows.Forms.CheckBox();
            this.MuteBox = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.timela = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.幸运观众 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.history = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.repeat = new System.Windows.Forms.Label();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.关于 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.timer4 = new System.Windows.Forms.Timer(this.components);
            this.timer5 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.详细.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.定时.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.幸运观众.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.关于.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Log);
            this.groupBox1.Location = new System.Drawing.Point(297, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(297, 222);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "日志";
            // 
            // Log
            // 
            this.Log.AcceptsReturn = true;
            this.Log.Location = new System.Drawing.Point(6, 20);
            this.Log.Multiline = true;
            this.Log.Name = "Log";
            this.Log.ReadOnly = true;
            this.Log.Size = new System.Drawing.Size(285, 196);
            this.Log.TabIndex = 999;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(480, 231);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 33);
            this.button1.TabIndex = 0;
            this.button1.Text = "保存更改";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.详细);
            this.tabControl1.Controls.Add(this.定时);
            this.tabControl1.Controls.Add(this.幸运观众);
            this.tabControl1.Controls.Add(this.关于);
            this.tabControl1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.Location = new System.Drawing.Point(1, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(610, 302);
            this.tabControl1.TabIndex = 1;
            // 
            // 详细
            // 
            this.详细.Controls.Add(this.label4);
            this.详细.Controls.Add(this.groupBox2);
            this.详细.Controls.Add(this.checkBox1);
            this.详细.Controls.Add(this.label3);
            this.详细.Controls.Add(this.groupBox1);
            this.详细.Controls.Add(this.button1);
            this.详细.Location = new System.Drawing.Point(4, 26);
            this.详细.Name = "详细";
            this.详细.Padding = new System.Windows.Forms.Padding(3);
            this.详细.Size = new System.Drawing.Size(602, 272);
            this.详细.TabIndex = 0;
            this.详细.Text = "详细";
            this.详细.UseVisualStyleBackColor = true;
            this.详细.Click += new System.EventHandler(this.详细_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(202, 239);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(272, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "请保持此窗口后台运行，窗口关闭将重新启用限制";
            this.label4.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.PasswordBox);
            this.groupBox2.Location = new System.Drawing.Point(6, 175);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(283, 53);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "密钥/密码键入";
            // 
            // PasswordBox
            // 
            this.PasswordBox.AccessibleDescription = "";
            this.PasswordBox.Location = new System.Drawing.Point(7, 22);
            this.PasswordBox.Name = "PasswordBox";
            this.PasswordBox.PasswordChar = '*';
            this.PasswordBox.Size = new System.Drawing.Size(270, 23);
            this.PasswordBox.TabIndex = 3;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(216, 148);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(75, 21);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "启用功能";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(3, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(288, 117);
            this.label3.TabIndex = 1;
            this.label3.Text = "控制对象:\r\nFireFox、Microsoft Edge、Google Chrome、Taskmgr...";
            // 
            // 定时
            // 
            this.定时.Controls.Add(this.checkBox2);
            this.定时.Controls.Add(this.label7);
            this.定时.Controls.Add(this.label6);
            this.定时.Controls.Add(this.groupBox3);
            this.定时.Controls.Add(this.progressBar1);
            this.定时.Location = new System.Drawing.Point(4, 26);
            this.定时.Name = "定时";
            this.定时.Size = new System.Drawing.Size(602, 272);
            this.定时.TabIndex = 2;
            this.定时.Text = "定时";
            this.定时.UseVisualStyleBackColor = true;
            this.定时.Click += new System.EventHandler(this.定时_Click);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(524, 248);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(75, 21);
            this.checkBox2.TabIndex = 4;
            this.checkBox2.Text = "窗口置顶";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.label7.Location = new System.Drawing.Point(402, 139);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 35);
            this.label7.TabIndex = 3;
            this.label7.Text = "秒 剩余";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("微软雅黑", 25F);
            this.label6.Location = new System.Drawing.Point(386, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(138, 71);
            this.label6.TabIndex = 2;
            this.label6.Text = "0";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.ScreenLockBox);
            this.groupBox3.Controls.Add(this.ShutDownBox);
            this.groupBox3.Controls.Add(this.MuteBox);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.trackBar1);
            this.groupBox3.Controls.Add(this.timela);
            this.groupBox3.Location = new System.Drawing.Point(7, 25);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(297, 222);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "操作台";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(167, 176);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(116, 34);
            this.button2.TabIndex = 6;
            this.button2.Text = "开始";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ScreenLockBox
            // 
            this.ScreenLockBox.AutoSize = true;
            this.ScreenLockBox.Enabled = false;
            this.ScreenLockBox.Location = new System.Drawing.Point(176, 149);
            this.ScreenLockBox.Name = "ScreenLockBox";
            this.ScreenLockBox.Size = new System.Drawing.Size(51, 21);
            this.ScreenLockBox.TabIndex = 5;
            this.ScreenLockBox.Text = "锁屏";
            this.ScreenLockBox.UseVisualStyleBackColor = true;
            // 
            // ShutDownBox
            // 
            this.ShutDownBox.AutoSize = true;
            this.ShutDownBox.Checked = true;
            this.ShutDownBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ShutDownBox.Location = new System.Drawing.Point(119, 149);
            this.ShutDownBox.Name = "ShutDownBox";
            this.ShutDownBox.Size = new System.Drawing.Size(51, 21);
            this.ShutDownBox.TabIndex = 4;
            this.ShutDownBox.Text = "关机";
            this.ShutDownBox.UseVisualStyleBackColor = true;
            // 
            // MuteBox
            // 
            this.MuteBox.AutoSize = true;
            this.MuteBox.Checked = true;
            this.MuteBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MuteBox.Location = new System.Drawing.Point(9, 149);
            this.MuteBox.Name = "MuteBox";
            this.MuteBox.Size = new System.Drawing.Size(104, 21);
            this.MuteBox.TabIndex = 3;
            this.MuteBox.Text = "静音/开启声音";
            this.MuteBox.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 17);
            this.label5.TabIndex = 2;
            this.label5.Text = "后 (顺序优先级)";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 1;
            this.trackBar1.Location = new System.Drawing.Point(6, 69);
            this.trackBar1.Maximum = 5;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(277, 45);
            this.trackBar1.TabIndex = 1;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // timela
            // 
            this.timela.AutoSize = true;
            this.timela.Location = new System.Drawing.Point(6, 34);
            this.timela.Name = "timela";
            this.timela.Size = new System.Drawing.Size(63, 17);
            this.timela.TabIndex = 0;
            this.timela.Text = "计时5分钟";
            this.timela.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.timela.Click += new System.EventHandler(this.label5_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(-1, -5);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(605, 10);
            this.progressBar1.TabIndex = 0;
            // 
            // 幸运观众
            // 
            this.幸运观众.Controls.Add(this.groupBox5);
            this.幸运观众.Controls.Add(this.groupBox4);
            this.幸运观众.Location = new System.Drawing.Point(4, 26);
            this.幸运观众.Name = "幸运观众";
            this.幸运观众.Size = new System.Drawing.Size(602, 272);
            this.幸运观众.TabIndex = 3;
            this.幸运观众.Text = "数学";
            this.幸运观众.UseVisualStyleBackColor = true;
            this.幸运观众.Click += new System.EventHandler(this.幸运观众_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.history);
            this.groupBox5.Location = new System.Drawing.Point(379, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(215, 266);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "历史记录";
            // 
            // history
            // 
            this.history.Location = new System.Drawing.Point(6, 22);
            this.history.Multiline = true;
            this.history.Name = "history";
            this.history.ReadOnly = true;
            this.history.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.history.Size = new System.Drawing.Size(203, 238);
            this.history.TabIndex = 999;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.repeat);
            this.groupBox4.Controls.Add(this.checkBox3);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.button3);
            this.groupBox4.Location = new System.Drawing.Point(7, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(366, 266);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "groupBox4";
            // 
            // repeat
            // 
            this.repeat.AutoSize = true;
            this.repeat.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.repeat.ForeColor = System.Drawing.Color.Red;
            this.repeat.Location = new System.Drawing.Point(116, 232);
            this.repeat.Name = "repeat";
            this.repeat.Size = new System.Drawing.Size(122, 27);
            this.repeat.TabIndex = 7;
            this.repeat.Text = "触发重复......";
            this.repeat.Visible = false;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Checked = true;
            this.checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox3.Location = new System.Drawing.Point(309, 239);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(51, 21);
            this.checkBox3.TabIndex = 6;
            this.checkBox3.Text = "记录";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.Cursor = System.Windows.Forms.Cursors.Default;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.label11.Location = new System.Drawing.Point(6, 175);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(337, 52);
            this.label11.TabIndex = 5;
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(160, 158);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 17);
            this.label8.TabIndex = 0;
            this.label8.Text = "选中";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 40F);
            this.label9.Location = new System.Drawing.Point(6, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(170, 70);
            this.label9.TabIndex = 1;
            this.label9.Text = "第0排";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 40F);
            this.label10.Location = new System.Drawing.Point(182, 30);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(170, 70);
            this.label10.TabIndex = 3;
            this.label10.Text = "第0座";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(132, 112);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(91, 28);
            this.button3.TabIndex = 0;
            this.button3.Text = "开始";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // 关于
            // 
            this.关于.Controls.Add(this.label2);
            this.关于.Controls.Add(this.pictureBox3);
            this.关于.Controls.Add(this.pictureBox2);
            this.关于.Controls.Add(this.linkLabel1);
            this.关于.Controls.Add(this.pictureBox1);
            this.关于.Controls.Add(this.label1);
            this.关于.Location = new System.Drawing.Point(4, 26);
            this.关于.Name = "关于";
            this.关于.Padding = new System.Windows.Forms.Padding(3);
            this.关于.Size = new System.Drawing.Size(602, 272);
            this.关于.TabIndex = 1;
            this.关于.Text = "关于";
            this.关于.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(411, 210);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "开放源代码-若需二次使用";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::BannedApplicationUseageManager.Properties.Resources.Github;
            this.pictureBox3.Location = new System.Drawing.Point(435, 146);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(92, 29);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 5;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::BannedApplicationUseageManager.Properties.Resources._14097526827e7d7d0a8ac6b4f1a31a23;
            this.pictureBox2.Location = new System.Drawing.Point(414, 6);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(134, 134);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // linkLabel1
            // 
            this.linkLabel1.Location = new System.Drawing.Point(366, 226);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(233, 37);
            this.linkLabel1.TabIndex = 2;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "https://github.com/LunaroakF/BannedApplicationUseageManager";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BannedApplicationUseageManager.Properties.Resources.water;
            this.pictureBox1.Location = new System.Drawing.Point(7, 133);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(353, 130);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(353, 133);
            this.label1.TabIndex = 0;
            this.label1.Text = "此软件适用于沙市五中高中2020级7班一体机软件使用限额控制\r\n以及一些乱七八糟的东西，开机自启动请手动设置\r\n作者1:何狐\r\n作者2:黎源\r\n作者3:狐冥栎\r\n" +
    "此版本处于测试阶段，欢迎至GitHub-issues栏反馈\r\nBannedApplicationUseageManager v1.1.7";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 2;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Interval = 2;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // timer4
            // 
            this.timer4.Interval = 200;
            this.timer4.Tick += new System.EventHandler(this.timer4_Tick);
            // 
            // timer5
            // 
            this.timer5.Interval = 200;
            this.timer5.Tick += new System.EventHandler(this.timer5_Tick);
            // 
            // ControlBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 302);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ControlBar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ControlBar";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ControlBar_FormClosing);
            this.Load += new System.EventHandler(this.ControlBar_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.详细.ResumeLayout(false);
            this.详细.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.定时.ResumeLayout(false);
            this.定时.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.幸运观众.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.关于.ResumeLayout(false);
            this.关于.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox Log;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage 详细;
        private System.Windows.Forms.TabPage 关于;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox PasswordBox;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage 定时;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label timela;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.CheckBox ScreenLockBox;
        private System.Windows.Forms.CheckBox ShutDownBox;
        private System.Windows.Forms.CheckBox MuteBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.TabPage 幸运观众;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Timer timer4;
        private System.Windows.Forms.Timer timer5;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox history;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.Label repeat;
    }
}