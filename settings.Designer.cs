namespace Mindcraft_Installer
{
    partial class settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(settings));
            button1 = new Button();
            label1 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            label3 = new Label();
            textBox2 = new TextBox();
            comboBox1 = new ComboBox();
            label4 = new Label();
            label5 = new Label();
            textBox3 = new TextBox();
            label6 = new Label();
            label7 = new Label();
            textBox4 = new TextBox();
            label8 = new Label();
            label9 = new Label();
            comboBox2 = new ComboBox();
            label10 = new Label();
            textBox5 = new TextBox();
            checkedListBox1 = new CheckedListBox();
            label11 = new Label();
            button2 = new Button();
            button3 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(8, 7);
            button1.Margin = new Padding(2, 2, 2, 2);
            button1.Name = "button1";
            button1.Size = new Size(78, 29);
            button1.TabIndex = 0;
            button1.Text = "Back";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(93, 283);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(44, 15);
            label1.TabIndex = 1;
            label1.Text = "Model:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(148, 307);
            textBox1.Margin = new Padding(2, 2, 2, 2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(282, 23);
            textBox1.TabIndex = 10;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(87, 310);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(50, 15);
            label2.TabIndex = 11;
            label2.Text = "API Key:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(451, 310);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(84, 15);
            label3.TabIndex = 12;
            label3.Text = "Bot Username:";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(539, 307);
            textBox2.Margin = new Padding(2, 2, 2, 2);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(96, 23);
            textBox2.TabIndex = 13;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Yes", "No" });
            comboBox1.Location = new Point(148, 229);
            comboBox1.Margin = new Padding(2, 2, 2, 2);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(116, 23);
            comboBox1.TabIndex = 14;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(8, 232);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(116, 15);
            label4.TabIndex = 15;
            label4.Text = "Remember Memory:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(293, 38);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(91, 15);
            label5.TabIndex = 16;
            label5.Text = "Only Chat With:";
            // 
            // textBox3
            // 
            textBox3.AcceptsReturn = true;
            textBox3.Location = new Point(295, 58);
            textBox3.Margin = new Padding(2, 2, 2, 2);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.ScrollBars = ScrollBars.Both;
            textBox3.Size = new Size(248, 77);
            textBox3.TabIndex = 17;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // label6
            // 
            label6.Font = new Font("Segoe UI", 7F);
            label6.Location = new Point(293, 135);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(246, 37);
            label6.TabIndex = 18;
            label6.Text = "Leave this blank to talk to everyone. Otherwise, write the username of everybody the bot is ALLOWED to talk to, separated by new lines.";
            // 
            // label7
            // 
            label7.Location = new Point(476, 249);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(97, 20);
            label7.TabIndex = 19;
            label7.Text = "Bot Language:";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(577, 244);
            textBox4.Margin = new Padding(2, 2, 2, 2);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(58, 23);
            textBox4.TabIndex = 20;
            textBox4.TextChanged += textBox4_TextChanged;
            // 
            // label8
            // 
            label8.Font = new Font("Segoe UI", 7F);
            label8.Location = new Point(407, 269);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(228, 29);
            label8.TabIndex = 21;
            label8.Text = "list can be found at https://cloud.google.com/translate/docs/languages";
            label8.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(8, 185);
            label9.Margin = new Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.Size = new Size(129, 15);
            label9.TabIndex = 22;
            label9.Text = "Allow Insecure Coding:";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "Yes", "No" });
            comboBox2.Location = new Point(148, 183);
            comboBox2.Margin = new Padding(2, 2, 2, 2);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(116, 23);
            comboBox2.TabIndex = 23;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 7F);
            label10.Location = new Point(11, 209);
            label10.Margin = new Padding(2, 0, 2, 0);
            label10.Name = "label10";
            label10.Size = new Size(235, 12);
            label10.TabIndex = 24;
            label10.Text = "Don't enable this when connecting to public servers.";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(152, 280);
            textBox5.Margin = new Padding(2, 2, 2, 2);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(232, 23);
            textBox5.TabIndex = 25;
            textBox5.TextChanged += textBox5_TextChanged;
            // 
            // checkedListBox1
            // 
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Items.AddRange(new object[] { "self_preservation", "unstuck", "cowardice", "self_defense", "hunting", "item_collecting", "torch_placing", "elbow_room", "idle_staring", "cheat" });
            checkedListBox1.Location = new Point(8, 55);
            checkedListBox1.Margin = new Padding(2, 2, 2, 2);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(253, 112);
            checkedListBox1.TabIndex = 26;
            checkedListBox1.SelectedIndexChanged += checkedListBox1_SelectedIndexChanged;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(8, 36);
            label11.Margin = new Padding(2, 0, 2, 0);
            label11.Name = "label11";
            label11.Size = new Size(108, 15);
            label11.TabIndex = 27;
            label11.Text = "Bot Customization:";
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 7F);
            button2.Location = new Point(304, 220);
            button2.Margin = new Padding(2, 2, 2, 2);
            button2.Name = "button2";
            button2.Size = new Size(144, 20);
            button2.TabIndex = 28;
            button2.Text = "Open Settings in Text Editor";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 7F);
            button3.Location = new Point(304, 244);
            button3.Margin = new Padding(2, 2, 2, 2);
            button3.Name = "button3";
            button3.Size = new Size(144, 20);
            button3.TabIndex = 29;
            button3.Text = "Open Profile in Text Editor";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // settings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(646, 341);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(label11);
            Controls.Add(checkedListBox1);
            Controls.Add(textBox5);
            Controls.Add(label10);
            Controls.Add(comboBox2);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(textBox4);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(textBox3);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(comboBox1);
            Controls.Add(textBox2);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2, 2, 2, 2);
            MaximizeBox = false;
            Name = "settings";
            Text = "Settings";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private Label label3;
        private TextBox textBox2;
        private ComboBox comboBox1;
        private Label label4;
        private Label label5;
        private TextBox textBox3;
        private Label label6;
        private Label label7;
        private TextBox textBox4;
        private Label label8;
        private Label label9;
        private ComboBox comboBox2;
        private Label label10;
        private TextBox textBox5;
        private CheckedListBox checkedListBox1;
        private Label label11;
        private Button button2;
        private Button button3;
    }
}