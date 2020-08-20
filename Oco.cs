using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace CaroChess1._2
{
    public class Oco
    {
        public const int _ChieuRong = 25;
        public const int _ChieuCao = 25;

        private int _Dong;
        public int Dong
        {
            set { _Dong = value; }
            get { return _Dong; }
        }

        private int _Cot;
        public int Cot
        {
            set { _Cot = value; }
            get { return _Cot; }
        }

        private Point _Vitri;
        public Point Vitri
        {
            set { _Vitri = value; }
            get { return _Vitri; }
        }

        private int _SoHuu;
        public int SoHuu
        {
            set { _SoHuu = value; }
            get { return _SoHuu; }
        }

        public Oco()
        { }

        public Oco(int dong, int cot, Point vitri, int sohuu)
        {
            _Dong = dong;
            _Cot = cot;
            _Vitri = vitri;
            _SoHuu = sohuu;
        }
    }
}
