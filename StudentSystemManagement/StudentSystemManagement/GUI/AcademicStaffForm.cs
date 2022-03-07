using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentSystemManagement;
using StudentSystemManagement.BLL;

namespace StudentSystemManagement.GUI
{
    public partial class AcademicStaffForm : Form
    {
        private List<School.Student> SinhViens;
        private List<School.Class> LopHocs;
        private List<School.Subject> MonHocs;
        private List<School.Score> Diems;
        private List<School.CHITIETMONHOC> ChiTietMonHocs;
        private List<School.TKB> ThoiKhoaBieus;

        public AcademicStaffForm()
        {
            InitializeComponent();
        }

        private void ReadClassCsvFile(string fileName)
        {
            StreamReader reader = new StreamReader(fileName);
            string line;
            bool FirstLine = true;
            string ClassCode = "";
            while (!reader.EndOfStream)
            {
                line = reader.ReadLine();
                string[] token = line.Split(',');
                if (FirstLine)
                {
                    FirstLine = false;
                    ClassCode = token[0];
                    if (!SSMBLL.IsExistClass(ClassCode, LopHocs))
                    {
                        LopHocs.Add(new School.Class()
                        {
                            MaLop = ClassCode,
                            TenLop = ""
                        });

                        SSMBLL.SaveDatabase("Insert into LOPHOC values ('" + ClassCode + "', null)");
                    }
                    else
                    {
                        var result = MessageBox.Show("Class is exist. Do you want to continue?", "Student system management", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                        if (result == DialogResult.No)
                        {
                            return;
                        }
                    }
                }
                else
                {
                    if (!SSMBLL.IsExistStudent(int.Parse(token[1]), SinhViens))
                    {
                        School.Student student = new School.Student()
                        {
                            MSSV = int.Parse(token[1]),
                            HoTen = token[2],
                            GioiTinh = token[3].Equals("Nam") ? School.GENDER.MALE : School.GENDER.FEMALE,
                            CMND = token[4],
                            MaLop = ClassCode
                        };
                        SinhViens.Add(student);
                        string Query = "INSERT INTO SINHVIEN VALUES (" + student.MSSV + ", N'" + student.HoTen + "', N'" + token[3] + "', '" + student.CMND + "', '" + student.MaLop + "')";
                        SSMBLL.SaveDatabase(Query);
                        Query = string.Format("INSERT INTO TAIKHOAN VALUES ('{0}', '{1}', {2})", student.MSSV, student.CMND, 1);
                        SSMBLL.SaveDatabase(Query);
                    }
                    else
                    {
                        var result = MessageBox.Show("MSSV " + int.Parse(token[1]) + " is exist. Do you want to continue?", "Student system management", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                        if (result == DialogResult.No)
                        {
                            return;
                        }

                    }
                }
            }
        }

        private bool IsCsvFile(string fileName)
        {
            return fileName.Substring(fileName.Length - 3).ToLower().Equals("csv");
        }


        private void ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadListCourse();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadListClass();
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadComboboxCourse(ref ListCourse, ListClass1.Text);
            LoadListCourse();
        }

        private void ComboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadListSchedule();
        }

        private void ClassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            var result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (IsCsvFile(dialog.FileName))
                {
                    ReadClassCsvFile(dialog.FileName);
                    LoadListView();
                }
            }
        }

        private void SchedulaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            var result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (IsCsvFile(dialog.FileName))
                {
                    ReadScheduleCsvFile(dialog.FileName);
                    LoadListView();
                }
            }
        }

        private void AcademicStaffForm_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadListView();
        }

        private void LoadListView()
        {
            //AddClassColumn();
            LoadComboboxClass(ref ListClass);
            LoadListClass();
            LoadComboboxClass(ref ListClass1);
            LoadComboboxCourse(ref ListCourse, ListClass1.Text);
            LoadListCourse();
            LoadComboboxClass(ref ScheduleClassComboBox);
            LoadListSchedule();
            //LoadListScore();
        }

        private void LoadListSchedule()
        {
            ScheduleListView.Clear();
            AddScheduleColumn();
            int i = 1;
            foreach (var Schedule in ThoiKhoaBieus)
            {
                if (Schedule.MaLop.Equals(ScheduleClassComboBox.Text))
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = i.ToString();
                    i++;
                    lvi.SubItems.Add(new ListViewItem.ListViewSubItem()
                    {
                        Text = Schedule.MaMonHoc
                    });
                    var Course = MonHocs.FirstOrDefault(x => x.MaMonHoc == Schedule.MaMonHoc);
                    lvi.SubItems.Add(new ListViewItem.ListViewSubItem()
                    {
                        Text = Course.TenMonHoc
                    });
                    var CourseDetail = ChiTietMonHocs.FirstOrDefault(x => x.MaMonHoc == Schedule.MaMonHoc);
                    lvi.SubItems.Add(new ListViewItem.ListViewSubItem()
                    {
                        Text = CourseDetail.PhongHoc
                    });
                    ScheduleListView.Items.Add(lvi);
                }
            }
        }

        private void AddScheduleColumn()
        {
            ScheduleListView.GridLines = true;
            ScheduleListView.View = View.Details;
            ScheduleListView.FullRowSelect = true;
            ScheduleListView.Columns.AddRange(new ColumnHeader[]
            {
                new ColumnHeader
                {
                    Text = "STT",
                    Width = 100
                },
                new ColumnHeader
                {
                    Text = "Ma môn",
                    Width = (ScheduleListView.Size.Width - 100) / 3
                },
                new ColumnHeader
                {
                    Text = "Tên môn",
                    Width = (ScheduleListView.Size.Width - 100) / 3
                },
                new ColumnHeader
                {
                    Text = "Phòng học",
                    Width = (ScheduleListView.Size.Width - 100) / 3
                },
            });
        }

        private void LoadComboboxCourse(ref ComboBox cb, string ClassCode)
        {
            cb.Text = "";
            cb.Items.Clear();
            foreach (var schedule in ThoiKhoaBieus)
            {
                if (schedule.MaLop.Equals(ClassCode))
                {
                    cb.Items.Add(schedule.MaMonHoc);
                }
            }
            if (cb.Items.Count > 0)
            {
                cb.Text = cb.Items[0].ToString();
            }
        }

        private void AddClassColumn()
        {
            ClassDetail.GridLines = true;
            ClassDetail.View = View.Details;
            ClassDetail.Columns.AddRange(new ColumnHeader[]
            {
                new ColumnHeader
                {
                    Text = "STT",
                    Width = 100
                },
                new ColumnHeader
                {
                    Text = "MSSV",
                    Width = (ClassDetail.Size.Width - 100) / 3
                },
                new ColumnHeader
                {
                    Text = "Họ tên",
                    Width = (ClassDetail.Size.Width - 100) / 3
                },
                new ColumnHeader
                {
                    Text = "Giới tính",
                    Width = (ClassDetail.Size.Width - 100) / 3
                },
                new ColumnHeader
                {
                    Text = "CMND",
                    Width = (ClassDetail.Size.Width - 100) / 3
                }
            });
        }
        private void AddCourseColumn()
        {
            CourseListView.GridLines = true;
            CourseListView.View = View.Details;
            CourseListView.FullRowSelect = true;
            CourseListView.Columns.AddRange(new ColumnHeader[]
            {
                new ColumnHeader
                {
                    Text = "STT",
                    Width = 100
                },
                new ColumnHeader
                {
                    Text = "MSSV",
                    Width = (CourseListView.Size.Width - 100) / 3
                },
                new ColumnHeader
                {
                    Text = "Họ tên",
                    Width = (CourseListView.Size.Width - 100) / 3
                },
                new ColumnHeader
                {
                    Text = "Giới tính",
                    Width = (CourseListView.Size.Width - 100) / 3
                },
                new ColumnHeader
                {
                    Text = "CMND",
                    Width = (CourseListView.Size.Width - 100) / 3
                }
            });
        }
        private void LoadListScore()
        {
            throw new NotImplementedException();
        }

        private void LoadListCourse()
        {
            CourseListView.Clear();
            AddCourseColumn();
            int i = 1;
            foreach (var CourseDetail in ChiTietMonHocs)
            {
                if (CourseDetail.MaMonHoc == ListCourse.Text)
                {
                    var student = SinhViens.FirstOrDefault(x => x.MSSV == CourseDetail.MSSV/* && x.MaLop == ListClass1.Text*/);
                    if (student != null)
                    {
                        ListViewItem lvi = new ListViewItem();
                        lvi.Tag = student;
                        lvi.Text = i.ToString();
                        i++;
                        lvi.SubItems.Add(new ListViewItem.ListViewSubItem()
                        {
                            Text = student.MSSV.ToString()
                        });
                        lvi.SubItems.Add(new ListViewItem.ListViewSubItem()
                        {
                            Text = student.HoTen
                        });
                        lvi.SubItems.Add(new ListViewItem.ListViewSubItem()
                        {
                            Text = student.GioiTinh == School.GENDER.MALE ? "Nam" : "Nữ"
                        });
                        lvi.SubItems.Add(new ListViewItem.ListViewSubItem()
                        {
                            Text = student.CMND
                        });
                        CourseListView.Items.Add(lvi);
                    }
                }
            }
            CourseListView.Items.Add(new ListViewItem()
            {
                Text = "ADD",
                Tag = null
            });
        }

        private void LoadListClass()
        {
            ClassDetail.Clear();
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
                    ClassDetail.Items.Add(lvi);
                }
            }
            ClassDetail.Items.Add(new ListViewItem()
            {
                Text = "ADD",
                Tag = null
            });

        }

        private void LoadComboboxClass(ref ComboBox cb)
        {
            cb.Items.Clear();
            foreach (var item in LopHocs)
            {
                cb.Items.Add(item.MaLop);
            }
            if (cb.Items.Count > 0)
            {
                cb.Text = ListClass.Items[0].ToString();
            }
        }

        private void LoadData()
        {
            SinhViens = SSMBLL.GetSinhViens();
            LopHocs = SSMBLL.GetLopHocs();
            MonHocs = SSMBLL.GetMonHocs();
            Diems = SSMBLL.GetDiems();
            ChiTietMonHocs = SSMBLL.GetChiTietMonHoc();
            ThoiKhoaBieus = SSMBLL.GetThoiKhoaBieu();
        }

        private void AcademicStaffForm_MaximumSizeChanged(object sender, EventArgs e)
        {
            LoadListView();
        }

        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ListView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var lvi = ClassDetail.HitTest(e.X, e.Y).Item;
            if (lvi != null)
            {
                if (lvi.Tag != null)
                {
                    var Student = lvi.Tag as School.Student;
                    var form = new AddAndEditStudentForm(Student, SinhViens);
                    form.FormClosing += Form_FormClosing;
                    form.ShowDialog();
                }
                else
                {
                    var form = new AddAndEditStudentForm(null, SinhViens);
                    form.FormClosing += Form_FormClosing;
                    form.ShowDialog();
                }
            }
        }
        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            var form = sender as AddAndEditStudentForm;
            var Student = form.GetSINHVIEN();
            if (Student == null)
            {
                return;
            }
            if (SSMBLL.IsExistStudent(Student.MSSV, SinhViens))
            {
                School.Student temp = SinhViens.Find(x => x.MSSV == Student.MSSV);

                temp = Student;
                string Query = string.Format("UPDATE SINHVIEN SET HoTen = N'{0}', GioiTinh = N'{1}', CMND = '{2}' WHERE MSSV = {3}", temp.HoTen, temp.GioiTinh == School.GENDER.MALE ? "Nam" : "Nữ", temp.CMND, temp.MSSV);
                SSMBLL.SaveDatabase(Query);
            }
            else
            {
                Student.MaLop = ListClass.Text;
                SinhViens.Add(Student);
                string Query = string.Format("INSERT INTO SINHVIEN VALUES ({0}, N'{1}', N'{2}', '{3}', '{4}')", Student.MSSV, Student.HoTen, Student.GioiTinh == School.GENDER.MALE ? "Nam" : "Nữ", Student.CMND, Student.MaLop);
                SSMBLL.SaveDatabase(Query);
                Query = string.Format("INSERT INTO TAIKHOAN VALUES ('{0}', '{1}', {2})", Student.MSSV, Student.CMND, 1);
                SSMBLL.SaveDatabase(Query);
            }
            //LoadComboboxClass();
            LoadListClass();
        }
        private void ReadScheduleCsvFile(string fileName)
        {
            StreamReader reader = new StreamReader(fileName);
            string line;
            bool FirstLine = true;
            string ClassCode = "";
            while (!reader.EndOfStream)
            {
                line = reader.ReadLine();
                string[] token = line.Split(',');
                if (FirstLine)
                {
                    FirstLine = false;
                    ClassCode = token[0];
                    if (!SSMBLL.IsExistClass(ClassCode, LopHocs))
                    {
                        LopHocs.Add(new School.Class()
                        {
                            MaLop = ClassCode,
                            TenLop = ""
                        });

                        SSMBLL.SaveDatabase("Insert into LOPHOC values ('" + ClassCode + "', null)");
                    }
                }
                else
                {
                    if (!SSMBLL.IsExistCourse(token[1], MonHocs))
                    {
                        MonHocs.Add(new School.Subject()
                        {
                            MaMonHoc = token[1],
                            TenMonHoc = token[2]
                        });
                        string Query = string.Format("INSERT INTO MONHOC VALUES ('{0}', N'{1}')", token[1], token[2]);
                        SSMBLL.SaveDatabase(Query);
                        ThoiKhoaBieus.Add(new School.TKB()
                        {
                            MaLop = ClassCode,
                            MaMonHoc = token[1]
                        });
                        Query = string.Format("INSERT INTO THOIKHOABIEU VALUES ('{0}', '{1}')", token[1], ClassCode);
                        SSMBLL.SaveDatabase(Query);
                        foreach (var student in SinhViens)
                        {
                            if (student.MaLop.Equals(ClassCode))
                            {
                                ChiTietMonHocs.Add(new School.CHITIETMONHOC()
                                {
                                    MSSV = student.MSSV,
                                    MaMonHoc = token[1],
                                    PhongHoc = token[3]
                                });
                                Query = string.Format("INSERT INTO CHITIETMONHOC VALUES ({0}, '{1}', '{2}')", student.MSSV, token[1], token[3]);
                                SSMBLL.SaveDatabase(Query);
                            }
                        }
                    }
                    else
                    {
                        var result = MessageBox.Show("Ma Mon Hoc " + token[1] + " is exist. Do you want to continue?", "Student system management", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.No)
                        {
                            return;
                        }
                    }
                }
            }
        }

        private void ListView2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var lvi = CourseListView.HitTest(e.X, e.Y).Item;
            if (lvi != null)
            {
                if (lvi.Tag != null)
                {
                    var Student = lvi.Tag as School.Student;
                    var form = new AddAndEditStudentForm(Student, SinhViens);
                    form.FormClosing += Form_FormClosing;
                    form.ShowDialog();
                }
                else
                {
                    var ctmh = ChiTietMonHocs.FirstOrDefault(x => x.MaMonHoc == ListCourse.Text);
                    var form = new ListStudentForm(SinhViens, LopHocs, ListCourse.Text, ctmh.PhongHoc, ref ChiTietMonHocs);
                    //form.FormClosing += Form_FormClosing;
                    form.ShowDialog();
                    LoadListCourse();
                }
            }

        }

        private void ListView2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                foreach (ListViewItem item in CourseListView.SelectedItems)
                {
                    string Query = string.Format("DELETE FROM CHITIETMONHOC WHERE MSSV = {0} AND MaMonHoc = '{1}'", item.SubItems[1].Text, ListCourse.Text);
                    SSMBLL.SaveDatabase(Query);
                    ChiTietMonHocs.Remove(ChiTietMonHocs.FirstOrDefault(x => x.MSSV == int.Parse(item.SubItems[1].Text) && x.MaMonHoc == ListCourse.Text));
                }
                LoadListCourse();
            }

        }
    }
}
