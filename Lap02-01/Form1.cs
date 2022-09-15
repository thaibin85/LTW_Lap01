using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lap02_01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var num1 = int.Parse(txtNum1.Text);
                var num2 = int.Parse(txtNum2.Text);
                txtAnswer.Text = (num1 + num2).ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Thông báo",MessageBoxButtons.OK);
            }
        }

        private void btnSub_Click(object sender, EventArgs e)
        {
            try
            {
                var num1 = int.Parse(txtNum1.Text);
                var num2 = int.Parse(txtNum2.Text);
                txtAnswer.Text = (num1 - num2).ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void btnMul_Click(object sender, EventArgs e)
        {
            try
            {
                var num1 = int.Parse(txtNum1.Text);
                var num2 = int.Parse(txtNum2.Text);
                txtAnswer.Text = (num1 * num2).ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            try
            {
                var num1 = float.Parse(txtNum1.Text);
                var num2 = float.Parse(txtNum2.Text);
                if (num2 == 0)
                    throw new Exception("Không thể nhập số 0 là số chia");
                txtAnswer.Text = (num1 / num2).ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK);
            }
        }
    }
}
