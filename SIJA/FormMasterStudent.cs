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
    public partial class FormMasterStudent : Form
    {
        DataBaseDataContext db = new DataBaseDataContext(); // Koneksi ke database menggunakan LINQ to SQL
        int selected_id = -1; // Menyimpan ID siswa yang sedang dipilih

        public FormMasterStudent()
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

        // Method untuk menampilkan data siswa di DataGridView
        void showData()
        {
            dgvData.Columns.Clear(); // Menghapus semua kolom sebelumnya untuk mencegah duplikasi

            // Mengambil data siswa dari database yang namanya mengandung teks dari TextBox pencarian
            var student = db.students.Where(x => x.name.Contains(tbSearch.Text))
                .Select(x => new {
                    x.id,
                    x.name,
                    x.@class,
                    x.gender,
                    x.address,
                    x.phone,
                });

            dgvData.DataSource = student; // Menampilkan data ke DataGridView
        }

        // Event handler ketika form pertama kali dimuat
        private void FormStudent_Load(object sender, EventArgs e)
        {
            showData(); // Menampilkan data siswa ke DataGridView
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
            tbClass.Text = "";
            cboGender.Text = "Male"; // Set default ke Male
        }

        // Event handler untuk tombol Insert (Tambah)
        private void btnInsert_Click(object sender, EventArgs e)
        {
            // Validasi semua input harus diisi
            if (tbName.Text == "" || tbAddress.Text == "" || tbPhone.Text == ""
                || tbClass.Text == "")
            {
                MessageBox.Show("All fields must be filled"); // Tampilkan pesan jika input kosong
                return;
            }

            var student = new student(); // Membuat objek siswa baru
            student.name = tbName.Text; // Mengisi properti siswa
            student.address = tbAddress.Text;
            student.phone = tbPhone.Text;
            student.@class = tbClass.Text;
            student.gender = cboGender.Text;

            db.students.InsertOnSubmit(student); // Menambahkan siswa ke database
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
                tbClass.Text = dgvData.Rows[e.RowIndex].Cells["class"].Value.ToString();
                cboGender.Text = dgvData.Rows[e.RowIndex].Cells["gender"].Value.ToString();
            }
        }

        // Event handler untuk tombol Update (Perbarui data siswa)
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selected_id == -1)
            {
                MessageBox.Show("Please select a row to update"); // Jika belum ada yang dipilih
                return;
            }

            // Validasi semua input harus diisi
            if (tbName.Text == "" || tbAddress.Text == "" || tbPhone.Text == ""
                || tbClass.Text == "")
            {
                MessageBox.Show("All fields must be filled"); // Tampilkan pesan jika input kosong
                return;
            }

            var student = db.students.Where(x => x.id == selected_id).FirstOrDefault(); // Ambil data siswa berdasarkan ID
            student.name = tbName.Text; // Update data
            student.address = tbAddress.Text;
            student.phone = tbPhone.Text;
            student.@class = tbClass.Text;
            student.gender = cboGender.Text;

            db.SubmitChanges(); // Simpan perubahan
            clearFields(); // Kosongkan input
            showData(); // Tampilkan ulang data
            MessageBox.Show("Data successfully updated"); // Notifikasi berhasil
            selected_id = -1; // Reset ID
        }

        // Event handler untuk tombol Delete (Hapus data siswa)
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selected_id == -1)
            {
                MessageBox.Show("Please select a row to delete"); // Jika belum ada yang dipilih
                return;
            }

            var student = db.students.Where(x => x.id == selected_id).FirstOrDefault(); // Cari siswa berdasarkan ID
            db.students.DeleteOnSubmit(student); // Hapus siswa dari database
            db.SubmitChanges(); // Simpan perubahan
            clearFields(); // Kosongkan input
            showData(); // Tampilkan ulang data
            MessageBox.Show("Data successfully deleted"); // Notifikasi berhasil
            selected_id = -1; // Reset ID
        }
    }
}
