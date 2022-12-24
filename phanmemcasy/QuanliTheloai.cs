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
    public partial class frm_theloai : DevExpress.XtraEditors.XtraForm
    {
        public frm_theloai()
        {
            InitializeComponent();
        }
        String chuoiketnoi = "Data Source=LAPTOP-T295SU9B\\SQLEXPRESS;Initial Catalog=PHANMEMTRACUUNHACSY_CASY;Integrated Security=True";
        String sql;
        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader docdulieu;
        int i = 0;
        private void QuanliTheloai_Load(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(chuoiketnoi);
            hienthi();
        }
        public void hienthi()
        {
            listView1.Items.Clear();
            ketnoi.Open();
            sql = @"Select MATHELOAI, TENTHELOAI FROM THELOAI";
            thuchien = new SqlCommand(sql, ketnoi);
            docdulieu = thuchien.ExecuteReader();
            i = 0;
            while (docdulieu.Read())
            {
                listView1.Items.Add(docdulieu[0].ToString());
                listView1.Items[i].SubItems.Add(docdulieu[1].ToString());
                i++;
            }
            ketnoi.Close();
        }
        private void btn_del_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            ketnoi.Open();
            sql = @"Delete FROM THELOAI Where (MATHELOAI = N'" + txMaTL.Text + @"')";
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
            hienthi();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            {
                listView1.Clear();
                ketnoi.Open();
                sql = @"Insert into THELOAI(MATHELOAI,TENTHELOAI) VALUES (N'" + txMaTL.Text + @"',N'" + txTenTL.Text + @"')";
                thuchien = new SqlCommand(sql, ketnoi);
                thuchien.ExecuteNonQuery();
                ketnoi.Close();
                hienthi();
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            ketnoi.Open();
            sql = @"UPDATE THELOAI SET
                   MATHELOAI=N'" + txMaTL.Text + @"', TENTHELOAI=N'" + txTenTL.Text + @"'
                   WHERE    (MATHELOAI = N'" + txMaTL.Text + @"')";
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
            hienthi();
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            txMaTL.Text = listView1.SelectedItems[0].SubItems[0].Text;
            txTenTL.Text = listView1.SelectedItems[0].SubItems[1].Text;
        }

        private void btn_searchTL_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            ketnoi.Open();
            sql = "Select MATHELOAI, TENTHELOAI from THELOAI Where (TENTHELOAI like '%" + search_TL.Text + "%')";
            thuchien = new SqlCommand(sql, ketnoi);
            docdulieu = thuchien.ExecuteReader();
            i = 0;
            while (docdulieu.Read())
            {
                listView1.Items.Add(docdulieu[0].ToString());
                listView1.Items[i].SubItems.Add(docdulieu[1].ToString());
                i++;
            }
            ketnoi.Close();
        }
    }
}