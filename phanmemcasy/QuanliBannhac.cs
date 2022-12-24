using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace phanmemcasy
{

    public partial class frm_BN : DevExpress.XtraEditors.XtraForm
    {
        public frm_BN()
        {
            InitializeComponent();
        }
        String chuoiketnoi = "Data Source=LAPTOP-T295SU9B\\SQLEXPRESS;Initial Catalog=PHANMEMTRACUUNHACSY_CASY;Integrated Security=True";
        String sql;
        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader docdulieu;
        int i = 0;

        private void frm_BN_Load(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(chuoiketnoi);
            hienthi();
        }
        public void hienthi()
        {
            listView1.Items.Clear();
            ketnoi.Open();
            sql = @"Select MABANNHAC, TENBANNHAC, SODTLIENHE, MATRUONGNHOM FROM BANNHAC";
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
        private void listView1_Click(object sender, EventArgs e)
        {
            txMaBN.Text = listView1.SelectedItems[0].SubItems[0].Text;
            txTenBN.Text = listView1.SelectedItems[0].SubItems[1].Text;
            txSDT.Text = listView1.SelectedItems[0].SubItems[2].Text;
            txTruongNhom.Text = listView1.SelectedItems[0].SubItems[3].Text;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            {
                listView1.Clear();
                ketnoi.Open();
                sql = @"Insert into BANNHAC(MABANNHAC,TENBANNHAC,SODTLIENHE,MATRUONGNHOM) VALUES (N'" + txMaBN.Text + @"',N'" + txTenBN.Text + @"',N'" + txSDT.Text + @"',N'" + txTruongNhom.Text + @"')";
                thuchien = new SqlCommand(sql, ketnoi);
                thuchien.ExecuteNonQuery();
                ketnoi.Close();
                hienthi();
            }
        }
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            ketnoi.Open();
            sql = @"Delete FROM BANNHAC Where (MABANNHAC = N'" + txMaBN.Text + @"')";
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
            hienthi();
        }

        private void btn_searchBN_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            ketnoi.Open();
            sql = "Select MABANNHAC, TENBANNHAC, SODTLIENHE,MATRUONGNHOM from BANNHAC Where (TENBANNHAC like '%" + search_BN.Text + "%')";
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

        private void txSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void simpleButton3_Click_1(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            ketnoi.Open();
            sql = @"UPDATE BANNHAC SET
                   MABANNHAC= N'" + txMaBN.Text + @"', TENBANNHAC=N'" + txTenBN.Text + @"',SODTLIENHE = N'" + txSDT.Text + @"',MATRUONGNHOM =N'" + txTruongNhom.Text + @"'
                   WHERE    (MABANNHAC = N'" + txMaBN.Text + @"')";
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
            hienthi();
        }
    }  
}