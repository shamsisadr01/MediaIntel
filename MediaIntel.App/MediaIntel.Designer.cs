namespace MediaIntel
{
    partial class MediaIntel
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            Footer = new Panel();
            showFiles = new Button();
            ProgressLable = new Label();
            ProgressBar = new ProgressBar();
            ClearQueue = new Button();
            RunProccess = new Button();
            Add = new Button();
            DataView = new DataGridView();
            FileName = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            Description = new DataGridViewTextBoxColumn();
            splitContainer1 = new SplitContainer();
            groupBox1 = new GroupBox();
            treeView1 = new TreeView();
            groupBoxDataGrid = new GroupBox();
            HeaderPanel = new Panel();
            folderSelected = new TextBox();
            Footer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DataView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBoxDataGrid.SuspendLayout();
            HeaderPanel.SuspendLayout();
            SuspendLayout();
            // 
            // Footer
            // 
            Footer.BackColor = Color.LightGray;
            Footer.Controls.Add(showFiles);
            Footer.Controls.Add(ProgressLable);
            Footer.Controls.Add(ProgressBar);
            Footer.Controls.Add(ClearQueue);
            Footer.Controls.Add(RunProccess);
            Footer.Controls.Add(Add);
            Footer.Dock = DockStyle.Bottom;
            Footer.Location = new Point(0, 355);
            Footer.Name = "Footer";
            Footer.Size = new Size(800, 95);
            Footer.TabIndex = 0;
            // 
            // showFiles
            // 
            showFiles.BackColor = Color.LightGray;
            showFiles.FlatAppearance.BorderColor = SystemColors.ControlDark;
            showFiles.FlatStyle = FlatStyle.Flat;
            showFiles.Location = new Point(12, 43);
            showFiles.Name = "showFiles";
            showFiles.Size = new Size(84, 35);
            showFiles.TabIndex = 5;
            showFiles.Text = "Show All";
            showFiles.UseVisualStyleBackColor = false;
            showFiles.Click += showFiles_Click;
            // 
            // ProgressLable
            // 
            ProgressLable.Anchor = AnchorStyles.None;
            ProgressLable.AutoSize = true;
            ProgressLable.BackColor = Color.Transparent;
            ProgressLable.Location = new Point(400, 6);
            ProgressLable.Name = "ProgressLable";
            ProgressLable.Size = new Size(0, 15);
            ProgressLable.TabIndex = 4;
            // 
            // ProgressBar
            // 
            ProgressBar.BackColor = SystemColors.ControlLight;
            ProgressBar.Dock = DockStyle.Top;
            ProgressBar.ForeColor = SystemColors.GrayText;
            ProgressBar.Location = new Point(0, 0);
            ProgressBar.Name = "ProgressBar";
            ProgressBar.Size = new Size(800, 27);
            ProgressBar.Step = 0;
            ProgressBar.TabIndex = 3;
            // 
            // ClearQueue
            // 
            ClearQueue.Anchor = AnchorStyles.None;
            ClearQueue.BackColor = Color.LightGray;
            ClearQueue.FlatAppearance.BorderColor = SystemColors.ControlDark;
            ClearQueue.FlatStyle = FlatStyle.Flat;
            ClearQueue.Location = new Point(539, 38);
            ClearQueue.Name = "ClearQueue";
            ClearQueue.Size = new Size(100, 45);
            ClearQueue.TabIndex = 2;
            ClearQueue.Text = "Clear Queue";
            ClearQueue.UseVisualStyleBackColor = false;
            ClearQueue.Click += ClearQueue_Click;
            // 
            // RunProccess
            // 
            RunProccess.Anchor = AnchorStyles.None;
            RunProccess.BackColor = Color.LightGray;
            RunProccess.FlatAppearance.BorderColor = SystemColors.ControlDark;
            RunProccess.FlatStyle = FlatStyle.Flat;
            RunProccess.Location = new Point(283, 38);
            RunProccess.Name = "RunProccess";
            RunProccess.Size = new Size(250, 45);
            RunProccess.TabIndex = 1;
            RunProccess.Text = "Run Proccess";
            RunProccess.UseVisualStyleBackColor = false;
            RunProccess.Click += RunProccess_Click;
            // 
            // Add
            // 
            Add.Anchor = AnchorStyles.None;
            Add.BackColor = Color.LightGray;
            Add.FlatAppearance.BorderColor = SystemColors.ControlDark;
            Add.FlatStyle = FlatStyle.Flat;
            Add.Location = new Point(177, 38);
            Add.Name = "Add";
            Add.Size = new Size(100, 45);
            Add.TabIndex = 0;
            Add.Text = "Add";
            Add.UseVisualStyleBackColor = false;
            Add.Click += Add_Click;
            // 
            // DataView
            // 
            DataView.AllowUserToAddRows = false;
            DataView.AllowUserToDeleteRows = false;
            DataView.AllowUserToOrderColumns = true;
            DataView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.ControlLight;
            dataGridViewCellStyle1.Padding = new Padding(10, 0, 0, 0);
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            DataView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            DataView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DataView.BackgroundColor = SystemColors.ControlLight;
            DataView.BorderStyle = BorderStyle.None;
            DataView.CellBorderStyle = DataGridViewCellBorderStyle.None;
            DataView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.ControlLight;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new Padding(10, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.ControlLight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            DataView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            DataView.ColumnHeadersHeight = 25;
            DataView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            DataView.Columns.AddRange(new DataGridViewColumn[] { FileName, Status, Description });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.Gainsboro;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.Padding = new Padding(10, 0, 0, 0);
            dataGridViewCellStyle3.SelectionBackColor = Color.Silver;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            DataView.DefaultCellStyle = dataGridViewCellStyle3;
            DataView.Dock = DockStyle.Fill;
            DataView.EnableHeadersVisualStyles = false;
            DataView.GridColor = Color.Silver;
            DataView.Location = new Point(3, 19);
            DataView.MultiSelect = false;
            DataView.Name = "DataView";
            DataView.ReadOnly = true;
            DataView.RightToLeft = RightToLeft.No;
            DataView.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.Padding = new Padding(10, 0, 0, 0);
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            DataView.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            DataView.RowHeadersVisible = false;
            DataView.RowHeadersWidth = 51;
            DataView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataView.Size = new Size(639, 309);
            DataView.TabIndex = 1;
            // 
            // FileName
            // 
            FileName.HeaderText = "File Name";
            FileName.MinimumWidth = 6;
            FileName.Name = "FileName";
            FileName.ReadOnly = true;
            FileName.Visible = false;
            // 
            // Status
            // 
            Status.HeaderText = "Status";
            Status.MinimumWidth = 6;
            Status.Name = "Status";
            Status.ReadOnly = true;
            Status.Visible = false;
            // 
            // Description
            // 
            Description.HeaderText = "Description";
            Description.MinimumWidth = 6;
            Description.Name = "Description";
            Description.ReadOnly = true;
            Description.Visible = false;
            // 
            // splitContainer1
            // 
            splitContainer1.BackColor = Color.Silver;
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 24);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(groupBox1);
            splitContainer1.Panel1.RightToLeft = RightToLeft.Yes;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(groupBoxDataGrid);
            splitContainer1.Panel2.RightToLeft = RightToLeft.Yes;
            splitContainer1.RightToLeft = RightToLeft.Yes;
            splitContainer1.Size = new Size(800, 331);
            splitContainer1.SplitterDistance = 154;
            splitContainer1.SplitterWidth = 1;
            splitContainer1.TabIndex = 2;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(treeView1);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.RightToLeft = RightToLeft.No;
            groupBox1.Size = new Size(154, 331);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Show Folders";
            // 
            // treeView1
            // 
            treeView1.BackColor = Color.Gainsboro;
            treeView1.BorderStyle = BorderStyle.None;
            treeView1.Dock = DockStyle.Fill;
            treeView1.Location = new Point(3, 19);
            treeView1.Name = "treeView1";
            treeView1.RightToLeft = RightToLeft.Yes;
            treeView1.RightToLeftLayout = true;
            treeView1.Size = new Size(148, 309);
            treeView1.TabIndex = 0;
            treeView1.AfterCollapse += ManageExpandCollapse;
            treeView1.AfterExpand += ManageExpandCollapse;
            treeView1.BeforeSelect += treeView1_BeforeSelect;
            treeView1.AfterSelect += treeView1_AfterSelect;
            // 
            // groupBoxDataGrid
            // 
            groupBoxDataGrid.Controls.Add(DataView);
            groupBoxDataGrid.Dock = DockStyle.Fill;
            groupBoxDataGrid.Location = new Point(0, 0);
            groupBoxDataGrid.Name = "groupBoxDataGrid";
            groupBoxDataGrid.RightToLeft = RightToLeft.No;
            groupBoxDataGrid.Size = new Size(645, 331);
            groupBoxDataGrid.TabIndex = 5;
            groupBoxDataGrid.TabStop = false;
            groupBoxDataGrid.Text = "Show Files";
            // 
            // HeaderPanel
            // 
            HeaderPanel.BackColor = Color.LightGray;
            HeaderPanel.Controls.Add(folderSelected);
            HeaderPanel.Dock = DockStyle.Top;
            HeaderPanel.Location = new Point(0, 0);
            HeaderPanel.Name = "HeaderPanel";
            HeaderPanel.Padding = new Padding(1, 2, 2, 2);
            HeaderPanel.Size = new Size(800, 24);
            HeaderPanel.TabIndex = 2;
            // 
            // folderSelected
            // 
            folderSelected.BackColor = Color.Gainsboro;
            folderSelected.BorderStyle = BorderStyle.None;
            folderSelected.Dock = DockStyle.Fill;
            folderSelected.Enabled = false;
            folderSelected.Font = new Font("Segoe UI", 12F);
            folderSelected.Location = new Point(1, 2);
            folderSelected.Name = "folderSelected";
            folderSelected.ReadOnly = true;
            folderSelected.Size = new Size(797, 22);
            folderSelected.TabIndex = 1;
            folderSelected.WordWrap = false;
            // 
            // MediaIntel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer1);
            Controls.Add(HeaderPanel);
            Controls.Add(Footer);
            Name = "MediaIntel";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MediaIntel";
            FormClosed += MediaIntel_FormClosed;
            Footer.ResumeLayout(false);
            Footer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DataView).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBoxDataGrid.ResumeLayout(false);
            HeaderPanel.ResumeLayout(false);
            HeaderPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel Footer;
        private Button RunProccess;
        private Button Add;
        private Button ClearQueue;
        private ProgressBar ProgressBar;
        private Label ProgressLable;
        private DataGridView DataView;
        private SplitContainer splitContainer1;
        private TreeView treeView1;
        private Panel HeaderPanel;
        private TextBox folderSelected;
        private DataGridViewTextBoxColumn FileName;
        private DataGridViewTextBoxColumn Status;
        private DataGridViewTextBoxColumn Description;
        private GroupBox groupBoxDataGrid;
        private GroupBox groupBox1;
        private Button showFiles;
    }
}
