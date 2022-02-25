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
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace BannedApplicationUseageManager
{
    public partial class RunTime : Form
    {
        public const int WM_DEVICECHANGE = 0x219;
        public const int DBT_DEVICEARRIVAL = 0x8000;
        public const int DBT_CONFIGCHANGECANCELED = 0x0019;
        public const int DBT_CONFIGCHANGED = 0x0018;
        public const int DBT_CUSTOMEVENT = 0x8006;
        public const int DBT_DEVICEQUERYREMOVE = 0x8001;
        public const int DBT_DEVICEQUERYREMOVEFAILED = 0x8002;
        public const int DBT_DEVICEREMOVECOMPLETE = 0x8004;
        public const int DBT_DEVICEREMOVEPENDING = 0x8003;
        public const int DBT_DEVICETYPESPECIFIC = 0x8005;
        public const int DBT_DEVNODES_CHANGED = 0x0007;
        public const int DBT_QUERYCHANGECONFIG = 0x0017;
        public const int DBT_USERDEFINED = 0xFFFF;



        protected override void WndProc(ref Message m)
        {
            try
            {
                if (m.Msg == WM_DEVICECHANGE)
                {
                    switch (m.WParam.ToInt32())
                    {
                        case WM_DEVICECHANGE:
                            break;
                        case DBT_DEVICEARRIVAL://U盘插入   
                            DriveInfo[] s = DriveInfo.GetDrives();
                            foreach (DriveInfo drive in s)
                            {
                                if (drive.DriveType == DriveType.Removable)
                                {
                                    Bools.driveName = drive.Name.ToString();
                                    //MessageBox.Show("盘符:" + drive.Name.ToString());
                                    break;
                                }
                            }
                            break;
                        case DBT_CONFIGCHANGECANCELED:
                            break;
                        case DBT_CONFIGCHANGED:
                            break;
                        case DBT_CUSTOMEVENT:
                            break;
                        case DBT_DEVICEQUERYREMOVE:
                            break;
                        case DBT_DEVICEQUERYREMOVEFAILED:
                            break;
                        case DBT_DEVICEREMOVECOMPLETE:   //U盘卸载 
                            Bools.driveName = null;
                            break;
                        case DBT_DEVICEREMOVEPENDING:
                            break;
                        case DBT_DEVICETYPESPECIFIC:
                            break;
                        case DBT_DEVNODES_CHANGED:
                            break;
                        case DBT_QUERYCHANGECONFIG:
                            break;
                        case DBT_USERDEFINED:
                            break;
                        default:
                            break;
                    }
                }
            }
            catch
            {
                Bools.driveName = null;
            }
            base.WndProc(ref m);
        }

        public RunTime()
        {
            InitializeComponent();
        }




        ControlBar controlbar = new ControlBar();
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!Bools.IsControlBarCreated)
            {
                controlbar = new ControlBar();
                controlbar.Show();
                Bools.IsControlBarCreated = true;
            }
        }

        private void RunTime_Load(object sender, EventArgs e)
        {
            string name = Process.GetCurrentProcess().MainModule.ModuleName;
            string pname = Path.GetFileNameWithoutExtension(name);
            Process[] myp = Process.GetProcessesByName(pname);
            if (myp.Length > 1)
            {
                this.Dispose(true);
                Application.Exit();
                return;
            }
            notifyIcon1.Visible = true;
        }

        private bool closeProc(string ProcName)
        {
            bool result = false;
            System.Collections.ArrayList procList = new System.Collections.ArrayList();
            string tempName = "";
            int begpos;
            int endpos;
            foreach (System.Diagnostics.Process thisProc in System.Diagnostics.Process.GetProcesses())
            {
                tempName = thisProc.ToString();
                begpos = tempName.IndexOf("(") + 1;
                endpos = tempName.IndexOf(")");
                tempName = tempName.Substring(begpos, endpos - begpos);
                procList.Add(tempName);
                if (tempName == ProcName)
                {
                    if (!thisProc.CloseMainWindow())
                        thisProc.Kill();         //当发送关闭窗口命令无效时强行结束进程
                    result = true;
                }
            }
            return result;
        }

        private void CloseAppsList()
        {
            try
            {
                if (closeProc("firefox"))
                {
                    this.RunningLog.Text = "[" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString() + " " + DateTime.Now.ToLongTimeString().ToString() + "]" +
                         "尝试打开FireFox被终止"
                        + Environment.NewLine + RunningLog.Text;
                }
                if (closeProc("msedge"))
                {
                    this.RunningLog.Text = "[" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString() + " " + DateTime.Now.ToLongTimeString().ToString() + "]" +
                         "尝试打开Microsoft Edge被终止"
                        + Environment.NewLine + RunningLog.Text;
                }
                if (closeProc("chrome"))
                {
                    this.RunningLog.Text = "[" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString() + " " + DateTime.Now.ToLongTimeString().ToString() + "]" +
                         "尝试打开Chrome被终止"
                        + Environment.NewLine + RunningLog.Text;
                }
                if (closeProc("Taskmgr"))
                {
                    this.RunningLog.Text = "[" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString() + " " + DateTime.Now.ToLongTimeString().ToString() + "]" +
                         "尝试打开Taskmgr被终止"
                        + Environment.NewLine + RunningLog.Text;
                }
               if (closeProc("Microsoft Edge"))
               {
                    this.RunningLog.Text = "[" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString() + " " + DateTime.Now.ToLongTimeString().ToString() + "]" +
                         "尝试打开Microsoft Edge被终止"
                        + Environment.NewLine + RunningLog.Text;
                }
                //if (closeProc("QQ"))
                //{
                    //this.RunningLog.Text = "[" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString() + " " + DateTime.Now.ToLongTimeString().ToString() + "]" +
                         //"尝试打开QQ被终止"
                        //+ Environment.NewLine + RunningLog.Text;
                //}


            }
            catch
            {
                this.RunningLog.Text = "[" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString() + " " + DateTime.Now.ToLongTimeString().ToString() + "]" +
         "一个未知的错误，请调用开发人员"
        + Environment.NewLine + RunningLog.Text;
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Bools.IsEnable)
                CloseAppsList();
        }

        private void RunningLog_TextChanged(object sender, EventArgs e)
        {
            Bools.Log = this.RunningLog.Text;
            if (Bools.IsControlBarCreated)
            {
                controlbar.UpdateLog();
            }
        }

        private void RunTime_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Bools.IsEnable)
            {
                System.Diagnostics.Process.Start(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            }
        }
    }
}
