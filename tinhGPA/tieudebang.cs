using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tinhGPA
{
    public partial class tieudebang : UserControl
    {
        public tieudebang()
        {
            InitializeComponent();
        }

        public event EventHandler AddnewMonHoc;
        private void button1_Click(object sender, EventArgs e)
        {
            AddnewMonHoc?.Invoke(this, EventArgs.Empty);
        }
        public void setVisiblebutton(Boolean value)
        {
            button1.Visible = value;
        }
    }
}
