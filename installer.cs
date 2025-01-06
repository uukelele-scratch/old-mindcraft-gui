using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Mindcraft_Installer
{
    public partial class installer : Form
    {
        public installer()
        {
            InitializeComponent();
            this.Load += new EventHandler(Installer_Load);
            button1.Text = "Show Details";
            textBox1.Hide();
        }

        private async void Installer_Load(object sender, EventArgs e)
        {
            await StartInstallationAsync();
        }

        private async Task StartInstallationAsync()
        {
            try
            {
                await Task.Run(() => InstallMindcraft());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                LogMessage($"Error: {ex.Message}");
            }
        }

        private void InstallMindcraft()
        {
            string appFolder = AppDomain.CurrentDomain.BaseDirectory;
            string mindcraftDir = Path.Combine(appFolder, "mindcraft-main");

            LogMessage("Downloading Mindcraft from https://github.com/kolbytn/mindcraft/archive/refs/heads/main.zip");
            UpdateProgress("Downloading Mindcraft...");
            RunProcess("powershell.exe", $"-Command \"Invoke-WebRequest -Uri 'https://github.com/kolbytn/mindcraft/archive/refs/heads/main.zip' -OutFile '{Path.Combine(appFolder, "mindcraft.zip")}'\"");
            CheckFileExists(Path.Combine(appFolder, "mindcraft.zip"));
            File.WriteAllText("installation.log", textBox1.Text);

            LogMessage("Extracting Mindcraft to program folder...");
            UpdateProgress("Extracting Mindcraft...");
            RunProcess("powershell.exe", $"-Command \"Expand-Archive -Path '{Path.Combine(appFolder, "mindcraft.zip")}' -DestinationPath '{appFolder}'\"");
            CheckDirectoryExists(Path.Combine(appFolder, "mindcraft-main"));
            File.WriteAllText("installation.log", textBox1.Text);

            UpdateProgress("Installing node...");
            string nodeInstallerPath = Path.Combine(appFolder, "node-installer.msi");
            LogMessage("Running node installer...");
            RunProcess("msiexec.exe", $"/i \"{nodeInstallerPath}\" /quiet /norestart");
            File.WriteAllText("installation.log", textBox1.Text);
            LogMessage("Adding node to path...");
            string nodePath = @"C:\Program Files\nodejs\";
            RunProcess("powershell.exe", $"-Command \"$env:PATH += ';{nodePath}'; [System.Environment]::SetEnvironmentVariable('PATH', $env:PATH, [System.EnvironmentVariableTarget]::User); [System.Environment]::SetEnvironmentVariable('PATH', $env:PATH, [System.EnvironmentVariableTarget]::Process); [System.Environment]::SetEnvironmentVariable('PATH', $env:PATH, [System.EnvironmentVariableTarget]::Machine)\"");

            string npm = Path.Combine(nodePath, "npm.cmd");
            string node = Path.Combine(nodePath, "node.exe");

            LogMessage("Downloading npm packages (npm install)...");
            UpdateProgress("Installing Node Packages...");
            RunProcess("cmd.exe", $"/C cd mindcraft-main && \"{npm}\" install");
            File.WriteAllText("installation.log", textBox1.Text);
            RunProcess("cmd.exe", "/C cd mindcraft-main && ren \"keys.example.json\" \"keys.json\"");

            UpdateProgress("Copying Gemini Beta files to enable gemini-2 support...");
            LogMessage("Adding gemini beta support...");
            MoveFile(Path.Combine(appFolder, "index.js"), Path.Combine(mindcraftDir, "node_modules/@google/generative-ai/dist", "index.js"));
            File.WriteAllText("installation.log", textBox1.Text);
            MoveFile(Path.Combine(appFolder, "gemini.js"), Path.Combine(mindcraftDir, "src/models", "gemini.js"));
            File.WriteAllText("installation.log", textBox1.Text);

            LogMessage("Copying GLHF and DeepSeek files...");
            UpdateProgress("Adding GLHF and DeepSeek compatibility...");
            MoveFile(Path.Combine(appFolder, "glhf.js"), Path.Combine(mindcraftDir, "src/models", "glhf.js"));
            MoveFile(Path.Combine(appFolder, "hyperbolic.js"), Path.Combine(mindcraftDir, "src/models", "hyperbolic.js"));
            MoveFile(Path.Combine(appFolder, "glhf.json"), Path.Combine(mindcraftDir, "profiles", "glhf.json"));
            MoveFile(Path.Combine(appFolder, "hyperbolic.json"), Path.Combine(mindcraftDir, "profiles", "hyperbolic.json"));
            MoveFile(Path.Combine(appFolder, "prompter.js"), Path.Combine(mindcraftDir, "src/agent", "prompter.js"));
            MoveFile(Path.Combine(appFolder, "keys.json"), Path.Combine(mindcraftDir, "keys.json"));

            File.WriteAllText("installation.log", textBox1.Text);
            this.Hide();

        }

        private void MoveFile(string sourceFile, string destFile)
        {
            string targetDir = Path.GetDirectoryName(sourceFile);
            if (!Directory.Exists(targetDir))
            {
                Directory.CreateDirectory(targetDir);
            }
            if (File.Exists(destFile))
            {
                LogMessage("Deleting old " + destFile);
                File.Delete(destFile);
            }
            LogMessage("Moving " + destFile);
            File.Move(sourceFile, destFile);
        }

        public void RunProcess(string Filename, string arguments)
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
            process.WaitForExit();
        }

        private void LogMessage(string message)
        {
            if (string.IsNullOrEmpty(message)) return;
            message = message + Environment.NewLine;
            if (textBox1.InvokeRequired)
            {
                textBox1.Invoke(new Action(() => textBox1.AppendText(message)));
            }
            else
            {
                textBox1.AppendText(message);
            }
        }

        private void UpdateProgress(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(UpdateProgress), message);
                return;
            }
            label2.Text = message;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Visible = !textBox1.Visible;
            button1.Text = textBox1.Visible ? "Hide Details" : "Show Details";
        }

        private void CheckFileExists(string filePath)
        {
            if (!File.Exists(filePath))
            {
                LogMessage($"File not found: {filePath}");
                throw new FileNotFoundException($"Required file not found: {filePath}");
            }
        }
        private void CheckDirectoryExists(string dirPath)
        {
            if (!Directory.Exists(dirPath))
            {
                LogMessage($"Directory not found: {dirPath}");
                throw new DirectoryNotFoundException($"Required directory not found: {dirPath}");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
