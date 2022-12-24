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
    public partial class frmBH : DevExpress.XtraEditors.XtraForm
    {
        PHANMEMTRACUUNHACSY_CASYEntities data = new PHANMEMTRACUUNHACSY_CASYEntities();

        public frmBH()
        {
            InitializeComponent();
        }
        String chuoiketnoi = "Data Source=LAPTOP-T295SU9B\\SQLEXPRESS;Initial Catalog=PHANMEMTRACUUNHACSY_CASY;Integrated Security=True";
        String sql;
        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader docdulieu;
        int i = 0;
    
        

        private void labelControl5_Click(object sender, EventArgs e)
        {

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            {
                listView1.Clear();
                ketnoi.Open();
                sql = @"Insert into BAIHAT(MABAIHAT,TENBAIHAT,GIAIDIEU,MATHELOAI,MANHACSY,GHICHU) VALUES (N'" + txt_mabaihat.Text + @"',N'" + txt_tenbaihat.Text + @"',N'" + txt_giaidieu.Text + @"',N'" + txt_matheloai.Text + @"',N'" + txt_manhacsi.Text + @"',N'" + txt_ghichu.Text + @"')";
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
            sql = @"UPDATE BAIHAT SET
                   MABAIHAT= N'" + txt_mabaihat.Text + @"', TENBAIHAT=N'" + txt_tenbaihat.Text + @"',GIAIDIEU = N'" + txt_giaidieu.Text + @"', MATHELOAI =N'" + txt_matheloai.Text + @"', MANHACSY =N'" + txt_manhacsi.Text + @"', GHICHU =N'" + txt_ghichu.Text + @"'
                   WHERE    (MABAIHAT = N'" + txt_mabaihat.Text + @"')";
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
            hienthi();
        }

        private void frmBH_Load(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(chuoiketnoi);
            hienthi();
        }
        public void hienthi()
        {
            listView1.Items.Clear();
            ketnoi.Open();
            sql = @"Select MABAIHAT, TENBAIHAT, GIAIDIEU, MATHELOAI, MANHACSY, GHICHU FROM BAIHAT";
            thuchien = new SqlCommand(sql, ketnoi);
            docdulieu = thuchien.ExecuteReader();
            i = 0;
            while (docdulieu.Read())
            {
                listView1.Items.Add(docdulieu[0].ToString());
                listView1.Items[i].SubItems.Add(docdulieu[1].ToString());
                listView1.Items[i].SubItems.Add(docdulieu[2].ToString());
                listView1.Items[i].SubItems.Add(docdulieu[3].ToString());
                listView1.Items[i].SubItems.Add(docdulieu[4].ToString());
                listView1.Items[i].SubItems.Add(docdulieu[5].ToString());
                i++;
            }
            ketnoi.Close();
        }
        
        private void listView1_Click(object sender, EventArgs e)
        {
            txt_mabaihat.Text = listView1.SelectedItems[0].SubItems[0].Text;
            txt_tenbaihat.Text = listView1.SelectedItems[0].SubItems[1].Text;
            txt_giaidieu.Text = listView1.SelectedItems[0].SubItems[2].Text;
            txt_matheloai.Text = listView1.SelectedItems[0].SubItems[3].Text;
            txt_manhacsi.Text = listView1.SelectedItems[0].SubItems[4].Text;
            txt_ghichu.Text = listView1.SelectedItems[0].SubItems[5].Text;
        }

        private void btn_del_Click_1(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            ketnoi.Open();
            sql = @"Delete FROM BAIHAT Where (MABAIHAT = N'" + txt_mabaihat.Text + @"')";
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
            hienthi();
        }

        private void searchBH_Click(object sender, EventArgs e)
        {

        }

        private void btn_searchBH_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            ketnoi.Open();
            sql = "Select MABAIHAT, TENBAIHAT, GIAIDIEU, MATHELOAI, MANHACSY, GHICHU from BAIHAT Where (TENBAIHAT like '%" + searchBH.Text + "%')";
            thuchien = new SqlCommand(sql, ketnoi);
            docdulieu = thuchien.ExecuteReader();
            i = 0;
            while (docdulieu.Read())
            {
                listView1.Items.Add(docdulieu[0].ToString());
                listView1.Items[i].SubItems.Add(docdulieu[1].ToString());
                listView1.Items[i].SubItems.Add(docdulieu[2].ToString());
                listView1.Items[i].SubItems.Add(docdulieu[3].ToString());
                listView1.Items[i].SubItems.Add(docdulieu[4].ToString());
                listView1.Items[i].SubItems.Add(docdulieu[5].ToString());

                i++;
            }
            ketnoi.Close();
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}