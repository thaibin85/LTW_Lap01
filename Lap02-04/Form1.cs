using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lap02_04
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int soluong = 0;

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                this.Close();
        }

        private void clear()
        {
            txtID.Clear();
            txtAdress.Clear();
            txtName.Clear();
            txtMoney.Clear();
            txtID.Focus();
        }
        private int GetSelectedRow(string ID)
        {
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].SubItems[1].ToString().IndexOf(ID) > 0)
                {
                    return i;
                }
            }
            return -1;
        }

        private int tinhTongTien()
        {
            int tongTien = 0;
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                tongTien += int.Parse(listView1.Items[i].SubItems[4].Text);
            }
            return tongTien;
        }

        private void InsertUpdate(int selectedRow)
        {
            listView1.Items[selectedRow].SubItems[1].Text = txtID.Text;
            listView1.Items[selectedRow].SubItems[2].Text = txtName.Text;
            listView1.Items[selectedRow].SubItems[3].Text = txtAdress.Text;
            listView1.Items[selectedRow].SubItems[4].Text = txtMoney.Text;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtID.Text == "" || txtName.Text == "" || txtAdress.Text == "" || txtMoney.Text == "")
                    throw new Exception("Vui lòng nhập đầy đủ thông tin");
                int selectedRow = GetSelectedRow(txtID.Text);
                if (selectedRow == -1)
                {
                    soluong++;
                    ListViewItem item = new ListViewItem(soluong.ToString());
                    item.SubItems.Add(txtID.Text);
                    item.SubItems.Add(txtName.Text);
                    item.SubItems.Add(txtAdress.Text);
                    item.SubItems.Add(txtMoney.Text);
                    listView1.Items.Add(item);
                    MessageBox.Show("Thêm dữ liệu thành công", "thông báo", MessageBoxButtons.OK);
                }
                else
                {
                    InsertUpdate(selectedRow);
                    MessageBox.Show("Cập nhật dữ liệu thành công", "thông báo", MessageBoxButtons.OK);

                }
                txtTongTien.Text = tinhTongTien().ToString();
                //clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void btnDetele_Click(object sender, EventArgs e)
        {


            try
            {
                int selectedRow = GetSelectedRow(txtID.Text);
                if (selectedRow == -1)
                {
                    throw new Exception("Không tìm thấy sinh viên cần xóa");
                }
                else
                {
                    if(MessageBox.Show("Bạn có muốn xóa?","Yes/No",MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        listView1.Items[selectedRow].Remove();
                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK);
                        clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK);
            }
            txtTongTien.Text = tinhTongTien().ToString();
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            txtID.Text = listView1.FocusedItem.SubItems[1].Text;
            txtName.Text = listView1.FocusedItem.SubItems[2].Text;
            txtAdress.Text = listView1.FocusedItem.SubItems[3].Text;
            txtMoney.Text = listView1.FocusedItem.SubItems[4].Text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtTongTien.Text = "0";
        }
    }
}
