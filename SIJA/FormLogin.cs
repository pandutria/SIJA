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
    public partial class FormLogin : Form
    {
        // Constructor untuk FormLogin, memanggil metode InitializeComponent
        public static string name;
        public FormLogin()
        {
            InitializeComponent(); // Inisialisasi komponen Form
        }

        // Event handler yang dipanggil saat FormLogin pertama kali diload
        private void FormLogin_Load(object sender, EventArgs e)
        {
            // Mengisi field nama dan password secara default saat form dibuka
            tbName.Text = "Purwanto";
            tbPass.Text = "Password123";
        }

        // Event handler untuk tombol Login ketika diklik
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Validasi: jika salah satu field kosong, tampilkan pesan error
            if (tbName.Text == "" || tbPass.Text == "")
            {
                MessageBox.Show("All fields must be filled");
                return;

            }

            // Membuat koneksi ke database dengan LINQ to SQL
            var db = new DataBaseDataContext();

            // Query untuk mencari user berdasarkan nama dan password
            var user = db.teachers
                         .Where(x => x.name == tbName.Text && x.password == tbPass.Text)
                         .FirstOrDefault();

            // Jika user ditemukan (tidak null)
            if (user != null)
            {
                Helper.id = user.id;
                Helper.password = user.password;
                // Tampilkan form utama (FormMain), kirimkan nama user
                new FormMain(user.name).Show();

                // Sembunyikan form login
                Hide();
            }
            else
            {
                // Tampilkan pesan error jika login gagal
                MessageBox.Show("Your data is not valid!!");

                // Kosongkan kembali inputan
                tbName.Text = "";
                tbPass.Text = "";
            }
        }
    }
}
