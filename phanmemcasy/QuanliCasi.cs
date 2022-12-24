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
using DevExpress.XtraPrinting;
using System.Runtime.Remoting.Contexts;

namespace phanmemcasy
{
    public partial class frmCS : DevExpress.XtraEditors.XtraForm
    {
        PHANMEMTRACUUNHACSY_CASYEntities data= new PHANMEMTRACUUNHACSY_CASYEntities();
        public frmCS()
        {
            InitializeComponent();   
        }
        String chuoiketnoi = "Data Source=LAPTOP-T295SU9B\\SQLEXPRESS;Initial Catalog=PHANMEMTRACUUNHACSY_CASY;Integrated Security=True";
        String sql;
        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader docdulieu;
        int i = 0;
        
        private void frmCS_Load(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(chuoiketnoi);
            hienthi();
        }
        public void hienthi()
        {
            listView1.Items.Clear();
            ketnoi.Open();
            sql = @"Select MACASY, TENCASY, DIACHI, SODIENTHOAI FROM CASY";
            thuchien = new SqlCommand(sql, ketnoi);
            docdulieu = thuchien.ExecuteReader();
            i = 0;
            while(docdulieu.Read())
            {
                listView1.Items.Add(docdulieu[0].ToString());
                listView1.Items[i].SubItems.Add(docdulieu[1].ToString());
                listView1.Items[i].SubItems.Add(docdulieu[2].ToString());
                listView1.Items[i].SubItems.Add(docdulieu[3].ToString());          
                i++;
            }
            ketnoi.Close();
        }

        

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            
                listView1.Clear();
                ketnoi.Open();
                sql = @"Insert into CASY(MACASY,TENCASY,DIACHI,SODIENTHOAI) VALUES (N'" + txMaCS.Text + @"',N'" + txTenCS.Text + @"',N'" + txDchiCS.Text + @"',N'" + txSDT_CS.Text + @"')";
                thuchien = new SqlCommand(sql, ketnoi);
                thuchien.ExecuteNonQuery();
                ketnoi.Close();
                hienthi();
             
        }

        private void pictureEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            ketnoi.Open();
            sql = @"Delete FROM CASY Where (MACASY = N'" + txMaCS.Text + @"')";
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
            hienthi();
        }
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            ketnoi.Open();
            sql=@"UPDATE CASY SET
                   MACASY=N'"+txMaCS.Text+@"', TENCASY=N'"+txTenCS.Text+@"',DIACHI = N'"+txDchiCS.Text+@"', SODIENTHOAI =N'"+txSDT_CS.Text +@"'
                   WHERE    (MACASY = N'"+txMaCS.Text+ @"')";
            thuchien = new SqlCommand(sql, ketnoi); 
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
            hienthi();
        }

       

        private void listView1_Click(object sender, EventArgs e)
        {
            txMaCS.Text = listView1.SelectedItems[0].SubItems[0].Text;
            txTenCS.Text = listView1.SelectedItems[0].SubItems[1].Text;
            txDchiCS.Text = listView1.SelectedItems[0].SubItems[2].Text;
            txSDT_CS.Text = listView1.SelectedItems[0].SubItems[3].Text;
        }

        private void btn_searchCS_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            ketnoi.Open();
            sql = "Select MACASY, TENCASY, DIACHI, SODIENTHOAI from CASY Where (TENCASY like '%" + searchCS.Text + "%')";
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

        private void txSDT_CS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}