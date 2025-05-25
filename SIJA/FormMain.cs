using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIJA
{
    public partial class FormMain : Form
    {
        // Variabel untuk menyimpan nama pengguna yang login
        string name;

        // Constructor FormMain menerima parameter name dan menyimpannya ke variabel lokal
        public FormMain(string name)
        {
            InitializeComponent(); // Inisialisasi komponen UI
            this.name = name; // Simpan nama ke variabel instance
        }

        // Event handler saat FormMain diload
        private void FormMain_Load(object sender, EventArgs e)
        {
            // Tampilkan ucapan selamat datang dengan nama pengguna
            lblName.Text = $"Welcome, {name}!";
        }

        // Event handler untuk tombol Logout
        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Tampilkan kembali FormLogin dan sembunyikan FormMain
            new FormLogin().Show();
            Hide();
        }

        // Event handler untuk tombol "Master Teacher"
        private void btnMasterSteacher_Click(object sender, EventArgs e)
        {
            // Buka FormMasterTeacher dan sembunyikan FormMain
            new FormMasterTeacher().Show();
            Hide();
        }

        // Event handler untuk tombol "Master Student"
        private void btnMasterStudent_Click(object sender, EventArgs e)
        {
            // Buka FormMasterStudent dan sembunyikan FormMain
            new FormMasterStudent().Show();
            Hide();
        }
    }
}
