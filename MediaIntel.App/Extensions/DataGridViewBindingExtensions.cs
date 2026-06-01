using MediaIntel.MediaPipeline.ScannerModule.Models;
using System.ComponentModel;
using System.Data;
using System.Reflection;

namespace MediaIntel.App.Extensions
{
    public static class DataGridViewBindingExtensions
    {
        public static void BindWithAttributes<T>(this DataGridView dgv, List<T>? data)
        {
            if (data == null)
            {
                dgv.DataSource = null;
                return;
            }

            dgv.DataSource = new BindingList<T>(data);
            ApplyHideColumnIfAllNull(dgv, data);
        }

        private static void ApplyHideColumnIfAllNull<T>(DataGridView dgv, List<T> data)
        {
            var props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var prop in props)
            {
                if (!prop.IsDefined(typeof(HideColumnIfAllNullAttribute), true))
                    continue;

                bool allNullOrEmpty = data.Count == 0 || data.All(item =>
                {
                    var value = prop.GetValue(item);

                    if (value == null)
                        return true;

                    if (value is string s)
                        return string.IsNullOrWhiteSpace(s);

                    return false;
                });

                var column = dgv.Columns
                    .Cast<DataGridViewColumn>()
                    .FirstOrDefault(c => c.DataPropertyName == prop.Name || c.Name == prop.Name);

                if (column != null)
                    column.Visible = !allNullOrEmpty;
            }
        }

        public static void SelectRowByItem(DataGridView grid, VideoSubtitle item)
        {
            if (grid.IsDisposed) return;

            if (grid.InvokeRequired)
            {
                grid.BeginInvoke(new Action(() => SelectRowByItem(grid, item)));
                return;
            }

            if (grid.RowCount == 0) return;

            foreach (DataGridViewRow r in grid.Rows)
            {
                if (!ReferenceEquals(r.DataBoundItem, item)) continue;

                grid.ClearSelection();
                r.Selected = true;

                DataGridViewCell? visibleCell =
                    r.Cells.Cast<DataGridViewCell>()
                     .FirstOrDefault(c => c.Visible && c.OwningColumn.Visible);

                if (visibleCell != null)
                    grid.CurrentCell = visibleCell;

                if (r.Index >= 0)
                    grid.FirstDisplayedScrollingRowIndex = r.Index;

                break;
            }
        }


    }
}
