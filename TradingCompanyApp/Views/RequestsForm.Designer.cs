namespace TradingCompanyApp.Views
{
    partial class RequestsForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label5 = new Label();
            label4 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            dateTimePicker2 = new DateTimePicker();
            dataGridView1 = new DataGridView();
            ItemCode = new DataGridViewTextBoxColumn();
            Quantity = new DataGridViewTextBoxColumn();
            ProductionDate = new DataGridViewTextBoxColumn();
            ExpirationDate = new DataGridViewTextBoxColumn();
            submitBtn = new Button();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F);
            label1.Location = new Point(300, 30);
            label1.Name = "label1";
            label1.Size = new Size(0, 46);
            label1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(24, 109);
            label2.Name = "label2";
            label2.Size = new Size(126, 20);
            label2.TabIndex = 1;
            label2.Text = "Warehouse Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(421, 109);
            label3.Name = "label3";
            label3.Size = new Size(83, 20);
            label3.TabIndex = 2;
            label3.Text = "Supplier ID";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(24, 153);
            label5.Name = "label5";
            label5.Size = new Size(98, 20);
            label5.TabIndex = 3;
            label5.Text = "Request Date";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(421, 153);
            label4.Name = "label4";
            label4.Size = new Size(83, 20);
            label4.TabIndex = 4;
            label4.Text = "Supplier ID";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(156, 102);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(234, 27);
            textBox1.TabIndex = 5;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(528, 106);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(249, 27);
            textBox2.TabIndex = 6;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(156, 148);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(250, 27);
            dateTimePicker1.TabIndex = 9;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(528, 148);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(250, 27);
            dateTimePicker2.TabIndex = 10;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ItemCode, Quantity, ProductionDate, ExpirationDate });
            dataGridView1.Location = new Point(229, 232);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(548, 197);
            dataGridView1.TabIndex = 11;
            // 
            // ItemCode
            // 
            ItemCode.HeaderText = "Item Code";
            ItemCode.MinimumWidth = 6;
            ItemCode.Name = "ItemCode";
            ItemCode.Resizable = DataGridViewTriState.True;
            ItemCode.Width = 125;
            // 
            // Quantity
            // 
            Quantity.HeaderText = "Quantity";
            Quantity.MinimumWidth = 6;
            Quantity.Name = "Quantity";
            Quantity.Width = 125;
            // 
            // ProductionDate
            // 
            ProductionDate.HeaderText = "Prod_Date";
            ProductionDate.MinimumWidth = 6;
            ProductionDate.Name = "ProductionDate";
            ProductionDate.Width = 125;
            // 
            // ExpirationDate
            // 
            ExpirationDate.HeaderText = "Expire Date";
            ExpirationDate.MinimumWidth = 6;
            ExpirationDate.Name = "ExpirationDate";
            ExpirationDate.Width = 125;
            // 
            // submitBtn
            // 
            submitBtn.BackColor = Color.SpringGreen;
            submitBtn.DialogResult = DialogResult.OK;
            submitBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            submitBtn.Location = new Point(56, 253);
            submitBtn.Name = "submitBtn";
            submitBtn.Size = new Size(109, 43);
            submitBtn.TabIndex = 12;
            submitBtn.Text = "Submit";
            submitBtn.UseVisualStyleBackColor = false;
            submitBtn.Click += submitBtn_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Firebrick;
            button2.DialogResult = DialogResult.Cancel;
            button2.ForeColor = SystemColors.ButtonHighlight;
            button2.Location = new Point(56, 328);
            button2.Name = "button2";
            button2.Size = new Size(109, 43);
            button2.TabIndex = 13;
            button2.Text = "Cancel";
            button2.UseVisualStyleBackColor = false;
            // 
            // RequestsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(submitBtn);
            Controls.Add(dataGridView1);
            Controls.Add(dateTimePicker2);
            Controls.Add(dateTimePicker1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "RequestsForm";
            Text = "Requests Form";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label5;
        private Label label4;
        private TextBox textBox1;
        private TextBox textBox2;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private DataGridView dataGridView1;
        private Button submitBtn;
        private Button button2;
        private DataGridViewTextBoxColumn ItemCode;
        private DataGridViewTextBoxColumn Quantity;
        private DataGridViewTextBoxColumn ProductionDate;
        private DataGridViewTextBoxColumn ExpirationDate;
    }
}