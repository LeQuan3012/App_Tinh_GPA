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
    public partial class monhoc : UserControl
    {
        public monhoc()
        {
            InitializeComponent();
        }

        public string getTenMon()
        {
            return txtmonhoc.Text;
        }

        public void setTenMon(string tenmon)
        {
            txtmonhoc.Text = tenmon;
        }

        public int getSoTC()
        {
            return int.Parse(numSoTC.Text);
        }

        public void getSoTC(int soTC)
        {
            numSoTC.Value = soTC;
        }
        float diemquydoi = 0;
        public float getDiemQuyDoi()
        {
            
                diemquydoi = float.Parse(lbdiemquydoi.Text);

            
            return diemquydoi;
        }

        public void setSTT(int number)
        {
            lbSTTcot.Text = number.ToString();
        }
        public event EventHandler OnDeleteButtonClick;

        private void btnxoa_Click(object sender, EventArgs e)
        {
            OnDeleteButtonClick?.Invoke(this, EventArgs.Empty);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                lbdiemquydoi.Text = "4.0";
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                lbdiemquydoi.Text = "3.5";
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                lbdiemquydoi.Text = "3.0";
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                lbdiemquydoi.Text = "2.5";
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                lbdiemquydoi.Text = "2.0";
            }
            else if (comboBox1.SelectedIndex == 5)
            {
                lbdiemquydoi.Text = "1.5";
            }
            else if (comboBox1.SelectedIndex == 6)
            {
                lbdiemquydoi.Text = "1.0";
            }
            else
            {
                lbdiemquydoi.Text = "0";
            }
        }
    }
}
