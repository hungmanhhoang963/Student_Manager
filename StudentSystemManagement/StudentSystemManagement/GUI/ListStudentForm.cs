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
using StudentSystemManagement.BLL;
namespace StudentSystemManagement.GUI
{
    
    public partial class ListStudentForm : Form
    {
        List<School.Student> SinhViens;
        List<School.Class> LopHocs;
        string CourseCode;
        string Room;
        List<School.CHITIETMONHOC> ChiTietMonHocs;
        public ListStudentForm()
        {
            InitializeComponent();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadListClass();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadComboBoxClass()
        {
            ListClass.Items.Clear();
            foreach (var item in LopHocs)
            {
                ListClass.Items.Add(item.MaLop);
            }
            if (ListClass.Items.Count > 0)
            {
                ListClass.Text = ListClass.Items[0].ToString();
            }
        }
        private void AddClassColumn()
        {
            Students.GridLines = true;
            Students.View = View.Details;
            Students.FullRowSelect = true;
            Students.Columns.AddRange(new ColumnHeader[]
            {
                new ColumnHeader
                {
                    Text = "STT",
                    Width = 100
                },
                new ColumnHeader
                {
                    Text = "MSSV",
                    Width = (Students.Size.Width - 100) / 3
                },
                new ColumnHeader
                {
                    Text = "Họ tên",
                    Width = (Students.Size.Width - 100) / 3
                },
                new ColumnHeader
                {
                    Text = "Giới tính",
                    Width = (Students.Size.Width - 100) / 3
                },
                new ColumnHeader
                {
                    Text = "CMND",
                    Width = (Students.Size.Width - 100) / 3
                }
            });
        }

        private void LoadListClass()
        {
            Students.Clear();
            AddClassColumn();
            int i = 1;
            foreach (var item in SinhViens)
            {
                if (item.MaLop.Equals(ListClass.Text))
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Tag = item;
                    lvi.Text = i.ToString();
                    i++;
                    lvi.SubItems.Add(new ListViewItem.ListViewSubItem()
                    {
                        Text = item.MSSV.ToString()
                    });
                    lvi.SubItems.Add(new ListViewItem.ListViewSubItem()
                    {
                        Text = item.HoTen
                    });
                    lvi.SubItems.Add(new ListViewItem.ListViewSubItem()
                    {
                        Text = item.GioiTinh == School.GENDER.MALE ? "Nam" : "Nữ"
                    });
                    lvi.SubItems.Add(new ListViewItem.ListViewSubItem()
                    {
                        Text = item.CMND
                    });
                    Students.Items.Add(lvi);
                }
            }
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in Students.SelectedItems)
            {
                if (!SSMBLL.IsExistStudentInCourse(int.Parse(item.SubItems[1].Text), CourseCode, ChiTietMonHocs))
                {
                    string Query = string.Format("INSERT INTO CHITIETMONHOC VALUES({0}, '{1}', '{2}')", item.SubItems[1].Text, CourseCode, Room);
                    SSMBLL.SaveDatabase(Query);
                    ChiTietMonHocs.Add(new School.CHITIETMONHOC()
                    {
                        MSSV = int.Parse(item.SubItems[1].Text),
                        MaMonHoc = CourseCode,
                        PhongHoc = Room
                    });
                }
            }
            this.Close();
        }

        private void ListStudent_Load(object sender, EventArgs e)
        {
            LoadComboBoxClass();
            LoadListClass();
        }
        public ListStudentForm(List<School.Student> sinhViens, List<School.Class> lopHocs, string courseCode, string room, ref List<School.CHITIETMONHOC> chiTietMonHocs)
        {
            InitializeComponent();
            SinhViens = sinhViens;
            LopHocs = lopHocs;
            ChiTietMonHocs = chiTietMonHocs;
            CourseCode = courseCode;
            Room = room;
        }
    }
}
