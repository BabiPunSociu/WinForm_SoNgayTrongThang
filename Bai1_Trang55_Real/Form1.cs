using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai1_Trang55_Real
{
    public partial class Form1 : Form
    {
        int thang, nam;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void txtThang_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Xác thực rằng phím vừa nhấn không phải CTRL hoặc không phải dạng số
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            txtThang.MaxLength = 2;
            txtNam.MaxLength = 4;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblKetQua.Text = string.Empty;
            txtNam.Text = string.Empty;
            txtThang.Text = string.Empty;
            txtThang.Focus();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                // user clicked yes
                this.Close();
            }
        }

        private void btnKetQua_Click(object sender, EventArgs e)
        {
            thang = Convert.ToInt32(txtThang.Text);
            if(thang <1 || thang >12)
            {
                MessageBox.Show("Nhập tháng từ 1 -> 12 !");
                txtThang.Text = String.Empty;
                txtThang.Focus();
                return;
            }

            nam = Convert.ToInt32(txtNam.Text);
            if (nam <1000 || nam>9999)
            {
                MessageBox.Show("Nhập năm trong [1000,9999]");
                txtNam.Text = String.Empty;
                txtNam.Focus();
                return;
            }

            lblKetQua.Text = "Tháng " + thang + " năm " + nam + " có " + DateTime.DaysInMonth(nam,thang);
        }
    }
}
