using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DLL
{
    public partial class usSanPham : UserControl
    {
        Boolean check = true;
        public usSanPham()
        {
            InitializeComponent();
        }


        #region method
        public void setValue(float gia, string path, string tenSanPham)
        {
            lbGia.Text = ConvertValue.convertValueMoney(gia);
            try
            {
                this.pic.Image = Image.FromFile(path);

            }
            catch
            {
                this.pic.Image = Image.FromFile("../../Asset/More/ic_image.png");
            }

            pic.SizeMode = PictureBoxSizeMode.StretchImage;
            lbTenSanPham.Text = tenSanPham;
        }
        public void setSuKien()
        {
            //foreach(Control item in pnChinh.Controls)
            //{
            //    item.Click += Item_Click;
            //}
            //pnChinh.Click += PnChinh_Click;
        }

        

        #endregion

        private void usSanPham_Load(object sender, EventArgs e)
        {
            this.AutoSize = true;
        }

        private void PnChinh_Click(object sender, EventArgs e)
        {

        }

        private void Item_Click(object sender, EventArgs e)
        {

        }

        

        private void lbGia_Click(object sender, EventArgs e)
        {
            
        }
    }
}
