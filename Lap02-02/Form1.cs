using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lap02_02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            rbtnNu.Checked = true;
            cmbChuyenNganh.SelectedIndex = 0;
            txtTongNam.Text = "0";
            txtTongNu.Text = "0";
        }

        private int GetSelectedRow(String studentID)
        {
            for (int i = 0; i < dgvStudent.Rows.Count; i++)
            {
                if (dgvStudent.Rows[i].Cells[0].Value?.ToString() == studentID)
                {
                    return i;
                }
            }
            return -1;
        }

        private void tinhSoNamNu()
        {
            int soNam = 0;
            for(int i = 0; i < dgvStudent.Rows.Count-1; i++)
            {
                if (dgvStudent.Rows[i].Cells["colGioiTinh"].FormattedValue.ToString() == "Nam")
                    soNam++;
            }
            int soNu = dgvStudent.Rows.Count -1 - soNam;
            txtTongNam.Text = soNam.ToString();
            txtTongNu.Text = soNu.ToString();
        }

        private void InsertUpdate(int selectedRow)
        {
            dgvStudent.Rows[selectedRow].Cells[0].Value = txtMSSV.Text;
            dgvStudent.Rows[selectedRow].Cells[1].Value = txtHoTen.Text;
            dgvStudent.Rows[selectedRow].Cells[2].Value = rbtnNu.Checked ? "Nữ" : "Nam";
            dgvStudent.Rows[selectedRow].Cells[3].Value = float.Parse(txtDTB.Text).ToString();
            dgvStudent.Rows[selectedRow].Cells[4].Value = cmbChuyenNganh.Text;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMSSV.Text == "" || txtHoTen.Text == "" || txtDTB.Text == "")
                    throw new Exception("Vui lòng điền đầy đủ thông tin sinh viên!");
                int selectedRow = GetSelectedRow(txtMSSV.Text);
                if(selectedRow == -1)
                {
                    selectedRow = dgvStudent.Rows.Add();
                    InsertUpdate(selectedRow);
                    MessageBox.Show("Thêm dữ liệu thành công!","Thông báo",MessageBoxButtons.OK);
                    tinhSoNamNu();
                }
                else
                {
                    InsertUpdate(selectedRow);
                    MessageBox.Show("Cập nhật dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK);
                    tinhSoNamNu();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void reset()
        {
            txtMSSV.Clear();
            txtDTB.Clear();
            txtHoTen.Clear();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedRow = GetSelectedRow(txtMSSV.Text);
                if (selectedRow == -1)
                {
                    throw new Exception("Không tìm thấy MSSV cần xóa!");
                }
                else
                {
                    DialogResult dr = MessageBox.Show("Bạn có muốn xóa?", "YES/NO", MessageBoxButtons.YesNo);
                    if(dr == DialogResult.Yes)
                    {
                        dgvStudent.Rows.RemoveAt(selectedRow);
                        MessageBox.Show("Xóa sinh viên thành công!", "Thông báo", MessageBoxButtons.OK);
                        tinhSoNamNu();
                        reset();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Lỗi",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvStudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvStudent.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    dgvStudent.CurrentRow.Selected = true;
                    txtMSSV.Text = dgvStudent.Rows[e.RowIndex].Cells["colMSSV"].FormattedValue.ToString();
                    txtHoTen.Text = dgvStudent.Rows[e.RowIndex].Cells["colHoTen"].FormattedValue.ToString();
                    txtDTB.Text = dgvStudent.Rows[e.RowIndex].Cells["colDTB"].FormattedValue.ToString();
                    if (dgvStudent.Rows[e.RowIndex].Cells["colKhoa"].FormattedValue.ToString() == "Nam")
                    {
                        rbtnNam.Checked = true;
                    }
                    else
                    {
                        rbtnNu.Checked = true;
                    }
                    cmbChuyenNganh.Text = dgvStudent.Rows[e.RowIndex].Cells["colKhoa"].FormattedValue.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Thông báo",MessageBoxButtons.OK);
            }
        }
    }
}
