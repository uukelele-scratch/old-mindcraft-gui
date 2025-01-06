namespace Mindcraft_Installer
{
    partial class prismarine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(prismarine));
            viewer = new Microsoft.Web.WebView2.WinForms.WebView2();
            ((System.ComponentModel.ISupportInitialize)viewer).BeginInit();
            SuspendLayout();
            // 
            // viewer
            // 
            viewer.AllowExternalDrop = true;
            viewer.CreationProperties = null;
            viewer.DefaultBackgroundColor = Color.White;
            viewer.Location = new Point(12, 12);
            viewer.Name = "viewer";
            viewer.Size = new Size(776, 426);
            viewer.TabIndex = 0;
            viewer.ZoomFactor = 1D;
            // 
            // prismarine
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(viewer);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "prismarine";
            Text = "Bot Viewer";
            ((System.ComponentModel.ISupportInitialize)viewer).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 viewer;
    }
}