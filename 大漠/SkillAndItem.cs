using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 大漠
{
    public partial class SkillAndItem : UserControl
    {
        public SkillAndItem()
        {
            InitializeComponent();
            for (int i = 1; i < 13; i++)
            {
                keyInput.Items.Add("F"+i);
            }
            keyInput.SelectedIndex = 0;
            
            
        }
    }
}
