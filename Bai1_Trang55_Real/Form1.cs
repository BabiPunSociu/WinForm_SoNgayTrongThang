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

            if (e.KeyChar==13)
            {
				btnKetQua_Click(sender, e);

			}    
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
            if(txtThang.Text == string.Empty || Convert.ToInt32(txtThang.Text) < 1 || Convert.ToInt32(txtThang.Text) > 12)
            {
                MessageBox.Show("Nhập tháng từ 1 -> 12 !");
                txtThang.Text = String.Empty;
                txtThang.Focus();
                return;
            }

            if (txtNam.Text==string.Empty || Convert.ToInt32(txtNam.Text) < 1000 || Convert.ToInt32(txtNam.Text) > 9999)
            {
                MessageBox.Show("Nhập năm trong [1000,9999]");
                txtNam.Text = String.Empty;
                txtNam.Focus();
                return;
            }

            lblKetQua.Text = "Tháng " + Convert.ToInt32(txtThang.Text) + " năm " + Convert.ToInt32(txtNam.Text) + " có " + DateTime.DaysInMonth(Convert.ToInt32(txtNam.Text), Convert.ToInt32(txtThang.Text));
        }
    }
}
