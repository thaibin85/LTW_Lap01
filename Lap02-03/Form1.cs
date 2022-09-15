using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lap02_03
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Button> buttons = new List<Button>();
        List<Button> LoA = new List<Button>();
        List<Button> LoB = new List<Button>();
        List<Button> LoC = new List<Button>();
        int thanhTien = 0;

        private void btnChooseAseat(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.BackColor != Color.Yellow)
            {
                if (btn.BackColor == Color.White)
                {
                    btn.BackColor = Color.Blue;
                    buttons.Add(btn);
                }
                else
                {
                    btn.BackColor = Color.White;
                    buttons.Remove(btn);
                }

            }
            else
                MessageBox.Show("Ghế đã được bán!!");
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            foreach (var item in buttons)
            {
                item.BackColor = Color.Yellow;
                int soGhe = int.Parse(item.Name.Substring(3));
                if (soGhe < 6)
                    thanhTien += 5000;
                else if (soGhe < 11)
                    thanhTien += 6500;
                else thanhTien += 8000;
            }
            txtThanhTien.Text = thanhTien.ToString();
            thanhTien = 0;
            buttons = new List<Button>();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            foreach (var item in buttons)
            {
                item.BackColor = Color.White;
                thanhTien++;
            }
            txtThanhTien.Text = "";
            buttons = new List<Button>();
        }

        private void btnKetThuc_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát?", "Thoát", MessageBoxButtons.YesNo) == DialogResult.Yes)
                this.Close();
        }
    }
}
