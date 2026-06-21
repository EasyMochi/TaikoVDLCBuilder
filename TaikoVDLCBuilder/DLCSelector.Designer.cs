namespace TaikoVDLCBuilder
{
    partial class DlcSelector
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlcSelector));
            RunButton = new System.Windows.Forms.Button();
            DBView = new System.Windows.Forms.DataGridView();
            isCheckedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            nameJPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            folderDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            genreName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            starEasyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            starNormalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            starHardDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            starManiaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            starUraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            sourceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            songItemBindingSource = new System.Windows.Forms.BindingSource(components);
            RunPBar = new System.Windows.Forms.ProgressBar();
            notifyIcon1 = new System.Windows.Forms.NotifyIcon(components);
            RandomButton = new System.Windows.Forms.Button();
            ClearButton = new System.Windows.Forms.Button();
            BottomPanel = new System.Windows.Forms.Panel();
            includeVitaDlc = new System.Windows.Forms.CheckBox();
            IntroLabel = new System.Windows.Forms.Label();
            TopPanel = new System.Windows.Forms.Panel();
            selectedCounterLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)DBView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)songItemBindingSource).BeginInit();
            BottomPanel.SuspendLayout();
            TopPanel.SuspendLayout();
            SuspendLayout();
            // 
            // RunButton
            // 
            RunButton.Dock = System.Windows.Forms.DockStyle.Right;
            RunButton.Location = new System.Drawing.Point(634, 0);
            RunButton.Margin = new System.Windows.Forms.Padding(1);
            RunButton.Name = "RunButton";
            RunButton.Size = new System.Drawing.Size(117, 46);
            RunButton.TabIndex = 1;
            RunButton.Text = "Run";
            RunButton.UseVisualStyleBackColor = true;
            RunButton.Click += RunButton_Click;
            // 
            // DBView
            // 
            DBView.AllowUserToAddRows = false;
            DBView.AllowUserToDeleteRows = false;
            DBView.AllowUserToOrderColumns = true;
            DBView.AutoGenerateColumns = false;
            DBView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DBView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { isCheckedDataGridViewCheckBoxColumn, nameDataGridViewTextBoxColumn, nameJPDataGridViewTextBoxColumn, folderDataGridViewTextBoxColumn, genreName, starEasyDataGridViewTextBoxColumn, starNormalDataGridViewTextBoxColumn, starHardDataGridViewTextBoxColumn, starManiaDataGridViewTextBoxColumn, starUraDataGridViewTextBoxColumn, sourceDataGridViewTextBoxColumn });
            DBView.DataSource = songItemBindingSource;
            DBView.Dock = System.Windows.Forms.DockStyle.Fill;
            DBView.Location = new System.Drawing.Point(0, 115);
            DBView.Margin = new System.Windows.Forms.Padding(1);
            DBView.Name = "DBView";
            DBView.RowTemplate.Height = 46;
            DBView.Size = new System.Drawing.Size(751, 400);
            DBView.TabIndex = 2;
            DBView.DataBindingComplete += DBView_DataBindingComplete;
            // 
            // isCheckedDataGridViewCheckBoxColumn
            // 
            isCheckedDataGridViewCheckBoxColumn.DataPropertyName = "isChecked";
            isCheckedDataGridViewCheckBoxColumn.Frozen = true;
            isCheckedDataGridViewCheckBoxColumn.HeaderText = "Select";
            isCheckedDataGridViewCheckBoxColumn.MinimumWidth = 20;
            isCheckedDataGridViewCheckBoxColumn.Name = "isCheckedDataGridViewCheckBoxColumn";
            isCheckedDataGridViewCheckBoxColumn.Width = 50;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.DataPropertyName = "name";
            nameDataGridViewTextBoxColumn.Frozen = true;
            nameDataGridViewTextBoxColumn.HeaderText = "Name";
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            nameDataGridViewTextBoxColumn.ReadOnly = true;
            nameDataGridViewTextBoxColumn.Width = 100;
            // 
            // nameJPDataGridViewTextBoxColumn
            // 
            nameJPDataGridViewTextBoxColumn.DataPropertyName = "nameJP";
            nameJPDataGridViewTextBoxColumn.Frozen = true;
            nameJPDataGridViewTextBoxColumn.HeaderText = "Japanese Name";
            nameJPDataGridViewTextBoxColumn.Name = "nameJPDataGridViewTextBoxColumn";
            nameJPDataGridViewTextBoxColumn.ReadOnly = true;
            nameJPDataGridViewTextBoxColumn.Width = 100;
            // 
            // folderDataGridViewTextBoxColumn
            // 
            folderDataGridViewTextBoxColumn.DataPropertyName = "folder";
            folderDataGridViewTextBoxColumn.HeaderText = "folder";
            folderDataGridViewTextBoxColumn.Name = "folderDataGridViewTextBoxColumn";
            folderDataGridViewTextBoxColumn.ReadOnly = true;
            folderDataGridViewTextBoxColumn.Visible = false;
            folderDataGridViewTextBoxColumn.Width = 100;
            // 
            // genreName
            // 
            genreName.DataPropertyName = "genreName";
            genreName.Frozen = true;
            genreName.HeaderText = "Genre";
            genreName.MinimumWidth = 40;
            genreName.Name = "genreName";
            genreName.ReadOnly = true;
            genreName.Width = 80;
            // 
            // starEasyDataGridViewTextBoxColumn
            // 
            starEasyDataGridViewTextBoxColumn.DataPropertyName = "strEasy";
            starEasyDataGridViewTextBoxColumn.Frozen = true;
            starEasyDataGridViewTextBoxColumn.HeaderText = "★ Easy";
            starEasyDataGridViewTextBoxColumn.MinimumWidth = 20;
            starEasyDataGridViewTextBoxColumn.Name = "starEasyDataGridViewTextBoxColumn";
            starEasyDataGridViewTextBoxColumn.ReadOnly = true;
            starEasyDataGridViewTextBoxColumn.Width = 50;
            // 
            // starNormalDataGridViewTextBoxColumn
            // 
            starNormalDataGridViewTextBoxColumn.DataPropertyName = "strNormal";
            starNormalDataGridViewTextBoxColumn.Frozen = true;
            starNormalDataGridViewTextBoxColumn.HeaderText = "★ Normal";
            starNormalDataGridViewTextBoxColumn.MinimumWidth = 20;
            starNormalDataGridViewTextBoxColumn.Name = "starNormalDataGridViewTextBoxColumn";
            starNormalDataGridViewTextBoxColumn.ReadOnly = true;
            starNormalDataGridViewTextBoxColumn.Width = 50;
            // 
            // starHardDataGridViewTextBoxColumn
            // 
            starHardDataGridViewTextBoxColumn.DataPropertyName = "strHard";
            starHardDataGridViewTextBoxColumn.Frozen = true;
            starHardDataGridViewTextBoxColumn.HeaderText = "★ Hard";
            starHardDataGridViewTextBoxColumn.MinimumWidth = 20;
            starHardDataGridViewTextBoxColumn.Name = "starHardDataGridViewTextBoxColumn";
            starHardDataGridViewTextBoxColumn.ReadOnly = true;
            starHardDataGridViewTextBoxColumn.Width = 50;
            // 
            // starManiaDataGridViewTextBoxColumn
            // 
            starManiaDataGridViewTextBoxColumn.DataPropertyName = "strMania";
            starManiaDataGridViewTextBoxColumn.Frozen = true;
            starManiaDataGridViewTextBoxColumn.HeaderText = "★ Extreme";
            starManiaDataGridViewTextBoxColumn.MinimumWidth = 20;
            starManiaDataGridViewTextBoxColumn.Name = "starManiaDataGridViewTextBoxColumn";
            starManiaDataGridViewTextBoxColumn.ReadOnly = true;
            starManiaDataGridViewTextBoxColumn.Width = 50;
            // 
            // starUraDataGridViewTextBoxColumn
            // 
            starUraDataGridViewTextBoxColumn.DataPropertyName = "strUra";
            starUraDataGridViewTextBoxColumn.HeaderText = "★ Oni";
            starUraDataGridViewTextBoxColumn.MinimumWidth = 20;
            starUraDataGridViewTextBoxColumn.Name = "starUraDataGridViewTextBoxColumn";
            starUraDataGridViewTextBoxColumn.ReadOnly = true;
            starUraDataGridViewTextBoxColumn.Width = 50;
            // 
            // sourceDataGridViewTextBoxColumn
            // 
            sourceDataGridViewTextBoxColumn.DataPropertyName = "source";
            sourceDataGridViewTextBoxColumn.HeaderText = "source";
            sourceDataGridViewTextBoxColumn.Name = "sourceDataGridViewTextBoxColumn";
            sourceDataGridViewTextBoxColumn.ReadOnly = true;
            sourceDataGridViewTextBoxColumn.Visible = false;
            sourceDataGridViewTextBoxColumn.Width = 100;
            // 
            // songItemBindingSource
            // 
            songItemBindingSource.DataSource = typeof(TaikoVDLCBuilder.SongItem);
            // 
            // RunPBar
            // 
            RunPBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            RunPBar.Location = new System.Drawing.Point(0, 515);
            RunPBar.Margin = new System.Windows.Forms.Padding(2);
            RunPBar.Name = "RunPBar";
            RunPBar.Size = new System.Drawing.Size(751, 17);
            RunPBar.TabIndex = 3;
            // 
            // notifyIcon1
            // 
            notifyIcon1.Text = "notifyIcon1";
            notifyIcon1.Visible = true;
            // 
            // RandomButton
            // 
            RandomButton.Dock = System.Windows.Forms.DockStyle.Left;
            RandomButton.Location = new System.Drawing.Point(0, 0);
            RandomButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            RandomButton.Name = "RandomButton";
            RandomButton.Size = new System.Drawing.Size(117, 46);
            RandomButton.TabIndex = 4;
            RandomButton.Text = "Randomize";
            RandomButton.UseVisualStyleBackColor = true;
            RandomButton.Click += RandomButton_Click;
            // 
            // ClearButton
            // 
            ClearButton.Dock = System.Windows.Forms.DockStyle.Left;
            ClearButton.Location = new System.Drawing.Point(117, 0);
            ClearButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            ClearButton.Name = "ClearButton";
            ClearButton.Size = new System.Drawing.Size(117, 46);
            ClearButton.TabIndex = 5;
            ClearButton.Text = "Clear";
            ClearButton.UseVisualStyleBackColor = true;
            ClearButton.Click += ClearButton_Click;
            // 
            // BottomPanel
            // 
            BottomPanel.Controls.Add(selectedCounterLabel);
            BottomPanel.Controls.Add(includeVitaDlc);
            BottomPanel.Controls.Add(RunButton);
            BottomPanel.Controls.Add(ClearButton);
            BottomPanel.Controls.Add(RandomButton);
            BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            BottomPanel.Location = new System.Drawing.Point(0, 532);
            BottomPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            BottomPanel.Name = "BottomPanel";
            BottomPanel.Size = new System.Drawing.Size(751, 46);
            BottomPanel.TabIndex = 6;
            // 
            // includeVitaDlc
            // 
            includeVitaDlc.Location = new System.Drawing.Point(241, 0);
            includeVitaDlc.Name = "includeVitaDlc";
            includeVitaDlc.Size = new System.Drawing.Size(115, 45);
            includeVitaDlc.TabIndex = 6;
            includeVitaDlc.Text = "Include Vita DLC";
            includeVitaDlc.UseVisualStyleBackColor = true;
            includeVitaDlc.CheckedChanged += includeVitaDlc_CheckedChanged;
            // 
            // IntroLabel
            // 
            IntroLabel.Dock = System.Windows.Forms.DockStyle.Top;
            IntroLabel.Location = new System.Drawing.Point(0, 0);
            IntroLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            IntroLabel.Name = "IntroLabel";
            IntroLabel.Size = new System.Drawing.Size(751, 115);
            IntroLabel.TabIndex = 7;
            IntroLabel.Text = "Label";
            IntroLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TopPanel
            // 
            TopPanel.Controls.Add(IntroLabel);
            TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            TopPanel.Location = new System.Drawing.Point(0, 0);
            TopPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            TopPanel.Name = "TopPanel";
            TopPanel.Size = new System.Drawing.Size(751, 115);
            TopPanel.TabIndex = 8;
            // 
            // selectedCounterLabel
            // 
            selectedCounterLabel.Location = new System.Drawing.Point(468, 0);
            selectedCounterLabel.Name = "selectedCounterLabel";
            selectedCounterLabel.Size = new System.Drawing.Size(162, 44);
            selectedCounterLabel.TabIndex = 7;
            selectedCounterLabel.Text = "Selected: 0 / Slots: 0";
            selectedCounterLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DlcSelector
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(751, 578);
            Controls.Add(DBView);
            Controls.Add(TopPanel);
            Controls.Add(RunPBar);
            Controls.Add(BottomPanel);
            Icon = ((System.Drawing.Icon)resources.GetObject("$this.Icon"));
            Margin = new System.Windows.Forms.Padding(1);
            Text = "Taiko no Tatsujin V Version - DLC Builder";
            Load += DLCSelector_Load;
            ((System.ComponentModel.ISupportInitialize)DBView).EndInit();
            ((System.ComponentModel.ISupportInitialize)songItemBindingSource).EndInit();
            BottomPanel.ResumeLayout(false);
            TopPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        private System.Windows.Forms.Label selectedCounterLabel;

        private System.Windows.Forms.CheckBox includeVitaDlc;

        #endregion
        private System.Windows.Forms.Button RunButton;
        private System.Windows.Forms.DataGridView DBView;
        private System.Windows.Forms.BindingSource songItemBindingSource;
        private System.Windows.Forms.ProgressBar RunPBar;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isCheckedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameJPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn folderDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn genreName;
        private System.Windows.Forms.DataGridViewTextBoxColumn starEasyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn starNormalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn starHardDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn starManiaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn starUraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sourceDataGridViewTextBoxColumn;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button RandomButton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Panel BottomPanel;
        private System.Windows.Forms.Label IntroLabel;
        private System.Windows.Forms.Panel TopPanel;
    }
}

