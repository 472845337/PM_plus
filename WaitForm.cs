using PM_plus.config;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PM_plus {
    public partial class WaitForm : Form {

        MemoryStream ms;
        public WaitForm() {
            InitializeComponent();
            this.ControlBox = false;
        }

        private void WaitForm_Load(object sender, EventArgs e) {
            Config.mainForm.Enabled = false;
            LoadingPictureBox.Image = ConvertGifFileToImage("resources/loading.gif");
        }

        private void WaitForm_FormClosed(object sender, FormClosedEventArgs e) {
            Config.mainForm.Enabled = true;
        }

        /// <summary>
        /// 从指定的路径读取gif图片并转成Image
        /// </summary>
        /// <param name="GifFilePath">gif图片的路径</param>
        /// <returns>转换后的Image</returns>
        private Image ConvertGifFileToImage(string GifFilePath) {

            //下面的操作从文件读取到fs流后还要转成ms流呢？因为如果fs流不关闭，下次再读同名的gif文件时就会抛异常
            FileStream fs = new FileStream(GifFilePath, FileMode.Open);
            byte[] byteArray = new byte[fs.Length];
            int result = fs.Read(byteArray, 0, byteArray.Length);
            fs.Seek(0, SeekOrigin.Begin);
            ms = new MemoryStream(byteArray);

            Image img = Image.FromStream(ms);

            fs.Dispose();
            fs.Close();
            return img;
        }
    }
}
