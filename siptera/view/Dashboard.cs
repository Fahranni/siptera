using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using siptera.koneksi;

namespace siptera.view
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();

            // Setting ukuran Form
            this.Text = "Dashboard";
            this.Size = new Size(1280, 720);//ukuran window
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.WhiteSmoke;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Font = new Font("Century Gothic", 10);


            //Top Bar = HEADER
            Panel topBar = new Panel()
            {
                BackColor = Color.Blue,
                Location = new Point(0, 0),
                Size = new Size(this.Width, 60)
            };
            this.Controls.Add(topBar);
            topBar.SendToBack();

            Label lblUser = new Label()
            {
                Text = "Login sebagai: Admin",
                ForeColor = Color.White,
                Font = new Font("Century Gothic", 10, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(this.Width - 670, 20) // posisi
            };
            topBar.Controls.Add(lblUser);//menambah label user ke panel topbar

            Label dashboardLabel = new Label()
            {
                Text = "DASHBOARD",
                ForeColor = Color.White,
                Font = new Font("Century Gothic", 16, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(240, 15)// margin
            };
            topBar.Controls.Add(dashboardLabel);//tambahin label dashboar ke top bar


            //Main Content = halaman utama
            Panel mainContent = new Panel()
            {
                Dock = DockStyle.Fill,//menyesuaikan halaman kosong
                BackColor = Color.WhiteSmoke,
                AutoScroll = true,
                Padding = new Padding(250, 50, 50, 50)//padding margin
            };
            this.Controls.Add(mainContent);


            TableLayoutPanel layout = new TableLayoutPanel()//tata letak card
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                ColumnCount = 1,
                RowCount = 3
            };
            mainContent.Controls.Add(layout);

            Label lblHeader = new Label()
            {
                Text = "Selamat Datang di Dashboard SIPTERA",
                Font = new Font("Century Gothic", 20, FontStyle.Bold),
                AutoSize = true,
                Margin = new Padding(0, 10, 0, 5),
                Anchor = AnchorStyles.Top,
                TextAlign = ContentAlignment.MiddleCenter
            };
            layout.Controls.Add(lblHeader);


            Label lblUpdate = new Label()// label waktu
            {
                Text = $"Data terakhir diperbarui: {DateTime.Now:dd MMMM yyyy, HH:mm} WIB",
                Font = new Font("Century Gothic", 10),
                AutoSize = true,//label menyesuaikan panjang teks
                ForeColor = Color.Gray,
                Margin = new Padding(0, 0, 0, 20),
                Anchor = AnchorStyles.Top,
                TextAlign = ContentAlignment.MiddleCenter
            };
            layout.Controls.Add(lblUpdate);


            //card jumlah data
            FlowLayoutPanel cardContainer = new FlowLayoutPanel()//membuat panel untuk card
            {
                Dock = DockStyle.Fill,
                AutoSize = true,
                FlowDirection = FlowDirection.LeftToRight,//menyusun panel dari kiri ke kanan
                WrapContents = true,
                Padding = new Padding(10),
                Margin = new Padding(0, 0, 0, 20)
            };
            layout.Controls.Add(cardContainer);


            //tampilin data
            var statList = new (string Title, int Value, Color ColorText, Color CircleColor, Color CardBackColor)[]
            {
                ("Total Penduduk", GetJumlahPenduduk(), Color.FromArgb(13, 110, 253), Color.FromArgb(222, 235, 255), Color.White),
                ("Total Keluarga", GetJumlahKeluarga(), Color.FromArgb(25, 135, 84), Color.FromArgb(209, 231, 221), Color.White),
                ("Total Anggota Keluarga", GetJumlahAnggotaKeluarga(), Color.FromArgb(13, 202, 240), Color.FromArgb(207, 239, 247), Color.White),
                ("Total Pengajuan", GetJumlahPengajuan(), Color.FromArgb(255, 193, 7), Color.FromArgb(255, 243, 205), Color.White),
                ("Jumlah Pekerjaan Tercatat", GetJumlahPekerjaan(), Color.FromArgb(220, 53, 69), Color.FromArgb(248, 215, 218), Color.White)
            };


            // loop buat card
            foreach (var stat in statList)
            {
                Panel card = new Panel()
                {
                    Size = new Size(300, 110),
                    Margin = new Padding(10),
                    BackColor = stat.CardBackColor,
                   // BorderStyle = BorderStyle.FixedSingle
                    Cursor = Cursors.Hand
                };
                card.Paint += (s, e) =>//menggambar ulang tampilan
                {
                    int radius = 12;//seberapa melengkung sudutnya
                    var rect = new Rectangle(0, 0, card.Width - 1, card.Height - 1);//buat kotak area

                    using (GraphicsPath path = new GraphicsPath())
                    {
                        //sudut sudut melengkung dikeempat pojok panel
                        path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
                        path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
                        path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
                        path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
                        path.CloseFigure();

                        // Apply region supaya sudut panel tetap melengkung
                        card.Region = new Region(path);

                        // Gambar border hitam halus di seluruh sisi
                        using (Pen borderPen = new Pen(Color.Transparent, 1))
                        {
                            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                            e.Graphics.DrawPath(borderPen, path);//garis pinggir panel
                        }
                    }
                };



                Label lblTitle = new Label()//label buat judul card
                {
                    Text = stat.Title,
                    Font = new Font("Century Gothic", 10, FontStyle.Regular),
                    Location = new Point(15, 10),
                    AutoSize = true,
                    Cursor = Cursors.Hand
                };

                Panel circle = new Panel() //buat panel lingkaran
                {
                    Size = new Size(60, 60),
                    Location = new Point(15, 40), // posisi kiri
                    BackColor = stat.CircleColor,//warna berdasarkan stat.circlecolor
                    Cursor = Cursors.Hand
                };

                circle.Paint += (s, e) =>
                {
                    System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
                    path.AddEllipse(0, 0, circle.Width - 1, circle.Height - 1);
                    circle.Region = new Region(path);
                };//lingkaran pakai region


                Label lblValue = new Label()//menampilkan angka card
                {
                    Text = stat.Value.ToString("N0"),
                    Font = new Font("Century Gothic", 16, FontStyle.Bold),
                    ForeColor = stat.ColorText,
                    AutoSize = false,
                    Size = new Size(60, 60),
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Cursor = Cursors.Hand
                };

                circle.Controls.Add(lblValue);//menaruh label value(angka) dalam lingkaran
                card.Cursor = Cursors.Hand;
                card.Controls.Add(lblTitle);//Menambah judul ke dalam card
                card.Controls.Add(circle);//menambah lingkaran ke card
              //  card.Controls.Add(lblValue);
                
                cardContainer.Controls.Add(card);//menambahkan card ke panel container

                //jika card diklik akan membuka halaman
                card.Click += (s, e) => OpenFormByTitle(stat.Title);
                lblTitle.Click += (s, e) => OpenFormByTitle(stat.Title);
                circle.Click += (s, e) => OpenFormByTitle(stat.Title);
                
                lblValue.Click += (s, e) => OpenFormByTitle(stat.Title);

            }

            //Panel Sidebar
            Panel sidebar = new Panel()
            {
                BackColor = Color.Black,
                Dock = DockStyle.Left,
                Width = 220
            };
            


            // Logo SIPTERA
            PictureBox logo = new PictureBox()
            {
                Size = new Size(160, 80),
                Location = new Point(20, 20),
                SizeMode = PictureBoxSizeMode.Zoom,
                Image = Properties.Resources.log// nama file logo
            };
            sidebar.Controls.Add(logo);//masukan logo ke panel sidebar

            string[] menuItems = { "Dashboard", "Penduduk", "Pekerjaan", "Keluarga", "Anggota Keluarga", "Pengajuan", "Logout" };

            Image[] icons = {// ambil dari resource
                Properties.Resources.homee,
                Properties.Resources.penduduk,
                Properties.Resources.pekerjaan,
                Properties.Resources.keluarga,
                Properties.Resources.anggota_keluarga,
                Properties.Resources.pengajuan,
                Properties.Resources.logout
            };

            int yOffset = 120;//jarak vertikal dari atas ke tombol utama
            for (int i = 0; i < menuItems.Length; i++)//membuat menu sebanyak array menuItems
            {
                string menuText = menuItems[i];//ambil berdasarkan urutan
                Image icon = icons[i];


                Button btn = new Button()
                {
                    Text = "   " + menuItems[i],//jarak icon ke teks
                    Image = new Bitmap(icons[i], new Size(24, 24)),// ukuran icon
                    ImageAlign = ContentAlignment.MiddleLeft,//icon rata kiri
                    TextAlign = ContentAlignment.MiddleLeft,//teks rata kiri
                    TextImageRelation = TextImageRelation.ImageBeforeText,//icon sebelum teks
                    Padding = new Padding(5, 0, 0, 0),//spasi antara ikun dan teks
                    ForeColor = Color.White,//warna teks
                    FlatStyle = FlatStyle.Flat,//gaya tombol
                    BackColor = Color.Transparent,
                    Width = 200,
                    Height = 45,
                    Location = new Point(10, yOffset),//posisi tombol
                    Font = new Font("Century Gothic", 10, FontStyle.Bold),
                    Cursor = Cursors.Hand
                };

                btn.FlatAppearance.BorderSize = 0;//hilangkan border tombol

                //hover tombol
                btn.MouseEnter += (s, e) => btn.BackColor = Color.FromArgb(33, 37, 41);
                btn.MouseLeave += (s, e) => btn.BackColor = Color.Transparent;


                // Klik sidebar
                btn.Click += (s, e) =>
                {
                    if (menuText == "Pengajuan")
                    {
                        LihatPengajuan pengajuan = new LihatPengajuan();
                        pengajuan.Show();
                        this.Close();
                    }
                    else if (menuText == "Logout")
                    {
                        Login_frm login = new Login_frm();
                        login.Show();
                        this.Close();
                    }
                    else if (menuText == "Penduduk")
                    {
                        string admin = "";
                        Penduduk_frm penduduk = new Penduduk_frm(admin);
                        penduduk.Show();
                        this.Close();

                    }
                    else if (menuText == "Pekerjaan")
                    {
                        pekerjaan pekerjaan = new pekerjaan();
                        pekerjaan.Show();
                        this.Close();

                    }
                    else if (menuText == "Keluarga")
                    {
                        keluarga keluarga = new keluarga();
                        keluarga.Show();
                        this.Close();

                    }
                    else if (menuText == "Anggota Keluarga")
                    {
                        AnggotaKeluarga_frm ang_keluarga = new AnggotaKeluarga_frm();
                        ang_keluarga.Show();
                        this.Close();
                    }
                };

                sidebar.Controls.Add(btn);
                yOffset += 50;// jarak tombol
            }

            
            this.Controls.Add(sidebar);
            sidebar.BringToFront();
        }

        //Ambil data dari database
        private int GetJumlahPenduduk()
        {
            KonekServer_cls koneksi = new KonekServer_cls();
            DataTable dt = koneksi.eksekusiQuery("SELECT COUNT(*) AS jumlah FROM penduduk");//query ini akan mencari umlah data lalu data disimpan ke DataTable bernama dt
            return dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0]["jumlah"]) : 0;//kalau aka return sebagai int agar hasil berypa angka
        }

        private int GetJumlahKeluarga()
        {
            KonekServer_cls koneksi = new KonekServer_cls();
            DataTable dt = koneksi.eksekusiQuery("SELECT COUNT(*) AS jumlah FROM keluarga");
            return dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0]["jumlah"]) : 0;
        }

        private int GetJumlahPengajuan()
        {
            KonekServer_cls koneksi = new KonekServer_cls();
            DataTable dt = koneksi.eksekusiQuery("SELECT COUNT(*) AS jumlah FROM pengajuan_perubahan");
            return dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0]["jumlah"]) : 0;
        }

        private int GetJumlahAnggotaKeluarga()
        {
            KonekServer_cls koneksi = new KonekServer_cls();
            DataTable dt = koneksi.eksekusiQuery("SELECT COUNT(*) AS jumlah FROM anggota_keluarga");
            return dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0]["jumlah"]) : 0;
        }

        private int GetJumlahPekerjaan()
        {
            KonekServer_cls koneksi = new KonekServer_cls();
            DataTable dt = koneksi.eksekusiQuery("SELECT COUNT(*) AS jumlah FROM pekerjaan");
            return dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0]["jumlah"]) : 0;
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            
        }

        private void OpenFormByTitle(string title)//membuka form berdasarkan judul
        {
            Form formToOpen = null;

            switch (title)
            {
                case "Total Penduduk":
                    formToOpen = new Penduduk_frm("");
                    break;
                case "Total Keluarga":
                    formToOpen = new keluarga();
                    break;
                case "Total Anggota Keluarga":
                    formToOpen = new AnggotaKeluarga_frm();
                    break;
                case "Total Pengajuan":
                    formToOpen = new LihatPengajuan();
                    break;
                case "Jumlah Pekerjaan Tercatat":
                    formToOpen = new pekerjaan();
                    break;
                default:
                    MessageBox.Show("Form belum tersedia untuk: " + title);
                    return;
            }

            formToOpen.Show();//menampilkan form baru
            this.Close();
        }

    }
}
