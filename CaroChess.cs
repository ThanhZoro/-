using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace CaroChess1._2
{
    #region Khai báo
    public enum KETTHUC
    {
        HoaCo,
        Player,
        Player1,
        Player2,
        COM
    }

    public class CaroChess
    {
        private KETTHUC _KetThuc;
        public static Pen pen;
        public static SolidBrush sbWhite;
        private Banco _Banco;
        private Oco[,] _MangOCo;
        private Stack<Oco> stkCacNuocDaDi;
        private Stack<Oco> stkCacNuocUndo;

        private int _LuotDi;
        public int LuotDi
        {
            set { _LuotDi = value; }
            get { return _LuotDi; }
        }

        private bool _SanSang;
        public bool SanSang
        {
            set { _SanSang = value; }
            get { return _SanSang; }
        }

        private bool _DaDanhCo;
        public bool DaDanhCo
        {
            set { _DaDanhCo = value; }
            get { return _DaDanhCo; }
        }

        private string _DenLuot;
        public string DenLuot
        {
            set { _DenLuot = value; }
            get { return _DenLuot; }
        }

        private int _LuuCheDoChoi;
        public int LuuCheDoChoi
        {
            set { _LuuCheDoChoi = value; }
            get { return _LuuCheDoChoi; }
        }

        public CaroChess()
        {
            pen = new Pen(Color.Black);
            sbWhite = new SolidBrush(Color.White);
            _Banco = new Banco(20, 20);
            _MangOCo = new Oco[_Banco.SoDong, _Banco.SoCot];
            _LuotDi = 1;
            _DaDanhCo = false;
            stkCacNuocDaDi = new Stack<Oco>();
            stkCacNuocUndo = new Stack<Oco>();

        }
    #endregion

        // Thiết kế các Chế độ chơi
        public void StartPlayerVsPlayer(Graphics g)
        {
            _SanSang = true;
            stkCacNuocDaDi = new Stack<Oco>();
            stkCacNuocUndo = new Stack<Oco>();
            _LuotDi = 1;
            KhoiTaoMangOCo();
            VeBanCo(g);
        }

        public void StartPlayerVsCom(Graphics g)
        {
            _SanSang = true;
            stkCacNuocDaDi = new Stack<Oco>();
            stkCacNuocUndo = new Stack<Oco>();
            _LuotDi = 1;
            KhoiTaoMangOCo();
            VeBanCo(g);
            KhoiDongComputer(g);
        }
        //-------------------------

        #region Vẽ bàn cờ, Đánh cờ
        // Vẽ bàn cờ
        public void VeBanCo(Graphics g)
        {
            _Banco.VeBanCo(g);
        }
        //----------

        // Khởi tạo mảng ô cờ (cấp phát vùng nhớ cho từng ô cờ)
        public void KhoiTaoMangOCo()
        {
            for (int i = 0; i < _Banco.SoDong; i++)
            {
                for (int j = 0; j < _Banco.SoCot; j++)
                {
                    _MangOCo[i, j] = new Oco(i, j, new Point(j * Oco._ChieuRong, i * Oco._ChieuCao), 0);
                }
            }
        }
        //-----------------------------------------------------

        // Đánh cờ 
        public bool DanhCo(int MouseX, int MouseY, Graphics g)
        {
            int Cot = MouseX / Oco._ChieuRong;
            int Dong = MouseY / Oco._ChieuCao;
            if (_MangOCo[Dong, Cot].SoHuu != 0)
                return false;

            switch (_LuotDi)
            {
                case 1:
                    _MangOCo[Dong, Cot].SoHuu = 1;
                    _Banco.VeQuanCo_X(g, _MangOCo[Dong, Cot].Vitri);
                    _DaDanhCo = true;
                    _LuotDi = 2;   
                    break;
                case 2:
                    _MangOCo[Dong, Cot].SoHuu = 2;
                    _Banco.VeQuanCo_O(g, _MangOCo[Dong, Cot].Vitri);
                    _DaDanhCo = true;
                    _LuotDi = 1;
                    break;
                default:
                    MessageBox.Show("Có lỗi");
                    break;
            }

            stkCacNuocUndo = new Stack<Oco>();
            Oco oco = new Oco(_MangOCo[Dong, Cot].Dong, _MangOCo[Dong, Cot].Cot, _MangOCo[Dong, Cot].Vitri, _MangOCo[Dong, Cot].SoHuu);
            stkCacNuocDaDi.Push(oco);
            return true;
        }
        //--------

        // Vẽ lại quân cờ
        public void VeLaiQuanCo(Graphics g)
        {
            foreach (Oco oco in stkCacNuocDaDi)
            {
                if (oco.SoHuu == 1)
                    _Banco.VeQuanCo_X(g, oco.Vitri);
                else if (oco.SoHuu == 2)
                    _Banco.VeQuanCo_O(g, oco.Vitri);
            }
        }
        //---------------
        #endregion

        #region Undo Redo
        public void Undo(Graphics g)
        {
            if (stkCacNuocDaDi.Count != 0)
            {
                if (_LuuCheDoChoi == 2 || _LuuCheDoChoi == 3)
                {
                    if (stkCacNuocDaDi.Count > 1)
                    {
                        Oco oco1 = stkCacNuocDaDi.Pop();
                        stkCacNuocUndo.Push(new Oco(oco1.Dong, oco1.Cot, oco1.Vitri, oco1.SoHuu));
                        _MangOCo[oco1.Dong, oco1.Cot].SoHuu = 0;
                        _Banco.XoaQuanCo(g, oco1.Vitri, sbWhite);
                        Oco oco2 = stkCacNuocDaDi.Pop();
                        stkCacNuocUndo.Push(new Oco(oco2.Dong, oco2.Cot, oco2.Vitri, oco2.SoHuu));
                        _MangOCo[oco2.Dong, oco2.Cot].SoHuu = 0;
                        _Banco.XoaQuanCo(g, oco2.Vitri, sbWhite);
                    }
                }
                else
                {
                    Oco oco = stkCacNuocDaDi.Pop();
                    stkCacNuocUndo.Push(new Oco(oco.Dong, oco.Cot, oco.Vitri, oco.SoHuu));
                    _MangOCo[oco.Dong, oco.Cot].SoHuu = 0;
                    _Banco.XoaQuanCo(g, oco.Vitri, sbWhite);
                    if (_LuotDi == 1)
                        _LuotDi = 2;
                    else if (_LuotDi == 2)
                        _LuotDi = 1;


                }
            }
        }

        public void Redo(Graphics g)
        {
            if (stkCacNuocUndo.Count != 0)
            {
                if (_LuuCheDoChoi == 2 || _LuuCheDoChoi == 3)
                {
                    Oco oco1 = stkCacNuocUndo.Pop();
                    stkCacNuocDaDi.Push(new Oco(oco1.Dong, oco1.Cot, oco1.Vitri, oco1.SoHuu));
                    Oco oco2 = stkCacNuocUndo.Pop();
                    stkCacNuocDaDi.Push(new Oco(oco2.Dong, oco2.Cot, oco2.Vitri, oco2.SoHuu));
                    _MangOCo[oco2.Dong, oco2.Cot].SoHuu = 0;
                    _MangOCo[oco1.Dong, oco1.Cot].SoHuu = 0;
                    if (oco1.SoHuu == 1)
                        _Banco.VeQuanCo_X(g, oco1.Vitri);
                    else _Banco.VeQuanCo_O(g, oco1.Vitri);
                    if (oco2.SoHuu == 1)
                        _Banco.VeQuanCo_X(g, oco2.Vitri);
                    else _Banco.VeQuanCo_O(g, oco2.Vitri);
                }
                else
                {
                    Oco oco = stkCacNuocUndo.Pop();
                    stkCacNuocDaDi.Push(new Oco(oco.Dong, oco.Cot, oco.Vitri, oco.SoHuu));
                    _MangOCo[oco.Dong, oco.Cot].SoHuu = oco.SoHuu;
                    if (oco.SoHuu == 1)
                        _Banco.VeQuanCo_X(g, oco.Vitri);
                    else _Banco.VeQuanCo_O(g, oco.Vitri);
                    if (_LuotDi == 1)
                        _LuotDi = 2;
                    else if (_LuotDi == 2)
                        _LuotDi = 1;
                }
            }
        }
        #endregion

        #region Duyệt chiến thắng
        public void KetThucTroChoi()
        {
            switch (_KetThuc)
            {
                case KETTHUC.HoaCo:
                    MessageBox.Show("Hoà cờ!");
                    break;
                case KETTHUC.Player:
                    MessageBox.Show("Player Win!!!");
                    break;
                case KETTHUC.Player1:
                    MessageBox.Show("Player 1 Win!!!");
                    break;
                case KETTHUC.Player2:
                    MessageBox.Show("Player 2 Win!!!");
                    break;
                case KETTHUC.COM:
                    MessageBox.Show("Compurter Win!!!");
                    break;
            }
            _SanSang = false;
        }

        public bool KiemTraChienThang()
        {
            if (stkCacNuocDaDi.Count == _Banco.SoDong * _Banco.SoCot)
            {
                _KetThuc = KETTHUC.HoaCo;
                return true;
            } 

            foreach (Oco oco in stkCacNuocDaDi)
            {
                if (DuyetDoc(oco.Dong, oco.Cot, oco.SoHuu) || DuyetNgang(oco.Dong, oco.Cot, oco.SoHuu) || DuyetCheoXuoi(oco.Dong, oco.Cot, oco.SoHuu) || DuyetCheoNguoc(oco.Dong, oco.Cot, oco.SoHuu))
                {
                    if (_LuuCheDoChoi == 1)
                    {
                        _KetThuc = oco.SoHuu == 1 ? KETTHUC.Player1 : KETTHUC.Player2;
                    }
                    else _KetThuc = oco.SoHuu == 1 ? KETTHUC.COM : KETTHUC.Player;
                    return true;
                }
            }
            return false;
        }

        private bool DuyetDoc(int currDong, int currCot, int currSoHuu)
        {
            if (currDong > _Banco.SoDong - 5)
                return false;
            int Dem;
            for (Dem = 1; Dem < 5; Dem++)
            {
                if (_MangOCo[currDong + Dem, currCot].SoHuu != currSoHuu)
                    return false;
            }
            if (currDong == 0 || currDong + Dem == _Banco.SoDong)
                return true;
            if (_MangOCo[currDong - 1, currCot].SoHuu == 0 || _MangOCo[currDong + Dem, currCot].SoHuu == 0)
                return true;

            return false;

        }

        private bool DuyetNgang(int currDong, int currCot, int currSoHuu)
        {
            if (currCot > _Banco.SoCot - 5)
                return false;
            int Dem;
            for (Dem = 1; Dem < 5; Dem++)
            {
                if (_MangOCo[currDong, currCot + Dem].SoHuu != currSoHuu)
                    return false;
            }
            if (currCot == 0 || currCot + Dem == _Banco.SoCot)
                return true;
            if (_MangOCo[currDong, currCot - 1].SoHuu == 0 || _MangOCo[currDong, currCot + Dem].SoHuu == 0)
                return true;

            return false;

        }

        private bool DuyetCheoXuoi(int currDong, int currCot, int currSoHuu)
        {
            if (currDong > _Banco.SoDong - 5 || currCot > _Banco.SoCot - 5)
                return false;
            int Dem;
            for (Dem = 1; Dem < 5; Dem++)
            {
                if (_MangOCo[currDong + Dem, currCot + Dem].SoHuu != currSoHuu)
                    return false;
            }
            if (currDong == 0 || currDong + Dem == _Banco.SoDong || currCot == 0 || currCot + Dem == _Banco.SoCot)
                return true;
            if (_MangOCo[currDong - 1, currCot - 1].SoHuu == 0 || _MangOCo[currDong + Dem, currCot + Dem].SoHuu == 0)
                return true;

            return false;

        }

        private bool DuyetCheoNguoc(int currDong, int currCot, int currSoHuu)
        {
            if (currDong < 4 || currCot > _Banco.SoCot - 5)
                return false;
            int Dem;
            for (Dem = 1; Dem < 5; Dem++)
            {
                if (_MangOCo[currDong - Dem, currCot + Dem].SoHuu != currSoHuu)
                    return false;
            }
            if (currDong == 4 || currDong == _Banco.SoDong - 1 || currCot == 0 || currCot + Dem == _Banco.SoCot)
                return true;
            if (_MangOCo[currDong + 1, currCot - 1].SoHuu == 0 || _MangOCo[currDong - Dem, currCot + Dem].SoHuu == 0)
                return true;

            return false;

        }

        #endregion

        #region AI
        private long[] MangDiemTanCong = new long[7] { 0, 3, 24, 192, 1536, 12288, 98304 };
        private long[] MangDiemPhongNgu = new long[7] { 0, 9, 54, 162, 1458, 13112, 118008 };

        public void KhoiDongComputer(Graphics g)
        {
            if (_LuotDi == 1)
            {
                if (stkCacNuocDaDi.Count == 0)
                {
                    DanhCo(_Banco.SoCot / 2 * Oco._ChieuRong + 1, _Banco.SoDong / 2 * Oco._ChieuCao + 1, g);
                    _DaDanhCo = true;
                }
                else
                {
                    Oco oco = TimKiemNuocDi();
                    DanhCo(oco.Vitri.X + 1, oco.Vitri.Y + 1, g);
                    _DaDanhCo = true;
                }
            }
        }

        private Oco TimKiemNuocDi()
        {
            Oco ocoResult = new Oco();
            long DiemMax = 0;
            for (int i = 0; i < _Banco.SoDong; i++)
            {
                for (int j = 0; j < _Banco.SoCot; j++)
                {
                    if (_MangOCo[i, j].SoHuu == 0)
                    {
                        long DiemTanCong = DiemTanCong_DuyetDoc(i, j) + DiemTanCong_DuyetNgang(i, j) + DiemTanCong_DuyetCheoXuoi(i, j) + DiemTanCong_DuyetCheoNguoc(i, j);
                        long DiemPhongNgu = DiemPhongNgu_DuyetDoc(i, j) + DiemPhongNgu_DuyetNgang(i, j) + DiemPhongNgu_DuyetCheoXuoi(i, j) + DiemPhongNgu_DuyetCheoNguoc(i, j);
                        long DiemTam = DiemTanCong > DiemPhongNgu ? DiemTanCong : DiemPhongNgu;
                        if (DiemMax < DiemTam)
                        {
                            DiemMax = DiemTam;
                            ocoResult = new Oco(_MangOCo[i, j].Dong, _MangOCo[i, j].Cot, _MangOCo[i, j].Vitri, _MangOCo[i, j].SoHuu);
                        }
                    }
                }
            }

            return ocoResult;
        }

        #region TanCong
        private long DiemTanCong_DuyetDoc(int currDong, int currCot)
        {
            long DiemTong = 0;
            int SoQuanTa = 0;
            int SoQuanDich = 0;
            for (int Dem = 1; Dem < 6 && currDong + Dem < _Banco.SoDong; Dem++)
            {
                if (_MangOCo[currDong + Dem, currCot].SoHuu == 1)
                    SoQuanTa++;
                else if (_MangOCo[currDong + Dem, currCot].SoHuu == 2)
                {
                    SoQuanDich++;
                    break;
                }
                else break;
            }

            for (int Dem = 1; Dem < 6 && currDong - Dem >= 0; Dem++)
            {
                if (_MangOCo[currDong - Dem, currCot].SoHuu == 1)
                    SoQuanTa++;
                else if (_MangOCo[currDong - Dem, currCot].SoHuu == 2)
                {
                    SoQuanDich++;
                    break;
                }
                else break;
            }
            if (SoQuanDich == 2)
                return 0;
            DiemTong -= MangDiemPhongNgu[SoQuanDich + 1];
            DiemTong += MangDiemTanCong[SoQuanTa];
            return DiemTong;
        }

        private long DiemTanCong_DuyetNgang(int currDong, int currCot)
        {
            long DiemTong = 0;
            int SoQuanTa = 0;
            int SoQuanDich = 0;
            for (int Dem = 1; Dem < 6 && currCot + Dem < _Banco.SoCot; Dem++)
            {
                if (_MangOCo[currDong, currCot + Dem].SoHuu == 1)
                    SoQuanTa++;
                else if (_MangOCo[currDong, currCot + Dem].SoHuu == 2)
                {
                    SoQuanDich++;
                    break;
                }
                else break;
            }

            for (int Dem = 1; Dem < 6 && currCot - Dem >= 0; Dem++)
            {
                if (_MangOCo[currDong, currCot - Dem].SoHuu == 1)
                    SoQuanTa++;
                else if (_MangOCo[currDong, currCot - Dem].SoHuu == 2)
                {
                    SoQuanDich++;
                    break;
                }
                else break;
            }
            if (SoQuanDich == 2)
                return 0;
            DiemTong -= MangDiemPhongNgu[SoQuanDich + 1];
            DiemTong += MangDiemTanCong[SoQuanTa];
            return DiemTong;
        }

        private long DiemTanCong_DuyetCheoXuoi(int currDong, int currCot)
        {
            long DiemTong = 0;
            int SoQuanTa = 0;
            int SoQuanDich = 0;
            for (int Dem = 1; Dem < 6 && currCot + Dem < _Banco.SoCot && currDong + Dem < _Banco.SoDong; Dem++)
            {
                if (_MangOCo[currDong + Dem, currCot + Dem].SoHuu == 1)
                    SoQuanTa++;
                else if (_MangOCo[currDong + Dem, currCot + Dem].SoHuu == 2)
                {
                    SoQuanDich++;
                    break;
                }
                else break;
            }

            for (int Dem = 1; Dem < 6 && currCot - Dem >= 0 && currDong - Dem >= 0; Dem++)
            {
                if (_MangOCo[currDong - Dem, currCot - Dem].SoHuu == 1)
                    SoQuanTa++;
                else if (_MangOCo[currDong - Dem, currCot - Dem].SoHuu == 2)
                {
                    SoQuanDich++;
                    break;
                }
                else break;
            }
            if (SoQuanDich == 2)
                return 0;
            DiemTong -= MangDiemPhongNgu[SoQuanDich + 1];
            DiemTong += MangDiemTanCong[SoQuanTa];
            return DiemTong;
        }

        private long DiemTanCong_DuyetCheoNguoc(int currDong, int currCot)
        {
            long DiemTong = 0;
            int SoQuanTa = 0;
            int SoQuanDich = 0;
            for (int Dem = 1; Dem < 6 && currCot + Dem < _Banco.SoCot && currDong - Dem >= 0; Dem++)
            {
                if (_MangOCo[currDong - Dem, currCot + Dem].SoHuu == 1)
                    SoQuanTa++;
                else if (_MangOCo[currDong - Dem, currCot + Dem].SoHuu == 2)
                {
                    SoQuanDich++;
                    break;
                }
                else break;
            }

            for (int Dem = 1; Dem < 6 && currCot - Dem >= 0 && currDong + Dem < _Banco.SoDong; Dem++)
            {
                if (_MangOCo[currDong + Dem, currCot - Dem].SoHuu == 1)
                    SoQuanTa++;
                else if (_MangOCo[currDong + Dem, currCot - Dem].SoHuu == 2)
                {
                    SoQuanDich++;
                    break;
                }
                else break;
            }
            if (SoQuanDich == 2)
                return 0;
            DiemTong -= MangDiemPhongNgu[SoQuanDich + 1];
            DiemTong += MangDiemTanCong[SoQuanTa];
            return DiemTong;
        }
        #endregion

        #region Phong Ngu
        private long DiemPhongNgu_DuyetDoc(int currDong, int currCot)
        {
            long DiemTong = 0;
            int SoQuanTa = 0;
            int SoQuanDich = 0;
            for (int Dem = 1; Dem < 6 && currDong + Dem < _Banco.SoDong; Dem++)
            {
                if (_MangOCo[currDong + Dem, currCot].SoHuu == 1)
                {
                    SoQuanTa++;
                    break;
                }
                else if (_MangOCo[currDong + Dem, currCot].SoHuu == 2)
                {
                    SoQuanDich++;
                }
                else break;
            }

            for (int Dem = 1; Dem < 6 && currDong - Dem >= 0; Dem++)
            {
                if (_MangOCo[currDong - Dem, currCot].SoHuu == 1)
                {
                    SoQuanTa++;
                    break;
                }
                else if (_MangOCo[currDong - Dem, currCot].SoHuu == 2)
                {
                    SoQuanDich++;
                }
                else break;
            }
            if (SoQuanTa == 2)
                return 0;
            DiemTong += MangDiemPhongNgu[SoQuanDich];
            return DiemTong;
        }

        private long DiemPhongNgu_DuyetNgang(int currDong, int currCot)
        {
            long DiemTong = 0;
            int SoQuanTa = 0;
            int SoQuanDich = 0;
            for (int Dem = 1; Dem < 6 && currCot + Dem < _Banco.SoCot; Dem++)
            {
                if (_MangOCo[currDong, currCot + Dem].SoHuu == 1)
                {
                    SoQuanTa++;
                    break;
                }
                else if (_MangOCo[currDong, currCot + Dem].SoHuu == 2)
                {
                    SoQuanDich++;
                }
                else break;
            }

            for (int Dem = 1; Dem < 6 && currCot - Dem >= 0; Dem++)
            {
                if (_MangOCo[currDong, currCot - Dem].SoHuu == 1)
                {
                    SoQuanTa++;
                    break;
                }
                else if (_MangOCo[currDong, currCot - Dem].SoHuu == 2)
                {
                    SoQuanDich++;
                }
                else break;
            }
            if (SoQuanTa == 2)
                return 0;
            DiemTong += MangDiemPhongNgu[SoQuanDich];
            return DiemTong;
        }

        private long DiemPhongNgu_DuyetCheoXuoi(int currDong, int currCot)
        {
            long DiemTong = 0;
            int SoQuanTa = 0;
            int SoQuanDich = 0;
            for (int Dem = 1; Dem < 6 && currCot + Dem < _Banco.SoCot && currDong + Dem < _Banco.SoDong; Dem++)
            {
                if (_MangOCo[currDong + Dem, currCot + Dem].SoHuu == 1)
                {
                    SoQuanTa++;
                    break;
                }
                else if (_MangOCo[currDong + Dem, currCot + Dem].SoHuu == 2)
                {
                    SoQuanDich++;
                }
                else break;
            }

            for (int Dem = 1; Dem < 6 && currCot - Dem >= 0 && currDong - Dem >= 0; Dem++)
            {
                if (_MangOCo[currDong - Dem, currCot - Dem].SoHuu == 1)
                {
                    SoQuanTa++;
                    break;
                }
                else if (_MangOCo[currDong - Dem, currCot - Dem].SoHuu == 2)
                {
                    SoQuanDich++;
                }
                else break;
            }
            if (SoQuanTa == 2)
                return 0;
            DiemTong += MangDiemPhongNgu[SoQuanDich];
            return DiemTong;
        }

        private long DiemPhongNgu_DuyetCheoNguoc(int currDong, int currCot)
        {
            long DiemTong = 0;
            int SoQuanTa = 0;
            int SoQuanDich = 0;
            for (int Dem = 1; Dem < 6 && currCot + Dem < _Banco.SoCot && currDong - Dem >= 0; Dem++)
            {
                if (_MangOCo[currDong - Dem, currCot + Dem].SoHuu == 1)
                {
                    SoQuanTa++;
                    break;
                }
                else if (_MangOCo[currDong - Dem, currCot + Dem].SoHuu == 2)
                {
                    SoQuanDich++;
                }
                else break;
            }

            for (int Dem = 1; Dem < 6 && currCot - Dem >= 0 && currDong + Dem < _Banco.SoDong; Dem++)
            {
                if (_MangOCo[currDong + Dem, currCot - Dem].SoHuu == 1)
                {
                    SoQuanTa++;
                    break;
                }
                else if (_MangOCo[currDong + Dem, currCot - Dem].SoHuu == 2)
                {
                    SoQuanDich++;
                }
                else break;
            }
            if (SoQuanTa == 2)
                return 0;
            DiemTong += MangDiemPhongNgu[SoQuanDich];
            return DiemTong;
        }
        #endregion

        #endregion
    }
}
