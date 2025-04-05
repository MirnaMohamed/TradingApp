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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeForm));
            menuStrip1 = new MenuStrip();
            warehouseToolStripItem = new ToolStripMenuItem();
            warehouseSubItem1 = new ToolStripMenuItem();
            warehouseSubItem2 = new ToolStripMenuItem();
            warehouseSubItem3 = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            menuItem2SubItem1 = new ToolStripMenuItem();
            menuItem2SubItem2 = new ToolStripMenuItem();
            menuItem2SubItem3 = new ToolStripMenuItem();
            welcomeLabel = new Label();
            addSupplyRequestBtn = new Button();
            addReleaseRequestBtn = new Button();
            logoutBtn = new Button();
            addTransferRequestBtn = new Button();
            listView1 = new ListView();
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
            warehouseToolStripItem.DropDownItems.AddRange(new ToolStripItem[] { warehouseSubItem1, warehouseSubItem2, warehouseSubItem3 });
            warehouseToolStripItem.Name = "warehouseToolStripItem";
            warehouseToolStripItem.Size = new Size(96, 24);
            warehouseToolStripItem.Text = "Warehouse";
            warehouseToolStripItem.DropDownItemClicked += toolStripMenuItem1_DropDownItemClicked;
            // 
            // warehouseSubItem1
            // 
            warehouseSubItem1.Name = "warehouseSubItem1";
            warehouseSubItem1.Size = new Size(224, 26);
            warehouseSubItem1.Text = "x";
            // 
            // warehouseSubItem2
            // 
            warehouseSubItem2.Name = "warehouseSubItem2";
            warehouseSubItem2.Size = new Size(224, 26);
            warehouseSubItem2.Text = "y";
            // 
            // warehouseSubItem3
            // 
            warehouseSubItem3.Name = "warehouseSubItem3";
            warehouseSubItem3.Size = new Size(224, 26);
            warehouseSubItem3.Text = "z";
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
            // addSupplyRequestBtn
            // 
            addSupplyRequestBtn.Location = new Point(85, 122);
            addSupplyRequestBtn.Name = "addSupplyRequestBtn";
            addSupplyRequestBtn.Size = new Size(221, 40);
            addSupplyRequestBtn.TabIndex = 2;
            addSupplyRequestBtn.Text = "Add Supply Request";
            addSupplyRequestBtn.UseVisualStyleBackColor = true;
            addSupplyRequestBtn.Click += AddSupplyRequest_Click;
            // 
            // addReleaseRequestBtn
            // 
            addReleaseRequestBtn.Location = new Point(85, 186);
            addReleaseRequestBtn.Name = "addReleaseRequestBtn";
            addReleaseRequestBtn.Size = new Size(221, 40);
            addReleaseRequestBtn.TabIndex = 3;
            addReleaseRequestBtn.Text = "Add Release Request";
            addReleaseRequestBtn.UseVisualStyleBackColor = true;
            addReleaseRequestBtn.Click += addReleaseRequest_Click;
            // 
            // logoutBtn
            // 
            logoutBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            logoutBtn.BackColor = Color.IndianRed;
            logoutBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            logoutBtn.Location = new Point(680, 384);
            logoutBtn.Name = "logoutBtn";
            logoutBtn.Size = new Size(95, 43);
            logoutBtn.TabIndex = 4;
            logoutBtn.Text = "Log Out";
            logoutBtn.UseVisualStyleBackColor = false;
            logoutBtn.Click += Logout_Click;
            // 
            // addTransferRequestBtn
            // 
            addTransferRequestBtn.Location = new Point(85, 250);
            addTransferRequestBtn.Name = "addTransferRequestBtn";
            addTransferRequestBtn.Size = new Size(221, 40);
            addTransferRequestBtn.TabIndex = 5;
            addTransferRequestBtn.Text = "Add Transfer Request";
            addTransferRequestBtn.UseVisualStyleBackColor = true;
            addTransferRequestBtn.Click += AddTransferRequest_Click;
            // 
            // listView1
            // 
            listView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listView1.FullRowSelect = true;
            listView1.Location = new Point(367, 113);
            listView1.Name = "listView1";
            listView1.Size = new Size(408, 254);
            listView1.TabIndex = 7;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.List;
            // 
            // HomeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(listView1);
            Controls.Add(addTransferRequestBtn);
            Controls.Add(logoutBtn);
            Controls.Add(addReleaseRequestBtn);
            Controls.Add(addSupplyRequestBtn);
            Controls.Add(welcomeLabel);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
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
        private ToolStripMenuItem warehouseSubItem1;
        private ToolStripMenuItem warehouseSubItem2;
        private ToolStripMenuItem warehouseSubItem3;
        private ToolStripMenuItem menuItem2SubItem1;
        private ToolStripMenuItem menuItem2SubItem2;
        private ToolStripMenuItem menuItem2SubItem3;
        private Label welcomeLabel;
        private Button addSupplyRequestBtn;
        private Button addReleaseRequestBtn;
        private Button logoutBtn;
        private Button addTransferRequestBtn;
        private ListView listView1;
    }
}