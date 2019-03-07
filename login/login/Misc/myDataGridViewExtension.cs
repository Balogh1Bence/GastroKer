using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace login.Misc
{
    public static class myDataGridViewExtension
    {
        public static void NoSelectedRow(this DataGridView dg)
        {
            dg.CurrentCell = null;
            dg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dg.ClearSelection();
            
        }
    }
}
