//using System;

//using System.Collections.Generic;

//using System.ComponentModel;

//using System.Data;

//using System.Drawing;

//using System.Linq;

//using System.Text;

//using System.Windows.Forms;

//namespace Lap02_03
//{

//    public partial class Form1 : Form

//    {

//        public Form1()

//        {

//            InitializeComponent();

//        }



//        private void btnKetThuc_Click(object sender, EventArgs e)

//        {

//            if (MessageBox.Show("thoat chuong trinh y/n?", "thong bao", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

//            {

//                this.Close();

//            }

//        }

//        List<Label> DanhSachChon = new List<Label>();

//        int intThanhTien = 0;

//        private void label2_Click(object sender, EventArgs e)

//        {

//            Label lbl = (Label)sender;

//            //neu label khac mau vang

//            if (lbl.BackColor != Color.Yellow)

//            {

//                //neu label la mau trang

//                if (lbl.BackColor == Color.White)

//                {

//                    //chuyen label mau trang thanh mau xanh

//                    lbl.BackColor = Color.Blue;

//                    DanhSachChon.Add(lbl);

//                }

//                else//nguoc lai label mau xanh

//                {

//                    //chuyen sang mau trang

//                    lbl.BackColor = Color.White;

//                    DanhSachChon.Remove(lbl);

//                }

//            }

//            else//label mau vang

//            {

//                //thang bao co nguoi chon roi

//                MessageBox.Show("Bàn này có người chọn rồi");

//            }

//        }

//        private void btnChon_Click(object sender, EventArgs e)

//        {

//            foreach (Label l in DanhSachChon)

//            {

//                l.BackColor = Color.Yellow;

//                intThanhTien += 100;

//            }

//            lblThanhTien.Text = intThanhTien.ToString();

//            intThanhTien = 0;

//            DanhSachChon = new List<Label>();

//        }

//        private void btnHuy_Click(object sender, EventArgs e)

//        {

//            foreach (Label l in DanhSachChon)

//            {

//                l.BackColor = Color.White;

//            }

//            lblThanhTien.Text = "";

//            DanhSachChon = new List<Label>();

//        }

//    }

//}