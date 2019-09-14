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

namespace SifreliVeriUygulaması
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();

        void listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from TBL_VERILER", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID");
            dt2.Columns.Add("AD");
            dt2.Columns.Add("SOYAD");
            dt2.Columns.Add("MAIL");
            dt2.Columns.Add("SIFRE");
            dt2.Columns.Add("HESAPNO");
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataRow r = dt2.NewRow();
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    try
                    {
                        string cozum = dataGridView1.Rows[i].Cells[j].Value.ToString();
                        byte[] cozumdizi = Convert.FromBase64String(cozum);
                        string cozumveri = ASCIIEncoding.ASCII.GetString(cozumdizi);
                        r[j] = cozumveri;
                    }
                    catch (Exception)
                    {
                        r[j] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    }
                }
                dt2.Rows.Add(r);
            }
            dataGridView2.DataSource = dt2;
        }

       
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            string ad = txtad.Text;
            byte[] addizi = ASCIIEncoding.ASCII.GetBytes(ad);//şifreliyoruz burada
            string adsifre = Convert.ToBase64String(addizi); //burada da şifreleme yönetemi olarak stringe çeviriyoruz.

            string soyad = txtsoyad.Text;
            byte[] soyadizi = ASCIIEncoding.ASCII.GetBytes(soyad);//şifreliyoruz burada
            string soyadsifre = Convert.ToBase64String(soyadizi); //burada da şifreleme yönetemi olarak stringe çeviriyoruz.

            string mail = txtmail.Text;
            byte[] maildizi = ASCIIEncoding.ASCII.GetBytes(mail);
            string mailsifre = Convert.ToBase64String(maildizi);

            string sifre = txtsifre.Text;
            byte[] sifredizi = ASCIIEncoding.ASCII.GetBytes(sifre);//şifreliyoruz burada
            string sifresifre = Convert.ToBase64String(sifredizi);

            string hesapno = txthesno.Text;
            byte[] hesapnodizi = ASCIIEncoding.ASCII.GetBytes(hesapno);//şifreliyoruz burada
            string hesapnosifre= Convert.ToBase64String(hesapnodizi);

            SqlCommand komut = new SqlCommand("INSERT INTO TBL_VERILER (AD,SOYAD, MAIL, SIFRE, HESAPNO) " +
                "VALUES (@P1,@P2,@P3,@P4,@P5)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", adsifre);
            komut.Parameters.AddWithValue("@p2", soyadsifre);
            komut.Parameters.AddWithValue("@p3", mailsifre);
            komut.Parameters.AddWithValue("@p4", sifresifre);
            komut.Parameters.AddWithValue("@p5", hesapnosifre);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("VERİLER EKLENDİ.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void BtnCöz_Click(object sender, EventArgs e)
        {
            string adcozum = txtad.Text;
            byte[] adcozumdizi = Convert.FromBase64String(adcozum);
            string adverisi = ASCIIEncoding.ASCII.GetString(adcozumdizi);
            txtveri.Text = adverisi;
        }
    }
}
