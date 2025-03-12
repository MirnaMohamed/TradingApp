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
            warehouseToolStripItem = new ToolStripMenuItem();
            menuItem1SubItem1 = new ToolStripMenuItem();
            menuItem1SubItem2 = new ToolStripMenuItem();
            menuItem1SubItem3 = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            menuItem2SubItem1 = new ToolStripMenuItem();
            menuItem2SubItem2 = new ToolStripMenuItem();
            menuItem2SubItem3 = new ToolStripMenuItem();
            welcomeLabel = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            listBox1 = new ListBox();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { warehouseToolStripItem, toolStripMenuItem2 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // warehouseToolStripItem
            // 
            warehouseToolStripItem.DropDownItems.AddRange(new ToolStripItem[] { menuItem1SubItem1, menuItem1SubItem2, menuItem1SubItem3 });
            warehouseToolStripItem.Name = "warehouseToolStripItem";
            warehouseToolStripItem.Size = new Size(96, 24);
            warehouseToolStripItem.Text = "Warehouse";
            warehouseToolStripItem.DropDownItemClicked += toolStripMenuItem1_DropDownItemClicked;
            // 
            // menuItem1SubItem1
            // 
            menuItem1SubItem1.Name = "menuItem1SubItem1";
            menuItem1SubItem1.Size = new Size(224, 26);
            menuItem1SubItem1.Text = "x";
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
            toolStripMenuItem2.Size = new Size(32, 24);
            toolStripMenuItem2.Text = "b";
            toolStripMenuItem2.DropDownItemClicked += toolStripMenuItem1_DropDownItemClicked;
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
            welcomeLabel.Size = new Size(120, 32);
            welcomeLabel.TabIndex = 1;
            welcomeLabel.Text = "Welcome ";
            // 
            // button1
            // 
            button1.Location = new Point(85, 122);
            button1.Name = "button1";
            button1.Size = new Size(221, 40);
            button1.TabIndex = 2;
            button1.Text = "Add Supply Request";
            button1.UseVisualStyleBackColor = true;
            button1.Click += ModifySupplyRequest;
            // 
            // button2
            // 
            button2.Location = new Point(85, 186);
            button2.Name = "button2";
            button2.Size = new Size(221, 40);
            button2.TabIndex = 3;
            button2.Text = "Add Release Request";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button3.BackColor = Color.IndianRed;
            button3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button3.Location = new Point(680, 384);
            button3.Name = "button3";
            button3.Size = new Size(95, 43);
            button3.TabIndex = 4;
            button3.Text = "Log Out";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(85, 250);
            button4.Name = "button4";
            button4.Size = new Size(221, 40);
            button4.TabIndex = 5;
            button4.Text = "Add Transfer Request";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // listBox1
            // 
            listBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(445, 98);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(309, 264);
            listBox1.TabIndex = 6;
            // 
            // HomeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(listBox1);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
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
        private ToolStripMenuItem warehouseToolStripItem;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem menuItem1SubItem1;
        private ToolStripMenuItem menuItem1SubItem2;
        private ToolStripMenuItem menuItem1SubItem3;
        private ToolStripMenuItem menuItem2SubItem1;
        private ToolStripMenuItem menuItem2SubItem2;
        private ToolStripMenuItem menuItem2SubItem3;
        private Label welcomeLabel;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private ListBox listBox1;
    }
}