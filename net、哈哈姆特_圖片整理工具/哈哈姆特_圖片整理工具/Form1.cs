using Gecko;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 哈哈姆特_圖片整理工具 {
    public partial class Form1 : Form {



        List<String> ar_黑名單 = new List<string>();
        int int_累計時間 = 0;
        GeckoWebBrowser webBrowser1;
        bool bool_執行中 = true;
        List<data_img> ar_img = new List<data_img>();

        /// <summary>
        /// 
        /// </summary>
        public class data_img {
            public String src;
            public String acc;
            public String name;
        }


        /// <summary>
        /// 
        /// </summary>
        public Form1() {

            fun_升級web核心();

            InitializeComponent();

            C_adapter.Initialize();

            this.FormClosing += Form1_FormClosing;

            //初始化火狐瀏覽器
            Xpcom.Initialize("Firefox");
            webBrowser1 = new GeckoWebBrowser();
            webBrowser1.Dock = DockStyle.Fill;
            webBrowser1.Navigate("https://haha.gamer.com.tw/?room=60076");
            panel1.Controls.Add(webBrowser1);


            //黑名單帳號 
            using (StreamReader sr = new StreamReader("黑名單.txt", Encoding.UTF8)) {
                String line;
                while ((line = sr.ReadLine()) != null) {
                    if (ar_黑名單.Contains(line) == false)
                        ar_黑名單.Add(line);
                }
            }

        }


        /// <summary>
        /// 程式關閉後，結束執行緒
        /// </summary>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            bool_執行中 = false;
        }



        /// <summary>
        /// 
        /// </summary>
        private void but_載入網頁_Click(object sender, EventArgs e) {
            webBrowser1.Navigate("https://haha.gamer.com.tw/");
        }

        /// <summary>
        /// 
        /// </summary>
        private void button1_Click(object sender, EventArgs e) {
            fun_解析與儲存();
        }


        /// <summary>
        /// 
        /// </summary>
        private void but_回收記憶體_Click(object sender, EventArgs e) {
            fun_清理記憶體();
        }


        /// <summary>
        /// 隱藏瀏覽器界面，藉此降低CPU運算
        /// </summary>
        private void but_顯示或隱藏_Click(object sender, EventArgs e) {
            String jsStr = @"
                if (document.body.style.display == 'none') {
                    document.body.style.display = 'block';
                } else {
                    document.body.style.display = 'none';
                }
            ";
            string output;
            using (AutoJSContext context = new AutoJSContext(webBrowser1.Window)) {
                context.EvaluateScript(jsStr, (nsISupports)webBrowser1.Window.DomWindow, out output);
            }
        }




    





        /// <summary>
        /// 啟動執行緒，每30秒抓一次
        /// </summary>
        private void but_開始_Click(object sender, EventArgs e) {

            //but_開始.Text = "執行中";
            but_開始.Visible = false;

            new Thread(() => {
                while (bool_執行中) {

                    C_adapter.fun_UI執行緒(() => {

                        //清理記憶體(每10分鐘1次
                        try {
                            int_累計時間 += 30;
                            if (int_累計時間 > 600) {
                                int_累計時間 = 0;
                                fun_清理記憶體();
                            }
                        } catch { }

                        //抓資料
                        try {
                            fun_解析與儲存();
                        } catch (Exception e2) {
                            richTextBox1.Text = e2 + "";
                        }
                    });

                    //延遲30秒
                    for (int i = 0; i < 30; i++) {
                        Thread.Sleep(1000);//延遲1秒
                        if (bool_執行中 == false) {
                            return;
                        }
                    }


                }//while
            }).Start();

        }




        /// <summary>
        /// 用js取得圖片資訊，並把界面清空以減少記憶體用量
        /// </summary>
        /// <returns></returns>
        public String fun_執行js() {

            String jsStr = @"
function getimg() {
    var sum = '';

    var ar_message = document.getElementsByClassName('message-log');

    for (var i = 0; i < ar_message.length; i++) {
        try {
            var img_src = ar_message[i].getElementsByTagName('img')[0].src;
            if (img_src != undefined)
                if (img_src.indexOf('https://im.bahamut.com.tw/chatimg') > -1) {
                    var s_acc = ar_message[i].parentNode.getElementsByTagName('a')[0].href;
                    var s_name = ar_message[i].getElementsByClassName('msg-log-title')[0].innerHTML;
                    sum += img_src + '\t' + s_name + '\t' + s_acc + '\n';
                }
        } catch (e) { }
    }
    document.getElementsByClassName('message-scoller')[0].innerHTML = '';
    return sum;
}
                                ";

            string output;
            using (AutoJSContext context = new AutoJSContext(webBrowser1.Window)) {
                context.EvaluateScript(jsStr, (nsISupports)webBrowser1.Window.DomWindow, out output);
                context.EvaluateScript("getimg()", (nsISupports)webBrowser1.Window.DomWindow, out output);
            }
            return output;
        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public void fun_判斷是否新增(String src) {

            var ars = src.Split('\t');
            if (ars.Length <= 2) {
                return;
            }

            String s1 = ars[0]; //圖片
            String s2 = ars[1]; //名稱
            String s3 = ars[2]; //帳號

            //重複就不新增
            foreach (var item in ar_img) {
                if (item.src == s1) {
                    return;
                }
            }

            String s_圖片 = s1.Replace("https://im.bahamut.com.tw/chatimg", "");
            String s_名稱 = s2.Replace(" -", "");
            String s_帳號 = s3.Replace("https://home.gamer.com.tw/", "");

            //過濾黑名單
            foreach (var item in ar_黑名單) {
                if (s_帳號 == item) {
                    return;
                }
            }

            ar_img.Add(new data_img
            {
                src = s_圖片,
                name = s_名稱,
                acc = s_帳號
            });

        }



        /// <summary>
        /// 
        /// </summary>
        public void fun_解析與儲存() {

            //讀取舊的資料
            if (File.Exists("html/ar.txt"))
                using (StreamReader sr = new StreamReader("html/ar.txt", Encoding.UTF8)) {
                    String line;
                    while ((line = sr.ReadLine()) != null) {
                        fun_判斷是否新增(line);
                    }
                }

            //從瀏覽器抓新的資料(合併舊資料與新資料)
            String[] ar_obj = fun_執行js().Split('\n');
            foreach (var item in ar_obj) {
                fun_判斷是否新增(item);
            }


            //刪除圖片
            foreach (var item in richTextBox_刪除圖片.Text.Replace("https://im.bahamut.com.tw/chatimg", "").Split('\n')) {
                String ss = item.Trim();
                for (int i = ar_img.Count - 1; i >= 0; i--) {
                    if (ar_img[i].src == ss)
                        ar_img.RemoveAt(i);
                }
            }
            richTextBox_刪除圖片.Text = "";


            //寫回到硬碟
            StringBuilder sb = new StringBuilder();
            foreach (var item in ar_img) {
                sb.Append(item.src + "\t" + item.name + "\t" + item.acc + "\n");
            }
            using (FileStream fs = new FileStream(@"html/ar.txt", FileMode.Create)) {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8)) {
                    sw.WriteLine(sb.ToString());
                    sw.Flush();
                    sw.Close();
                    sw.Dispose();
                }
            }

            richTextBox1.Text = "數量：" + ar_img.Count + "\n" + "時間：" + int_累計時間;
            fun_匯出js();//產生js
            ar_img = new List<data_img>();//清空
        }



        /// <summary>
        /// 
        /// </summary>
        public void fun_匯出js() {

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < ar_img.Count; i++) {

                String s_src = ar_img[i].src.Replace("'", "\\\'").Replace("#", "%23").Replace(" ", "%20");
                String s_name = ar_img[i].name.Replace("'", "\\\'");
                String s_acc = ar_img[i].acc;

                sb.Append("[" + $"'{s_src}','{s_name}','{s_acc}'" + "]");
                if (i != ar_img.Count - 1)
                    sb.Append(",");
            }

            using (FileStream fs = new FileStream("html/urls.js", FileMode.Create)) {  //寫入
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8)) {

                    sw.WriteLine("<!-- saved from url=(0014)about:internet -->");
                    sw.Write("function fun(){return (new Array(");
                    sw.Write(sb.ToString().Replace("\n", "").Replace("\r", "").Replace(Environment.NewLine, ""));//避免跳行
                    sw.Write("));}");

                    sw.Write("var end_time = '" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "';");

                    sw.Flush(); //清空緩衝區        
                    sw.Close();  //關閉流
                    sw.Dispose();
                    fs.Close();
                    fs.Dispose();
                }
            }

        }





        /// <summary>
        /// 使用IE11核心
        /// </summary>
        // set WebBrowser features, more info: http://stackoverflow.com/a/18333982/1768303
        private void fun_升級web核心() {
            // don't change the registry if running in-proc inside Visual Studio
            if (LicenseManager.UsageMode != LicenseUsageMode.Runtime)
                return;

            //判斷IE版本的方法
            var GetBrowserEmulationMode = new Func<UInt32>(() => {

                int browserVersion = 0;
                using (var ieKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer",
                    RegistryKeyPermissionCheck.ReadSubTree,
                    System.Security.AccessControl.RegistryRights.QueryValues)) {
                    var version = ieKey.GetValue("svcVersion");
                    if (null == version) {
                        version = ieKey.GetValue("Version");
                        if (null == version)
                            throw new ApplicationException("Microsoft Internet Explorer is required!");
                    }
                    int.TryParse(version.ToString().Split('.')[0], out browserVersion);
                }

                if (browserVersion < 7) {
                    throw new ApplicationException("Unsupported version of Microsoft Internet Explorer!");
                }

                UInt32 mode = 11000; // Internet Explorer 11. Webpages containing standards-based !DOCTYPE directives are displayed in IE11 Standards mode. 

                switch (browserVersion) {
                    case 7:
                        mode = 7000; // Webpages containing standards-based !DOCTYPE directives are displayed in IE7 Standards mode. 
                        break;
                    case 8:
                        mode = 8000; // Webpages containing standards-based !DOCTYPE directives are displayed in IE8 mode. 
                        break;
                    case 9:
                        mode = 9000; // Internet Explorer 9. Webpages containing standards-based !DOCTYPE directives are displayed in IE9 mode.                    
                        break;
                    case 10:
                        mode = 10000; // Internet Explorer 10.
                        break;
                }

                return mode;
            });

            var appName = System.IO.Path.GetFileName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            var featureControlRegKey = @"HKEY_CURRENT_USER\Software\Microsoft\Internet Explorer\Main\FeatureControl\";

            //修改預設IE版本
            Registry.SetValue(featureControlRegKey + "FEATURE_BROWSER_EMULATION", appName, GetBrowserEmulationMode(), RegistryValueKind.DWord);

            //使用完整的IE瀏覽器功能
            //Registry.SetValue(featureControlRegKey + "FEATURE_ENABLE_CLIPCHILDREN_OPTIMIZATION", appName, 1, RegistryValueKind.DWord);
            //Registry.SetValue(featureControlRegKey + "FEATURE_AJAX_CONNECTIONEVENTS", appName, 1, RegistryValueKind.DWord);
            Registry.SetValue(featureControlRegKey + "FEATURE_GPU_RENDERING", appName, 1, RegistryValueKind.DWord);
            //Registry.SetValue(featureControlRegKey + "FEATURE_WEBOC_DOCUMENT_ZOOM", appName, 1, RegistryValueKind.DWord);
            //Registry.SetValue(featureControlRegKey + "FEATURE_NINPUT_LEGACYMODE", appName, 0, RegistryValueKind.DWord);

        }



        /// <summary>
        /// 清理記憶體
        /// </summary>
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern bool SetProcessWorkingSetSize(IntPtr proc, int min, int max);
        public void fun_清理記憶體() {
            try {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                if (Environment.OSVersion.Platform == PlatformID.Win32NT) {
                    SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
                }
            } catch { }
        }








    }
}
