namespace CaroChess1._2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pnlBanco = new System.Windows.Forms.Panel();
            this.btnRedo = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.pnlOThongTin = new System.Windows.Forms.Panel();
            this.ptbDenLuotO = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.ptbDenLuotX = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbPlayer2 = new System.Windows.Forms.Label();
            this.lbPlayer1 = new System.Windows.Forms.Label();
            this.lbTime = new System.Windows.Forms.Label();
            this.lbNguoiChoi2 = new System.Windows.Forms.Label();
            this.lbNguoiChoi1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lbThongBao = new System.Windows.Forms.Label();
            this.lbMatLuot = new System.Windows.Forms.Label();
            this.ptbNutQuayVe = new System.Windows.Forms.PictureBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.pnlOThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbDenLuotO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbDenLuotX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbNutQuayVe)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBanco
            // 
            this.pnlBanco.BackColor = System.Drawing.Color.White;
            this.pnlBanco.Location = new System.Drawing.Point(284, 42);
            this.pnlBanco.Name = "pnlBanco";
            this.pnlBanco.Size = new System.Drawing.Size(501, 501);
            this.pnlBanco.TabIndex = 0;
            this.pnlBanco.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlBanco_Paint);
            this.pnlBanco.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pnlBanco_MouseClick);
            // 
            // btnRedo
            // 
            this.btnRedo.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnRedo.ForeColor = System.Drawing.Color.Maroon;
            this.btnRedo.Location = new System.Drawing.Point(186, 472);
            this.btnRedo.Name = "btnRedo";
            this.btnRedo.Size = new System.Drawing.Size(82, 55);
            this.btnRedo.TabIndex = 2;
            this.btnRedo.Text = "REDO";
            this.btnRedo.UseVisualStyleBackColor = true;
            this.btnRedo.Click += new System.EventHandler(this.btnRedo_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnUndo.ForeColor = System.Drawing.Color.Maroon;
            this.btnUndo.Location = new System.Drawing.Point(98, 472);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(82, 55);
            this.btnUndo.TabIndex = 1;
            this.btnUndo.Text = "UNDO";
            this.btnUndo.UseVisualStyleBackColor = true;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnNew.ForeColor = System.Drawing.Color.Maroon;
            this.btnNew.Location = new System.Drawing.Point(128, 409);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(111, 55);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "NEW";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // pnlOThongTin
            // 
            this.pnlOThongTin.BackColor = System.Drawing.Color.SkyBlue;
            this.pnlOThongTin.Controls.Add(this.ptbDenLuotO);
            this.pnlOThongTin.Controls.Add(this.pictureBox2);
            this.pnlOThongTin.Controls.Add(this.ptbDenLuotX);
            this.pnlOThongTin.Controls.Add(this.pictureBox1);
            this.pnlOThongTin.Controls.Add(this.lbPlayer2);
            this.pnlOThongTin.Controls.Add(this.lbPlayer1);
            this.pnlOThongTin.Controls.Add(this.lbTime);
            this.pnlOThongTin.Controls.Add(this.lbNguoiChoi2);
            this.pnlOThongTin.Controls.Add(this.lbNguoiChoi1);
            this.pnlOThongTin.Controls.Add(this.label3);
            this.pnlOThongTin.Controls.Add(this.label2);
            this.pnlOThongTin.Controls.Add(this.label1);
            this.pnlOThongTin.Location = new System.Drawing.Point(98, 85);
            this.pnlOThongTin.Name = "pnlOThongTin";
            this.pnlOThongTin.Size = new System.Drawing.Size(170, 204);
            this.pnlOThongTin.TabIndex = 2;
            // 
            // ptbDenLuotO
            // 
            this.ptbDenLuotO.Image = global::CaroChess1._2.Properties.Resources.dau_o;
            this.ptbDenLuotO.Location = new System.Drawing.Point(99, 155);
            this.ptbDenLuotO.Name = "ptbDenLuotO";
            this.ptbDenLuotO.Size = new System.Drawing.Size(39, 37);
            this.ptbDenLuotO.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbDenLuotO.TabIndex = 2;
            this.ptbDenLuotO.TabStop = false;
            this.ptbDenLuotO.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::CaroChess1._2.Properties.Resources.dau_o;
            this.pictureBox2.Location = new System.Drawing.Point(121, 110);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(39, 37);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // ptbDenLuotX
            // 
            this.ptbDenLuotX.Image = global::CaroChess1._2.Properties.Resources.dau_x;
            this.ptbDenLuotX.Location = new System.Drawing.Point(99, 155);
            this.ptbDenLuotX.Name = "ptbDenLuotX";
            this.ptbDenLuotX.Size = new System.Drawing.Size(39, 37);
            this.ptbDenLuotX.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbDenLuotX.TabIndex = 2;
            this.ptbDenLuotX.TabStop = false;
            this.ptbDenLuotX.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CaroChess1._2.Properties.Resources.dau_x;
            this.pictureBox1.Location = new System.Drawing.Point(120, 66);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(39, 37);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // lbPlayer2
            // 
            this.lbPlayer2.AutoSize = true;
            this.lbPlayer2.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbPlayer2.Location = new System.Drawing.Point(26, 117);
            this.lbPlayer2.Name = "lbPlayer2";
            this.lbPlayer2.Size = new System.Drawing.Size(90, 22);
            this.lbPlayer2.TabIndex = 1;
            this.lbPlayer2.Text = "Player 2";
            // 
            // lbPlayer1
            // 
            this.lbPlayer1.AutoSize = true;
            this.lbPlayer1.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbPlayer1.Location = new System.Drawing.Point(25, 77);
            this.lbPlayer1.Name = "lbPlayer1";
            this.lbPlayer1.Size = new System.Drawing.Size(90, 22);
            this.lbPlayer1.TabIndex = 1;
            this.lbPlayer1.Text = "Player 1";
            // 
            // lbTime
            // 
            this.lbTime.AutoSize = true;
            this.lbTime.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbTime.Location = new System.Drawing.Point(119, 12);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(20, 22);
            this.lbTime.TabIndex = 1;
            this.lbTime.Text = "0";
            // 
            // lbNguoiChoi2
            // 
            this.lbNguoiChoi2.AutoSize = true;
            this.lbNguoiChoi2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbNguoiChoi2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lbNguoiChoi2.Location = new System.Drawing.Point(16, 103);
            this.lbNguoiChoi2.Name = "lbNguoiChoi2";
            this.lbNguoiChoi2.Size = new System.Drawing.Size(0, 22);
            this.lbNguoiChoi2.TabIndex = 0;
            // 
            // lbNguoiChoi1
            // 
            this.lbNguoiChoi1.AutoSize = true;
            this.lbNguoiChoi1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbNguoiChoi1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lbNguoiChoi1.Location = new System.Drawing.Point(16, 76);
            this.lbNguoiChoi1.Name = "lbNguoiChoi1";
            this.lbNguoiChoi1.Size = new System.Drawing.Size(0, 22);
            this.lbNguoiChoi1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label3.Location = new System.Drawing.Point(4, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 22);
            this.label3.TabIndex = 0;
            this.label3.Text = "Đến lượt:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label2.Location = new System.Drawing.Point(6, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 22);
            this.label2.TabIndex = 0;
            this.label2.Text = "Người chơi:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Location = new System.Drawing.Point(4, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thời gian:";
            // 
            // timer1
            // 
            this.timer1.Interval = 800;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lbThongBao
            // 
            this.lbThongBao.AutoSize = true;
            this.lbThongBao.BackColor = System.Drawing.Color.Black;
            this.lbThongBao.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbThongBao.ForeColor = System.Drawing.Color.Red;
            this.lbThongBao.Location = new System.Drawing.Point(382, 17);
            this.lbThongBao.Name = "lbThongBao";
            this.lbThongBao.Size = new System.Drawing.Size(310, 22);
            this.lbThongBao.TabIndex = 3;
            this.lbThongBao.Text = "Bạn sắp hết thời gian suy nghĩ";
            this.lbThongBao.Visible = false;
            // 
            // lbMatLuot
            // 
            this.lbMatLuot.AutoSize = true;
            this.lbMatLuot.BackColor = System.Drawing.Color.Black;
            this.lbMatLuot.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbMatLuot.ForeColor = System.Drawing.Color.Red;
            this.lbMatLuot.Location = new System.Drawing.Point(423, 17);
            this.lbMatLuot.Name = "lbMatLuot";
            this.lbMatLuot.Size = new System.Drawing.Size(220, 22);
            this.lbMatLuot.TabIndex = 3;
            this.lbMatLuot.Text = "Bạn đã bị mất 1 lượt!";
            this.lbMatLuot.Visible = false;
            // 
            // ptbNutQuayVe
            // 
            this.ptbNutQuayVe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ptbNutQuayVe.Image = global::CaroChess1._2.Properties.Resources.Nut__Quay_Ve_1;
            this.ptbNutQuayVe.Location = new System.Drawing.Point(800, 388);
            this.ptbNutQuayVe.Name = "ptbNutQuayVe";
            this.ptbNutQuayVe.Size = new System.Drawing.Size(69, 58);
            this.ptbNutQuayVe.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbNutQuayVe.TabIndex = 4;
            this.ptbNutQuayVe.TabStop = false;
            this.ptbNutQuayVe.Click += new System.EventHandler(this.ptbNutQuayVe_Click);
            // 
            // timer2
            // 
            this.timer2.Interval = 800;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = global::CaroChess1._2.Properties.Resources.ipad_nentrong;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(888, 592);
            this.Controls.Add(this.ptbNutQuayVe);
            this.Controls.Add(this.lbMatLuot);
            this.Controls.Add(this.lbThongBao);
            this.Controls.Add(this.pnlOThongTin);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnUndo);
            this.Controls.Add(this.btnRedo);
            this.Controls.Add(this.pnlBanco);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Caro Chess";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlOThongTin.ResumeLayout(false);
            this.pnlOThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbDenLuotO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbDenLuotX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbNutQuayVe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlBanco;
        private System.Windows.Forms.Button btnRedo;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Panel pnlOThongTin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lbThongBao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbNguoiChoi2;
        private System.Windows.Forms.Label lbNguoiChoi1;
        private System.Windows.Forms.Label lbPlayer2;
        private System.Windows.Forms.Label lbPlayer1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbMatLuot;
        private System.Windows.Forms.PictureBox ptbNutQuayVe;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.PictureBox ptbDenLuotO;
        private System.Windows.Forms.PictureBox ptbDenLuotX;
        private System.Windows.Forms.Label label3;
    }
}

