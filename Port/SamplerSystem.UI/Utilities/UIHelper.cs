using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SamplerSystem.UI.Utilities
{
    public class UIHelper
    {
        public static void EnableDoubleBufferedDataGridView(DataGridView dgv)
        {
            // 启用双缓冲
            // 因为 DoubleBuffered 属性是 protected 的，所以得靠下面这种 trick 来实现
            typeof(DataGridView).InvokeMember(
                "DoubleBuffered",
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
                null,
                dgv,
                new object[] { true }
            );
        }

    }
}
