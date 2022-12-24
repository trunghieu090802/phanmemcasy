using DevExpress.ClipboardSource.SpreadsheetML;
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
using System.Runtime.Remoting.Contexts;
using DevExpress.XtraPrinting;


namespace phanmemcasy
{
    public partial class frmNS : DevExpress.XtraEditors.XtraForm
    {
        PHANMEMTRACUUNHACSY_CASYEntities data = new PHANMEMTRACUUNHACSY_CASYEntities();

        public frmNS()
        {
            InitializeComponent();
        }
        String chuoiketnoi = "Data Source=LAPTOP-T295SU9B\\SQLEXPRESS;Initial Catalog=PHANMEMTRACUUNHACSY_CASY;Integrated Security=True";
        String sql;
        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader docdulieu;
        int i = 0;
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            {
                listView1.Clear();
                ketnoi.Open();
                sql = @"Insert into NHACSY(MANHACSY,TENNHACSY,DIACHI,SODIENTHOAI) VALUES (N'" + txtUser.Text + @"',N'" + txt_TenNS.Text + @"',N'" + txt_Diachi.Text + @"',N'" + txt_SDT.Text + @"')";
                thuchien = new SqlCommand(sql, ketnoi);
                thuchien.ExecuteNonQuery();
                ketnoi.Close();
                hienthi();
            }
        }

      

        private void btn_del_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            ketnoi.Open();
            sql = @"Delete FROM NHACSY Where (MANHACSY = N'" + txtUser.Text + @"')";
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
            hienthi();
        }

        private void frmNS_Load(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(chuoiketnoi);
            hienthi();
        }
        public void hienthi()
        {
            listView1.Items.Clear();
            ketnoi.Open();
            sql = @"Select MANHACSY, TENNHACSY, DIACHI, SODIENTHOAI FROM NHACSY";
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
        
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            ketnoi.Open();
            sql = @"UPDATE NHACSY SET
                   MANHACSY=N'" + txtUser.Text + @"', TENNHACSY=N'" + txt_TenNS.Text + @"',DIACHI = N'" + txt_Diachi.Text + @"', SODIENTHOAI =N'" + txt_SDT.Text + @"'
                   WHERE    (MANHACSY = N'" + txtUser.Text + @"')";
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
            hienthi();
        }

        private void btn_searchNS_Click(object sender, EventArgs e)
        {
                listView1.Items.Clear();
                ketnoi.Open();
                sql = "Select MANHACSY, TENNHACSY, DIACHI, SODIENTHOAI from NHACSY Where (TENNHACSY like '%" + searchNS.Text + "%')";
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

        private void listView1_Click_1(object sender, EventArgs e)
        {
            txtUser.Text = listView1.SelectedItems[0].SubItems[0].Text;
            txt_TenNS.Text = listView1.SelectedItems[0].SubItems[1].Text;
            txt_Diachi.Text = listView1.SelectedItems[0].SubItems[2].Text;
            txt_SDT.Text = listView1.SelectedItems[0].SubItems[3].Text;
        }
    }
}