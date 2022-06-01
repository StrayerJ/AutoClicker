namespace Auto_Clicker
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.PositionsGroupBox = new System.Windows.Forms.GroupBox();
            this.btnUpdateRow = new System.Windows.Forms.Button();
            this.SleepTimeTextBox = new System.Windows.Forms.TextBox();
            this.QueuedYPositionTextBox = new System.Windows.Forms.TextBox();
            this.RightClickCheckBox = new System.Windows.Forms.CheckBox();
            this.SleepTimeLabel = new System.Windows.Forms.Label();
            this.AddPositionButton = new System.Windows.Forms.Button();
            this.QueuedXPositionLabel = new System.Windows.Forms.Label();
            this.QueuedYPositionLabel = new System.Windows.Forms.Label();
            this.QueuedXPositionTextBox = new System.Windows.Forms.TextBox();
            this.PositionsListView = new System.Windows.Forms.ListView();
            this.XCoordHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.YCoordHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LRHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SleepTimeHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ListViewContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.RemoveAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveSelectedMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.QueuedPositionsLabel = new System.Windows.Forms.Label();
            this.CurrentPosGroupBox = new System.Windows.Forms.GroupBox();
            this.CopyToAddButton = new System.Windows.Forms.Button();
            this.CurrentYCoordTextBox = new System.Windows.Forms.TextBox();
            this.XCoordLabel = new System.Windows.Forms.Label();
            this.YCoordLabel = new System.Windows.Forms.Label();
            this.CurrentXCoordTextBox = new System.Windows.Forms.TextBox();
            this.StartingOptionsGroupBox = new System.Windows.Forms.GroupBox();
            this.StopClickingButton = new System.Windows.Forms.Button();
            this.StartClickingButton = new System.Windows.Forms.Button();
            this.NumRepeatsTextBox = new System.Windows.Forms.TextBox();
            this.NumRepeatsLabel = new System.Windows.Forms.Label();
            this.CurrentPositionTimer = new System.Windows.Forms.Timer(this.components);
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.ddlFileNames = new System.Windows.Forms.ComboBox();
            this.lblCurrentState = new System.Windows.Forms.Label();
            this.PositionsGroupBox.SuspendLayout();
            this.ListViewContextMenu.SuspendLayout();
            this.CurrentPosGroupBox.SuspendLayout();
            this.StartingOptionsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // PositionsGroupBox
            // 
            this.PositionsGroupBox.Controls.Add(this.btnUpdateRow);
            this.PositionsGroupBox.Controls.Add(this.SleepTimeTextBox);
            this.PositionsGroupBox.Controls.Add(this.QueuedYPositionTextBox);
            this.PositionsGroupBox.Controls.Add(this.RightClickCheckBox);
            this.PositionsGroupBox.Controls.Add(this.SleepTimeLabel);
            this.PositionsGroupBox.Controls.Add(this.AddPositionButton);
            this.PositionsGroupBox.Controls.Add(this.QueuedXPositionLabel);
            this.PositionsGroupBox.Controls.Add(this.QueuedYPositionLabel);
            this.PositionsGroupBox.Controls.Add(this.QueuedXPositionTextBox);
            this.PositionsGroupBox.Controls.Add(this.PositionsListView);
            this.PositionsGroupBox.Controls.Add(this.QueuedPositionsLabel);
            this.PositionsGroupBox.Location = new System.Drawing.Point(285, 3);
            this.PositionsGroupBox.Name = "PositionsGroupBox";
            this.PositionsGroupBox.Size = new System.Drawing.Size(350, 279);
            this.PositionsGroupBox.TabIndex = 0;
            this.PositionsGroupBox.TabStop = false;
            this.PositionsGroupBox.Text = "Cursor Positions";
            // 
            // btnUpdateRow
            // 
            this.btnUpdateRow.Location = new System.Drawing.Point(80, 222);
            this.btnUpdateRow.Name = "btnUpdateRow";
            this.btnUpdateRow.Size = new System.Drawing.Size(70, 23);
            this.btnUpdateRow.TabIndex = 12;
            this.btnUpdateRow.Text = "Update";
            this.btnUpdateRow.UseVisualStyleBackColor = true;
            this.btnUpdateRow.Click += new System.EventHandler(this.btnUpdateRow_Click);
            // 
            // SleepTimeTextBox
            // 
            this.SleepTimeTextBox.Location = new System.Drawing.Point(227, 254);
            this.SleepTimeTextBox.Name = "SleepTimeTextBox";
            this.SleepTimeTextBox.Size = new System.Drawing.Size(116, 20);
            this.SleepTimeTextBox.TabIndex = 11;
            this.SleepTimeTextBox.Text = "1000";
            // 
            // QueuedYPositionTextBox
            // 
            this.QueuedYPositionTextBox.Location = new System.Drawing.Point(279, 225);
            this.QueuedYPositionTextBox.Name = "QueuedYPositionTextBox";
            this.QueuedYPositionTextBox.Size = new System.Drawing.Size(64, 20);
            this.QueuedYPositionTextBox.TabIndex = 10;
            // 
            // RightClickCheckBox
            // 
            this.RightClickCheckBox.AutoSize = true;
            this.RightClickCheckBox.Location = new System.Drawing.Point(6, 256);
            this.RightClickCheckBox.Name = "RightClickCheckBox";
            this.RightClickCheckBox.Size = new System.Drawing.Size(83, 17);
            this.RightClickCheckBox.TabIndex = 9;
            this.RightClickCheckBox.Text = "Right Click?";
            this.RightClickCheckBox.UseVisualStyleBackColor = true;
            // 
            // SleepTimeLabel
            // 
            this.SleepTimeLabel.AutoSize = true;
            this.SleepTimeLabel.Location = new System.Drawing.Point(115, 257);
            this.SleepTimeLabel.Name = "SleepTimeLabel";
            this.SleepTimeLabel.Size = new System.Drawing.Size(103, 13);
            this.SleepTimeLabel.TabIndex = 5;
            this.SleepTimeLabel.Text = "Time to Sleep (ms) - ";
            // 
            // AddPositionButton
            // 
            this.AddPositionButton.Location = new System.Drawing.Point(6, 222);
            this.AddPositionButton.Name = "AddPositionButton";
            this.AddPositionButton.Size = new System.Drawing.Size(70, 23);
            this.AddPositionButton.TabIndex = 4;
            this.AddPositionButton.Text = "Add (F2)";
            this.AddPositionButton.UseVisualStyleBackColor = true;
            this.AddPositionButton.Click += new System.EventHandler(this.AddPositionButton_Click);
            // 
            // QueuedXPositionLabel
            // 
            this.QueuedXPositionLabel.AutoSize = true;
            this.QueuedXPositionLabel.Location = new System.Drawing.Point(173, 228);
            this.QueuedXPositionLabel.Name = "QueuedXPositionLabel";
            this.QueuedXPositionLabel.Size = new System.Drawing.Size(14, 13);
            this.QueuedXPositionLabel.TabIndex = 7;
            this.QueuedXPositionLabel.Text = "X";
            // 
            // QueuedYPositionLabel
            // 
            this.QueuedYPositionLabel.AutoSize = true;
            this.QueuedYPositionLabel.Location = new System.Drawing.Point(263, 228);
            this.QueuedYPositionLabel.Name = "QueuedYPositionLabel";
            this.QueuedYPositionLabel.Size = new System.Drawing.Size(14, 13);
            this.QueuedYPositionLabel.TabIndex = 8;
            this.QueuedYPositionLabel.Text = "Y";
            // 
            // QueuedXPositionTextBox
            // 
            this.QueuedXPositionTextBox.Location = new System.Drawing.Point(193, 224);
            this.QueuedXPositionTextBox.Name = "QueuedXPositionTextBox";
            this.QueuedXPositionTextBox.Size = new System.Drawing.Size(64, 20);
            this.QueuedXPositionTextBox.TabIndex = 8;
            // 
            // PositionsListView
            // 
            this.PositionsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.XCoordHeader,
            this.YCoordHeader,
            this.LRHeader,
            this.SleepTimeHeader});
            this.PositionsListView.ContextMenuStrip = this.ListViewContextMenu;
            this.PositionsListView.FullRowSelect = true;
            this.PositionsListView.GridLines = true;
            this.PositionsListView.HideSelection = false;
            this.PositionsListView.Location = new System.Drawing.Point(6, 32);
            this.PositionsListView.MultiSelect = false;
            this.PositionsListView.Name = "PositionsListView";
            this.PositionsListView.Size = new System.Drawing.Size(338, 181);
            this.PositionsListView.TabIndex = 1;
            this.PositionsListView.UseCompatibleStateImageBehavior = false;
            this.PositionsListView.View = System.Windows.Forms.View.Details;
            this.PositionsListView.SelectedIndexChanged += new System.EventHandler(this.PositionsListView_SelectedIndexChanged);
            // 
            // XCoordHeader
            // 
            this.XCoordHeader.Text = "X";
            this.XCoordHeader.Width = 74;
            // 
            // YCoordHeader
            // 
            this.YCoordHeader.Text = "Y";
            this.YCoordHeader.Width = 75;
            // 
            // LRHeader
            // 
            this.LRHeader.Text = "L/R";
            this.LRHeader.Width = 76;
            // 
            // SleepTimeHeader
            // 
            this.SleepTimeHeader.Text = "Time to Sleep";
            this.SleepTimeHeader.Width = 104;
            // 
            // ListViewContextMenu
            // 
            this.ListViewContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RemoveAllMenuItem,
            this.RemoveSelectedMenuItem});
            this.ListViewContextMenu.Name = "ListViewContextMenu";
            this.ListViewContextMenu.Size = new System.Drawing.Size(167, 48);
            // 
            // RemoveAllMenuItem
            // 
            this.RemoveAllMenuItem.Name = "RemoveAllMenuItem";
            this.RemoveAllMenuItem.Size = new System.Drawing.Size(166, 22);
            this.RemoveAllMenuItem.Text = "Remove All Items";
            this.RemoveAllMenuItem.Click += new System.EventHandler(this.RemoveAllMenuItem_Click);
            // 
            // RemoveSelectedMenuItem
            // 
            this.RemoveSelectedMenuItem.Name = "RemoveSelectedMenuItem";
            this.RemoveSelectedMenuItem.Size = new System.Drawing.Size(166, 22);
            this.RemoveSelectedMenuItem.Text = "Remove Selected";
            this.RemoveSelectedMenuItem.Click += new System.EventHandler(this.RemoveSelectedMenuItem_Click);
            // 
            // QueuedPositionsLabel
            // 
            this.QueuedPositionsLabel.AutoSize = true;
            this.QueuedPositionsLabel.Location = new System.Drawing.Point(3, 16);
            this.QueuedPositionsLabel.Name = "QueuedPositionsLabel";
            this.QueuedPositionsLabel.Size = new System.Drawing.Size(123, 13);
            this.QueuedPositionsLabel.TabIndex = 0;
            this.QueuedPositionsLabel.Text = "Queued Cursor Positions";
            // 
            // CurrentPosGroupBox
            // 
            this.CurrentPosGroupBox.Controls.Add(this.CopyToAddButton);
            this.CurrentPosGroupBox.Controls.Add(this.CurrentYCoordTextBox);
            this.CurrentPosGroupBox.Controls.Add(this.XCoordLabel);
            this.CurrentPosGroupBox.Controls.Add(this.YCoordLabel);
            this.CurrentPosGroupBox.Controls.Add(this.CurrentXCoordTextBox);
            this.CurrentPosGroupBox.Location = new System.Drawing.Point(12, 12);
            this.CurrentPosGroupBox.Name = "CurrentPosGroupBox";
            this.CurrentPosGroupBox.Size = new System.Drawing.Size(267, 131);
            this.CurrentPosGroupBox.TabIndex = 2;
            this.CurrentPosGroupBox.TabStop = false;
            this.CurrentPosGroupBox.Text = "Current Cursor Position";
            // 
            // CopyToAddButton
            // 
            this.CopyToAddButton.Location = new System.Drawing.Point(9, 85);
            this.CopyToAddButton.Name = "CopyToAddButton";
            this.CopyToAddButton.Size = new System.Drawing.Size(252, 30);
            this.CopyToAddButton.TabIndex = 6;
            this.CopyToAddButton.Text = "Copy to Add Position (F1)";
            this.CopyToAddButton.UseVisualStyleBackColor = true;
            this.CopyToAddButton.Click += new System.EventHandler(this.CopyToAddButton_Click);
            // 
            // CurrentYCoordTextBox
            // 
            this.CurrentYCoordTextBox.Location = new System.Drawing.Point(47, 49);
            this.CurrentYCoordTextBox.Name = "CurrentYCoordTextBox";
            this.CurrentYCoordTextBox.Size = new System.Drawing.Size(214, 20);
            this.CurrentYCoordTextBox.TabIndex = 5;
            // 
            // XCoordLabel
            // 
            this.XCoordLabel.AutoSize = true;
            this.XCoordLabel.Location = new System.Drawing.Point(6, 26);
            this.XCoordLabel.Name = "XCoordLabel";
            this.XCoordLabel.Size = new System.Drawing.Size(14, 13);
            this.XCoordLabel.TabIndex = 2;
            this.XCoordLabel.Text = "X";
            // 
            // YCoordLabel
            // 
            this.YCoordLabel.AutoSize = true;
            this.YCoordLabel.Location = new System.Drawing.Point(6, 56);
            this.YCoordLabel.Name = "YCoordLabel";
            this.YCoordLabel.Size = new System.Drawing.Size(14, 13);
            this.YCoordLabel.TabIndex = 3;
            this.YCoordLabel.Text = "Y";
            // 
            // CurrentXCoordTextBox
            // 
            this.CurrentXCoordTextBox.Location = new System.Drawing.Point(47, 23);
            this.CurrentXCoordTextBox.Name = "CurrentXCoordTextBox";
            this.CurrentXCoordTextBox.Size = new System.Drawing.Size(214, 20);
            this.CurrentXCoordTextBox.TabIndex = 4;
            // 
            // StartingOptionsGroupBox
            // 
            this.StartingOptionsGroupBox.Controls.Add(this.StopClickingButton);
            this.StartingOptionsGroupBox.Controls.Add(this.StartClickingButton);
            this.StartingOptionsGroupBox.Controls.Add(this.NumRepeatsTextBox);
            this.StartingOptionsGroupBox.Controls.Add(this.NumRepeatsLabel);
            this.StartingOptionsGroupBox.Location = new System.Drawing.Point(12, 149);
            this.StartingOptionsGroupBox.Name = "StartingOptionsGroupBox";
            this.StartingOptionsGroupBox.Size = new System.Drawing.Size(267, 133);
            this.StartingOptionsGroupBox.TabIndex = 2;
            this.StartingOptionsGroupBox.TabStop = false;
            this.StartingOptionsGroupBox.Text = "Starting Options";
            // 
            // StopClickingButton
            // 
            this.StopClickingButton.Location = new System.Drawing.Point(6, 85);
            this.StopClickingButton.Name = "StopClickingButton";
            this.StopClickingButton.Size = new System.Drawing.Size(255, 37);
            this.StopClickingButton.TabIndex = 3;
            this.StopClickingButton.Text = "Stop Clicking (F4)";
            this.StopClickingButton.UseVisualStyleBackColor = true;
            this.StopClickingButton.Click += new System.EventHandler(this.StopClickingButton_Click);
            // 
            // StartClickingButton
            // 
            this.StartClickingButton.Location = new System.Drawing.Point(6, 42);
            this.StartClickingButton.Name = "StartClickingButton";
            this.StartClickingButton.Size = new System.Drawing.Size(255, 37);
            this.StartClickingButton.TabIndex = 2;
            this.StartClickingButton.Text = "Start Clicking Queued Positions (F3)";
            this.StartClickingButton.UseVisualStyleBackColor = true;
            this.StartClickingButton.Click += new System.EventHandler(this.StartClickingButton_Click);
            // 
            // NumRepeatsTextBox
            // 
            this.NumRepeatsTextBox.Location = new System.Drawing.Point(120, 16);
            this.NumRepeatsTextBox.Name = "NumRepeatsTextBox";
            this.NumRepeatsTextBox.Size = new System.Drawing.Size(141, 20);
            this.NumRepeatsTextBox.TabIndex = 1;
            this.NumRepeatsTextBox.Text = "1";
            this.NumRepeatsTextBox.TextChanged += new System.EventHandler(this.NumRepeatsTextBox_TextChanged);
            // 
            // NumRepeatsLabel
            // 
            this.NumRepeatsLabel.AutoSize = true;
            this.NumRepeatsLabel.Location = new System.Drawing.Point(6, 19);
            this.NumRepeatsLabel.Name = "NumRepeatsLabel";
            this.NumRepeatsLabel.Size = new System.Drawing.Size(108, 13);
            this.NumRepeatsLabel.TabIndex = 0;
            this.NumRepeatsLabel.Text = "Number of Repeats - ";
            // 
            // CurrentPositionTimer
            // 
            this.CurrentPositionTimer.Interval = 1;
            this.CurrentPositionTimer.Tick += new System.EventHandler(this.CurrentPositionTimer_Tick);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(512, 288);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(61, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(574, 288);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(61, 23);
            this.btnLoad.TabIndex = 5;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // ddlFileNames
            // 
            this.ddlFileNames.FormattingEnabled = true;
            this.ddlFileNames.Location = new System.Drawing.Point(385, 290);
            this.ddlFileNames.Name = "ddlFileNames";
            this.ddlFileNames.Size = new System.Drawing.Size(121, 21);
            this.ddlFileNames.TabIndex = 6;
            // 
            // label1
            // 
            this.lblCurrentState.AutoSize = true;
            this.lblCurrentState.Location = new System.Drawing.Point(21, 297);
            this.lblCurrentState.Name = "label1";
            this.lblCurrentState.Size = new System.Drawing.Size(35, 13);
            this.lblCurrentState.TabIndex = 7;
            this.lblCurrentState.Text = "label1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 315);
            this.Controls.Add(this.lblCurrentState);
            this.Controls.Add(this.ddlFileNames);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.StartingOptionsGroupBox);
            this.Controls.Add(this.CurrentPosGroupBox);
            this.Controls.Add(this.PositionsGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Auto Clicker";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.PositionsGroupBox.ResumeLayout(false);
            this.PositionsGroupBox.PerformLayout();
            this.ListViewContextMenu.ResumeLayout(false);
            this.CurrentPosGroupBox.ResumeLayout(false);
            this.CurrentPosGroupBox.PerformLayout();
            this.StartingOptionsGroupBox.ResumeLayout(false);
            this.StartingOptionsGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox PositionsGroupBox;
        private System.Windows.Forms.TextBox SleepTimeTextBox;
        private System.Windows.Forms.TextBox QueuedYPositionTextBox;
        private System.Windows.Forms.CheckBox RightClickCheckBox;
        private System.Windows.Forms.Label SleepTimeLabel;
        private System.Windows.Forms.Button AddPositionButton;
        private System.Windows.Forms.Label QueuedXPositionLabel;
        private System.Windows.Forms.Label QueuedYPositionLabel;
        private System.Windows.Forms.TextBox QueuedXPositionTextBox;
        private System.Windows.Forms.ListView PositionsListView;
        private System.Windows.Forms.ColumnHeader XCoordHeader;
        private System.Windows.Forms.ColumnHeader YCoordHeader;
        private System.Windows.Forms.ColumnHeader LRHeader;
        private System.Windows.Forms.ColumnHeader SleepTimeHeader;
        private System.Windows.Forms.Label QueuedPositionsLabel;
        private System.Windows.Forms.GroupBox CurrentPosGroupBox;
        private System.Windows.Forms.Button CopyToAddButton;
        private System.Windows.Forms.TextBox CurrentYCoordTextBox;
        private System.Windows.Forms.Label XCoordLabel;
        private System.Windows.Forms.Label YCoordLabel;
        private System.Windows.Forms.TextBox CurrentXCoordTextBox;
        private System.Windows.Forms.GroupBox StartingOptionsGroupBox;
        private System.Windows.Forms.Button StopClickingButton;
        private System.Windows.Forms.Button StartClickingButton;
        private System.Windows.Forms.TextBox NumRepeatsTextBox;
        private System.Windows.Forms.Label NumRepeatsLabel;
        private System.Windows.Forms.Timer CurrentPositionTimer;
        private System.Windows.Forms.ContextMenuStrip ListViewContextMenu;
        private System.Windows.Forms.ToolStripMenuItem RemoveAllMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RemoveSelectedMenuItem;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnUpdateRow;
        private System.Windows.Forms.ComboBox ddlFileNames;
        private System.Windows.Forms.Label lblCurrentState;
    }
}

