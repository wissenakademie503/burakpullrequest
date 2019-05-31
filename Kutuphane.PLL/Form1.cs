using Kutuphane.BLL;
using Kutuphane.EntityLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kutuphane.PLL
{
    public partial class frmKITAP : Form
    {
        public frmKITAP()
        {
            InitializeComponent();
        }

        private void frmKITAP_Load(object sender, EventArgs e)
        {
            kitapListele();
            kategoriListele();
        }

        private void kategoriListele()
        {
            List<EKATEGORI> kategoriListesi = BLLKATEGORI.SelectList();

            //foreach(EKATEGORI item in kategoriListesi)
            //{
            //    txtKategori.Items.Add(item);

            //}

            txtKategori.DataSource = kategoriListesi;
            txtKategori.DisplayMember = "ADI";
            txtKategori.ValueMember = "ID";
        }

        private void kitapListele()
        {
            List<EKITAP> kitapListesi = BLLKITAP.SelectList();
            Liste.DataSource = kitapListesi;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            EKITAP kitapItem = new EKITAP();
            kitapItem.KATEGORIID = Convert.ToInt32(txtKategori.SelectedValue);
            kitapItem.SAYFASAYISI = short.Parse(txtSayfaSayisi.Text);
            kitapItem.YAZAR = txtYazar.Text;
            kitapItem.ADI = txtKitapAdi.Text;

            if (BLLKITAP.Insert(kitapItem)>0)
            {
              
                MessageBox.Show("KİTAP Ekleme İşLemi BasaRılı");
              
            }
            else
            {
                MessageBox.Show("KİTAP Ekleme İşLemi Hatalı.->HATA KODU:1993");
            }
           
            
            
        }
    }
}
