using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CaroChess1._2
{
    public partial class Form1 : Form
    {
        private CaroChess CoCaro;
        private Graphics grs;
        private int _CheDoChoi;
        public int CheDoChoi
        {
            set { _CheDoChoi = value; }
            get { return _CheDoChoi; }
        }

        public Form1()
        {
            InitializeComponent();
            CoCaro = new CaroChess();
            CoCaro.KhoiTaoMangOCo();
            grs = pnlBanco.CreateGraphics();
        }

        //Bắt sự kiện Load cho Form1
        private void Form1_Load(object sender, EventArgs e)
        {
            CoCaro.LuuCheDoChoi = _CheDoChoi;
            if (CheDoChoi == 1 || CheDoChoi == 2)
            {
                if (CheDoChoi == 1)
                {
                    CoCaro.StartPlayerVsPlayer(grs);
                    lbPlayer1.Text = "Player 1";
                    lbPlayer2.Text = "Player 2";
                }
                else if (CheDoChoi == 2)
                {
                    CoCaro.StartPlayerVsCom(grs);
                    lbPlayer1.Text = "Com";
                    lbPlayer2.Text = "Player";
                    ptbDenLuotO.Visible = true;
                }
                DialogResult _load = MessageBox.Show(" Sau khi nhấn \"OK\" đồng hồ sẽ bắt đầu đếm.\n Mỗi lượt có 20s để suy nghĩ nếu hết 20s bạn chưa đánh quân cờ của mình sẽ bị mất lượt.\n Bạn đã sẵn sàng chưa?", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Information);
                if (_load == DialogResult.OK)
                {
                    timer1.Enabled = true;
                }
            }
            else if (CheDoChoi == 3)
            {
                CoCaro.StartPlayerVsCom(grs);
                lbPlayer1.Text = "Com";
                lbPlayer2.Text = "Player";
                ptbDenLuotO.Visible = true;
                DialogResult _load = MessageBox.Show(" Sau khi nhấn \"OK\" đồng hồ sẽ bắt đầu đếm.\n Bạn sẽ có 30s để đấu với máy và giành lấy chiến thắng.\n Nếu quá 30s mà bạn chưa chiến thắng sẽ bị xử thua.\n Bạn đã sẵn sàng chưa?", "Chế độ Đặc Biệt", MessageBoxButtons.OK,MessageBoxIcon.Information);
                if (_load == DialogResult.OK)
                {
                    timer2.Enabled = true;
                }
            }
            
        }
        //----------------------------------

        // Bắt sự kiện Tick của Time2
        int time2 = 0;
        private void timer2_Tick(object sender, EventArgs e)
        {
            time2++;
            lbTime.Text = time2.ToString();
            if (CoCaro.KiemTraChienThang())
                timer2.Enabled = false;
            if (time2 == 30)
            {
                timer2.Enabled = false;
                CoCaro.SanSang = false;
                MessageBox.Show("Bạn đã hết thời gian chinh phục thử thách.\nComputer Win!!!");
            }
         }
        //---------------------------

        // Bắt sự kiện Tick của Time1
        int time = -1;
        private void timer1_Tick(object sender, EventArgs e)
        {
            time++;
            lbTime.Text = time.ToString();
            switch (time)
            { 
                case 14:
                    lbThongBao.Visible = true;
                    break;
                case 19:
                    lbThongBao.Visible = false;
                    CoCaro.SanSang = false;
                    break;
                case 20:
                    lbMatLuot.Visible = true;
                    break;    
                case 2:
                    lbMatLuot.Visible = false;
                    break;
            }
            if (CoCaro.KiemTraChienThang())
                timer1.Enabled = false;
            if (!CoCaro.DaDanhCo)
            {
                if (time == 21)
                {
                    if (CheDoChoi == 1)
                    {
                        timer1.Enabled = false;
                        if (CoCaro.LuotDi == 1)
                        {
                            CoCaro.LuotDi = 2;
                            ptbDenLuotX.Visible = false;
                            ptbDenLuotO.Visible = true;
                        }
                        else
                        {
                            CoCaro.LuotDi = 1;
                            ptbDenLuotX.Visible = true;
                            ptbDenLuotO.Visible = false;

                        }
                    }
                    if (CheDoChoi == 2 || CheDoChoi == 3)
                    {
                        if (CoCaro.LuotDi == 2)
                        {
                            CoCaro.LuotDi = 1;
                            CoCaro.KhoiDongComputer(grs);
                            CoCaro.LuotDi = 2;
                        }
                    }
                    CoCaro.DaDanhCo = false;
                    time = 0;
                    timer1.Enabled = true;
                    CoCaro.SanSang = true;
                }
            }
            else
            {
                timer1.Enabled = false;
                if (time > 14)
                    lbThongBao.Visible = false;
                CoCaro.DaDanhCo = false;
                time = 0;
                timer1.Enabled = true;
            }
        }
        //---------------------------

        //Bắt sự kiện FromClosed cho Form1
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        //----------------------------------

        // Bắt sự kiện Paint cho pnlBanco
        private void pnlBanco_Paint(object sender, PaintEventArgs e)
        {
            CoCaro.VeBanCo(grs);
            CoCaro.VeLaiQuanCo(grs);
        }
        //-------------------------------

        // Bắt sự kiện MouseClick cho pnlBanco
        private void pnlBanco_MouseClick(object sender, MouseEventArgs e)
        {
            if (!CoCaro.SanSang)
                return;
            if (CoCaro.LuotDi == 1)
            {
                ptbDenLuotX.Visible = false;
                ptbDenLuotO.Visible = true;
            }
            else
            {
                ptbDenLuotX.Visible = true;
                ptbDenLuotO.Visible = false;
            }
            CoCaro.DanhCo(e.X, e.Y, grs);
            if (CoCaro.KiemTraChienThang())
                CoCaro.KetThucTroChoi();
            if (CheDoChoi == 2 || CheDoChoi ==3)
            {
                CoCaro.KhoiDongComputer(grs);
                if (CoCaro.KiemTraChienThang())
                    CoCaro.KetThucTroChoi();
                ptbDenLuotO.Visible = true;
            }

        }
        //------------------------------------

        // Bắt sự kiện Click cho btnUndo
        private void btnUndo_Click(object sender, EventArgs e)
        {
            CoCaro.Undo(grs);
        }
        //------------------------------

        // Bắt sự kiện Click cho btnRedo
        private void btnRedo_Click(object sender, EventArgs e)
        {
            CoCaro.Redo(grs);
        }
        //------------------------------

        // Bắt sự kiện Click cho btnNew
        private void btnNew_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            time = -1;
            ptbDenLuotO.Visible = false;
            ptbDenLuotX.Visible = false;
            grs.Clear(pnlBanco.BackColor);
            CoCaro.VeBanCo(grs);
            CoCaro.KhoiTaoMangOCo();
            if (CheDoChoi == 1)
            {
                CoCaro.StartPlayerVsPlayer(grs);
                timer1.Enabled = true;
            }  
            else if (CheDoChoi == 2)
            {
                CoCaro.StartPlayerVsCom(grs);
                timer1.Enabled = true;
                ptbDenLuotO.Visible = true;
            }
            else if (CheDoChoi == 3)
            {
                time2 = 0;
                CoCaro.StartPlayerVsCom(grs);
                timer2.Enabled = true;
                ptbDenLuotO.Visible = true;
            }
        } 
        //-----------------------------

        // Bắt sự kiện Click cho ptbNutQuayVe
        private void ptbNutQuayVe_Click(object sender, EventArgs e)
        {
            Form2 _form2 = new Form2();
            timer1.Enabled = false;
            timer2.Enabled = false;
            grs.Clear(pnlBanco.BackColor);
            this.Hide();
            _form2.ShowDialog();
        }     
        //-----------------------------------
    }
}
