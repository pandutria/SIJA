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
    public partial class FormMasterTeacher : Form
    {
        DataBaseDataContext db = new DataBaseDataContext(); // Koneksi ke database menggunakan LINQ to SQL
        int selected_id = -1; // Menyimpan ID guru yang sedang dipilih

        public FormMasterTeacher()
        {
            InitializeComponent(); // Inisialisasi komponen form
        }

        // Method untuk menampilkan pilihan gender di ComboBox
        void showDataCbo()
        {
            var data = new List<string>(); // List untuk menyimpan data gender
            data.Add("Male");
            data.Add("Female");

            cboGender.DataSource = data; // Menampilkan data ke ComboBox
        }

        // Method untuk menampilkan data guru di DataGridView
        void showData()
        {
            dgvData.Columns.Clear(); // Menghapus semua kolom sebelumnya untuk mencegah duplikasi

            // Mengambil data guru dari database yang namanya mengandung teks dari TextBox pencarian
            var teacher = db.teachers.Where(x => x.name.Contains(tbSearch.Text))
                .Select(x => new {
                    x.id,
                    x.name,
                    x.gender,
                    x.address,
                    x.phone,
                    x.subject,
                    x.password
                });

            dgvData.DataSource = teacher; // Menampilkan data ke DataGridView
        }

        // Event handler ketika form pertama kali dimuat
        private void FormMasterTeacher_Load(object sender, EventArgs e)
        {
            showData(); // Menampilkan data guru ke DataGridView
            showDataCbo(); // Menampilkan pilihan gender ke ComboBox
        }

        // Event handler ketika teks di TextBox pencarian berubah
        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            showData(); // Memperbarui tampilan data sesuai pencarian
        }

        // Method untuk mengosongkan semua inputan
        void clearFields()
        {
            tbName.Text = "";
            tbAddress.Text = "";
            tbPhone.Text = "";
            tbSubject.Text = "";
            tbPassword.Text = "";
            cboGender.Text = "Male"; // Set default ke Male
        }

        // Event handler untuk tombol Insert (Tambah)
        private void btnInsert_Click(object sender, EventArgs e)
        {
            // Validasi semua input harus diisi
            if (tbName.Text == "" || tbAddress.Text == "" || tbPhone.Text == ""
                || tbSubject.Text == "" || tbPassword.Text == "")
            {
                MessageBox.Show("All fields must be filled"); // Tampilkan pesan jika input kosong
                return;
            }

            var teacher = new teacher(); // Membuat objek guru baru
            teacher.name = tbName.Text; // Mengisi properti guru
            teacher.address = tbAddress.Text;
            teacher.phone = tbPhone.Text;
            teacher.subject = tbSubject.Text;
            teacher.password = tbPassword.Text;
            teacher.gender = cboGender.Text;

            db.teachers.InsertOnSubmit(teacher); // Menambahkan guru ke database
            db.SubmitChanges(); // Menyimpan perubahan ke database
            clearFields(); // Mengosongkan inputan
            showData(); // Menampilkan ulang data
            MessageBox.Show("Data successfully added"); // Notifikasi berhasil
            selected_id = -1; // Reset ID terpilih
        }

        // Event handler saat salah satu baris DataGridView diklik
        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Pastikan klik pada baris yang valid
            {
                // Ambil data dari baris yang diklik dan tampilkan ke inputan
                selected_id = (int)dgvData.Rows[e.RowIndex].Cells["id"].Value;
                tbName.Text = dgvData.Rows[e.RowIndex].Cells["name"].Value.ToString();
                tbAddress.Text = dgvData.Rows[e.RowIndex].Cells["address"].Value.ToString();
                tbPhone.Text = dgvData.Rows[e.RowIndex].Cells["phone"].Value.ToString();
                tbSubject.Text = dgvData.Rows[e.RowIndex].Cells["subject"].Value.ToString();
                tbPassword.Text = dgvData.Rows[e.RowIndex].Cells["password"].Value.ToString();
                cboGender.Text = dgvData.Rows[e.RowIndex].Cells["gender"].Value.ToString();
            }
        }

        // Event handler untuk tombol Update (Perbarui data guru)
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selected_id == -1)
            {
                MessageBox.Show("Please select a row to update"); // Jika belum ada yang dipilih
                return;
            }

            // Validasi semua input harus diisi
            if (tbName.Text == "" || tbAddress.Text == "" || tbPhone.Text == ""
                || tbSubject.Text == "" || tbPassword.Text == "")
            {
                MessageBox.Show("All fields must be filled");
                return;
            }

            var teacher = db.teachers.Where(x => x.id == selected_id).FirstOrDefault(); // Ambil data guru berdasarkan ID
            teacher.name = tbName.Text; // Update data
            teacher.address = tbAddress.Text;
            teacher.phone = tbPhone.Text;
            teacher.subject = tbSubject.Text;
            teacher.password = tbPassword.Text;
            teacher.gender = cboGender.Text;

            db.SubmitChanges(); // Simpan perubahan
            clearFields(); // Kosongkan input
            showData(); // Tampilkan ulang data
            MessageBox.Show("Data successfully updated"); // Notifikasi berhasil
            selected_id = -1; // Reset ID
        }

        // Event handler untuk tombol Delete (Hapus data guru)
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selected_id == -1)
            {
                MessageBox.Show("Please select a row to delete"); // Jika belum ada yang dipilih
                return;
            }

            var teacher = db.teachers.Where(x => x.id == selected_id).FirstOrDefault(); // Cari guru berdasarkan ID
            db.teachers.DeleteOnSubmit(teacher); // Hapus guru dari database
            db.SubmitChanges(); // Simpan perubahan
            clearFields(); // Kosongkan input
            showData(); // Tampilkan ulang data
            MessageBox.Show("Data successfully deleted"); // Notifikasi berhasil
            selected_id = -1; // Reset ID
        }
    }
}
