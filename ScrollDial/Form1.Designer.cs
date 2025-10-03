namespace ScrollDial
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblCurrentApp = new Label();
            lblProcesses = new Label();
            btnRefresh = new Button();
            lstProcesses = new ListBox();
            btnQuit = new Button();
            grpAssignments = new GroupBox();
            txtCCWB = new TextBox();
            txtCCWNoB = new TextBox();
            txtCWB = new TextBox();
            txtCWnoB = new TextBox();
            lblCCWB = new Label();
            lblCCWNoB = new Label();
            lblCWB = new Label();
            lblCWNoB = new Label();
            lblProcessName = new Label();
            lblProcessNameTag = new Label();
            btnSave = new Button();
            grpAssignments.SuspendLayout();
            SuspendLayout();
            // 
            // lblCurrentApp
            // 
            lblCurrentApp.Location = new Point(12, 242);
            lblCurrentApp.Name = "lblCurrentApp";
            lblCurrentApp.Size = new Size(100, 20);
            lblCurrentApp.TabIndex = 0;
            // 
            // lblProcesses
            // 
            lblProcesses.AutoSize = true;
            lblProcesses.Location = new Point(12, 5);
            lblProcesses.Name = "lblProcesses";
            lblProcesses.Size = new Size(72, 20);
            lblProcesses.TabIndex = 2;
            lblProcesses.Text = "Processes";
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(220, 5);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(66, 27);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // lstProcesses
            // 
            lstProcesses.FormattingEnabled = true;
            lstProcesses.Location = new Point(12, 35);
            lstProcesses.Name = "lstProcesses";
            lstProcesses.Size = new Size(274, 244);
            lstProcesses.TabIndex = 4;
            lstProcesses.SelectedIndexChanged += lstProcesses_SelectedIndexChanged;
            // 
            // btnQuit
            // 
            btnQuit.Location = new Point(513, 300);
            btnQuit.Name = "btnQuit";
            btnQuit.Size = new Size(75, 33);
            btnQuit.TabIndex = 5;
            btnQuit.Text = "Quit";
            btnQuit.UseVisualStyleBackColor = true;
            btnQuit.Click += btnQuit_Click;
            // 
            // grpAssignments
            // 
            grpAssignments.Controls.Add(txtCCWB);
            grpAssignments.Controls.Add(txtCCWNoB);
            grpAssignments.Controls.Add(txtCWB);
            grpAssignments.Controls.Add(txtCWnoB);
            grpAssignments.Controls.Add(lblCCWB);
            grpAssignments.Controls.Add(lblCCWNoB);
            grpAssignments.Controls.Add(lblCWB);
            grpAssignments.Controls.Add(lblCWNoB);
            grpAssignments.Controls.Add(lblProcessName);
            grpAssignments.Controls.Add(lblProcessNameTag);
            grpAssignments.Controls.Add(btnSave);
            grpAssignments.Enabled = false;
            grpAssignments.Location = new Point(305, 35);
            grpAssignments.Name = "grpAssignments";
            grpAssignments.Size = new Size(283, 244);
            grpAssignments.TabIndex = 6;
            grpAssignments.TabStop = false;
            grpAssignments.Text = "Key assignments";
            // 
            // txtCCWB
            // 
            txtCCWB.Location = new Point(223, 166);
            txtCCWB.Name = "txtCCWB";
            txtCCWB.Size = new Size(54, 27);
            txtCCWB.TabIndex = 10;
            txtCCWB.KeyUp += TxtCCWB_KeyUp;
            // 
            // txtCCWNoB
            // 
            txtCCWNoB.Location = new Point(223, 133);
            txtCCWNoB.Name = "txtCCWNoB";
            txtCCWNoB.Size = new Size(54, 27);
            txtCCWNoB.TabIndex = 9;
            txtCCWNoB.KeyUp += TxtCCWNoB_KeyUp;
            // 
            // txtCWB
            // 
            txtCWB.Location = new Point(223, 100);
            txtCWB.Name = "txtCWB";
            txtCWB.Size = new Size(54, 27);
            txtCWB.TabIndex = 8;
            txtCWB.KeyUp += TxtCWB_KeyUp;
            // 
            // txtCWnoB
            // 
            txtCWnoB.Location = new Point(223, 67);
            txtCWnoB.Name = "txtCWnoB";
            txtCWnoB.Size = new Size(54, 27);
            txtCWnoB.TabIndex = 7;
            txtCWnoB.KeyUp += TxtCWnoB_KeyUp;
            // 
            // lblCCWB
            // 
            lblCCWB.AutoSize = true;
            lblCCWB.Location = new Point(27, 169);
            lblCCWB.Name = "lblCCWB";
            lblCCWB.Size = new Size(190, 20);
            lblCCWB.TabIndex = 6;
            lblCCWB.Text = "Counter-Clockwise (button)";
            // 
            // lblCCWNoB
            // 
            lblCCWNoB.AutoSize = true;
            lblCCWNoB.Location = new Point(6, 136);
            lblCCWNoB.Name = "lblCCWNoB";
            lblCCWNoB.Size = new Size(211, 20);
            lblCCWNoB.TabIndex = 5;
            lblCCWNoB.Text = "Counter-Clockwise (no button)";
            // 
            // lblCWB
            // 
            lblCWB.AutoSize = true;
            lblCWB.Location = new Point(85, 103);
            lblCWB.Name = "lblCWB";
            lblCWB.Size = new Size(132, 20);
            lblCWB.TabIndex = 4;
            lblCWB.Text = "Clockwise (button)";
            // 
            // lblCWNoB
            // 
            lblCWNoB.AutoSize = true;
            lblCWNoB.Location = new Point(64, 70);
            lblCWNoB.Name = "lblCWNoB";
            lblCWNoB.Size = new Size(153, 20);
            lblCWNoB.TabIndex = 3;
            lblCWNoB.Text = "Clockwise (no button)";
            // 
            // lblProcessName
            // 
            lblProcessName.Location = new Point(73, 33);
            lblProcessName.Name = "lblProcessName";
            lblProcessName.Size = new Size(204, 23);
            lblProcessName.TabIndex = 2;
            // 
            // lblProcessNameTag
            // 
            lblProcessNameTag.AutoSize = true;
            lblProcessNameTag.Location = new Point(6, 33);
            lblProcessNameTag.Name = "lblProcessNameTag";
            lblProcessNameTag.Size = new Size(61, 20);
            lblProcessNameTag.TabIndex = 1;
            lblProcessNameTag.Text = "Process:";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(202, 201);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 33);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(600, 345);
            Controls.Add(grpAssignments);
            Controls.Add(btnQuit);
            Controls.Add(lstProcesses);
            Controls.Add(btnRefresh);
            Controls.Add(lblProcesses);
            Controls.Add(lblCurrentApp);
            Name = "Form1";
            Text = "Form1";
            grpAssignments.ResumeLayout(false);
            grpAssignments.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCurrentApp;
        private Label lblProcesses;
        private Button btnRefresh;
        private ListBox lstProcesses;
        private Button btnQuit;
        private GroupBox grpAssignments;
        private Button btnSave;
        private Label lblProcessNameTag;
        private Label lblProcessName;
        private Label lblCWNoB;
        private Label lblCCWB;
        private Label lblCCWNoB;
        private Label lblCWB;
        private TextBox txtCCWB;
        private TextBox txtCCWNoB;
        private TextBox txtCWB;
        private TextBox txtCWnoB;
    }
}
