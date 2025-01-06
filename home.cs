using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;

namespace Mindcraft_Installer
{
    public partial class home : Form
    {
        public home()
        {
            InitializeComponent();
            InitializeApplication();
            CheckFirstLaunch();
        }

        private void CheckFirstLaunch()
        {
            string appFolder = AppDomain.CurrentDomain.BaseDirectory;
            string mindcraftDir = Path.Combine(appFolder, "mindcraft-main");

            if (!Directory.Exists(mindcraftDir))
            {
                this.Hide();
                installer installerForm = new installer();
                installerForm.FormClosed += InstallerForm_FormClosed;
                installerForm.ShowDialog();
            }
        }

        private void InstallerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void InitializeApplication()
        {
            label1.Visible = false;
            textBox1.Visible = false;
            label2.Visible = true;
            textBox2.Visible = true;
            label3.Visible = false;
            radioButton1.Checked = true;
            radioButton2.Checked = false;

            radioButton1.CheckedChanged += new EventHandler(radioButton1_CheckedChanged);
            radioButton2.CheckedChanged += new EventHandler(radioButton2_CheckedChanged);
            button1.Text = "Start Bot";
            try
            {

                textBox2.Text = GetSettings()["port"].ToString();
                if (textBox2.Text == "")
                {
                    textBox2.Text = "55916";
                }
                textBox3.Text = GetSettings()["minecraft_version"].ToString();
                if (textBox3.Text == "")
                {
                    textBox3.Text = "1.20.4";
                }
            }
            catch (Exception ex) { }
        }

        private Process _botProcess;

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Start Bot")
            {
                string mcversion = textBox3.Text;
                string hostname = "0.0.0.0";
                int port = 25565;
                if (radioButton1.Checked)
                {
                    hostname = "0.0.0.0";
                    port = int.Parse(textBox2.Text);
                }
                else if (radioButton2.Checked)
                {
                    hostname = textBox1.Text;
                    if (hostname.Contains(":"))
                    {
                        port = int.Parse(hostname.Split(':')[1]);
                    }
                    else
                    {
                        port = 25565;
                    }
                }
                JObject Jsettings = GetSettings();
                Jsettings["minecraft_version"] = mcversion;
                Jsettings["host"] = hostname;
                Jsettings["port"] = port;
                Jsettings["profiles"] = new JArray(new List<string> { "./profiles/andy_npc.json" });
                WriteSettings(Jsettings);
                button1.Text = "Stop Bot";
                LogMessage("Starting...");
                string nodePath = @"C:\Program Files\nodejs\";
                string node = Path.Combine(nodePath, "node.exe");
                _botProcess = RunProcess("cmd.exe", $"/C cd mindcraft-main && \"{node}\" main.js");
            }
            else if (button1.Text == "Stop Bot")
            {
                StopBot();
                button1.Text = "Start Bot";
            }
        }

        private Process RunProcess(string Filename, string arguments)
        {
            var process = Process.Start(new ProcessStartInfo
            {
                FileName = Filename,
                Arguments = arguments,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            });

            process.OutputDataReceived += (sender, args) => LogMessage(args.Data);
            process.ErrorDataReceived += (sender, args) => LogMessage(args.Data);

            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            return process;
            process.WaitForExit();
        }

        private void StopBot()
        {
            if (_botProcess != null && !_botProcess.HasExited)
            {
                LogMessage("Stopping...");
                _botProcess.Kill(true);
                if (!_botProcess.WaitForExit(5000))
                {
                    LogMessage("Failed to stop bot within 5 seconds.");
                }
                if (!_botProcess.HasExited)
                {
                    _botProcess.Kill(true);
                }
                _botProcess = null;
                LogMessage("Stopped.");
            }
        }

        private void LogMessage(string message)
        {
            if (string.IsNullOrEmpty(message)) return;
            message = $"{message}{Environment.NewLine}";
            if (textBox4.InvokeRequired)
            {
                textBox4.Invoke(new Action(() => textBox4.AppendText(message)));
            }
            else
            {
                textBox4.AppendText(message);
            }
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                label1.Visible = true;
                textBox1.Visible = true;
                label2.Visible = false;
                textBox2.Visible = false;
                label3.Visible = true;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                label1.Visible = false;
                textBox1.Visible = false;
                label2.Visible = true;
                textBox2.Visible = true;
                label3.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            settings settingsForm = new settings();
            settingsForm.Show();
            this.Hide();
        }

        public static JObject GetSettings()
        {
            string jsContent = File.ReadAllText("mindcraft-main/settings.js");
            string jsonString = RemoveComments(jsContent);
            JObject settings = JObject.Parse(jsonString);
            return settings;
        }

        public static void WriteSettings(JObject data)
        {
            string modifiedJsonString = data.ToString();
            File.WriteAllText("mindcraft-main/settings.js", "export default " + modifiedJsonString);
        }

        private static string RemoveComments(string jsContent)
        {
            string withoutSingleLineComments = Regex.Replace(jsContent, @"//.*", string.Empty);
            string withoutMultiLineComments = Regex.Replace(withoutSingleLineComments, @"/\*.*?\*/", string.Empty, RegexOptions.Singleline);
            var match = Regex.Match(withoutMultiLineComments, @"export default\s*(\{[\s\S]*\})");
            return match.Groups[1].Value.Trim();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string mcversion = textBox3.Text;
            if (mcversion == "1.21.1")
            {
                MessageBox.Show("1.21.1 is not supported! Please try an older version, such as 1.20.4", "Incorrect version", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                prismarine viewer = new prismarine();
                viewer.Show();
            }
        }
    }
}
