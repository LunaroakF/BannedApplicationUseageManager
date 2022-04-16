using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BannedApplicationUseageManager
{
    internal class Bools
    {
        public static string Passwords = "123456";
        public static string Version = "1.1.10";
        public static string ControlBarName = "ControlBar v"+Version;
        public static bool IsControlBarCreated = false;
        public static bool IsEnable = true;
        public static string[] Apps = new string[] {"firefox", "msedge", "chrome", "Microsoft Edge" };
        public static string Log;
        public static int remaintime;
        public static int firstremaintime=0;
        public static string RunPlace= @System.AppDomain.CurrentDomain.BaseDirectory;
        public static int oldtimer2int = 2;
        public static int oldtimer3int = 2;
        public static int AlreadyPai = 6;
        public static int[] AlreadyZuo = new int[] { };
        public static int pai = 0;
        public static int zuo = 0;
        public static int NotRepeat = 40;
        public static string PassWeek = "星期六";
        public static string driveName = null;
    }
}
