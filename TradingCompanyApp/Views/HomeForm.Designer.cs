namespace TradingCompanyApp.Views
{
    partial class HomeForm
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
            menuStrip1 = new MenuStrip();
            toolStripMenuItem1 = new ToolStripMenuItem();
            menuItem1SubItem1 = new ToolStripMenuItem();
            menuItem1SubItem2 = new ToolStripMenuItem();
            menuItem1SubItem3 = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            menuItem2SubItem1 = new ToolStripMenuItem();
            menuItem2SubItem2 = new ToolStripMenuItem();
            menuItem2SubItem3 = new ToolStripMenuItem();
            welcomeLabel = new Label();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, toolStripMenuItem2 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { menuItem1SubItem1, menuItem1SubItem2, menuItem1SubItem3 });
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(156, 24);
            toolStripMenuItem1.Text = "toolStripMenuItem1";
            // 
            // menuItem1SubItem1
            // 
            menuItem1SubItem1.Name = "menuItem1SubItem1";
            menuItem1SubItem1.Size = new Size(224, 26);
            menuItem1SubItem1.Text = "x";
            menuItem1SubItem1.Click += menuItem1SubItem1_Click;
            // 
            // menuItem1SubItem2
            // 
            menuItem1SubItem2.Name = "menuItem1SubItem2";
            menuItem1SubItem2.Size = new Size(224, 26);
            menuItem1SubItem2.Text = "y";
            // 
            // menuItem1SubItem3
            // 
            menuItem1SubItem3.Name = "menuItem1SubItem3";
            menuItem1SubItem3.Size = new Size(224, 26);
            menuItem1SubItem3.Text = "z";
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.DropDownItems.AddRange(new ToolStripItem[] { menuItem2SubItem1, menuItem2SubItem2, menuItem2SubItem3 });
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(156, 24);
            toolStripMenuItem2.Text = "toolStripMenuItem2";
            // 
            // menuItem2SubItem1
            // 
            menuItem2SubItem1.Name = "menuItem2SubItem1";
            menuItem2SubItem1.Size = new Size(99, 26);
            menuItem2SubItem1.Text = "x";
            // 
            // menuItem2SubItem2
            // 
            menuItem2SubItem2.Name = "menuItem2SubItem2";
            menuItem2SubItem2.Size = new Size(99, 26);
            menuItem2SubItem2.Text = "y";
            // 
            // menuItem2SubItem3
            // 
            menuItem2SubItem3.Name = "menuItem2SubItem3";
            menuItem2SubItem3.Size = new Size(99, 26);
            menuItem2SubItem3.Text = "z";
            // 
            // welcomeLabel
            // 
            welcomeLabel.AutoSize = true;
            welcomeLabel.Font = new Font("Segoe UI", 14F);
            welcomeLabel.Location = new Point(37, 54);
            welcomeLabel.Name = "welcomeLabel";
            welcomeLabel.Size = new Size(78, 32);
            welcomeLabel.TabIndex = 1;
            welcomeLabel.Text = "label1";
            // 
            // HomeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(welcomeLabel);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "HomeForm";
            Text = "HomeForm";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem menuItem1SubItem1;
        private ToolStripMenuItem menuItem1SubItem2;
        private ToolStripMenuItem menuItem1SubItem3;
        private ToolStripMenuItem menuItem2SubItem1;
        private ToolStripMenuItem menuItem2SubItem2;
        private ToolStripMenuItem menuItem2SubItem3;
        private Label welcomeLabel;
    }
}