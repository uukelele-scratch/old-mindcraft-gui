using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;

namespace Mindcraft_Installer
{
    public partial class settings : Form
    {
        public settings()
        {
            InitializeComponent();
            JObject settings_existing = GetSettings();
            if (settings_existing["profiles"][0].ToString() == "./andy.json")
            {
                settings_existing["profiles"][0] = "./profiles/andy_npc.json";
            }
            textBox4.Text = settings_existing["language"].ToString();
            if (settings_existing["allow_insecure_coding"].ToString() == "true") { comboBox2.SelectedItem = "Yes"; } else { comboBox2.SelectedItem = "No"; }
            if (settings_existing["load_memory"].ToString() == "true") { comboBox1.SelectedItem = "Yes"; } else { comboBox1.SelectedItem = "No"; }
            JArray OnlyChatWith = (JArray)settings_existing["only_chat_with"];
            textBox3.Text = String.Join(Environment.NewLine, OnlyChatWith.Select(item => item.ToString()));
            textBox1.Text = GetKeys();
            JObject profile = GetProfile();
            string model = profile["model"].ToString();
            textBox5.Text = model;
            textBox2.Text = profile["name"].ToString();
            JObject Jmodes = (JObject)profile["modes"];
            Dictionary<string, bool> modes = Jmodes.ToObject<Dictionary<string, bool>>();
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (modes.ContainsKey(checkedListBox1.Items[i].ToString()))
                {
                    checkedListBox1.SetItemChecked(i, modes[checkedListBox1.Items[i].ToString()]);
                }
                else
                {
                    checkedListBox1.SetItemChecked(i, false);
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            home homeForm = new home();
            homeForm.Show();
            this.Hide();
        }

        public static string GetKeys()
        {
            string jsContent = File.ReadAllText("mindcraft-main/keys.json");
            JObject keys = JObject.Parse(jsContent);
            return keys["OPENAI_API_KEY"].ToString();
        }

        public static void WriteKeys(string key)
        {
            string jsContent = File.ReadAllText("mindcraft-main/keys.json");
            JObject keys = JObject.Parse(jsContent);
            foreach (var KeyValuePair in keys)
            {
                string key_name = KeyValuePair.Key;
                keys[key_name] = key;
            }
            File.WriteAllText("mindcraft-main/keys.json", keys.ToString());
        }

        public static JObject GetProfile()
        {
            string jsContent = File.ReadAllText("mindcraft-main/profiles/andy_npc.json");
            JObject profile = JObject.Parse(jsContent);
            return profile;
        }

        public static void WriteProfile(JObject profile)
        {
            File.WriteAllText("mindcraft-main/profiles/andy_npc.json", profile.ToString());
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            JObject settings_obj = GetSettings();
            if (comboBox1.SelectedItem.ToString() == "Yes")
            {
                settings_obj["load_memory"] = true;
            }
            else
            {
                settings_obj["load_memory"] = false;
            }
            WriteSettings(settings_obj);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            JObject settings_obj = GetSettings();
            if (comboBox2.SelectedItem.ToString() == "Yes")
            {
                settings_obj["allow_insecure_coding"] = true;
            }
            else
            {
                settings_obj["allow_insecure_coding"] = false;
            }
            WriteSettings(settings_obj);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            WriteKeys(textBox1.Text);
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            JObject profile = GetProfile();
            profile["model"] = textBox5.Text;
            profile.Remove("embedding");
            WriteProfile(profile);

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            JObject profile = GetProfile();
            profile["name"] = textBox2.Text;
            WriteProfile(profile);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            JObject settings_obj = GetSettings();
            settings_obj["language"] = textBox4.Text;
            WriteSettings(settings_obj);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            JObject settings_obj = GetSettings();
            List<string> lines = String.IsNullOrEmpty(textBox3.Text) ? new List<string>() : textBox3.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.None).ToList();
            settings_obj["only_chat_with"] = new JArray(lines);
            WriteSettings(settings_obj);
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dictionary<string, bool> modes = new Dictionary<string, bool>();
            foreach (var item in checkedListBox1.Items)
            {
                bool isChecked = checkedListBox1.GetItemChecked(checkedListBox1.Items.IndexOf(item));
                modes[item.ToString()] = isChecked;
            }
            JObject Jmodes = JObject.FromObject(modes);
            JObject profile = GetProfile();
            profile["modes"] = Jmodes;
            WriteProfile(profile);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start("notepad.exe", "mindcraft-main/settings.js");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process.Start("notepad.exe", "mindcraft-main/profiles/andy_npc.json");
        }
    }
}
