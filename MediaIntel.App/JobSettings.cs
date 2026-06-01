using MediaIntel.MediaPipeline.AIModule.Enums;
using MediaIntel.MediaPipeline.AIModule.Models;
using MediaIntel.MediaPipeline.Application.Models;
using System.ComponentModel;

namespace MediaIntel
{
    public partial class JobSettings : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public JobSettingsBatch JobSettingsBatch { get; set; } = new JobSettingsBatch(new AiModelOptions());
        public JobSettings()
        {
            InitializeComponent();

            ModelComboBox.DataSource = Enum.GetValues(typeof(AiModel));
            languageComboBox.DataSource = Enum.GetValues(typeof(Language));
        }

        public void Initialize()
        {
            languageComboBox.SelectedIndex = (int)JobSettingsBatch.AiModelOptions.Language;
            ModelComboBox.SelectedIndex = (int)JobSettingsBatch.AiModelOptions.Model;
            BaseUrlModel.Text = JobSettingsBatch.AiModelOptions.BaseUrl;
            apiKeyTextBox.Text = JobSettingsBatch.AiModelOptions.ApiKey;
        }

        private void CreateJob_Click(object sender, EventArgs e)
        {
            JobSettingsBatch.AiModelOptions.Language = (Language)languageComboBox.SelectedIndex;
            JobSettingsBatch.AiModelOptions.Model = (AiModel)ModelComboBox.SelectedIndex;
            JobSettingsBatch.AiModelOptions.BaseUrl = BaseUrlModel.Text;
            JobSettingsBatch.AiModelOptions.ApiKey = apiKeyTextBox.Text;


            if (translateSubtitleChecked.Checked)
            {
                JobSettingsBatch.BatchActions.Add(BatchAction.TranslateSubtitle);
            }

            if (burnSubtitleCheckBox.Checked)
            {
                JobSettingsBatch.BatchActions.Add(BatchAction.BurnSubtitle);
            }

            if (string.IsNullOrWhiteSpace(JobSettingsBatch.FolderPath) || JobSettingsBatch.BatchActions.Count == 0)
            {
                MessageBox.Show(this,
                 "Please select a folder path and at least one action.",
                 "Error",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Warning);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void SelectFolder_Click(object sender, EventArgs e)
        {
            using var dlg = new FolderBrowserDialog
            {
                Description = "Select Folder",
                UseDescriptionForTitle = true, // .NET 6+
                SelectedPath = JobSettingsBatch.FolderPath
            };

            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                JobSettingsBatch.FolderPath = dlg.SelectedPath;
                showPath.Text = dlg.SelectedPath;
            }
        }
    }

    public class JobSettingsBatch
    {
        public JobSettingsBatch(AiModelOptions aiModelOptions)
        {
            AiModelOptions = aiModelOptions;
        }

        public string FolderPath { get; set; } = string.Empty;

        public List<BatchAction> BatchActions { get; set; } = new();

        public AiModelOptions AiModelOptions { get; set; } = new();
    }
}
