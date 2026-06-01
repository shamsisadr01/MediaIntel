using MediaIntel.App.Extensions;
using MediaIntel.MediaPipeline.AIModule.Models;
using MediaIntel.MediaPipeline.Application.Models;
using MediaIntel.MediaPipeline.Application.Services;
using MediaIntel.MediaPipeline.Application.Settings;
using MediaIntel.MediaPipeline.ScannerModule.Extensions;
using MediaIntel.MediaPipeline.ScannerModule.Models;

namespace MediaIntel
{
    public partial class MediaIntel : Form, IMessageFilter
    {
        private AppSettings appSettings;
        private AppService appService;
        private bool isRunning;

        public MediaIntel()
        {
            InitializeComponent();

            appSettings = new AppSettings();

            appSettings.TaskProgress = new Progress<double>(percent =>
            {
                ProgressBar.Value = (int)percent;
                ProgressLable.Text = $"{(int)percent}%";
            });

            ServiceFactory serviceFactory = new ServiceFactory(appSettings);
            appService = new AppService(serviceFactory);

            LoadRootIntoTreeView();
            Application.AddMessageFilter(this);
        }

        private void Add_Click(object sender, EventArgs e)
        {
            using (var jobSettings = new JobSettings())
            {
                var aiModelOptions = appSettings.Container.Get<AiModelOptions>();
                jobSettings.JobSettingsBatch = new JobSettingsBatch(aiModelOptions);
                jobSettings.Initialize();

                if (jobSettings.ShowDialog() == DialogResult.OK)
                {
                    ClearQueue_Click(sender, e);
                    appService.CreateJob(jobSettings.JobSettingsBatch.FolderPath, jobSettings.JobSettingsBatch.BatchActions);
                    LoadRootIntoTreeView();
                    appSettings.Container.Save(aiModelOptions);
                }
            }
        }

        private void ClearQueue_Click(object sender, EventArgs e)
        {
            appSettings.Container.Delete<BatchJob>();
            LoadRootIntoTreeView();
            RefreshFileListView();
            folderSelected.Text = "";
        }

        private async void RunProccess_Click(object sender, EventArgs e)
        {
            try
            {
                if (isRunning == false)
                {
                    ProgressLable.Text = "0%";
                    isRunning = true;
                    SetRunningUI(isRunning);
                    while (isRunning)
                    {
                        isRunning = await appService.RunProcessAsync(item =>
                        {
                            DataGridViewBindingExtensions.SelectRowByItem(DataView, item);
                        });
                        LoadRootIntoTreeView();
                    }
                    RunProccess.Enabled = false;
                }
                else
                {
                    appService.CancelProccess();
                }
            }
            catch (Exception ex)
            {
                appService.CancelProccess();
                MessageBox.Show(this, ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                isRunning = false;
                SetRunningUI(false);
                ResetProgressUI();
            }
        }

        private void SetRunningUI(bool isRunning)
        {
            ClearQueue.Enabled = !isRunning;
            Add.Enabled = !isRunning;

            RunProccess.Text = isRunning ? "Stop Process" : "Run Process";
        }

        private void ResetProgressUI()
        {
            ProgressBar.Value = 0;
            ProgressLable.Text = "";
        }

        private void RefreshFileListView(FolderItem? folderItem = null)
        {
            var files = folderItem?.Files;
            if (files is null && folderItem is not null)
            {
                var emptyList = new List<object>
                {
                    new { Message = "No File available in this directory."}
                };
                DataView.BindWithAttributes(emptyList);
            }
            else
            {
                DataView.BindWithAttributes(files);
                if (files != null)
                {
                    foreach (var item in files)
                    {
                        if (item.Status == ProcessStatus.Processing)
                        {
                            DataGridViewBindingExtensions.SelectRowByItem(DataView, item);
                            break;
                        }
                    }
                }
            }
        }


        #region GridViewData

        private void showFiles_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel1Collapsed = !splitContainer1.Panel1Collapsed;
            if (splitContainer1.Panel1Collapsed)
            {
                folderSelected.Text = appSettings.Container.Get<BatchJob>().TargetFolderPath;
                var data = appService.LoadDataForView()?.EnumerateFile().ToList();
                if (data == null) return;
                DataView.BindWithAttributes(data);
                foreach (var item in data)
                {
                    if (item.Status == ProcessStatus.Processing)
                    {
                        DataGridViewBindingExtensions.SelectRowByItem(DataView, item);
                        break;
                    }
                }
            }
            else
            {
                var data = treeView1.SelectedNode?.Tag as FolderItem;
                if (data == null) return;
                folderSelected.Text = data.DirectoryPath;
                RefreshFileListView(data);
                treeView1.Select();
            }
            if (isRunning == false)
            {
                UnselectGridViewData();
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            BeginInvoke(new MethodInvoker(UnselectGridViewData));
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            Application.RemoveMessageFilter(this);
            base.OnFormClosed(e);
        }

        public bool PreFilterMessage(ref Message m)
        {
            if ((m.Msg == 0x0201 || m.Msg == 0x00A1) && !isRunning)
            {
                Control clickedControl = FromHandle(m.HWnd);
                if (clickedControl != null && !IsChildOf(DataView, clickedControl))
                {
                    UnselectGridViewData();
                }
            }
            return false;
        }

        private bool IsChildOf(Control parent, Control child)
        {
            while (child != null)
            {
                if (child == parent) return true;
                child = child.Parent;
            }
            return false;
        }

        private void UnselectGridViewData()
        {
            DataView.ClearSelection();
            DataView.CurrentCell = null;
        }

        #endregion


        #region TreeView

        private void LoadRootIntoTreeView()
        {
            splitContainer1.Panel1Collapsed = false;
            folderSelected.Text = appSettings.Container.Get<BatchJob>().TargetFolderPath;
            var data = appService.LoadDataForView();
            RunProccess.Enabled = data?.EnumerateFile(ProcessStatus.NotProcessed).Any() == true;
            RefreshFileListView(data);

            treeView1.BeginUpdate();
            treeView1.Nodes.Clear();

            if (data is null)
            {
                treeView1.EndUpdate();
                return;
            }
            bool isSelected = false;
            var rootNode = TreeViewNodeBuilder.CreateTreeNodeFromFolder(data, node =>
            {
                treeView1.SelectedNode = node;
                treeView1.Select();
                isSelected = true;
            });
            if (isSelected == false)
            {
                treeView1.SelectedNode = rootNode;
                treeView1.Select();
            }
            treeView1.Nodes.Add(rootNode);

            treeView1.EndUpdate();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var cur = e.Node.Tag as FolderItem;
            if (cur == null) return;

            cur.IsSelected = true;

            RefreshFileListView(cur);
            folderSelected.Text = cur.DirectoryPath;
            appService.UpdateBatchJob();
        }

        private void ManageExpandCollapse(object sender, TreeViewEventArgs e)
        {
            var folderItem = e.Node.Tag as FolderItem;
            if (folderItem == null) return;

            folderItem.IsExpand = e.Node.IsExpanded;
            appService.UpdateBatchJob();
        }

        private void treeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            var prev = treeView1.SelectedNode?.Tag as FolderItem;
            if (prev == null) return;
            prev.IsSelected = false;
            appService.UpdateBatchJob();
        }

        #endregion


        private void MediaIntel_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(isRunning)
            {
                appService.CancelProccess();
            }
        }
    }



}
