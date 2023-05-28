using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ude;

namespace Ftp索引
{
    public partial class MainForm : Form
    {
        public static int 文件数量 = 0;
        public static string 目录 = string.Empty;
        public MainForm()
        {
            InitializeComponent();
        }

        private void 爬虫任务_DoWork(object sender, DoWorkEventArgs e)
        {
            string Host = HostInput.Text;
            string User = UserInput.Text;
            string Password = PasswordInput.Text;

            // 设置最大连接数和最大空闲时间
            ServicePointManager.DefaultConnectionLimit = 3;
            ServicePointManager.MaxServicePointIdleTime = 10000;
            DateTime startTime = DateTime.Now;

            int 截取位置 = GetLongestNameLength(Host, (int)PortSelection.Value, User, Password).Result;
            string 编码设定 = (string)e.Argument;
            if (截取位置 > 0)
            {
                List<string> fileList;
                fileList = 获取全部文件列表(Host, (int)PortSelection.Value, User, Password, 截取位置, 编码设定).Result;
                DateTime endTime = DateTime.Now;
                TimeSpan elapsedTime = endTime - startTime;
                fileList.Insert(0, "");
                fileList.Insert(0, $"运行时间：{elapsedTime.TotalSeconds:F2}秒");
                fileList.Insert(0, $"结束时间：{endTime:yyyy-MM-dd HH:mm:ss.fff}");
                fileList.Insert(0, $"开始时间：{startTime:yyyy-MM-dd HH:mm:ss.fff}");
                SaveFileList(fileList);
                通知.BalloonTipText = "索引制作完成！";
                通知.ShowBalloonTip(5);
            }
        }
        static async Task<int> GetLongestNameLength(string host, int port, string user, string password)
        {
            try
            {
                Uri uri = new Uri($"ftp://{host}:{port}/");

                // 获取文件夹下的文件名列表，并找出其中最长的文件名
                string maxLine = "";
                var request = (FtpWebRequest)WebRequest.Create(new UriBuilder(uri) { Path = "" }.Uri);
                request.Credentials = new NetworkCredential(user, password);
                request.Method = WebRequestMethods.Ftp.ListDirectory;
                var response = (FtpWebResponse)await request.GetResponseAsync();
                using (var responseStream = response.GetResponseStream())
                using (var ms = new MemoryStream())
                {
                    await responseStream.CopyToAsync(ms);
                    var bytes = ms.ToArray();
                    var encoding = Encoding.GetEncoding("utf-8");
                    var content = encoding.GetString(bytes);

                    using (var reader = new StringReader(content))
                    {
                        string line;
                        while ((line = await reader.ReadLineAsync()) != null)
                        {
                            if (line.Length > maxLine.Length)
                            {
                                maxLine = line;
                            }
                        }
                    }
                }
                response.Close();

                // 获取文件名列表详情，并根据最长的文件名找到该文件名在每个文件详情中的位置
                int maxLength = 0;
                request = (FtpWebRequest)WebRequest.Create(new UriBuilder(uri) { Path = "" }.Uri);
                request.Credentials = new NetworkCredential(user, password);
                request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                response = (FtpWebResponse)await request.GetResponseAsync();
                using (var responseStream = response.GetResponseStream())
                using (var ms = new MemoryStream())
                {
                    await responseStream.CopyToAsync(ms);
                    var bytes = ms.ToArray();

                    var encoding = Encoding.GetEncoding("utf-8");
                    var content = encoding.GetString(bytes);

                    using (var reader = new StringReader(content))
                    {
                        string line;
                        while ((line = await reader.ReadLineAsync()) != null)
                        {
                            int index = line.LastIndexOf(maxLine);
                            if (index > maxLength)
                            {
                                maxLength = index;
                            }
                        }
                    }
                }
                response.Close();

                return maxLength;
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ConnectFailure)
                {
                    _ = Task.Run(() => MessageBox.Show("连接 FTP 服务器失败，请检查网络连接和输入的 IP 地址是否正确。", "错误QWQ"));
                }
                else if (ex.Status == WebExceptionStatus.NameResolutionFailure)
                {
                    _ = Task.Run(() => MessageBox.Show("无法解析 FTP 服务器 的主机名或 IP 地址，请检查输入是否正确。", "错误QWQ"));
                }
                else if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    _ = Task.Run(() => MessageBox.Show("FTP 服务器返回了错误的响应信息，请检查账号密码是否正确。", "错误QWQ"));
                }
                else
                {
                    _ = Task.Run(() => MessageBox.Show($"发生网络异常：{ex.Message}", "错误QWQ"));
                }
            }
            catch (Exception ex)
            {
                _ = Task.Run(() => MessageBox.Show($"发生未知异常：{ex.Message}", "错误QWQ"));
            }
            return -1;
        }


        static async Task<List<string>> 获取全部文件列表(string host, int port, string user, string password, int 名字截取位置, string 编码设定)
        {
            文件数量 = 0;

            Uri uri = new Uri($"ftp://{host}:{port}/");
            List<string> fileList = new List<string>();
            Stack<string> dirs = new Stack<string>();
            dirs.Push("");

            while (dirs.Count > 0)
            {
                string currentDir = dirs.Pop();
                try
                {
                    var request = (FtpWebRequest)WebRequest.Create(new UriBuilder(uri) { Path = currentDir }.Uri);
                    request.Credentials = new NetworkCredential(user, password);
                    request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                    using (var response = (FtpWebResponse)await request.GetResponseAsync())
                    using (var responseStream = response.GetResponseStream())
                    using (var ms = new MemoryStream())
                    {
                        await responseStream.CopyToAsync(ms);
                        var bytes = ms.ToArray();
                        string encodingName;
                        if (编码设定 == "<自动检测>")
                        {
                            encodingName = 检测编码(bytes); //获取编码信息
                        }
                        else
                        {
                            encodingName = 编码设定; //获取编码信息
                        }
                        var encoding = Encoding.GetEncoding(encodingName);
                        var content = encoding.GetString(bytes);
                        fileList.Add(currentDir + "\\");
                        目录 = currentDir + "\\";
                        using (StringReader reader = new StringReader(content))
                        {
                            while (true)
                            {
                                string line = await reader.ReadLineAsync();
                                if (line == null) break;

                                string Name = "";

                                Name = line.Substring(名字截取位置).Trim();

                                if (line.StartsWith("d") || line.Contains("<DIR>"))
                                {
                                    dirs.Push(Path.Combine(currentDir, Name));
                                }
                                else
                                {
                                    fileList.Add(Path.Combine(currentDir, Name));
                                    文件数量++;
                                }
                            }
                        }
                        response.Close();
                    }
                }
                catch (WebException ex) // 网络异常
                {
                    // 根据状态码判断具体网络异常类型，更加精确地提示用户
                    _ = Task.Run(() => MessageBox.Show($"发生网络异常：{ex.Message}", "错误QWQ"));
                    fileList.Add($"ERROR：发生网络异常：{ex.Message}");
                }
                catch (ArgumentException ex)
                {
                    _ = Task.Run(() => MessageBox.Show($"发生编码异常：{ex.Message}", "错误QWQ"));
                    fileList.Add($"ERROR：发生编码异常：{ex.Message}");
                }
                catch (Exception ex) // 其他异常
                {
                    _ = Task.Run(() => MessageBox.Show($"发生未知异常：{ex.Message}", "错误QWQ"));
                    fileList.Add($"ERROR：发生未知异常：{ex.Message}");
                }
            }
            return fileList;
        }

        static string 检测编码(byte[] bytes)
        {
            CharsetDetector cdet = new CharsetDetector();
            cdet.Feed(bytes, 0, bytes.Length);
            cdet.DataEnd();
            if (cdet.Charset != null)
            {
                return cdet.Charset;
            }
            else
            {
                return "utf-8";
            }
        }

        static void SaveFileList(List<string> fileList)
        {
            string filePath = Path.Combine(Environment.CurrentDirectory, "list.txt");
            using (StreamWriter writer = new StreamWriter(filePath, false))
            {
                foreach (string file in fileList)
                {
                    writer.WriteLine(file);
                }
            }
        }

        private void Run_Button_Click(object sender, EventArgs e)
        {
            Run_button.Enabled = false;
            // 开始执行后台任务
            爬虫任务.RunWorkerAsync(EncodingSettings.Text);
            通知.Visible = true;
            周期更新.Enabled = true;
        }

        private void 周期更新_Tick(object sender, EventArgs e)
        {
            L文件数量.Text = 文件数量.ToString();
            if (目录 != "")
            {
                L目录.Text = 目录;
            }
            else
            {
                L目录.Text = "连接中...";
            }
            目录全名.SetToolTip(L目录, L目录.Text);
        }
        private void 爬虫任务_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            通知.Visible = false;
            Run_button.Enabled = true;
            周期更新.Enabled = false;
            L文件数量.Text = 文件数量.ToString();
            L目录.Text = 目录;
            目录全名.SetToolTip(L目录, L目录.Text);
        }

        private void BilibiliLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://space.bilibili.com/1927497544");
        }

        private void CodeLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/23286440/FtpDirGet");
        }
    }
}
