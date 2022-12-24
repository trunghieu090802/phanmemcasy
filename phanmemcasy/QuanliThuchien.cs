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
    public partial class frm_TH : DevExpress.XtraEditors.XtraForm
    {
        public frm_TH()
        {
            InitializeComponent();
        }
        String chuoiketnoi = "Data Source=LAPTOP-T295SU9B\\SQLEXPRESS;Initial Catalog=PHANMEMTRACUUNHACSY_CASY;Integrated Security=True";
        String sql;
        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader docdulieu;
        int i = 0;

        private void listView1_Click(object sender, EventArgs e)
        {
            txt_MTH.Text = listView1.SelectedItems[0].SubItems[0].Text;
            txt_MCS.Text = listView1.SelectedItems[0].SubItems[1].Text;
            txt_MBH.Text = listView1.SelectedItems[0].SubItems[2].Text;
            txt_MBN.Text = listView1.SelectedItems[0].SubItems[3].Text;
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            ketnoi.Open();
            sql = @"Delete FROM THUCHIEN Where (MATHUCHIEN = N'" + txt_MTH.Text + @"')";
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
            hienthi();
        }

        private void btn_search_MCS_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            ketnoi.Open();
            sql = "Select MATHUCHIEN, MACASY, MABAIHAT, MABANNHAC from THUCHIEN Where (MACASY like '%" + search_MCS.Text + "%')";
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
        public void hienthi()
        {
            listView1.Items.Clear();
            ketnoi.Open();
            sql = @"Select MATHUCHIEN, MACASY, MABAIHAT, MABANNHAC FROM THUCHIEN";
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
        private void frm_TH_Load(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(chuoiketnoi);
            hienthi();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            {
                listView1.Clear();
                ketnoi.Open();
                sql = @"Insert into THUCHIEN(MATHUCHIEN,MACASY,MABAIHAT,MABANNHAC) VALUES (N'" + txt_MTH.Text + @"',N'" + txt_MCS.Text + @"',N'" + txt_MBH.Text + @"',N'" + txt_MBN.Text + @"')";
                thuchien = new SqlCommand(sql, ketnoi);
                thuchien.ExecuteNonQuery();
                ketnoi.Close();
                hienthi();
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            ketnoi.Open();
            sql = @"UPDATE THUCHIEN SET
                   MATHUCHIEN=N'" + txt_MTH.Text + @"', MACASY=N'" + txt_MCS.Text + @"',MABAIHAT = N'" + txt_MBH.Text + @"', MABANNHAC =N'" + txt_MBN.Text + @"'
                   WHERE    (MATHUCHIEN = N'" + txt_MTH.Text + @"')";
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
            hienthi();
        }
    }
}