using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace phanmemcasy
{
    public partial class frm_NC : DevExpress.XtraEditors.XtraForm
    {
        public frm_NC()
        {
            InitializeComponent();
        }
        String chuoiketnoi = "Data Source=LAPTOP-T295SU9B\\SQLEXPRESS;Initial Catalog=PHANMEMTRACUUNHACSY_CASY;Integrated Security=True";
        String sql;
        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader docdulieu;
        int i = 0;
        private void QuanliNhaccong_Load(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(chuoiketnoi);
            hienthi();
        }
        public void hienthi()
        {
            listView1.Items.Clear();
            ketnoi.Open();
            sql = @"Select MANHACCONG, TENNHACCONG, NHACCUSUDUNG, MABANNHAC FROM NHACCONG";
            thuchien = new SqlCommand(sql, ketnoi);
            docdulieu = thuchien.ExecuteReader();
            i = 0;
            while (docdulieu.Read())
            {
                listView1.Items.Add(docdulieu[0].ToString());
                listView1.Items[i].SubItems.Add(docdulieu[1].ToString());
                listView1.Items[i].SubItems.Add(docdulieu[2].ToString());
                listView1.Items[i].SubItems.Add(docdulieu[3].ToString());
                i++;
            }
            ketnoi.Close();
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            {
                listView1.Clear();
                ketnoi.Open();
                sql = @"Insert into NHACCONG(MANHACCONG,TENNHACCONG,NHACCUSUDUNG,MABANNHAC) VALUES (N'" + txt_MNC.Text + @"',N'" + txt_TenNC.Text + @"',N'" + txt_NCSD.Text + @"',N'" + txt_MBN.Text + @"')";
                thuchien = new SqlCommand(sql, ketnoi);
                thuchien.ExecuteNonQuery();
                ketnoi.Close();
                hienthi();
            }
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            txt_MNC.Text = listView1.SelectedItems[0].SubItems[0].Text;
            txt_TenNC.Text = listView1.SelectedItems[0].SubItems[1].Text;
            txt_NCSD.Text = listView1.SelectedItems[0].SubItems[2].Text;
            txt_MBN.Text = listView1.SelectedItems[0].SubItems[3].Text;
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            ketnoi.Open();
            sql = @"UPDATE NHACCONG SET
                   MANHACCONG=N'" + txt_MNC.Text + @"', TENNHACCONG=N'" + txt_TenNC.Text + @"',NHACCUSUDUNG = N'" + txt_NCSD.Text + @"', MABANNHAC =N'" + txt_MBN.Text + @"'
                   WHERE    (MANHACCONG = N'" + txt_MNC.Text + @"')";
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
            hienthi();
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            ketnoi.Open();
            sql = @"Delete FROM NHACCONG Where (MANHACCONG = N'" + txt_MNC.Text + @"')";
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
            hienthi();
        }

        private void btn_search_NC_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            ketnoi.Open();
            sql = "Select MANHACCONG, TENNHACCONG, NHACCUSUDUNG, MABANNHAC from NHACCONG Where (TENNHACCONG like '%" + search_NC.Text + "%')";
            thuchien = new SqlCommand(sql, ketnoi);
            docdulieu = thuchien.ExecuteReader();
            i = 0;
            while (docdulieu.Read())
            {
                listView1.Items.Add(docdulieu[0].ToString());
                listView1.Items[i].SubItems.Add(docdulieu[1].ToString());
                listView1.Items[i].SubItems.Add(docdulieu[2].ToString());
                listView1.Items[i].SubItems.Add(docdulieu[3].ToString());
                i++;
            }
            ketnoi.Close();
        }
    }
}