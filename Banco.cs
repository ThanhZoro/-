using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace CaroChess1._2
{
    public class Banco
    {
        #region Khai báo
        private int _SoDong;
        public int SoDong
        {
            get { return _SoDong; }
        }

        private int _SoCot;
        public int SoCot
        {
            get { return _SoCot; }
        }

        public Banco()
        {
            _SoDong = 0;
            _SoCot = 0;
        }

        public Banco(int SoDong, int SoCot)
        {
            _SoDong = SoDong;
            _SoCot = SoCot;
        }

        private CaroChess _carochess;
        #endregion

        // Vẽ bàn cờ
        public void VeBanCo(Graphics g)
        {
            for (int i = 0; i <= _SoCot; i++)
            {
                g.DrawLine(CaroChess.pen, i * Oco._ChieuRong, 0, i * Oco._ChieuRong, _SoDong * Oco._ChieuCao);
            }
            for (int j = 0; j <= _SoDong; j++)
            {
                g.DrawLine(CaroChess.pen, 0, j * Oco._ChieuCao, _SoCot * Oco._ChieuRong, j * Oco._ChieuCao);
            }
        }
        //----------

        // Vẽ quân cờ
        public void VeQuanCo_X(Graphics g, Point point)
        {
            Bitmap bm = new Bitmap(Properties.Resources.dau_x);
            g.DrawImage(bm, point.X + 1, point.Y + 1, Oco._ChieuRong - 3, Oco._ChieuCao - 3);
        }

        public void VeQuanCo_O(Graphics g, Point point)
        {
            Bitmap bm = new Bitmap(Properties.Resources.dau_o);
            g.DrawImage(bm, point.X + 1, point.Y + 1, Oco._ChieuRong - 3, Oco._ChieuCao - 3);
        }
        //-----------

        // Xoá quân cờ
        public void XoaQuanCo(Graphics g, Point point, SolidBrush sb)
        {
            g.FillRectangle(sb, point.X + 1, point.Y + 1, Oco._ChieuRong - 2, Oco._ChieuCao - 2);
        }
        //------------
    }
}
