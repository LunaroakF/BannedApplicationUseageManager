using System;
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
        }
    public void ReloadRandom()
        {
            Random rd1 = new Random();
            Bools.pai = rd1.Next(1, Bools.AlreadyPai+1);
            Random rd2 = new Random();
            Bools.zuo = rd2.Next(1, Bools.AlreadyZuo[Bools.pai-1]+1);
        }
        private void ControlBar_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.Log.Text = Bools.Log;
            groupBox7.Location = hidebt.Location;
            if (Bools.Passwords != "123456")
                this.label12.Visible = false;
            if (Bools.IsEnable)
            {
                this.checkBox1.Checked = true;
                Bools.ControlBarName = "ControlBar v" + Bools.Version;
            }
            else
                Bools.ControlBarName = "ControlBar v" + Bools.Version + " (未启用)";
            int add = 1;
            string[] Day = new string[] { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
            string week = Day[Convert.ToInt32(DateTime.Now.DayOfWeek.ToString("d"))].ToString();
            if (week == Bools.PassWeek)
                add = 2;
            string date= DateTime.Now.AddDays(add).ToString("MM月dd日");
            this.groupBox4.Text = "将于"+date+"午间上台讲数学题的同学位于";
            this.groupBox7.Text = "将于" + date + "午间上台讲数学题的同学";
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
            }
            this.label13.Text = "不重复次数:" + Bools.NotRepeat.ToString();
            this.label14.Text = "不重复次数:" + Bools.NotRepeat.ToString();
            HistoryFresh();
            ReloadRandom();
            this.TopMost = false;
            if (history.Lines.Length > Bools.NotRepeat)
            {
                Thread thread = new Thread(new ThreadStart(changeCard));
                thread.Start();
            }
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
        public bool CheckNameInNameBox(string name)
        {
            if (NameBox1.Text == name || NameBox2.Text == name || NameBox3.Text == name || NameBox4.Text == name || NameBox5.Text == name)
            {
                return true;
            }
            else {
                return false;
            }
        }
        public void LoadVIPCards()
        {
            string[] Guys;
            List<string> strList = new List<string>();
            if (File.Exists(@Bools.RunPlace + "BAUM_Settings/students_table.inf")) //检测是否存在学生数据目录
            {
                string[] line1 = File.ReadAllLines(@Bools.RunPlace + "BAUM_Settings/students_table.inf");
                for (int i = 1; i <= line1.Length - 1; i++)
                {
                    if (MathEnd(line1[i]))
                    {
                        strList.Add(line1[i]);
                        //MessageBox.Show(line[i]);
                    }
                }
                Guys = strList.ToArray();//下次可能被抽到的学生名单
                NameBox1.Text = Guys[0];
                NameBox2.Text = Guys[1];
                NameBox3.Text = Guys[2];
                NameBox4.Text = Guys[3];
                NameBox5.Text = Guys[4];
                if (File.Exists(@Bools.RunPlace + "BAUM_Settings/math_history.inf")) //检测是否存在学生数据目录
                {
                    string[] line2 = File.ReadAllLines(@Bools.RunPlace + "BAUM_Settings/math_history.inf");
                    int Name1_Value = 2;
                    int Name2_Value = 2;
                    int Name3_Value = 2;
                    int Name4_Value = 2;
                    int Name5_Value = 2;
                    bool wt1 = true;
                    bool wt2 = true;
                    bool wt3 = true;
                    bool wt4 = true;
                    bool wt5 = true;
                    for (int i = line2.Length-1; i >=1; i--)
                    {
                        string[] a = line2[i].Split('-');
                        if (a[1] == Guys[0]&&wt1){
                            try {
                                NameLast1.Text = "上次:" + a[0];
                                Namebutton1.Text = (line2.Length-i).ToString();
                                if ((line2.Length - i) <= Bools.GreenButton) { Name1_Value = 0; }
                                else if ((line2.Length - i) <= Bools.OrangeButton) { Name1_Value = 1; }
                                else { Name1_Value = 2; }
                                NamePause1.Text = "相隔:" + (line2.Length - i).ToString() + "人";
                            } catch {
                                NameLast1.Text = "上次:" + "[从未]";
                                Namebutton1.Text = "999";
                                Name1_Value = 2;
                                NamePause1.Text = "相隔:" + "-1" + "人";
                            }
                            wt1 = false;
                        }
                        else if (a[1] == Guys[1]&&wt2 ) { 
                            try { NameLast2.Text = "上次:" + a[0];
                                Namebutton2.Text = (line2.Length - i).ToString();
                                if ((line2.Length - i) <= Bools.GreenButton) { Name2_Value = 0; }
                                else if ((line2.Length - i) <= Bools.OrangeButton) { Name2_Value = 1; }
                                else { Name2_Value = 2; }
                                NamePause2.Text = "相隔:" + (line2.Length - i).ToString() + "人";
                            } catch {
                                NameLast2.Text = "上次:" + "[从未]";
                                Namebutton2.Text = "999";
                                Name2_Value = 2;
                                NamePause2.Text = "相隔:" + "-1" + "人";
                            }
                            wt2 = false;
                        }
                        else if (a[1] == Guys[2] && wt3) { 
                            try {
                                NameLast3.Text = "上次:" + a[0];
                                Namebutton3.Text = (line2.Length - i).ToString();
                                if ((line2.Length - i) <= Bools.GreenButton) { Name3_Value = 0; }
                                else if ((line2.Length - i) <= Bools.OrangeButton) { Name3_Value = 1; }
                                else { Name3_Value = 2; }
                                NamePause3.Text = "相隔:" + (line2.Length - i).ToString() + "人";
                            } catch {
                                NameLast3.Text = "上次:" + "[从未]";
                                Namebutton3.Text = "999";
                                Name3_Value = 2;
                                NamePause3.Text = "相隔:"+"-1"+"人";
                            }
                            wt3 = false;
                        }
                        else if (a[1] == Guys[3]&& wt4) {
                            try { 
                                NameLast4.Text = "上次:" + a[0];
                                Namebutton4.Text = (line2.Length - i).ToString();
                                if ((line2.Length - i) <= Bools.GreenButton) { Name4_Value = 0; }
                                else if ((line2.Length - i) <= Bools.OrangeButton) { Name4_Value = 1; }
                                else { Name4_Value = 2; }
                                NamePause4.Text = "相隔:" + (line2.Length - i).ToString() + "人";
                            } catch {
                                NameLast4.Text = "上次:" + "[从未]";
                                Namebutton4.Text = "999";
                                Name4_Value = 2;
                                NamePause4.Text = "相隔:" + "-1" + "人";
                            }
                            wt4 = false;
                        }
                        else if (a[1] == Guys[4]&& wt5) {
                            try { NameLast5.Text = "上次:" + a[0];
                                Namebutton5.Text = (line2.Length - i).ToString();
                                if ((line2.Length - i) <= Bools.GreenButton) { Name5_Value = 0; }
                                else if ((line2.Length - i) <= Bools.OrangeButton) { Name5_Value = 1; }
                                else { Name5_Value = 2; }
                                NamePause5.Text = "相隔:" + (line2.Length - i).ToString() + "人";
                            } catch {
                                NameLast5.Text = "上次:" + "[从未]";
                                Namebutton5.Text = "999";
                                Name5_Value = 2;
                                NamePause5.Text = "相隔:" + "-1" + "人";
                            }
                            wt5 = false;
                        }
                    }
                    int[] c = new int[]{Name1_Value, Name2_Value, Name3_Value, Name4_Value, Name5_Value};
                    List<int> intListGreen = new List<int>();
                    List<int> intListOrange = new List<int>();
                    List<int> intListRed = new List<int>();
                    for (int i = 0; i < c.Length; i++)
                    {
                        if (c[i] == 0){ intListGreen.Add(i+1);}
                        else if (c[i] == 1) { intListOrange.Add(i+1); }
                        else if (c[i] == 2) { intListRed.Add(i+1); }
                    }
                    Bools.GreenBox = intListGreen.ToArray();
                    Bools.OrangeBox = intListOrange.ToArray();
                    Bools.RedBox = intListRed.ToArray();
                }
            }
        }
        public void changeCard()
        {
            groupBox7.Location = groupBox4.Location;
            groupBox4.Enabled = false;
            LuckyGuyALLRED();
            //System.Threading.Thread.Sleep(50);
            groupBox4.Visible = false;
            LoadVIPCards();
            LuckyGuyALLOFF();
            button5.Enabled = true;
            button4.Enabled = true;
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
        public void SaveChanges()
        {
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
                            MessageBox.Show("保存成功" + Environment.NewLine + "限制状态: 关闭", "完成", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            Bools.IsEnable = true;
                            MessageBox.Show("保存成功" + Environment.NewLine + "限制状态: 启用", "完成", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                        if (Bools.IsEnable)
                            Bools.ControlBarName = "ControlBar v" + Bools.Version;
                        else
                            Bools.ControlBarName = "ControlBar v" + Bools.Version + " (未启用)";
                        this.Text = Bools.ControlBarName;
                        return;
                    }
                }
            }
            if (PasswordBox.Text == Bools.Passwords && !checkBox1.Checked)
            {
                Bools.IsEnable = false;
                MessageBox.Show("保存成功" + Environment.NewLine + "限制状态: 关闭", "完成", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (PasswordBox.Text == Bools.Passwords && checkBox1.Checked)
            {
                Bools.IsEnable = true;
                MessageBox.Show("保存成功" + Environment.NewLine + "限制状态: 启用", "完成", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (Bools.driveName != null)
                    MessageBox.Show("凭据不工作" + Environment.NewLine + "当前使用凭据: 密钥+密码" + Environment.NewLine + "检测到移动存储介质插入 但从中无法读取DAKey文件或密钥不符", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("凭据不工作" + Environment.NewLine + "当前使用凭据: 仅密码", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (Bools.IsEnable)
            {
                Bools.ControlBarName = "ControlBar v" + Bools.Version;
                try
                {
                    Bools.Hostsfs = File.Open("C:/Windows/System32/drivers/etc/hosts", FileMode.Open);
                    Bools.Hostssr = new StreamReader((System.IO.Stream)Bools.Hostsfs, System.Text.Encoding.Default);
                }
                catch { }
            }
            else
            {
                Bools.ControlBarName = "ControlBar v" + Bools.Version + " (未启用)";
                try
                {
                    Bools.Hostsfs.Close();
                    Bools.Hostssr = null;
                }
                catch { }
            }
            this.Text = Bools.ControlBarName;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SaveChanges();
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
                    nameoutput2.Text = name;
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
            System.Threading.Thread.Sleep(1000);
            bool yes = true;
            while (yes && Bools.IsControlBarCreated)
            {
                for (int i = 1; i <=9&&yes && Bools.IsControlBarCreated; i++)
                {
                    Random rd2 = new Random();
                    Bools.zuo = rd2.Next(1, Bools.AlreadyZuo[Bools.pai-1]+1);
                    if (Bools.IsControlBarCreated)
                    {
                        label9.Text = "第" + Bools.pai.ToString() + "条";
                        label10.Text = "第" + Bools.zuo.ToString() + "座";
                        System.Threading.Thread.Sleep(10);
                    }
                    int se = CountSe(Bools.pai, Bools.zuo);
                    string name = NameOutPut(se);
                    if (MathEnd(name) && Bools.IsControlBarCreated)
                    {
                        label11.Text = name;
                        nameoutput2.Text = name;
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
                    Bools.pai = rd1.Next(1, Bools.AlreadyPai+1);
                }
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
        private void PasswordBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyValue==13)
                SaveChanges();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            //button4.Text = "加载";
            button4.Enabled = false;
            groupBox4.Enabled = true;
            groupBox4.Visible = true;
            groupBox7.Enabled = true;
            groupBox7.Location = hidebt.Location;
            LuckyGuyALLRED();
            //groupBox7.Visible = false;
            //button4.Text = "切换";
        }
        private void button5_Click(object sender, EventArgs e)
        {
            //button5.Text = "加载";
            button5.Enabled = false;
            groupBox4.Enabled = false;
            Thread thread = new Thread(new ThreadStart(changeCard));
            thread.Start();
        }
        private void Namebutton1_TextChanged(object sender, EventArgs e)
        {
            if (int.Parse(Namebutton1.Text) <= Bools.GreenButton)
            {
                Namebutton1.BackgroundImage = Properties.Resources.green;
            }
            else if (int.Parse(Namebutton1.Text) <= Bools.OrangeButton)
            {
                Namebutton1.BackgroundImage = Properties.Resources.orange;
            }
            else { 
                Namebutton1.BackgroundImage = Properties.Resources.red;
            }
        }
        private void Namebutton2_TextChanged(object sender, EventArgs e)
        {
            if (int.Parse(Namebutton2.Text) <= Bools.GreenButton)
            {
                Namebutton2.BackgroundImage = Properties.Resources.green;
            }
            else if (int.Parse(Namebutton2.Text) <= Bools.OrangeButton)
            {
                Namebutton2.BackgroundImage = Properties.Resources.orange;
            }
            else
            {
                Namebutton2.BackgroundImage = Properties.Resources.red;
            }
        }
        private void Namebutton3_TextChanged(object sender, EventArgs e)
        {
            if (int.Parse(Namebutton3.Text) <= Bools.GreenButton)
            {
                Namebutton3.BackgroundImage = Properties.Resources.green;
            }
            else if (int.Parse(Namebutton3.Text) <= Bools.OrangeButton)
            {
                Namebutton3.BackgroundImage = Properties.Resources.orange;
            }
            else
            {
                Namebutton3.BackgroundImage = Properties.Resources.red;
            }
        }
        private void Namebutton4_TextChanged(object sender, EventArgs e)
        {
            if (int.Parse(Namebutton4.Text) <= Bools.GreenButton)
            {
                Namebutton4.BackgroundImage = Properties.Resources.green;
            }
            else if (int.Parse(Namebutton4.Text) <= Bools.OrangeButton)
            {
                Namebutton4.BackgroundImage = Properties.Resources.orange;
            }
            else
            {
                Namebutton4.BackgroundImage = Properties.Resources.red;
            }
        }
        private void Namebutton5_TextChanged(object sender, EventArgs e)
        {
            if (int.Parse(Namebutton5.Text) <= Bools.GreenButton)
            {
                Namebutton5.BackgroundImage = Properties.Resources.green;
            }
            else if (int.Parse(Namebutton5.Text) <= Bools.OrangeButton)
            {
                Namebutton5.BackgroundImage = Properties.Resources.orange;
            }
            else
            {
                Namebutton5.BackgroundImage = Properties.Resources.red;
            }
        }
        public void Start2plus()
        {
            while (Bools.SecondPlusRunning)
            {
                int waittime = 50;
                Random rd1 = new Random();
                int a = rd1.Next(1, 10+1);//1~5红色 6~9橙色 10绿色
                int b = 0;
                if (a == 1 || a == 2 || a == 3 || a == 4 || a == 5||a==6)
                {
                    if (Bools.RedBox.Length != 0)
                    {
                        Random rd2 = new Random();
                        b = rd2.Next(0, Bools.RedBox.Length);
                        b = Bools.RedBox[b];
                    }
                    else {
                        Random rd2 = new Random();
                        b = rd2.Next(1, 6);
                    }
                }
                else if (a == 7 || a == 8 || a == 9)
                {
                    if (Bools.OrangeBox.Length != 0)
                    {
                        Random rd2 = new Random();
                        b = rd2.Next(0, Bools.OrangeBox.Length);
                        b = Bools.OrangeBox[b];
                    }
                    else {
                        Random rd2 = new Random();
                        b = rd2.Next(1, 6);
                    }
                }
                else if (a == 10)
                {
                    if (Bools.GreenBox.Length != 0)
                    {
                        Random rd2 = new Random();
                        b = rd2.Next(0, Bools.GreenBox.Length);
                        //MessageBox.Show("Bools.GreenBox.Length=" + Bools.GreenBox.Length.ToString());
                        b = Bools.GreenBox[b];
                    }
                    else {
                        Random rd2 = new Random();
                        b = rd2.Next(1, 6);
                    }
                }
                if (b == 1) { LuckyGuyTurn1(); }
                else if (b == 2) { LuckyGuyTurn2(); }
                else if (b == 3) { LuckyGuyTurn3(); }
                else if (b == 4) { LuckyGuyTurn4(); }
                else if (b == 5) { LuckyGuyTurn5(); }
                else { waittime = 0; }
                System.Threading.Thread.Sleep(waittime);
            }
        }
        public void LuckyGuyTurn1() { LuckyGuyALLOFF(); NameBox1.BackColor = Color.Gainsboro; Bools.LuckyGuyNum = 1; }
        public void LuckyGuyTurn2() { LuckyGuyALLOFF(); NameBox2.BackColor = Color.Gainsboro; Bools.LuckyGuyNum = 2; }
        public void LuckyGuyTurn3() { LuckyGuyALLOFF(); NameBox3.BackColor = Color.Gainsboro; Bools.LuckyGuyNum = 3; }
        public void LuckyGuyTurn4() { LuckyGuyALLOFF(); NameBox4.BackColor = Color.Gainsboro; Bools.LuckyGuyNum = 4; }
        public void LuckyGuyTurn5() { LuckyGuyALLOFF(); NameBox5.BackColor = Color.Gainsboro; Bools.LuckyGuyNum = 5; }
        public void LuckyGuyALLOFF(){NameBox1.BackColor = Color.Transparent;NameBox2.BackColor = Color.Transparent;NameBox3.BackColor = Color.Transparent;NameBox4.BackColor = Color.Transparent;NameBox5.BackColor = Color.Transparent; Bools.LuckyGuyNum = 0; }
        public void LuckyGuyALLRED()
        {
            NameBox1.Text = "//NAME//";
            NameBox2.Text = "//NAME//";
            NameBox3.Text = "//NAME//";
            NameBox4.Text = "//NAME//";
            NameBox5.Text = "//NAME//";
            NameLast1.Text = "上次:[Never]";
            NameLast2.Text = "上次:[Never]";
            NameLast3.Text = "上次:[Never]";
            NameLast4.Text = "上次:[Never]";
            NameLast5.Text = "上次:[Never]";
            NamePause1.Text = "相隔:-1人";
            NamePause2.Text = "相隔:-1人";
            NamePause3.Text = "相隔:-1人";
            NamePause4.Text = "相隔:-1人";
            NamePause5.Text = "相隔:-1人";
            Namebutton1.Text = "-1";
            Namebutton2.Text = "-1";
            Namebutton3.Text = "-1";
            Namebutton4.Text = "-1";
            Namebutton5.Text = "-1";
        }
        public void button6_Click_Branch1()
        {
            System.Threading.Thread.Sleep(2100);
            //button6.Text = "开始";
            button6.Enabled = true;
        }
        public void button6_Click_Branch2()
        {
            System.Threading.Thread.Sleep(100);
            if (Bools.LuckyGuyNum == 1) { HistoryWrite(NameBox1.Text); nameoutput2.Text = NameBox1.Text; label11.Text = NameBox1.Text; }
            else if (Bools.LuckyGuyNum == 2) { HistoryWrite(NameBox2.Text); nameoutput2.Text = NameBox2.Text; label11.Text = NameBox2.Text; }
            else if (Bools.LuckyGuyNum == 3) { HistoryWrite(NameBox3.Text); nameoutput2.Text = NameBox3.Text; label11.Text = NameBox3.Text; }
            else if (Bools.LuckyGuyNum == 4) { HistoryWrite(NameBox4.Text); nameoutput2.Text = NameBox4.Text; label11.Text = NameBox4.Text; }
            else if (Bools.LuckyGuyNum == 5) { HistoryWrite(NameBox5.Text); nameoutput2.Text = NameBox5.Text; label11.Text = NameBox5.Text; }
            System.Threading.Thread.Sleep(1500);
            changeCard();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            nameoutput2.Text = "";
            nameoutput2.Visible = true;
            if (!Bools.SecondPlusRunning)
            {
                //button6.Enabled = false;
                button6.Text="停止";
                Bools.SecondPlusRunning = true;
                Thread thread = new Thread(new ThreadStart(Start2plus));
                thread.Start();
            }
            else {
                button6.Enabled = false;
                button6.Text = "开始";
                Thread thread = new Thread(new ThreadStart(button6_Click_Branch2));
                thread.Start();
                Bools.SecondPlusRunning = false;
            }
            Thread thread0 = new Thread(new ThreadStart(button6_Click_Branch1));
            thread0.Start();
        }
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            checkBox3.Checked = checkBox4.Checked;
        }
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            checkBox4.Checked = checkBox3.Checked;
        }
    }
}