namespace QuanLySach_ThuVien
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            grpThongTin = new GroupBox();
            lblMaSach = new Label();
            txtMaSach = new TextBox();
            lblTenSach = new Label();
            txtTenSach = new TextBox();
            lblGiaTien = new Label();
            txtGiaTien = new TextBox();
            pnlChucNang = new Panel();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnThoat = new Button();
            grpDanhSach = new GroupBox();
            dgvSach = new DataGridView();
            errProvider = new ErrorProvider(components);
            grpThongTin.SuspendLayout();
            pnlChucNang.SuspendLayout();
            grpDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSach).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errProvider).BeginInit();
            SuspendLayout();
            // 
            // grpThongTin
            // 
            grpThongTin.Controls.Add(lblMaSach);
            grpThongTin.Controls.Add(txtMaSach);
            grpThongTin.Controls.Add(lblTenSach);
            grpThongTin.Controls.Add(txtTenSach);
            grpThongTin.Controls.Add(lblGiaTien);
            grpThongTin.Controls.Add(txtGiaTien);
            grpThongTin.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            grpThongTin.Location = new Point(12, 12);
            grpThongTin.Name = "grpThongTin";
            grpThongTin.Size = new Size(240, 400);
            grpThongTin.TabIndex = 0;
            grpThongTin.TabStop = false;
            grpThongTin.Text = "Thông tin sách";
            // 
            // lblMaSach
            // 
            lblMaSach.AutoSize = true;
            lblMaSach.Font = new Font("Segoe UI", 10.2F);
            lblMaSach.Location = new Point(15, 40);
            lblMaSach.Name = "lblMaSach";
            lblMaSach.Size = new Size(77, 23);
            lblMaSach.TabIndex = 0;
            lblMaSach.Text = "Mã sách:";
            // 
            // txtMaSach
            // 
            txtMaSach.Location = new Point(15, 65);
            txtMaSach.MaxLength = 15;
            txtMaSach.Name = "txtMaSach";
            txtMaSach.Size = new Size(205, 34);
            txtMaSach.TabIndex = 1;
            txtMaSach.TextChanged += txtMaSach_TextChanged;
            // 
            // lblTenSach
            // 
            lblTenSach.AutoSize = true;
            lblTenSach.Font = new Font("Segoe UI", 10.2F);
            lblTenSach.Location = new Point(15, 145);
            lblTenSach.Name = "lblTenSach";
            lblTenSach.Size = new Size(79, 23);
            lblTenSach.TabIndex = 2;
            lblTenSach.Text = "Tên sách:";
            // 
            // txtTenSach
            // 
            txtTenSach.Location = new Point(15, 170);
            txtTenSach.Name = "txtTenSach";
            txtTenSach.Size = new Size(205, 34);
            txtTenSach.TabIndex = 3;
            // 
            // lblGiaTien
            // 
            lblGiaTien.AutoSize = true;
            lblGiaTien.Font = new Font("Segoe UI", 10.2F);
            lblGiaTien.Location = new Point(15, 250);
            lblGiaTien.Name = "lblGiaTien";
            lblGiaTien.Size = new Size(73, 23);
            lblGiaTien.TabIndex = 4;
            lblGiaTien.Text = "Giá tiền:";
            // 
            // txtGiaTien
            // 
            txtGiaTien.Location = new Point(15, 275);
            txtGiaTien.MaxLength = 12;
            txtGiaTien.Name = "txtGiaTien";
            txtGiaTien.Size = new Size(205, 34);
            txtGiaTien.TabIndex = 5;
            txtGiaTien.KeyPress += txtGiaTien_KeyPress;
            // 
            // pnlChucNang
            // 
            pnlChucNang.BorderStyle = BorderStyle.FixedSingle;
            pnlChucNang.Controls.Add(btnThem);
            pnlChucNang.Controls.Add(btnSua);
            pnlChucNang.Controls.Add(btnXoa);
            pnlChucNang.Controls.Add(btnThoat);
            pnlChucNang.Location = new Point(265, 18);
            pnlChucNang.Name = "pnlChucNang";
            pnlChucNang.Size = new Size(538, 58);
            pnlChucNang.TabIndex = 1;
            // 
            // btnThem
            // 
            btnThem.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnThem.ForeColor = Color.FromArgb(0, 192, 0);
            btnThem.Location = new Point(10, 10);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(118, 36);
            btnThem.TabIndex = 0;
            btnThem.Text = "➕Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnSua.ForeColor = Color.Goldenrod;
            btnSua.Location = new Point(138, 10);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(118, 36);
            btnSua.TabIndex = 1;
            btnSua.Text = "✏️Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnXoa.ForeColor = Color.FromArgb(255, 128, 0);
            btnXoa.Location = new Point(266, 10);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(118, 36);
            btnXoa.TabIndex = 2;
            btnXoa.Text = "🚮Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnThoat
            // 
            btnThoat.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnThoat.ForeColor = Color.Red;
            btnThoat.Location = new Point(394, 10);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(118, 36);
            btnThoat.TabIndex = 3;
            btnThoat.Text = "❌Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // grpDanhSach
            // 
            grpDanhSach.Controls.Add(dgvSach);
            grpDanhSach.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            grpDanhSach.Location = new Point(265, 82);
            grpDanhSach.Name = "grpDanhSach";
            grpDanhSach.Size = new Size(538, 330);
            grpDanhSach.TabIndex = 2;
            grpDanhSach.TabStop = false;
            grpDanhSach.Text = "Danh sách sách";
            // 
            // dgvSach
            // 
            dgvSach.AllowUserToAddRows = false;
            dgvSach.AllowUserToDeleteRows = false;
            dgvSach.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvSach.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSach.Location = new Point(6, 29);
            dgvSach.MultiSelect = false;
            dgvSach.Name = "dgvSach";
            dgvSach.ReadOnly = true;
            dgvSach.RowHeadersWidth = 51;
            dgvSach.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSach.Size = new Size(526, 295);
            dgvSach.TabIndex = 0;
            dgvSach.CellClick += dgvSach_CellClick;
            // 
            // errProvider
            // 
            errProvider.ContainerControl = this;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(825, 434);
            Controls.Add(grpThongTin);
            Controls.Add(pnlChucNang);
            Controls.Add(grpDanhSach);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý Sách / Thư viện - VP103";
            Load += Form1_Load;
            grpThongTin.ResumeLayout(false);
            grpThongTin.PerformLayout();
            pnlChucNang.ResumeLayout(false);
            grpDanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSach).EndInit();
            ((System.ComponentModel.ISupportInitialize)errProvider).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpThongTin;
        private Label lblMaSach;
        private TextBox txtMaSach;
        private Label lblTenSach;
        private TextBox txtTenSach;
        private Label lblGiaTien;
        private TextBox txtGiaTien;
        private Panel pnlChucNang;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnThoat;
        private GroupBox grpDanhSach;
        private DataGridView dgvSach;
        private ErrorProvider errProvider;
    }
}
