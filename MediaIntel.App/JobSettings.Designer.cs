namespace MediaIntel
{
    partial class JobSettings
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
            SelectFolder = new Button();
            Job = new GroupBox();
            showPath = new Label();
            burnSubtitleCheckBox = new CheckBox();
            translateSubtitleChecked = new CheckBox();
            CreateJob = new Button();
            AISettings = new GroupBox();
            Model = new Label();
            Language = new Label();
            BaseUrl = new Label();
            ApiKey = new Label();
            ModelComboBox = new ComboBox();
            languageComboBox = new ComboBox();
            apiKeyTextBox = new TextBox();
            BaseUrlModel = new TextBox();
            panel1 = new Panel();
            Job.SuspendLayout();
            AISettings.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // SelectFolder
            // 
            SelectFolder.Location = new Point(23, 22);
            SelectFolder.Name = "SelectFolder";
            SelectFolder.Size = new Size(75, 31);
            SelectFolder.TabIndex = 0;
            SelectFolder.Text = "Select Path";
            SelectFolder.UseVisualStyleBackColor = true;
            SelectFolder.Click += SelectFolder_Click;
            // 
            // Job
            // 
            Job.Controls.Add(showPath);
            Job.Controls.Add(burnSubtitleCheckBox);
            Job.Controls.Add(translateSubtitleChecked);
            Job.Controls.Add(SelectFolder);
            Job.Dock = DockStyle.Fill;
            Job.Location = new Point(0, 140);
            Job.Name = "Job";
            Job.RightToLeft = RightToLeft.Yes;
            Job.Size = new Size(359, 93);
            Job.TabIndex = 2;
            Job.TabStop = false;
            Job.Text = "Actions";
            // 
            // showPath
            // 
            showPath.BackColor = Color.Silver;
            showPath.Dock = DockStyle.Bottom;
            showPath.Enabled = false;
            showPath.Location = new Point(3, 75);
            showPath.Name = "showPath";
            showPath.RightToLeft = RightToLeft.No;
            showPath.Size = new Size(353, 15);
            showPath.TabIndex = 3;
            showPath.Text = "No Folder Selected";
            showPath.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // burnSubtitleCheckBox
            // 
            burnSubtitleCheckBox.AutoSize = true;
            burnSubtitleCheckBox.Location = new Point(249, 47);
            burnSubtitleCheckBox.Name = "burnSubtitleCheckBox";
            burnSubtitleCheckBox.Size = new Size(94, 19);
            burnSubtitleCheckBox.TabIndex = 2;
            burnSubtitleCheckBox.Text = "Burn Subtitle";
            burnSubtitleCheckBox.UseVisualStyleBackColor = true;
            // 
            // translateSubtitleChecked
            // 
            translateSubtitleChecked.AutoSize = true;
            translateSubtitleChecked.Location = new Point(227, 22);
            translateSubtitleChecked.Name = "translateSubtitleChecked";
            translateSubtitleChecked.Size = new Size(116, 19);
            translateSubtitleChecked.TabIndex = 1;
            translateSubtitleChecked.Text = "Translate Subtitle";
            translateSubtitleChecked.UseVisualStyleBackColor = true;
            // 
            // CreateJob
            // 
            CreateJob.Location = new Point(108, 13);
            CreateJob.Name = "CreateJob";
            CreateJob.Size = new Size(132, 31);
            CreateJob.TabIndex = 3;
            CreateJob.Text = "Create Job Save";
            CreateJob.UseVisualStyleBackColor = true;
            CreateJob.Click += CreateJob_Click;
            // 
            // AISettings
            // 
            AISettings.Controls.Add(Model);
            AISettings.Controls.Add(Language);
            AISettings.Controls.Add(BaseUrl);
            AISettings.Controls.Add(ApiKey);
            AISettings.Controls.Add(ModelComboBox);
            AISettings.Controls.Add(languageComboBox);
            AISettings.Controls.Add(apiKeyTextBox);
            AISettings.Controls.Add(BaseUrlModel);
            AISettings.Dock = DockStyle.Top;
            AISettings.Location = new Point(0, 0);
            AISettings.Name = "AISettings";
            AISettings.RightToLeft = RightToLeft.Yes;
            AISettings.Size = new Size(359, 140);
            AISettings.TabIndex = 4;
            AISettings.TabStop = false;
            AISettings.Text = "Gapgpt AI";
            // 
            // Model
            // 
            Model.AutoSize = true;
            Model.Location = new Point(12, 112);
            Model.Name = "Model";
            Model.Size = new Size(41, 15);
            Model.TabIndex = 11;
            Model.Text = "Model";
            // 
            // Language
            // 
            Language.AutoSize = true;
            Language.Location = new Point(12, 83);
            Language.Name = "Language";
            Language.Size = new Size(59, 15);
            Language.TabIndex = 10;
            Language.Text = "Language";
            // 
            // BaseUrl
            // 
            BaseUrl.AutoSize = true;
            BaseUrl.Location = new Point(12, 30);
            BaseUrl.Name = "BaseUrl";
            BaseUrl.Size = new Size(49, 15);
            BaseUrl.TabIndex = 8;
            BaseUrl.Text = "Base Url";
            // 
            // ApiKey
            // 
            ApiKey.AutoSize = true;
            ApiKey.Location = new Point(12, 54);
            ApiKey.Name = "ApiKey";
            ApiKey.Size = new Size(47, 15);
            ApiKey.TabIndex = 9;
            ApiKey.Text = "Api Key";
            // 
            // ModelComboBox
            // 
            ModelComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            ModelComboBox.FormattingEnabled = true;
            ModelComboBox.Location = new Point(132, 109);
            ModelComboBox.Name = "ModelComboBox";
            ModelComboBox.RightToLeft = RightToLeft.No;
            ModelComboBox.Size = new Size(226, 23);
            ModelComboBox.TabIndex = 7;
            // 
            // languageComboBox
            // 
            languageComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            languageComboBox.FormattingEnabled = true;
            languageComboBox.Location = new Point(132, 80);
            languageComboBox.Name = "languageComboBox";
            languageComboBox.RightToLeft = RightToLeft.No;
            languageComboBox.Size = new Size(226, 23);
            languageComboBox.TabIndex = 6;
            // 
            // apiKeyTextBox
            // 
            apiKeyTextBox.Location = new Point(132, 51);
            apiKeyTextBox.Name = "apiKeyTextBox";
            apiKeyTextBox.RightToLeft = RightToLeft.No;
            apiKeyTextBox.Size = new Size(226, 23);
            apiKeyTextBox.TabIndex = 5;
            // 
            // BaseUrlModel
            // 
            BaseUrlModel.Location = new Point(132, 22);
            BaseUrlModel.Name = "BaseUrlModel";
            BaseUrlModel.RightToLeft = RightToLeft.No;
            BaseUrlModel.Size = new Size(226, 23);
            BaseUrlModel.TabIndex = 4;
            // 
            // panel1
            // 
            panel1.Controls.Add(CreateJob);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 233);
            panel1.Name = "panel1";
            panel1.Size = new Size(359, 56);
            panel1.TabIndex = 4;
            // 
            // JobSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGray;
            ClientSize = new Size(359, 289);
            Controls.Add(Job);
            Controls.Add(AISettings);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "JobSettings";
            RightToLeft = RightToLeft.No;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Job Settings";
            Job.ResumeLayout(false);
            Job.PerformLayout();
            AISettings.ResumeLayout(false);
            AISettings.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button SelectFolder;
        private GroupBox Job;
        private CheckBox burnSubtitleCheckBox;
        private CheckBox translateSubtitleChecked;
        private GroupBox AISettings;
        private ComboBox ModelComboBox;
        private ComboBox languageComboBox;
        private TextBox apiKeyTextBox;
        private TextBox BaseUrlModel;
        private Label BaseUrl;
        private Label ApiKey;
        private Label Language;
        private Label Model;
        private Button CreateJob;
        private Panel panel1;
        private Label showPath;
    }
}