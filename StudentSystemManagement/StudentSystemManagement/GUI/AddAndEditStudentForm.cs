using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentSystemManagement;
using School;
using StudentSystemManagement.BLL;
using StudentSystemManagement.GUI;
namespace StudentSystemManagement.GUI
{
    public partial class AddAndEditStudentForm : Form
    {
        Student Student;
        List<School.Student> SinhViens;
        public AddAndEditStudentForm(Student student, List<Student> sinhViens)
        {
            InitializeComponent();
            Student = student;
            SinhViens = sinhViens;
        }

        private void AddAndEditStudentForm_Load(object sender, EventArgs e)
        {
            if (Student != null)
            {
                MssvBox.Text = Student.MSSV.ToString().TrimEnd();
                MssvBox.Enabled = false;
                NameBox.Text = Student.HoTen.TrimEnd();
                if (Student.GioiTinh == School.GENDER.MALE)
                {
                    Male.Checked = true;
                }
                else
                {
                    Female.Checked = true;
                }
                CmndBox.Text = Student.CMND.TrimEnd();
            }
            else
            {
                Student = new School.Student();
            }
        }

        public School.Student GetSINHVIEN()
        {
            if (!IsValidInput())
            {
                return null;
            }
            Student.MSSV = int.Parse(MssvBox.Text);
            Student.HoTen = NameBox.Text;
            Student.GioiTinh = Male.Checked ? GENDER.MALE : GENDER.FEMALE;
            Student.CMND = CmndBox.Text;
            return Student;
        }
        public AddAndEditStudentForm()
        {
            InitializeComponent();
        }

        

        private bool IsValidInput()
        {
            bool result = true;
            if (MssvBox.Text == string.Empty)
            {
                MessageBox.Show("MSSV is empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
            }
            if (NameBox.Text == string.Empty)
            {
                MessageBox.Show("Ho Ten is empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
            }
            if (CmndBox.Text == string.Empty)
            {
                MessageBox.Show("CMND is empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
            }
            if (!IsNumeric(MssvBox.Text))
            {
                MessageBox.Show("MSSV Is Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
            }
            if (!IsNumeric(CmndBox.Text))
            {
                MessageBox.Show("CMND Is Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
            }
            return result;
        }

        private bool IsNumeric(string Regression)
        {
            foreach (var item in Regression)
            {
                if (!char.IsNumber(item))
                {
                    return false;
                }
            }
            return true;
        }
        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Add_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {

            if (IsValidInput())
            {
                Student = GetSINHVIEN();
                if (MssvBox.Enabled)
                {
                    if (SSMBLL.IsExistStudent(Student.MSSV, SinhViens))
                    {
                        MessageBox.Show("this is already exist", "Existed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                this.Close();
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MssvBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
