﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;
using System.Collections;
using System.Threading;

namespace BannedApplicationUseageManager
{
    public partial class ControlBar : Form
    {
        //按键初始化
        private const byte VK_VOLUME_MUTE = 0xAD;
        private const byte VK_VOLUME_DOWN = 0xAE;
        private const byte VK_VOLUME_UP = 0xAF;
        private const UInt32 KEYEVENTF_EXTENDEDKEY = 0x0001;
        private const UInt32 KEYEVENTF_KEYUP = 0x0002;
        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, UInt32 dwFlags, UInt32 dwExtraInfo);
        [DllImport("user32.dll")]
        static extern Byte MapVirtualKey(UInt32 uCode, UInt32 uMapType);
        public ControlBar()
        {
            InitializeComponent();
            //跨线程调用窗体组件无视警告
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
        }
        private void ControlBar_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Enabled = false;
            Bools.remaintime = 0;
            Bools.IsControlBarCreated = false;
            Bools.IsEnable = true;
        }
    public void ReloadRandom()
        {
            Random rd1 = new Random();
            Bools.pai = rd1.Next(1, Bools.AlreadyPai);
            Random rd2 = new Random();
            Bools.zuo = rd2.Next(1, Bools.AlreadyZuo[Bools.pai-1]);

        }
        private void ControlBar_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.Log.Text = Bools.Log;
            if (Bools.Passwords != "123456")
                this.label12.Visible = false;
            int add = 1;
            string[] Day = new string[] { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
            string week = Day[Convert.ToInt32(DateTime.Now.DayOfWeek.ToString("d"))].ToString();
            if (week == Bools.PassWeek)
                add = 2;
            string date= DateTime.Now.AddDays(add).ToString("MM月dd日");
            this.groupBox4.Text = "将于"+date+"午间上台讲数学题的同学位于";
            this.Text = Bools.ControlBarName;
            
            try
            {
                if (File.Exists(@Bools.RunPlace + "BAUM_Settings/students_table.inf")) //检测是否存在学生数据目录
                {
                    string[] line = File.ReadAllLines(@Bools.RunPlace + "BAUM_Settings/students_table.inf");
                    string[] setting = line[0].Split('-');
                    Bools.AlreadyPai = int.Parse(setting[0]);
                    Bools.NotRepeat=int.Parse(setting[Bools.AlreadyPai+1]);
                    Bools.AlreadyZuo = new int[] {};
                    for (int i = 1; i <= Bools.AlreadyPai; i++)
                    {
                        List<int> b = Bools.AlreadyZuo.ToList();//添加座位参数
                        b.Add(int.Parse(setting[i]));
                        Bools.AlreadyZuo = b.ToArray();
                    }
                }
            }
            catch {
                Bools.AlreadyPai = 6;
                Bools.AlreadyZuo = new int[] { 9,8,9,9,8,9};
                Bools.NotRepeat = 40;
               // MessageBox.Show("non");
                //Bools.AlreadyZuo = 

            }
            HistoryFresh();
            ReloadRandom();
            this.TopMost = false;



        }
        public void HistoryFresh()
        {
            string main="";
            //history.Text = "";
            if (File.Exists(@Bools.RunPlace + "BAUM_Settings/math_history.inf")) //检测是否存在学生数据目录
            {
                string[] line = File.ReadAllLines(@Bools.RunPlace + "BAUM_Settings/math_history.inf");
                for (int i = 1; i <= line.Length - 1; i++)
                {
                    try
                    {
                        main = (line.Length - i).ToString() + "." + line[i] + Environment.NewLine + main;
                    }
                    catch
                    {
                    }
                    if ((line.Length - i - 1) == Bools.NotRepeat)
                    {
                        main = "------------------------------" + Environment.NewLine + main;
                    }
                }
                history.Text = main;
            }
        }
        public void UpdateLog()
        {
            this.Log.Text = Bools.Log;
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/LunaroakF/BannedApplicationUseageManager");
        }
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/LunaroakF/BannedApplicationUseageManager");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            if (Bools.driveName != null)
            {
                if (File.Exists(Bools.driveName + "DAKey"))//检测密钥文件是否存在
                {
                    string password = File.ReadAllText(Bools.driveName + "DAKey");
                    if (password == Bools.Passwords)
                    {
                        if (!checkBox1.Checked)
                        {
                            Bools.IsEnable = false;
                            this.label4.Visible = true;
                            MessageBox.Show("保存成功", "完成", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            Bools.IsEnable = true;
                            this.label4.Visible = false;
                            MessageBox.Show("保存成功", "完成", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        return;
                    }
                }
            }
            if (PasswordBox.Text == Bools.Passwords && !checkBox1.Checked)
            {
                Bools.IsEnable = false;
                this.label4.Visible = true;
                MessageBox.Show("保存成功", "完成", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (PasswordBox.Text == Bools.Passwords && checkBox1.Checked)
            {
                Bools.IsEnable = true;
                this.label4.Visible = false;
                MessageBox.Show("保存成功", "完成", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            { 
            MessageBox.Show("凭据不工作", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void 详细_Click(object sender, EventArgs e)
        {
        }
        private void label5_Click(object sender, EventArgs e)
        {
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            string a = "计时";
            string b = "分钟";
            if (trackBar1.Value == 0)
                timela.Text = a + "5" + b;
            else if (trackBar1.Value == 1)
                timela.Text = a + "10" + b;
            else if (trackBar1.Value == 2)
                timela.Text = a + "20" + b;
            else if (trackBar1.Value == 3)
                timela.Text = a + "30" + b;
            else if (trackBar1.Value == 4)
                timela.Text = a + "40" + b;
            else if (trackBar1.Value == 5)
                timela.Text = a + "50" + b;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            groupBox3.Enabled = false;
            if (trackBar1.Value == 0)
            {
                label6.Text = "300" ;
                Bools.remaintime = 300;
                Bools.firstremaintime = 300;
            }
            else if (trackBar1.Value == 1)
            {
                label6.Text = "600" ;
                Bools.remaintime = 600;
                Bools.firstremaintime = 600;
            }
            else if (trackBar1.Value == 2)
            {
                label6.Text = "1200" ;
                Bools.remaintime = 1200;
                Bools.firstremaintime = 1200;
            }
            else if (trackBar1.Value == 3)
            {
                label6.Text = "1800" ;
                Bools.remaintime = 1800;
                Bools.firstremaintime = 1800;
            }
            else if (trackBar1.Value == 4)
            {
                label6.Text = "2400" ;
                Bools.remaintime = 2400;
                Bools.firstremaintime = 2400;
            }
            else if (trackBar1.Value == 5)
            {
                label6.Text = "3000" ;
                Bools.remaintime = 3000;
                Bools.firstremaintime = 3000;
            }
            timer1.Enabled = true;
            this.Text = Bools.ControlBarName+" - " + Bools.remaintime.ToString() + " 秒剩余";
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Bools.remaintime--;
            this.label6.Text = Bools.remaintime.ToString();
            freshProgressBar();
            this.Text = Bools.ControlBarName + " - " + Bools.remaintime.ToString() + " 秒剩余";
            //

            if (Bools.remaintime <= 0)
            {
                timer1.Enabled = false;
                groupBox3.Enabled = true;
                Bools.firstremaintime = 0;
                timeup();
            }
        }
        private void freshProgressBar()
        {
            float a = Bools.remaintime;
            float b = Bools.firstremaintime;
            float total = a / b*100;
            int all = (int)total;
            progressBar1.Value = 100-all;
        }
        private void timeup()
        {
            if (MuteBox.Checked)
            {
                Mute();
            }
            if (ShutDownBox.Checked)
            {
                Bools.IsEnable = false;
                Exec("shutdown -s -f -t 0");
            }
        }
        public static void Mute()
        {
            keybd_event(VK_VOLUME_MUTE, MapVirtualKey(VK_VOLUME_MUTE, 0), KEYEVENTF_EXTENDEDKEY, 0);
            keybd_event(VK_VOLUME_MUTE, MapVirtualKey(VK_VOLUME_MUTE, 0), KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
        }
        public void Exec(string str)
        {
            try
            {
                using (Process process = new Process())
                {
                    process.StartInfo.FileName = "cmd.exe";//调用cmd.exe程序
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.RedirectStandardInput = true;//重定向标准输入
                    process.StartInfo.RedirectStandardOutput = true;//重定向标准输出
                    process.StartInfo.RedirectStandardError = true;//重定向标准出错
                    process.StartInfo.CreateNoWindow = true;//不显示黑窗口
                    process.Start();//开始调用执行
                    process.StandardInput.WriteLine(str + "&exit");//标准输入str + "&exit"，相等于在cmd黑窗口输入str + "&exit"
                    process.StandardInput.AutoFlush = true;//刷新缓冲流，执行缓冲区的命令，相当于输入命令之后回车执行
                    process.WaitForExit();//等待退出
                    process.Close();//关闭进程
                }
            }
            catch
            {
            }
        }
        private void 定时_Click(object sender, EventArgs e)
        {
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                this.TopMost = true;
            }
            else
            {
                this.TopMost = false;
            }
        }



        private void 幸运观众_Click(object sender, EventArgs e)
        {
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == "开始")
            {
                ReloadRandom();
                label11.Text = "";
                button3.Text = "停止组";
                timer4.Enabled = false;
                timer5.Enabled = false;
                timer2.Enabled = true;
                timer3.Enabled = true;
            }
            else if (button3.Text == "停止组")
            {
                timer4.Enabled = true;
                button3.Text = "停止座";
            }
            else if (button3.Text == "停止座")
            {
                button3.Text = "请等候...";
                button3.Enabled = false;
                timer5.Enabled = true;
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            Bools.pai++;
            if (Bools.pai > Bools.AlreadyPai)
            {
                Bools.pai =1;
            }
            label9.Text = "第" + Bools.pai.ToString() + "条";
        }
        private void timer3_Tick(object sender, EventArgs e)
        {
            Bools.zuo++;
            if (Bools.zuo > Bools.AlreadyZuo[Bools.pai-1])
                Bools.zuo = 1;

            label10.Text = "第" + Bools.zuo.ToString() + "座";
        }
        private void timer4_Tick(object sender, EventArgs e)
        {
            timer2.Interval = timer2.Interval + 50;
            if (timer2.Interval >= 300)
            {
                timer2.Enabled = false;
                timer2.Interval = Bools.oldtimer2int;
                timer4.Enabled = false;
            }
        }
        private void timer5_Tick(object sender, EventArgs e)
        {
            timer3.Interval = timer3.Interval + 50;
            if (timer3.Interval >= 400)
            {
                timer3.Enabled = false;
                timer3.Interval = Bools.oldtimer3int;
                timer5.Enabled = false;
            }
            else if (timer3.Interval >= 300&& timer3.Interval < 310)
            {
                int se=CountSe(Bools.pai, Bools.zuo);
                string name = NameOutPut(se);
                if (MathEnd(name))
                {
                    label11.Text = name;
                    HistoryWrite(name);
                    button3.Text = "开始";
                    button3.Enabled = true;
                }
                else
                {
                    label11.Text = "["+Bools.NotRepeat.ToString()+"次内重复]"+name;
                    repeat.Visible = true;
                    button3.Text = "请等候...";
                    button3.Enabled = false;
                    Thread thread = new Thread(new ThreadStart(notAgain));
                    thread.Start();
                }
            }
        }
        public void notAgain()
        {
            System.Threading.Thread.Sleep(1500);
            bool yes = true;
            while (yes && Bools.IsControlBarCreated)
            {
                for (int i = 1; i <=9&&yes && Bools.IsControlBarCreated; i++)
                {
                    Random rd2 = new Random();
                    Bools.zuo = rd2.Next(1, Bools.AlreadyZuo[Bools.pai-1]);

                    if (Bools.IsControlBarCreated)
                    {
                        label9.Text = "第" + Bools.pai.ToString() + "条";
                        label10.Text = "第" + Bools.zuo.ToString() + "座";

                        System.Threading.Thread.Sleep(50);
                    }
                    int se = CountSe(Bools.pai, Bools.zuo);
                    string name = NameOutPut(se);
                    if (MathEnd(name) && Bools.IsControlBarCreated)
                    {
                        label11.Text = name;
                        HistoryWrite(name);
                        yes = false;
                        button3.Text = "开始";
                        button3.Enabled = true;
                        repeat.Visible = false;
                    }
                    else {
                        label11.Text = "[" + Bools.NotRepeat.ToString() + "次内重复]" + name;
                    }
                }
                if (yes)
                {
                    Random rd1 = new Random();
                    Bools.pai = rd1.Next(1, Bools.AlreadyPai);
                }
                //System.Threading.Thread.Sleep(200);
            }
        }
        public int CountSe(int pai, int zuo) {
            int result = 0;
            if (pai == 1) { result = 0 + zuo; }
            else {
                int exist = zuo;
                for (int i = pai; i>1 ; i--)
                {
                    exist=exist+ Bools.AlreadyZuo[i-2];
                }
                result = exist;
            }
            //MessageBox.Show(result.ToString());
            return result;
        }
        public bool MathEnd(string Name)
        {
            if (File.Exists(@Bools.RunPlace + "BAUM_Settings/math_history.inf")) //检测是否存在学生数据目录
            {
                string[] line = File.ReadAllLines(@Bools.RunPlace + "BAUM_Settings/math_history.inf");
                bool exists = ((IList)MathHistorySetOutStudentsName(line)).Contains(Name);
                if (exists)//出现重复
                    return false;
                else
                    return true;
            }
            else
                return true;
        }
        public void HistoryWrite(string Name)
        {
            if (checkBox3.Checked)
            {
                if (File.Exists(@Bools.RunPlace + "BAUM_Settings/math_history.inf")) //检测是否存在学生数据目录
                {
                    int add = 1;
                    string[] Day = new string[] { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
                    string week = Day[Convert.ToInt32(DateTime.Now.DayOfWeek.ToString("d"))].ToString();
                    if (week == Bools.PassWeek)
                        add = 2;
                    string date = DateTime.Now.AddDays(add).ToString("MM月dd日");
                    string text = File.ReadAllText(@Bools.RunPlace + "BAUM_Settings/math_history.inf");
                    text = text + Environment.NewLine + "[" + date + "]" + "-" + Name;
                    System.IO.File.WriteAllText(@Bools.RunPlace + "BAUM_Settings/math_history.inf", text, Encoding.UTF8);
                    HistoryFresh();
                }
            }
        }
        public string[] MathHistorySetOutStudentsName(string[] line)
        {
            string[] Array=new string[] {"//New!"};
            int allline = line.Length;
            for (int i = allline-Bools.NotRepeat; i <= allline; i++)
            {
                try
                {
                    string[] a = line[i].Split('-');
                    List<string> b = Array.ToList();
                    b.Add(a[1]);
                    Array = b.ToArray();
                }
                catch { }
            }
            return Array;
        }
        public string NameOutPut(int a)
        {
            try
            {
                if (File.Exists(@Bools.RunPlace + "BAUM_Settings/students_table.inf")) //检测是否存在学生数据目录
                {
                    string[] line = File.ReadAllLines(@Bools.RunPlace + "BAUM_Settings/students_table.inf");
                    return line[a];
                }
                else
                {
                    return "//NoneStudentName//";
                }
            }
            catch {
                return "//NoneStudentName//";
            }
        }
    }
}


