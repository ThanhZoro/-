using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace CaroChess1._2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            Thread t = new Thread(new ThreadStart(SplashScreen));
            t.Start();
            Thread.Sleep(3000);
            InitializeComponent();
            t.Abort();
        }

        // Thiết kế Form3: Form nạp giới thiệu
        private void SplashScreen()
        {
            Application.Run(new Form3());
        }
        //-----------------------------------

        // Bắt sự kiện FormClosed cho Form2
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        //---------------------------------

        // Bắt sự kiện Click cho ptbHelp
        private void ptbHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Luật chơi\nTrên bàn cờ 20x20 ô vuông. Một người đi X, một người đi O.\nKhi đến lượt mình, người chơi phải tích vào một ô trên bàn cờ. Người chơi phải tìm cách tích đủ 5 ô theo chiều dọc hoặc chiều ngang hoặc đường chéo thì sẽ thắng.\nMỗi người chơi có 20s để đi. Sau 20s mà người chơi không tích vào ô sẽ bị bỏ 1 lượt đánh.\nKhi đã đi hết bàn cờ mà chưa phân thắng bại thì coi như hòa.", "Help", MessageBoxButtons.OK);
        }
        //------------------------------

        #region Thiết kế ptbPvsC
        // Bắt sự kiện Click
        private void ptbPvsC_Click(object sender, EventArgs e)
        {
            Form1 _form1 = new Form1();
            this.Hide();
            _form1.CheDoChoi = 2;
            _form1.ShowDialog();  
        }
        //------------------

        // Bắt sự kiện MouseMove(di chuyển chuột vào)
        private void ptbPvsC_MouseMove(object sender, MouseEventArgs e)
        {
            ptbPvsC_Player.BackColor = Color.GreenYellow;
            ptbO.BackColor = Color.GreenYellow;
            ptbPvsC_Com.BackColor = Color.Yellow;
            ptbX.BackColor = Color.Yellow;
            ptbVs.BackColor = Color.Gold;
        }
        //-------------------------------------------

        // Bắt sự kiện MouseLeave(di chuyển chuột ra)
        private void ptbPvsC_MouseLeave(object sender, EventArgs e)
        {
            ptbPvsC_Player.BackColor = Color.White;
            ptbX.BackColor = Color.White;
            ptbPvsC_Com.BackColor = Color.White;
            ptbO.BackColor = Color.White;
            ptbVs.BackColor = Color.White;
        }
        //-------------------------------------------
        #endregion

        #region Thiết kế ptbPvsP
        // Bắt sự kiện Click
        private void ptbPvsP_Click(object sender, EventArgs e)
        {
            Form1 _form1 = new Form1();
            this.Hide();
            _form1.CheDoChoi = 1;
            _form1.ShowDialog();
        }
        
        //------------------

        // Bắt sự kiện MouseMove(di chuyển chuột vào)
        private void ptbPvsP_MouseMove(object sender, MouseEventArgs e)
        {
            ptbPvsP_PlayerDuoi.BackColor = Color.Yellow;
            ptbO.BackColor = Color.Yellow;
            ptbPvsP_PlayerTren.BackColor = Color.GreenYellow;
            ptbX.BackColor = Color.GreenYellow;
            ptbVs.BackColor = Color.Gold;
        }
        //-------------------------------------------

        // Bắt sự kiện MouseLeave(si chuyển chuột ra)
        private void ptbPvsP_MouseLeave(object sender, EventArgs e)
        {
            ptbPvsP_PlayerDuoi.BackColor = Color.White;
            ptbO.BackColor = Color.White;
            ptbPvsP_PlayerTren.BackColor = Color.White;
            ptbX.BackColor = Color.White;
            ptbVs.BackColor = Color.White;
        }
        #endregion

        #region Thiết kế ptbDacBiet
        // Bắt sự kiện Click
        private void ptbDacBiet_Click(object sender, EventArgs e)
        {
            Form1 _form1 = new Form1();
            this.Hide();
            _form1.CheDoChoi = 3;
            _form1.ShowDialog();
        }
        //------------------

        // Bắt sự kiện MouseMove 
        private void ptbDacBiet_MouseMove(object sender, MouseEventArgs e)
        {
            ptbDacBiet.BackColor = Color.Blue;
        }
        //----------------------

        // Bắt sự kiện MouseLeave
        private void ptbDacBiet_MouseLeave(object sender, EventArgs e)
        {
            ptbDacBiet.BackColor = Color.White;
        }
        //-----------------------
        #endregion

    }
}
