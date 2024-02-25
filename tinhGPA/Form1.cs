namespace tinhGPA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            tieudebang1.AddnewMonHoc += monhoc_addnewClick;
        }

        int slmon = 0;

        private void btnSL_Click(object sender, EventArgs e)
        {
            slmon = 0;
            flowLayoutPanel1.Controls.Clear();
            tieudebang1.setVisiblebutton(true);
            slmon = int.Parse(numSL.Value.ToString());

            if (slmon == 0)
            {
                MessageBox.Show("Vui lòng nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                numSL.Focus();
            }
            else if (slmon > 1000)
            {
                MessageBox.Show("Số lượng môn học không được quá 1000", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numSL.Focus();
            }
            else if (slmon <= 1000)
            {
                btntinhdiem.Visible = true;
                btnxoa.Visible = true;
                flowLayoutPanel1.Controls.Clear();
                for (int i = 0; i < slmon; i++)
                {
                    monhoc monhoc1 = new monhoc();
                    monhoc1.setSTT(i + 1);
                    flowLayoutPanel1.Controls.Add(monhoc1);
                    monhoc1.OnDeleteButtonClick += monhoc_onDeleteButtonClick;
                }

            }
        }

        private void monhoc_addnewClick(object sender, EventArgs e)
        {
            monhoc a = new monhoc();
            a.setSTT(slmon + 1);
            slmon += 1;
            flowLayoutPanel1.Controls.Add(a);
            a.OnDeleteButtonClick += monhoc_onDeleteButtonClick;
            lbGPA.Text = "GPA:";
            lbXepLoai.Text = "Xếp loại";
        }

        private void updateSTT()
        {
            int dem = 1;
            foreach (monhoc mon in flowLayoutPanel1.Controls)
            {
                mon.setSTT(dem);
                dem++;
            }
        }

        private void monhoc_onDeleteButtonClick(object sender, EventArgs e)
        {
            if (sender is monhoc deletedItem)
            {
                flowLayoutPanel1.Controls.Remove(deletedItem);
                deletedItem.Dispose();
                updateSTT();
                slmon--;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                lbGPA.Text = "";
                lbXepLoai.Text = "";
                int tongsotinchi = 0;
                float tongdiem = 0;
                float tongtu = 0;
                foreach (monhoc mon in flowLayoutPanel1.Controls)
                {
                    tongsotinchi += mon.getSoTC();
                    tongdiem += mon.getDiemQuyDoi();
                    tongtu += (mon.getDiemQuyDoi() * mon.getSoTC());
                }
                float gpa = (tongtu / tongsotinchi);
                lbGPA.Text = "GPA: " + (gpa).ToString("N2");
                if (gpa >= 3.6)
                {
                    lbXepLoai.Text = "Xếp loại xuất sắc";
                }
                else if (gpa >= 3.2)
                {
                    lbXepLoai.Text = "Xếp loại giỏi";
                }
                else if (gpa >= 2.5)
                {
                    lbXepLoai.Text = "Xếp loại khá";
                }
                else if (gpa >= 2.0)
                {
                    lbXepLoai.Text = "Xếp loại trung bình";
                }
                else
                {
                    lbXepLoai.Text = "Xếp loại yếu";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin để tính điểm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            slmon = 0;
            flowLayoutPanel1.Controls.Clear();
            lbGPA.Text = "GPA: ";
            lbXepLoai.Text = "Xếp loại";
            btnxoa.Visible = false;
            btntinhdiem.Visible = false;
            tieudebang1.setVisiblebutton(false);
            numSL.Value = 0;

        }
    }
}